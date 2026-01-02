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
    /// <param name="foundryTools">The Foundry tool definitions to resolve.</param>
    /// <returns>The <see cref="AIAgentBuilder"/> instance with tool discovery added.</returns>
    public static AIAgentBuilder UseFoundryTools(
        this AIAgentBuilder builder,
        params FoundryTool[] foundryTools)
    {
        ArgumentNullException.ThrowIfNull(builder);
        ArgumentNullException.ThrowIfNull(foundryTools);

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

    private static Uri ResolveProjectEndpoint()
    {
        var endpointFromEnv = Environment.GetEnvironmentVariable("AZURE_AI_PROJECT_ENDPOINT");
        if (!string.IsNullOrWhiteSpace(endpointFromEnv))
        {
            return new Uri(endpointFromEnv);
        }

        throw new InvalidOperationException("AZURE_AI_PROJECT_ENDPOINT must be set to resolve tools.");
    }
}
