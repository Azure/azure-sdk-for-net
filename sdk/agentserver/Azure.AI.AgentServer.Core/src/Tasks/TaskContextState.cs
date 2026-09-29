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
    public TaskContextState(TInput input, string taskId, string inputId)
    {
        Input = input;
        TaskId = taskId;
        InputId = inputId;
    }

    public TInput Input { get; }

    public string TaskId { get; }

    public string InputId { get; }

    public EntryMode EntryMode { get; set; } = EntryMode.Fresh;

    public int RetryAttempt { get; set; }

    public int RecoveryCount { get; set; }

    public bool IsSteeredTurn { get; set; }

    public int PendingInputCount { get; set; }

    public CancellationToken Cancellation { get; set; }

    public bool CancelRequested { get; set; }

    public bool TimeoutExceeded { get; set; }

    public CancellationToken Shutdown { get; set; }

    /// <summary>
    /// Set by <see cref="ExitForRecoveryAsync"/> to signal that the handler has voluntarily
    /// yielded for recovery. The engine reads this after the handler returns and reconciles the
    /// deferral (parks the task <c>in_progress</c>) instead of treating the return value as a
    /// result. This is a post-return control signal, not an exception.
    /// </summary>
    public bool DeferredForRecovery { get; set; }

    public Func<CancellationToken, Task> ExitForRecovery { get; set; } =
        _ => throw new InvalidOperationException("ExitForRecovery is not available on this context.");

    public Task ExitForRecoveryAsync(CancellationToken cancellationToken) => ExitForRecovery(cancellationToken);
}
