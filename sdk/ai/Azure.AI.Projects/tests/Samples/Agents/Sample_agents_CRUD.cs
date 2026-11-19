// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.Projects.Agents;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests.Samples;

public class Sample_agents_CRUD : SamplesBase
{
    [Test]
    [AsyncOnly]
    public async Task AgentCRUDAsync()
    {
        #region Snippet:Sample_CreateAgentClientCRUD
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        #endregion

        #region Snippet:Sample_CreateAgentVersionCRUD_Async
        DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a prompt agent."
        };
        ProjectsAgentVersion agentVersion1 = await projectClient.GetProjectAgentsClient().CreateAgentVersionAsync(
            agentName: "myAgent1",
            options: new(agentDefinition));
        Console.WriteLine($"Agent created (id: {agentVersion1.Id}, name: {agentVersion1.Name}, version: {agentVersion1.Version})");
        ProjectsAgentVersion agentVersion2 = await projectClient.GetProjectAgentsClient().CreateAgentVersionAsync(
            agentName: "myAgent2",
            options: new(agentDefinition));
        Console.WriteLine($"Agent created (id: {agentVersion2.Id}, name: {agentVersion2.Name}, version: {agentVersion2.Version})");
        #endregion

        #region Snippet:Sample_GetAgentCRUD_Async
        ProjectsAgentRecord result = await projectClient.GetProjectAgentsClient().GetAgentAsync(agentVersion1.Name);
        Console.WriteLine($"Agent created (id: {result.Id}, name: {result.Name})");
        #endregion

        #region Snippet:Sample_ListAgentsCRUD_Async
        await foreach (ProjectsAgentRecord agent in projectClient.GetProjectAgentsClient().GetAgentsAsync())
        {
            Console.WriteLine($"Listed Agent: id: {agent.Id}, name: {agent.Name}");
        }
        #endregion

        #region Snippet:Sample_DeleteAgentCRUD_Async
        await projectClient.GetProjectAgentsClient().DeleteAgentVersionAsync(agentName: agentVersion1.Name, agentVersion: agentVersion1.Version);
        Console.WriteLine($"Agent deleted (name: {agentVersion1.Name}, version: {agentVersion1.Version})");
        await projectClient.GetProjectAgentsClient().DeleteAgentVersionAsync(agentName: agentVersion2.Name, agentVersion: agentVersion2.Version);
        Console.WriteLine($"Agent deleted (name: {agentVersion2.Name}, version: {agentVersion2.Version})");
        #endregion
    }

    [Test]
    [SyncOnly]
    public void AgentCRUD()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());

        #region Snippet:Sample_CreateAgentVersionCRUD_Sync
        DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a prompt agent."
        };
        ProjectsAgentVersion agentVersion1 = projectClient.GetProjectAgentsClient().CreateAgentVersion(
            agentName: "myAgent1",
            options: new(agentDefinition));
        Console.WriteLine($"Agent created (id: {agentVersion1.Id}, name: {agentVersion1.Name}, version: {agentVersion1.Version})");
        ProjectsAgentVersion agentVersion2 = projectClient.GetProjectAgentsClient().CreateAgentVersion(
            agentName: "myAgent2",
            options: new(agentDefinition));
        Console.WriteLine($"Agent created (id: {agentVersion2.Id}, name: {agentVersion2.Name}, version: {agentVersion2.Version})");
        #endregion

        #region Snippet:Sample_GetAgentCRUD_Sync
        ProjectsAgentRecord result = projectClient.GetProjectAgentsClient().GetAgent(agentVersion1.Name);
        Console.WriteLine($"Agent created (id: {result.Id}, name: {result.Name})");
        #endregion

        #region Snippet:Sample_ListAgentsCRUD_Sync
        foreach (ProjectsAgentRecord agent in projectClient.GetProjectAgentsClient().GetAgents())
        {
            Console.WriteLine($"Listed Agent: id: {agent.Id}, name: {agent.Name}");
        }
        #endregion

        #region Snippet:Sample_DeleteAgentCRUD_Sync
        projectClient.GetProjectAgentsClient().DeleteAgentVersion(agentName: agentVersion1.Name, agentVersion: agentVersion1.Version);
        Console.WriteLine($"Agent deleted (name: {agentVersion1.Name}, version: {agentVersion1.Version})");
        projectClient.GetProjectAgentsClient().DeleteAgentVersion(agentName: agentVersion2.Name, agentVersion: agentVersion2.Version);
        Console.WriteLine($"Agent deleted (name: {agentVersion2.Name}, version: {agentVersion2.Version})");
        #endregion
    }

    public Sample_agents_CRUD(bool isAsync) : base(isAsync)
    { }
}
