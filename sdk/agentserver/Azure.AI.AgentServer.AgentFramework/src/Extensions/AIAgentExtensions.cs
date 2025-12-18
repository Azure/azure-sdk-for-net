// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core.Context;
using Azure.AI.AgentServer.Core.Tools;
using Azure.AI.AgentServer.Core.Tools.Models;
using Azure.AI.AgentServer.Responses.Invocation;
using Azure.Core;
using Azure.Identity;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Azure.AI.AgentServer.AgentFramework.Extensions;

/// <summary>
/// Provides extension methods for running AI agents in the agent server framework.
/// </summary>
public static class AIAgentExtensions
{
    /// <summary>
    /// Runs an AI agent asynchronously using the provided service provider.
    /// </summary>
    /// <param name="agent">The AI agent to run.</param>
    /// <param name="sp">The service provider for dependency injection.</param>
    /// <param name="telemetrySourceName">The name of the telemetry source. Defaults to "Agents".</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static Task RunAIAgentAsync(this AIAgent agent, IServiceProvider sp, string telemetrySourceName = "Agents")
    {
        return AgentServerApplication.RunAsync(new ApplicationOptions(
            ConfigureServices: services => services.AddSingleton(agent).AddSingleton<IAgentInvocation, AIAgentInvocation>(),
            LoggerFactory: GetLoggerFactory(sp),
            TelemetrySourceName: telemetrySourceName));
    }

    /// <summary>
    /// Runs an AI agent asynchronously with an optional logger factory.
    /// </summary>
    /// <param name="agent">The AI agent to run.</param>
    /// <param name="loggerFactory">Optional logger factory for creating loggers.</param>
    /// <param name="telemetrySourceName">The name of the telemetry source. Defaults to "Agents".</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static Task RunAIAgentAsync(this AIAgent agent, ILoggerFactory? loggerFactory = null,
        string telemetrySourceName = "Agents")
    {
        return AgentServerApplication.RunAsync(new ApplicationOptions(
            ConfigureServices: services => services.AddSingleton(agent).AddSingleton<IAgentInvocation, AIAgentInvocation>(),
            LoggerFactory: loggerFactory == null ? null : () => loggerFactory,
            TelemetrySourceName: telemetrySourceName));
    }

    /// <summary>
    /// Runs an AI agent asynchronously using the service provider's dependencies.
    /// </summary>
    /// <param name="sp">The service provider for dependency injection.</param>
    /// <param name="agent">Optional AI agent to run. If null, retrieves from service provider.</param>
    /// <param name="telemetrySourceName">The name of the telemetry source. Defaults to "Agents".</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static Task RunAIAgentAsync(this IServiceProvider sp, AIAgent? agent = null,
        string telemetrySourceName = "Agents")
    {
        return AgentServerApplication.RunAsync(new ApplicationOptions(
            ConfigureServices: services =>
            {
                if (sp.GetService<IAgentInvocation>() == null)
                {
                    services.AddSingleton(agent ?? sp.GetRequiredService<AIAgent>()).AddSingleton<AIAgentInvocation>();
                }
                else
                {
                    services.AddSingleton(sp.GetRequiredService<IAgentInvocation>());
                }
            },
            LoggerFactory: GetLoggerFactory(sp),
            TelemetrySourceName: telemetrySourceName));
    }

    /// <summary>
    /// Runs an AI agent with optional tool support using ToolDefinition objects.
    /// </summary>
    /// <param name="agent">The AI agent to run.</param>
    /// <param name="telemetrySourceName">The name of the telemetry source.</param>
    /// <param name="credential">Optional Azure credential for authentication. If null, uses DefaultAzureCredential when tools are provided.</param>
    /// <param name="tools">Optional list of tool definitions to enable. If null, runs without tool support.</param>
    /// <param name="loggerFactory">Optional logger factory.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="InvalidOperationException">Thrown when AZURE_AI_PROJECT_ENDPOINT environment variable is not set.</exception>
    public static async Task RunAIAgentAsync(
        this AIAgent agent,
        IList<ToolDefinition>? tools,
        string telemetrySourceName = "Agents",
        TokenCredential? credential = null,
        ILoggerFactory? loggerFactory = null)
    {
        ArgumentNullException.ThrowIfNull(agent);

        // If tools is null or empty, fall back to basic agent run mode without tools
        if (tools == null || tools.Count == 0)
        {
            await AgentServerApplication.RunAsync(new ApplicationOptions(
                ConfigureServices: services => services
                    .AddSingleton(agent)
                    .AddSingleton<IAgentInvocation, AIAgentInvocation>(),
                LoggerFactory: loggerFactory == null ? null : () => loggerFactory,
                TelemetrySourceName: telemetrySourceName)).ConfigureAwait(false);
            return;
        }

        // Get endpoint and run agent with tools
        Uri endpoint = GetAzureAIProjectEndpoint();
        TokenCredential effectiveCredential = credential ?? new DefaultAzureCredential();

        // Create tool client options
        AzureAIToolClientOptions toolClientOptions = new AzureAIToolClientOptions
        {
            Tools = tools
        };

        AzureAIToolClient azureToolClient = new AzureAIToolClient(endpoint, effectiveCredential, toolClientOptions);
        await using (azureToolClient.ConfigureAwait(false))
        {
            ToolClient toolClient = new ToolClient(azureToolClient);
            await using (toolClient.ConfigureAwait(false))
            {
                // Get tools as AIFunctions
                IReadOnlyList<AIFunction> aiFunctions = await toolClient.ListToolsAsync().ConfigureAwait(false);

                // Run agent with tools
                await AgentServerApplication.RunAsync(new ApplicationOptions(
                    ConfigureServices: services => services
                        .AddSingleton(agent)
                        .AddSingleton<IAgentInvocation, AIAgentInvocation>()
                        .AddSingleton<IReadOnlyList<AIFunction>>(aiFunctions),
                    LoggerFactory: loggerFactory == null ? null : () => loggerFactory,
                    TelemetrySourceName: telemetrySourceName)).ConfigureAwait(false);
            }
        }
    }

    /// <summary>
    /// Runs an AI agent asynchronously using the service provider's dependencies with optional tool support.
    /// </summary>
    /// <param name="sp">The service provider for dependency injection.</param>
    /// <param name="agent">Optional AI agent to run. If null, retrieves from service provider.</param>
    /// <param name="tools">Optional list of tool definitions to enable. If null, runs without tool support.</param>
    /// <param name="telemetrySourceName">The name of the telemetry source. Defaults to "Agents".</param>
    /// <param name="credential">Optional Azure credential for authentication. If null, uses DefaultAzureCredential when tools are provided.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="InvalidOperationException">Thrown when AZURE_AI_PROJECT_ENDPOINT environment variable is not set or contains an invalid URL.</exception>
    public static async Task RunAIAgentAsync(
        this IServiceProvider sp,
        AIAgent? agent = null,
        IList<ToolDefinition>? tools = null,
        string telemetrySourceName = "Agents",
        TokenCredential? credential = null)
    {
        ArgumentNullException.ThrowIfNull(sp);

        // Get the effective agent (from parameter or service provider)
        AIAgent effectiveAgent = agent ?? sp.GetRequiredService<AIAgent>();

        // If tools is null or empty, fall back to basic agent run mode without tools
        if (tools == null || tools.Count == 0)
        {
            await AgentServerApplication.RunAsync(new ApplicationOptions(
                ConfigureServices: services =>
                {
                    if (sp.GetService<IAgentInvocation>() == null)
                    {
                        services.AddSingleton(effectiveAgent).AddSingleton<IAgentInvocation, AIAgentInvocation>();
                    }
                    else
                    {
                        services.AddSingleton(sp.GetRequiredService<IAgentInvocation>());
                    }
                },
                LoggerFactory: GetLoggerFactory(sp),
                TelemetrySourceName: telemetrySourceName)).ConfigureAwait(false);
            return;
        }

        // Get endpoint and run agent with tools
        Uri endpoint = GetAzureAIProjectEndpoint();
        TokenCredential effectiveCredential = credential ?? new DefaultAzureCredential();

        // Create tool client options
        AzureAIToolClientOptions toolClientOptions = new AzureAIToolClientOptions
        {
            Tools = tools
        };

        AzureAIToolClient azureToolClient = new AzureAIToolClient(endpoint, effectiveCredential, toolClientOptions);
        await using (azureToolClient.ConfigureAwait(false))
        {
            ToolClient toolClient = new ToolClient(azureToolClient);
            await using (toolClient.ConfigureAwait(false))
            {
                // Get tools as AIFunctions
                IReadOnlyList<AIFunction> aiFunctions = await toolClient.ListToolsAsync().ConfigureAwait(false);

                // Run agent with tools
                await AgentServerApplication.RunAsync(new ApplicationOptions(
                    ConfigureServices: services =>
                    {
                        if (sp.GetService<IAgentInvocation>() == null)
                        {
                            services
                                .AddSingleton(effectiveAgent)
                                .AddSingleton<IAgentInvocation, AIAgentInvocation>()
                                .AddSingleton<IReadOnlyList<AIFunction>>(aiFunctions);
                        }
                        else
                        {
                            services
                                .AddSingleton(sp.GetRequiredService<IAgentInvocation>())
                                .AddSingleton<IReadOnlyList<AIFunction>>(aiFunctions);
                        }
                    },
                    LoggerFactory: GetLoggerFactory(sp),
                    TelemetrySourceName: telemetrySourceName)).ConfigureAwait(false);
            }
        }
    }

    private static Func<ILoggerFactory>? GetLoggerFactory(IServiceProvider sp)
    {
        return sp.GetService<ILoggerFactory>() == null ? null : sp.GetRequiredService<ILoggerFactory>;
    }

    /// <summary>
    /// Retrieves and validates the Azure AI project endpoint from environment variable.
    /// </summary>
    /// <returns>The validated endpoint URI.</returns>
    /// <exception cref="InvalidOperationException">Thrown when AZURE_AI_PROJECT_ENDPOINT environment variable is not set or contains an invalid URL.</exception>
    private static Uri GetAzureAIProjectEndpoint()
    {
        var endpointString = Environment.GetEnvironmentVariable("AZURE_AI_PROJECT_ENDPOINT");
        if (string.IsNullOrWhiteSpace(endpointString))
        {
            throw new InvalidOperationException(
                "AZURE_AI_PROJECT_ENDPOINT environment variable is not set. " +
                "Please set this environment variable to your Azure AI project endpoint URL.");
        }

        try
        {
            return new Uri(endpointString);
        }
        catch (UriFormatException ex)
        {
            throw new InvalidOperationException(
                $"AZURE_AI_PROJECT_ENDPOINT environment variable contains an invalid URL: '{endpointString}'", ex);
        }
    }
}
