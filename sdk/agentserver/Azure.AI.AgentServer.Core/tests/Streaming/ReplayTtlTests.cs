// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Streaming;
using Azure.AI.AgentServer.Core.Streaming.Backings;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Streaming;

[TestFixture]
public sealed class ReplayTtlTests
{
    [Test]
    public async Task CloseClockTtlElapsesDestroysStreamAndSubsequentOpsRaiseNotFound()
    {
        var options = new EventStreamOptions();
        options.UseInMemoryReplay(cursor: p => (int)p, ttl: TimeSpan.FromMilliseconds(80));
        var registry = new EventStreamRegistry(options);

        IEventStream stream = await registry.GetOrCreateAsync("ttl1");
        await stream.EmitAsync(1);
        await stream.CloseAsync();

        // Before the close-clock elapses the stream is still reachable.
        Assert.That(await registry.GetOrCreateAsync("ttl1"), Is.SameAs(stream));

        await Task.Delay(150);

        // The next emit/subscribe runs eviction, fires the close-clock, and self-destructs.
        Assert.ThrowsAsync<EventStreamNotFoundException>(async () => await stream.EmitAsync(2));

        // The registry has tombstoned the id; GetAsync now raises NotFound.
        Assert.ThrowsAsync<EventStreamNotFoundException>(async () => await registry.GetAsync("ttl1"));
    }

    [Test]
    public async Task TombstoneIsClearedOnNextGetOrCreate()
    {
        var options = new EventStreamOptions();
        options.UseInMemoryReplay(cursor: p => (int)p, ttl: TimeSpan.FromMilliseconds(50));
        var registry = new EventStreamRegistry(options);

        IEventStream first = await registry.GetOrCreateAsync("ttl2");
        await first.EmitAsync(1);
        await first.CloseAsync();
        await Task.Delay(120);
        Assert.ThrowsAsync<EventStreamNotFoundException>(async () => await first.EmitAsync(2));

        // A fresh GetOrCreate after the tombstone yields a brand-new, usable stream.
        IEventStream second = await registry.GetOrCreateAsync("ttl2");
        Assert.That(second, Is.Not.SameAs(first));
        Assert.DoesNotThrowAsync(async () => await second.EmitAsync(10));
    }

    [Test]
    public async Task GetLastCursorIsSideEffectFreeAndDoesNotTriggerTombstone()
    {
        var options = new EventStreamOptions();
        options.UseInMemoryReplay(cursor: p => (int)p, ttl: TimeSpan.FromMilliseconds(60));
        var registry = new EventStreamRegistry(options);

        IEventStream stream = await registry.GetOrCreateAsync("ttl3");
        await stream.EmitAsync(42);
        await stream.CloseAsync();
        await Task.Delay(150);

        // GetLastCursorAsync must keep working on a closed stream after events expired,
        // and must NOT itself trigger the close-clock tombstone.
        Assert.That(await stream.GetLastCursorAsync(), Is.EqualTo(42));
        Assert.That(await registry.GetOrCreateAsync("ttl3"), Is.SameAs(stream));
    }
}
