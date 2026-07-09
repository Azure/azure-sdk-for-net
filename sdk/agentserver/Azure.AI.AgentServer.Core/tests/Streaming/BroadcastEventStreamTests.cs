// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Streaming;
using Azure.AI.AgentServer.Core.Streaming.Backings;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Streaming;

[TestFixture]
public sealed class BroadcastEventStreamTests
{
    private static EventStreamRegistry NewLiveRegistry()
    {
        var options = new EventStreamOptions();
        options.UseInMemoryLive();
        return new EventStreamRegistry(options);
    }

    [Test]
    public async Task GetOrCreateIsIdempotentSameInstance()
    {
        EventStreamRegistry registry = NewLiveRegistry();
        IEventStream a = await registry.GetOrCreateAsync("s1");
        IEventStream b = await registry.GetOrCreateAsync("s1");
        Assert.That(a, Is.SameAs(b));
    }

    [Test]
    public async Task OrderedLiveDeliveryThenCleanTerminationOnClose()
    {
        EventStreamRegistry registry = NewLiveRegistry();
        IEventStream stream = await registry.GetOrCreateAsync("s2");

        var received = new List<object>();
        var subscriberReady = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
        var consumer = Task.Run(async () =>
        {
            IAsyncEnumerator<object> e = stream.Subscribe().GetAsyncEnumerator();
            subscriberReady.TrySetResult(true);
            while (await e.MoveNextAsync())
            {
                received.Add(e.Current);
            }
        });

        await subscriberReady.Task;
        await Task.Delay(50);

        await stream.EmitAsync(1);
        await stream.EmitAsync(2);
        await stream.EmitAsync(3);
        await stream.CloseAsync();

        await consumer;

        Assert.That(received, Is.EqualTo(new object[] { 1, 2, 3 }));
    }

    [Test]
    public async Task EmitAfterCloseRaisesClosed()
    {
        EventStreamRegistry registry = NewLiveRegistry();
        IEventStream stream = await registry.GetOrCreateAsync("s3");
        await stream.CloseAsync();

        Assert.ThrowsAsync<EventStreamClosedException>(async () => await stream.EmitAsync(1));
    }

    [Test]
    public async Task CloseIsIdempotent()
    {
        EventStreamRegistry registry = NewLiveRegistry();
        IEventStream stream = await registry.GetOrCreateAsync("s4");
        await stream.CloseAsync();
        Assert.DoesNotThrowAsync(async () => await stream.CloseAsync());
    }

    [Test]
    public async Task EmitWithCloseDeliversThenCloses()
    {
        EventStreamRegistry registry = NewLiveRegistry();
        IEventStream stream = await registry.GetOrCreateAsync("s5");

        var received = new List<object>();
        var subscriberReady = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
        var consumer = Task.Run(async () =>
        {
            IAsyncEnumerator<object> e = stream.Subscribe().GetAsyncEnumerator();
            subscriberReady.TrySetResult(true);
            while (await e.MoveNextAsync())
            {
                received.Add(e.Current);
            }
        });

        await subscriberReady.Task;
        await Task.Delay(50);

        await stream.EmitAsync("last", close: true);
        await consumer;

        Assert.That(received, Is.EqualTo(new object[] { "last" }));
        Assert.ThrowsAsync<EventStreamClosedException>(async () => await stream.EmitAsync("more"));
    }
}
