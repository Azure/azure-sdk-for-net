// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Agents.Tests.Samples;

public class Sample_AgentDraft : SamplesBase
{
    [Test]
    [AsyncOnly]
    public async Task AgentDraftAsync()
    {
        #region Snippet:Sample_CreateAgentClient_AgentsDraft
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
#endif
        AgentAdministrationClientOptions options = new();
        options.AddPolicy(new FeaturePolicy("DraftAgents=V1Preview"), PipelinePosition.PerCall);
        AgentAdministrationClient agentsClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential(), options: options);
        #endregion

        #region Snippet:Sample_CreateAgentVersion_AgentsDraft_Async
        DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a prompt agent, which always give wrong responses."
        };
        ProjectsAgentVersion agentVersion1 = await agentsClient.CreateAgentVersionAsync(
            agentName: "myAgentWithDraft",
            options: new(agentDefinition));
        Console.WriteLine($"Agent created: name: {agentVersion1.Name}, version: {agentVersion1.Version}");
        #endregion
        #region Snippet:Sample_GetDefaultVersion_AgentsDraft_Async
        ProjectsAgentRecord agent = await agentsClient.GetAgentAsync(agentName: agentVersion1.Name);
        Console.WriteLine($"The latest version of agent \"{agent.Name}\" is {agent.Versions.Latest.Version}.");
        #endregion

        #region Snippet:Sample_CreateAnotherAgentVersion_AgentsDraft_Async
        agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a prompt agent which frequently give wrong responses."
        };
        ProjectsAgentVersion agentVersion2 = await agentsClient.CreateAgentVersionAsync(
            agentName: agent.Name,
            options: new(agentDefinition));
        Console.WriteLine($"Agent created name: {agentVersion2.Name}, version: {agentVersion2.Version}");
        agent = await agentsClient.GetAgentAsync(agentName: agentVersion1.Name);
        Console.WriteLine($"The latest version of agent \"{agent.Name}\" is now {agent.Versions.Latest.Version}.");
        #endregion

        #region Snippet:Sample_CreateDraft_AgentsDraft_Async
        agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a prompt agent which gives wrong answers with 0.1 probability."
        };
        ProjectsAgentVersion agentVersionDraft = await agentsClient.CreateAgentVersionAsync(
            agentName: agent.Name,
            options: new(agentDefinition)
            {
                Draft = true
            }
        );
        Console.WriteLine($"Agent created draft name: {agentVersionDraft.Name}, version: {agentVersionDraft.Version}");
        agent = await agentsClient.GetAgentAsync(agentName: agentVersion1.Name);
        Console.WriteLine($"The latest version of agent \"{agent.Name}\" is still {agent.Versions.Latest.Version}.");
        #endregion

        #region Snippet:Sample_ListReleaseAgents_AgentsDraft_Async
        Console.WriteLine($"Here are \"release\" versions of the agent {agent.Name}:");
        await foreach (ProjectsAgentVersion agentVersion in agentsClient.GetAgentVersionsAsync(agentName: agent.Name))
        {
            Console.WriteLine($"    {agentVersion.Version}");
        }
        #endregion

        #region Snippet:Sample_ListReleaseAgentsWithDrafts_AgentsDraft_Async
        Console.WriteLine($"Here are \"release\" versions of the agent {agent.Name}:");
        await foreach (ProjectsAgentVersion agentVersion in agentsClient.GetAgentVersionsAsync(agentName: agent.Name, includeDrafts: true))
        {
            Console.WriteLine($"    {agentVersion.Version}, is draft: {agentVersion.Draft ?? false}");
        }
        #endregion

        #region Snippet:Sample_DeleteAgent_AgentsDraft_Async
        await agentsClient.DeleteAgentAsync(agentName: agentVersion1.Name);
        Console.WriteLine($"Agent deleted (name: {agentVersion1.Name})");
        #endregion
    }

    [Test]
    [SyncOnly]
    public void AgentDraftSync()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
#endif
        AgentAdministrationClientOptions options = new();
        options.AddPolicy(new FeaturePolicy("DraftAgents=V1Preview"), PipelinePosition.PerCall);
        AgentAdministrationClient agentsClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential(), options: options);

        #region Snippet:Sample_CreateAgentVersion_AgentsDraft_Sync
        DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a prompt agent, which always give wrong responses."
        };
        ProjectsAgentVersion agentVersion1 = agentsClient.CreateAgentVersion(
            agentName: "myAgentWithDraft",
            options: new(agentDefinition));
        Console.WriteLine($"Agent created: name: {agentVersion1.Name}, version: {agentVersion1.Version}");
        #endregion
        #region Snippet:Sample_GetDefaultVersion_AgentsDraft_Sync
        ProjectsAgentRecord agent = agentsClient.GetAgent(agentName: agentVersion1.Name);
        Console.WriteLine($"The latest version of agent \"{agent.Name}\" is {agent.Versions.Latest.Version}.");
        #endregion

        #region Snippet:Sample_CreateAnotherAgentVersion_AgentsDraft_Sync
        agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a prompt agent which frequently give wrong responses."
        };
        ProjectsAgentVersion agentVersion2 = agentsClient.CreateAgentVersion(
            agentName: agent.Name,
            options: new(agentDefinition));
        Console.WriteLine($"Agent created name: {agentVersion2.Name}, version: {agentVersion2.Version}");
        agent = agentsClient.GetAgent(agentName: agentVersion1.Name);
        Console.WriteLine($"The latest version of agent \"{agent.Name}\" is now {agent.Versions.Latest.Version}.");
        #endregion

        #region Snippet:Sample_CreateDraft_AgentsDraft_Sync
        agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a prompt agent which gives wrong answers with 0.1 probability."
        };
        ProjectsAgentVersion agentVersionDraft = agentsClient.CreateAgentVersion(
            agentName: agent.Name,
            options: new(agentDefinition)
            {
                Draft = true
            }
        );
        Console.WriteLine($"Agent created draft name: {agentVersionDraft.Name}, version: {agentVersionDraft.Version}");
        agent = agentsClient.GetAgent(agentName: agentVersion1.Name);
        Console.WriteLine($"The latest version of agent \"{agent.Name}\" is still {agent.Versions.Latest.Version}.");
        #endregion

        #region Snippet:Sample_ListReleaseAgents_AgentsDraft_Sync
        Console.WriteLine($"Here are \"release\" versions of the agent {agent.Name}:");
        foreach (ProjectsAgentVersion agentVersion in agentsClient.GetAgentVersions(agentName: agent.Name))
        {
            Console.WriteLine($"    {agentVersion.Version}");
        }
        #endregion

        #region Snippet:Sample_ListReleaseAgentsWithDrafts_AgentsDraft_Sync
        Console.WriteLine($"Here are \"release\" versions of the agent {agent.Name}:");
        foreach (ProjectsAgentVersion agentVersion in agentsClient.GetAgentVersions(agentName: agent.Name, includeDrafts: true))
        {
            Console.WriteLine($"    {agentVersion.Version}, is draft: {agentVersion.Draft ?? false}");
        }
        #endregion

        #region Snippet:Sample_DeleteAgent_AgentsDraft_Sync
        agentsClient.DeleteAgent(agentName: agentVersion1.Name);
        Console.WriteLine($"Agent deleted (name: {agentVersion1.Name})");
        #endregion
    }

    public Sample_AgentDraft(bool isAsync) : base(isAsync)
    { }
}
