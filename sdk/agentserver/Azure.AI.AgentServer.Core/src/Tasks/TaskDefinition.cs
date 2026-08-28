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
/// </summary>
/// <typeparam name="TInput">The task input type.</typeparam>
/// <typeparam name="TOutput">The task output type.</typeparam>
public sealed class TaskDefinition<TInput, TOutput>
{
    private readonly TaskEngineAccessor _engine;

    internal TaskDefinition(string name, TaskEngineAccessor engine)
    {
        Name = name;
        _engine = engine;
    }

    /// <summary>The registered task name.</summary>
    public string Name { get; }

    /// <summary>Starts the task and awaits it to completion, returning the typed result.</summary>
    /// <param name="input">The typed input.</param>
    /// <param name="options">Optional per-invocation options.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>The typed result.</returns>
    public Task<TOutput> RunAsync(TInput input, RunOptions? options = null, CancellationToken cancellationToken = default)
        => _engine.Require().RunAsync<TInput, TOutput>(Name, input, options, cancellationToken);

    /// <summary>Starts the task and returns an awaitable handle once the creation round-trip succeeds.</summary>
    /// <param name="input">The typed input.</param>
    /// <param name="options">Optional per-invocation options.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>An awaitable <see cref="TaskRun{TOutput}"/> handle.</returns>
    public Task<TaskRun<TOutput>> StartAsync(TInput input, RunOptions? options = null, CancellationToken cancellationToken = default)
        => _engine.Require().StartAsync<TInput, TOutput>(Name, input, options, cancellationToken);

    /// <summary>
    /// Returns the in-flight run for a one-shot task keyed by <paramref name="taskId"/>, or
    /// <see langword="null"/> when not in-flight in this process and not reclaimable inline.
    /// </summary>
    /// <param name="taskId">The task id.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>The in-flight run, or <see langword="null"/>.</returns>
    public Task<TaskRun<TOutput>?> GetActiveRunAsync(string taskId, CancellationToken cancellationToken = default)
        => _engine.Require().GetActiveRunAsync<TOutput>(Name, taskId, cancellationToken);

    /// <summary>
    /// Returns the in-flight run for a multi-turn task keyed by <paramref name="taskId"/> and
    /// <paramref name="inputId"/>, or <see langword="null"/> when not in-flight.
    /// </summary>
    /// <param name="taskId">The chain id.</param>
    /// <param name="inputId">The input id of the turn to attach to.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>The in-flight run, or <see langword="null"/>.</returns>
    public Task<TaskRun<TOutput>?> GetActiveRunAsync(string taskId, string inputId, CancellationToken cancellationToken = default)
        => _engine.Require().GetActiveRunAsync<TOutput>(Name, taskId, inputId, cancellationToken);

    /// <summary>
    /// Ends a multi-turn chain: cancels any in-flight turn, resolves queued callers as cancelled,
    /// and removes the record. Idempotent — a no-op when the chain is absent.
    /// </summary>
    /// <param name="taskId">The chain id.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A task that completes when the chain has been removed.</returns>
    public Task DeleteAsync(string taskId, CancellationToken cancellationToken = default)
        => _engine.Require().DeleteAsync(Name, taskId, cancellationToken);
}
