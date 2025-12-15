// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using Azure.AI.AgentServer.Core.Context;
using Azure.AI.AgentServer.Core.Tools;
using Azure.AI.AgentServer.Core.Tools.Models;
using Azure.AI.AgentServer.Responses.Invocation;
using Azure.Core;
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
    /// Runs an AI agent with tool support using ToolDefinition objects.
    /// </summary>
    /// <param name="agent">The AI agent to run.</param>
    /// <param name="telemetrySourceName">The name of the telemetry source.</param>
    /// <param name="tools">List of tool definitions to enable.</param>
    /// <param name="endpoint">Azure AI endpoint.</param>
    /// <param name="credential">Azure credential for authentication.</param>
    /// <param name="loggerFactory">Optional logger factory.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task RunAIAgentAsync(
        this AIAgent agent,
        string telemetrySourceName,
        IList<ToolDefinition> tools,
        Uri endpoint,
        TokenCredential credential,
        ILoggerFactory? loggerFactory = null)
    {
        ArgumentNullException.ThrowIfNull(agent);
        ArgumentNullException.ThrowIfNull(tools);
        ArgumentNullException.ThrowIfNull(endpoint);
        ArgumentNullException.ThrowIfNull(credential);

        // Create tool client options
        AzureAIToolClientOptions toolClientOptions = new AzureAIToolClientOptions
        {
            Tools = tools
        };

        AzureAIToolClientAsync azureToolClient = new AzureAIToolClientAsync(endpoint, credential, toolClientOptions);
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
    /// Runs an AI agent with tool support using inline tool configuration objects.
    /// </summary>
    /// <param name="agent">The AI agent to run.</param>
    /// <param name="telemetrySourceName">The name of the telemetry source.</param>
    /// <param name="toolConfigs">Array of anonymous objects with tool configurations.</param>
    /// <param name="endpoint">Azure AI endpoint.</param>
    /// <param name="credential">Azure credential for authentication.</param>
    /// <param name="loggerFactory">Optional logger factory.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static Task RunAIAgentAsync(
        this AIAgent agent,
        string telemetrySourceName,
        object[] toolConfigs,
        Uri endpoint,
        TokenCredential credential,
        ILoggerFactory? loggerFactory = null)
    {
        ArgumentNullException.ThrowIfNull(agent);
        ArgumentNullException.ThrowIfNull(toolConfigs);
        ArgumentNullException.ThrowIfNull(endpoint);
        ArgumentNullException.ThrowIfNull(credential);

        // Convert anonymous objects to ToolDefinition
        var tools = toolConfigs.Select(config =>
        {
            var dict = ObjectToDictionary(config);
            var type = dict.TryGetValue("type", out var typeValue)
                ? typeValue?.ToString() ?? "mcp"
                : "mcp";
            var projectConnectionId = dict.TryGetValue("project_connection_id", out var connId)
                ? connId?.ToString()
                : null;

            return new ToolDefinition
            {
                Type = type,
                ProjectConnectionId = projectConnectionId,
                AdditionalProperties = dict.Where(kvp =>
                    kvp.Key != "type" && kvp.Key != "project_connection_id")
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value)
            };
        }).ToList();

        return RunAIAgentAsync(agent, telemetrySourceName, tools, endpoint, credential, loggerFactory);
    }

    private static Dictionary<string, object?> ObjectToDictionary(object obj)
    {
        return obj.GetType()
            .GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .ToDictionary(
                prop => prop.Name,
                prop => prop.GetValue(obj));
    }

    private static Func<ILoggerFactory>? GetLoggerFactory(IServiceProvider sp)
    {
        return sp.GetService<ILoggerFactory>() == null ? null : sp.GetRequiredService<ILoggerFactory>;
    }
}
