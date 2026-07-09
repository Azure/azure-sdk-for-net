// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.AgentServer.Core.Tasks.Engine;

namespace Azure.AI.AgentServer.Core.Tasks;

/// <summary>
/// Controls how a failed task handler is retried. Mirrors the Python
/// <c>RetryPolicy</c> field-for-field and is configured per task only.
/// </summary>
// AZC0034: the name 'RetryPolicy' is intentional for cross-language (Python) parity;
// this is a developer-facing options record, not an Azure.Core pipeline policy.
#pragma warning disable AZC0034
public sealed class RetryPolicy
#pragma warning restore AZC0034
{
    private readonly TimeSpan _initialDelay = TimeSpan.FromSeconds(1);
    private readonly double _backoffCoefficient = 2.0;
    private readonly TimeSpan _maxDelay = TimeSpan.FromSeconds(60);
    private readonly int _maxAttempts = 3;

    /// <summary>The delay before the first retry. Defaults to 1 second. Must be &gt;= <see cref="TimeSpan.Zero"/>.</summary>
    public TimeSpan InitialDelay
    {
        get => _initialDelay;
        init
        {
            if (value < TimeSpan.Zero)
            {
                throw new ArgumentOutOfRangeException(nameof(value), value, "InitialDelay must not be negative.");
            }

            _initialDelay = value;
        }
    }

    /// <summary>The multiplier applied to the delay after each attempt. Must be &gt;= 1.0. Defaults to 2.0.</summary>
    public double BackoffCoefficient
    {
        get => _backoffCoefficient;
        init
        {
            if (value < 1.0 || double.IsNaN(value))
            {
                throw new ArgumentOutOfRangeException(nameof(value), value, "BackoffCoefficient must be >= 1.0.");
            }

            _backoffCoefficient = value;
        }
    }

    /// <summary>The maximum delay between attempts. Defaults to 60 seconds. Must be between <see cref="TimeSpan.Zero"/> and the 1-hour hard cap; a larger value throws <see cref="ArgumentOutOfRangeException"/>.</summary>
    public TimeSpan MaxDelay
    {
        get => _maxDelay;
        init
        {
            if (value < TimeSpan.Zero)
            {
                throw new ArgumentOutOfRangeException(nameof(value), value, "MaxDelay must not be negative.");
            }

            if (value > TaskEngineConstants.MaxRetryDelay)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(value), value, $"MaxDelay must not exceed the {TaskEngineConstants.MaxRetryDelay.TotalHours}-hour hard cap.");
            }

            _maxDelay = value;
        }
    }

    /// <summary>The maximum number of attempts, including the first try. Defaults to 3. Must be between 1 and the hard cap of 10; a larger value throws <see cref="ArgumentOutOfRangeException"/>.</summary>
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

    /// <summary>Whether to apply ±25% jitter to each delay. Defaults to <see langword="true"/>.</summary>
    public bool Jitter { get; init; } = true;

    /// <summary>An optional predicate deciding whether a given exception is retryable; <see langword="null"/> retries all.</summary>
    public Func<Exception, bool>? RetryOn { get; init; }

    /// <summary>Creates an exponential-backoff policy.</summary>
    /// <param name="maxAttempts">The maximum number of attempts (including the first).</param>
    /// <param name="initialDelay">The initial delay; defaults to 1 second.</param>
    /// <param name="backoffCoefficient">The backoff multiplier; defaults to 2.0.</param>
    /// <param name="maxDelay">The maximum delay; defaults to 60 seconds.</param>
    /// <param name="jitter">Whether to apply jitter; defaults to <see langword="true"/>.</param>
    /// <returns>A configured <see cref="RetryPolicy"/>.</returns>
    public static RetryPolicy ExponentialBackoff(
        int maxAttempts = 3,
        TimeSpan? initialDelay = null,
        double backoffCoefficient = 2.0,
        TimeSpan? maxDelay = null,
        bool jitter = true)
        => new()
        {
            MaxAttempts = maxAttempts,
            InitialDelay = initialDelay ?? TimeSpan.FromSeconds(1),
            BackoffCoefficient = backoffCoefficient,
            MaxDelay = maxDelay ?? TimeSpan.FromSeconds(60),
            Jitter = jitter,
        };

    /// <summary>Creates a fixed-delay policy (no backoff growth).</summary>
    /// <param name="maxAttempts">The maximum number of attempts (including the first).</param>
    /// <param name="delay">The constant delay between attempts; defaults to 5 seconds.</param>
    /// <param name="jitter">Whether to apply jitter; defaults to <see langword="false"/> so the delay stays fixed.</param>
    /// <returns>A configured <see cref="RetryPolicy"/>.</returns>
    public static RetryPolicy FixedDelay(
        int maxAttempts = 3,
        TimeSpan? delay = null,
        bool jitter = false)
    {
        TimeSpan d = delay ?? TimeSpan.FromSeconds(5);
        return new RetryPolicy
        {
            MaxAttempts = maxAttempts,
            InitialDelay = d,
            BackoffCoefficient = 1.0,
            MaxDelay = d,
            Jitter = jitter,
        };
    }

    /// <summary>Creates a linear-backoff policy (delay grows by <paramref name="increment"/> each attempt).</summary>
    /// <param name="maxAttempts">The maximum number of attempts (including the first).</param>
    /// <param name="initialDelay">The initial delay; defaults to 1 second.</param>
    /// <param name="increment">The per-attempt increment; defaults to the initial delay.</param>
    /// <param name="maxDelay">The maximum delay; defaults to 60 seconds.</param>
    /// <param name="jitter">Whether to apply jitter; defaults to <see langword="false"/>.</param>
    /// <returns>A configured <see cref="RetryPolicy"/>.</returns>
    public static RetryPolicy LinearBackoff(
        int maxAttempts = 5,
        TimeSpan? initialDelay = null,
        TimeSpan? increment = null,
        TimeSpan? maxDelay = null,
        bool jitter = false)
    {
        TimeSpan init = initialDelay ?? TimeSpan.FromSeconds(1);
        return new RetryPolicy
        {
            MaxAttempts = maxAttempts,
            InitialDelay = init,
            // Linear growth is modeled by callers via the engine; coefficient 1.0 keeps
            // the base delay constant and the engine adds the increment per attempt.
            BackoffCoefficient = 1.0,
            MaxDelay = maxDelay ?? TimeSpan.FromSeconds(60),
            Jitter = jitter,
            LinearIncrement = increment ?? init,
        };
    }

    /// <summary>Creates a policy that performs no retries (a single attempt).</summary>
    /// <returns>A configured <see cref="RetryPolicy"/> with <see cref="MaxAttempts"/> = 1.</returns>
    public static RetryPolicy NoRetry()
        => new() { MaxAttempts = 1, Jitter = false };

    /// <summary>The per-attempt linear increment used by <see cref="LinearBackoff"/>; <see langword="null"/> for non-linear policies.</summary>
    internal TimeSpan? LinearIncrement { get; init; }

    /// <summary>
    /// Validates cross-field invariants that individual <c>init</c> setters cannot see in
    /// isolation. Called when the policy is attached to a task registration.
    /// Mirrors the Python <c>RetryPolicy.__init__</c> check that <c>max_delay &gt;= initial_delay</c>.
    /// </summary>
    /// <exception cref="ArgumentException"><see cref="MaxDelay"/> is smaller than <see cref="InitialDelay"/>.</exception>
    internal void Validate()
    {
        if (_maxDelay < _initialDelay)
        {
            throw new ArgumentException(
                $"RetryPolicy.MaxDelay ({_maxDelay}) must be >= RetryPolicy.InitialDelay ({_initialDelay}).");
        }
    }
}
