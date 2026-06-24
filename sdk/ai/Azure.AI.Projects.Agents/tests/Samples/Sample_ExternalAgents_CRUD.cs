// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Agents.Tests.Samples;
#pragma warning disable AAIP001

public class Sample_ExternalAgents_CRUD : SamplesBase
{
    [Test]
    [AsyncOnly]
    public async Task ExternalAgentsCRUDAsync()
    {
        #region Snippet:Sample_CreateClient_ExternalAgentsCRUD
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
#endif
        AgentAdministrationClientOptions options = new();
        options.AddPolicy(new FeaturePolicy("ExternalAgents=V1Preview"), PipelinePosition.PerCall);
        AgentAdministrationClient agentsClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential(), options: options);
        #endregion

        #region Snippet:Sample_CreateAgentVersion_ExternalAgentsCRUD_Async
        ExternalAgentDefinition agentDefinition = new()
        {
            OtelAgentId = "sample-external-agent",
        };
        ProjectsAgentVersionCreationOptions agentOptions = new(agentDefinition)
        {
            Description = "External agent registered by the azure-ai-projects sample.",
            Metadata = {
                { "sample", "external_agents_crud" },
                { "status", "created" }
            }
        };
        ProjectsAgentVersion agentVersion = await agentsClient.CreateAgentVersionAsync(
            agentName: "myExternalAgent1",
            options: agentOptions);
        Console.WriteLine($"Agent created (id: {agentVersion.Id}, name: {agentVersion.Name}, version: {agentVersion.Version})");
        #endregion

        #region Snippet:Sample_Get_ExternalAgentsCRUD_Async
        ProjectsAgentRecord result = await agentsClient.GetAgentAsync(agentVersion.Name);
        Console.WriteLine($"Agent retrieved (id: {result.Id}, name: {result.Name}, latest version: {result.Versions.Latest})");
        #endregion

        #region Snippet:Sample_ListAgentVersions_ExternalAgentsCRUD_Async
        Console.WriteLine($"Versions for agent {agentVersion.Name}");
        await foreach (ProjectsAgentVersion oneAgentVersion in agentsClient.GetAgentVersionsAsync(agentVersion.Name))
        {
            Console.WriteLine($"    - Agent id: {oneAgentVersion.Id}, version: {oneAgentVersion.Version}");
        }
        #endregion

        #region Snippet:Sample_ListAgents_ExternalAgentsCRUD_Async
        Console.WriteLine("Found the next Agents.");
        await foreach (ProjectsAgentRecord agent in agentsClient.GetAgentsAsync(kind: ProjectsAgentKind.External))
        {
            Console.WriteLine($"    - Agent id: {agent.Id}, name: {agent.Name}, latest version: {agent.Versions.Latest.Version}");
        }
        #endregion

        #region Snippet:Sample_DeleteAgent_ExternalAgentsCRUD_Async
        await agentsClient.DeleteAgentAsync(agentName: agentVersion.Name);
        Console.WriteLine($"Agent deleted (name: {agentVersion.Name})");
        #endregion
    }

    [Test]
    [SyncOnly]
    public void ExternalAgentsCRUDSync()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
#endif
        AgentAdministrationClientOptions options = new();
        options.AddPolicy(new FeaturePolicy("ExternalAgents=V1Preview"), PipelinePosition.PerCall);
        AgentAdministrationClient agentsClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential(), options: options);

        #region Snippet:Sample_CreateAgentVersion_ExternalAgentsCRUD_Sync
        ExternalAgentDefinition agentDefinition = new()
        {
            OtelAgentId = "sample-external-agent",
        };
        ProjectsAgentVersionCreationOptions agentOptions = new(agentDefinition)
        {
            Description = "External agent registered by the azure-ai-projects sample.",
            Metadata = {
                { "sample", "external_agents_crud" },
                { "status", "created" }
            }
        };
        ProjectsAgentVersion agentVersion = agentsClient.CreateAgentVersion(
            agentName: "myExternalAgent1",
            options: agentOptions);
        Console.WriteLine($"Agent created (id: {agentVersion.Id}, name: {agentVersion.Name}, version: {agentVersion.Version})");
        #endregion

        #region Snippet:Sample_Get_ExternalAgentsCRUD_Sync
        ProjectsAgentRecord result = agentsClient.GetAgent(agentVersion.Name);
        Console.WriteLine($"Agent retrieved (id: {result.Id}, name: {result.Name}, latest version: {result.Versions.Latest})");
        #endregion

        #region Snippet:Sample_ListAgentVersions_ExternalAgentsCRUD_Sync
        Console.WriteLine($"Versions for agent {agentVersion.Name}");
        foreach (ProjectsAgentVersion oneAgentVersion in agentsClient.GetAgentVersions(agentVersion.Name))
        {
            Console.WriteLine($"    - Agent id: {oneAgentVersion.Id}, version: {oneAgentVersion.Version}");
        }
        #endregion

        #region Snippet:Sample_ListAgents_ExternalAgentsCRUD_Sync
        Console.WriteLine("Found the next Agents.");
        foreach (ProjectsAgentRecord agent in agentsClient.GetAgents(kind: ProjectsAgentKind.External))
        {
            Console.WriteLine($"    - Agent id: {agent.Id}, name: {agent.Name}, latest version: {agent.Versions.Latest.Version}");
        }
        #endregion

        #region Snippet:Sample_DeleteAgent_ExternalAgentsCRUD_Sync
        agentsClient.DeleteAgent(agentName: agentVersion.Name);
        Console.WriteLine($"Agent deleted (name: {agentVersion.Name})");
        #endregion
    }

    public Sample_ExternalAgents_CRUD(bool isAsync) : base(isAsync)
    { }
}
