// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.AgentServer.Core.Tasks;

/// <summary>
/// Fluent builder for registering resilient tasks. Only the delegate registration
/// form is exposed (Python parity — <c>@task</c> decorates a function); a DI-resolved
/// class handler can be wrapped in the delegate.
/// </summary>
public interface IResilientTaskBuilder
{
    /// <summary>
    /// Registers a one-shot task (Python <c>@task</c>).
    /// </summary>
    /// <typeparam name="TInput">The task input type.</typeparam>
    /// <typeparam name="TOutput">The task output type.</typeparam>
    /// <param name="name">The unique task name.</param>
    /// <param name="handler">The handler delegate.</param>
    /// <param name="configure">An optional callback to configure per-task options.</param>
    /// <returns>The same builder for chaining.</returns>
    IResilientTaskBuilder AddTask<TInput, TOutput>(
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
    IResilientTaskBuilder AddMultiTurnTask<TInput, TOutput>(
        string name,
        Func<TaskContext<TInput>, CancellationToken, Task<TOutput>> handler,
        bool steerable = false,
        Action<TaskRegistrationOptions>? configure = null);

    /// <summary>
    /// Registers a one-shot task whose handler resolves dependencies from the application
    /// <see cref="IServiceProvider"/>. The provider is supplied at invocation time, so there is no
    /// need to call <c>BuildServiceProvider()</c> before registering tasks.
    /// </summary>
    /// <remarks>
    /// The provider passed to the handler is the <b>root</b> application provider. Task handlers run
    /// on background/recovery paths with no ambient request scope, so resolve <b>singleton</b> (or
    /// transient) services here; resolving a <b>scoped</b> service directly throws. If a handler
    /// needs scoped services, create a scope explicitly
    /// (<c>provider.GetRequiredService&lt;IServiceScopeFactory&gt;().CreateScope()</c>) and resolve
    /// from <c>scope.ServiceProvider</c>.
    /// </remarks>
    /// <typeparam name="TInput">The task input type.</typeparam>
    /// <typeparam name="TOutput">The task output type.</typeparam>
    /// <param name="name">The unique task name.</param>
    /// <param name="handler">The handler delegate; its first argument is the resolved service provider.</param>
    /// <param name="configure">An optional callback to configure per-task options.</param>
    /// <returns>The same builder for chaining.</returns>
    IResilientTaskBuilder AddTask<TInput, TOutput>(
        string name,
        Func<IServiceProvider, TaskContext<TInput>, CancellationToken, Task<TOutput>> handler,
        Action<TaskRegistrationOptions>? configure = null);

    /// <summary>
    /// Registers a multi-turn task (optionally steerable) whose handler resolves dependencies from
    /// the application <see cref="IServiceProvider"/>. The provider is supplied at invocation time,
    /// so there is no need to call <c>BuildServiceProvider()</c> before registering tasks.
    /// </summary>
    /// <remarks>
    /// The provider passed to the handler is the <b>root</b> application provider. Task handlers run
    /// on background/recovery paths with no ambient request scope, so resolve <b>singleton</b> (or
    /// transient) services here; resolving a <b>scoped</b> service directly throws. If a handler
    /// needs scoped services, create a scope explicitly
    /// (<c>provider.GetRequiredService&lt;IServiceScopeFactory&gt;().CreateScope()</c>) and resolve
    /// from <c>scope.ServiceProvider</c>.
    /// </remarks>
    /// <typeparam name="TInput">The task input type.</typeparam>
    /// <typeparam name="TOutput">The task output type.</typeparam>
    /// <param name="name">The unique task name.</param>
    /// <param name="handler">The handler delegate; its first argument is the resolved service provider.</param>
    /// <param name="steerable">Whether the task accepts steering input.</param>
    /// <param name="configure">An optional callback to configure per-task options.</param>
    /// <returns>The same builder for chaining.</returns>
    IResilientTaskBuilder AddMultiTurnTask<TInput, TOutput>(
        string name,
        Func<IServiceProvider, TaskContext<TInput>, CancellationToken, Task<TOutput>> handler,
        bool steerable = false,
        Action<TaskRegistrationOptions>? configure = null);
}
