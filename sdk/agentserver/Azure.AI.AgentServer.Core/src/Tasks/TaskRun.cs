// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;

namespace Azure.AI.AgentServer.Core.Tasks;

/// <summary>
/// A handle to a started task run. Await <see cref="Completion"/> to observe the typed
/// result; to cancel only your wait (without affecting the durable run) use
/// <c>Completion.WaitAsync(cancellationToken)</c>. The protected constructor supports
/// mocking; the engine returns populated instances.
/// </summary>
/// <typeparam name="TOutput">The task output type.</typeparam>
public class TaskRun<TOutput>
{
    private readonly TaskRunState<TOutput>? _state;

    /// <summary>Initializes a new instance of the <see cref="TaskRun{TOutput}"/> class for mocking.</summary>
    protected TaskRun()
    {
    }

    internal TaskRun(TaskRunState<TOutput> state) => _state = state;

    private TaskRunState<TOutput> State => _state
        ?? throw new System.InvalidOperationException("TaskRun was not initialized by the task engine.");

    /// <summary>The task id.</summary>
    public virtual string TaskId => State.TaskId;

    /// <summary>The input id assigned to the input that started this run.</summary>
    public virtual string InputId => State.InputId;

    /// <summary>Whether the input was queued as steering rather than starting a fresh run.</summary>
    public virtual bool IsQueued => State.IsQueued;

    /// <summary>The event stream associated with the input that started this run.</summary>
    public virtual TaskStream Stream => State.Stream;

    /// <summary>
    /// A task that completes with the run's typed result. Await it to observe the result;
    /// use <c>Completion.WaitAsync(cancellationToken)</c> to cancel only your wait. If the run
    /// is deferred for recovery, this task remains pending — the durable run resumes elsewhere.
    /// </summary>
    public virtual Task<TOutput> Completion => State.ResultTask;

    /// <summary>Requests cooperative cancellation of the run.</summary>
    /// <returns>A task that completes when cancellation has been requested.</returns>
    public virtual Task RequestCancellationAsync()
        => State.RequestCancellationAsync();
}
