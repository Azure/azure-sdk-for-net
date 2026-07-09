// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.AgentServer.Core.Tasks.Serialization;

namespace Azure.AI.AgentServer.Core.Tasks.Engine;

/// <summary>
/// Implements the intent-based 412 (precondition-failed) resolution policy from
/// SOT §25.3. On a precondition failure the serializer re-reads the latest record
/// and asks the resolver what to do next given the write intent and the freshly
/// observed state.
/// </summary>
internal static class EtagConflictResolver
{
    /// <summary>Default maximum number of resolution attempts.</summary>
    public const int DefaultMaxAttempts = 5;

    /// <summary>The decision returned by the resolver after a precondition failure.</summary>
    internal enum Decision
    {
        /// <summary>Re-read, recompute, and re-apply the write.</summary>
        Retry,

        /// <summary>Stop trying — the race was lost; abandon the write quietly.</summary>
        Abandon,

        /// <summary>Stop trying and surface the conflict to the caller.</summary>
        Surface,
    }

    /// <summary>
    /// Decides how to react to a precondition failure for a given intent. <paramref name="current"/>
    /// is the freshly re-read record (or <c>null</c> if the task disappeared).
    /// </summary>
    /// <param name="intent">The semantic write intent.</param>
    /// <param name="current">The re-read record, or <c>null</c> if not found.</param>
    /// <param name="entry">The per-task bookkeeping entry (holds the cached expiry count).</param>
    /// <param name="attempt">The 1-based attempt number that just failed.</param>
    /// <param name="maxAttempts">The maximum number of attempts allowed.</param>
    /// <returns>The resolution decision.</returns>
    public static Decision Resolve(WriteIntent intent, TaskRecord? current, ActiveTaskEntry entry, int attempt, int maxAttempts)
    {
        // Reclaim treats a 412 as the definitive race-loss signal — never retry.
        if (intent == WriteIntent.Reclaim)
        {
            return Decision.Abandon;
        }

        if (current is null)
        {
            // The task vanished underneath us: a terminal write should abandon; others surface.
            return intent is WriteIntent.Suspend or WriteIntent.Complete or WriteIntent.Fail
                ? Decision.Abandon
                : Decision.Surface;
        }

        // Terminal writes and lease heartbeats abandon if the lease is no longer ours or the task is
        // already terminal; otherwise they retry to re-apply on the latest etag.
        // (A heartbeat that lost its lease evicts rather than fighting for it — §25.3.)
        if (intent is WriteIntent.Suspend or WriteIntent.Complete or WriteIntent.Fail or WriteIntent.LeaseHeartbeat)
        {
            // Takeover fencing: if we have held the lease and the re-read record now carries a
            // different lease instance id (a restarted/other process reacquired) or a newer
            // generation, the lease is no longer ours and the stale holder must abandon rather than
            // overwrite the new holder's lifecycle (§25.3).
            //
            // We intentionally do NOT consult lease.expiry_count here, matching Python parity
            // (_manager._terminal_412_decide). Per C-LSE-3 every real expiry-driven handoff bumps
            // the lease instance id, so instance-id comparison alone is sufficient. An expiry_count
            // leg would spuriously abandon any reclaimed task whose expiry_count is already >= 1 on
            // a legitimate retryable 412 (the cached count starts at 0 until a lease PATCH seeds it).
            string? serverInstance = current.Lease?.InstanceId;
            long serverGeneration = current.Lease?.Generation ?? 0;
            bool identityTakenOver =
                !string.IsNullOrEmpty(entry.HeldInstanceId)
                && (!string.Equals(serverInstance, entry.HeldInstanceId, StringComparison.Ordinal)
                    || serverGeneration > entry.HeldGeneration);

            bool alreadyTerminal = current.Status == TaskWireKeys.StatusCompleted;
            if (identityTakenOver || alreadyTerminal)
            {
                return Decision.Abandon;
            }
        }

        return attempt < maxAttempts ? Decision.Retry : Decision.Surface;
    }
}
