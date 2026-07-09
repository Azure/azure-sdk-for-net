// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Streaming;
using Azure.AI.AgentServer.Core.Streaming.Backings;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Streaming;

[TestFixture]
public sealed class ReplayEventStreamTests
{
    private static EventStreamRegistry NewReplayRegistry(TimeSpan? ttl = null)
    {
        var options = new EventStreamOptions();
        options.UseInMemoryReplay(cursor: p => ((CursoredEvent)p).N, ttl: ttl);
        return new EventStreamRegistry(options);
    }

    private static async Task<List<object>> DrainAsync(IEventStream stream, int? after = null)
    {
        var items = new List<object>();
        await foreach (object item in stream.Subscribe(after))
        {
            items.Add(item);
        }

        return items;
    }

    [Test]
    public async Task LateSubscriberCatchesUpFromHistory()
    {
        EventStreamRegistry registry = NewReplayRegistry();
        IEventStream stream = await registry.GetOrCreateAsync("r1");

        await stream.EmitAsync(new CursoredEvent(0));
        await stream.EmitAsync(new CursoredEvent(1));
        await stream.EmitAsync(new CursoredEvent(2), close: true);

        // A subscriber attaching after close still sees the full retained history.
        List<object> items = await DrainAsync(stream);
        Assert.That(items.Count, Is.EqualTo(3));
        Assert.That(((CursoredEvent)items[0]).N, Is.EqualTo(0));
        Assert.That(((CursoredEvent)items[2]).N, Is.EqualTo(2));
    }

    [Test]
    public async Task ReconnectAfterCursorDeliversOnlyLaterEvents()
    {
        EventStreamRegistry registry = NewReplayRegistry();
        IEventStream stream = await registry.GetOrCreateAsync("r2");

        for (int n = 0; n < 5; n++)
        {
            await stream.EmitAsync(new CursoredEvent(n));
        }

        await stream.CloseAsync();

        List<object> items = await DrainAsync(stream, after: 2);
        Assert.That(items.Count, Is.EqualTo(2));
        Assert.That(((CursoredEvent)items[0]).N, Is.EqualTo(3));
        Assert.That(((CursoredEvent)items[1]).N, Is.EqualTo(4));
    }

    [Test]
    public async Task GetLastCursorReturnsHighestSeen()
    {
        EventStreamRegistry registry = NewReplayRegistry();
        IEventStream stream = await registry.GetOrCreateAsync("r3");

        Assert.That(await stream.GetLastCursorAsync(), Is.Null);

        await stream.EmitAsync(new CursoredEvent(7));
        await stream.EmitAsync(new CursoredEvent(9));

        Assert.That(await stream.GetLastCursorAsync(), Is.EqualTo(9));
    }

    [Test]
    public async Task LiveBackingIgnoresAfterAndHasNoCursor()
    {
        var options = new EventStreamOptions();
        options.UseInMemoryLive();
        var registry = new EventStreamRegistry(options);
        IEventStream stream = await registry.GetOrCreateAsync("r4");

        Assert.That(await stream.GetLastCursorAsync(), Is.Null);
    }

    private sealed class CursoredEvent
    {
        public CursoredEvent(int n) => N = n;

        public int N { get; }
    }
}
