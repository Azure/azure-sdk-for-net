// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Net.ServerSentEvents;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using ClientModel.Tests.Collections;
using NUnit.Framework;

namespace System.ClientModel.Tests.Results;

public class StreamingResultParsingTests
{
    [Test]
    public async Task SseParsesEventEnvelopeAndTypedPayload()
    {
        MockStreamedResponse response =
            new(MockStreamedData.SseMetadataMockContent);
        AsyncStreamingClientResult<SseItem<StreamedValue>> result =
            SseStreamedValueResult.Create(response);
        List<SseItem<StreamedValue>> items = [];

        await foreach (SseItem<StreamedValue> item in result)
        {
            items.Add(item);
        }

        Assert.AreEqual(MockStreamedData.TotalItemCount, items.Count);
        for (int i = 0; i < items.Count; i++)
        {
            Assert.AreEqual($"event.{i}", items[i].EventType);
            Assert.AreEqual(i.ToString(), items[i].EventId);
            Assert.AreEqual(i, items[i].Data.Id);
            Assert.AreEqual(i.ToString(), items[i].Data.Value);
        }
        Assert.AreEqual(TimeSpan.FromMilliseconds(1500), items[0].ReconnectionInterval);
        Assert.IsTrue(response.IsDisposed);
    }

    [Test]
    public async Task SseDetectsTerminalPayloadBeforeInvokingTypedParser()
    {
        MockStreamedResponse response = new(
            "data: { \"id\": 0, \"value\": \"0\" }\n\ndata: [DONE]\n\n");
        int parserInvocationCount = 0;
        AsyncStreamingClientResult<SseItem<StreamedValue>> result =
            AsyncStreamingClientResult.CreateSse(
                response,
                (_, data) =>
                {
                    parserInvocationCount++;
                    return StreamedValue.FromJson(data.ToArray());
                },
                static item => item.Data.ToString() == "[DONE]");
        List<SseItem<StreamedValue>> items = [];

        await foreach (SseItem<StreamedValue> item in result)
        {
            items.Add(item);
        }

        Assert.AreEqual(1, parserInvocationCount);
        Assert.AreEqual(1, items.Count);
        Assert.AreEqual(0, items[0].Data.Id);
        Assert.IsTrue(response.IsDisposed);
    }

    [Test]
    public async Task SseWithoutTerminalPredicateUsesTypedParser()
    {
        MockStreamedResponse response =
            new("event: value\nid: 1\ndata: { \"id\": 1, \"value\": \"one\" }\n\n");
        int parserInvocationCount = 0;
        AsyncStreamingClientResult<SseItem<StreamedValue>> result =
            AsyncStreamingClientResult.CreateSse(
                response,
                (_, data) =>
                {
                    parserInvocationCount++;
                    return StreamedValue.FromJson(data.ToArray());
                });

        await foreach (SseItem<StreamedValue> item in result)
        {
            Assert.AreEqual("value", item.EventType);
            Assert.AreEqual("1", item.EventId);
            Assert.AreEqual(1, item.Data.Id);
        }

        Assert.AreEqual(1, parserInvocationCount);
        Assert.IsTrue(response.IsDisposed);
    }

    [Test]
    public async Task SsePositionalNullTerminalPredicateRemainsUnambiguous()
    {
        MockStreamedResponse response = new("data: value\n\n");
        AsyncStreamingClientResult<SseItem<BinaryData>> result =
            AsyncStreamingClientResult.CreateSse(response, null);

        await foreach (SseItem<BinaryData> item in result)
        {
            Assert.AreEqual("value", item.Data.ToString());
        }

        Assert.IsTrue(response.IsDisposed);
    }

    [Test]
    public async Task ReconnectableSseUsesRetryAndLastEventId()
    {
        MockStreamedResponse initial = new("""
            retry: 25
            id: first
            data: one


            """);
        MockStreamedResponse reconnected =
            new("id: second\ndata: two\n\ndata: [DONE]\n\n");
        List<string?> reconnectEventIds = [];
        List<TimeSpan> delays = [];
        int reconnectCount = 0;

        AsyncStreamingClientResult<SseItem<BinaryData>> result =
            AsyncStreamingClientResult.CreateReconnectableSse(
                initial,
                (lastEventId, _) =>
                {
                    reconnectCount++;
                    Assert.AreEqual(1, reconnectCount);
                    reconnectEventIds.Add(lastEventId);
                    return new ValueTask<PipelineResponse>(reconnected);
                },
                static (_, data) => BinaryData.FromBytes(data.ToArray()),
                static item => item.Data.ToString() == "[DONE]",
                TimeSpan.FromSeconds(3),
                (delay, _) =>
                {
                    delays.Add(delay);
                    return default;
                });
        List<string> values = [];

        await foreach (SseItem<BinaryData> item in result)
        {
            values.Add(item.Data.ToString());
        }

        CollectionAssert.AreEqual(new[] { "one", "two" }, values);
        CollectionAssert.AreEqual(new[] { "first" }, reconnectEventIds);
        CollectionAssert.AreEqual(
            new[] { TimeSpan.FromMilliseconds(25) },
            delays);
        Assert.AreEqual(1, reconnectCount);
        Assert.IsTrue(initial.IsDisposed);
        Assert.IsTrue(reconnected.IsDisposed);
    }

    [Test]
    public async Task ReconnectableSseEmptyEventIdClearsLastEventId()
    {
        MockStreamedResponse initial =
            new("retry: 0\nid: first\ndata: one\n\n");
        MockStreamedResponse clearsId = new("id:\ndata: two\n\n");
        MockStreamedResponse noContent = new("", status: 204);
        Queue<PipelineResponse> responses = new([clearsId, noContent]);
        List<string?> reconnectEventIds = [];

        AsyncStreamingClientResult<SseItem<BinaryData>> result =
            AsyncStreamingClientResult.CreateReconnectableSse(
                initial,
                (lastEventId, _) =>
                {
                    reconnectEventIds.Add(lastEventId);
                    return new ValueTask<PipelineResponse>(responses.Dequeue());
                });

        await foreach (SseItem<BinaryData> _ in result)
        {
        }

        CollectionAssert.AreEqual(new string?[] { "first", null }, reconnectEventIds);
        Assert.IsTrue(initial.IsDisposed);
        Assert.IsTrue(clearsId.IsDisposed);
        Assert.IsTrue(noContent.IsDisposed);
    }

    [Test]
    public async Task ReconnectableSseInitialNoContentEndsWithoutReconnect()
    {
        MockStreamedResponse initial = new("", status: 204);
        int reconnectCount = 0;
        AsyncStreamingClientResult<SseItem<BinaryData>> result =
            AsyncStreamingClientResult.CreateReconnectableSse(
                initial,
                (_, _) =>
                {
                    reconnectCount++;
                    return new ValueTask<PipelineResponse>(
                        new MockStreamedResponse("data: unexpected\n\n"));
                },
                static (_, data) => BinaryData.FromBytes(data.ToArray()),
                isTerminal: null,
                TimeSpan.Zero,
                static (_, _) => default);

        await foreach (SseItem<BinaryData> _ in result)
        {
            Assert.Fail("A 204 response must not produce events.");
        }

        Assert.AreEqual(0, reconnectCount);
        Assert.IsTrue(initial.IsDisposed);
    }

    [Test]
    public async Task ReconnectableSseCancellationStopsReconnectDelay()
    {
        MockStreamedResponse initial = new("data: one\n\n");
        using CancellationTokenSource cancellation = new();
        TaskCompletionSource<object?> delayStarted =
            new(TaskCreationOptions.RunContinuationsAsynchronously);
        AsyncStreamingClientResult<SseItem<BinaryData>> result =
            AsyncStreamingClientResult.CreateReconnectableSse(
                initial,
                (_, _) => throw new InvalidOperationException(
                    "Reconnect must not run after cancellation."),
                static (_, data) => BinaryData.FromBytes(data.ToArray()),
                isTerminal: null,
                TimeSpan.Zero,
                async (_, cancellationToken) =>
                {
                    delayStarted.TrySetResult(null);
                    await Task.Delay(Timeout.InfiniteTimeSpan, cancellationToken);
                });

        Task enumeration = Task.Run(async () =>
        {
            await foreach (SseItem<BinaryData> _ in result
                .WithCancellation(cancellation.Token))
            {
            }
        });
        Assert.AreSame(
            delayStarted.Task,
            await Task.WhenAny(delayStarted.Task, Task.Delay(TimeSpan.FromSeconds(5))));
        cancellation.Cancel();

        Assert.CatchAsync<OperationCanceledException>(async () => await enumeration);
        Assert.IsTrue(initial.IsDisposed);
    }

    [Test]
    public void ReconnectableSseRejectsUnexpectedStatusAndDisposesResponse()
    {
        MockStreamedResponse initial = new("data: one\n\n");
        MockStreamedResponse invalid = new("data: invalid\n\n", status: 202);
        AsyncStreamingClientResult<SseItem<BinaryData>> result =
            AsyncStreamingClientResult.CreateReconnectableSse(
                initial,
                (_, _) => new ValueTask<PipelineResponse>(invalid),
                static (_, data) => BinaryData.FromBytes(data.ToArray()),
                isTerminal: null,
                TimeSpan.Zero,
                static (_, _) => default);

        InvalidOperationException? exception =
            Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await foreach (SseItem<BinaryData> _ in result)
                {
                }
            });

        Assert.That(exception!.Message, Does.Contain("status code 200 or 204"));
        Assert.IsTrue(invalid.IsDisposed);
        Assert.IsTrue(initial.IsDisposed);
    }

    [Test]
    public async Task ReconnectableSseReconnectsAfterReadFailure()
    {
        var stream = new ThrowAfterContentStream(
            BinaryData.FromString("id: before-drop\ndata: one\n\n").ToArray());
        MockStreamedResponse initial = new(stream);
        MockStreamedResponse noContent = new("", status: 204);
        string? reconnectEventId = null;
        AsyncStreamingClientResult<SseItem<BinaryData>> result =
            AsyncStreamingClientResult.CreateReconnectableSse(
                initial,
                (lastEventId, _) =>
                {
                    reconnectEventId = lastEventId;
                    return new ValueTask<PipelineResponse>(noContent);
                },
                static (_, data) => BinaryData.FromBytes(data.ToArray()),
                isTerminal: null,
                TimeSpan.Zero,
                static (_, _) => default);
        List<string> values = [];

        await foreach (SseItem<BinaryData> item in result)
        {
            values.Add(item.Data.ToString());
        }

        CollectionAssert.AreEqual(new[] { "one" }, values);
        Assert.AreEqual("before-drop", reconnectEventId);
        Assert.IsTrue(noContent.IsDisposed);
    }

    [Test]
    public async Task ReconnectableSseRetriesConnectionFailure()
    {
        MockStreamedResponse initial =
            new("id: before-drop\ndata: one\n\n");
        MockStreamedResponse noContent = new("", status: 204);
        int reconnectCount = 0;
        List<TimeSpan> delays = [];
        AsyncStreamingClientResult<SseItem<BinaryData>> result =
            AsyncStreamingClientResult.CreateReconnectableSse(
                initial,
                (lastEventId, _) =>
                {
                    Assert.AreEqual("before-drop", lastEventId);
                    reconnectCount++;
                    if (reconnectCount == 1)
                    {
                        throw new IOException(
                            "The reconnect attempt failed.");
                    }

                    return new ValueTask<PipelineResponse>(noContent);
                },
                static (_, data) => BinaryData.FromBytes(data.ToArray()),
                isTerminal: null,
                TimeSpan.FromMilliseconds(25),
                (delay, _) =>
                {
                    delays.Add(delay);
                    return default;
                });

        await foreach (SseItem<BinaryData> _ in result)
        {
        }

        Assert.AreEqual(2, reconnectCount);
        CollectionAssert.AreEqual(
            new[]
            {
                TimeSpan.FromMilliseconds(25),
                TimeSpan.FromMilliseconds(25)
            },
            delays);
        Assert.IsTrue(noContent.IsDisposed);
    }

    [Test]
    public async Task DisposingReconnectableSseClosesActiveReconnectResponse()
    {
        MockStreamedResponse initial = new("data: one\n\n");
        var blockingStream = new BlockingReadStream();
        MockStreamedResponse reconnected = new(blockingStream);
        AsyncStreamingClientResult<SseItem<BinaryData>> result =
            AsyncStreamingClientResult.CreateReconnectableSse(
                initial,
                (_, _) => new ValueTask<PipelineResponse>(reconnected),
                static (_, data) => BinaryData.FromBytes(data.ToArray()),
                isTerminal: null,
                TimeSpan.Zero,
                static (_, _) => default);
        IAsyncEnumerator<SseItem<BinaryData>> enumerator =
            ((IAsyncEnumerable<SseItem<BinaryData>>)result).GetAsyncEnumerator();
        Assert.IsTrue(await enumerator.MoveNextAsync());
        Task<bool> blockedMoveNext = enumerator.MoveNextAsync().AsTask();
        await blockingStream.ReadStarted.Task;

        Task disposal = result.DisposeAsync().AsTask();
        await disposal;

        Assert.IsTrue(blockingStream.IsDisposed);
        Assert.CatchAsync<OperationCanceledException>(
            async () => await blockedMoveNext);
        Assert.IsTrue(reconnected.IsDisposed);
    }

    [TestCase("\n")]
    [TestCase("\r\n")]
    public async Task JsonlParsesTypedValuesAndBlankLines(string newline)
    {
        string content = MockStreamedData.JsonlMockContent
            .Replace("\r\n", "\n")
            .Replace("\n", newline);
        MockStreamedResponse response = new(content);
        AsyncStreamingClientResult<StreamedValue> result =
            JsonlStreamedValueResult.Create(response);
        List<StreamedValue> items = [];

        await foreach (StreamedValue item in result)
        {
            items.Add(item);
        }

        Assert.AreEqual(MockStreamedData.TotalItemCount, items.Count);
        for (int i = 0; i < items.Count; i++)
        {
            Assert.AreEqual(i, items[i].Id);
            Assert.AreEqual(i.ToString(), items[i].Value);
        }
        Assert.IsTrue(response.IsDisposed);
    }

    [Test]
    public void JsonlDisposesResponseWhenParsingFails()
    {
        MockStreamedResponse response = new("""
            { "id": 0, "value": "0" }
            { malformed }

            """);
        AsyncStreamingClientResult<StreamedValue> result =
            JsonlStreamedValueResult.Create(response);

        Assert.CatchAsync<JsonException>(async () =>
        {
            await foreach (StreamedValue _ in result)
            {
            }
        });

        Assert.IsTrue(response.IsDisposed);
    }

    [TestCase("\n")]
    [TestCase("\r\n")]
    public async Task JsonlSkipsLeadingUtf8Bom(string newline)
    {
        MockStreamedResponse response =
            new($"\uFEFF{{ \"id\": 0, \"value\": \"0\" }}{newline}");
        AsyncStreamingClientResult<StreamedValue> result =
            JsonlStreamedValueResult.Create(response);

        await foreach (StreamedValue item in result)
        {
            Assert.AreEqual(0, item.Id);
            Assert.AreEqual("0", item.Value);
        }

        Assert.IsTrue(response.IsDisposed);
    }

    [Test]
    public async Task JsonlDoesNotSkipBomAfterFirstRecord()
    {
        MockStreamedResponse response =
            new("{\"id\":0}\n\uFEFF{\"id\":1}\n");
        List<BinaryData> items = [];

        await foreach (BinaryData item in
            AsyncStreamingClientResult.CreateJsonLines(response))
        {
            items.Add(item);
        }

        Assert.AreEqual(2, items.Count);
        Assert.AreEqual(0xEF, items[1].ToMemory().Span[0]);
        Assert.IsTrue(response.IsDisposed);
    }

    [Test]
    public async Task JsonlSkipsAsciiWhitespaceLines()
    {
        MockStreamedResponse response =
            new(" \t\r\n{\"id\":1}\n");
        List<BinaryData> items = [];

        await foreach (BinaryData item in
            AsyncStreamingClientResult.CreateJsonLines(response))
        {
            items.Add(item);
        }

        Assert.AreEqual(1, items.Count);
        Assert.AreEqual("{\"id\":1}", items[0].ToString());
        Assert.IsTrue(response.IsDisposed);
    }

    [Test]
    public void JsonlRejectsLineOverConfiguredLimit()
    {
        MockStreamedResponse response = new("123456789\n");
        AsyncStreamingClientResult<BinaryData> result =
            AsyncStreamingClientResult.CreateJsonLines(
                response,
                static data => data,
                maxLineLength: 8);

        Assert.ThrowsAsync<InvalidDataException>(async () =>
        {
            await foreach (BinaryData _ in result)
            {
            }
        });
        Assert.IsTrue(response.IsDisposed);
    }

    [Test]
    public void SseTerminalPredicateRequiresTerminalEvent()
    {
        MockStreamedResponse response = new("data: value\n\n");
        AsyncStreamingClientResult<SseItem<BinaryData>> result =
            AsyncStreamingClientResult.CreateSse(
                response,
                static item => item.Data.ToString() == "[DONE]");

        Assert.ThrowsAsync<InvalidDataException>(async () =>
        {
            await foreach (SseItem<BinaryData> _ in result)
            {
            }
        });
        Assert.IsTrue(response.IsDisposed);
    }

    [Test]
    public async Task RawFactoriesReturnBinaryData()
    {
        MockStreamedResponse sseResponse = new("event: value\ndata: hello\n\n");
        await foreach (SseItem<BinaryData> item in
            AsyncStreamingClientResult.CreateSse(sseResponse))
        {
            Assert.AreEqual("value", item.EventType);
            Assert.AreEqual("hello", item.Data.ToString());
        }

        MockStreamedResponse jsonlResponse = new("{\"value\":1}\n");
        await foreach (BinaryData item in
            AsyncStreamingClientResult.CreateJsonLines(jsonlResponse))
        {
            Assert.AreEqual("{\"value\":1}", item.ToString());
        }
    }

    private sealed class ThrowAfterContentStream(byte[] content) : Stream
    {
        private readonly MemoryStream _content = new(content);
        private bool _contentReturned;

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
        {
            if (_contentReturned)
            {
                throw new IOException("The connection dropped.");
            }
            _contentReturned = true;
            return _content.Read(buffer, offset, count);
        }

        public override Task<int> ReadAsync(
            byte[] buffer,
            int offset,
            int count,
            CancellationToken cancellationToken)
            => Task.FromResult(Read(buffer, offset, count));

#if !NETFRAMEWORK
        public override ValueTask<int> ReadAsync(
            Memory<byte> buffer,
            CancellationToken cancellationToken = default)
        {
            byte[] bytes = new byte[buffer.Length];
            int read = Read(bytes, 0, bytes.Length);
            bytes.AsMemory(0, read).CopyTo(buffer);
            return new ValueTask<int>(read);
        }
#endif

        public override void Flush() => throw new NotSupportedException();
        public override long Seek(long offset, SeekOrigin origin)
            => throw new NotSupportedException();
        public override void SetLength(long value)
            => throw new NotSupportedException();
        public override void Write(byte[] buffer, int offset, int count)
            => throw new NotSupportedException();
    }

    private sealed class BlockingReadStream : Stream
    {
        private readonly TaskCompletionSource<int> _readCompletion =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource<object?> ReadStarted { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public bool IsDisposed { get; private set; }
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

        public override async Task<int> ReadAsync(
            byte[] buffer,
            int offset,
            int count,
            CancellationToken cancellationToken)
        {
            ReadStarted.TrySetResult(null);
            return await WaitForReadAsync(cancellationToken);
        }

#if !NETFRAMEWORK
        public override async ValueTask<int> ReadAsync(
            Memory<byte> buffer,
            CancellationToken cancellationToken = default)
        {
            ReadStarted.TrySetResult(null);
            return await WaitForReadAsync(cancellationToken);
        }
#endif

        private async Task<int> WaitForReadAsync(
            CancellationToken cancellationToken)
        {
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
}
