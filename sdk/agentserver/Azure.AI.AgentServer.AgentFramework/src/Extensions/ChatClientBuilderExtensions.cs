// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using Azure.Identity;
using Microsoft.Extensions.AI;
using Azure.AI.AgentServer.Core.Tools.Models;
using Azure.AI.AgentServer.Core.Tools.Runtime.Facade;

namespace Azure.AI.AgentServer.AgentFramework.Extensions;

/// <summary>
/// Provides extension methods for configuring chat client builders.
/// </summary>
public static class ChatClientBuilderExtensions
{
    /// <summary>
    /// Adds Foundry tool discovery to the chat client pipeline and enables tool calling using the resolved tools.
    /// </summary>
    /// <param name="builder">The chat client builder.</param>
    /// <param name="foundryTools">The Foundry tool definitions to resolve.</param>
    /// <returns>The updated <see cref="ChatClientBuilder"/> instance.</returns>
    public static ChatClientBuilder UseFoundryTools(
        this ChatClientBuilder builder,
        params FoundryTool[] foundryTools)
    {
        ArgumentNullException.ThrowIfNull(builder);
        ArgumentNullException.ThrowIfNull(foundryTools);

        return UseFoundryToolsInternal(builder, foundryTools);
    }

    /// <summary>
    /// Adds Foundry tool discovery using dictionary or anonymous-object facades.
    /// </summary>
    /// <param name="builder">The chat client builder.</param>
    /// <param name="foundryTools">
    /// Tool facades with a <c>type</c> discriminator. Use <c>type</c> values of
    /// <c>mcp</c> or <c>a2a</c> with <c>project_connection_id</c> for connected tools;
    /// any other <c>type</c> value maps to a hosted MCP tool name.
    /// </param>
    /// <returns>The updated <see cref="ChatClientBuilder"/> instance.</returns>
    public static ChatClientBuilder UseFoundryTools(
        this ChatClientBuilder builder,
        params object[] foundryTools)
    {
        ArgumentNullException.ThrowIfNull(builder);
        ArgumentNullException.ThrowIfNull(foundryTools);

        var converted = foundryTools.Select(ConvertToFoundryTool).ToList();
        return UseFoundryToolsInternal(builder, converted);
    }

    private static ChatClientBuilder UseFoundryToolsInternal(
        ChatClientBuilder builder,
        IReadOnlyList<FoundryTool> foundryTools)
    {
        if (foundryTools.Count == 0)
        {
            return builder;
        }

        var endpoint = ResolveProjectEndpoint();
        var credential = new DefaultAzureCredential();

        return builder.Use(innerClient =>
        {
            var functionInvokingClient = new FunctionInvokingChatClient(innerClient, loggerFactory: null, functionInvocationServices: null);
            return new FoundryToolsChatClient(functionInvokingClient, endpoint, credential, foundryTools);
        });
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
