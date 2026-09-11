// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization.Metadata;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Engine;

namespace Azure.AI.AgentServer.Core.Tasks;

/// <summary>
/// Records task registrations into the shared <see cref="TaskRegistry"/> and hands back the typed
/// <see cref="TaskDefinition{TInput, TOutput}"/> invocation handle. Used internally by the flat
/// <c>AddResilientTask</c>/<c>AddResilientMultiTurnTask</c> extension methods on
/// <see cref="Microsoft.Extensions.DependencyInjection.IServiceCollection"/> (see
/// <see cref="ResilientTaskServiceCollectionExtensions"/>), and directly by tests that need a
/// registrar without a DI container.
/// </summary>
internal sealed class DefaultResilientTaskBuilder
{
    internal const string ReflectionTrimWarning =
        "This overload serializes the task input using reflection-based JSON serialization, which is not " +
        "compatible with trimming. Use the overload that accepts a JsonTypeInfo<TInput> instead.";

    internal const string ReflectionAotWarning =
        "This overload serializes the task input using reflection-based JSON serialization, which may require " +
        "runtime code generation. Use the overload that accepts a JsonTypeInfo<TInput> instead.";

    private readonly TaskRegistry _registry;
    private readonly TaskEngineAccessor _engine;

    public DefaultResilientTaskBuilder(TaskRegistry registry, TaskEngineAccessor engine)
    {
        _registry = registry;
        _engine = engine;
    }

    /// <summary>Registers a one-shot task (Python <c>@task</c>).</summary>
    [RequiresUnreferencedCode(ReflectionTrimWarning)]
    [RequiresDynamicCode(ReflectionAotWarning)]
    public TaskDefinition<TInput, TOutput> AddTask<TInput, TOutput>(
        string name,
        Func<TaskContext<TInput>, CancellationToken, Task<TOutput>> handler,
        Action<TaskRegistrationOptions>? configure = null)
        => Add(name, handler, multiTurn: false, static () => false, configure);

    /// <summary>Registers a multi-turn task (Python <c>@multi_turn_task</c>), optionally steerable.</summary>
    [RequiresUnreferencedCode(ReflectionTrimWarning)]
    [RequiresDynamicCode(ReflectionAotWarning)]
    public TaskDefinition<TInput, TOutput> AddMultiTurnTask<TInput, TOutput>(
        string name,
        Func<TaskContext<TInput>, CancellationToken, Task<TOutput>> handler,
        bool steerable = false,
        Action<TaskRegistrationOptions>? configure = null)
        => Add(name, handler, multiTurn: true, () => steerable, configure);

    /// <summary>Registers a multi-turn task whose steerability is resolved when a run starts.</summary>
    public TaskDefinition<TInput, TOutput> AddMultiTurnTask<TInput, TOutput>(
        string name,
        Func<TaskContext<TInput>, CancellationToken, Task<TOutput>> handler,
        Func<bool> isSteerable,
        Action<TaskRegistrationOptions>? configure = null)
    {
        ArgumentNullException.ThrowIfNull(isSteerable);
        return Add(name, handler, multiTurn: true, isSteerable, configure);
    }

    /// <summary>
    /// Registers a one-shot task using a source-generated <see cref="JsonTypeInfo{T}"/> for the
    /// input type (Native-AOT / trimming-safe).
    /// </summary>
    public TaskDefinition<TInput, TOutput> AddTask<TInput, TOutput>(
        string name,
        Func<TaskContext<TInput>, CancellationToken, Task<TOutput>> handler,
#pragma warning disable AZC0014 // JsonTypeInfo<T> is the sanctioned Native-AOT escape hatch (see Azure.Search.Documents).
        JsonTypeInfo<TInput> inputTypeInfo,
#pragma warning restore AZC0014
        Action<TaskRegistrationOptions>? configure = null)
    {
        ArgumentNullException.ThrowIfNull(inputTypeInfo);
        return Add(name, handler, multiTurn: false, static () => false, configure, inputTypeInfo);
    }

    /// <summary>
    /// Registers a multi-turn task (optionally steerable) using a source-generated
    /// <see cref="JsonTypeInfo{T}"/> for the input type (Native-AOT / trimming-safe).
    /// </summary>
    public TaskDefinition<TInput, TOutput> AddMultiTurnTask<TInput, TOutput>(
        string name,
        Func<TaskContext<TInput>, CancellationToken, Task<TOutput>> handler,
#pragma warning disable AZC0014 // JsonTypeInfo<T> is the sanctioned Native-AOT escape hatch (see Azure.Search.Documents).
        JsonTypeInfo<TInput> inputTypeInfo,
#pragma warning restore AZC0014
        bool steerable = false,
        Action<TaskRegistrationOptions>? configure = null)
    {
        ArgumentNullException.ThrowIfNull(inputTypeInfo);
        return Add(name, handler, multiTurn: true, () => steerable, configure, inputTypeInfo);
    }

    private TaskDefinition<TInput, TOutput> Add<TInput, TOutput>(
        string name,
        Func<TaskContext<TInput>, CancellationToken, Task<TOutput>> handler,
        bool multiTurn,
        Func<bool> isSteerable,
        Action<TaskRegistrationOptions>? configure,
        JsonTypeInfo<TInput>? inputTypeInfo = null)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Task name must be a non-empty, non-whitespace string.", nameof(name));
        }

        ArgumentNullException.ThrowIfNull(handler);

        TaskRegistrationOptions? options = null;
        if (configure is not null)
        {
            options = new TaskRegistrationOptions();
            configure(options);

            if (options.Timeout is { } timeout)
            {
                if (timeout < TimeSpan.Zero)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(configure), timeout, "TaskRegistrationOptions.Timeout must not be negative.");
                }

                if (timeout > TaskEngineConstants.MaxTaskTimeout)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(configure), timeout,
                        $"TaskRegistrationOptions.Timeout must not exceed the {TaskEngineConstants.MaxTaskTimeout.TotalDays:0}-day hard cap.");
                }
            }

            options.Retry?.Validate();
        }

        var registration = new TaskRegistration(
            name,
            typeof(TInput),
            typeof(TOutput),
            handler,
            multiTurn,
            isSteerable,
            options,
            inputTypeInfo);

        registration.RecoverDispatch = (engineObj, record) =>
            ((TaskEngine)engineObj).RecoverAsync<TInput, TOutput>(registration, record);

        _registry.Add(registration);

        return new TaskDefinition<TInput, TOutput>(name, _engine);
    }
}
