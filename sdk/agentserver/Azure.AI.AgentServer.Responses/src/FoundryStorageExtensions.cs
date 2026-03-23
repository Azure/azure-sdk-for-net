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
    /// The environment variable names required for hosted-environment auto-detection.
    /// All must be non-empty for FoundryStorage to be registered.
    /// </summary>
    internal static readonly string[] RequiredEnvVars =
    [
        BaseUrlRewriteHandler.CallbackUrlEnvVar,
        "AZURE_TENANT_ID",
        "AGENT_SUBSCRIPTION_ID",
        "AGENT_RESOURCE_GROUP",
        "AGENT_PROJECT_NAME",
    ];

    /// <summary>
    /// Returns <see langword="true"/> when all required hosted-environment variables are set,
    /// including <c>FOUNDRY_AGENT_STORAGE_CALLBACK_URL</c>.
    /// </summary>
    internal static bool IsHostedEnvironment()
    {
        foreach (var name in RequiredEnvVars)
        {
            if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable(name)))
            {
                return false;
            }
        }

        return true;
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
