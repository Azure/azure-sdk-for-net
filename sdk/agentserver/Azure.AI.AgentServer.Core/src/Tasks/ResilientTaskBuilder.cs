// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization.Metadata;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.AgentServer.Core.Tasks;

/// <summary>
/// Fluent builder for registering resilient tasks. Only the delegate registration
/// form is exposed (Python parity — <c>@task</c> decorates a function); a DI-resolved
/// class handler can be wrapped in the delegate.
/// </summary>
public abstract class ResilientTaskBuilder
{
    internal const string ReflectionTrimWarning =
        "This overload serializes the task input using reflection-based JSON serialization, which is not " +
        "compatible with trimming. Use the overload that accepts a JsonTypeInfo<TInput> instead.";

    internal const string ReflectionAotWarning =
        "This overload serializes the task input using reflection-based JSON serialization, which may require " +
        "runtime code generation. Use the overload that accepts a JsonTypeInfo<TInput> instead.";

    /// <summary>Initializes a new instance of the <see cref="ResilientTaskBuilder"/> class.</summary>
    protected ResilientTaskBuilder()
    {
    }

    /// <summary>
    /// Registers a one-shot task (Python <c>@task</c>).
    /// </summary>
    /// <typeparam name="TInput">The task input type.</typeparam>
    /// <typeparam name="TOutput">The task output type.</typeparam>
    /// <param name="name">The unique task name.</param>
    /// <param name="handler">The handler delegate.</param>
    /// <param name="configure">An optional callback to configure per-task options.</param>
    /// <returns>The same builder for chaining.</returns>
    [RequiresUnreferencedCode(ReflectionTrimWarning)]
    [RequiresDynamicCode(ReflectionAotWarning)]
    public abstract ResilientTaskBuilder AddTask<TInput, TOutput>(
        string name,
        Func<TaskContext<TInput>, CancellationToken, Task<TOutput>> handler,
        Action<TaskRegistrationOptions>? configure = null);

    /// <summary>
    /// Registers a multi-turn task (Python <c>@multi_turn_task</c>), optionally steerable.
    /// </summary>
    /// <typeparam name="TInput">The task input type.</typeparam>
    /// <typeparam name="TOutput">The task output type.</typeparam>
    /// <param name="name">The unique task name.</param>
    /// <param name="handler">The handler delegate.</param>
    /// <param name="steerable">Whether the task accepts steering input.</param>
    /// <param name="configure">An optional callback to configure per-task options.</param>
    /// <returns>The same builder for chaining.</returns>
    [RequiresUnreferencedCode(ReflectionTrimWarning)]
    [RequiresDynamicCode(ReflectionAotWarning)]
    public abstract ResilientTaskBuilder AddMultiTurnTask<TInput, TOutput>(
        string name,
        Func<TaskContext<TInput>, CancellationToken, Task<TOutput>> handler,
        bool steerable = false,
        Action<TaskRegistrationOptions>? configure = null);

    /// <summary>
    /// Registers a one-shot task using a source-generated <see cref="JsonTypeInfo{T}"/> for the
    /// input type, so the task input is serialized without runtime reflection. Use this overload in
    /// Native-AOT or trimming-enabled applications; the framework never serializes the output, so no
    /// output metadata is required.
    /// </summary>
    /// <typeparam name="TInput">The task input type.</typeparam>
    /// <typeparam name="TOutput">The task output type.</typeparam>
    /// <param name="name">The unique task name.</param>
    /// <param name="handler">The handler delegate.</param>
    /// <param name="inputTypeInfo">The source-generated serialization metadata for <typeparamref name="TInput"/>.</param>
    /// <param name="configure">An optional callback to configure per-task options.</param>
    /// <returns>The same builder for chaining.</returns>
    public abstract ResilientTaskBuilder AddTask<TInput, TOutput>(
        string name,
        Func<TaskContext<TInput>, CancellationToken, Task<TOutput>> handler,
#pragma warning disable AZC0014 // JsonTypeInfo<T> is the sanctioned Native-AOT escape hatch (see Azure.Search.Documents).
        JsonTypeInfo<TInput> inputTypeInfo,
#pragma warning restore AZC0014
        Action<TaskRegistrationOptions>? configure = null);

    /// <summary>
    /// Registers a multi-turn task (optionally steerable) using a source-generated
    /// <see cref="JsonTypeInfo{T}"/> for the input type, so the task input is serialized without
    /// runtime reflection. Use this overload in Native-AOT or trimming-enabled applications; the
    /// framework never serializes the output, so no output metadata is required.
    /// </summary>
    /// <typeparam name="TInput">The task input type.</typeparam>
    /// <typeparam name="TOutput">The task output type.</typeparam>
    /// <param name="name">The unique task name.</param>
    /// <param name="handler">The handler delegate.</param>
    /// <param name="inputTypeInfo">The source-generated serialization metadata for <typeparamref name="TInput"/>.</param>
    /// <param name="steerable">Whether the task accepts steering input.</param>
    /// <param name="configure">An optional callback to configure per-task options.</param>
    /// <returns>The same builder for chaining.</returns>
    public abstract ResilientTaskBuilder AddMultiTurnTask<TInput, TOutput>(
        string name,
        Func<TaskContext<TInput>, CancellationToken, Task<TOutput>> handler,
#pragma warning disable AZC0014 // JsonTypeInfo<T> is the sanctioned Native-AOT escape hatch (see Azure.Search.Documents).
        JsonTypeInfo<TInput> inputTypeInfo,
#pragma warning restore AZC0014
        bool steerable = false,
        Action<TaskRegistrationOptions>? configure = null);
}
