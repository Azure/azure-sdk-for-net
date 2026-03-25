// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Identity;
using Azure.AI.AgentServer.Responses.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Internal helper for registering the FoundryStorage provider within <c>AddResponsesServer</c>.
/// </summary>
internal static class FoundryStorageExtensions
{
    /// <summary>
    /// Returns <see langword="true"/> when the <c>FOUNDRY_PROJECT_ENDPOINT</c>
    /// environment variable is set, indicating a hosted Foundry environment.
    /// </summary>
    internal static bool IsHostedEnvironment()
    {
        return !string.IsNullOrEmpty(
            Environment.GetEnvironmentVariable(BaseUrlRewriteHandler.ProjectEndpointEnvVar));
    }

    /// <summary>
    /// Replaces the <see cref="IResponsesProvider"/> registration with an HTTP-backed
    /// implementation that persists state to the Azure AI Foundry storage API.
    /// Called internally by <c>AddResponsesServer</c> when hosted-environment is detected.
    /// </summary>
    internal static IServiceCollection AddFoundryStorageProvider(this IServiceCollection services)
    {
        // Replace IResponsesProvider with FoundryStorageProvider (last-wins)
        services.RemoveAll<IResponsesProvider>();
        services.AddSingleton<IResponsesProvider, FoundryStorageProvider>();

        // Register DefaultAzureCredential as TokenCredential.
        // TryAdd: tests can override with a custom TokenCredential.
        services.TryAddSingleton<TokenCredential>(_ => new DefaultAzureCredential());

        // Register the delegating handlers
        services.AddTransient<BearerTokenHandler>();
        services.AddTransient<BaseUrlRewriteHandler>();

        // Wire the named HttpClient with the full pipeline
        services.AddHttpClient("FoundryStorage")
            .AddHttpMessageHandler<BaseUrlRewriteHandler>()
            .AddHttpMessageHandler<BearerTokenHandler>();

        return services;
    }
}
