// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Net.ServerSentEvents;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Streaming;
using Azure.AI.AgentServer.Core.Streaming.Backings;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Streaming;

[TestFixture]
public sealed class BroadcastEventStreamTests
{
    private static AgentEventStreamRegistry NewLiveRegistry()
    {
        var options = new AgentEventStreamOptions();
        options.UseInMemoryLive();
        return new InMemoryEventStreamRegistry(options);
    }

    [Test]
    public async Task GetOrCreateIsIdempotentSameInstance()
    {
        AgentEventStreamRegistry registry = NewLiveRegistry();
        AgentEventStream a = await registry.GetOrCreateAsync("s1");
        AgentEventStream b = await registry.GetOrCreateAsync("s1");
        Assert.That(a, Is.SameAs(b));
    }

    [Test]
    public async Task OrderedLiveDeliveryThenCleanTerminationOnClose()
    {
        AgentEventStreamRegistry registry = NewLiveRegistry();
        AgentEventStream stream = await registry.GetOrCreateAsync("s2");

        var received = new List<string>();
        var subscriberReady = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
        var consumer = Task.Run(async () =>
        {
            IAsyncEnumerator<SseItem<string>> e = stream.Subscribe().GetAsyncEnumerator();
            subscriberReady.TrySetResult(true);
            while (await e.MoveNextAsync())
            {
                received.Add(e.Current.Data);
            }
        });

        await subscriberReady.Task;
        await Task.Delay(50);

        await stream.EmitAsync(new SseItem<string>("1"));
        await stream.EmitAsync(new SseItem<string>("2"));
        await stream.EmitAsync(new SseItem<string>("3"));
        await stream.CloseAsync();

        await consumer;

        Assert.That(received, Is.EqualTo(new[] { "1", "2", "3" }));
    }

    [Test]
    public async Task EmitAfterCloseRaisesClosed()
    {
        AgentEventStreamRegistry registry = NewLiveRegistry();
        AgentEventStream stream = await registry.GetOrCreateAsync("s3");
        await stream.CloseAsync();

        Assert.ThrowsAsync<AgentEventStreamClosedException>(async () => await stream.EmitAsync(new SseItem<string>("1")));
    }

    [Test]
    public async Task CloseIsIdempotent()
    {
        AgentEventStreamRegistry registry = NewLiveRegistry();
        AgentEventStream stream = await registry.GetOrCreateAsync("s4");
        await stream.CloseAsync();
        Assert.DoesNotThrowAsync(async () => await stream.CloseAsync());
    }

    [Test]
    public async Task EmitWithCloseDeliversThenCloses()
    {
        AgentEventStreamRegistry registry = NewLiveRegistry();
        AgentEventStream stream = await registry.GetOrCreateAsync("s5");

        var received = new List<string>();
        var subscriberReady = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
        var consumer = Task.Run(async () =>
        {
            IAsyncEnumerator<SseItem<string>> e = stream.Subscribe().GetAsyncEnumerator();
            subscriberReady.TrySetResult(true);
            while (await e.MoveNextAsync())
            {
                received.Add(e.Current.Data);
            }
        });

        await subscriberReady.Task;
        await Task.Delay(50);

        await stream.EmitAsync(new SseItem<string>("last"), close: true);
        await consumer;

        Assert.That(received, Is.EqualTo(new[] { "last" }));
        Assert.ThrowsAsync<AgentEventStreamClosedException>(async () => await stream.EmitAsync(new SseItem<string>("more")));
    }
}
