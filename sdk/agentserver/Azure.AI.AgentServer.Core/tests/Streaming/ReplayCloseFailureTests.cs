// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Net.ServerSentEvents;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Streaming.Backings;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Streaming;

[TestFixture]
public class ReplayCloseFailureTests
{
    [Test]
    public async Task FailedPersistDoesNotPublishClosedOrSubscriberEof()
    {
        var stream = new FailingCloseStream(TimeSpan.FromMinutes(5));
        using var stop = new CancellationTokenSource();
        await using var reader = stream.Subscribe(cancellationToken: stop.Token).GetAsyncEnumerator();
        Task<bool> next = reader.MoveNextAsync().AsTask();
        try
        {
            Assert.ThrowsAsync<IOException>(async () => await stream.CloseAsync());
            Assert.That(stream.Closed, Is.False);
            Assert.That(next.IsCompleted, Is.False);
            await stream.CloseAsync();
            Assert.That(await next.WaitAsync(TimeSpan.FromSeconds(3)), Is.False);
            Assert.That(stream.Closed, Is.True);
            Assert.That(stream.CloseWrites, Is.EqualTo(2));
        }
        finally
        {
            stop.Cancel();
            try
            { await next; }
            catch (OperationCanceledException) { }
        }
    }

    [Test]
    public async Task RetryPersistsCloseBeforeZeroTtlDeletion()
    {
        var stream = new FailingCloseStream(TimeSpan.Zero);
        Assert.ThrowsAsync<IOException>(async () => await stream.CloseAsync());
        Assert.That(stream.DeleteWrites, Is.Zero);
        await stream.CloseAsync();
        Assert.That(stream.CloseWrites, Is.EqualTo(2));
        Assert.That(stream.DeleteWrites, Is.EqualTo(1));
    }

    [Test]
    public async Task RetryIsIdempotentAfterSuccessfulClose()
    {
        var stream = new FailingCloseStream(TimeSpan.FromMinutes(5));
        Assert.ThrowsAsync<IOException>(async () => await stream.CloseAsync());
        await stream.CloseAsync();
        await Task.WhenAll(Task.Run(async () => await stream.CloseAsync()), Task.Run(async () => await stream.CloseAsync()));
        Assert.That(stream.CloseWrites, Is.EqualTo(2));
        Assert.That(stream.Closed, Is.True);
    }

    private sealed class FailingCloseStream(TimeSpan ttl) : ReplayEventStream("failure", ttl, () => { })
    {
        public int CloseWrites { get; private set; }
        public int DeleteWrites { get; private set; }
        public bool Closed => IsClosedSnapshot;

        protected override void PersistClose()
        {
            if (++CloseWrites == 1)
            { throw new IOException("Injected persistence failure."); }
        }

        protected override void PersistDelete()
        {
            Assert.That(CloseWrites, Is.EqualTo(2), "TTL cannot destroy a stream whose close marker was never persisted.");
            DeleteWrites++;
        }
    }
}
