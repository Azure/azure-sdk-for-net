// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class SseHttpPipelineResponseHandlerTests
    {
        [Test]
        public async Task ReconnectsByDefaultAndSendsLastEventId()
        {
            int requestCount = 0;
            string? lastEventId = null;
            var transport = new MockTransport(request =>
            {
                requestCount++;
                request.Headers.TryGetValue(
                    "Last-Event-ID",
                    out lastEventId);
                return requestCount == 1
                    ? CreateDroppedResponse(
                        "retry: 0\nid: first\ndata: one\n\n")
                    : new MockResponse(204);
            });
            HttpPipeline pipeline = new(transport);
            using HttpMessage message = CreateMessage(
                pipeline,
                new Uri("https://example.test/events"));

            await pipeline.SendAsync(message, CancellationToken.None);
            Stream stream = message.ExtractResponseContent()!;
            message.Dispose();
            string content = await ReadToEndAsync(stream);

            StringAssert.Contains("data: one", content);
            Assert.AreEqual(2, requestCount);
            Assert.AreEqual("first", lastEventId);
        }

        [Test]
        public async Task EmptyIdRemovesLastEventIdHeader()
        {
            int requestCount = 0;
            string? lastEventId = null;
            var transport = new MockTransport(request =>
            {
                requestCount++;
                request.Headers.TryGetValue(
                    "Last-Event-ID",
                    out lastEventId);
                return requestCount == 1
                    ? CreateDroppedResponse(
                        "retry: 0\nid: first\ndata: one\n\n" +
                        "id:\ndata: two\n\n")
                    : new MockResponse(204);
            });
            HttpPipeline pipeline = new(transport);
            using HttpMessage message = CreateMessage(
                pipeline,
                new Uri("https://example.test/events"));

            await pipeline.SendAsync(message, CancellationToken.None);
            await ReadToEndAsync(message.Response.ContentStream!);

            Assert.AreEqual(2, requestCount);
            Assert.IsNull(lastEventId);
        }

        [Test]
        public async Task PreservesInitialLastEventIdUntilUpdated()
        {
            int requestCount = 0;
            string? lastEventId = null;
            var transport = new MockTransport(request =>
            {
                requestCount++;
                request.Headers.TryGetValue(
                    "Last-Event-ID",
                    out lastEventId);
                return requestCount == 1
                    ? CreateDroppedResponse(
                        "retry: 0\ndata: one\n\n")
                    : new MockResponse(204);
            });
            HttpPipeline pipeline = new(transport);
            using HttpMessage message = CreateMessage(
                pipeline,
                new Uri("https://example.test/events"),
                initialLastEventId: "prior");

            await pipeline.SendAsync(message, CancellationToken.None);
            await ReadToEndAsync(message.Response.ContentStream!);

            Assert.AreEqual(2, requestCount);
            Assert.AreEqual("prior", lastEventId);
        }

        [Test]
        public async Task InitialNoContentIsSuccessfulAndDoesNotReconnect()
        {
            int requestCount = 0;
            var transport = new MockTransport(_ =>
            {
                requestCount++;
                return new MockResponse(204);
            });
            HttpPipeline pipeline = new(transport);
            using HttpMessage message = CreateMessage(
                pipeline,
                new Uri("https://example.test/events"));
            message.ResponseClassifier =
                new StatusCodeClassifier(new ushort[] { 200 });

            await pipeline.SendAsync(message, CancellationToken.None);

            Assert.AreEqual(204, message.Response.Status);
            Assert.IsFalse(message.Response.IsError);
            Assert.AreEqual(1, requestCount);
        }

        [Test]
        public async Task PermanentRedirectIsRemembered()
        {
            var requestUris = new List<Uri>();
            var lastEventIds = new List<string?>();
            var transport = new MockTransport(request =>
            {
                requestUris.Add(request.Uri.ToUri());
                request.Headers.TryGetValue(
                    "Last-Event-ID",
                    out string? lastEventId);
                lastEventIds.Add(lastEventId);
                return requestUris.Count switch
                {
                    1 => new MockResponse(301).AddHeader(
                        "Location",
                        "https://example.test/permanent"),
                    2 => CreateDroppedResponse(
                        "retry: 0\ndata: one\n\n"),
                    _ => new MockResponse(204)
                };
            });
            HttpPipeline pipeline = new(transport);
            using HttpMessage message = CreateMessage(
                pipeline,
                new Uri("https://example.test/events"),
                initialLastEventId: "prior");

            await pipeline.SendAsync(message, CancellationToken.None);
            await ReadToEndAsync(message.Response.ContentStream!);

            CollectionAssert.AreEqual(
                new[]
                {
                    new Uri("https://example.test/events"),
                    new Uri("https://example.test/permanent"),
                    new Uri("https://example.test/permanent")
                },
                requestUris);
            CollectionAssert.AreEqual(
                new[] { "prior", "prior", "prior" },
                lastEventIds);
        }

        [Test]
        public void CrossAuthorityRedirectIsRejected()
        {
            var transport = new MockTransport(
                new MockResponse(307).AddHeader(
                    "Location",
                    "https://redirected.test/events"));
            HttpPipeline pipeline = new(
                transport,
                new HttpPipelinePolicy[]
                {
                    new RedirectPolicy(allowAutoRedirect: true)
                });
            using HttpMessage message = CreateMessage(
                pipeline,
                new Uri("https://example.test/events"));

            Assert.ThrowsAsync<InvalidOperationException>(
                async () => await pipeline.SendAsync(
                    message,
                    CancellationToken.None));
            Assert.AreEqual(1, transport.Requests.Count);
        }

        [Test]
        public async Task TemporaryRedirectPreservesPostAndBody()
        {
            var requestUris = new List<Uri>();
            var requestMethods = new List<RequestMethod>();
            var requestBodies = new List<string?>();
            var transport = new MockTransport(request =>
            {
                requestUris.Add(request.Uri.ToUri());
                requestMethods.Add(request.Method);
                requestBodies.Add(ReadContent(request.Content));
                return requestUris.Count switch
                {
                    1 => new MockResponse(307).AddHeader(
                        "Location",
                        "https://example.test/temporary"),
                    2 => CreateDroppedResponse(
                        "retry: 0\ndata: one\n\n"),
                    _ => new MockResponse(204)
                };
            });
            HttpPipeline pipeline = new(transport);
            using HttpMessage message = CreateMessage(
                pipeline,
                new Uri("https://example.test/events"),
                RequestMethod.Post,
                BinaryData.FromString("request"));

            await pipeline.SendAsync(message, CancellationToken.None);
            await ReadToEndAsync(message.Response.ContentStream!);

            CollectionAssert.AreEqual(
                new[]
                {
                    new Uri("https://example.test/events"),
                    new Uri("https://example.test/temporary"),
                    new Uri("https://example.test/events")
                },
                requestUris);
            CollectionAssert.AreEqual(
                new[]
                {
                    RequestMethod.Post,
                    RequestMethod.Post,
                    RequestMethod.Post
                },
                requestMethods);
            CollectionAssert.AreEqual(
                new[] { "request", "request", "request" },
                requestBodies);
        }

        [Test]
        public async Task GracefulEndOfStreamDoesNotReconnect()
        {
            int requestCount = 0;
            var transport = new MockTransport(_ =>
            {
                requestCount++;
                return CreateSseResponse(
                    "retry: 0\nid: first\ndata: one\n\ndata: two\n\n");
            });
            HttpPipeline pipeline = new(transport);
            using HttpMessage message = CreateMessage(
                pipeline,
                new Uri("https://example.test/events"));

            await pipeline.SendAsync(message, CancellationToken.None);
            string content = await ReadToEndAsync(
                message.Response.ContentStream!);

            StringAssert.Contains("data: one", content);
            StringAssert.Contains("data: two", content);
            Assert.AreEqual(
                1,
                requestCount,
                "A stream that completes normally must not be replayed.");
        }

        [Test]
        public void SyncGracefulEndOfStreamDoesNotReconnect()
        {
            var transport = new SyncOnlyTransport(_ =>
                CreateSseResponse(
                    "retry: 0\ndata: one\n\n"));
            HttpPipeline pipeline = new(transport);
            using HttpMessage message = CreateMessage(
                pipeline,
                new Uri("https://example.test/events"));

            pipeline.Send(message, CancellationToken.None);
            string content = ReadToEnd(
                message.Response.ContentStream!);

            StringAssert.Contains("data: one", content);
            Assert.AreEqual(
                1,
                transport.RequestCount,
                "A stream that completes normally must not be replayed.");
        }

        [Test]
        public async Task NonSseResponseIsNotWrapped()
        {
            int requestCount = 0;
            var transport = new MockTransport(_ =>
            {
                requestCount++;
                return new MockResponse(200).SetContent("content");
            });
            HttpPipeline pipeline = new(transport);
            using HttpMessage message = pipeline.CreateMessage();
            message.BufferResponse = false;
            message.Request.Method = RequestMethod.Get;
            message.Request.Uri.Reset(
                new Uri("https://example.test/events"));
            message.Request.Headers.Add(
                "Accept",
                "application/x-text/event-stream-suffix");

            await pipeline.SendAsync(message, CancellationToken.None);
            string content = await ReadToEndAsync(
                message.Response.ContentStream!);

            Assert.AreEqual("content", content);
            Assert.AreEqual(1, requestCount);
        }

        [Test]
        public async Task ReadCancellationCancelsReconnectRequest()
        {
            var transport = new CancellationAwareTransport();
            HttpPipeline pipeline = new(transport);
            HttpMessage message = CreateMessage(
                pipeline,
                new Uri("https://example.test/events"));
            await pipeline.SendAsync(message, CancellationToken.None);
            Stream stream = message.ExtractResponseContent()!;
            message.Dispose();
            var buffer = new byte[128];
            using var cancellation = new CancellationTokenSource();

            Assert.Greater(
                await stream.ReadAsync(
                    buffer,
                    0,
                    buffer.Length,
                    cancellation.Token),
                0);
            Task<int> reconnectRead = stream.ReadAsync(
                buffer,
                0,
                buffer.Length,
                cancellation.Token);
            await transport.ReconnectStarted.Task;
            cancellation.Cancel();

            Assert.CatchAsync<OperationCanceledException>(
                async () => await reconnectRead);
            stream.Dispose();
        }

        [Test]
        public async Task AuthenticationPolicyRunsForReconnectRequest()
        {
            int requestCount = 0;
            var authorizationHeaders = new List<string>();
            var transport = new MockTransport(request =>
            {
                requestCount++;
                request.Headers.TryGetValue(
                    "Authorization",
                    out string? authorization);
                authorizationHeaders.Add(authorization!);
                return requestCount == 1
                    ? CreateDroppedResponse(
                        "retry: 0\ndata: one\n\n")
                    : new MockResponse(204);
            });
            var policy = new RotatingAuthenticationPolicy();
            HttpPipeline pipeline = new(
                transport,
                new HttpPipelinePolicy[] { policy });
            using HttpMessage message = CreateMessage(
                pipeline,
                new Uri("https://example.test/events"));

            await pipeline.SendAsync(message, CancellationToken.None);
            await ReadToEndAsync(message.Response.ContentStream!);

            CollectionAssert.AreEqual(
                new[] { "Bearer token-1", "Bearer token-2" },
                authorizationHeaders);
        }

        [Test]
        public void SyncSendFollowsInitialRedirect()
        {
            int requestCount = 0;
            var transport = new MockTransport(_ =>
            {
                requestCount++;
                return requestCount == 1
                    ? new MockResponse(307).AddHeader(
                        "Location",
                        "https://example.test/redirected")
                    : CreateSseResponse(
                        "data: one\n\n");
            });
            HttpPipeline pipeline = new(transport);
            using HttpMessage message = CreateMessage(
                pipeline,
                new Uri("https://example.test/events"));

            pipeline.Send(message, CancellationToken.None);

            Assert.AreEqual(200, message.Response.Status);
            Assert.AreEqual(2, requestCount);
        }

        [Test]
        public void SyncReadReconnectsAndSendsLastEventId()
        {
            var transport = new SyncOnlyTransport(requestCount =>
                requestCount == 1
                    ? CreateDroppedResponse(
                        "retry: 0\nid: first\ndata: one\n\n")
                    : new MockResponse(204));
            HttpPipeline pipeline = new(transport);
            using HttpMessage message = CreateMessage(
                pipeline,
                new Uri("https://example.test/events"));

            pipeline.Send(message, CancellationToken.None);
            Stream stream = message.ExtractResponseContent()!;
            string content = ReadToEnd(stream);

            StringAssert.Contains("data: one", content);
            Assert.AreEqual(2, transport.RequestCount);
            Assert.AreEqual("first", transport.LastEventId);
        }

        [Test]
        public void SyncReadReconnectsAfterConnectionDrop()
        {
            var transport = new SyncOnlyTransport(requestCount =>
                requestCount == 1
                    ? CreateDroppedResponse(
                        "retry: 0\ndata: one\n\n")
                    : requestCount == 2
                        ? CreateDroppedResponse(
                            "data: two\n\n")
                        : new MockResponse(204));
            HttpPipeline pipeline = new(transport);
            using HttpMessage message = CreateMessage(
                pipeline,
                new Uri("https://example.test/events"));

            pipeline.Send(message, CancellationToken.None);
            Stream stream = message.ExtractResponseContent()!;
            string content = ReadToEnd(stream);

            StringAssert.Contains("data: one", content);
            StringAssert.Contains("data: two", content);
            Assert.AreEqual(3, transport.RequestCount);
        }

        [Test]
        public async Task AsyncReadOnSyncEstablishedStreamUsesSyncTransport()
        {
            var transport = new SyncOnlyTransport(requestCount =>
                requestCount == 1
                    ? CreateDroppedResponse(
                        "retry: 0\nid: first\ndata: one\n\n")
                    : new MockResponse(204));
            HttpPipeline pipeline = new(transport);
            using HttpMessage message = CreateMessage(
                pipeline,
                new Uri("https://example.test/events"));

            pipeline.Send(message, CancellationToken.None);
            Stream stream = message.ExtractResponseContent()!;
            string content = await ReadToEndAsync(stream);

            StringAssert.Contains("data: one", content);
            Assert.AreEqual(2, transport.RequestCount);
            Assert.AreEqual("first", transport.LastEventId);
        }

        [Test]
        public void SyncReadOnAsyncEstablishedStreamUsesAsyncTransport()
        {
            var transport = new AsyncOnlyTransport(requestCount =>
                requestCount == 1
                    ? CreateDroppedResponse(
                        "retry: 0\nid: first\ndata: one\n\n")
                    : new MockResponse(204));
            HttpPipeline pipeline = new(transport);
            using HttpMessage message = CreateMessage(
                pipeline,
                new Uri("https://example.test/events"));

            pipeline.SendAsync(message, CancellationToken.None)
                .AsTask().GetAwaiter().GetResult();
            Stream stream = message.ExtractResponseContent()!;
            string content = ReadToEnd(stream);

            StringAssert.Contains("data: one", content);
            Assert.AreEqual(2, transport.RequestCount);
            Assert.AreEqual("first", transport.LastEventId);
        }

        [Test]
        public async Task DisposingStreamDisposesReconnectResponse()
        {
            int requestCount = 0;
            MockResponse? reconnectResponse = null;
            var transport = new MockTransport(_ =>
            {
                requestCount++;
                if (requestCount == 1)
                {
                    return CreateDroppedResponse(
                        "retry: 0\ndata: one\n\n");
                }

                reconnectResponse = CreateDroppedResponse(
                    "data: two\n\n");
                return reconnectResponse;
            });
            HttpPipeline pipeline = new(transport);
            using HttpMessage message = CreateMessage(
                pipeline,
                new Uri("https://example.test/events"));
            await pipeline.SendAsync(message, CancellationToken.None);
            Stream stream = message.Response.ContentStream!;
            var buffer = new byte[128];

            Assert.Greater(
                await stream.ReadAsync(
                    buffer,
                    0,
                    buffer.Length),
                0);
            Assert.Greater(
                await stream.ReadAsync(
                    buffer,
                    0,
                    buffer.Length),
                0);
            stream.Dispose();

            Assert.IsNotNull(reconnectResponse);
            Assert.IsTrue(reconnectResponse!.IsDisposed);
        }

        [Test]
        public async Task ForceGetRedirectDropsBodyAndContentHeaders()
        {
            int requestCount = 0;
            var transport = new MockTransport(request =>
            {
                requestCount++;
                if (requestCount == 2)
                {
                    Assert.AreEqual(
                        RequestMethod.Get,
                        request.Method);
                    Assert.IsNull(request.Content);
                    Assert.IsFalse(
                        request.Headers.Contains(
                            "Content-Encoding"));
                }

                return requestCount == 1
                    ? new MockResponse(303).AddHeader(
                        "Location",
                        "https://example.test/redirected")
                    : new MockResponse(204);
            });
            HttpPipeline pipeline = new(transport);
            using HttpMessage message = CreateMessage(
                pipeline,
                new Uri("https://example.test/events"),
                RequestMethod.Post,
                BinaryData.FromString("request"));
            message.Request.Headers.Add(
                "Content-Encoding",
                "gzip");

            await pipeline.SendAsync(
                message,
                CancellationToken.None);

            Assert.AreEqual(204, message.Response.Status);
            Assert.AreEqual(2, requestCount);
        }

        [Test]
        public async Task RequestAwareClassifierHandlesReconnectResponse()
        {
            int requestCount = 0;
            var transport = new MockTransport(_ =>
            {
                requestCount++;
                return requestCount switch
                {
                    1 => CreateDroppedResponse(
                        "retry: 0\ndata: one\n\n"),
                    2 => new MockResponse(503),
                    _ => new MockResponse(204)
                };
            });
            HttpPipeline pipeline = new(transport);
            using HttpMessage message = CreateMessage(
                pipeline,
                new Uri("https://example.test/events"));
            message.ResponseClassifier =
                new RequestAwareClassifier();

            await pipeline.SendAsync(
                message,
                CancellationToken.None);
            await ReadToEndAsync(
                message.Response.ContentStream!);

            Assert.AreEqual(3, requestCount);
        }

        [Test]
        public async Task NonEventStreamContentTypeIsNotWrapped()
        {
            int requestCount = 0;
            var transport = new MockTransport(_ =>
            {
                requestCount++;
                return new MockResponse(200)
                    .AddHeader("Content-Type", "application/json")
                    .SetContent("{\"value\":1}");
            });
            HttpPipeline pipeline = new(transport);
            using HttpMessage message = CreateMessage(
                pipeline,
                new Uri("https://example.test/events"));

            await pipeline.SendAsync(message, CancellationToken.None);
            string content = await ReadToEndAsync(
                message.Response.ContentStream!);

            Assert.AreEqual(
                "{\"value\":1}",
                content,
                "A body that is not an event stream must be delivered unchanged instead of being parsed as events.");
            Assert.AreEqual(1, requestCount);
        }

        [Test]
        public void SyncNonEventStreamContentTypeIsNotWrapped()
        {
            var transport = new SyncOnlyTransport(_ =>
                new MockResponse(200)
                    .AddHeader("Content-Type", "application/json")
                    .SetContent("{\"value\":1}"));
            HttpPipeline pipeline = new(transport);
            using HttpMessage message = CreateMessage(
                pipeline,
                new Uri("https://example.test/events"));

            pipeline.Send(message, CancellationToken.None);
            string content = ReadToEnd(
                message.Response.ContentStream!);

            Assert.AreEqual("{\"value\":1}", content);
        }

        [Test]
        public async Task MissingContentTypeIsNotWrapped()
        {
            var transport = new MockTransport(_ =>
                new MockResponse(200).SetContent("data: one\n"));
            HttpPipeline pipeline = new(transport);
            using HttpMessage message = CreateMessage(
                pipeline,
                new Uri("https://example.test/events"));

            await pipeline.SendAsync(message, CancellationToken.None);
            string content = await ReadToEndAsync(
                message.Response.ContentStream!);

            Assert.AreEqual(
                "data: one\n",
                content,
                "Without a text/event-stream content type the response must pass through untouched.");
        }

        [Test]
        public async Task EventStreamContentTypeWithParametersReconnects()
        {
            int requestCount = 0;
            var transport = new MockTransport(_ =>
            {
                requestCount++;
                if (requestCount > 1)
                {
                    return new MockResponse(204);
                }

                var dropped = new MockResponse(200)
                {
                    ContentStream = new ThrowAtEndStream(
                        "retry: 0\ndata: one\n\n")
                };
                dropped.AddHeader(
                    "Content-Type",
                    "text/event-stream; charset=utf-8");
                return dropped;
            });
            HttpPipeline pipeline = new(transport);
            using HttpMessage message = CreateMessage(
                pipeline,
                new Uri("https://example.test/events"));

            await pipeline.SendAsync(message, CancellationToken.None);
            string content = await ReadToEndAsync(
                message.Response.ContentStream!);

            StringAssert.Contains("data: one", content);
            Assert.AreEqual(
                2,
                requestCount,
                "A media type parameter must not disable reconnection.");
        }

        [Test]
        public async Task ReconnectWithNonEventStreamContentTypeEndsStream()
        {
            int requestCount = 0;
            var transport = new MockTransport(_ =>
            {
                requestCount++;
                return requestCount == 1
                    ? CreateDroppedResponse(
                        "retry: 0\ndata: one\n\n")
                    : new MockResponse(200)
                        .AddHeader("Content-Type", "application/json")
                        .SetContent("data: gateway\n\n");
            });
            HttpPipeline pipeline = new(transport);
            using HttpMessage message = CreateMessage(
                pipeline,
                new Uri("https://example.test/events"));

            await pipeline.SendAsync(message, CancellationToken.None);
            string content = await ReadToEndAsync(
                message.Response.ContentStream!);

            StringAssert.Contains("data: one", content);
            StringAssert.DoesNotContain(
                "gateway",
                content,
                "A reconnect that is not an event stream must not be spliced onto the delivered events.");
            Assert.AreEqual(
                2,
                requestCount,
                "A reconnect that is not an event stream must end the stream.");
        }

        [Test]
        public async Task ExhaustedRetryCycleReconnects()
        {
            int requestCount = 0;
            var transport = new MockTransport(_ =>
            {
                requestCount++;
                if (requestCount == 1)
                {
                    return CreateDroppedResponse(
                        "retry: 0\ndata: one\n\n");
                }

                // Both attempts of the first reconnect fail, so the retry
                // policy reports an AggregateException rather than the
                // individual IOExceptions.
                if (requestCount <= 3)
                {
                    throw new IOException("The connection was reset.");
                }

                return new MockResponse(204);
            });
            HttpPipeline pipeline = new(
                transport,
                new HttpPipelinePolicy[]
                {
                    new RetryPolicy(
                        maxRetries: 1,
                        DelayStrategy.CreateFixedDelayStrategy(
                            TimeSpan.Zero))
                },
                responseClassifier: null);
            using HttpMessage message = CreateMessage(
                pipeline,
                new Uri("https://example.test/events"));

            await pipeline.SendAsync(message, CancellationToken.None);
            string content = await ReadToEndAsync(
                message.Response.ContentStream!);

            StringAssert.Contains("data: one", content);
            Assert.AreEqual(
                4,
                requestCount,
                "An exhausted retry cycle must not end the stream.");
        }

        private static HttpMessage CreateMessage(
            HttpPipeline pipeline,
            Uri uri,
            RequestMethod? method = null,
            BinaryData? content = null,
            string? initialLastEventId = null)
        {
            HttpMessage message = pipeline.CreateMessage();
            message.BufferResponse = false;
            message.Request.Method = method ?? RequestMethod.Get;
            message.Request.Uri.Reset(uri);
            message.Request.Headers.Add(
                "Accept",
                "text/event-stream");
            if (initialLastEventId != null)
            {
                message.Request.Headers.Add(
                    "Last-Event-ID",
                    initialLastEventId);
            }
            if (content != null)
            {
                message.Request.Content =
                    RequestContent.Create(content);
            }

            return message;
        }

        private static async Task<string> ReadToEndAsync(
            Stream stream)
        {
            using var reader = new StreamReader(
                stream,
                Encoding.UTF8,
                detectEncodingFromByteOrderMarks: false,
                bufferSize: 1024,
                leaveOpen: true);
            return await reader.ReadToEndAsync();
        }

        private static string ReadToEnd(Stream stream)
        {
            using var reader = new StreamReader(
                stream,
                Encoding.UTF8,
                detectEncodingFromByteOrderMarks: false,
                bufferSize: 1024,
                leaveOpen: true);
            return reader.ReadToEnd();
        }

        private static MockResponse CreateSseResponse(string content)
            => new MockResponse(200)
                .AddHeader("Content-Type", "text/event-stream")
                .SetContent(content);

        private static MockResponse CreateDroppedResponse(
            string content)
        {
            var response = new MockResponse(200)
            {
                ContentStream = new ThrowAtEndStream(content)
            };
            response.AddHeader("Content-Type", "text/event-stream");
            return response;
        }

        private sealed class ThrowAtEndStream : MemoryStream
        {
            internal ThrowAtEndStream(string value)
                : base(Encoding.UTF8.GetBytes(value))
            {
            }

            public override int Read(
                byte[] buffer,
                int offset,
                int count)
            {
                if (Position == Length)
                {
                    throw new IOException("The connection dropped.");
                }

                return base.Read(buffer, offset, count);
            }

            public override Task<int> ReadAsync(
                byte[] buffer,
                int offset,
                int count,
                CancellationToken cancellationToken)
            {
                if (Position == Length)
                {
                    throw new IOException("The connection dropped.");
                }

                return base.ReadAsync(
                    buffer,
                    offset,
                    count,
                    cancellationToken);
            }

#if NET8_0_OR_GREATER
            public override int Read(Span<byte> buffer)
            {
                if (Position == Length)
                {
                    throw new IOException("The connection dropped.");
                }

                return base.Read(buffer);
            }

            public override ValueTask<int> ReadAsync(
                Memory<byte> buffer,
                CancellationToken cancellationToken = default)
            {
                if (Position == Length)
                {
                    throw new IOException("The connection dropped.");
                }

                return base.ReadAsync(buffer, cancellationToken);
            }
#endif
        }

        private static string? ReadContent(
            RequestContent? content)
        {
            if (content == null)
            {
                return null;
            }

            using var stream = new MemoryStream();
            content.WriteTo(stream, CancellationToken.None);
            return Encoding.UTF8.GetString(stream.ToArray());
        }

        private sealed class SyncOnlyTransport : HttpPipelineTransport
        {
            private readonly Func<int, MockResponse> _onSend;

            internal SyncOnlyTransport(Func<int, MockResponse> onSend)
            {
                _onSend = onSend;
            }

            internal int RequestCount { get; private set; }

            internal string? LastEventId { get; private set; }

            public override Request CreateRequest() => new MockRequest();

            public override void Process(HttpMessage message)
            {
                RequestCount++;
                message.Request.Headers.TryGetValue(
                    "Last-Event-ID",
                    out string? lastEventId);
                LastEventId = lastEventId;
                message.Response = _onSend(RequestCount);
            }

            public override ValueTask ProcessAsync(HttpMessage message)
                => throw new AssertionException(
                    "The synchronous read path must not use the async transport.");
        }

        private sealed class AsyncOnlyTransport : HttpPipelineTransport
        {
            private readonly Func<int, MockResponse> _onSend;

            internal AsyncOnlyTransport(Func<int, MockResponse> onSend)
            {
                _onSend = onSend;
            }

            internal int RequestCount { get; private set; }

            internal string? LastEventId { get; private set; }

            public override Request CreateRequest() => new MockRequest();

            public override void Process(HttpMessage message)
                => throw new AssertionException(
                    "Reconnects must use the same send mode as the initial request.");

            public override ValueTask ProcessAsync(HttpMessage message)
                => ProcessCoreAsync(message);

            private async ValueTask ProcessCoreAsync(HttpMessage message)
            {
                // Suspend so the send completes asynchronously, the way a
                // real transport does. Without this the reconnect would
                // finish synchronously and would not exercise the blocking
                // path taken by a synchronous read.
                await Task.Yield();
                RequestCount++;
                message.Request.Headers.TryGetValue(
                    "Last-Event-ID",
                    out string? lastEventId);
                LastEventId = lastEventId;
                message.Response = _onSend(RequestCount);
            }
        }

        private sealed class CancellationAwareTransport
            : HttpPipelineTransport
        {
            private int _requestCount;

            internal TaskCompletionSource<bool> ReconnectStarted { get; } =
                new(TaskCreationOptions.RunContinuationsAsynchronously);

            public override Request CreateRequest() => new MockRequest();

            public override void Process(HttpMessage message)
                => throw new AssertionException(
                    "Only asynchronous sends are expected.");

            public override async ValueTask ProcessAsync(
                HttpMessage message)
            {
                _requestCount++;
                if (_requestCount == 1)
                {
                    message.Response = CreateDroppedResponse(
                        "retry: 0\ndata: one\n\n");
                    return;
                }

                ReconnectStarted.TrySetResult(true);
                await Task.Delay(
                    Timeout.Infinite,
                    message.CancellationToken);
            }
        }

        private sealed class RotatingAuthenticationPolicy
            : HttpPipelineSynchronousPolicy
        {
            private int _requestCount;

            public override void OnSendingRequest(
                HttpMessage message)
            {
                _requestCount++;
                message.Request.Headers.SetValue(
                    "Authorization",
                    $"Bearer token-{_requestCount}");
            }
        }

        private sealed class RequestAwareClassifier
            : ResponseClassifier
        {
            public override bool IsRetriableResponse(
                HttpMessage message)
            {
                Assert.AreEqual(
                    new Uri("https://example.test/events"),
                    message.Request.Uri.ToUri());
                return message.Response.Status == 503;
            }
        }
    }
}
