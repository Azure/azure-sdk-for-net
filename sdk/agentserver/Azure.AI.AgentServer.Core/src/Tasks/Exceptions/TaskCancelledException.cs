// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.AgentServer.Core.Tasks;

/// <summary>
/// Thrown when a task is cancelled. This deliberately does <b>not</b> derive
/// from <see cref="OperationCanceledException"/> so that task cancellation is
/// never silently swallowed by generic cancellation handling and is always
/// surfaced through the <see cref="TaskException"/> hierarchy.
/// </summary>
public sealed class TaskCancelledException : TaskException
{
    /// <summary>Initializes a new instance of the <see cref="TaskCancelledException"/> class.</summary>
    public TaskCancelledException()
        : base("The task was cancelled.")
    {
    }

    /// <summary>Initializes a new instance of the <see cref="TaskCancelledException"/> class with a message.</summary>
    /// <param name="message">A description of the cancellation.</param>
    public TaskCancelledException(string message)
        : base(message)
    {
    }
}
