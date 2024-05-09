// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace System.ClientModel.Tests.Convenience;

public class ServerSentEventEnumerableTests
{
    [Test]
    public void EnumeratesEvents()
    {
        using Stream contentStream = BinaryData.FromString(_mockContent).ToStream();
        ServerSentEventEnumerable enumerable = new(contentStream);

        List<ServerSentEvent> events = new();

        foreach (ServerSentEvent sse in enumerable)
        {
            events.Add(sse);
        }

        Assert.AreEqual(4, events.Count);

        for (int i = 0; i < 3; i++)
        {
            Assert.AreEqual($"event.{i}", events[i].EventType);
            Assert.AreEqual($"{{ \"id\": \"{i}\", \"object\": {i} }}", events[i].Data);
        }
    }

    #region Helpers

    private readonly string _mockContent = """
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
