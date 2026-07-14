// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.AgentServer.Core.Tasks;

/// <summary>
/// Internal mutable backing state for <see cref="TaskRun{TOutput}"/>. The engine owns
/// the completion source and cancellation hook; the public handle projects them.
/// </summary>
/// <typeparam name="TOutput">The task output type.</typeparam>
internal sealed class TaskRunState<TOutput>
{
    private readonly TaskCompletionSource<TOutput> _completion =
        new(TaskCreationOptions.RunContinuationsAsynchronously);

    public TaskRunState(string taskId, string inputId, TaskMetadata metadata, bool isQueued)
    {
        TaskId = taskId;
        InputId = inputId;
        Metadata = metadata;
        IsQueued = isQueued;
    }

    public string TaskId { get; }

    public string InputId { get; set; }

    public TaskMetadata Metadata { get; }

    public bool IsQueued { get; }

    /// <summary>
    /// The crash-recovery generation for the run's context (spec §22): mirrors the record's
    /// lease <c>generation</c> at dispatch. 0 on a fresh run; incremented each time the lease is
    /// re-acquired under a new instance id (a crash/takeover recovery).
    /// </summary>
    public int RecoveryCount { get; set; }

    public Func<CancellationToken, Task> Cancel { get; set; } = _ => Task.CompletedTask;

    public Task<TOutput> ResultTask => _completion.Task;

    public void SetResult(TOutput result) => _completion.TrySetResult(result);

    public void SetException(Exception exception) => _completion.TrySetException(exception);

    public async Task<TOutput> GetResultAsync(CancellationToken cancellationToken)
    {
        if (!cancellationToken.CanBeCanceled)
        {
            return await _completion.Task.ConfigureAwait(false);
        }

        var tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
        using (cancellationToken.Register(static s => ((TaskCompletionSource<bool>)s!).TrySetResult(true), tcs))
        {
            Task completed = await Task.WhenAny(_completion.Task, tcs.Task).ConfigureAwait(false);
            if (completed == tcs.Task)
            {
                cancellationToken.ThrowIfCancellationRequested();
            }
        }

        return await _completion.Task.ConfigureAwait(false);
    }

    public Task CancelAsync(CancellationToken cancellationToken) => Cancel(cancellationToken);

    public TaskRun<TOutput> ToHandle() => new(this);
}
