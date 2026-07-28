// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.AgentServer.Core.Tasks;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks;

/// <summary>
/// Pins that a <see cref="TaskRetryPolicy"/> rejects invalid values at construction (fail-fast) rather
/// than silently clamping them: negative delays, sub-1.0 backoff, and values outside the hard caps
/// (1–10 attempts, 0–1 hour delay) all throw.
/// </summary>
[TestFixture]
public sealed class RetryPolicyValidationTests
{
    [Test]
    public void NegativeInitialDelayThrows()
    {
        Assert.Throws<ArgumentOutOfRangeException>(
            () => _ = new TaskRetryPolicy { InitialDelay = TimeSpan.FromSeconds(-1) });
    }

    [Test]
    public void NegativeMaxDelayThrows()
    {
        Assert.Throws<ArgumentOutOfRangeException>(
            () => _ = new TaskRetryPolicy { MaxDelay = TimeSpan.FromSeconds(-1) });
    }

    [Test]
    public void ZeroDelaysAreAllowed()
    {
        // Zero means "retry immediately" — a valid configuration, not an error.
        var policy = new TaskRetryPolicy { InitialDelay = TimeSpan.Zero, MaxDelay = TimeSpan.Zero };
        Assert.That(policy.InitialDelay, Is.EqualTo(TimeSpan.Zero));
        Assert.That(policy.MaxDelay, Is.EqualTo(TimeSpan.Zero));
    }

    [Test]
    public void MaxAttemptsBelowOneThrows()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _ = new TaskRetryPolicy { MaxAttempts = 0 });
        Assert.Throws<ArgumentOutOfRangeException>(() => _ = new TaskRetryPolicy { MaxAttempts = -3 });
    }

    [Test]
    public void BackoffCoefficientBelowOneThrows()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _ = new TaskRetryPolicy { BackoffCoefficient = 0.5 });
        Assert.Throws<ArgumentOutOfRangeException>(() => _ = new TaskRetryPolicy { BackoffCoefficient = double.NaN });
    }

    [Test]
    public void FactoryRejectsNegativeArguments()
    {
        Assert.Throws<ArgumentOutOfRangeException>(
            () => TaskRetryPolicy.FixedDelay(maxAttempts: 3, delay: TimeSpan.FromSeconds(-1)));
        Assert.Throws<ArgumentOutOfRangeException>(
            () => TaskRetryPolicy.ExponentialBackoff(maxAttempts: 0));
    }

    [Test]
    public void MaxAttemptsAboveCapThrows()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _ = new TaskRetryPolicy { MaxAttempts = 11 });
        Assert.Throws<ArgumentOutOfRangeException>(() => _ = new TaskRetryPolicy { MaxAttempts = 1000 });
    }

    [Test]
    public void MaxDelayAboveCapThrows()
    {
        Assert.Throws<ArgumentOutOfRangeException>(
            () => _ = new TaskRetryPolicy { MaxDelay = TimeSpan.FromHours(5) });
    }

    [Test]
    public void ValuesAtExactlyTheCapAreAllowed()
    {
        var policy = new TaskRetryPolicy { MaxAttempts = 10, MaxDelay = TimeSpan.FromHours(1) };
        Assert.That(policy.MaxAttempts, Is.EqualTo(10));
        Assert.That(policy.MaxDelay, Is.EqualTo(TimeSpan.FromHours(1)));
    }

    [Test]
    public void MaxDelayBelowInitialDelayThrowsAtRegistration()
    {
        using var host = TaskTestHost.Create();

        // Individually valid values, but MaxDelay < InitialDelay is invalid as a pair (spec §15;
        // Python RetryPolicy.__init__ raises). The cross-field check fires when the policy is
        // attached to a registration.
        Assert.Throws<ArgumentException>(() =>
            host.Builder.AddTask<string, string>(
                "bad-retry",
                (ctx, ct) => System.Threading.Tasks.Task.FromResult(ctx.Input),
                configure: o => o.Retry = new TaskRetryPolicy
                {
                    InitialDelay = TimeSpan.FromSeconds(30),
                    MaxDelay = TimeSpan.FromSeconds(5),
                }));
    }

    [Test]
    public void MaxDelayEqualToInitialDelayIsAllowedAtRegistration()
    {
        using var host = TaskTestHost.Create();

        Assert.DoesNotThrow(() =>
            host.Builder.AddTask<string, string>(
                "ok-retry",
                (ctx, ct) => System.Threading.Tasks.Task.FromResult(ctx.Input),
                configure: o => o.Retry = new TaskRetryPolicy
                {
                    InitialDelay = TimeSpan.FromSeconds(5),
                    MaxDelay = TimeSpan.FromSeconds(5),
                }));
    }
}
