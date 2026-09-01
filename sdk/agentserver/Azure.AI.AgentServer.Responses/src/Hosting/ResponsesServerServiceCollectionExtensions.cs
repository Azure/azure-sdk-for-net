// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Core.Streaming;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Internal.Resilience;
using Azure.AI.AgentServer.Responses.Models;
using Azure.Core;
using Azure.Core.Pipeline;
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
    /// <para>
    /// This overload targets local / non-hosted scenarios (in-memory or file-backed storage), which
    /// require no Azure credential or endpoint. In a hosted Foundry environment the Foundry
    /// credential and endpoint must bind from configuration so response storage and resilient-task
    /// storage cannot diverge; register via
    /// <see cref="ResponsesServerHostExtensions.AddResponsesServer(Microsoft.Extensions.Hosting.IHostApplicationBuilder, string)"/>
    /// instead. Calling this overload in a hosted environment throws.
    /// </para>
    /// </summary>
    /// <param name="services">The service collection to add services to.</param>
    /// <param name="configure">Optional callback to configure <see cref="ResponsesServerOptions"/>.</param>
    /// <returns>The service collection for chaining.</returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when called in a hosted Foundry environment; use the
    /// <see cref="Microsoft.Extensions.Hosting.IHostApplicationBuilder"/> overload there.
    /// </exception>
    public static IServiceCollection AddResponsesServer(
        this IServiceCollection services,
        Action<ResponsesServerOptions>? configure = null)
    {
        if (FoundryEnvironment.IsHosted)
        {
            throw new InvalidOperationException(
                "AddResponsesServer(IServiceCollection) cannot be used in a hosted Foundry environment: " +
                "the Foundry response-storage and resilient-task-storage identities must bind from the same " +
                "configuration section so they cannot diverge. Register via " +
                "AddResponsesServer(IHostApplicationBuilder host, string sectionName) instead.");
        }

        return services.AddResponsesServerCore(configure, hostedStorage: null);
    }

    /// <summary>
    /// Shared registration core. <paramref name="hostedStorage"/> carries the single Foundry
    /// credential and storage endpoint (bound from configuration) used for BOTH response storage
    /// and resilient-task storage; it is <see langword="null"/> for local / non-hosted registration.
    /// </summary>
    internal static IServiceCollection AddResponsesServerCore(
        this IServiceCollection services,
        Action<ResponsesServerOptions>? configure,
        ResponsesHostedStorage? hostedStorage)
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
        // AddAgentEventStreams below), not a pluggable Responses stream provider.

        if (hostedStorage is not null)
        {
            // Response storage and resilient task storage authenticate with the SAME identity: the
            // one credential bound from the configuration section (carried on hostedStorage), captured
            // in the pipeline closure below and passed to Core's AddResilientTasks. No credential is
            // published into the container and no ambient DefaultAzureCredential is created.
            TokenCredential credential = hostedStorage.Credential;

            // Build the Azure.Core HttpPipeline with BearerTokenAuthenticationPolicy.
            // This automatically provides: retry, request ID, user-agent telemetry,
            // distributed tracing, logging, and token caching.
            // The ServerVersionPolicy prepends the composed server version (from all
            // registered protocols and developer segments) to the User-Agent header.
            // The FoundryStorageLoggingPolicy is added as a per-retry policy so each
            // attempt (including retries) is logged with correlation headers.
            services.TryAddSingleton(sp =>
            {
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

            Uri storageBaseUri = hostedStorage.StorageBaseUri;
            services.TryAddSingleton<ResponsesProvider>(sp =>
            {
                var pipeline = sp.GetRequiredService<HttpPipeline>();
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
        // the Core event-stream primitive (AgentEventStreamRegistry/AgentEventStream) — matching Python,
        // which uses the core EventStream registry directly. The backing is chosen from the bound
        // configuration (ResponsesServerSettings): local + ResilientBackground uses a durable
        // file-backed replay so a reconnecting client can replay pre-restart SSE events after a
        // otherwise an in-memory replay buffer is sufficient. Register this as a protocol default:
        // an explicit application backing overrides it regardless of registration order, while
        // conflicting protocol defaults fail when the registry is materialized.
        var eagerOptions = new ResponsesServerOptions();
        configure?.Invoke(eagerOptions);
        var useDurableStreams = eagerOptions.ResilientBackground && hostedStorage is null;
        var streamTtl = new InMemoryProviderOptions().EventStreamTtl;
        services.AddAgentEventStreamsDefault("ResponsesServer", o =>
        {
            if (useDurableStreams)
            {
                o.UseFileBackedReplay(
                    storageDirectory: Internal.Resilience.ResponsesStatePaths.StreamsRoot(),
                    ttl: streamTtl);
            }
            else
            {
                o.UseInMemoryReplay(ttl: streamTtl);
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
        if (hostedStorage is not null)
        {
            // Flat AddResilientTask/AddResilientMultiTurnTask calls self-initialize the core
            // services on first use. Hosted composition attaches its credential and endpoint to
            // that shared environment whether consumer tasks were registered before or after this call.
            services.AddResilientTasks(
                hostedStorage.Credential,
                hostedStorage.ProjectEndpoint);
        }

        services.AddResilientTask<
            ResponseTaskInput,
            ResponseTaskOutput,
            ResponsesResilientTaskHandler>(
            ResponsesResilientTaskHandler.OneShotTaskName);
        services.AddResilientMultiTurnTask<
            ResponseTaskInput,
            ResponseTaskOutput,
            ResponsesResilientTaskHandler>(
            ResponsesResilientTaskHandler.MultiTurnTaskName,
            steerable: eagerOptions.SteerableConversations);

        services.AddScoped<ResponseOrchestrator>();
        services.AddScoped<ResponseEndpointHandler>();
        services.AddScoped<ResponsesExceptionFilter>();

        // Log startup configuration when the host starts
        services.AddHostedService<ResponsesStartupLogger>();

        return services;
    }

    /// <summary>
    /// Resolves the Foundry storage base URI from the project endpoint.
    /// </summary>
    /// <param name="endpoint">The Foundry project endpoint.</param>
    /// <param name="isDevelopment">
    /// Whether the host environment is Development. Resolved from
    /// <see cref="Microsoft.Extensions.Hosting.IHostEnvironment"/> by the caller rather than read
    /// from environment variables directly, so any configuration source that sets the environment is
    /// honored. HTTPS is required outside Development.
    /// </param>
    internal static Uri ResolveStorageBaseUri(Uri? endpoint, bool isDevelopment)
    {
        if (endpoint is null)
        {
            throw new InvalidOperationException(
                "A Foundry project endpoint is required for hosted storage. " +
                "Set the 'Endpoint' value on the bound ResponsesServerSettings section " +
                "(the Azure AI Foundry platform provides this in hosted environments).");
        }

        // Require HTTPS in non-development environments.
        if (!isDevelopment
            && !string.Equals(endpoint.Scheme, Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException(
                "The Foundry project endpoint must use the HTTPS scheme.");
        }

        return new Uri(endpoint.GetLeftPart(UriPartial.Path).TrimEnd('/') + "/storage/");
    }
}

/// <summary>
/// Carries the single Foundry identity and storage endpoint — bound from one configuration section —
/// shared by response storage and resilient-task storage so the two cannot diverge.
/// </summary>
internal sealed class ResponsesHostedStorage
{
    public ResponsesHostedStorage(
        TokenCredential credential,
        Uri projectEndpoint,
        Uri storageBaseUri)
    {
        Credential = credential;
        ProjectEndpoint = projectEndpoint;
        StorageBaseUri = storageBaseUri;
    }

    public TokenCredential Credential { get; }

    public Uri ProjectEndpoint { get; }

    public Uri StorageBaseUri { get; }
}
