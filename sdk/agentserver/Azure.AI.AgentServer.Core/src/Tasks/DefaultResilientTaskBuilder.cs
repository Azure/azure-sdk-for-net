// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json.Serialization.Metadata;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Engine;

namespace Azure.AI.AgentServer.Core.Tasks;

/// <summary>
/// The default <see cref="ResilientTaskBuilder"/> that records registrations into
/// the shared <see cref="TaskRegistry"/>.
/// </summary>
internal sealed class DefaultResilientTaskBuilder : ResilientTaskBuilder
{
    private readonly TaskRegistry _registry;
    private readonly TaskServiceProviderAccessor _providerAccessor;

    public DefaultResilientTaskBuilder(TaskRegistry registry, TaskServiceProviderAccessor providerAccessor)
    {
        _registry = registry;
        _providerAccessor = providerAccessor;
    }

    /// <inheritdoc/>
    public override ResilientTaskBuilder AddTask<TInput, TOutput>(
        string name,
        Func<TaskContext<TInput>, CancellationToken, Task<TOutput>> handler,
        Action<TaskRegistrationOptions>? configure = null)
        => Add(name, handler, multiTurn: false, steerable: false, configure);

    /// <inheritdoc/>
    public override ResilientTaskBuilder AddMultiTurnTask<TInput, TOutput>(
        string name,
        Func<TaskContext<TInput>, CancellationToken, Task<TOutput>> handler,
        bool steerable = false,
        Action<TaskRegistrationOptions>? configure = null)
        => Add(name, handler, multiTurn: true, steerable, configure);

    /// <inheritdoc/>
    public override ResilientTaskBuilder AddTask<TInput, TOutput>(
        string name,
        Func<TaskContext<TInput>, CancellationToken, Task<TOutput>> handler,
#pragma warning disable AZC0014 // JsonTypeInfo<T> is the sanctioned Native-AOT escape hatch (see Azure.Search.Documents).
        JsonTypeInfo<TInput> inputTypeInfo,
#pragma warning restore AZC0014
        Action<TaskRegistrationOptions>? configure = null)
    {
        ArgumentNullException.ThrowIfNull(inputTypeInfo);
        return Add(name, handler, multiTurn: false, steerable: false, configure, inputTypeInfo);
    }

    /// <inheritdoc/>
    public override ResilientTaskBuilder AddMultiTurnTask<TInput, TOutput>(
        string name,
        Func<TaskContext<TInput>, CancellationToken, Task<TOutput>> handler,
#pragma warning disable AZC0014 // JsonTypeInfo<T> is the sanctioned Native-AOT escape hatch (see Azure.Search.Documents).
        JsonTypeInfo<TInput> inputTypeInfo,
#pragma warning restore AZC0014
        bool steerable = false,
        Action<TaskRegistrationOptions>? configure = null)
    {
        ArgumentNullException.ThrowIfNull(inputTypeInfo);
        return Add(name, handler, multiTurn: true, steerable, configure, inputTypeInfo);
    }

    /// <inheritdoc/>
    public override ResilientTaskBuilder AddTask<TInput, TOutput>(
        string name,
        Func<IServiceProvider, TaskContext<TInput>, CancellationToken, Task<TOutput>> handler,
        Action<TaskRegistrationOptions>? configure = null)
    {
        ArgumentNullException.ThrowIfNull(handler);
        return Add(name, Wrap(handler), multiTurn: false, steerable: false, configure);
    }

    /// <inheritdoc/>
    public override ResilientTaskBuilder AddMultiTurnTask<TInput, TOutput>(
        string name,
        Func<IServiceProvider, TaskContext<TInput>, CancellationToken, Task<TOutput>> handler,
        bool steerable = false,
        Action<TaskRegistrationOptions>? configure = null)
    {
        ArgumentNullException.ThrowIfNull(handler);
        return Add(name, Wrap(handler), multiTurn: true, steerable, configure);
    }

    // Adapts a provider-aware handler to the plain delegate shape the engine invokes. The provider
    // is resolved from the shared accessor at invocation time (populated when the engine is built),
    // so registration does not depend on the container already existing.
    private Func<TaskContext<TInput>, CancellationToken, Task<TOutput>> Wrap<TInput, TOutput>(
        Func<IServiceProvider, TaskContext<TInput>, CancellationToken, Task<TOutput>> handler)
        => (ctx, ct) => handler(_providerAccessor.Require(), ctx, ct);

    private ResilientTaskBuilder Add<TInput, TOutput>(
        string name,
        Func<TaskContext<TInput>, CancellationToken, Task<TOutput>> handler,
        bool multiTurn,
        bool steerable,
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
            steerable,
            options,
            inputTypeInfo);

        registration.RecoverDispatch = (engineObj, record) =>
            ((TaskEngine)engineObj).RecoverAsync<TInput, TOutput>(registration, record);

        _registry.Add(registration);

        return this;
    }
}
