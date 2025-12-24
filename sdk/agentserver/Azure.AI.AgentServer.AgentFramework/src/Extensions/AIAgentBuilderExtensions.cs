// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core.Tools;
using Azure.AI.AgentServer.Core.Tools.Models;
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
    /// <param name="toolDefinitions">The Foundry tool definitions to resolve.</param>
    /// <param name="projectEndpoint">
    /// Optional Foundry project endpoint. If not provided, the method uses the
    /// <c>AZURE_AI_PROJECT_ENDPOINT</c> or <c>AGENT_PROJECT_NAME</c> environment variables.
    /// </param>
    /// <param name="credential">
    /// Optional credential for accessing Foundry tools. If not provided, the method falls back to
    /// a <see cref="DefaultAzureCredential"/> or a resolved <see cref="TokenCredential"/> from the service provider.
    /// </param>
    /// <returns>The <see cref="AIAgentBuilder"/> instance with tool discovery added.</returns>
    public static AIAgentBuilder useFoundryTools(
        this AIAgentBuilder builder,
        IList<ToolDefinition> toolDefinitions,
        Uri? projectEndpoint = null,
        TokenCredential? credential = null)
    {
        ArgumentNullException.ThrowIfNull(builder);
        ArgumentNullException.ThrowIfNull(toolDefinitions);

        return builder.Use((innerAgent, services) =>
        {
            var endpoint = ResolveProjectEndpoint(projectEndpoint);
            var toolCredential = credential ?? (services.GetService(typeof(TokenCredential)) as TokenCredential) ?? new DefaultAzureCredential();

            var options = new AzureAIToolClientOptions
            {
                Tools = new List<ToolDefinition>(toolDefinitions)
            };

            var toolClient = new ToolClient(new AzureAIToolClient(endpoint, toolCredential, options));
            return new FoundryToolAgent(innerAgent, toolClient);
        });
    }

    private static Uri ResolveProjectEndpoint(Uri? projectEndpoint)
    {
        if (projectEndpoint is not null)
        {
            return projectEndpoint;
        }

        var endpointFromEnv = Environment.GetEnvironmentVariable("AZURE_AI_PROJECT_ENDPOINT");
        if (!string.IsNullOrWhiteSpace(endpointFromEnv))
        {
            return new Uri(endpointFromEnv);
        }

        throw new InvalidOperationException("AZURE_AI_PROJECT_ENDPOINT must be set to resolve tools.");
    }
}
