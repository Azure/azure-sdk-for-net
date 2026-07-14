// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Core.Streaming;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Internal.Resilience;
using Azure.AI.AgentServer.Responses.Models;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Extension methods for <see cref="IServiceCollection"/> to register
/// the Responses API server SDK services.
/// </summary>
public static class ResponsesServerServiceCollectionExtensions
{
    /// <summary>
    /// The OAuth scope used for authenticating with the Azure AI Foundry storage API.
    /// </summary>
    internal const string FoundryStorageScope = "https://ai.azure.com/.default";

    /// <summary>
    /// Registers the Responses API server SDK services into the dependency injection container.
    /// </summary>
    /// <param name="services">The service collection to add services to.</param>
    /// <param name="configure">Optional callback to configure <see cref="ResponsesServerOptions"/>.</param>
    /// <returns>The service collection for chaining.</returns>
    public static IServiceCollection AddResponsesServer(
        this IServiceCollection services,
        Action<ResponsesServerOptions>? configure = null)
    {
        if (configure is not null)
        {
            services.Configure(configure);
        }
        else
        {
            services.Configure<ResponsesServerOptions>(_ => { });
        }

        // Register InMemoryProviderOptions with defaults
        services.Configure<InMemoryProviderOptions>(_ => { });

        // PostConfigure: apply environment variable overrides for SDK-level options
        services.PostConfigure<ResponsesServerOptions>(options =>
        {
            if (options.DefaultFetchHistoryCount == ResponsesServerOptions.DefaultFetchHistoryCountValue)
            {
                var envValue = Environment.GetEnvironmentVariable(
                    "DEFAULT_FETCH_HISTORY_ITEM_COUNT");
                if (!string.IsNullOrEmpty(envValue)
                    && int.TryParse(envValue, out var count) && count > 0)
                {
                    options.DefaultFetchHistoryCount = count;
                }
            }
        });

        services.TryAddSingleton(TimeProvider.System);

        // Register the default ActivitySource wrapper as a singleton.
        // TryAddSingleton: consumers who register a custom ResponsesActivitySource subclass
        // before calling AddResponsesServer() take precedence.
        services.TryAddSingleton<ResponsesActivitySource>();

        // InMemoryResponsesProvider is always registered: it backs
        // ResponsesCancellationSignalProvider even when FoundryStorageProvider handles
        // ResponsesProvider in hosted environments.
        services.TryAddSingleton<InMemoryResponsesProvider>();
        services.TryAddSingleton<ResponsesCancellationSignalProvider>(sp =>
            new InMemoryCancellationSignalProvider(sp.GetRequiredService<InMemoryResponsesProvider>()));

        // SSE streaming is composed on the Core event-stream primitive (registered via
        // AddEventStreams below), not a pluggable Responses stream provider.

        TokenCredential? resilientTaskCredential = null;

        // Auto-detect hosted environment: when FoundryEnvironment.IsHosted is true,
        // meaning the .NET hosting environment is not Development and
        // FOUNDRY_PROJECT_ENDPOINT, FOUNDRY_AGENT_NAME, and FOUNDRY_AGENT_VERSION are all configured,
        // use FoundryStorageProvider for persistence; otherwise use in-memory.
        if (FoundryEnvironment.IsHosted)
        {
            resilientTaskCredential = new DefaultAzureCredential();
            services.TryAddSingleton<TokenCredential>(_ => resilientTaskCredential);

            // Build the Azure.Core HttpPipeline with BearerTokenAuthenticationPolicy.
            // This automatically provides: retry, request ID, user-agent telemetry,
            // distributed tracing, logging, and token caching.
            // The ServerVersionPolicy prepends the composed server version (from all
            // registered protocols and developer segments) to the User-Agent header.
            // The FoundryStorageLoggingPolicy is added as a per-retry policy so each
            // attempt (including retries) is logged with correlation headers.
            services.TryAddSingleton(sp =>
            {
                var credential = sp.GetRequiredService<TokenCredential>();
                var logger = sp.GetRequiredService<ILoggerFactory>().CreateLogger<FoundryStorageLoggingPolicy>();
                var options = new FoundryStorageClientOptions();

                var registry = sp.GetService<ServerVersionRegistry>();
                if (registry is not null)
                {
                    options.AddPolicy(new ServerVersionPolicy(registry), HttpPipelinePosition.PerCall);
                }

                options.AddPolicy(new FoundryStorageLoggingPolicy(logger), HttpPipelinePosition.PerRetry);

                return HttpPipelineBuilder.Build(
                    options,
                    new BearerTokenAuthenticationPolicy(credential, FoundryStorageScope));
            });

            services.TryAddSingleton<ResponsesProvider>(sp =>
            {
                var pipeline = sp.GetRequiredService<HttpPipeline>();
                var storageBaseUri = ResolveStorageBaseUri();
                return new FoundryStorageProvider(pipeline, storageBaseUri);
            });
        }
        else
        {
            // Local (non-hosted) environment. The durable filesystem-backed provider is the
            // default so response envelopes survive a process restart (single-sandbox auto-recovery)
            // with full fidelity locally — matching the Python implementation, where the file-backed
            // store is the local default. The InMemoryResponsesProvider remains registered (it backs
            // ResponsesCancellationSignalProvider) but is no longer selected as the ResponsesProvider;
            // it is effectively dead unless a consumer explicitly discovers and wires it up.
            services.TryAddSingleton<FileResponsesProvider>(_ => new FileResponsesProvider());
            services.TryAddSingleton<ResponsesProvider>(sp =>
                sp.GetRequiredService<FileResponsesProvider>());
        }

        // The Responses layer does not own an event-stream store. SSE events are published onto
        // the Core event-stream primitive (IEventStreamRegistry/IEventStream) — matching Python,
        // which uses the core EventStream registry directly. Register it once here. The backing is
        // chosen eagerly: local + ResilientBackground uses a durable file-backed replay so a
        // reconnecting client can replay pre-restart SSE events after a single-sandbox recovery;
        // otherwise an in-memory replay buffer is sufficient. TryAddSingleton in AddEventStreams
        // preserves consumer precedence (a custom IEventStreamRegistry registered first wins).
        var eagerOptions = new ResponsesServerOptions();
        configure?.Invoke(eagerOptions);
        var useDurableStreams = eagerOptions.ResilientBackground && !FoundryEnvironment.IsHosted;
        var streamTtl = new InMemoryProviderOptions().EventStreamTtl;
        services.AddEventStreams(o =>
        {
            if (useDurableStreams)
            {
                o.UseFileBackedReplay(
                    storageDirectory: Internal.Resilience.ResponsesStatePaths.StreamsRoot(),
                    cursor: payload => (int)((ResponseStreamEvent)payload).SequenceNumber,
                    ttl: streamTtl,
                    serializer: payload => ModelReaderWriter.Write(
                        (ResponseStreamEvent)payload,
                        ModelReaderWriterOptions.Json,
                        AzureAIAgentServerResponsesContext.Default).ToArray(),
                    deserializer: bytes => ModelReaderWriter.Read<ResponseStreamEvent>(
                        new BinaryData(bytes),
                        ModelReaderWriterOptions.Json,
                        AzureAIAgentServerResponsesContext.Default)!);
            }
            else
            {
                o.UseInMemoryReplay(
                    cursor: payload => (int)((ResponseStreamEvent)payload).SequenceNumber,
                    ttl: streamTtl);
            }
        });

        services.AddSingleton<ResponseExecutionTracker>();
        services.AddHostedService(sp => sp.GetRequiredService<ResponseExecutionTracker>());

        // Compose the Core resilient-task primitive (do NOT reinvent recovery/leasing/steering).
        // In a local sandbox the Core task subsystem is ALWAYS available — matching Python, whose
        // task subsystem is not gated on any option (`_pick_primitive` routes any conversation
        // through the multi-turn task, and every stored response is tracked by a task so the
        // next-lifetime recovery scan can act on it). The response orchestration runs INSIDE a Core
        // @task / @multi_turn_task: Core's task engine owns crash recovery (its TaskDurabilityService
        // cold-start scan), leasing, and steering. This composition is active in BOTH local and hosted
        // environments; hosted mode selects the hosted task store via AddResilientTasks(credential),
        // matching Python's hosted behavior.
        //
        // The multi-turn task is registered steerable only when SteerableConversations is set:
        // a non-steerable multi-turn conversation turns concurrent overlap into a Core lock conflict
        // (→ HTTP 409 conversation_locked), which is exactly the concurrency protection a plain
        // conversation_id chain requires. Checkpoint/durable-stream backing stays resilient-only
        // (see the useDurableStreams gate above) — this registration does not change that.
        IResilientTaskBuilder taskBuilder = resilientTaskCredential is null
            ? services.AddResilientTasks()
            : services.AddResilientTasks(resilientTaskCredential);
        taskBuilder.AddTask<ResponseTaskInput, ResponseTaskOutput>(
            ResponsesResilientTaskHandler.OneShotTaskName,
            (sp, ctx, ct) => ResponsesResilientTaskHandler.RunTurnAsync(sp, ctx, ct));
        taskBuilder.AddMultiTurnTask<ResponseTaskInput, ResponseTaskOutput>(
            ResponsesResilientTaskHandler.MultiTurnTaskName,
            (sp, ctx, ct) => ResponsesResilientTaskHandler.RunTurnAsync(sp, ctx, ct),
            steerable: eagerOptions.SteerableConversations);

        services.AddScoped<ResponseOrchestrator>();
        services.AddScoped<ResponseEndpointHandler>();
        services.AddScoped<ResponsesExceptionFilter>();

        // Log startup configuration when the host starts
        services.AddHostedService<ResponsesStartupLogger>();

        return services;
    }

    /// <summary>
    /// Resolves the Foundry storage base URI from the project endpoint environment variable.
    /// </summary>
    internal static Uri ResolveStorageBaseUri()
    {
        var endpoint = FoundryEnvironment.ProjectEndpoint;

        if (string.IsNullOrWhiteSpace(endpoint))
        {
            throw new InvalidOperationException(
                "FoundryEnvironment.ProjectEndpoint is required. " +
                "In hosted environments, the Azure AI Foundry platform must set the FOUNDRY_PROJECT_ENDPOINT variable.");
        }

        if (!Uri.TryCreate(endpoint, UriKind.Absolute, out var uri))
        {
            throw new InvalidOperationException(
                "FoundryEnvironment.ProjectEndpoint contains an invalid absolute URI.");
        }

        // Require HTTPS in non-development environments.
        var hostingEnv = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
            ?? Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT");
        bool isDevelopment = string.Equals(hostingEnv, "Development", StringComparison.OrdinalIgnoreCase);

        if (!isDevelopment
            && !string.Equals(uri.Scheme, Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException(
                "FoundryEnvironment.ProjectEndpoint must use the HTTPS scheme.");
        }

        return new Uri(uri.GetLeftPart(UriPartial.Path).TrimEnd('/') + "/storage/");
    }
}
