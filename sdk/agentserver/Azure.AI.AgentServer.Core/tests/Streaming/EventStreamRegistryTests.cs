// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net.ServerSentEvents;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Streaming;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Streaming;

[TestFixture]
public sealed class EventStreamRegistryTests
{
    [Test]
    public async Task OptionsConfiguredAfterRegistrationDetermineBacking()
    {
        var services = new ServiceCollection();
        services.AddAgentEventStreamsDefault(
            "test-protocol",
            serviceProvider =>
            {
                var options = new AgentEventStreamOptions();
                if (serviceProvider.GetRequiredService<IOptions<LateStreamOptions>>().Value.Replay)
                {
                    options.UseInMemoryReplay();
                }

                return options;
            });
        services.Configure<LateStreamOptions>(options => options.Replay = true);

        await using ServiceProvider provider = services.BuildServiceProvider();
        AgentEventStreamRegistry registry =
            provider.GetRequiredService<AgentEventStreamRegistry>();
        AgentEventStream stream = await registry.GetOrCreateAsync("late-options");
        await stream.EmitAsync(
            new SseItem<string>("retained") { EventId = "1" },
            close: true);

        var retained = new List<SseItem<string>>();
        await foreach (SseItem<string> item in stream.Subscribe())
        {
            retained.Add(item);
        }

        Assert.That(retained, Has.Count.EqualTo(1));
        Assert.That(retained[0].Data, Is.EqualTo("retained"));
    }

    private sealed class LateStreamOptions
    {
        public bool Replay { get; set; }
    }

    [Test]
    public async Task DeleteUnknownStreamIdIsNoOp()
    {
        // rule 35 (Python streams registry): delete of an id that was never created is a no-op,
        // never raises.
        var registry = new InMemoryEventStreamRegistry(new AgentEventStreamOptions());

        Assert.DoesNotThrowAsync(async () => await registry.DeleteAsync("never-existed"));

        // The id remains absent (a plain lookup still reports not-found).
        Assert.ThrowsAsync<AgentEventStreamNotFoundException>(async () => await registry.GetAsync("never-existed"));

        // A subsequent get-or-create still yields a fresh, live stream.
        AgentEventStream fresh = await registry.GetOrCreateAsync("never-existed");
        Assert.That(fresh, Is.Not.Null);
    }

    [Test]
    public async Task DeleteIsIdempotentAcrossRepeatedCalls()
    {
        // rule 35: deleting an already-deleted id is a no-op.
        var registry = new InMemoryEventStreamRegistry(new AgentEventStreamOptions());

        AgentEventStream stream = await registry.GetOrCreateAsync("s1");
        await stream.EmitAsync(new SseItem<string>("1"));

        await registry.DeleteAsync("s1");
        Assert.DoesNotThrowAsync(async () => await registry.DeleteAsync("s1"));

        // After deletion, a plain get raises not-found (tombstone semantics)...
        Assert.ThrowsAsync<AgentEventStreamNotFoundException>(async () => await registry.GetAsync("s1"));

        // ...but get-or-create recreates a fresh stream under the same id (tombstone cleared).
        AgentEventStream recreated = await registry.GetOrCreateAsync("s1");
        Assert.That(recreated, Is.Not.SameAs(stream));
    }

    [Test]
    public void DeleteWithEmptyIdThrowsArgumentException()
    {
        var registry = new InMemoryEventStreamRegistry(new AgentEventStreamOptions());
        Assert.ThrowsAsync<ArgumentException>(async () => await registry.DeleteAsync(string.Empty));
    }
}
