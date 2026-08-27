// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
    public void FailedSendAsyncRestoresCallerClassifier()
    {
        var handler = new MockHttpClientHandler(_ =>
            Task.FromResult(CreateRedirect(
                HttpStatusCode.TemporaryRedirect,
                "https://redirected.test/events")));
        ClientPipeline pipeline = CreatePipeline(handler);
        PipelineMessageClassifier classifier =
            PipelineMessageClassifier.Create(stackalloc ushort[] { 200 });
        using PipelineMessage message = CreateSseMessage(
            pipeline,
            classifier);

        Assert.ThrowsAsync<InvalidOperationException>(
            async () => await pipeline.SendAsync(message));

        Assert.AreSame(
            classifier,
            message.ResponseClassifier,
            "A failed send must leave the caller's message holding the " +
            "classifier it supplied, not the private SSE classifier.");
    }

    [Test]
    public void FailedSendRestoresCallerClassifier()
    {
        var handler = new SyncTrackingHandler(_ =>
            CreateRedirect(
                HttpStatusCode.TemporaryRedirect,
                "https://redirected.test/events"));
        ClientPipeline pipeline = CreatePipeline(handler);
        PipelineMessageClassifier classifier =
            PipelineMessageClassifier.Create(stackalloc ushort[] { 200 });
        using PipelineMessage message = CreateSseMessage(
            pipeline,
            classifier);

        Assert.Throws<InvalidOperationException>(
            () => pipeline.Send(message));

        Assert.AreSame(
            classifier,
            message.ResponseClassifier,
            "The synchronous path must restore the classifier too.");
    }

    [Test]
    public void TransportFailureRestoresCallerClassifier()
    {
        var handler = new MockHttpClientHandler(_ =>
            throw new IOException("transport down"));
        ClientPipeline pipeline = CreatePipeline(
            handler,
            new ImmediateRetryPolicy(0));
        PipelineMessageClassifier classifier =
            PipelineMessageClassifier.Create(stackalloc ushort[] { 200 });
        using PipelineMessage message = CreateSseMessage(
            pipeline,
            classifier);

        Assert.CatchAsync(
            async () => await pipeline.SendAsync(message));

        Assert.AreSame(
            classifier,
            message.ResponseClassifier,
            "A failure inside the pipeline must restore the classifier " +
            "before the exception reaches the caller.");
    }

    [Test]
    public async Task SuccessfulSendRestoresCallerClassifier()
    {
        var handler = new MockHttpClientHandler(_ =>
            Task.FromResult(CreateResponse(
                HttpStatusCode.OK,
                "retry: 0\ndata: one\n\n")));
        ClientPipeline pipeline = CreatePipeline(handler);
        PipelineMessageClassifier classifier =
            PipelineMessageClassifier.Create(stackalloc ushort[] { 200 });
        using PipelineMessage message = CreateSseMessage(
            pipeline,
            classifier);

        await pipeline.SendAsync(message);

        Assert.AreSame(
            classifier,
            message.ResponseClassifier,
            "The private classifier must not outlive the send.");
    }

    [Test]
    public async Task ZeroQualityAcceptIsNotWrapped()
    {
        int requestCount = 0;
        var handler = new MockHttpClientHandler(_ =>
        {
            requestCount++;
            return Task.FromResult(
                requestCount == 1
                    ? CreateDroppedResponse(
                        "retry: 0\ndata: one\n\n")
                    : CreateResponse(
                        HttpStatusCode.OK,
                        "retry: 0\ndata: two\n\n"));
        });
        ClientPipeline pipeline = CreatePipeline(handler);
        using PipelineResponse response = await SendResponseAsync(
            pipeline,
            new Uri("https://example.test/events"),
            accept: "text/event-stream; q=0");
        Stream stream = response.ContentStream!;
        var buffer = new byte[1024];

        int read = await stream.ReadAsync(buffer, 0, buffer.Length);

        Assert.AreEqual(
            "retry: 0\ndata: one\n\n",
            Encoding.UTF8.GetString(buffer, 0, read));
        Assert.ThrowsAsync<IOException>(
            async () => await ExpectNoFurtherReadAsync(stream, buffer),
            "RFC 9110 gives a weight of zero the meaning 'not " +
            "acceptable', so the stream must not have been wrapped.");
        Assert.AreEqual(1, requestCount);
    }

    [Test]
    public async Task ZeroQualityAmongOtherMediaTypesIsNotWrapped()
    {
        int requestCount = 0;
        var handler = new MockHttpClientHandler(_ =>
        {
            requestCount++;
            return Task.FromResult(
                requestCount == 1
                    ? CreateDroppedResponse(
                        "retry: 0\ndata: one\n\n")
                    : CreateResponse(
                        HttpStatusCode.OK,
                        "retry: 0\ndata: two\n\n"));
        });
        ClientPipeline pipeline = CreatePipeline(handler);
        using PipelineResponse response = await SendResponseAsync(
            pipeline,
            new Uri("https://example.test/events"),
            accept: "application/json, text/event-stream;q=0.000");
        Stream stream = response.ContentStream!;
        var buffer = new byte[1024];

        int read = await stream.ReadAsync(buffer, 0, buffer.Length);

        Assert.AreEqual(
            "retry: 0\ndata: one\n\n",
            Encoding.UTF8.GetString(buffer, 0, read));
        Assert.ThrowsAsync<IOException>(
            async () => await ExpectNoFurtherReadAsync(stream, buffer));
        Assert.AreEqual(1, requestCount);
    }

    [TestCase("text/event-stream")]
    [TestCase("text/event-stream;q=1")]
    [TestCase("text/event-stream; q=0.5")]
    [TestCase("text/event-stream ; Q = 0.001")]
    [TestCase("text/event-stream;charset=utf-8;q=1.0")]
    [TestCase("application/json;q=0, text/event-stream")]
    [TestCase("text/event-stream;q=0.5;profile=x")]
    public async Task PositiveQualityAcceptIsWrapped(string accept)
    {
        int requestCount = 0;
        var handler = new MockHttpClientHandler(_ =>
        {
            requestCount++;
            return Task.FromResult(
                requestCount == 1
                    ? CreateDroppedResponse(
                        "retry: 0\ndata: one\n\n")
                    : CreateResponse(
                        HttpStatusCode.OK,
                        "retry: 0\ndata: two\n\n"));
        });
        ClientPipeline pipeline = CreatePipeline(handler);
        using PipelineResponse response = await SendResponseAsync(
            pipeline,
            new Uri("https://example.test/events"),
            accept: accept);

        string content = await ReadToEndAsync(response.ContentStream!);

        Assert.AreEqual(
            "retry: 0\ndata: one\n\nretry: 0\ndata: two\n\n",
            content,
            "An omitted or positive weight must still opt in.");
        Assert.AreEqual(2, requestCount);
    }

    [Test]
    public async Task ZeroLengthReadAfterDisposeThrows()
    {
        var handler = new MockHttpClientHandler(_ =>
            Task.FromResult(CreateResponse(
                HttpStatusCode.OK,
                "retry: 0\ndata: one\n\n")));
        ClientPipeline pipeline = CreatePipeline(handler);
        using PipelineResponse response = await SendResponseAsync(
            pipeline,
            new Uri("https://example.test/events"));
        Stream stream = response.ContentStream!;
        var buffer = new byte[16];

        stream.Dispose();

        // CA2022 guards against assuming a read filled the buffer. These
        // reads request zero bytes on purpose: the subject is the disposal
        // contract, not the byte count.
#pragma warning disable CA2022
        Assert.Throws<ObjectDisposedException>(
            () => stream.Read(buffer, 0, 0),
            "A zero-length read must report disposal rather than " +
            "silently returning 0.");
        Assert.ThrowsAsync<ObjectDisposedException>(
            async () => await stream.ReadAsync(buffer, 0, 0),
            "The byte[] async overload must behave the same way.");
#if NET8_0_OR_GREATER
        Assert.ThrowsAsync<ObjectDisposedException>(
            async () => await stream.ReadAsync(Memory<byte>.Empty),
            "The Memory<byte> overload must behave the same way.");
#endif
#pragma warning restore CA2022
    }

    [Test]
    public async Task ZeroLengthReadOnLiveStreamStillReturnsZero()
    {
        var handler = new MockHttpClientHandler(_ =>
            Task.FromResult(CreateResponse(
                HttpStatusCode.OK,
                "retry: 0\ndata: one\n\n")));
        ClientPipeline pipeline = CreatePipeline(handler);
        using PipelineResponse response = await SendResponseAsync(
            pipeline,
            new Uri("https://example.test/events"));
        Stream stream = response.ContentStream!;
        var buffer = new byte[16];

#pragma warning disable CA2022 // zero-byte reads are the subject here
        Assert.AreEqual(0, stream.Read(buffer, 0, 0));
        Assert.AreEqual(0, await stream.ReadAsync(buffer, 0, 0));
#if NET8_0_OR_GREATER
        Assert.AreEqual(0, await stream.ReadAsync(Memory<byte>.Empty));
#endif
#pragma warning restore CA2022
        Assert.AreEqual(
            "retry: 0\ndata: one\n\n",
            await ReadToEndAsync(stream),
            "A zero-length read must not consume or disturb the stream.");
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
                    "retry: 0\nid: one\ndata: one\n\n"),
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
                ? CreateDroppedResponse(
                    "retry: 0\ndata: one\n\n")
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
                return Task.FromResult(
                    CreateDroppedResponse(
                        "retry: 0\ndata: one\n\n"));
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
    public async Task DroppedStreamWithoutEventIdStillReconnects()
    {
        int requestCount = 0;
        var sentLastEventIds = new List<string?>();
        var handler = new MockHttpClientHandler(request =>
        {
            requestCount++;
            sentLastEventIds.Add(
                request.Headers.TryGetValues(
                    "Last-Event-ID",
                    out IEnumerable<string>? values)
                        ? string.Join(",", values)
                        : null);
            return Task.FromResult(
                requestCount == 1
                    ? CreateDroppedResponse(
                        "retry: 0\ndata: one\n\n")
                    : CreateResponse(
                        HttpStatusCode.OK,
                        "retry: 0\ndata: two\n\n"));
        });
        ClientPipeline pipeline = CreatePipeline(handler);
        using PipelineResponse response = await SendResponseAsync(
            pipeline,
            new Uri("https://example.test/events"));

        string content = await ReadToEndAsync(response.ContentStream!);

        Assert.AreEqual(
            "retry: 0\ndata: one\n\nretry: 0\ndata: two\n\n",
            content,
            "The stream continues after the drop even though the " +
            "service published no resumption token.");
        Assert.AreEqual(
            2,
            requestCount,
            "An absent id is an optional SSE field, not a signal to " +
            "abandon the rest of the stream.");
        CollectionAssert.AreEqual(
            new string?[] { null, null },
            sentLastEventIds,
            "Last-Event-ID is omitted when there is no id to send.");
    }

    [Test]
    public void SyncDroppedStreamWithoutEventIdStillReconnects()
    {
        var handler = new SyncTrackingHandler(count =>
            count == 1
                ? CreateDroppedResponse("retry: 0\ndata: one\n\n")
                : CreateResponse(
                    HttpStatusCode.OK,
                    "retry: 0\ndata: two\n\n"));
        ClientPipeline pipeline = CreatePipeline(handler);
        using PipelineResponse response = SendResponse(
            pipeline,
            new Uri("https://example.test/events"));

        string content = ReadToEnd(response.ContentStream!);

        Assert.AreEqual(
            "retry: 0\ndata: one\n\nretry: 0\ndata: two\n\n",
            content);
        Assert.AreEqual(2, handler.RequestCount);
        Assert.IsNull(
            handler.LastEventId,
            "Last-Event-ID is omitted when there is no id to send.");
    }

    [Test]
    public async Task DroppedStreamBeforeAnyEventStillReconnects()
    {
        int requestCount = 0;
        var handler = new MockHttpClientHandler(_ =>
        {
            requestCount++;
            return Task.FromResult(
                requestCount == 1
                    ? CreateDroppedResponse(
                        "retry: 0\ndata: partial")
                    : CreateResponse(
                        HttpStatusCode.OK,
                        "retry: 0\ndata: whole\n\n"));
        });
        ClientPipeline pipeline = CreatePipeline(handler);
        using PipelineResponse response = await SendResponseAsync(
            pipeline,
            new Uri("https://example.test/events"));

        string content = await ReadToEndAsync(response.ContentStream!);

        Assert.AreEqual("retry: 0\ndata: whole\n\n", content);
        Assert.AreEqual(
            2,
            requestCount,
            "Restarting from the beginning is exactly correct when " +
            "no event has been dispatched yet.");
    }

    [Test]
    public async Task CommentOnlyBlocksDoNotBreakReconnect()
    {
        int requestCount = 0;
        var handler = new MockHttpClientHandler(_ =>
        {
            requestCount++;
            return Task.FromResult(
                requestCount == 1
                    ? CreateDroppedResponse(
                        ": keep-alive\n\n: still here\n\n")
                    : CreateResponse(
                        HttpStatusCode.OK,
                        "retry: 0\ndata: one\n\n"));
        });
        ClientPipeline pipeline = CreatePipeline(handler);
        using PipelineResponse response = await SendResponseAsync(
            pipeline,
            new Uri("https://example.test/events"));

        string content = await ReadToEndAsync(response.ContentStream!);

        Assert.AreEqual(
            ": keep-alive\n\n: still here\n\nretry: 0\ndata: one\n\n",
            content,
            "Comment lines are passed through untouched.");
        Assert.AreEqual(
            2,
            requestCount,
            "A block that carries no data field dispatches no event, " +
            "so a drop after one must still reconnect.");
    }

    [Test]
    public async Task RetryOnlyBlocksDoNotBreakReconnect()
    {
        int requestCount = 0;
        var handler = new MockHttpClientHandler(_ =>
        {
            requestCount++;
            return Task.FromResult(
                requestCount == 1
                    ? CreateDroppedResponse("retry: 0\n\n")
                    : CreateResponse(
                        HttpStatusCode.OK,
                        "retry: 0\ndata: one\n\n"));
        });
        ClientPipeline pipeline = CreatePipeline(handler);
        using PipelineResponse response = await SendResponseAsync(
            pipeline,
            new Uri("https://example.test/events"));

        string content = await ReadToEndAsync(response.ContentStream!);

        Assert.AreEqual(
            "retry: 0\n\nretry: 0\ndata: one\n\n",
            content);
        Assert.AreEqual(
            2,
            requestCount,
            "A retry field is a reconnection hint, not an event.");
    }

    [Test]
    public async Task EmptyEventBlocksAreToleratedAndReconnect()
    {
        int requestCount = 0;
        var handler = new MockHttpClientHandler(_ =>
        {
            requestCount++;
            return Task.FromResult(
                requestCount == 1
                    ? CreateDroppedResponse(
                        "retry: 0\ndata: one\n\n\n\n\n")
                    : CreateResponse(
                        HttpStatusCode.OK,
                        "\n\ndata: two\n\n"));
        });
        ClientPipeline pipeline = CreatePipeline(handler);
        using PipelineResponse response = await SendResponseAsync(
            pipeline,
            new Uri("https://example.test/events"));

        string content = await ReadToEndAsync(response.ContentStream!);

        Assert.AreEqual(
            "retry: 0\ndata: one\n\n\n\n\n\n\ndata: two\n\n",
            content,
            "Completely empty events some services emit are passed " +
            "through and must not terminate or corrupt the stream.");
        Assert.AreEqual(2, requestCount);
    }

    [Test]
    public async Task OversizedRequestContentIsNotWrapped()
    {
        int requestCount = 0;
        var handler = new MockHttpClientHandler(_ =>
        {
            requestCount++;
            return Task.FromResult(
                requestCount == 1
                    ? CreateDroppedResponse(
                        "retry: 0\nid: first\ndata: one\n\n")
                    : new HttpResponseMessage(
                        HttpStatusCode.NoContent));
        });
        ClientPipeline pipeline = CreatePipeline(handler);
        using PipelineResponse response = await SendResponseAsync(
            pipeline,
            new Uri("https://example.test/events"),
            BinaryContent.Create(
                BinaryData.FromBytes(new byte[(4 * 1024 * 1024) + 1])));
        Stream stream = response.ContentStream!;
        var buffer = new byte[1024];

        int read = await stream.ReadAsync(buffer, 0, buffer.Length);

        Assert.AreEqual(
            "retry: 0\nid: first\ndata: one\n\n",
            Encoding.UTF8.GetString(buffer, 0, read));
        Assert.ThrowsAsync<IOException>(
            async () => await ExpectNoFurtherReadAsync(stream, buffer),
            "A body too large to snapshot must keep the original " +
            "one-shot behaviour.");
        Assert.AreEqual(1, requestCount);
    }

    [Test]
    public async Task UnmeasurableRequestContentIsNotWrapped()
    {
        int requestCount = 0;
        var handler = new MockHttpClientHandler(_ =>
        {
            requestCount++;
            return Task.FromResult(
                requestCount == 1
                    ? CreateDroppedResponse(
                        "retry: 0\nid: first\ndata: one\n\n")
                    : new HttpResponseMessage(
                        HttpStatusCode.NoContent));
        });
        ClientPipeline pipeline = CreatePipeline(handler);
        using PipelineResponse response = await SendResponseAsync(
            pipeline,
            new Uri("https://example.test/events"),
            new UnmeasurableContent("body"u8.ToArray()));
        Stream stream = response.ContentStream!;
        var buffer = new byte[1024];

        int read = await stream.ReadAsync(buffer, 0, buffer.Length);

        Assert.AreEqual(
            "retry: 0\nid: first\ndata: one\n\n",
            Encoding.UTF8.GetString(buffer, 0, read));
        Assert.ThrowsAsync<IOException>(
            async () => await ExpectNoFurtherReadAsync(stream, buffer),
            "A body whose length cannot be measured must not be " +
            "snapshotted.");
        Assert.AreEqual(1, requestCount);
    }

    [Test]
    public async Task RequestContentAtSizeLimitIsStillWrapped()
    {
        int requestCount = 0;
        var handler = new MockHttpClientHandler(_ =>
        {
            requestCount++;
            return Task.FromResult(
                requestCount == 1
                    ? CreateDroppedResponse(
                        "retry: 0\nid: first\ndata: one\n\n")
                    : new HttpResponseMessage(
                        HttpStatusCode.NoContent));
        });
        ClientPipeline pipeline = CreatePipeline(handler);
        using PipelineResponse response = await SendResponseAsync(
            pipeline,
            new Uri("https://example.test/events"),
            BinaryContent.Create(
                BinaryData.FromBytes(new byte[4 * 1024 * 1024])));

        string content = await ReadToEndAsync(response.ContentStream!);

        Assert.AreEqual("retry: 0\nid: first\ndata: one\n\n", content);
        Assert.AreEqual(
            2,
            requestCount,
            "A body exactly at the limit is still replayable.");
    }

    [Test]
    public async Task NonIdempotentRequestWithoutEventIdDoesNotReconnect()
    {
        int requestCount = 0;
        var handler = new MockHttpClientHandler(_ =>
        {
            requestCount++;
            return Task.FromResult(
                requestCount == 1
                    ? CreateDroppedResponse("retry: 0\ndata: partial")
                    : CreateResponse(
                        HttpStatusCode.OK,
                        "retry: 0\ndata: whole\n\n"));
        });
        ClientPipeline pipeline = CreatePipeline(handler);
        using PipelineResponse response = await SendResponseAsync(
            pipeline,
            new Uri("https://example.test/events"),
            BinaryContent.Create(BinaryData.FromString("{}")),
            "POST");
        Stream stream = response.ContentStream!;

        Assert.ThrowsAsync<IOException>(
            async () => await ReadToEndAsync(stream),
            "RFC 9110 forbids automatically replaying a POST that may " +
            "already have been applied.");
        Assert.AreEqual(1, requestCount);
    }

    [Test]
    public async Task NonIdempotentRequestWithEventIdReconnects()
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
        using PipelineResponse response = await SendResponseAsync(
            pipeline,
            new Uri("https://example.test/events"),
            BinaryContent.Create(BinaryData.FromString("{}")),
            "POST");

        string content = await ReadToEndAsync(response.ContentStream!);

        Assert.AreEqual("retry: 0\nid: first\ndata: one\n\n", content);
        Assert.AreEqual(
            2,
            requestCount,
            "A service that publishes a resumption token has opted into " +
            "being asked to continue rather than repeat the work.");
        Assert.AreEqual("first", lastEventId);
    }

    [Test]
    public async Task IdempotentRequestWithoutEventIdReconnects()
    {
        int requestCount = 0;
        var handler = new MockHttpClientHandler(_ =>
        {
            requestCount++;
            return Task.FromResult(
                requestCount == 1
                    ? CreateDroppedResponse("retry: 0\ndata: partial")
                    : CreateResponse(
                        HttpStatusCode.OK,
                        "retry: 0\ndata: whole\n\n"));
        });
        ClientPipeline pipeline = CreatePipeline(handler);
        using PipelineResponse response = await SendResponseAsync(
            pipeline,
            new Uri("https://example.test/events"),
            BinaryContent.Create(BinaryData.FromString("{}")),
            "PUT");

        string content = await ReadToEndAsync(response.ContentStream!);

        Assert.AreEqual("retry: 0\ndata: whole\n\n", content);
        Assert.AreEqual(
            2,
            requestCount,
            "An idempotent method is safe to replay by definition.");
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

    [Test]
    public async Task NonEventStreamContentTypeIsNotWrapped()
    {
        int requestCount = 0;
        var handler = new MockHttpClientHandler(_ =>
        {
            requestCount++;
            return Task.FromResult(
                CreateJsonResponse("{\"value\":1}"));
        });
        ClientPipeline pipeline = CreatePipeline(handler);
        using PipelineResponse response = await SendResponseAsync(
            pipeline,
            new Uri("https://example.test/events"));

        string content = await ReadToEndAsync(response.ContentStream!);

        Assert.AreEqual(
            "{\"value\":1}",
            content,
            "A body that is not an event stream must be delivered unchanged instead of being parsed as events.");
        Assert.AreEqual(1, requestCount);
    }

    [Test]
    public void SyncNonEventStreamContentTypeIsNotWrapped()
    {
        var handler = new SyncTrackingHandler(_ =>
            CreateJsonResponse("{\"value\":1}"));
        ClientPipeline pipeline = CreatePipeline(handler);
        using PipelineResponse response = SendResponse(
            pipeline,
            new Uri("https://example.test/events"));

        string content = ReadToEnd(response.ContentStream!);

        Assert.AreEqual("{\"value\":1}", content);
    }

    [Test]
    public async Task MissingContentTypeIsNotWrapped()
    {
        var handler = new MockHttpClientHandler(_ =>
            Task.FromResult(
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StreamContent(
                        new MemoryStream(
                            Encoding.UTF8.GetBytes("data: one\n")))
                }));
        ClientPipeline pipeline = CreatePipeline(handler);
        using PipelineResponse response = await SendResponseAsync(
            pipeline,
            new Uri("https://example.test/events"));

        string content = await ReadToEndAsync(response.ContentStream!);

        Assert.AreEqual(
            "data: one\n",
            content,
            "Without a text/event-stream content type the response must pass through untouched.");
    }

    [Test]
    public async Task EventStreamContentTypeWithParametersReconnects()
    {
        int requestCount = 0;
        var handler = new MockHttpClientHandler(_ =>
        {
            requestCount++;
            if (requestCount > 1)
            {
                return Task.FromResult(
                    new HttpResponseMessage(HttpStatusCode.NoContent));
            }

            var dropped = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StreamContent(
                    new ThrowAtEndStream(
                        "retry: 0\ndata: one\n\n"))
            };
            dropped.Content.Headers.ContentType =
                new MediaTypeHeaderValue("text/event-stream")
                {
                    CharSet = "utf-8"
                };
            return Task.FromResult(dropped);
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
        Assert.AreEqual(
            2,
            requestCount,
            "A media type parameter must not disable reconnection.");
    }

    [Test]
    public void ReconnectWithNonEventStreamContentTypeFailsStream()
    {
        int requestCount = 0;
        var handler = new MockHttpClientHandler(_ =>
        {
            requestCount++;
            return Task.FromResult(
                requestCount == 1
                    ? CreateDroppedResponse(
                        "retry: 0\ndata: one\n\n")
                    : CreateJsonResponse("data: gateway\n\n"));
        });
        ClientPipeline pipeline = CreatePipeline(handler);
        var values = new List<string>();

        InvalidOperationException? exception =
            Assert.ThrowsAsync<InvalidOperationException>(
                async () =>
                {
                    AsyncStreamingClientResult<SseItem<BinaryData>>
                        result = await CreateResultAsync(
                            pipeline,
                            new Uri("https://example.test/events"));
                    await foreach (SseItem<BinaryData> item in result)
                    {
                        values.Add(item.Data.ToString());
                    }
                });

        StringAssert.Contains(
            "text/event-stream",
            exception!.Message,
            "The failure must identify the unexpected content type.");
        CollectionAssert.AreEqual(
            new[] { "one" },
            values,
            "A reconnect that is not an event stream must not be spliced onto the delivered events.");
        Assert.AreEqual(
            2,
            requestCount,
            "A reconnect that fails its content type contract must be observable rather than look like a clean stop.");
    }

    [Test]
    public async Task ExhaustedRetryCycleReconnects()
    {
        int requestCount = 0;
        var handler = new MockHttpClientHandler(_ =>
        {
            requestCount++;
            if (requestCount == 1)
            {
                return Task.FromResult(
                    CreateDroppedResponse(
                        "retry: 0\ndata: one\n\n"));
            }

            // Both attempts of the first reconnect fail, so the retry
            // policy reports an AggregateException rather than the
            // individual transport exceptions.
            if (requestCount <= 3)
            {
                throw new IOException("The connection was reset.");
            }

            return Task.FromResult(
                new HttpResponseMessage(HttpStatusCode.NoContent));
        });
        ClientPipeline pipeline = CreatePipeline(
            handler,
            new ImmediateRetryPolicy(maxRetries: 1));
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
        Assert.AreEqual(
            4,
            requestCount,
            "An exhausted retry cycle must not end the stream.");
    }

    private sealed class ImmediateRetryPolicy : ClientRetryPolicy
    {
        internal ImmediateRetryPolicy(int maxRetries)
            : base(maxRetries)
        {
        }

        protected override TimeSpan GetNextDelay(
            PipelineMessage message,
            int tryCount) => TimeSpan.Zero;
    }

    private static HttpResponseMessage CreateJsonResponse(string content)
    {
        var response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(content)
        };
        response.Content.Headers.ContentType =
            new MediaTypeHeaderValue("application/json");
        return response;
    }

    private static ClientPipeline CreatePipeline(
        HttpMessageHandler handler)
        => CreatePipeline(handler, retryPolicy: null);

    private static ClientPipeline CreatePipeline(
        HttpMessageHandler handler,
        PipelinePolicy? retryPolicy)
    {
        var options = new ClientPipelineOptions
        {
            Transport = new HttpClientPipelineTransport(
                new HttpClient(handler))
        };
        if (retryPolicy is not null)
        {
            options.RetryPolicy = retryPolicy;
        }

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
            string? initialLastEventId = null,
            string accept = "text/event-stream")
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
            accept);
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

    private static PipelineMessage CreateSseMessage(
        ClientPipeline pipeline,
        PipelineMessageClassifier classifier)
    {
        PipelineMessage message = pipeline.CreateMessage(
            new Uri("https://example.test/events"),
            "GET",
            classifier);
        message.BufferResponse = false;
        message.Request.Headers.Set(
            "Accept",
            "text/event-stream");
        return message;
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

    private static async Task<PipelineResponse>
        SendResponseAsync(
            ClientPipeline pipeline,
            Uri uri,
            BinaryContent content,
            string method = "POST")
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
        message.Request.Content = content;

        await pipeline.SendAsync(message);
        return message.ExtractResponse()!;
    }

    private sealed class UnmeasurableContent : BinaryContent
    {
        private readonly byte[] _bytes;

        public UnmeasurableContent(byte[] bytes) => _bytes = bytes;

        public override bool TryComputeLength(out long length)
        {
            length = 0;
            return false;
        }

        public override void WriteTo(
            Stream stream,
            CancellationToken cancellationToken = default)
            => stream.Write(_bytes, 0, _bytes.Length);

        public override Task WriteToAsync(
            Stream stream,
            CancellationToken cancellationToken = default)
            => stream.WriteAsync(
                _bytes,
                0,
                _bytes.Length,
                cancellationToken);

        public override void Dispose()
        {
        }
    }

    private static HttpResponseMessage CreateResponse(
        HttpStatusCode status,
        string content)
    {
        var response = new HttpResponseMessage(status)
        {
            Content = new StringContent(content)
        };
        response.Content.Headers.ContentType =
            new MediaTypeHeaderValue("text/event-stream");
        return response;
    }

    private static HttpResponseMessage CreateDroppedResponse(
        string content)
    {
        var response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StreamContent(
                new ThrowAtEndStream(content))
        };
        response.Content.Headers.ContentType =
            new MediaTypeHeaderValue("text/event-stream");
        return response;
    }

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

    // net462 has no Stream.ReadExactly, and CA2022 forbids discarding the
    // count from a plain Read, so reads that are expected to fault assert
    // on the count they would otherwise have ignored.
    private static async Task ExpectNoFurtherReadAsync(
        Stream stream,
        byte[] buffer)
    {
        int read = await stream.ReadAsync(buffer, 0, buffer.Length);
        Assert.Fail(
            $"Expected the drop to surface, but read {read} bytes.");
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
