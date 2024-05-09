// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace System.ClientModel.Tests.Convenience;

public class AsyncServerSentEventEnumerableTests
{
    [Test]
    public async Task EnumeratesEvents()
    {
        using Stream contentStream = BinaryData.FromString(_mockContent).ToStream();
        AsyncServerSentEventEnumerable enumerable = new(contentStream);

        List<ServerSentEvent> events = new();

        await foreach (ServerSentEvent sse in enumerable)
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

    [Test]
    public void ThrowsIfCancelled()
    {
        CancellationToken token = new(true);

        using Stream contentStream = BinaryData.FromString(_mockContent).ToStream();
        AsyncServerSentEventEnumerable enumerable = new(contentStream);
        IAsyncEnumerator<ServerSentEvent> enumerator = enumerable.GetAsyncEnumerator(token);

        Assert.ThrowsAsync<OperationCanceledException>(async () => await enumerator.MoveNextAsync());
    }

    // TODO: Add tests for dispose

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
