// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.Projects.OpenAI;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests.Samples;

public class Sample_agents_CRUD : SamplesBase<AIProjectsTestEnvironment>
{
    [Test]
    [AsyncOnly]
    public async Task AgentCRUDAsync()
    {
        #region Snippet:Sample_CreateAgentClientCRUD
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECTENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        #endregion

        #region Snippet:Sample_CreateAgentVersionCRUD_Async
        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a prompt agent."
        };
        AgentVersion agentVersion1 = await projectClient.Agents.CreateAgentVersionAsync(
            agentName: "myAgent1",
            options: new(agentDefinition));
        Console.WriteLine($"Agent created (id: {agentVersion1.Id}, name: {agentVersion1.Name}, version: {agentVersion1.Version})");
        AgentVersion agentVersion2 = await projectClient.Agents.CreateAgentVersionAsync(
            agentName: "myAgent2",
            options: new(agentDefinition));
        Console.WriteLine($"Agent created (id: {agentVersion2.Id}, name: {agentVersion2.Name}, version: {agentVersion2.Version})");
        #endregion

        #region Snippet:Sample_GetAgentCRUD_Async
        AgentRecord result = await projectClient.Agents.GetAgentAsync(agentVersion1.Name);
        Console.WriteLine($"Agent created (id: {result.Id}, name: {result.Name})");
        #endregion

        #region Snippet:Sample_ListAgentsCRUD_Async
        await foreach (AgentRecord agent in projectClient.Agents.GetAgentsAsync())
        {
            Console.WriteLine($"Listed Agent: id: {agent.Id}, name: {agent.Name}");
        }
        #endregion

        #region Snippet:Sample_DeleteAgentCRUD_Async
        await projectClient.Agents.DeleteAgentVersionAsync(agentName: agentVersion1.Name, agentVersion: agentVersion1.Version);
        Console.WriteLine($"Agent deleted (name: {agentVersion1.Name}, version: {agentVersion1.Version})");
        await projectClient.Agents.DeleteAgentVersionAsync(agentName: agentVersion2.Name, agentVersion: agentVersion2.Version);
        Console.WriteLine($"Agent deleted (name: {agentVersion2.Name}, version: {agentVersion2.Version})");
        #endregion
    }

    [Test]
    [SyncOnly]
    public void AgentCRUD()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECTENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());

        #region Snippet:Sample_CreateAgentVersionCRUD_Sync
        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a prompt agent."
        };
        AgentVersion agentVersion1 = projectClient.Agents.CreateAgentVersion(
            agentName: "myAgent1",
            options: new(agentDefinition));
        Console.WriteLine($"Agent created (id: {agentVersion1.Id}, name: {agentVersion1.Name}, version: {agentVersion1.Version})");
        AgentVersion agentVersion2 = projectClient.Agents.CreateAgentVersion(
            agentName: "myAgent2",
            options: new(agentDefinition));
        Console.WriteLine($"Agent created (id: {agentVersion2.Id}, name: {agentVersion2.Name}, version: {agentVersion2.Version})");
        #endregion

        #region Snippet:Sample_GetAgentCRUD_Sync
        AgentRecord result = projectClient.Agents.GetAgent(agentVersion1.Name);
        Console.WriteLine($"Agent created (id: {result.Id}, name: {result.Name})");
        #endregion

        #region Snippet:Sample_ListAgentsCRUD_Sync
        foreach (AgentRecord agent in projectClient.Agents.GetAgents())
        {
            Console.WriteLine($"Listed Agent: id: {agent.Id}, name: {agent.Name}");
        }
        #endregion

        #region Snippet:Sample_DeleteAgentCRUD_Sync
        projectClient.Agents.DeleteAgentVersion(agentName: agentVersion1.Name, agentVersion: agentVersion1.Version);
        Console.WriteLine($"Agent deleted (name: {agentVersion1.Name}, version: {agentVersion1.Version})");
        projectClient.Agents.DeleteAgentVersion(agentName: agentVersion2.Name, agentVersion: agentVersion2.Version);
        Console.WriteLine($"Agent deleted (name: {agentVersion2.Name}, version: {agentVersion2.Version})");
        #endregion
    }
}
