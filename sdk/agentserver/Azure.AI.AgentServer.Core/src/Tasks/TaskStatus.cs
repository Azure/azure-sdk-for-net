// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Core.Tasks;

/// <summary>
/// The lifecycle status of a resilient task as reported by the task store.
/// </summary>
/// <remarks>
/// Mirrors the cross-language wire protocol status values. The wire form uses
/// lower-case snake-case strings (for example <c>in_progress</c>); the
/// serialization layer normalizes the legacy alias <c>done</c> to
/// <see cref="Completed"/>.
/// </remarks>
public enum TaskStatus
{
    /// <summary>The task record exists but execution has not started.</summary>
    Pending,

    /// <summary>The task is currently leased and executing.</summary>
    InProgress,

    /// <summary>
    /// A multi-turn task is parked between turns, awaiting the next input.
    /// </summary>
    Suspended,

    /// <summary>The task has reached a terminal state and is immutable.</summary>
    Completed,
}
