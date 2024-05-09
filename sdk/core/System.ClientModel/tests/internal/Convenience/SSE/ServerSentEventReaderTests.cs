// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace System.ClientModel.Tests.Convenience;

public class ServerSentEventReaderTests
{
    // TODO: Test both sync and async

    [Test]
    public async Task GetsEventsFromStream()
    {
        Stream contentStream = BinaryData.FromString(_mockContent).ToStream();
        using ServerSentEventReader reader = new(contentStream);

        List<ServerSentEvent> events = new();
        ServerSentEvent? ssEvent = await reader.TryGetNextEventAsync();
        while (ssEvent is not null)
        {
            events.Add(ssEvent.Value);
            ssEvent = await reader.TryGetNextEventAsync();
        }

        Assert.AreEqual(events.Count, 4);

        for (int i = 0; i < 3; i++)
        {
            ServerSentEvent sse = events[i];
            Assert.IsTrue(sse.EventName.Span.SequenceEqual($"event.{i}".AsSpan()));
            Assert.IsTrue(sse.Data.Span.SequenceEqual($"{{ \"id\": \"{i}\", \"object\": {i} }}".AsSpan()));
        }

        Assert.IsTrue(events[3].EventName.Span.SequenceEqual("done".AsSpan()));
        Assert.IsTrue(events[3].Data.Span.SequenceEqual("[DONE]".AsSpan()));
    }

    [Test]
    public async Task HandlesNullLine()
    {
        Stream contentStream = BinaryData.FromString(string.Empty).ToStream();
        using ServerSentEventReader reader = new(contentStream);

        ServerSentEvent? ssEvent = await reader.TryGetNextEventAsync();
        Assert.IsNull(ssEvent);
    }

    [Test]
    public async Task DiscardsCommentLine()
    {
        Stream contentStream = BinaryData.FromString(": comment").ToStream();
        using ServerSentEventReader reader = new(contentStream);

        ServerSentEvent? ssEvent = await reader.TryGetNextEventAsync();
        Assert.IsNull(ssEvent);
    }

    [Test]
    public async Task HandlesIgnoreLine()
    {
        Stream contentStream = BinaryData.FromString("""
            ignore: noop


            """).ToStream();
        using ServerSentEventReader reader = new(contentStream);

        ServerSentEvent? sse = await reader.TryGetNextEventAsync();

        Assert.IsNull(sse);
    }

    [Test]
    public async Task HandlesDoneEvent()
    {
        Stream contentStream = BinaryData.FromString("event: stop\ndata: ~stop~\n\n").ToStream();
        using ServerSentEventReader reader = new(contentStream);

        ServerSentEvent? sse = await reader.TryGetNextEventAsync();

        Assert.IsNotNull(sse);
        Assert.IsTrue(sse.Value.EventName.Span.SequenceEqual("stop".AsSpan()));
        Assert.IsTrue(sse.Value.Data.Span.SequenceEqual("~stop~".AsSpan()));
        Assert.AreEqual(sse.Value.LastEventId.Length, 0);
        Assert.IsNull(sse.Value.ReconnectionTime);
    }

    [Test]
    public async Task ConcatenatesDataLines()
    {
        Stream contentStream = BinaryData.FromString("""
            event: event
            data: YHOO
            data: +2
            data: 10


            """).ToStream();
        using ServerSentEventReader reader = new(contentStream);

        ServerSentEvent? sse = await reader.TryGetNextEventAsync();

        Assert.IsNotNull(sse);
        Assert.IsTrue(sse.Value.EventName.Span.SequenceEqual("event".AsSpan()));
        Assert.IsTrue(sse.Value.Data.Span.SequenceEqual("YHOO\n+2\n10".AsSpan()));
        Assert.AreEqual(sse.Value.LastEventId.Length, 0);
        Assert.IsNull(sse.Value.ReconnectionTime);
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
        using ServerSentEventReader reader = new(contentStream);

        List<ServerSentEvent> events = new();

        ServerSentEvent? sse = await reader.TryGetNextEventAsync();
        while (sse is not null)
        {
            events.Add(sse.Value);
            sse = await reader.TryGetNextEventAsync();
        }

        Assert.AreEqual(3, events.Count);

        Assert.IsTrue(events[0].Data.Span.SequenceEqual("first event".AsSpan()));
        Assert.IsTrue(events[0].LastEventId.Span.SequenceEqual("1".AsSpan()));

        Assert.IsTrue(events[1].Data.Span.SequenceEqual("second event".AsSpan()));
        Assert.AreEqual(events[1].LastEventId.Length, 0);

        Assert.IsTrue(events[2].Data.Span.SequenceEqual(" third event".AsSpan()));
        Assert.AreEqual(events[2].LastEventId.Length, 0);
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
        using ServerSentEventReader reader = new(contentStream);

        List<ServerSentEvent> events = new();

        ServerSentEvent? sse = await reader.TryGetNextEventAsync();
        while (sse is not null)
        {
            events.Add(sse.Value);
            sse = await reader.TryGetNextEventAsync();
        }

        Assert.AreEqual(2, events.Count);

        Assert.AreEqual(0, events[0].Data.Length);
        Assert.IsTrue(events[1].Data.Span.SequenceEqual("\n".AsSpan()));
    }

    [Test]
    public async Task FourthSpecTestCase()
    {
        // See: https://html.spec.whatwg.org/multipage/server-sent-events.html#event-stream-interpretation
        Stream contentStream = BinaryData.FromString("""
            data:test

            data: test


            """).ToStream();
        using ServerSentEventReader reader = new(contentStream);

        List<ServerSentEvent> events = new();

        ServerSentEvent? sse = await reader.TryGetNextEventAsync();
        while (sse is not null)
        {
            events.Add(sse.Value);
            sse = await reader.TryGetNextEventAsync();
        }

        Assert.AreEqual(2, events.Count);

        Assert.IsTrue(events[0].Data.Span.SequenceEqual(events[1].Data.Span));
    }

    [Test]
    public void ThrowsIfCancelled()
    {
        CancellationToken token = new(true);

        using Stream contentStream = BinaryData.FromString(_mockContent).ToStream();
        using ServerSentEventReader reader = new(contentStream);

        Assert.ThrowsAsync<OperationCanceledException>(async ()
            => await reader.TryGetNextEventAsync(token));
    }

    #region Helpers

    // Note: raw string literal quirk removes \n from final line.
    private string _mockContent = """
        event: event.0
        data: { "id": "0", "object": 0 }

        event: event.1
        data: { "id": "1", "object": 1 }

        event: event.2
        data: { "id": "2", "object": 2 }

        event: done
        data: [DONE]


        """;

    #endregion
}
