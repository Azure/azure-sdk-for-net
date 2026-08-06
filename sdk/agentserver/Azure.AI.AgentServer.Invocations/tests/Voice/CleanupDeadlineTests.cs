// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Invocations.Internal;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests.Voice;

public class CleanupDeadlineTests
{
    [Test]
    public void DeadlineUsesOneNonRestartingBudget()
    {
        var timeProvider = new ManualTimeProvider();
        var deadline = new CleanupDeadline(TimeSpan.FromSeconds(5), timeProvider);

        deadline.Start();
        timeProvider.Advance(TimeSpan.FromSeconds(4));
        Assert.That(deadline.Remaining, Is.EqualTo(TimeSpan.FromSeconds(1)));

        deadline.Start();
        timeProvider.Advance(TimeSpan.FromSeconds(1));
        Assert.That(deadline.Remaining, Is.EqualTo(TimeSpan.Zero));
    }

    [Test]
    public void RemainingBeforeStartIsFullBudget()
    {
        var deadline = new CleanupDeadline(TimeSpan.FromSeconds(5), new ManualTimeProvider());

        Assert.That(deadline.Remaining, Is.EqualTo(TimeSpan.FromSeconds(5)));
    }

    [Test]
    public void CloseEventCancellationUsesExhaustedSharedDeadline()
    {
        var timeProvider = new ManualTimeProvider();
        var deadline = new CleanupDeadline(TimeSpan.FromSeconds(5), timeProvider);
        deadline.Start();
        timeProvider.Advance(TimeSpan.FromSeconds(5));

        using var cancellation = WebSocketEndpointHandler.CreateCloseEventCancellation(deadline);

        Assert.That(cancellation.IsCancellationRequested, Is.True);
    }

    private sealed class ManualTimeProvider : TimeProvider
    {
        private long _timestamp;

        public override long TimestampFrequency => TimeSpan.TicksPerSecond;

        public override long GetTimestamp() => _timestamp;

        public void Advance(TimeSpan duration) => _timestamp += duration.Ticks;
    }
}
