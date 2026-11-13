// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.AgentServer.Core.Tasks.Engine;
using Azure.Core;

namespace Azure.AI.AgentServer.Core.Tasks;

/// <summary>
/// Controls how a failed task handler is retried: the maximum number of attempts, the delay
/// between attempts, and an optional predicate selecting which exceptions are retryable. The delay
/// is expressed as an <see cref="Azure.Core.DelayStrategy"/> so fixed, exponential, jittered, and
/// custom-derived backoff all use one delay model instead of a second bespoke one.
/// </summary>
public sealed class TaskRetryPolicy
{
    private readonly int _maxAttempts = 3;

    /// <summary>
    /// The maximum number of attempts, including the first. Defaults to 3. Must be between 1 and the
    /// hard cap of 10; a larger or non-positive value throws <see cref="ArgumentOutOfRangeException"/>.
    /// Set to 1 to disable retries.
    /// </summary>
    public int MaxAttempts
    {
        get => _maxAttempts;
        init
        {
            if (value < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(value), value, "MaxAttempts must be >= 1.");
            }

            if (value > TaskEngineConstants.MaxRetryAttempts)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(value), value, $"MaxAttempts must not exceed the hard cap of {TaskEngineConstants.MaxRetryAttempts}.");
            }

            _maxAttempts = value;
        }
    }

    /// <summary>
    /// The delay strategy applied between attempts. Defaults to an exponential strategy. Use
    /// <see cref="DelayStrategy.CreateExponentialDelayStrategy"/>,
    /// <see cref="DelayStrategy.CreateFixedDelayStrategy"/>, or a custom derived strategy for linear
    /// or service-specific behavior. The strategy owns its own jitter and maximum-delay handling.
    /// </summary>
    public DelayStrategy Delay { get; init; } = DelayStrategy.CreateExponentialDelayStrategy();

    /// <summary>An optional predicate deciding whether a given exception is retryable; <see langword="null"/> retries all.</summary>
    public Func<Exception, bool>? RetryOn { get; init; }

    /// <summary>
    /// Validates cross-field invariants that individual <c>init</c> setters cannot see in isolation.
    /// Called when the policy is attached to a task registration. The delay model no longer carries
    /// cross-field invariants (the <see cref="DelayStrategy"/> validates its own bounds), so this is
    /// currently a no-op retained as a stable registration hook.
    /// </summary>
    internal void Validate()
    {
    }
}
