// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net.ServerSentEvents;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Streaming;
using Azure.AI.AgentServer.Core.Streaming.Backings;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Streaming;

[TestFixture]
public sealed class ReplayEventStreamTests
{
    private static AgentEventStreamRegistry NewReplayRegistry(TimeSpan? ttl = null)
    {
        var options = new AgentEventStreamOptions();
        options.UseInMemoryReplay(ttl: ttl);
        return new InMemoryEventStreamRegistry(options);
    }

    private static async Task<List<SseItem<string>>> DrainAsync(AgentEventStream stream, string? afterEventId = null)
    {
        var items = new List<SseItem<string>>();
        await foreach (SseItem<string> item in stream.Subscribe(afterEventId))
        {
            items.Add(item);
        }

        return items;
    }

    [Test]
    public async Task LateSubscriberCatchesUpFromHistory()
    {
        AgentEventStreamRegistry registry = NewReplayRegistry();
        AgentEventStream stream = await registry.GetOrCreateAsync("r1");

        await stream.EmitAsync(new SseItem<string>("0") { EventId = "0" });
        await stream.EmitAsync(new SseItem<string>("1") { EventId = "1" });
        await stream.EmitAsync(new SseItem<string>("2") { EventId = "2" }, close: true);

        // A subscriber attaching after close still sees the full retained history.
        List<SseItem<string>> items = await DrainAsync(stream);
        Assert.That(items.Count, Is.EqualTo(3));
        Assert.That(items[0].Data, Is.EqualTo("0"));
        Assert.That(items[2].Data, Is.EqualTo("2"));
    }

    [Test]
    public async Task ReconnectAfterCursorDeliversOnlyLaterEvents()
    {
        AgentEventStreamRegistry registry = NewReplayRegistry();
        AgentEventStream stream = await registry.GetOrCreateAsync("r2");

        for (int n = 0; n < 5; n++)
        {
            string value = n.ToString();
            await stream.EmitAsync(new SseItem<string>(value) { EventId = value });
        }

        await stream.CloseAsync();

        List<SseItem<string>> items = await DrainAsync(stream, afterEventId: "2");
        Assert.That(items.Count, Is.EqualTo(2));
        Assert.That(items[0].Data, Is.EqualTo("3"));
        Assert.That(items[1].Data, Is.EqualTo("4"));
    }

    [Test]
    public async Task GetLastEventIdReturnsLastSeen()
    {
        AgentEventStreamRegistry registry = NewReplayRegistry();
        AgentEventStream stream = await registry.GetOrCreateAsync("r3");

        Assert.That(await stream.GetLastEventIdAsync(), Is.Null);

        await stream.EmitAsync(new SseItem<string>("7") { EventId = "7" });
        await stream.EmitAsync(new SseItem<string>("9") { EventId = "9" });

        Assert.That(await stream.GetLastEventIdAsync(), Is.EqualTo("9"));
    }

    [Test]
    public async Task LiveBackingIgnoresAfterAndHasNoEventId()
    {
        var options = new AgentEventStreamOptions();
        options.UseInMemoryLive();
        var registry = new InMemoryEventStreamRegistry(options);
        AgentEventStream stream = await registry.GetOrCreateAsync("r4");

        Assert.That(await stream.GetLastEventIdAsync(), Is.Null);
    }
}
