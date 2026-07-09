// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.AgentServer.Core.Tasks.Engine;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks;

/// <summary>
/// Pins the per-turn timeout resolver: a 1-day default when unset (null) and a 1-day hard ceiling.
/// An explicit zero is preserved as an immediate timeout. The ceiling is enforced by throwing at
/// registration (see <c>ResilientTaskRegistrationTests</c>). Retry hard caps (10 attempts, 1-hour
/// delay) are enforced at <see cref="Azure.AI.AgentServer.Core.Tasks.RetryPolicy"/> construction
/// (see <c>RetryPolicyValidationTests</c>).
/// </summary>
[TestFixture]
public sealed class TaskTimeoutResolutionTests
{
    [Test]
    public void DefaultsToOneDayWhenUnset()
    {
        Assert.That(TaskEngineConstants.MaxTaskTimeout, Is.EqualTo(TimeSpan.FromDays(1)));
        Assert.That(TaskEngineConstants.ResolveTaskTimeout(null), Is.EqualTo(TimeSpan.FromDays(1)));
    }

    [Test]
    public void PreservesExplicitZeroAsImmediateTimeout()
    {
        // Only an unset (null) timeout defaults to 1 day (Python parity); an explicit zero is a
        // valid "time out immediately" budget and is preserved as-is.
        Assert.That(TaskEngineConstants.ResolveTaskTimeout(TimeSpan.Zero), Is.EqualTo(TimeSpan.Zero));
    }

    [Test]
    public void HonorsASmallerConfiguredBudget()
    {
        Assert.That(
            TaskEngineConstants.ResolveTaskTimeout(TimeSpan.FromMinutes(2)),
            Is.EqualTo(TimeSpan.FromMinutes(2)));
    }

    [Test]
    public void AllowsExactlyTheHardCap()
    {
        Assert.That(
            TaskEngineConstants.ResolveTaskTimeout(TimeSpan.FromDays(1)),
            Is.EqualTo(TimeSpan.FromDays(1)));
    }

    [Test]
    public void MaxRetryAttemptsCapIsTen()
    {
        Assert.That(TaskEngineConstants.MaxRetryAttempts, Is.EqualTo(10));
    }

    [Test]
    public void MaxRetryDelayCapIsOneHour()
    {
        Assert.That(TaskEngineConstants.MaxRetryDelay, Is.EqualTo(TimeSpan.FromHours(1)));
    }
}
