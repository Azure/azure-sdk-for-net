// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Invocations.Voice;
using Azure.AI.AgentServer.Invocations.Voice.Internal;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests.Voice;

public class TrackedIdentityBudgetTests
{
    [Test]
    public async Task ConcurrentReservationsAndReleasesPreserveExactCount()
    {
        var budget = new TrackedIdentityBudget(1_000_000);
        var workers = Enumerable.Range(0, 16)
            .Select(_ => Task.Run(() =>
            {
                for (var index = 0; index < 10_000; index++)
                {
                    budget.Reserve(7);
                    budget.Release(3);
                }
            }));

        await Task.WhenAll(workers);

        Assert.That(budget.Bytes, Is.EqualTo(16L * 10_000 * 4));
    }

    [Test]
    public void ConcurrentOverflowNeverExceedsMaximum()
    {
        var budget = new TrackedIdentityBudget(64);
        var accepted = 0;
        var rejected = 0;

        Parallel.For(0, 128, _ =>
        {
            try
            {
                budget.Reserve(1);
                Interlocked.Increment(ref accepted);
            }
            catch (VoiceBridgeProtocolException)
            {
                Interlocked.Increment(ref rejected);
            }
        });

        Assert.Multiple(() =>
        {
            Assert.That(accepted, Is.EqualTo(64));
            Assert.That(rejected, Is.EqualTo(64));
            Assert.That(budget.Bytes, Is.EqualTo(64));
        });
    }
}
