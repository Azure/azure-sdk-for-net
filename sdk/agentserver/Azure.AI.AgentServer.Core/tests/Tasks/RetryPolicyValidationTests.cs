// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.AgentServer.Core.Tasks;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks;

/// <summary>
/// Pins that a <see cref="TaskRetryPolicy"/> rejects an out-of-range attempt count at construction
/// (fail-fast) rather than silently clamping it. The delay bounds are now owned by the composed
/// <see cref="Azure.Core.DelayStrategy"/>.
/// </summary>
[TestFixture]
public sealed class RetryPolicyValidationTests
{
    [Test]
    public void MaxAttemptsBelowOneThrows()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _ = new TaskRetryPolicy { MaxAttempts = 0 });
        Assert.Throws<ArgumentOutOfRangeException>(() => _ = new TaskRetryPolicy { MaxAttempts = -3 });
    }

    [Test]
    public void MaxAttemptsAboveCapThrows()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _ = new TaskRetryPolicy { MaxAttempts = 11 });
        Assert.Throws<ArgumentOutOfRangeException>(() => _ = new TaskRetryPolicy { MaxAttempts = 1000 });
    }

    [Test]
    public void MaxAttemptsAtTheCapIsAllowed()
    {
        var policy = new TaskRetryPolicy { MaxAttempts = 10 };
        Assert.That(policy.MaxAttempts, Is.EqualTo(10));
    }

    [Test]
    public void DelayDefaultsToAStrategy()
    {
        Assert.That(new TaskRetryPolicy().Delay, Is.Not.Null);
    }
}
