// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses.Internal;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

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
        // ResponsesCancellationSignalProvider and ResponsesStreamProvider even when
        // FoundryStorageProvider handles ResponsesProvider in hosted environments.
        services.TryAddSingleton<InMemoryResponsesProvider>();
        services.TryAddSingleton<ResponsesCancellationSignalProvider>(sp =>
            new InMemoryCancellationSignalProvider(sp.GetRequiredService<InMemoryResponsesProvider>()));
        services.TryAddSingleton<ResponsesStreamProvider>(sp =>
            new InMemoryStreamProvider(sp.GetRequiredService<InMemoryResponsesProvider>()));

        // Auto-detect hosted environment: when FoundryEnvironment.IsHosted is true,
        // meaning the .NET hosting environment is not Development and
        // FOUNDRY_PROJECT_ENDPOINT, FOUNDRY_AGENT_NAME, and FOUNDRY_AGENT_VERSION are all configured,
        // use FoundryStorageProvider for persistence; otherwise use in-memory.
        if (FoundryEnvironment.IsHosted)
        {
            services.TryAddSingleton<TokenCredential>(_ => new DefaultAzureCredential());

            // Build the Azure.Core HttpPipeline with BearerTokenAuthenticationPolicy.
            // This automatically provides: retry, request ID, user-agent telemetry,
            // distributed tracing, logging, and token caching.
            services.TryAddSingleton(sp =>
            {
                var credential = sp.GetRequiredService<TokenCredential>();
                var options = new FoundryStorageClientOptions();
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
            services.TryAddSingleton<ResponsesProvider>(sp => sp.GetRequiredService<InMemoryResponsesProvider>());
        }

        services.AddSingleton<ResponseExecutionTracker>();
        services.AddHostedService(sp => sp.GetRequiredService<ResponseExecutionTracker>());
        services.AddSingleton<IPayloadValidator, PayloadValidator>();
        services.AddScoped<ResponseOrchestrator>();
        services.AddScoped<ResponseEndpointHandler>();
        services.AddScoped<ResponsesExceptionFilter>();

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
