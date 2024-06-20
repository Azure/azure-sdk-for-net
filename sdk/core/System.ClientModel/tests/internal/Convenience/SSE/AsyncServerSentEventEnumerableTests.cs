// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using ClientModel.Tests.Internal.Mocks;
using NUnit.Framework;

namespace System.ClientModel.Tests.Convenience;

public class AsyncServerSentEventEnumerableTests
{
    [Test]
    public async Task EnumeratesEvents()
    {
        using Stream contentStream = BinaryData.FromString(MockSseClient.DefaultMockContent).ToStream();
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
            Assert.AreEqual($"{{ \"IntValue\": {i}, \"StringValue\": \"{i}\" }}", events[i].Data);
        }
    }

    [Test]
    public void ThrowsIfCancelled()
    {
        CancellationToken token = new(true);

        using Stream contentStream = BinaryData.FromString(MockSseClient.DefaultMockContent).ToStream();
        AsyncServerSentEventEnumerable enumerable = new(contentStream);
        IAsyncEnumerator<ServerSentEvent> enumerator = enumerable.GetAsyncEnumerator(token);

        Assert.ThrowsAsync<OperationCanceledException>(async () => await enumerator.MoveNextAsync());
    }
}
