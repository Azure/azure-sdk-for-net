// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
/// Registration entry point for the resilient-tasks feature. There is no global
/// configuration object: backend selection (local/hosted), lease durations, and
/// retry/timeout defaults are not developer-configurable (Python parity). The
/// optional <see cref="TokenCredential"/> is the only knob; it is required when
/// running against hosted task storage and ignored by the local file-backed store.
/// </summary>
public static class ResilientTaskServiceCollectionExtensions
{
    /// <summary>
    /// Adds the resilient-tasks services and returns a builder for registering tasks.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="credential">A credential for hosted-mode authentication. Required when running in a hosted environment.</param>
    /// <returns>An <see cref="ResilientTaskBuilder"/> for registering tasks.</returns>
    public static ResilientTaskBuilder AddResilientTasks(
        this IServiceCollection services,
        TokenCredential? credential = null)
    {
        ArgumentNullException.ThrowIfNull(services);

        // Resilient-tasks services are registered once per process. Everything below uses
        // TryAddSingleton (first-wins), but AddHostedService is NOT idempotent — a second call
        // would register a duplicate TaskDurabilityService, running the recovery scan twice. Guard
        // the whole method: on a repeat call, register nothing further and hand back a builder over
        // the already-registered registry. A repeat call that supplies a credential cannot be
        // honored (the first registration wins), so surface that as an error rather than discarding
        // it silently.
        if (IsAlreadyRegistered(services))
        {
            if (credential is not null)
            {
                throw new InvalidOperationException(
                    "AddResilientTasks has already been called; resilient-tasks services are " +
                    "registered once per process. Remove the duplicate call, or pass the credential " +
                    "only on the first call.");
            }

            TaskRegistry existingRegistry = ResolveRegistered(services) ?? new TaskRegistry();
            return new DefaultResilientTaskBuilder(existingRegistry);
        }

        var registry = new TaskRegistry();
        services.TryAddSingleton(registry);

        var environment = new TaskHostEnvironment(credential);
        services.TryAddSingleton(environment);

        // The store is environment-selected: filesystem-backed locally, hosted in Foundry.
        services.TryAddSingleton<ITaskStore>(sp =>
        {
            return TaskStoreSelector.Create(hostedFactory: () =>
            {
                var env = sp.GetRequiredService<TaskHostEnvironment>();
                var cred = env.Credential;
                if (cred is null)
                {
                    throw new InvalidOperationException(
                        "A TokenCredential is required for hosted task storage. " +
                        "Pass a credential to AddResilientTasks() when running in a hosted environment.");
                }

                var endpoint = FoundryEnvironment.ProjectEndpoint;
                if (string.IsNullOrWhiteSpace(endpoint))
                {
                    throw new InvalidOperationException(
                        "FoundryEnvironment.ProjectEndpoint (FOUNDRY_PROJECT_ENDPOINT) is required for hosted task storage.");
                }

                if (!Uri.TryCreate(endpoint, UriKind.Absolute, out var baseUri))
                {
                    throw new InvalidOperationException(
                        "FoundryEnvironment.ProjectEndpoint contains an invalid absolute URI.");
                }

                // Base URL is `{FOUNDRY_PROJECT_ENDPOINT}/tasks` — the project endpoint already
                // targets the storage surface, so no extra `/storage` segment is added (matches the
                // Foundry task-storage client that runs against the live backend).
                var storageBaseUri = new Uri(baseUri.GetLeftPart(UriPartial.Path).TrimEnd('/') + "/");

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
        // no-op if one was already registered, so the builder must wrap that instance (not the
        // freshly-constructed local) or registrations would target an orphaned registry.
        TaskRegistry canonical = ResolveRegistered(services) ?? registry;

        services.TryAddSingleton<TaskEngine>(sp =>
        {
            ITaskStore store = sp.GetRequiredService<ITaskStore>();
            TaskRegistry reg = sp.GetRequiredService<TaskRegistry>();
            ILoggerFactory? loggerFactory = sp.GetService<ILoggerFactory>();
            ILogger logger = loggerFactory?.CreateLogger(TaskTelemetry.Category)
                ?? NullLogger.Instance;
            (string agentName, string sessionId) = ResolveScope();

            return new TaskEngine(store, reg, agentName, sessionId, logger);
        });
        services.TryAddSingleton<ITaskInvoker>(sp => sp.GetRequiredService<TaskEngine>());
        services.TryAddSingleton<IMultiTurnTask>(sp => sp.GetRequiredService<TaskEngine>());

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

        return new DefaultResilientTaskBuilder(canonical);
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
}
