// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using ClientModel.Tests.Internal.Mocks;
using NUnit.Framework;
using SyncAsyncTestBase = ClientModel.Tests.SyncAsyncTestBase;

namespace System.ClientModel.Tests.Convenience;

public class ServerSentEventReaderTests : SyncAsyncTestBase
{
    public ServerSentEventReaderTests(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    public async Task GetsEventsFromStream()
    {
        Stream contentStream = BinaryData.FromString(MockSseClient.DefaultMockContent).ToStream();
        ServerSentEventReader reader = new(contentStream);

        List<ServerSentEvent> events = new();
        ServerSentEvent? ssEvent = await reader.TryGetNextEventSyncOrAsync(IsAsync);
        while (ssEvent is not null)
        {
            events.Add(ssEvent.Value);
            ssEvent = await reader.TryGetNextEventSyncOrAsync(IsAsync);
        }

        Assert.AreEqual(events.Count, 4);

        for (int i = 0; i < 3; i++)
        {
            ServerSentEvent sse = events[i];
            Assert.AreEqual($"event.{i}", sse.EventType);
            Assert.AreEqual($"{{ \"IntValue\": {i}, \"StringValue\": \"{i}\" }}", sse.Data);
        }

        Assert.AreEqual("done", events[3].EventType);
        Assert.AreEqual("[DONE]", events[3].Data);
    }

    [Test]
    public async Task HandlesNullLine()
    {
        Stream contentStream = BinaryData.FromString(string.Empty).ToStream();
        ServerSentEventReader reader = new(contentStream);

        ServerSentEvent? ssEvent = await reader.TryGetNextEventSyncOrAsync(IsAsync);
        Assert.IsNull(ssEvent);
    }

    [Test]
    public async Task DiscardsCommentLine()
    {
        Stream contentStream = BinaryData.FromString(": comment").ToStream();
        ServerSentEventReader reader = new(contentStream);

        ServerSentEvent? ssEvent = await reader.TryGetNextEventSyncOrAsync(IsAsync);
        Assert.IsNull(ssEvent);
    }

    [Test]
    public async Task HandlesIgnoreLine()
    {
        Stream contentStream = BinaryData.FromString("""
            ignore: noop


            """).ToStream();
        ServerSentEventReader reader = new(contentStream);

        ServerSentEvent? sse = await reader.TryGetNextEventSyncOrAsync(IsAsync);

        Assert.IsNull(sse);
    }

    [Test]
    public async Task HandlesDoneEvent()
    {
        Stream contentStream = BinaryData.FromString("event: stop\ndata: ~stop~\n\n").ToStream();
        ServerSentEventReader reader = new(contentStream);

        ServerSentEvent? sse = await reader.TryGetNextEventSyncOrAsync(IsAsync);

        Assert.IsNotNull(sse);

        Assert.AreEqual("stop", sse.Value.EventType);
        Assert.AreEqual("~stop~", sse.Value.Data);

        Assert.AreEqual(string.Empty, reader.LastEventId);
        Assert.AreEqual(Timeout.InfiniteTimeSpan, reader.ReconnectionInterval);
    }

    [Test]
    public async Task ConcatenatesDataLines()
    {
        Stream contentStream = BinaryData.FromString("""
            data: YHOO
            data: +2
            data: 10


            """).ToStream();
        ServerSentEventReader reader = new(contentStream);

        ServerSentEvent? sse = await reader.TryGetNextEventSyncOrAsync(IsAsync);

        Assert.IsNotNull(sse);

        Assert.AreEqual("YHOO\n+2\n10", sse.Value.Data);

        Assert.AreEqual(string.Empty, reader.LastEventId);
        Assert.AreEqual(Timeout.InfiniteTimeSpan, reader.ReconnectionInterval);
    }

    [Test]
    public async Task DefaultsEventTypeToMessage()
    {
        Stream contentStream = BinaryData.FromString("""
            data: data


            """).ToStream();
        ServerSentEventReader reader = new(contentStream);

        ServerSentEvent? sse = await reader.TryGetNextEventSyncOrAsync(IsAsync);

        Assert.IsNotNull(sse);

        Assert.AreEqual("message", sse.Value.EventType);
        Assert.AreEqual("data", sse.Value.Data);
    }

    [Test]
    public async Task SecondTestCaseFromSpec()
    {
        // See: https://html.spec.whatwg.org/multipage/server-sent-events.html#event-stream-interpretation
        Stream contentStream = BinaryData.FromString("""
            : test stream

            data: first event
            id: 1

            data:second event
            id

            data:  third event


            """).ToStream();
        ServerSentEventReader reader = new(contentStream);

        List<ServerSentEvent> events = new();
        List<string> ids = new();

        ServerSentEvent? sse = await reader.TryGetNextEventSyncOrAsync(IsAsync);
        while (sse is not null)
        {
            events.Add(sse.Value);
            ids.Add(reader.LastEventId.ToString());

            sse = await reader.TryGetNextEventSyncOrAsync(IsAsync);
        }

        Assert.AreEqual(3, events.Count);

        Assert.AreEqual("first event", events[0].Data);
        Assert.AreEqual("1", ids[0]);

        Assert.AreEqual("second event", events[1].Data);
        Assert.AreEqual(string.Empty, ids[1]);

        Assert.AreEqual(" third event", events[2].Data);
        Assert.AreEqual(string.Empty, ids[2]);
    }

    [Test]
    public async Task ThirdSpecTestCase()
    {
        // See: https://html.spec.whatwg.org/multipage/server-sent-events.html#event-stream-interpretation
        Stream contentStream = BinaryData.FromString("""
            data

            data
            data

            data:
            """).ToStream();
        ServerSentEventReader reader = new(contentStream);

        List<ServerSentEvent> events = new();

        ServerSentEvent? sse = await reader.TryGetNextEventSyncOrAsync(IsAsync);
        while (sse is not null)
        {
            events.Add(sse.Value);
            sse = await reader.TryGetNextEventSyncOrAsync(IsAsync);
        }

        Assert.AreEqual(2, events.Count);
        Assert.AreEqual(0, events[0].Data.Length);
        Assert.AreEqual("\n", events[1].Data);
    }

    [Test]
    public async Task FourthSpecTestCase()
    {
        // See: https://html.spec.whatwg.org/multipage/server-sent-events.html#event-stream-interpretation
        Stream contentStream = BinaryData.FromString("""
            data:test

            data: test


            """).ToStream();
        ServerSentEventReader reader = new(contentStream);

        List<ServerSentEvent> events = new();

        ServerSentEvent? sse = await reader.TryGetNextEventSyncOrAsync(IsAsync);
        while (sse is not null)
        {
            events.Add(sse.Value);
            sse = await reader.TryGetNextEventSyncOrAsync(IsAsync);
        }

        Assert.AreEqual(2, events.Count);
        Assert.AreEqual(events[0].Data, events[1].Data);
    }

    [Test]
    public async Task SetsReconnectionInterval()
    {
        Stream contentStream = BinaryData.FromString("""
            data: test

            data: test
            retry: 2500

            data: test
            retry:


            """).ToStream();
        ServerSentEventReader reader = new(contentStream);

        List<ServerSentEvent> events = new();
        List<TimeSpan> retryValues = new();

        ServerSentEvent? sse = await reader.TryGetNextEventSyncOrAsync(IsAsync);
        while (sse is not null)
        {
            events.Add(sse.Value);
            retryValues.Add(reader.ReconnectionInterval);

            sse = await reader.TryGetNextEventSyncOrAsync(IsAsync);
        }

        Assert.AreEqual(3, events.Count);

        // Defaults to infinite timespan
        Assert.AreEqual("test", events[0].Data);
        Assert.AreEqual(Timeout.InfiniteTimeSpan, retryValues[0]);

        Assert.AreEqual("test", events[1].Data);
        Assert.AreEqual(new TimeSpan(0, 0, 0, 2, 500), retryValues[1]);

        // Ignores invalid values
        Assert.AreEqual("test", events[2].Data);
        Assert.AreEqual(new TimeSpan(0, 0, 0, 2, 500), retryValues[2]);
    }

    [Test]
    public void ThrowsIfCancelled()
    {
        CancellationToken token = new(true);

        using Stream contentStream = BinaryData.FromString(MockSseClient.DefaultMockContent).ToStream();
        ServerSentEventReader reader = new(contentStream);

        Assert.ThrowsAsync<OperationCanceledException>(async ()
            => await reader.TryGetNextEventAsync(token));
    }
}
