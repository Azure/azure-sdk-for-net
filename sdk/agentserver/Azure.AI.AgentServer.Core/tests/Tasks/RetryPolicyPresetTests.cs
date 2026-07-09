// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.AgentServer.Core.Tasks;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks;

/// <summary>
/// Asserts the <see cref="RetryPolicy"/> preset defaults match the Python reference
/// field-for-field, so a developer using a zero-argument preset gets identical retry
/// cadence across languages.
/// </summary>
[TestFixture]
public sealed class RetryPolicyPresetTests
{
    [Test]
    public void FixedDelayDefaultsMatchPython()
    {
        // Python RetryPolicy.fixed_delay: delay=5s, jitter=False, max_attempts=3.
        RetryPolicy policy = RetryPolicy.FixedDelay();
        Assert.That(policy.InitialDelay, Is.EqualTo(TimeSpan.FromSeconds(5)));
        Assert.That(policy.MaxDelay, Is.EqualTo(TimeSpan.FromSeconds(5)));
        Assert.That(policy.MaxAttempts, Is.EqualTo(3));
        Assert.That(policy.BackoffCoefficient, Is.EqualTo(1.0));
        Assert.That(policy.Jitter, Is.False, "a 'fixed' delay must not add jitter");
    }

    [Test]
    public void LinearBackoffDefaultsMatchPython()
    {
        // Python RetryPolicy.linear_backoff: max_attempts=5, jitter=False, initial_delay=1s.
        RetryPolicy policy = RetryPolicy.LinearBackoff();
        Assert.That(policy.MaxAttempts, Is.EqualTo(5));
        Assert.That(policy.Jitter, Is.False);
        Assert.That(policy.InitialDelay, Is.EqualTo(TimeSpan.FromSeconds(1)));
        Assert.That(policy.BackoffCoefficient, Is.EqualTo(1.0));
    }

    [Test]
    public void ExponentialBackoffDefaultsMatchPython()
    {
        // Python RetryPolicy.exponential_backoff: max_attempts=3, initial_delay=1s,
        // backoff_coefficient=2.0, max_delay=60s, jitter=True.
        RetryPolicy policy = RetryPolicy.ExponentialBackoff();
        Assert.That(policy.MaxAttempts, Is.EqualTo(3));
        Assert.That(policy.InitialDelay, Is.EqualTo(TimeSpan.FromSeconds(1)));
        Assert.That(policy.BackoffCoefficient, Is.EqualTo(2.0));
        Assert.That(policy.MaxDelay, Is.EqualTo(TimeSpan.FromSeconds(60)));
        Assert.That(policy.Jitter, Is.True);
    }
}
