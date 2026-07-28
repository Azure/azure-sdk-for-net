// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.AgentServer.Core.Tasks;

/// <summary>
/// The handler-facing context for a single task turn. Exposes the typed input,
/// identity, entry mode, durable metadata, retry/steering signals, the crash-recovery
/// count, and cooperative cancellation, matching Python's <c>TaskContext</c>. The protected
/// constructor supports mocking; the engine populates instances internally.
/// </summary>
/// <typeparam name="TInput">The task input type.</typeparam>
public class TaskContext<TInput>
{
    private readonly TaskContextState<TInput>? _state;

    /// <summary>Initializes a new instance of the <see cref="TaskContext{TInput}"/> class for mocking.</summary>
    protected TaskContext()
    {
    }

    internal TaskContext(TaskContextState<TInput> state) => _state = state;

    private TaskContextState<TInput> State => _state
        ?? throw new System.InvalidOperationException("TaskContext was not initialized by the task engine.");

    /// <summary>The typed input for this turn.</summary>
    public virtual TInput Input => State.Input;

    /// <summary>The task id.</summary>
    public virtual string TaskId => State.TaskId;

    /// <summary>The input id for this turn.</summary>
    public virtual string InputId => State.InputId;

    /// <summary>How the handler was entered for this turn.</summary>
    public virtual EntryMode EntryMode => State.EntryMode;

    /// <summary>The durable, namespaced task metadata.</summary>
    public virtual TaskMetadata Metadata => State.Metadata;

    /// <summary>The zero-based retry attempt for the current turn (0 on the first try).</summary>
    public virtual int RetryAttempt => State.RetryAttempt;

    /// <summary>
    /// The crash-recovery count for this task (spec §22): 0 on a fresh run, incremented each
    /// time the task's lease is re-acquired under a new process instance (a crash/takeover
    /// recovery). Mirrors the persisted lease <c>generation</c>.
    /// </summary>
    public virtual int RecoveryCount => State.RecoveryCount;

    /// <summary>Whether the current turn was triggered by a steering input.</summary>
    public virtual bool IsSteeredTurn => State.IsSteeredTurn;

    /// <summary>The number of pending (queued) steering inputs.</summary>
    public virtual int PendingInputCount => State.PendingInputCount;

    /// <summary>A token signaled for any cancellation cause (timeout, steering-cancel, shutdown).</summary>
    public virtual CancellationToken Cancellation => State.Cancellation;

    /// <summary>Whether cancellation was requested by an explicit cancel cause.</summary>
    public virtual bool CancelRequested => State.CancelRequested;

    /// <summary>Whether the per-task execution timeout was exceeded.</summary>
    public virtual bool TimeoutExceeded => State.TimeoutExceeded;

    /// <summary>A token signaled when the host is shutting down.</summary>
    public virtual CancellationToken Shutdown => State.Shutdown;

    /// <summary>
    /// Exits the current turn for later recovery: releases the lease without a terminal
    /// status, leaving the task <c>in_progress</c> so it can be resumed elsewhere. Throws
    /// <see cref="TaskDeferredException"/> to unwind the handler.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A task that never completes normally; it throws to unwind the handler.</returns>
    public virtual Task ExitForRecoveryAsync(CancellationToken cancellationToken = default)
        => State.ExitForRecoveryAsync(cancellationToken);
}
