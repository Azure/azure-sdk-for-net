// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.ServerSentEvents;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Moq;
using Moq.Protected;
using NUnit.Framework;

namespace Azure.Generator.Tests.Primitives
{
    public class AzurePipelineResponseTests
    {
        [Test]
        public void ResponseSurvivesHttpMessageDisposal()
        {
            var response = new Mock<Response> { CallBase = true };
            var responseDisposed = false;
            response.SetupGet(r => r.Status).Returns(() => responseDisposed
                ? throw new ObjectDisposedException(nameof(Response))
                : 200);
            response.SetupGet(r => r.ReasonPhrase).Returns(() => responseDisposed
                ? throw new ObjectDisposedException(nameof(Response))
                : "OK");
            response.Protected()
                .Setup<IEnumerable<HttpHeader>>("EnumerateHeaders")
                .Returns(() => responseDisposed
                    ? throw new ObjectDisposedException(nameof(Response))
                    : [new HttpHeader("x-test", "value")]);
            response.Setup(r => r.Dispose()).Callback(() => responseDisposed = true);
            var networkStream = new TrackingStream([1, 2, 3]);
            response.SetupProperty(r => r.ContentStream, networkStream);
            using var message = CreateMessage(response.Object);
            using var pipelineResponse = new AzurePipelineResponse(message);

            message.Dispose();

            Assert.AreEqual(200, pipelineResponse.Status);
            Assert.AreEqual("OK", pipelineResponse.ReasonPhrase);
            Assert.IsTrue(pipelineResponse.Headers.TryGetValue("x-test", out string? headerValue));
            Assert.AreEqual("value", headerValue);
            Assert.AreSame(networkStream, pipelineResponse.ContentStream);
            Assert.IsFalse(networkStream.IsDisposed);
        }

        [Test]
        public void HeadersPreserveFirstValueForDuplicateNames()
        {
            using var message = CreateMessage(new DuplicateHeaderResponse());
            using var pipelineResponse = new AzurePipelineResponse(message);

            Assert.IsTrue(pipelineResponse.Headers.TryGetValue("x-duplicate", out string? headerValue));
            Assert.AreEqual("response", headerValue);
            Assert.IsTrue(pipelineResponse.Headers.TryGetValues("x-duplicate", out IEnumerable<string>? headerValues));
            CollectionAssert.AreEqual(new[] { "response" }, headerValues);
            CollectionAssert.AreEqual(
                new[]
                {
                    new KeyValuePair<string, string>("x-duplicate", "response"),
                    new KeyValuePair<string, string>("x-duplicate", "content")
                },
                pipelineResponse.Headers);
        }

        [Test]
        public void ContentUsesExposedMemoryStreamBuffer()
        {
            byte[] bytes = [1, 2, 3];
            var response = new Mock<Response> { CallBase = true };
            response.SetupProperty(
                r => r.ContentStream,
                new MemoryStream(bytes, 0, bytes.Length, writable: true, publiclyVisible: true));
            using var message = CreateMessage(response.Object);
            using var pipelineResponse = new AzurePipelineResponse(message);

            BinaryData content = pipelineResponse.Content;
            bytes[0] = 4;

            Assert.AreEqual(4, content.ToMemory().Span[0]);
        }

        [Test]
        public void BufferContentDisposesNetworkStream()
        {
            var response = new Mock<Response> { CallBase = true };
            var networkStream = new TrackingStream([1, 2, 3]);
            response.SetupProperty(r => r.ContentStream, networkStream);
            using var message = CreateMessage(response.Object);
            using var pipelineResponse = new AzurePipelineResponse(message);
            message.Dispose();

            BinaryData content = pipelineResponse.BufferContent();

            Assert.IsTrue(networkStream.IsDisposed);
            Assert.AreEqual(new byte[] { 1, 2, 3 }, content.ToArray());
            Assert.IsInstanceOf<MemoryStream>(pipelineResponse.ContentStream);
        }

        [Test]
        public void BufferContentHonorsCancellationToken()
        {
            var response = new Mock<Response> { CallBase = true };
            var networkStream = new TrackingStream([1, 2, 3]);
            response.SetupProperty(r => r.ContentStream, networkStream);
            using var message = CreateMessage(response.Object);
            using var pipelineResponse = new AzurePipelineResponse(message);
            message.Dispose();
            var cancellationToken = new CancellationToken(canceled: true);

            Assert.Throws<OperationCanceledException>(() => pipelineResponse.BufferContent(cancellationToken));
            Assert.IsFalse(networkStream.IsDisposed);
        }

        [Test]
        public async Task BufferContentAsyncDisposesNetworkStream()
        {
            var response = new Mock<Response> { CallBase = true };
            var networkStream = new TrackingStream([1, 2, 3]);
            response.SetupProperty(r => r.ContentStream, networkStream);
            using var message = CreateMessage(response.Object);
            using var pipelineResponse = new AzurePipelineResponse(message);
            message.Dispose();

            BinaryData content = await pipelineResponse.BufferContentAsync();

            Assert.IsTrue(networkStream.IsDisposed);
            Assert.AreEqual(new byte[] { 1, 2, 3 }, content.ToArray());
            Assert.IsInstanceOf<MemoryStream>(pipelineResponse.ContentStream);
        }

        [Test]
        public void DisposeDisposesExtractedStreamOnce()
        {
            var response = new Mock<Response> { CallBase = true };
            var networkStream = new TrackingStream([1, 2, 3]);
            response.SetupProperty(r => r.ContentStream, networkStream);
            using var message = CreateMessage(response.Object);
            var pipelineResponse = new AzurePipelineResponse(message);
            message.Dispose();

            pipelineResponse.Dispose();
            pipelineResponse.Dispose();

            Assert.AreEqual(1, networkStream.DisposeCount);
        }

        [Test]
        public async Task SseReconnectSendsLastEventIdAndAcceptsNoContent()
        {
            Uri? requestUri = null;
            string? lastEventId = null;
            string? requestBody = null;
            var handler = new TestHttpMessageHandler(async (request, cancellationToken) =>
            {
                requestUri = request.RequestUri;
                lastEventId = request.Headers.TryGetValues(
                    "Last-Event-ID",
                    out IEnumerable<string>? values)
                        ? string.Join(",", values)
                        : null;
                requestBody = request.Content is null
                    ? null
                    : await request.Content.ReadAsStringAsync(cancellationToken);
                return new HttpResponseMessage(HttpStatusCode.NoContent);
            });
            HttpPipeline pipeline = CreatePipeline(
                handler,
                enableAutoRedirect: true);
            using HttpMessage message = pipeline.CreateMessage(
                new RequestContext(),
                new StatusCodeClassifier(stackalloc ushort[] { 200 }));
            message.Request.Uri.Reset(new Uri("https://example.test/events"));
            message.Request.Method = RequestMethod.Post;
            message.Request.Headers.SetValue("x-test", "value");
            message.Request.Content = RequestContent.Create("request");

            AzurePipelineResponse.ConfigureSse(
                message,
                pipeline,
                new RequestContext());
            Func<string?, CancellationToken, ValueTask<PipelineResponse>> reconnect =
                AzurePipelineResponse.GetSseReconnectCallback(message);
            using PipelineResponse response = await reconnect("42", default);

            Assert.AreEqual(204, response.Status);
            Assert.AreEqual(
                new Uri("https://example.test/events"),
                requestUri);
            Assert.AreEqual("42", lastEventId);
            Assert.AreEqual("request", requestBody);
        }

        [Test]
        public async Task SseReconnectFollowsTemporaryRedirect()
        {
            var requestUris = new List<Uri?>();
            var requestMethods = new List<HttpMethod>();
            var requestBodies = new List<string?>();
            var handler = new TestHttpMessageHandler(async (request, cancellationToken) =>
            {
                requestUris.Add(request.RequestUri);
                requestMethods.Add(request.Method);
                requestBodies.Add(request.Content is null
                    ? null
                    : await request.Content.ReadAsStringAsync(
                        cancellationToken));
                if (requestUris.Count is 1 or 3)
                {
                    return new HttpResponseMessage(
                        HttpStatusCode.TemporaryRedirect)
                    {
                        Headers =
                        {
                            Location = new Uri("https://example.test/redirected")
                        }
                    };
                }
                return new HttpResponseMessage(HttpStatusCode.NoContent);
            });
            HttpPipeline pipeline = CreatePipeline(
                handler,
                enableAutoRedirect: true);
            var context = new RequestContext();
            using HttpMessage message = pipeline.CreateMessage(
                context,
                new StatusCodeClassifier(stackalloc ushort[] { 200 }));
            message.Request.Uri.Reset(new Uri("https://example.test/events"));
            message.Request.Method = RequestMethod.Post;
            message.Request.Content = RequestContent.Create("request");

            AzurePipelineResponse.ConfigureSse(message, pipeline, context);
            Func<string?, CancellationToken, ValueTask<PipelineResponse>> reconnect =
                AzurePipelineResponse.GetSseReconnectCallback(message);
            using PipelineResponse response = await reconnect(null, default);
            using PipelineResponse secondResponse = await reconnect(null, default);

            Assert.AreEqual(204, response.Status);
            Assert.AreEqual(204, secondResponse.Status);
            CollectionAssert.AreEqual(
                new[]
                {
                    new Uri("https://example.test/events"),
                    new Uri("https://example.test/redirected"),
                    new Uri("https://example.test/events"),
                    new Uri("https://example.test/redirected")
                },
                requestUris);
            CollectionAssert.AreEqual(
                new[]
                {
                    HttpMethod.Post,
                    HttpMethod.Post,
                    HttpMethod.Post,
                    HttpMethod.Post
                },
                requestMethods);
            CollectionAssert.AreEqual(
                new[] { "request", "request", "request", "request" },
                requestBodies);
        }

        [Test]
        public void SseReconnectRejectsCrossAuthorityRedirect()
        {
            var requestUris = new List<Uri?>();
            var handler = new TestHttpMessageHandler((request, _) =>
            {
                requestUris.Add(request.RequestUri);
                return Task.FromResult(new HttpResponseMessage(
                    HttpStatusCode.TemporaryRedirect)
                {
                    Headers =
                    {
                        Location = new Uri("https://redirected.test/events")
                    }
                });
            });
            HttpPipeline pipeline = CreatePipeline(
                handler,
                enableAutoRedirect: true);
            var context = new RequestContext();
            using HttpMessage message = pipeline.CreateMessage(
                context,
                new StatusCodeClassifier(stackalloc ushort[] { 200 }));
            message.Request.Uri.Reset(new Uri("https://example.test/events"));
            message.Request.Method = RequestMethod.Get;

            AzurePipelineResponse.ConfigureSse(message, pipeline, context);
            Func<string?, CancellationToken, ValueTask<PipelineResponse>> reconnect =
                AzurePipelineResponse.GetSseReconnectCallback(message);

            Assert.ThrowsAsync<InvalidOperationException>(
                async () => await reconnect(null, default));
            CollectionAssert.AreEqual(
                new[] { new Uri("https://example.test/events") },
                requestUris);
        }

        [TestCase(null)]
        [TestCase("//[bad")]
        public async Task SseResultRejectsInvalidInitialRedirectWithoutReplay(
            string? location)
        {
            int requestCount = 0;
            var redirectBody = new TrackingStream([1, 2, 3]);
            var handler = new TestHttpMessageHandler((_, _) =>
            {
                requestCount++;
                var response = new HttpResponseMessage(
                    HttpStatusCode.MovedPermanently)
                {
                    Content = new StreamContent(redirectBody)
                };
                if (location is not null)
                {
                    response.Headers.TryAddWithoutValidation(
                        "Location",
                        location);
                }
                return Task.FromResult(response);
            });
            HttpPipeline pipeline = CreatePipeline(
                handler,
                enableAutoRedirect: true);
            var context = new RequestContext();
            using HttpMessage message = pipeline.CreateMessage(
                context,
                new StatusCodeClassifier(stackalloc ushort[] { 200 }));
            message.Request.Uri.Reset(new Uri("https://example.test/events"));
            message.Request.Method = RequestMethod.Post;
            message.Request.Content = RequestContent.Create("request");
            AzurePipelineResponse.ConfigureSse(message, pipeline, context);
            await pipeline.SendAsync(message, default);
            var initial = new AzurePipelineResponse(message);
            Func<string?, CancellationToken, ValueTask<PipelineResponse>> reconnect =
                AzurePipelineResponse.GetSseReconnectCallback(message);
#pragma warning disable SCME0005 // Type is for evaluation purposes only and is subject to change or removal in future updates.
            AsyncStreamingClientResult<SseItem<BinaryData>> result =
                AzurePipelineResponse.CreateSse(initial, reconnect);
#pragma warning restore SCME0005 // Type is for evaluation purposes only and is subject to change or removal in future updates.

            Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await foreach (SseItem<BinaryData> _ in result)
                {
                }
            });

            Assert.AreEqual(1, requestCount);
            Assert.IsTrue(redirectBody.IsDisposed);
        }

        [Test]
        public async Task SseResultDisposesInitialRedirectBody()
        {
            var redirectBody = new TrackingStream([1, 2, 3]);
            var initial = new TestPipelineResponse(
                redirectBody,
                status: 301);
            var noContent = new TestPipelineResponse("", status: 204);
#pragma warning disable SCME0005 // Type is for evaluation purposes only and is subject to change or removal in future updates.
            AsyncStreamingClientResult<SseItem<BinaryData>> result =
                AzurePipelineResponse.CreateSse(
                    initial,
                    (_, _) =>
                        new ValueTask<PipelineResponse>(noContent));
#pragma warning restore SCME0005 // Type is for evaluation purposes only and is subject to change or removal in future updates.

            await foreach (SseItem<BinaryData> _ in result)
            {
                Assert.Fail("A redirect followed by 204 must not produce events.");
            }

            Assert.IsTrue(redirectBody.IsDisposed);
            Assert.IsTrue(noContent.IsDisposed);
        }

        [Test]
        public async Task SseResultRetriesAzureTransportFailure()
        {
            int requestCount = 0;
            var handler = new TestHttpMessageHandler((_, _) =>
            {
                requestCount++;
                return requestCount == 1
                    ? Task.FromException<HttpResponseMessage>(
                        new HttpRequestException("Connection failed."))
                    : Task.FromResult(
                        new HttpResponseMessage(HttpStatusCode.NoContent));
            });
            HttpPipeline pipeline = CreatePipeline(
                handler,
                maxRetries: 0);
            var context = new RequestContext();
            using HttpMessage message = pipeline.CreateMessage(
                context,
                new StatusCodeClassifier(stackalloc ushort[] { 200 }));
            message.Request.Uri.Reset(new Uri("https://example.test/events"));
            message.Request.Method = RequestMethod.Get;
            AzurePipelineResponse.ConfigureSse(message, pipeline, context);
            Func<string?, CancellationToken, ValueTask<PipelineResponse>> reconnect =
                AzurePipelineResponse.GetSseReconnectCallback(message);
            var initial = new TestPipelineResponse(
                "retry: 0\ndata: initial\n\n");
#pragma warning disable SCME0005 // Type is for evaluation purposes only and is subject to change or removal in future updates.
            AsyncStreamingClientResult<SseItem<BinaryData>> result =
                AzurePipelineResponse.CreateSse(initial, reconnect);
#pragma warning restore SCME0005 // Type is for evaluation purposes only and is subject to change or removal in future updates.
            var values = new List<string>();

            await foreach (SseItem<BinaryData> item in result)
            {
                values.Add(item.Data.ToString());
            }

            CollectionAssert.AreEqual(new[] { "initial" }, values);
            Assert.AreEqual(2, requestCount);
        }

        [Test]
        public async Task SseReconnectRemembersPermanentRedirect()
        {
            var requestUris = new List<Uri?>();
            var requestMethods = new List<HttpMethod>();
            var handler = new TestHttpMessageHandler((request, _) =>
            {
                requestUris.Add(request.RequestUri);
                requestMethods.Add(request.Method);
                if (requestUris.Count == 1)
                {
                    return Task.FromResult(new HttpResponseMessage(
                        HttpStatusCode.MovedPermanently)
                    {
                        Headers =
                        {
                            Location = new Uri(
                                "https://example.test/permanent")
                        }
                    });
                }

                return Task.FromResult(
                    new HttpResponseMessage(HttpStatusCode.NoContent));
            });
            HttpPipeline pipeline = CreatePipeline(
                handler,
                enableAutoRedirect: true);
            var context = new RequestContext();
            using HttpMessage message = pipeline.CreateMessage(
                context,
                new StatusCodeClassifier(stackalloc ushort[] { 200 }));
            message.Request.Uri.Reset(new Uri("https://example.test/events"));
            message.Request.Method = RequestMethod.Post;
            message.Request.Content = RequestContent.Create("request");

            AzurePipelineResponse.ConfigureSse(message, pipeline, context);
            await pipeline.SendAsync(message, default);
            Func<string?, CancellationToken, ValueTask<PipelineResponse>> reconnect =
                AzurePipelineResponse.GetSseReconnectCallback(message);
            using PipelineResponse response = await reconnect(null, default);

            Assert.AreEqual(204, response.Status);
            CollectionAssert.AreEqual(
                new[]
                {
                    new Uri("https://example.test/events"),
                    new Uri("https://example.test/permanent")
                },
                requestUris);
            CollectionAssert.AreEqual(
                new[] { HttpMethod.Post, HttpMethod.Get },
                requestMethods);
        }

        [Test]
        public async Task SseResultFollowsInitialPermanentRedirect()
        {
            var requestUris = new List<Uri?>();
            var handler = new TestHttpMessageHandler((request, _) =>
            {
                requestUris.Add(request.RequestUri);
                if (requestUris.Count == 1)
                {
                    return Task.FromResult(new HttpResponseMessage(
                        HttpStatusCode.MovedPermanently)
                    {
                        Headers =
                        {
                            Location = new Uri(
                                "https://example.test/permanent")
                        }
                    });
                }

                return Task.FromResult(
                    new HttpResponseMessage(HttpStatusCode.NoContent));
            });
            HttpPipeline pipeline = CreatePipeline(
                handler,
                enableAutoRedirect: true);
            var context = new RequestContext();
            using HttpMessage message = pipeline.CreateMessage(
                context,
                new StatusCodeClassifier(stackalloc ushort[] { 200 }));
            message.Request.Uri.Reset(new Uri("https://example.test/events"));
            message.Request.Method = RequestMethod.Get;
            AzurePipelineResponse.ConfigureSse(message, pipeline, context);
            await pipeline.SendAsync(message, default);
            var initial = new AzurePipelineResponse(message);
            Func<string?, CancellationToken, ValueTask<PipelineResponse>> reconnect =
                AzurePipelineResponse.GetSseReconnectCallback(message);
#pragma warning disable SCME0005 // Type is for evaluation purposes only and is subject to change or removal in future updates.
            AsyncStreamingClientResult<SseItem<BinaryData>> result =
                AzurePipelineResponse.CreateSse(initial, reconnect);
#pragma warning restore SCME0005 // Type is for evaluation purposes only and is subject to change or removal in future updates.

            await foreach (SseItem<BinaryData> _ in result)
            {
                Assert.Fail("A redirect followed by 204 must not produce events.");
            }

            CollectionAssert.AreEqual(
                new[]
                {
                    new Uri("https://example.test/events"),
                    new Uri("https://example.test/permanent")
                },
                requestUris);
        }

        [Test]
        public void SseConfigurationClassifiesNoContentAsSuccess()
        {
            HttpPipeline pipeline = CreatePipeline(
                new TestHttpMessageHandler((_, _) =>
                    Task.FromResult(
                        new HttpResponseMessage(HttpStatusCode.OK))));
            using HttpMessage message = pipeline.CreateMessage(
                new RequestContext(),
                new StatusCodeClassifier(stackalloc ushort[] { 200 }));
            message.Request.Uri.Reset(new Uri("https://example.test/events"));
            message.Request.Method = RequestMethod.Get;
            AzurePipelineResponse.ConfigureSse(
                message,
                pipeline,
                new RequestContext());
            var response = new Mock<Response> { CallBase = true };
            response.SetupGet(r => r.Status).Returns(204);
            message.Response = response.Object;

            Assert.IsFalse(message.ResponseClassifier.IsErrorResponse(message));
        }

        [Test]
        public async Task SseResultReconnectsAndStopsAtTerminalEvent()
        {
            var initial = new TestPipelineResponse(
                "retry: 0\nid: first\ndata: one\n\n");
            var reconnected = new TestPipelineResponse(
                "id: second\ndata: two\n\ndata: [DONE]\n\n");
            string? reconnectEventId = null;
#pragma warning disable SCME0005 // Type is for evaluation purposes only and is subject to change or removal in future updates.
            AsyncStreamingClientResult<SseItem<BinaryData>> result =
                AzurePipelineResponse.CreateSse(
                    initial,
                    (lastEventId, _) =>
                    {
                        reconnectEventId = lastEventId;
                        return new ValueTask<PipelineResponse>(reconnected);
                    },
                    static item => item.Data.ToString() == "[DONE]");
#pragma warning restore SCME0005 // Type is for evaluation purposes only and is subject to change or removal in future updates.
            var values = new List<string>();

            await foreach (SseItem<BinaryData> item in result)
            {
                values.Add(item.Data.ToString());
            }

            CollectionAssert.AreEqual(new[] { "one", "two" }, values);
            Assert.AreEqual("first", reconnectEventId);
            Assert.IsTrue(initial.IsDisposed);
            Assert.IsTrue(reconnected.IsDisposed);
        }

        [Test]
        public async Task SseResultInitialNoContentDoesNotReconnect()
        {
            var initial = new TestPipelineResponse("", status: 204);
            int reconnectCount = 0;
#pragma warning disable SCME0005 // Type is for evaluation purposes only and is subject to change or removal in future updates.
            AsyncStreamingClientResult<SseItem<BinaryData>> result =
                AzurePipelineResponse.CreateSse(
                    initial,
                    (_, _) =>
                    {
                        reconnectCount++;
                        return new ValueTask<PipelineResponse>(
                            new TestPipelineResponse("data: unexpected\n\n"));
                    });
#pragma warning restore SCME0005 // Type is for evaluation purposes only and is subject to change or removal in future updates.

            await foreach (SseItem<BinaryData> _ in result)
            {
                Assert.Fail("A 204 response must not produce events.");
            }

            Assert.AreEqual(0, reconnectCount);
            Assert.IsTrue(initial.IsDisposed);
        }

        [Test]
        public async Task SseResultUsesRequestContextCancellationForActiveRead()
        {
            var cancellationSource = new CancellationTokenSource();
            var context = new RequestContext
            {
                CancellationToken = cancellationSource.Token
            };
            HttpPipeline pipeline = CreatePipeline(
                new TestHttpMessageHandler((_, _) =>
                    Task.FromResult(
                        new HttpResponseMessage(HttpStatusCode.NoContent))));
            using HttpMessage message = pipeline.CreateMessage(
                context,
                new StatusCodeClassifier(stackalloc ushort[] { 200 }));
            message.Request.Uri.Reset(new Uri("https://example.test/events"));
            message.Request.Method = RequestMethod.Get;
            AzurePipelineResponse.ConfigureSse(message, pipeline, context);
            Func<string?, CancellationToken, ValueTask<PipelineResponse>> reconnect =
                AzurePipelineResponse.GetSseReconnectCallback(message);
            var stream = new BlockingReadStream();
            var initial = new TestPipelineResponse(stream);
#pragma warning disable SCME0005 // Type is for evaluation purposes only and is subject to change or removal in future updates.
            AsyncStreamingClientResult<SseItem<BinaryData>> result =
                AzurePipelineResponse.CreateSse(initial, reconnect);
#pragma warning restore SCME0005 // Type is for evaluation purposes only and is subject to change or removal in future updates.
            Task enumeration = EnumerateAsync(result);
            await stream.ReadStarted.Task;

            cancellationSource.Cancel();

            Assert.CatchAsync<OperationCanceledException>(
                async () => await enumeration);
            Assert.IsTrue(stream.IsDisposed);
        }

#pragma warning disable SCME0005 // Type is for evaluation purposes only and is subject to change or removal in future updates.
        private static async Task EnumerateAsync(
            AsyncStreamingClientResult<SseItem<BinaryData>> result)
        {
            await foreach (SseItem<BinaryData> _ in result)
            {
            }
        }
#pragma warning restore SCME0005 // Type is for evaluation purposes only and is subject to change or removal in future updates.

        private static HttpMessage CreateMessage(Response response)
            => new(new Mock<Request>().Object, new Mock<ResponseClassifier>().Object)
            {
                Response = response
            };

        private static HttpPipeline CreatePipeline(
            HttpMessageHandler handler,
            bool enableAutoRedirect = false,
            int maxRetries = 3)
        {
            var options = new TestClientOptions
            {
                Transport = new HttpClientTransport(new HttpClient(handler))
            };
            options.Retry.MaxRetries = maxRetries;
            if (!enableAutoRedirect)
            {
                return HttpPipelineBuilder.Build(
                    options,
                    Array.Empty<HttpPipelinePolicy>());
            }

            return HttpPipelineBuilder.Build(
                options,
                Array.Empty<HttpPipelinePolicy>(),
                Array.Empty<HttpPipelinePolicy>(),
                new HttpPipelineTransportOptions
                {
                    IsClientRedirectEnabled = true
                },
                responseClassifier: null);
        }

        private sealed class TestClientOptions : ClientOptions
        {
        }

        private sealed class TestHttpMessageHandler(
            Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> send)
            : HttpMessageHandler
        {
            protected override Task<HttpResponseMessage> SendAsync(
                HttpRequestMessage request,
                CancellationToken cancellationToken)
                => send(request, cancellationToken);
        }

        private sealed class TestPipelineResponse : PipelineResponse
        {
            private Stream? _contentStream;

            internal TestPipelineResponse(string content, int status = 200)
            {
                Status = status;
                Content = BinaryData.FromString(content);
                _contentStream = status == 204 ? null : Content.ToStream();
            }

            internal TestPipelineResponse(Stream content, int status = 200)
            {
                Status = status;
                Content = BinaryData.Empty;
                _contentStream = content;
            }

            public bool IsDisposed { get; private set; }
            public override int Status { get; }
            public override string ReasonPhrase => "OK";
            public override Stream? ContentStream
            {
                get => _contentStream;
                set => _contentStream = value;
            }
            public override BinaryData Content { get; }
            protected override PipelineResponseHeaders HeadersCore
                => throw new NotImplementedException();
            public override BinaryData BufferContent(
                CancellationToken cancellationToken = default)
                => Content;
            public override ValueTask<BinaryData> BufferContentAsync(
                CancellationToken cancellationToken = default)
                => new ValueTask<BinaryData>(Content);

            public override void Dispose()
            {
                _contentStream?.Dispose();
                _contentStream = null;
                IsDisposed = true;
            }
        }

        private sealed class BlockingReadStream : Stream
        {
            private readonly TaskCompletionSource<int> _readCompletion =
                new(TaskCreationOptions.RunContinuationsAsynchronously);

            internal TaskCompletionSource<object?> ReadStarted { get; } =
                new(TaskCreationOptions.RunContinuationsAsynchronously);

            internal bool IsDisposed { get; private set; }

            public override bool CanRead => true;
            public override bool CanSeek => false;
            public override bool CanWrite => false;
            public override long Length => throw new NotSupportedException();
            public override long Position
            {
                get => throw new NotSupportedException();
                set => throw new NotSupportedException();
            }

            public override int Read(byte[] buffer, int offset, int count)
                => throw new NotSupportedException();

            public override async ValueTask<int> ReadAsync(
                Memory<byte> buffer,
                CancellationToken cancellationToken = default)
            {
                ReadStarted.TrySetResult(null);
                using CancellationTokenRegistration registration =
                    cancellationToken.Register(
                        () => _readCompletion.TrySetCanceled());
                return await _readCompletion.Task;
            }

            protected override void Dispose(bool disposing)
            {
                IsDisposed = true;
                _readCompletion.TrySetCanceled();
                base.Dispose(disposing);
            }

            public override void Flush() => throw new NotSupportedException();
            public override long Seek(long offset, SeekOrigin origin)
                => throw new NotSupportedException();
            public override void SetLength(long value)
                => throw new NotSupportedException();
            public override void Write(byte[] buffer, int offset, int count)
                => throw new NotSupportedException();
        }

        private sealed class DuplicateHeaderResponse : Response
        {
            private int _getValuesCallCount;

            public override int Status => 200;

            public override string ReasonPhrase => "OK";

            public override Stream? ContentStream { get; set; }

            public override string ClientRequestId { get; set; } = string.Empty;

            public override void Dispose()
            {
            }

            protected override bool TryGetHeader(string name, out string value)
            {
                value = "response";
                return true;
            }

            protected override bool TryGetHeaderValues(string name, out IEnumerable<string> values)
            {
                values = _getValuesCallCount++ == 0 ? ["response"] : ["content"];
                return true;
            }

            protected override bool ContainsHeader(string name) => true;

            protected override IEnumerable<HttpHeader> EnumerateHeaders()
            {
                yield return new HttpHeader("x-duplicate", "response");
                yield return new HttpHeader("x-duplicate", "content");
            }
        }

        private sealed class TrackingStream : Stream
        {
            private readonly MemoryStream _inner;

            public TrackingStream(byte[] content)
            {
                _inner = new MemoryStream(content);
            }

            public bool IsDisposed => DisposeCount > 0;

            public int DisposeCount { get; private set; }

            public override bool CanRead => _inner.CanRead;
            public override bool CanSeek => _inner.CanSeek;
            public override bool CanWrite => _inner.CanWrite;
            public override long Length => _inner.Length;

            public override long Position
            {
                get => _inner.Position;
                set => _inner.Position = value;
            }

            public override void Flush() => _inner.Flush();

            public override int Read(byte[] buffer, int offset, int count)
                => _inner.Read(buffer, offset, count);

            public override long Seek(long offset, SeekOrigin origin)
                => _inner.Seek(offset, origin);

            public override void SetLength(long value)
                => _inner.SetLength(value);

            public override void Write(byte[] buffer, int offset, int count)
                => _inner.Write(buffer, offset, count);

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    DisposeCount++;
                    _inner.Dispose();
                }

                base.Dispose(disposing);
            }
        }
    }
}
