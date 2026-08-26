// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.ServerSentEvents;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ClientModel.Tests.Mocks;
using NUnit.Framework;

namespace System.ClientModel.Tests.Pipeline;

public class SsePipelineResponseHandlerTests
{
    [Test]
    public async Task ReconnectsByDefaultAndSendsLastEventId()
    {
        int requestCount = 0;
        string? lastEventId = null;
        var handler = new MockHttpClientHandler(request =>
        {
            requestCount++;
            lastEventId = request.Headers.TryGetValues(
                "Last-Event-ID",
                out IEnumerable<string>? values)
                    ? string.Join(",", values)
                    : null;
            return Task.FromResult(
                requestCount == 1
                    ? CreateDroppedResponse(
                        "retry: 0\nid: first\ndata: one\n\n")
                    : new HttpResponseMessage(
                        HttpStatusCode.NoContent));
        });
        ClientPipeline pipeline = CreatePipeline(handler);
        AsyncStreamingClientResult<SseItem<BinaryData>> result =
            await CreateResultAsync(
                pipeline,
                new Uri("https://example.test/events"));
        var values = new List<string>();

        await foreach (SseItem<BinaryData> item in result)
        {
            values.Add(item.Data.ToString());
        }

        CollectionAssert.AreEqual(new[] { "one" }, values);
        Assert.AreEqual(2, requestCount);
        Assert.AreEqual("first", lastEventId);
    }

    [Test]
    public async Task PreservesInitialLastEventIdUntilUpdated()
    {
        int requestCount = 0;
        string? lastEventId = null;
        var handler = new MockHttpClientHandler(request =>
        {
            requestCount++;
            lastEventId = request.Headers.TryGetValues(
                "Last-Event-ID",
                out IEnumerable<string>? values)
                    ? string.Join(",", values)
                    : null;
            return Task.FromResult(
                requestCount == 1
                    ? CreateDroppedResponse(
                        "retry: 0\ndata: one\n\n")
                    : new HttpResponseMessage(
                        HttpStatusCode.NoContent));
        });
        ClientPipeline pipeline = CreatePipeline(handler);
        AsyncStreamingClientResult<SseItem<BinaryData>> result =
            await CreateResultAsync(
                pipeline,
                new Uri("https://example.test/events"),
                initialLastEventId: "prior");

        await foreach (SseItem<BinaryData> _ in result)
        {
        }

        Assert.AreEqual(2, requestCount);
        Assert.AreEqual("prior", lastEventId);
    }

    [Test]
    public async Task InitialNoContentEndsWithoutReconnect()
    {
        int requestCount = 0;
        var handler = new MockHttpClientHandler(_ =>
        {
            requestCount++;
            return Task.FromResult(
                new HttpResponseMessage(HttpStatusCode.NoContent));
        });
        ClientPipeline pipeline = CreatePipeline(handler);
        AsyncStreamingClientResult<SseItem<BinaryData>> result =
            await CreateResultAsync(
                pipeline,
                new Uri("https://example.test/events"));

        await foreach (SseItem<BinaryData> _ in result)
        {
            Assert.Fail("A 204 response must not produce events.");
        }

        Assert.AreEqual(1, requestCount);
    }

    [Test]
    public async Task PermanentRedirectIsRemembered()
    {
        var requestUris = new List<Uri?>();
        var lastEventIds = new List<string?>();
        var handler = new MockHttpClientHandler(request =>
        {
            requestUris.Add(request.RequestUri);
            lastEventIds.Add(request.Headers.TryGetValues(
                "Last-Event-ID",
                out IEnumerable<string>? values)
                    ? string.Join(",", values)
                    : null);
            return Task.FromResult(requestUris.Count switch
            {
                1 => CreateRedirect(
                    HttpStatusCode.MovedPermanently,
                    "https://example.test/permanent"),
                2 => CreateDroppedResponse(
                    "retry: 0\ndata: one\n\n"),
                _ => new HttpResponseMessage(
                    HttpStatusCode.NoContent)
            });
        });
        ClientPipeline pipeline = CreatePipeline(handler);
        AsyncStreamingClientResult<SseItem<BinaryData>> result =
            await CreateResultAsync(
                pipeline,
                new Uri("https://example.test/events"),
                initialLastEventId: "prior");

        await foreach (SseItem<BinaryData> _ in result)
        {
        }

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
        var requestUris = new List<Uri?>();
        var handler = new MockHttpClientHandler(request =>
        {
            requestUris.Add(request.RequestUri);
            return Task.FromResult(CreateRedirect(
                HttpStatusCode.TemporaryRedirect,
                "https://redirected.test/events"));
        });
        ClientPipeline pipeline = CreatePipeline(handler);

        Assert.ThrowsAsync<InvalidOperationException>(async () =>
        {
            AsyncStreamingClientResult<SseItem<BinaryData>> result =
                await CreateResultAsync(
                    pipeline,
                    new Uri("https://example.test/events"));
            await foreach (SseItem<BinaryData> _ in result)
            {
            }
        });
        CollectionAssert.AreEqual(
            new[] { new Uri("https://example.test/events") },
            requestUris);
    }

    [Test]
    public async Task TemporaryRedirectPreservesPostAndBody()
    {
        var requestUris = new List<Uri?>();
        var requestMethods = new List<HttpMethod>();
        var requestBodies = new List<string?>();
        var handler = new MockHttpClientHandler(async request =>
        {
            requestUris.Add(request.RequestUri);
            requestMethods.Add(request.Method);
            requestBodies.Add(request.Content is null
                ? null
                : await request.Content.ReadAsStringAsync());
            return requestUris.Count switch
            {
                1 => CreateRedirect(
                    HttpStatusCode.TemporaryRedirect,
                    "https://example.test/temporary"),
                2 => CreateDroppedResponse(
                    "retry: 0\ndata: one\n\n"),
                _ => new HttpResponseMessage(
                    HttpStatusCode.NoContent)
            };
        });
        ClientPipeline pipeline = CreatePipeline(handler);
        AsyncStreamingClientResult<SseItem<BinaryData>> result =
            await CreateResultAsync(
                pipeline,
                new Uri("https://example.test/events"),
                "POST",
                BinaryData.FromString("request"));

        await foreach (SseItem<BinaryData> _ in result)
        {
        }

        CollectionAssert.AreEqual(
            new[]
            {
                new Uri("https://example.test/events"),
                new Uri("https://example.test/temporary"),
                new Uri("https://example.test/events")
            },
            requestUris);
        CollectionAssert.AreEqual(
            new[] { HttpMethod.Post, HttpMethod.Post, HttpMethod.Post },
            requestMethods);
        CollectionAssert.AreEqual(
            new[] { "request", "request", "request" },
            requestBodies);
    }

    [Test]
    public void SyncReadReconnectsAndSendsLastEventId()
    {
        var handler = new SyncTrackingHandler(requestCount =>
            requestCount == 1
                ? CreateDroppedResponse(
                    "retry: 0\nid: first\ndata: one\n\n")
                : new HttpResponseMessage(HttpStatusCode.NoContent));
        ClientPipeline pipeline = CreatePipeline(handler);
        using PipelineResponse response = SendResponse(
            pipeline,
            new Uri("https://example.test/events"));

        string content = ReadToEnd(response.ContentStream!);

        Assert.AreEqual(
            "retry: 0\nid: first\ndata: one\n\n",
            content);
        Assert.AreEqual(2, handler.RequestCount);
        Assert.AreEqual("first", handler.LastEventId);
#if NET5_0_OR_GREATER
        Assert.AreEqual(
            0,
            handler.AsyncRequestCount,
            "The synchronous read path must not use the async transport.");
#endif
    }

    [Test]
    public void SyncReadReconnectsAfterReadFailure()
    {
        var handler = new SyncTrackingHandler(requestCount =>
            requestCount == 1
                ? new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StreamContent(
                        new ThrowAtEndStream(
                            "retry: 0\ndata: one\n\n"))
                }
                : new HttpResponseMessage(HttpStatusCode.NoContent));
        ClientPipeline pipeline = CreatePipeline(handler);
        using PipelineResponse response = SendResponse(
            pipeline,
            new Uri("https://example.test/events"));

        string content = ReadToEnd(response.ContentStream!);

        Assert.AreEqual("retry: 0\ndata: one\n\n", content);
        Assert.AreEqual(2, handler.RequestCount);
    }

    [Test]
    public async Task AsyncReadOnSyncEstablishedStreamUsesSyncTransport()
    {
        var handler = new SyncTrackingHandler(requestCount =>
            requestCount == 1
                ? CreateDroppedResponse(
                    "retry: 0\nid: first\ndata: one\n\n")
                : new HttpResponseMessage(HttpStatusCode.NoContent));
        ClientPipeline pipeline = CreatePipeline(handler);
        using PipelineResponse response = SendResponse(
            pipeline,
            new Uri("https://example.test/events"));

        string content = await ReadToEndAsync(response.ContentStream!);

        Assert.AreEqual(
            "retry: 0\nid: first\ndata: one\n\n",
            content);
        Assert.AreEqual(2, handler.RequestCount);
        Assert.AreEqual("first", handler.LastEventId);
#if NET5_0_OR_GREATER
        Assert.AreEqual(
            0,
            handler.AsyncRequestCount,
            "Reconnects must use the same send mode as the initial request.");
#endif
    }

    [Test]
    public void SyncSendFollowsInitialRedirect()
    {
        int requestCount = 0;
        var handler = new MockHttpClientHandler(_ =>
        {
            requestCount++;
            return Task.FromResult(
                requestCount == 1
                    ? CreateRedirect(
                        HttpStatusCode.TemporaryRedirect,
                        "https://example.test/redirected")
                    : CreateResponse(
                        HttpStatusCode.OK,
                        "data: one\n\n"));
        });
        ClientPipeline pipeline = CreatePipeline(handler);
        using PipelineMessage message = pipeline.CreateMessage(
            new Uri("https://example.test/events"),
            "GET",
            PipelineMessageClassifier.Create(
                stackalloc ushort[] { 200 }));
        message.BufferResponse = false;
        message.Request.Headers.Set(
            "Accept",
            "text/event-stream");

        pipeline.Send(message);

        Assert.AreEqual(200, message.Response!.Status);
        Assert.AreEqual(2, requestCount);
    }

    [Test]
    public void CancellationStopsActiveStream()
    {
        var handler = new CancellationAwareHandler();
        ClientPipeline pipeline = CreatePipeline(handler);
        using var cancellation = new CancellationTokenSource();

        Task task = Task.Run(async () =>
        {
            AsyncStreamingClientResult<SseItem<BinaryData>> result =
                await CreateResultAsync(
                    pipeline,
                    new Uri("https://example.test/events"),
                    cancellationToken: cancellation.Token);
            await foreach (SseItem<BinaryData> _ in result)
            {
            }
        });
        cancellation.Cancel();

        Assert.CatchAsync<OperationCanceledException>(
            async () => await task);
    }

    [Test]
    public async Task ReadCancellationCancelsReconnectRequest()
    {
        var handler = new ReconnectCancellationHandler();
        ClientPipeline pipeline = CreatePipeline(handler);
        AsyncStreamingClientResult<SseItem<BinaryData>> result =
            await CreateResultAsync(
                pipeline,
                new Uri("https://example.test/events"));
        using var cancellation = new CancellationTokenSource();
        await using IAsyncEnumerator<SseItem<BinaryData>> enumerator =
            ((IAsyncEnumerable<SseItem<BinaryData>>)result)
                .GetAsyncEnumerator(cancellation.Token);

        Assert.IsTrue(await enumerator.MoveNextAsync());
        Task<bool> moveNext = enumerator.MoveNextAsync().AsTask();
        await handler.ReconnectStarted.Task;
        cancellation.Cancel();

        Assert.CatchAsync<OperationCanceledException>(
            async () => await moveNext);
    }

    [Test]
    public async Task DiscardsIncompleteEventBeforeReconnect()
    {
        int requestCount = 0;
        var lastEventIds = new List<string?>();
        var handler = new MockHttpClientHandler(request =>
        {
            requestCount++;
            lastEventIds.Add(request.Headers.TryGetValues(
                "Last-Event-ID",
                out IEnumerable<string>? values)
                    ? string.Join(",", values)
                    : null);
            return Task.FromResult(requestCount switch
            {
                1 => CreateDroppedResponse(
                    "retry: 0\nid: lost\ndata: partial"),
                2 => CreateDroppedResponse(
                    "retry: 0\nid: kept\ndata: complete\n\n"),
                _ => new HttpResponseMessage(
                    HttpStatusCode.NoContent)
            });
        });
        ClientPipeline pipeline = CreatePipeline(handler);
        AsyncStreamingClientResult<SseItem<BinaryData>> result =
            await CreateResultAsync(
                pipeline,
                new Uri("https://example.test/events"));
        var values = new List<string>();

        await foreach (SseItem<BinaryData> item in result)
        {
            values.Add(item.Data.ToString());
        }

        CollectionAssert.AreEqual(new[] { "complete" }, values);
        CollectionAssert.AreEqual(
            new string?[] { null, null, "kept" },
            lastEventIds);
    }

    [Test]
    public async Task ReconnectsAfterReadFailure()
    {
        int requestCount = 0;
        var handler = new MockHttpClientHandler(_ =>
        {
            requestCount++;
            if (requestCount == 1)
            {
                var response =
                    new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StreamContent(
                            new ThrowAtEndStream(
                                "retry: 0\ndata: one\n\n"))
                    };
                return Task.FromResult(response);
            }

            return Task.FromResult(
                new HttpResponseMessage(HttpStatusCode.NoContent));
        });
        ClientPipeline pipeline = CreatePipeline(handler);
        AsyncStreamingClientResult<SseItem<BinaryData>> result =
            await CreateResultAsync(
                pipeline,
                new Uri("https://example.test/events"));
        var values = new List<string>();

        await foreach (SseItem<BinaryData> item in result)
        {
            values.Add(item.Data.ToString());
        }

        CollectionAssert.AreEqual(new[] { "one" }, values);
        Assert.AreEqual(2, requestCount);
    }

    [Test]
    public async Task GracefulEndOfStreamDoesNotReconnect()
    {
        int requestCount = 0;
        var handler = new MockHttpClientHandler(_ =>
        {
            requestCount++;
            return Task.FromResult(CreateResponse(
                HttpStatusCode.OK,
                "retry: 0\nid: first\ndata: one\n\ndata: two\n\n"));
        });
        ClientPipeline pipeline = CreatePipeline(handler);
        AsyncStreamingClientResult<SseItem<BinaryData>> result =
            await CreateResultAsync(
                pipeline,
                new Uri("https://example.test/events"));
        var values = new List<string>();

        await foreach (SseItem<BinaryData> item in result)
        {
            values.Add(item.Data.ToString());
        }

        CollectionAssert.AreEqual(new[] { "one", "two" }, values);
        Assert.AreEqual(
            1,
            requestCount,
            "A stream that completes normally must not be replayed.");
    }

    [Test]
    public void SyncGracefulEndOfStreamDoesNotReconnect()
    {
        var handler = new SyncTrackingHandler(_ =>
            CreateResponse(
                HttpStatusCode.OK,
                "retry: 0\ndata: one\n\n"));
        ClientPipeline pipeline = CreatePipeline(handler);
        using PipelineResponse response = SendResponse(
            pipeline,
            new Uri("https://example.test/events"));

        string content = ReadToEnd(response.ContentStream!);

        Assert.AreEqual("retry: 0\ndata: one\n\n", content);
        Assert.AreEqual(
            1,
            handler.RequestCount,
            "A stream that completes normally must not be replayed.");
    }

    [Test]
    public async Task ZeroLengthAndRepeatedEofReadsDoNotReconnect()
    {
        int requestCount = 0;
        var handler = new MockHttpClientHandler(_ =>
        {
            requestCount++;
            return Task.FromResult(
                requestCount == 1
                    ? CreateDroppedResponse(
                        "retry: 0\ndata: one\n\n")
                    : new HttpResponseMessage(
                        HttpStatusCode.NoContent));
        });
        ClientPipeline pipeline = CreatePipeline(handler);
        using PipelineResponse response = await SendResponseAsync(
            pipeline,
            new Uri("https://example.test/events"));
        Stream stream = response.ContentStream!;

        Assert.AreEqual(
            0,
            await stream.ReadAsync(
                Array.Empty<byte>(),
                0,
                0));
        Assert.AreEqual(1, requestCount);
        Assert.AreEqual(
            "retry: 0\ndata: one\n\n",
            await ReadToEndAsync(stream));
        Assert.AreEqual(2, requestCount);
        Assert.AreEqual(0, stream.Read(new byte[1], 0, 1));
        Assert.AreEqual(
            0,
            await stream.ReadAsync(new byte[1], 0, 1));
        Assert.AreEqual(2, requestCount);
    }

    [Test]
    public async Task TerminalEventStopsBeforeReconnect()
    {
        int requestCount = 0;
        var handler = new MockHttpClientHandler(_ =>
        {
            requestCount++;
            return Task.FromResult(CreateDroppedResponse(
                "retry: 0\ndata: done\n\n"));
        });
        ClientPipeline pipeline = CreatePipeline(handler);
        PipelineResponse response = await SendResponseAsync(
            pipeline,
            new Uri("https://example.test/events"));
        await using AsyncStreamingClientResult<SseItem<BinaryData>> result =
            AsyncStreamingClientResult.CreateSse(
                response,
                item => item.Data.ToString() == "done");

        await foreach (SseItem<BinaryData> _ in result)
        {
            Assert.Fail("The terminal event must not be returned.");
        }

        Assert.AreEqual(1, requestCount);
    }

    [Test]
    public async Task ForceGetRedirectDropsBodyAndContentHeaders()
    {
        int requestCount = 0;
        var handler = new MockHttpClientHandler(request =>
        {
            requestCount++;
            if (requestCount == 2)
            {
                Assert.AreEqual(HttpMethod.Get, request.Method);
                Assert.IsNull(request.Content);
            }

            return Task.FromResult(
                requestCount == 1
                    ? CreateRedirect(
                        HttpStatusCode.SeeOther,
                        "https://example.test/redirected")
                    : new HttpResponseMessage(
                        HttpStatusCode.NoContent));
        });
        ClientPipeline pipeline = CreatePipeline(handler);
        using PipelineMessage message = pipeline.CreateMessage(
            new Uri("https://example.test/events"),
            "POST",
            PipelineMessageClassifier.Create(
                stackalloc ushort[] { 200 }));
        message.BufferResponse = false;
        message.Request.Headers.Set(
            "Accept",
            "text/event-stream");
        message.Request.Headers.Set(
            "Content-Encoding",
            "gzip");
        message.Request.Content =
            BinaryContent.Create(BinaryData.FromString("request"));

        await pipeline.SendAsync(message);

        Assert.AreEqual(204, message.Response!.Status);
        Assert.AreEqual(2, requestCount);
    }

    [Test]
    public async Task DisposeDuringReconnectDisposesNewResponse()
    {
        var reconnectStarted =
            new TaskCompletionSource<bool>(
                TaskCreationOptions.RunContinuationsAsynchronously);
        var releaseReconnect =
            new TaskCompletionSource<bool>(
                TaskCreationOptions.RunContinuationsAsynchronously);
        var owner = new TrackingDisposable();
        var stream = new SseReconnectingStream(
            new ThrowAtEndStream(string.Empty),
            (_, _) => throw new NotSupportedException(),
            async (_, _) =>
            {
                reconnectStarted.TrySetResult(true);
                await releaseReconnect.Task;
                return new SseReconnectResult(
                    new MemoryStream(),
                    owner);
            },
            CancellationToken.None,
            reconnectImmediately: true);
        Task<int> read = stream.ReadAsync(
            new byte[1],
            0,
            1);
        await reconnectStarted.Task;

        stream.Dispose();
        releaseReconnect.TrySetResult(true);

        Assert.CatchAsync<OperationCanceledException>(
            async () => await read);
        Assert.IsTrue(owner.IsDisposed);
    }

    private sealed class CancellationAwareHandler : HttpMessageHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            await Task.Delay(
                Timeout.Infinite,
                cancellationToken);
            throw new AssertionException(
                "The request should have been canceled.");
        }
    }

    private sealed class ReconnectCancellationHandler
        : HttpMessageHandler
    {
        private int _requestCount;

        internal TaskCompletionSource<bool> ReconnectStarted { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            _requestCount++;
            if (_requestCount == 1)
            {
                return CreateDroppedResponse(
                    "retry: 0\ndata: one\n\n");
            }

            ReconnectStarted.TrySetResult(true);
            await Task.Delay(
                Timeout.Infinite,
                cancellationToken);
            throw new AssertionException(
                "The reconnect request should have been canceled.");
        }
    }

    private static ClientPipeline CreatePipeline(
        HttpMessageHandler handler)
    {
        var options = new ClientPipelineOptions
        {
            Transport = new HttpClientPipelineTransport(
                new HttpClient(handler))
        };
        return ClientPipeline.Create(options);
    }

    private static async Task<
        AsyncStreamingClientResult<SseItem<BinaryData>>>
        CreateResultAsync(
            ClientPipeline pipeline,
            Uri uri,
            string method = "GET",
            BinaryData? content = null,
            CancellationToken cancellationToken = default,
            string? initialLastEventId = null)
        => AsyncStreamingClientResult.CreateSse(
            await SendResponseAsync(
                pipeline,
                uri,
                method,
                content,
                cancellationToken,
                initialLastEventId));

    private static async Task<PipelineResponse>
        SendResponseAsync(
            ClientPipeline pipeline,
            Uri uri,
            string method = "GET",
            BinaryData? content = null,
            CancellationToken cancellationToken = default,
            string? initialLastEventId = null)
    {
        using PipelineMessage message = pipeline.CreateMessage(
            uri,
            method,
            PipelineMessageClassifier.Create(
                stackalloc ushort[] { 200 }));
        message.BufferResponse = false;
        message.CancellationToken = cancellationToken;
        message.Request.Headers.Set(
            "Accept",
            "text/event-stream");
        if (initialLastEventId is not null)
        {
            message.Request.Headers.Set(
                "Last-Event-ID",
                initialLastEventId);
        }
        if (content is not null)
        {
            message.Request.Content = BinaryContent.Create(content);
        }

        await pipeline.SendAsync(message);
        return message.ExtractResponse()!;
    }

    private static PipelineResponse SendResponse(
        ClientPipeline pipeline,
        Uri uri,
        string method = "GET")
    {
        using PipelineMessage message = pipeline.CreateMessage(
            uri,
            method,
            PipelineMessageClassifier.Create(
                stackalloc ushort[] { 200 }));
        message.BufferResponse = false;
        message.Request.Headers.Set(
            "Accept",
            "text/event-stream");

        pipeline.Send(message);
        return message.ExtractResponse()!;
    }

    private static HttpResponseMessage CreateResponse(
        HttpStatusCode status,
        string content)
        => new(status)
        {
            Content = new StringContent(content)
        };

    private static HttpResponseMessage CreateDroppedResponse(
        string content)
        => new(HttpStatusCode.OK)
        {
            Content = new StreamContent(
                new ThrowAtEndStream(content))
        };

    private static HttpResponseMessage CreateRedirect(
        HttpStatusCode status,
        string location)
        => new(status)
        {
            Headers =
            {
                Location = new Uri(location)
            }
        };

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

    private sealed class SyncTrackingHandler : HttpMessageHandler
    {
        private readonly Func<int, HttpResponseMessage> _onSend;

        internal SyncTrackingHandler(
            Func<int, HttpResponseMessage> onSend)
        {
            _onSend = onSend;
        }

        internal int RequestCount { get; private set; }

        internal int AsyncRequestCount { get; private set; }

        internal string? LastEventId { get; private set; }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            AsyncRequestCount++;
            return Task.FromResult(CreateResponse(request));
        }

#if NET5_0_OR_GREATER
        protected override HttpResponseMessage Send(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
            => CreateResponse(request);
#endif

        private HttpResponseMessage CreateResponse(
            HttpRequestMessage request)
        {
            RequestCount++;
            LastEventId = request.Headers.TryGetValues(
                "Last-Event-ID",
                out IEnumerable<string>? values)
                    ? string.Join(",", values)
                    : null;
            return _onSend(RequestCount);
        }
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

    private sealed class TrackingDisposable : IDisposable
    {
        internal bool IsDisposed { get; private set; }

        public void Dispose() => IsDisposed = true;
    }
}
