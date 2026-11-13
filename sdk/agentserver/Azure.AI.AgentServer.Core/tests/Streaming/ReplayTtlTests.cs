// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
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
    public void InMemoryReplayDefaultsToBoundedRetention()
    {
        var options = new AgentEventStreamOptions();

        options.UseInMemoryReplay();

        Assert.That(options.Configuration.Ttl, Is.EqualTo(TimeSpan.FromMinutes(10)));
    }

    [Test]
    public async Task CloseClockTtlReclaimsStreamWithoutAnotherLookup()
    {
        var options = new AgentEventStreamOptions();
        options.UseInMemoryReplay(ttl: TimeSpan.FromMilliseconds(30));
        using var registry = new InMemoryEventStreamRegistry(options);

        AgentEventStream stream = await registry.GetOrCreateAsync("ttl1");
        await stream.EmitAsync(new SseItem<string>("1") { EventId = "1" });
        await stream.CloseAsync();

        await WaitForAsync(() => registry.StreamCount == 0);
        Assert.That(registry.TaskOwnerCount, Is.Zero);
        Assert.ThrowsAsync<AgentEventStreamNotFoundException>(async () => await registry.GetAsync("ttl1"));
    }

    [Test]
    public async Task TombstoneIsClearedOnNextGetOrCreate()
    {
        var options = new AgentEventStreamOptions();
        options.UseInMemoryReplay(ttl: TimeSpan.FromMilliseconds(50));
        using var registry = new InMemoryEventStreamRegistry(options);

        AgentEventStream first = await registry.GetOrCreateAsync("ttl2");
        await first.EmitAsync(new SseItem<string>("1") { EventId = "1" });
        await first.CloseAsync();
        await WaitForAsync(() => registry.StreamCount == 0);

        // A fresh GetOrCreate after the tombstone yields a brand-new, usable stream.
        AgentEventStream second = await registry.GetOrCreateAsync("ttl2");
        Assert.That(second, Is.Not.SameAs(first));
        Assert.DoesNotThrowAsync(async () => await second.EmitAsync(new SseItem<string>("10") { EventId = "10" }));
    }

    [Test]
    public async Task ClosedStreamIsUnavailableAfterAutomaticTombstone()
    {
        var options = new AgentEventStreamOptions();
        options.UseInMemoryReplay(ttl: TimeSpan.FromMilliseconds(60));
        using var registry = new InMemoryEventStreamRegistry(options);

        AgentEventStream stream = await registry.GetOrCreateAsync("ttl3");
        await stream.EmitAsync(new SseItem<string>("42") { EventId = "42" });
        await stream.CloseAsync();
        await WaitForAsync(() => registry.StreamCount == 0);

        Assert.ThrowsAsync<AgentEventStreamNotFoundException>(
            async () => await stream.GetLastEventIdAsync());
    }

    private static async Task WaitForAsync(Func<bool> condition)
    {
        var timeout = TimeSpan.FromSeconds(5);
        Stopwatch stopwatch = Stopwatch.StartNew();
        while (stopwatch.Elapsed < timeout)
        {
            if (condition())
            {
                return;
            }

            await Task.Delay(10);
        }

        Assert.That(condition(), Is.True, $"Condition was not met within {timeout}.");
    }
}
