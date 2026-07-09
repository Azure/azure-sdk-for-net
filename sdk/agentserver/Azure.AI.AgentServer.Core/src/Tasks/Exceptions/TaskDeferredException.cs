// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Core.Tasks;

/// <summary>
/// Thrown internally when a handler voluntarily yields for recovery (via
/// <c>ExitForRecoveryAsync</c>), parking the task <c>in_progress</c> so a future
/// process lifetime resumes it. This is a control-flow signal, not a fault.
/// </summary>
public sealed class TaskDeferredException : TaskException
{
    /// <summary>Initializes a new instance of the <see cref="TaskDeferredException"/> class.</summary>
    public TaskDeferredException()
        : base("The task was deferred for recovery.")
    {
    }

    /// <summary>Initializes a new instance of the <see cref="TaskDeferredException"/> class with a message.</summary>
    /// <param name="message">A description of the deferral.</param>
    public TaskDeferredException(string message)
        : base(message)
    {
    }
}
