// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization.Metadata;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Streaming;
using Azure.AI.AgentServer.Core.Tasks.Engine;
using Azure.AI.AgentServer.Core.Tasks.Providers;
using Azure.AI.AgentServer.Core.Tasks.Providers.Hosted;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Azure.AI.AgentServer.Core.Tasks;

/// <summary>
/// Registration entry points for the resilient-tasks feature. Hosted storage can be configured
/// with an explicit credential and endpoint, or through configuration-bound
/// <see cref="ResilientTaskSettings"/> on an <see cref="Microsoft.Extensions.Hosting.IHostApplicationBuilder"/>.
/// Without an explicit endpoint, the hosted credential can also be supplied through
/// <see cref="AddResilientTasks(IServiceCollection, TokenCredential?)"/> or a registered
/// <see cref="TokenCredential"/> service. Lease durations and retry/timeout defaults are
/// configured per task rather than globally.
/// </summary>
public static class ResilientTaskServiceCollectionExtensions
{
    /// <summary>
    /// Sets up the resilient-tasks services, optionally supplying the hosted-storage credential.
    /// Calling <c>AddResilientTask</c>/<c>AddResilientMultiTurnTask</c> directly also performs this
    /// setup on first use, so this method only needs to be called explicitly to supply a hosted
    /// credential. The credential may be supplied before or after task registrations while composing
    /// the service collection. A <see cref="TokenCredential"/> registered directly in the service
    /// collection is also supported; when both forms are used they must resolve to the same instance.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="credential">A credential for hosted-mode authentication. Required when running in a hosted environment.</param>
    /// <returns>The service collection, for chaining.</returns>
    public static IServiceCollection AddResilientTasks(
        this IServiceCollection services,
        TokenCredential? credential = null)
    {
        ArgumentNullException.ThrowIfNull(services);
        if (credential is not null)
        {
            // Publish an explicitly supplied Core credential so composing protocol packages can
            // reuse the same identity instead of creating and attempting to attach a second one.
            services.TryAddSingleton<TokenCredential>(credential);
        }

        EnsureCoreServices(services, credential);
        return services;
    }

    /// <summary>
    /// Sets up resilient-task services with an explicit hosted-storage credential and project
    /// endpoint. Use the host-builder overload when binding these values from configuration.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="credential">The credential for hosted task storage.</param>
    /// <param name="endpoint">The Azure AI Foundry project endpoint.</param>
    /// <returns>The service collection.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static IServiceCollection AddResilientTasks(
        this IServiceCollection services,
        TokenCredential credential,
        Uri endpoint)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(credential);
        ArgumentNullException.ThrowIfNull(endpoint);
        if (!endpoint.IsAbsoluteUri)
        {
            throw new ArgumentException(
                "The task-storage endpoint must be an absolute URI.",
                nameof(endpoint));
        }

        EnsureCoreServices(services, credential, endpoint);
        return services;
    }

    /// <summary>
    /// Registers a one-shot task (Python <c>@task</c>) and returns a typed
    /// <see cref="TaskDefinition{TInput, TOutput}"/> handle bound to it. The handle is also
    /// registered as a keyed singleton service — keyed by <paramref name="name"/> — so it can be
    /// resolved later with <see cref="ResilientTaskServiceProviderExtensions.GetResilientTask{TInput, TOutput}(IServiceProvider, string)"/>.
    /// The first call to any <c>AddResilientTask</c>/<c>AddResilientMultiTurnTask</c> method sets up
    /// the resilient-tasks services if they are not already present.
    /// </summary>
    /// <typeparam name="TInput">The task input type.</typeparam>
    /// <typeparam name="TOutput">The task output type.</typeparam>
    /// <param name="services">The service collection.</param>
    /// <param name="name">The unique task name.</param>
    /// <param name="handler">The handler delegate.</param>
    /// <param name="configure">An optional callback to configure per-task options.</param>
    /// <returns>A typed <see cref="TaskDefinition{TInput, TOutput}"/> for running the registered task.</returns>
    [RequiresUnreferencedCode(DefaultResilientTaskBuilder.ReflectionTrimWarning)]
    [RequiresDynamicCode(DefaultResilientTaskBuilder.ReflectionAotWarning)]
    public static TaskDefinition<TInput, TOutput> AddResilientTask<TInput, TOutput>(
        this IServiceCollection services,
        string name,
        Func<TaskContext<TInput>, CancellationToken, Task<TOutput>> handler,
        Action<TaskRegistrationOptions>? configure = null)
    {
        ArgumentNullException.ThrowIfNull(services);
        ValidateRegistrationArguments(name, handler);
        DefaultResilientTaskBuilder registrar = EnsureCoreServices(services, credential: null);
        TaskDefinition<TInput, TOutput> definition = registrar.AddTask(name, handler, configure);
        RegisterDefinition(services, name, definition);
        return definition;
    }

    /// <summary>
    /// Registers a one-shot task whose handler and dependencies are resolved from a fresh
    /// dependency-injection scope for each execution attempt.
    /// </summary>
    /// <typeparam name="TInput">The task input type.</typeparam>
    /// <typeparam name="TOutput">The task output type.</typeparam>
    /// <typeparam name="THandler">The scoped task handler type.</typeparam>
    /// <param name="services">The service collection.</param>
    /// <param name="name">The unique task name.</param>
    /// <param name="configure">An optional callback to configure per-task options.</param>
    /// <returns>A typed task definition for running the registered task.</returns>
    [RequiresUnreferencedCode(DefaultResilientTaskBuilder.ReflectionTrimWarning)]
    [RequiresDynamicCode(DefaultResilientTaskBuilder.ReflectionAotWarning)]
    public static TaskDefinition<TInput, TOutput> AddResilientTask<
        TInput,
        TOutput,
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] THandler>(
        this IServiceCollection services,
        string name,
        Action<TaskRegistrationOptions>? configure = null)
        where THandler : class, IResilientTaskHandler<TInput, TOutput>
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        DefaultResilientTaskBuilder registrar = EnsureCoreServices(services, credential: null);
        TaskDefinition<TInput, TOutput> definition = registrar.AddTask<TInput, TOutput>(
            name,
            (serviceProvider, context, cancellationToken) =>
                serviceProvider.GetRequiredKeyedService<IResilientTaskHandler<TInput, TOutput>>(name)
                    .RunAsync(context, cancellationToken),
            configure);
        services.TryAddKeyedScoped<IResilientTaskHandler<TInput, TOutput>, THandler>(name);
        RegisterDefinition(services, name, definition);
        return definition;
    }

    /// <summary>
    /// Registers a one-shot task using a source-generated <see cref="JsonTypeInfo{T}"/> for the
    /// input type, so the task input is serialized without runtime reflection (Native-AOT /
    /// trimming-safe). The returned handle is also registered as a keyed singleton service, keyed
    /// by <paramref name="name"/>.
    /// </summary>
    /// <typeparam name="TInput">The task input type.</typeparam>
    /// <typeparam name="TOutput">The task output type.</typeparam>
    /// <param name="services">The service collection.</param>
    /// <param name="name">The unique task name.</param>
    /// <param name="handler">The handler delegate.</param>
    /// <param name="inputTypeInfo">The source-generated serialization metadata for <typeparamref name="TInput"/>.</param>
    /// <param name="configure">An optional callback to configure per-task options.</param>
    /// <returns>A typed <see cref="TaskDefinition{TInput, TOutput}"/> for running the registered task.</returns>
    public static TaskDefinition<TInput, TOutput> AddResilientTask<TInput, TOutput>(
        this IServiceCollection services,
        string name,
        Func<TaskContext<TInput>, CancellationToken, Task<TOutput>> handler,
#pragma warning disable AZC0014 // JsonTypeInfo<T> is the sanctioned Native-AOT escape hatch (see Azure.Search.Documents).
        JsonTypeInfo<TInput> inputTypeInfo,
#pragma warning restore AZC0014
        Action<TaskRegistrationOptions>? configure = null)
    {
        ArgumentNullException.ThrowIfNull(services);
        ValidateRegistrationArguments(name, handler);
        ArgumentNullException.ThrowIfNull(inputTypeInfo);
        DefaultResilientTaskBuilder registrar = EnsureCoreServices(services, credential: null);
        TaskDefinition<TInput, TOutput> definition = registrar.AddTask(name, handler, inputTypeInfo, configure);
        RegisterDefinition(services, name, definition);
        return definition;
    }

    /// <summary>
    /// Registers a one-shot scoped task handler using source-generated input serialization metadata.
    /// </summary>
    /// <typeparam name="TInput">The task input type.</typeparam>
    /// <typeparam name="TOutput">The task output type.</typeparam>
    /// <typeparam name="THandler">The scoped task handler type.</typeparam>
    /// <param name="services">The service collection.</param>
    /// <param name="name">The unique task name.</param>
    /// <param name="inputTypeInfo">The source-generated serialization metadata for the input.</param>
    /// <param name="configure">An optional callback to configure per-task options.</param>
    /// <returns>A typed task definition for running the registered task.</returns>
    public static TaskDefinition<TInput, TOutput> AddResilientTask<
        TInput,
        TOutput,
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] THandler>(
        this IServiceCollection services,
        string name,
#pragma warning disable AZC0014 // JsonTypeInfo<T> is the sanctioned Native-AOT escape hatch (see Azure.Search.Documents).
        JsonTypeInfo<TInput> inputTypeInfo,
#pragma warning restore AZC0014
        Action<TaskRegistrationOptions>? configure = null)
        where THandler : class, IResilientTaskHandler<TInput, TOutput>
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentNullException.ThrowIfNull(inputTypeInfo);
        DefaultResilientTaskBuilder registrar = EnsureCoreServices(services, credential: null);
        TaskDefinition<TInput, TOutput> definition = registrar.AddTask<TInput, TOutput>(
            name,
            (serviceProvider, context, cancellationToken) =>
                serviceProvider.GetRequiredKeyedService<IResilientTaskHandler<TInput, TOutput>>(name)
                    .RunAsync(context, cancellationToken),
            inputTypeInfo,
            configure);
        services.TryAddKeyedScoped<IResilientTaskHandler<TInput, TOutput>, THandler>(name);
        RegisterDefinition(services, name, definition);
        return definition;
    }

    /// <summary>
    /// Registers a multi-turn task (Python <c>@multi_turn_task</c>), optionally steerable, and
    /// returns a typed <see cref="TaskDefinition{TInput, TOutput}"/> handle bound to it. The handle
    /// is also registered as a keyed singleton service — keyed by <paramref name="name"/> — so it
    /// can be resolved later with <see cref="ResilientTaskServiceProviderExtensions.GetResilientTask{TInput, TOutput}(IServiceProvider, string)"/>.
    /// The first call to any <c>AddResilientTask</c>/<c>AddResilientMultiTurnTask</c> method sets up
    /// the resilient-tasks services if they are not already present.
    /// </summary>
    /// <typeparam name="TInput">The task input type.</typeparam>
    /// <typeparam name="TOutput">The task output type.</typeparam>
    /// <param name="services">The service collection.</param>
    /// <param name="name">The unique task name.</param>
    /// <param name="handler">The handler delegate.</param>
    /// <param name="steerable">Whether the task accepts steering input.</param>
    /// <param name="configure">An optional callback to configure per-task options.</param>
    /// <returns>A typed <see cref="TaskDefinition{TInput, TOutput}"/> for running the registered task.</returns>
    [RequiresUnreferencedCode(DefaultResilientTaskBuilder.ReflectionTrimWarning)]
    [RequiresDynamicCode(DefaultResilientTaskBuilder.ReflectionAotWarning)]
    public static TaskDefinition<TInput, TOutput> AddResilientMultiTurnTask<TInput, TOutput>(
        this IServiceCollection services,
        string name,
        Func<TaskContext<TInput>, CancellationToken, Task<TOutput>> handler,
        bool steerable = false,
        Action<TaskRegistrationOptions>? configure = null)
    {
        ArgumentNullException.ThrowIfNull(services);
        ValidateRegistrationArguments(name, handler);
        DefaultResilientTaskBuilder registrar = EnsureCoreServices(services, credential: null);
        TaskDefinition<TInput, TOutput> definition = registrar.AddMultiTurnTask(name, handler, steerable, configure);
        RegisterDefinition(services, name, definition);
        return definition;
    }

    /// <summary>
    /// Registers a multi-turn task whose steerability is resolved when a run starts.
    /// </summary>
    /// <typeparam name="TInput">The task input type.</typeparam>
    /// <typeparam name="TOutput">The task output type.</typeparam>
    /// <param name="services">The service collection.</param>
    /// <param name="name">The unique task name.</param>
    /// <param name="handler">The handler delegate.</param>
    /// <param name="isSteerable">Resolves whether the task accepts steering.</param>
    /// <param name="configure">An optional callback to configure per-task options.</param>
    /// <returns>A typed task definition.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [RequiresUnreferencedCode(DefaultResilientTaskBuilder.ReflectionTrimWarning)]
    [RequiresDynamicCode(DefaultResilientTaskBuilder.ReflectionAotWarning)]
    public static TaskDefinition<TInput, TOutput> AddResilientMultiTurnTask<TInput, TOutput>(
        this IServiceCollection services,
        string name,
        Func<TaskContext<TInput>, CancellationToken, Task<TOutput>> handler,
        Func<bool> isSteerable,
        Action<TaskRegistrationOptions>? configure = null)
    {
        ArgumentNullException.ThrowIfNull(services);
        ValidateRegistrationArguments(name, handler);
        ArgumentNullException.ThrowIfNull(isSteerable);
        DefaultResilientTaskBuilder registrar = EnsureCoreServices(services, credential: null);
        TaskDefinition<TInput, TOutput> definition =
            registrar.AddMultiTurnTask(name, handler, isSteerable, configure);
        RegisterDefinition(services, name, definition);
        return definition;
    }

    /// <summary>
    /// Registers a multi-turn task whose handler and dependencies are resolved from a fresh
    /// dependency-injection scope for each execution attempt.
    /// </summary>
    /// <typeparam name="TInput">The task input type.</typeparam>
    /// <typeparam name="TOutput">The task output type.</typeparam>
    /// <typeparam name="THandler">The scoped task handler type.</typeparam>
    /// <param name="services">The service collection.</param>
    /// <param name="name">The unique task name.</param>
    /// <param name="steerable">Whether the task accepts steering input.</param>
    /// <param name="configure">An optional callback to configure per-task options.</param>
    /// <returns>A typed task definition for running the registered task.</returns>
    [RequiresUnreferencedCode(DefaultResilientTaskBuilder.ReflectionTrimWarning)]
    [RequiresDynamicCode(DefaultResilientTaskBuilder.ReflectionAotWarning)]
    public static TaskDefinition<TInput, TOutput> AddResilientMultiTurnTask<
        TInput,
        TOutput,
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] THandler>(
        this IServiceCollection services,
        string name,
        bool steerable = false,
        Action<TaskRegistrationOptions>? configure = null)
        where THandler : class, IResilientTaskHandler<TInput, TOutput>
        => AddResilientMultiTurnTask<TInput, TOutput, THandler>(
            services,
            name,
            () => steerable,
            configure);

    /// <summary>
    /// Registers a scoped multi-turn task whose steerability is resolved when a run starts.
    /// </summary>
    /// <typeparam name="TInput">The task input type.</typeparam>
    /// <typeparam name="TOutput">The task output type.</typeparam>
    /// <typeparam name="THandler">The scoped task handler type.</typeparam>
    /// <param name="services">The service collection.</param>
    /// <param name="name">The unique task name.</param>
    /// <param name="isSteerable">Resolves whether the task accepts steering.</param>
    /// <param name="configure">An optional callback to configure per-task options.</param>
    /// <returns>A typed task definition for running the registered task.</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [RequiresUnreferencedCode(DefaultResilientTaskBuilder.ReflectionTrimWarning)]
    [RequiresDynamicCode(DefaultResilientTaskBuilder.ReflectionAotWarning)]
    public static TaskDefinition<TInput, TOutput> AddResilientMultiTurnTask<
        TInput,
        TOutput,
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] THandler>(
        this IServiceCollection services,
        string name,
        Func<bool> isSteerable,
        Action<TaskRegistrationOptions>? configure = null)
        where THandler : class, IResilientTaskHandler<TInput, TOutput>
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentNullException.ThrowIfNull(isSteerable);
        DefaultResilientTaskBuilder registrar = EnsureCoreServices(services, credential: null);
        TaskDefinition<TInput, TOutput> definition = registrar.AddMultiTurnTask<TInput, TOutput>(
            name,
            (serviceProvider, context, cancellationToken) =>
                serviceProvider.GetRequiredKeyedService<IResilientTaskHandler<TInput, TOutput>>(name)
                    .RunAsync(context, cancellationToken),
            isSteerable,
            configure);
        services.TryAddKeyedScoped<IResilientTaskHandler<TInput, TOutput>, THandler>(name);
        RegisterDefinition(services, name, definition);
        return definition;
    }

    /// <summary>
    /// Registers a multi-turn task (optionally steerable) using a source-generated
    /// <see cref="JsonTypeInfo{T}"/> for the input type (Native-AOT / trimming-safe). The returned
    /// handle is also registered as a keyed singleton service, keyed by <paramref name="name"/>.
    /// </summary>
    /// <typeparam name="TInput">The task input type.</typeparam>
    /// <typeparam name="TOutput">The task output type.</typeparam>
    /// <param name="services">The service collection.</param>
    /// <param name="name">The unique task name.</param>
    /// <param name="handler">The handler delegate.</param>
    /// <param name="inputTypeInfo">The source-generated serialization metadata for <typeparamref name="TInput"/>.</param>
    /// <param name="steerable">Whether the task accepts steering input.</param>
    /// <param name="configure">An optional callback to configure per-task options.</param>
    /// <returns>A typed <see cref="TaskDefinition{TInput, TOutput}"/> for running the registered task.</returns>
    public static TaskDefinition<TInput, TOutput> AddResilientMultiTurnTask<TInput, TOutput>(
        this IServiceCollection services,
        string name,
        Func<TaskContext<TInput>, CancellationToken, Task<TOutput>> handler,
#pragma warning disable AZC0014 // JsonTypeInfo<T> is the sanctioned Native-AOT escape hatch (see Azure.Search.Documents).
        JsonTypeInfo<TInput> inputTypeInfo,
#pragma warning restore AZC0014
        bool steerable = false,
        Action<TaskRegistrationOptions>? configure = null)
    {
        ArgumentNullException.ThrowIfNull(services);
        ValidateRegistrationArguments(name, handler);
        ArgumentNullException.ThrowIfNull(inputTypeInfo);
        DefaultResilientTaskBuilder registrar = EnsureCoreServices(services, credential: null);
        TaskDefinition<TInput, TOutput> definition = registrar.AddMultiTurnTask(name, handler, inputTypeInfo, steerable, configure);
        RegisterDefinition(services, name, definition);
        return definition;
    }

    private static void ValidateRegistrationArguments<TInput, TOutput>(
        string name,
        Func<TaskContext<TInput>, CancellationToken, Task<TOutput>> handler)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentNullException.ThrowIfNull(handler);
    }

    private static void RegisterDefinition<TInput, TOutput>(
        IServiceCollection services,
        string name,
        TaskDefinition<TInput, TOutput> definition)
    {
        services.AddKeyedSingleton<TaskDefinition<TInput, TOutput>>(
            name,
            (serviceProvider, _) =>
            {
                _ = serviceProvider.GetRequiredService<TaskEngine>();
                return definition;
            });
    }

    /// <summary>
    /// Registers a multi-turn scoped task handler using source-generated input serialization metadata.
    /// </summary>
    /// <typeparam name="TInput">The task input type.</typeparam>
    /// <typeparam name="TOutput">The task output type.</typeparam>
    /// <typeparam name="THandler">The scoped task handler type.</typeparam>
    /// <param name="services">The service collection.</param>
    /// <param name="name">The unique task name.</param>
    /// <param name="inputTypeInfo">The source-generated serialization metadata for the input.</param>
    /// <param name="steerable">Whether the task accepts steering input.</param>
    /// <param name="configure">An optional callback to configure per-task options.</param>
    /// <returns>A typed task definition for running the registered task.</returns>
    public static TaskDefinition<TInput, TOutput> AddResilientMultiTurnTask<
        TInput,
        TOutput,
        [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] THandler>(
        this IServiceCollection services,
        string name,
#pragma warning disable AZC0014 // JsonTypeInfo<T> is the sanctioned Native-AOT escape hatch (see Azure.Search.Documents).
        JsonTypeInfo<TInput> inputTypeInfo,
#pragma warning restore AZC0014
        bool steerable = false,
        Action<TaskRegistrationOptions>? configure = null)
        where THandler : class, IResilientTaskHandler<TInput, TOutput>
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentNullException.ThrowIfNull(inputTypeInfo);
        DefaultResilientTaskBuilder registrar = EnsureCoreServices(services, credential: null);
        TaskDefinition<TInput, TOutput> definition = registrar.AddMultiTurnTask<TInput, TOutput>(
            name,
            (serviceProvider, context, cancellationToken) =>
                serviceProvider.GetRequiredKeyedService<IResilientTaskHandler<TInput, TOutput>>(name)
                    .RunAsync(context, cancellationToken),
            inputTypeInfo,
            steerable,
            configure);
        services.TryAddKeyedScoped<IResilientTaskHandler<TInput, TOutput>, THandler>(name);
        RegisterDefinition(services, name, definition);
        return definition;
    }

    /// <summary>
    /// Idempotently sets up the resilient-tasks services (registry, environment, store, engine,
    /// recovery scanner, durability hosted service) and returns the registrar over the canonical
    /// registry/accessor the container holds — the same instances every registration call, whether
    /// via <c>AddResilientTasks</c> or a flat <c>AddResilientTask</c>/<c>AddResilientMultiTurnTask</c>
    /// call, must target.
    /// </summary>
    private static DefaultResilientTaskBuilder EnsureCoreServices(
        IServiceCollection services,
        TokenCredential? credential,
        Uri? endpoint = null)
    {
        // Resilient-tasks services are set up once per process. Everything below uses
        // TryAddSingleton (first-wins), but AddHostedService is NOT idempotent — a second call
        // would register a duplicate TaskDurabilityService, running the recovery scan twice. Guard
        // the whole method: on a repeat call, register nothing further and hand back a registrar over
        // the already-registered registry. A later host integration may still attach the first
        // non-null credential to the shared environment holder, making registration order independent.
        if (IsAlreadyRegistered(services))
        {
            // The registry and accessor are registered together with the TaskEngine on the first
            // call, so if the engine is present they must be too. Fail fast rather than fabricating
            // new instances: a registrar over a fresh registry/accessor would silently orphan every
            // subsequent registration (the already-registered engine keeps using the originals).
            TaskRegistry existingRegistry = ResolveRegistered(services)
                ?? throw new InvalidOperationException(
                    "Resilient-tasks services are in an inconsistent state: a TaskEngine is registered " +
                    "but its TaskRegistry is not. Ensure the resilient-tasks services are not registered " +
                    "piecemeal.");
            TaskEngineAccessor existingAccessor = ResolveRegisteredAccessor(services)
                ?? throw new InvalidOperationException(
                    "Resilient-tasks services are in an inconsistent state: a TaskEngine is registered " +
                    "but its TaskEngineAccessor is not. Ensure the resilient-tasks services are not " +
                    "registered piecemeal.");
            TaskHostEnvironment existingEnvironment = ResolveRegisteredEnvironment(services)
                ?? throw new InvalidOperationException(
                    "Resilient-tasks services are in an inconsistent state: a TaskEngine is registered " +
                    "but its TaskHostEnvironment is not. Ensure the resilient-tasks services are not " +
                    "registered piecemeal.");
            existingEnvironment.AttachConfiguration(credential, endpoint);

            return new DefaultResilientTaskBuilder(existingRegistry, existingAccessor);
        }

        var registry = new TaskRegistry();
        services.TryAddSingleton(registry);

        var engineAccessor = new TaskEngineAccessor();
        services.TryAddSingleton(engineAccessor);

        var environment = new TaskHostEnvironment(credential, endpoint);
        services.TryAddSingleton(environment);
        services.AddAgentEventStreams();

        // The store is environment-selected: filesystem-backed locally, hosted in Foundry.
        services.TryAddSingleton<ITaskStore>(sp =>
        {
            return TaskStoreSelector.Create(hostedFactory: () =>
            {
                var env = sp.GetRequiredService<TaskHostEnvironment>();
                TokenCredential? cred = env.Endpoint is not null
                    ? env.Credential
                    : sp.GetService<TokenCredential>() ?? env.Credential;
                if (cred is null)
                {
                    throw new InvalidOperationException(
                        "A TokenCredential is required for hosted task storage. Call " +
                        "AddResilientTasks(credential) or register TokenCredential while composing " +
                        "services when running in a hosted environment.");
                }

                if (env.Endpoint is null)
                {
                    // Without explicit endpoint-bound settings, publish the provider's effective
                    // credential onto the shared holder and reject any explicit/DI mismatch.
                    env.AttachConfiguration(cred, endpoint: null);
                }

                Uri? configuredEndpoint = env.Endpoint;
                string? environmentEndpoint = FoundryEnvironment.ProjectEndpoint;
                if (configuredEndpoint is null && string.IsNullOrWhiteSpace(environmentEndpoint))
                {
                    throw new InvalidOperationException(
                        "FoundryEnvironment.ProjectEndpoint (FOUNDRY_PROJECT_ENDPOINT) is required for hosted task storage.");
                }

                if (configuredEndpoint is null
                    && !Uri.TryCreate(environmentEndpoint, UriKind.Absolute, out configuredEndpoint))
                {
                    throw new InvalidOperationException(
                        "FoundryEnvironment.ProjectEndpoint contains an invalid absolute URI.");
                }

                // Base URL is `{FOUNDRY_PROJECT_ENDPOINT}/tasks` — the project endpoint already
                // targets the storage surface, so no extra `/storage` segment is added (matches the
                // Foundry task-storage client that runs against the live backend).
                var storageBaseUri = new Uri(
                    configuredEndpoint.GetLeftPart(UriPartial.Path).TrimEnd('/') + "/");

                var options = new HostedTaskStoreClientOptions();

                var registry = sp.GetService<ServerVersionRegistry>();
                if (registry is not null)
                {
                    options.AddPolicy(new ServerVersionPolicy(registry), HttpPipelinePosition.PerCall);
                }

                var loggerFactory = sp.GetService<ILoggerFactory>();
                var logger = loggerFactory?.CreateLogger<HostedTaskStoreLoggingPolicy>()
                    ?? (ILogger)NullLogger.Instance;
                options.AddPolicy(new HostedTaskStoreLoggingPolicy(logger), HttpPipelinePosition.PerRetry);

                const string FoundryStorageScope = "https://ai.azure.com/.default";
                var pipeline = HttpPipelineBuilder.Build(
                    options,
                    new BearerTokenAuthenticationPolicy(cred, FoundryStorageScope));

                return new HostedTaskStore(pipeline, storageBaseUri);
            });
        });

        // Resolve the canonical registry actually held by the container: TryAddSingleton is a
        // no-op if one was already registered, so the registrar must wrap that instance (not the
        // freshly-constructed local) or registrations would target an orphaned registry.
        TaskRegistry canonical = ResolveRegistered(services) ?? registry;
        TaskEngineAccessor canonicalAccessor = ResolveRegisteredAccessor(services) ?? engineAccessor;

        services.TryAddSingleton<TaskEngine>(sp =>
        {
            ITaskStore store = sp.GetRequiredService<ITaskStore>();
            TaskRegistry reg = sp.GetRequiredService<TaskRegistry>();
            ILoggerFactory? loggerFactory = sp.GetService<ILoggerFactory>();
            ILogger logger = loggerFactory?.CreateLogger(TaskTelemetry.Category)
                ?? NullLogger.Instance;
            (string agentName, string sessionId) = ResolveScope();

            var engine = new TaskEngine(
                store,
                reg,
                agentName,
                sessionId,
                sp.GetRequiredService<AgentEventStreamRegistry>(),
                logger,
                sp.GetRequiredService<IServiceScopeFactory>());

            // Late-bind the engine so a TaskDefinition (created at registration time, before the
            // container existed) can resolve it at invocation time. The engine is always resolved
            // before any task runs, so populating here guarantees the accessor is ready.
            sp.GetRequiredService<TaskEngineAccessor>().Bind(engine);

            return engine;
        });

        // FR-022 durability: the recovery scanner + background service must be driven by the host
        // lifespan. Without this wiring the cold-start recovery scan (SOT §49) and the periodic
        // reclaim sweep never run, so crashed/interrupted tasks are never auto-recovered.
        services.TryAddSingleton<RecoveryScanner>(sp =>
            new RecoveryScanner(sp.GetRequiredService<TaskEngine>()));
        services.TryAddSingleton<TaskDurabilityService>(sp =>
        {
            ILoggerFactory? loggerFactory = sp.GetService<ILoggerFactory>();
            ILogger logger = loggerFactory?.CreateLogger(TaskTelemetry.Category)
                ?? NullLogger.Instance;
            return new TaskDurabilityService(
                sp.GetRequiredService<RecoveryScanner>(),
                sp.GetRequiredService<TaskEngine>(),
                scanInterval: null,
                shutdownGrace: null,
                logger);
        });
        services.AddHostedService(sp => sp.GetRequiredService<TaskDurabilityService>());

        return new DefaultResilientTaskBuilder(canonical, canonicalAccessor);
    }

    private static (string AgentName, string SessionId) ResolveScope()
    {
        string agentName = string.IsNullOrEmpty(FoundryEnvironment.AgentName)
            ? TaskEngineConstants.DefaultAgentName
            : FoundryEnvironment.AgentName!;
        string sessionId = string.IsNullOrEmpty(FoundryEnvironment.SessionId)
            ? TaskEngineConstants.DefaultSessionId
            : FoundryEnvironment.SessionId!;
        return (agentName, sessionId);
    }

    private static bool IsAlreadyRegistered(IServiceCollection services)
    {
        for (int i = 0; i < services.Count; i++)
        {
            if (services[i].ServiceType == typeof(TaskEngine))
            {
                return true;
            }
        }

        return false;
    }

    private static TaskRegistry? ResolveRegistered(IServiceCollection services)
    {
        for (int i = 0; i < services.Count; i++)
        {
            ServiceDescriptor descriptor = services[i];
            if (descriptor.ServiceType == typeof(TaskRegistry) &&
                descriptor.ImplementationInstance is TaskRegistry existing)
            {
                return existing;
            }
        }

        return null;
    }

    private static TaskEngineAccessor? ResolveRegisteredAccessor(IServiceCollection services)
    {
        for (int i = 0; i < services.Count; i++)
        {
            ServiceDescriptor descriptor = services[i];
            if (descriptor.ServiceType == typeof(TaskEngineAccessor) &&
                descriptor.ImplementationInstance is TaskEngineAccessor existing)
            {
                return existing;
            }
        }

        return null;
    }

    private static TaskHostEnvironment? ResolveRegisteredEnvironment(IServiceCollection services)
    {
        for (int i = 0; i < services.Count; i++)
        {
            ServiceDescriptor descriptor = services[i];
            if (descriptor.ServiceType == typeof(TaskHostEnvironment) &&
                descriptor.ImplementationInstance is TaskHostEnvironment existing)
            {
                return existing;
            }
        }

        return null;
    }
}
