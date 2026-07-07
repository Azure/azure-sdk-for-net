// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Agents.Tests.Samples;

public class Sample_agents_CRUD : SamplesBase
{
    [Test]
    [AsyncOnly]
    public async Task AgentCRUDAsync()
    {
        #region Snippet:Sample_Agents_CreateAgentClientCRUD
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
#endif
        AgentAdministrationClient agentsClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        #endregion

        #region Snippet:Sample_Agents_CreateAgentVersionCRUD_Async
        DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a prompt agent."
        };
        ProjectsAgentVersion agentVersion1 = await agentsClient.CreateAgentVersionAsync(
            agentName: "myAgent1",
            options: new(agentDefinition));
        Console.WriteLine($"Agent created (id: {agentVersion1.Id}, name: {agentVersion1.Name}, version: {agentVersion1.Version})");
        ProjectsAgentVersion agentVersion2 = await agentsClient.CreateAgentVersionAsync(
            agentName: "myAgent2",
            options: new(agentDefinition));
        Console.WriteLine($"Agent created (id: {agentVersion2.Id}, name: {agentVersion2.Name}, version: {agentVersion2.Version})");
        #endregion

        #region Snippet:Sample_Agents_GetAgentCRUD_Async
        ProjectsAgentRecord result = await agentsClient.GetAgentAsync(agentVersion1.Name);
        Console.WriteLine($"Agent created (id: {result.Id}, name: {result.Name})");
        #endregion

        #region Snippet:Sample_Agents_ListAgentsCRUD_Async
        await foreach (ProjectsAgentRecord agent in agentsClient.GetAgentsAsync())
        {
            Console.WriteLine($"Listed Agent: id: {agent.Id}, name: {agent.Name}");
        }
        #endregion

        #region Snippet:Sample_Agents_DeleteAgentCRUD_Async
        await agentsClient.DeleteAgentVersionAsync(agentName: agentVersion1.Name, agentVersion: agentVersion1.Version);
        Console.WriteLine($"Agent deleted (name: {agentVersion1.Name}, version: {agentVersion1.Version})");
        await agentsClient.DeleteAgentVersionAsync(agentName: agentVersion2.Name, agentVersion: agentVersion2.Version);
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
        AgentAdministrationClient agentsClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());

        #region Snippet:Sample_Agents_CreateAgentVersionCRUD_Sync
        DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a prompt agent."
        };
        ProjectsAgentVersion agentVersion1 = agentsClient.CreateAgentVersion(
            agentName: "myAgent1",
            options: new(agentDefinition));
        Console.WriteLine($"Agent created (id: {agentVersion1.Id}, name: {agentVersion1.Name}, version: {agentVersion1.Version})");
        ProjectsAgentVersion agentVersion2 = agentsClient.CreateAgentVersion(
            agentName: "myAgent2",
            options: new(agentDefinition));
        Console.WriteLine($"Agent created (id: {agentVersion2.Id}, name: {agentVersion2.Name}, version: {agentVersion2.Version})");
        #endregion

        #region Snippet:Sample_Agents_GetAgentCRUD_Sync
        ProjectsAgentRecord result = agentsClient.GetAgent(agentVersion1.Name);
        Console.WriteLine($"Agent created (id: {result.Id}, name: {result.Name})");
        #endregion

        #region Snippet:Sample_Agents_ListAgentsCRUD_Sync
        foreach (ProjectsAgentRecord agent in agentsClient.GetAgents())
        {
            Console.WriteLine($"Listed Agent: id: {agent.Id}, name: {agent.Name}");
        }
        #endregion

        #region Snippet:Sample_Agents_DeleteAgentCRUD_Sync
        agentsClient.DeleteAgentVersion(agentName: agentVersion1.Name, agentVersion: agentVersion1.Version);
        Console.WriteLine($"Agent deleted (name: {agentVersion1.Name}, version: {agentVersion1.Version})");
        agentsClient.DeleteAgentVersion(agentName: agentVersion2.Name, agentVersion: agentVersion2.Version);
        Console.WriteLine($"Agent deleted (name: {agentVersion2.Name}, version: {agentVersion2.Version})");
        #endregion
    }

    [Test]
    public void VersionSelection()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
#endif
        #region Snippet:Sample_Agents_API_version
        AgentAdministrationClientOptions options = new(version: AgentAdministrationClientOptions.ServiceVersion.V1);
        AgentAdministrationClient agentsClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential(), options: options);
        #endregion
    }

    [Test]
    [AsyncOnly]
    public async Task ErrorHandling()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
#endif
        AgentAdministrationClient agentsClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        #region Snippet:Sample_Agent_ErrorHandling
        try
        {
            ProjectsAgentVersion agent = await agentsClient.GetAgentVersionAsync(
                agentName: "agent_which_dies_not_exist", agentVersion: "1");
        }
        catch (ClientResultException e) when (e.Status == 404)
        {
            Console.WriteLine($"Exception status code: {e.Status}");
            Console.WriteLine($"Exception message: {e.Message}");
        }
        #endregion
    }

    public Sample_agents_CRUD(bool isAsync) : base(isAsync)
    { }
}
