// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.AgentServer.Core.Tasks;

/// <summary>
/// Starts and inspects resilient task runs. <see cref="RunAsync{TInput, TOutput}"/> is
/// the convenience that starts and awaits to completion; <see cref="StartAsync{TInput, TOutput}"/>
/// performs the creation round-trip and returns an awaitable handle. Both perform a
/// task-storage round-trip and so are async (1:1 with Python <c>run</c>/<c>start</c>).
/// </summary>
public interface ITaskInvoker
{
    /// <summary>Starts a task and awaits it to completion, returning the typed result.</summary>
    /// <typeparam name="TInput">The task input type.</typeparam>
    /// <typeparam name="TOutput">The task output type.</typeparam>
    /// <param name="name">The registered task name.</param>
    /// <param name="input">The typed input.</param>
    /// <param name="options">Optional per-invocation options.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>The typed result.</returns>
    Task<TOutput> RunAsync<TInput, TOutput>(
        string name, TInput input, RunOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>Starts a task and returns an awaitable handle once the creation round-trip succeeds.</summary>
    /// <typeparam name="TInput">The task input type.</typeparam>
    /// <typeparam name="TOutput">The task output type.</typeparam>
    /// <param name="name">The registered task name.</param>
    /// <param name="input">The typed input.</param>
    /// <param name="options">Optional per-invocation options.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>An awaitable <see cref="TaskRun{TOutput}"/> handle.</returns>
    Task<TaskRun<TOutput>> StartAsync<TInput, TOutput>(
        string name, TInput input, RunOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns the in-flight run for a one-shot task keyed by <paramref name="taskId"/>, or
    /// <see langword="null"/> when not in-flight in this process and not reclaimable inline.
    /// </summary>
    /// <typeparam name="TOutput">The task output type.</typeparam>
    /// <param name="name">The registered (one-shot) task name.</param>
    /// <param name="taskId">The task id.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>The in-flight run, or <see langword="null"/>.</returns>
    Task<TaskRun<TOutput>?> GetActiveRunAsync<TOutput>(
        string name, string taskId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns the in-flight run for a multi-turn task keyed by <paramref name="taskId"/> and
    /// <paramref name="inputId"/>, or <see langword="null"/> when not in-flight.
    /// </summary>
    /// <typeparam name="TOutput">The task output type.</typeparam>
    /// <param name="name">The registered (multi-turn) task name.</param>
    /// <param name="taskId">The task id.</param>
    /// <param name="inputId">The input id.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>The in-flight run, or <see langword="null"/>.</returns>
    Task<TaskRun<TOutput>?> GetActiveRunAsync<TOutput>(
        string name, string taskId, string inputId, CancellationToken cancellationToken = default);
}
