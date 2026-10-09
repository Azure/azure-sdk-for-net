// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Engine;

namespace Azure.AI.AgentServer.Core.Tasks;

/// <summary>
/// A typed handle to a registered resilient task, returned by
/// <see cref="ResilientTaskServiceCollectionExtensions.AddResilientTask{TInput, TOutput}(Microsoft.Extensions.DependencyInjection.IServiceCollection, string, System.Func{TaskContext{TInput}, System.Threading.CancellationToken, System.Threading.Tasks.Task{TOutput}}, System.Action{TaskRegistrationOptions}?)"/>
/// and <see cref="ResilientTaskServiceCollectionExtensions.AddResilientMultiTurnTask{TInput, TOutput}(Microsoft.Extensions.DependencyInjection.IServiceCollection, string, System.Func{TaskContext{TInput}, System.Threading.CancellationToken, System.Threading.Tasks.Task{TOutput}}, bool, System.Action{TaskRegistrationOptions}?)"/>.
/// The task name and its <typeparamref name="TInput"/>/<typeparamref name="TOutput"/> types are
/// bound once at registration, so starting or running the task is strongly typed — an input or
/// output that does not match the registration is a compile-time error rather than a runtime failure.
/// The protected constructor and virtual members support substitution in consumer unit tests.
/// </summary>
/// <typeparam name="TInput">The task input type.</typeparam>
/// <typeparam name="TOutput">The task output type.</typeparam>
public class TaskDefinition<TInput, TOutput>
{
    private readonly string? _name;
    private readonly TaskEngineAccessor? _engine;

    /// <summary>Initializes a new instance of the <see cref="TaskDefinition{TInput, TOutput}"/> class for mocking.</summary>
    protected TaskDefinition()
    {
    }

    internal TaskDefinition(string name, TaskEngineAccessor engine)
    {
        _name = name;
        _engine = engine;
    }

    private TaskEngine Engine => _engine?.Require()
        ?? throw new System.InvalidOperationException(
            "TaskDefinition was not initialized by resilient task registration.");

    /// <summary>The registered task name.</summary>
    public virtual string Name => _name
        ?? throw new System.InvalidOperationException(
            "TaskDefinition was not initialized by resilient task registration.");

    /// <summary>Starts the task and awaits it to completion, returning the typed result.</summary>
    /// <param name="input">The typed input.</param>
    /// <param name="options">Optional per-invocation options.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>The typed result.</returns>
    public virtual Task<TOutput> RunAsync(TInput input, RunOptions? options = null, CancellationToken cancellationToken = default)
        => Engine.RunAsync<TInput, TOutput>(Name, input, options, cancellationToken);

    /// <summary>Starts the task and returns an awaitable handle once the creation round-trip succeeds.</summary>
    /// <remarks>
    /// Concurrent starts for the same task id within one task engine coordinate initial creation.
    /// Once started, a steerable multi-turn task queues each accepted input with its own handle;
    /// a one-shot task converges on the existing run. Creation conflicts with another task engine
    /// are not automatically converted into steering.
    /// If a multi-turn execution suspends before accepting an input that was waiting to append,
    /// the start is re-evaluated with the same input id, precondition, and cancellation token.
    /// </remarks>
    /// <param name="input">The typed input.</param>
    /// <param name="options">Optional per-invocation options.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>An awaitable <see cref="TaskRun{TOutput}"/> handle.</returns>
    public virtual Task<TaskRun<TOutput>> StartAsync(TInput input, RunOptions? options = null, CancellationToken cancellationToken = default)
        => Engine.StartAsync<TInput, TOutput>(Name, input, options, cancellationToken);

    /// <summary>
    /// Returns the in-flight run for a one-shot task keyed by <paramref name="taskId"/>, or
    /// <see langword="null"/> when not in-flight in this process and not reclaimable inline.
    /// </summary>
    /// <param name="taskId">The task id.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>The in-flight run, or <see langword="null"/>.</returns>
    public virtual Task<TaskRun<TOutput>?> GetActiveRunAsync(string taskId, CancellationToken cancellationToken = default)
        => Engine.GetActiveRunAsync<TOutput>(Name, taskId, cancellationToken);

    /// <summary>
    /// Returns the in-flight run for a multi-turn task keyed by <paramref name="taskId"/> and
    /// <paramref name="inputId"/>, or <see langword="null"/> when not in-flight.
    /// </summary>
    /// <param name="taskId">The chain id.</param>
    /// <param name="inputId">The input id of the turn to attach to.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>The in-flight run, or <see langword="null"/>.</returns>
    public virtual Task<TaskRun<TOutput>?> GetActiveRunAsync(string taskId, string inputId, CancellationToken cancellationToken = default)
        => Engine.GetActiveRunAsync<TOutput>(Name, taskId, inputId, cancellationToken);

    /// <summary>
    /// Ends a multi-turn chain: cancels any in-flight turn, resolves queued callers as cancelled,
    /// and removes the record. Idempotent — a no-op when the chain is absent.
    /// </summary>
    /// <remarks>
    /// Cancellation is requested before storage deletion. A storage failure does not undo
    /// cancellation and does not authorize stream closure. Task-bound streams close after
    /// deletion is confirmed and their producer has unwound. This method does not wait for
    /// an in-flight handler to finish; that handler's completion may remain pending.
    /// </remarks>
    /// <param name="taskId">The chain id.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A task that completes when the chain has been removed.</returns>
    public virtual Task DeleteAsync(string taskId, CancellationToken cancellationToken = default)
        => Engine.DeleteAsync(Name, taskId, cancellationToken);
}
