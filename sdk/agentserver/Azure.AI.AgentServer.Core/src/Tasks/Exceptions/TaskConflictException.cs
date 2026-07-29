// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.AgentServer.Core.Tasks;

/// <summary>
/// Thrown when an operation conflicts with the current state of a task — for
/// example, attempting to run a task whose lease is held elsewhere, or mutating
/// a task that has reached a terminal state.
/// </summary>
public sealed class TaskConflictException : TaskException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TaskConflictException"/> class.
    /// </summary>
    /// <param name="currentStatus">The task status reported by the store at the time of the conflict.</param>
    /// <param name="message">An optional description of the conflict.</param>
    /// <param name="innerException">An optional underlying cause.</param>
    public TaskConflictException(TaskStatus currentStatus, string? message = null, Exception? innerException = null)
        : base(message ?? $"The task operation conflicts with the current task status '{currentStatus}'.", innerException)
    {
        CurrentStatus = currentStatus;
    }

    /// <summary>The status the task store reported when the conflict was detected.</summary>
    public TaskStatus CurrentStatus { get; }
}
