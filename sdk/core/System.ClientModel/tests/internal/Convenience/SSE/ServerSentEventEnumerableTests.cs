// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Collections.Generic;
using System.IO;
using ClientModel.Tests.Internal.Mocks;
using NUnit.Framework;

namespace System.ClientModel.Tests.Convenience;

public class ServerSentEventEnumerableTests
{
    [Test]
    public void EnumeratesEvents()
    {
        using Stream contentStream = BinaryData.FromString(MockSseClient.DefaultMockContent).ToStream();
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
            Assert.AreEqual($"{{ \"IntValue\": {i}, \"StringValue\": \"{i}\" }}", events[i].Data);
        }
    }
}
