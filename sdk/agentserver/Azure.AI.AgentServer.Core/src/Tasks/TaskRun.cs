// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.AgentServer.Core.Tasks;

/// <summary>
/// An awaitable handle to a started task run. <c>await</c>-ing the handle yields the
/// typed result (equivalent to <see cref="GetResultAsync"/>). The protected
/// constructor supports mocking; the engine returns populated instances.
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

    /// <summary>The live metadata reference while the run is in-flight.</summary>
    public virtual TaskMetadata Metadata => State.Metadata;

    /// <summary>Whether the input was queued as steering rather than starting a fresh run.</summary>
    public virtual bool IsQueued => State.IsQueued;

    /// <summary>Awaits the run to completion and returns the typed result.</summary>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>The typed result.</returns>
    public virtual Task<TOutput> GetResultAsync(CancellationToken cancellationToken = default)
        => State.GetResultAsync(cancellationToken);

    /// <summary>Requests cancellation of the run.</summary>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A task that completes when cancellation has been requested.</returns>
    public virtual Task CancelAsync(CancellationToken cancellationToken = default)
        => State.CancelAsync(cancellationToken);

    /// <summary>Gets an awaiter so the handle can be <c>await</c>-ed directly.</summary>
    /// <returns>An awaiter for the run result.</returns>
    public TaskAwaiter<TOutput> GetAwaiter() => GetResultAsync().GetAwaiter();
}
