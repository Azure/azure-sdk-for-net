// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Core.Tasks.Engine;

/// <summary>Framework-internal task engine constants (not developer-configurable; Python parity).</summary>
internal static class TaskEngineConstants
{
    /// <summary>The lease duration acquired for an executing task, in seconds.</summary>
    public const int LeaseDurationSeconds = 60;

    /// <summary>
    /// The lease renewal (heartbeat) cadence, in seconds: half the lease duration (Python parity:
    /// <c>max(1, lease_duration_seconds // 2)</c>).
    /// </summary>
    public static int LeaseRenewSeconds => System.Math.Max(1, LeaseDurationSeconds / 2);

    /// <summary>The background recovery-scan cadence, in seconds (FR-022 durability loop).</summary>
    public const int RecoveryScanIntervalSeconds = 300;

    /// <summary>
    /// The maximum time graceful shutdown waits for in-flight turns to checkpoint (call
    /// <c>ExitForRecovery</c> / wind down) before force-expiring their leases so a restarted
    /// process reclaims immediately instead of waiting the lease TTL (Python parity:
    /// <c>shutdown_grace_seconds = 25.0</c>).
    /// </summary>
    public static readonly System.TimeSpan ShutdownGrace = System.TimeSpan.FromSeconds(25);

    /// <summary>The default agent name when not running in a hosted Foundry environment (Python parity: "unknown-agent").</summary>
    public const string DefaultAgentName = "unknown-agent";

    /// <summary>The default session id when not running in a hosted Foundry environment (Python parity: "local").</summary>
    public const string DefaultSessionId = "local";

    /// <summary>Soft cap on the terminated one-shot set before TTL eviction runs.</summary>
    public const int TerminatedOneShotMaxEntries = 4096;

    /// <summary>Age (seconds) after which a terminated one-shot entry may be evicted.</summary>
    public const int TerminatedOneShotTtlSeconds = 300;

    /// <summary>
    /// The per-turn execution timeout applied when a task does not configure one. Also the hard
    /// ceiling: a developer-supplied <see cref="TaskRegistrationOptions.Timeout"/> above this value
    /// is rejected at registration (1 day).
    /// </summary>
    public static readonly System.TimeSpan MaxTaskTimeout = System.TimeSpan.FromDays(1);

    /// <summary>
    /// Resolves the effective per-turn timeout for execution. An unset (<see langword="null"/>)
    /// timeout falls back to the 1-day default; a supplied value is used as-is — including an
    /// explicit <see cref="System.TimeSpan.Zero"/>, which means "time out immediately" (Python
    /// parity: only <c>None</c> defaults). Values above <see cref="MaxTaskTimeout"/> are rejected
    /// at registration; the cap here is defense-in-depth.
    /// </summary>
    public static System.TimeSpan ResolveTaskTimeout(System.TimeSpan? configured)
    {
        if (configured is not { } t)
        {
            return MaxTaskTimeout;
        }

        return t > MaxTaskTimeout ? MaxTaskTimeout : t;
    }

    /// <summary>
    /// The hard ceiling on retry attempts (including the first try). A developer-configured
    /// <see cref="RetryPolicy.MaxAttempts"/> above this value is rejected at construction so a
    /// misconfiguration cannot cause a task turn to retry unboundedly (10 attempts).
    /// </summary>
    public const int MaxRetryAttempts = 10;

    /// <summary>
    /// The hard ceiling on the delay between retry attempts. A developer-configured
    /// <see cref="RetryPolicy.MaxDelay"/> above this value is rejected at construction so backoff
    /// growth cannot produce an arbitrarily long wait (1 hour).
    /// </summary>
    public static readonly System.TimeSpan MaxRetryDelay = System.TimeSpan.FromHours(1);
}
