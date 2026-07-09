// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.AgentServer.Core.Tasks;

/// <summary>
/// Internal mutable backing state for <see cref="TaskContext{TInput}"/>. The engine
/// owns and mutates this between turns; the public context projects it as virtual,
/// read-only members.
/// </summary>
/// <typeparam name="TInput">The task input type.</typeparam>
internal sealed class TaskContextState<TInput>
{
    public TaskContextState(TInput input, string taskId, string inputId, TaskMetadata metadata)
    {
        Input = input;
        TaskId = taskId;
        InputId = inputId;
        Metadata = metadata;
    }

    public TInput Input { get; set; }

    public string TaskId { get; }

    public string InputId { get; set; }

    public EntryMode EntryMode { get; set; } = EntryMode.Fresh;

    public TaskMetadata Metadata { get; }

    public int RetryAttempt { get; set; }

    public int RecoveryCount { get; set; }

    public bool IsSteeredTurn { get; set; }

    public int PendingInputCount { get; set; }

    public CancellationToken Cancellation { get; set; }

    public bool CancelRequested { get; set; }

    public bool TimeoutExceeded { get; set; }

    public CancellationToken Shutdown { get; set; }

    public Func<CancellationToken, Task> ExitForRecovery { get; set; } =
        _ => throw new TaskDeferredException("Task exited for recovery.");

    public Task ExitForRecoveryAsync(CancellationToken cancellationToken) => ExitForRecovery(cancellationToken);
}
