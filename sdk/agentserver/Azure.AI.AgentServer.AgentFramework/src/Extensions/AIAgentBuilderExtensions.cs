// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using Azure.AI.AgentServer.Core.Tools;
using Azure.AI.AgentServer.Core.Tools.Models;
using Azure.AI.AgentServer.Core.Tools.Runtime.Facade;
using Azure.Core;
using Azure.Identity;
using Microsoft.Agents.AI;

namespace Azure.AI.AgentServer.AgentFramework.Extensions;

/// <summary>
/// Provides extension methods for configuring and customizing <see cref="AIAgentBuilder"/> instances.
/// </summary>
public static class AIAgentBuilderExtensions
{
    /// <summary>
    /// Adds Foundry tool discovery to the agent pipeline and enables tool calling using the resolved tools.
    /// </summary>
    /// <param name="builder">The <see cref="AIAgentBuilder"/> to augment.</param>
    /// <param name="foundryTools">The Foundry tool definitions to resolve.</param>
    /// <returns>The <see cref="AIAgentBuilder"/> instance with tool discovery added.</returns>
    public static AIAgentBuilder UseFoundryTools(
        this AIAgentBuilder builder,
        params FoundryTool[] foundryTools)
    {
        ArgumentNullException.ThrowIfNull(builder);
        ArgumentNullException.ThrowIfNull(foundryTools);

        return UseFoundryToolsInternal(builder, foundryTools);
    }

    /// <summary>
    /// Adds Foundry tool discovery using dictionary or anonymous-object facades.
    /// </summary>
    /// <param name="builder">The <see cref="AIAgentBuilder"/> to augment.</param>
    /// <param name="foundryTools">
    /// Tool facades with a <c>type</c> discriminator. Use <c>type</c> values of
    /// <c>mcp</c> or <c>a2a</c> with <c>project_connection_id</c> for connected tools;
    /// any other <c>type</c> value maps to a hosted MCP tool name.
    /// </param>
    /// <returns>The <see cref="AIAgentBuilder"/> instance with tool discovery added.</returns>
    public static AIAgentBuilder UseFoundryTools(
        this AIAgentBuilder builder,
        params object[] foundryTools)
    {
        ArgumentNullException.ThrowIfNull(builder);
        ArgumentNullException.ThrowIfNull(foundryTools);

        var converted = foundryTools.Select(ConvertToFoundryTool).ToList();
        return UseFoundryToolsInternal(builder, converted);
    }

    private static Uri ResolveProjectEndpoint()
    {
        var endpointFromEnv = Environment.GetEnvironmentVariable("AZURE_AI_PROJECT_ENDPOINT");
        if (!string.IsNullOrWhiteSpace(endpointFromEnv))
        {
            return new Uri(endpointFromEnv);
        }

        throw new InvalidOperationException("AZURE_AI_PROJECT_ENDPOINT must be set to resolve tools.");
    }

    private static AIAgentBuilder UseFoundryToolsInternal(
        AIAgentBuilder builder,
        IReadOnlyList<FoundryTool> foundryTools)
    {
        return builder.Use((innerAgent, services) =>
        {
            var endpoint = ResolveProjectEndpoint();
            var toolCredential = (services.GetService(typeof(TokenCredential)) as TokenCredential) ?? new DefaultAzureCredential();

            var options = new FoundryToolClientOptions
            {
                Tools = new List<FoundryTool>(foundryTools)
            };

            var toolClient = new ToolClient(new FoundryToolClient(endpoint, toolCredential, options));
            return new FoundryToolAgent(innerAgent, toolClient);
        });
    }

    private static FoundryTool ConvertToFoundryTool(object tool)
    {
        ArgumentNullException.ThrowIfNull(tool);

        if (tool is FoundryTool foundryTool)
        {
            return foundryTool;
        }

        if (tool is IDictionary<string, object?> facadeDictionary)
        {
            return FoundryToolFactory.Create(NormalizeFacade(facadeDictionary));
        }

        return FoundryToolFactory.Create(NormalizeFacade(CreateFacadeFromObject(tool)));
    }

    private static IDictionary<string, object?> CreateFacadeFromObject(object tool)
    {
        var properties = tool.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
        if (properties.Length == 0)
        {
            throw new ArgumentException("Tool facade must have public properties to infer the tool definition.", nameof(tool));
        }

        var facade = new Dictionary<string, object?>(StringComparer.OrdinalIgnoreCase);
        foreach (var property in properties)
        {
            if (!property.CanRead)
            {
                continue;
            }

            facade[property.Name] = property.GetValue(tool);
        }

        return facade;
    }

    private static IDictionary<string, object?> NormalizeFacade(IDictionary<string, object?> facade)
    {
        var normalized = new Dictionary<string, object?>(facade, StringComparer.OrdinalIgnoreCase);

        if (!normalized.ContainsKey("type") && normalized.TryGetValue("protocol", out var protocol))
        {
            normalized["type"] = protocol;
        }

        if (!normalized.ContainsKey("project_connection_id") &&
            normalized.TryGetValue("projectConnectionId", out var projectConnectionId))
        {
            normalized["project_connection_id"] = projectConnectionId;
        }

        return normalized;
    }
}
