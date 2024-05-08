// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace System.ClientModel.Tests.Convenience;

public class AsyncServerSentEventEnumeratorTests
{
    [Test]
    public async Task EnumeratesEvents()
    {
        using Stream contentStream = BinaryData.FromString(_mockContent).ToStream();
        AsyncServerSentEventEnumerator enumerator = new(contentStream, "[DONE]");

        int i = 0;
        while (await enumerator.MoveNextAsync())
        {
            ServerSentEvent sse = enumerator.Current;

            Assert.IsTrue(sse.EventName.Span.SequenceEqual($"event.{i}".AsSpan()));
            Assert.IsTrue(sse.Data.Span.SequenceEqual($"{{ \"id\": \"{i}\", \"object\": {i} }}".AsSpan()));

            i++;
        }

        Assert.AreEqual(i, 3);
    }

    [Test]
    public void ThrowsIfCancelled()
    {
        CancellationToken token = new(true);

        using Stream contentStream = BinaryData.FromString(_mockContent).ToStream();
        AsyncServerSentEventEnumerator enumerator = new(contentStream, "[DONE]", token);

        Assert.ThrowsAsync<OperationCanceledException>(async () => await enumerator.MoveNextAsync());
    }

    [Test]
    public async Task StopsOnStringBasedTerminalEvent()
    {
        string mockContent = """
            event: event.0
            data: 0

            event: stop
            data: ~stop~
        
            event: event.1
            data: 1
        

            """;

        using Stream contentStream = BinaryData.FromString(mockContent).ToStream();
        AsyncServerSentEventEnumerator enumerator = new(contentStream, "~stop~");

        List<ServerSentEvent> events = new();

        while (await enumerator.MoveNextAsync())
        {
            events.Add(enumerator.Current);
        }

        Assert.AreEqual(events.Count, 1);
        Assert.IsTrue(events[0].EventName.Span.SequenceEqual("event.0".AsSpan()));
        Assert.IsTrue(events[0].Data.Span.SequenceEqual("0".AsSpan()));
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
