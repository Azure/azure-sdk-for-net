// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Extension methods for <see cref="IServiceCollection"/> to register
/// the Responses API server SDK services.
/// </summary>
public static class ResponsesServerServiceCollectionExtensions
{
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

        // Register the concrete InMemoryResponsesProvider as a singleton,
        // then forward each interface to the same instance.
        // TryAddSingleton ensures consumer registrations before AddResponsesServer() take precedence.
        services.TryAddSingleton<InMemoryResponsesProvider>();
        services.TryAddSingleton<IResponsesProvider>(sp => sp.GetRequiredService<InMemoryResponsesProvider>());
        services.TryAddSingleton<IResponsesCancellationSignalProvider>(sp => sp.GetRequiredService<InMemoryResponsesProvider>());
        services.TryAddSingleton<IResponsesStreamProvider>(sp => sp.GetRequiredService<InMemoryResponsesProvider>());

        services.AddSingleton<ResponseExecutionTracker>();
        services.AddHostedService(sp => sp.GetRequiredService<ResponseExecutionTracker>());
        services.AddSingleton<IPayloadValidator, PayloadValidator>();
        services.AddScoped<ResponseOrchestrator>();
        services.AddScoped<ResponseEndpointHandler>();
        services.AddScoped<ResponsesExceptionFilter>();

        // Auto-detect hosted environment: if FOUNDRY_PROJECT_ENDPOINT is set,
        // replace the in-memory provider with the FoundryStorage provider.
        if (FoundryStorageExtensions.IsHostedEnvironment())
        {
            services.AddFoundryStorageProvider();
        }

        return services;
    }
}
