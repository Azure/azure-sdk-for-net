// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.AgentServer.Core.Tasks.Engine;

/// <summary>
/// Internal sentinel signaling that a serialized write was abandoned (rather than
/// retried) because the race was lost — e.g. the lease was expired-and-taken-over,
/// or the task is already terminal (SOT §25.3). Callers translate this into the
/// appropriate quiet no-op or eviction signal.
/// </summary>
internal sealed class WriteAbandonedException : Exception
{
    /// <summary>Initializes a new instance of the <see cref="WriteAbandonedException"/> class.</summary>
    /// <param name="taskId">The task id whose write was abandoned.</param>
    /// <param name="intent">The intent that was abandoned.</param>
    public WriteAbandonedException(string taskId, WriteIntent intent)
        : base($"Write abandoned for task '{taskId}' (intent: {intent}).")
    {
        TaskId = taskId;
        Intent = intent;
    }

    /// <summary>The task id whose write was abandoned.</summary>
    public string TaskId { get; }

    /// <summary>The intent that was abandoned.</summary>
    public WriteIntent Intent { get; }
}
