// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Collections.Generic;
using System.IO;
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

        Assert.AreEqual(events.Count, 3);

        for (int i = 0; i < events.Count; i++)
        {
            ServerSentEvent sse = events[i];
            Assert.IsTrue(sse.EventName.Span.SequenceEqual($"event.{i}".AsSpan()));
            Assert.IsTrue(sse.Data.Span.SequenceEqual($"{{ \"id\": \"{i}\", \"object\": {i} }}".AsSpan()));
        }
    }

    #region Helpers

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
