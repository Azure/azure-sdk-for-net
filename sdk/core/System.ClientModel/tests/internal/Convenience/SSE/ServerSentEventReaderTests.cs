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

        Assert.IsNotNull(sse);
        Assert.AreEqual(sse.Value.EventName.Length, 0);
        Assert.AreEqual(sse.Value.Data.Length, 0);
        Assert.AreEqual(sse.Value.LastEventId.Length, 0);
        Assert.IsNull(sse.Value.ReconnectionTime);
    }

    [Test]
    public async Task HandlesDoneEvent()
    {
        Stream contentStream = BinaryData.FromString("event: done\ndata: [DONE]\n\n").ToStream();
        using ServerSentEventReader reader = new(contentStream);

        ServerSentEvent? sse = await reader.TryGetNextEventAsync();

        Assert.IsNotNull(sse);
        Assert.IsTrue(sse.Value.EventName.Span.SequenceEqual($"done".AsSpan()));
        Assert.IsTrue(sse.Value.Data.Span.SequenceEqual($"[DONE]".AsSpan()));
        Assert.AreEqual(sse.Value.LastEventId.Length, 0);
        Assert.IsNull(sse.Value.ReconnectionTime);
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
