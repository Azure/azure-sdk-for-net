// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Streaming;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Streaming;

[TestFixture]
public sealed class EventStreamRegistryTests
{
    [Test]
    public async Task DeleteUnknownStreamIdIsNoOp()
    {
        // rule 35 (Python streams registry): delete of an id that was never created is a no-op,
        // never raises.
        var registry = new EventStreamRegistry(new EventStreamOptions());

        Assert.DoesNotThrowAsync(async () => await registry.DeleteAsync("never-existed"));

        // The id remains absent (a plain lookup still reports not-found).
        Assert.ThrowsAsync<EventStreamNotFoundException>(async () => await registry.GetAsync("never-existed"));

        // A subsequent get-or-create still yields a fresh, live stream.
        IEventStream fresh = await registry.GetOrCreateAsync("never-existed");
        Assert.That(fresh, Is.Not.Null);
    }

    [Test]
    public async Task DeleteIsIdempotentAcrossRepeatedCalls()
    {
        // rule 35: deleting an already-deleted id is a no-op.
        var registry = new EventStreamRegistry(new EventStreamOptions());

        IEventStream stream = await registry.GetOrCreateAsync("s1");
        await stream.EmitAsync(1);

        await registry.DeleteAsync("s1");
        Assert.DoesNotThrowAsync(async () => await registry.DeleteAsync("s1"));

        // After deletion, a plain get raises not-found (tombstone semantics)...
        Assert.ThrowsAsync<EventStreamNotFoundException>(async () => await registry.GetAsync("s1"));

        // ...but get-or-create recreates a fresh stream under the same id (tombstone cleared).
        IEventStream recreated = await registry.GetOrCreateAsync("s1");
        Assert.That(recreated, Is.Not.SameAs(stream));
    }

    [Test]
    public void DeleteWithEmptyIdThrowsArgumentException()
    {
        var registry = new EventStreamRegistry(new EventStreamOptions());
        Assert.ThrowsAsync<ArgumentException>(async () => await registry.DeleteAsync(string.Empty));
    }
}
