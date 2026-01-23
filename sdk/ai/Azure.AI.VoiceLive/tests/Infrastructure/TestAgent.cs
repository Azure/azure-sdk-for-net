// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

using Azure.AI.Agents.Persistent;
using Azure.Identity;

namespace Azure.AI.VoiceLive.Tests.Infrastructure
{
    public static class TestAgent
    {
        public static async Task CreateAgentAsync(string agentName)
        {
            //Create a PersistentAgentsClient and PersistentAgent.
            var projectEndpoint = System.Environment.GetEnvironmentVariable("AI_SERVICES_ENDPOINT");
            var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");

            PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());

            //Give PersistentAgent a tool to execute code using CodeInterpreterToolDefinition.
            PersistentAgent agent = await client.Administration.CreateAgentAsync(
                model: modelDeploymentName,
                name: agentName,
                instructions: "You politely help with math questions. Use the code interpreter tool when asked to visualize numbers.",
                tools: [new CodeInterpreterToolDefinition()]
            );
        }

        public static async Task<string> FindAgentAsync(string agentName)
        {
            //Create a PersistentAgentsClient and PersistentAgent.
            var projectEndpoint = System.Environment.GetEnvironmentVariable("AI_SERVICES_ENDPOINT");
            var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");

            PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());

            await foreach (var agent in client.Administration.GetAgentsAsync().ConfigureAwait(false))
            {
                if (agent.Name == agentName)
                {
                    return agent.Id;
                }
            }

            return string.Empty;
        }
    }
}
