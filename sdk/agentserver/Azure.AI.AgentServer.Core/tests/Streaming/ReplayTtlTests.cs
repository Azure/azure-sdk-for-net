// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.ServerSentEvents;
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
        var options = new AgentEventStreamOptions();
        options.UseInMemoryReplay(ttl: TimeSpan.FromMilliseconds(80));
        var registry = new InMemoryEventStreamRegistry(options);

        AgentEventStream stream = await registry.GetOrCreateAsync("ttl1");
        await stream.EmitAsync(new SseItem<string>("1") { EventId = "1" });
        await stream.CloseAsync();

        // Before the close-clock elapses the stream is still reachable.
        Assert.That(await registry.GetOrCreateAsync("ttl1"), Is.SameAs(stream));

        await Task.Delay(150);

        // The next emit/subscribe runs eviction, fires the close-clock, and self-destructs.
        Assert.ThrowsAsync<AgentEventStreamNotFoundException>(async () => await stream.EmitAsync(new SseItem<string>("2") { EventId = "2" }));

        // The registry has tombstoned the id; GetAsync now raises NotFound.
        Assert.ThrowsAsync<AgentEventStreamNotFoundException>(async () => await registry.GetAsync("ttl1"));
    }

    [Test]
    public async Task TombstoneIsClearedOnNextGetOrCreate()
    {
        var options = new AgentEventStreamOptions();
        options.UseInMemoryReplay(ttl: TimeSpan.FromMilliseconds(50));
        var registry = new InMemoryEventStreamRegistry(options);

        AgentEventStream first = await registry.GetOrCreateAsync("ttl2");
        await first.EmitAsync(new SseItem<string>("1") { EventId = "1" });
        await first.CloseAsync();
        await Task.Delay(120);
        Assert.ThrowsAsync<AgentEventStreamNotFoundException>(async () => await first.EmitAsync(new SseItem<string>("2") { EventId = "2" }));

        // A fresh GetOrCreate after the tombstone yields a brand-new, usable stream.
        AgentEventStream second = await registry.GetOrCreateAsync("ttl2");
        Assert.That(second, Is.Not.SameAs(first));
        Assert.DoesNotThrowAsync(async () => await second.EmitAsync(new SseItem<string>("10") { EventId = "10" }));
    }

    [Test]
    public async Task GetLastEventIdIsSideEffectFreeAndDoesNotTriggerTombstone()
    {
        var options = new AgentEventStreamOptions();
        options.UseInMemoryReplay(ttl: TimeSpan.FromMilliseconds(60));
        var registry = new InMemoryEventStreamRegistry(options);

        AgentEventStream stream = await registry.GetOrCreateAsync("ttl3");
        await stream.EmitAsync(new SseItem<string>("42") { EventId = "42" });
        await stream.CloseAsync();
        await Task.Delay(150);

        // GetLastEventIdAsync must keep working on a closed stream after events expired,
        // and must NOT itself trigger the close-clock tombstone.
        Assert.That(await stream.GetLastEventIdAsync(), Is.EqualTo("42"));
        Assert.That(await registry.GetOrCreateAsync("ttl3"), Is.SameAs(stream));
    }
}
