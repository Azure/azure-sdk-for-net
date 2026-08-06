// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Core.Tasks;

/// <summary>
/// Identifies the category of a <see cref="ResilientTaskException"/>. The set is
/// intentionally extensible: new protocol reasons can be added here without introducing
/// a new exception type. Argument validation and cancellation are represented by the
/// standard <see cref="System.ArgumentException"/> and
/// <see cref="System.OperationCanceledException"/> instead of a code.
/// </summary>
public enum ResilientTaskErrorCode
{
    /// <summary>The handler threw an exception that was not retried (or retries were disabled).</summary>
    HandlerError,

    /// <summary>The handler exhausted its configured retry budget.</summary>
    ExhaustedRetries,

    /// <summary>
    /// An operation conflicted with the task's current state — for example, starting a task whose
    /// turn is already in progress elsewhere, or mutating a task that has reached a terminal state.
    /// </summary>
    Conflict,

    /// <summary>
    /// A run was submitted with an <c>IfLastInputId</c> precondition that did not match the task's
    /// actual last input id (an optimistic-concurrency guard for multi-turn chains).
    /// </summary>
    PreconditionFailed,

    /// <summary>A steerable multi-turn task already holds the maximum number of pending steering inputs.</summary>
    QueueFull,
}
