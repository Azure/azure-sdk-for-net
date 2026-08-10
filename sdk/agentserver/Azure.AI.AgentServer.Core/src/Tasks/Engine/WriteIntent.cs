// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Core.Tasks.Engine;

/// <summary>
/// The semantic intent of a serialized task write, used by the intent-based
/// 412 resolver to decide how to react to a precondition failure (SOT §25.3).
/// </summary>
internal enum WriteIntent
{
    /// <summary>Last-writer-wins metadata namespace flush.</summary>
    MetadataFlush,

    /// <summary>Append to the steering queue (re-read NEW state, re-apply).</summary>
    SteeringAppend,

    /// <summary>Drain the steering queue (re-read NEW state, re-apply).</summary>
    SteeringDrain,

    /// <summary>Lease heartbeat renewal (re-read; retry or evict).</summary>
    LeaseHeartbeat,

    /// <summary>Suspend the task (re-read + decide abandon-or-retry).</summary>
    Suspend,

    /// <summary>Complete the task (re-read + decide abandon-or-retry).</summary>
    Complete,

    /// <summary>Fail the task (re-read + decide abandon-or-retry).</summary>
    Fail,

    /// <summary>Reclaim an expired lease (abandon on 412 — the 412 is the race-loss signal).</summary>
    Reclaim,

    /// <summary>Generic read-modify-write (re-read, recompute, retry).</summary>
    Generic,
}
