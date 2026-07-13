// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Agents.Tests.Samples;

public class Sample_HostedAgentDisable : SamplesBase
{
    #region Snippet:Sample_HostedAgentSessionsAgentsDefinition_HostedAgentSessionsAgents
    private static HostedAgentDefinition GetAgentDefinition(string dockerImage)
    {
        HostedAgentDefinition agentDefinition = new(
            versions: [new ProtocolVersionRecord(ProjectsAgentProtocol.Responses, "1.0.0")],
            cpu: "0.5",
            memory: "1Gi"
        )
        {
            ContainerConfiguration = new(dockerImage)
        };
        return agentDefinition;
    }
    #endregion

    [Test]
    [AsyncOnly]
    public async Task HostedAgentDisableAsync()
    {
        #region Snippet:Sample_CreateAgentClient_HostedAgentSessionsAgents
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var dockerImage = System.Environment.GetEnvironmentVariable("AGENT_DOCKER_IMAGE");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var dockerImage = TestEnvironment.AGENT_DOCKER_IMAGE;
#endif
        AgentAdministrationClient agentsClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        #endregion

        #region Snippet:Sample_CreateAgent_HostedAgentSessionsAgents_Async
        HostedAgentDefinition agentDefinition = GetAgentDefinition(
            dockerImage: dockerImage
        );
        ProjectsAgentVersionCreationOptions creationOptions = new(agentDefinition);
        creationOptions.Metadata["enableVnextExperience"] = "true";
        ProjectsAgentVersion agentVersion = await agentsClient.CreateAgentVersionAsync(
            agentName: "myHostedAgent",
            options: creationOptions);
        #endregion
        #region Snippet:Sample_WaitForDeployment_HostedAgentSessionsAgents_Async
        while (agentVersion.Status != AgentVersionStatus.Active && agentVersion.Status != AgentVersionStatus.Failed)
        {
            await Task.Delay(500);
            agentVersion = await agentsClient.GetAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        }
        if (agentVersion.Status != AgentVersionStatus.Active)
        {
            throw new InvalidOperationException($"The Agent deployment failed, status: {agentVersion.Status}");
        }
        #endregion
        #region Snippet:Sample_CreateTheEndpoint_HostedAgentSessionsAgents_Async
        AgentEndpointConfiguration config = new()
        {
            VersionSelector = new([new FixedRatioVersionSelectionRule(agentVersion: agentVersion.Version, trafficPercentage: 100)]),
            ProtocolConfiguration = new()
            {
                Responses = new()
            }
        };
        PatchAgentOptions patchOptions = new()
        {
            AgentEndpoint = config,
        };
        ProjectsAgentRecord patchedRecord = await agentsClient.PatchAgentAsync(
            agentName: agentVersion.Name,
            patchAgentOptions: patchOptions);
        Console.WriteLine($"The Agent {patchedRecord.Name} was patched.");
        #endregion
        // If we have occasionally disabled the Agent, enable it again.
        await agentsClient.EnableAgentAsync(agentVersion.Name);
        #region Snippet:Sample_CreateSession_HostedAgentSessionsAgents_Async
        ProjectAgentSession session1 = await agentsClient.CreateSessionAsync(agentVersion.Name, new VersionRefIndicator(agentVersion.Version));
        Console.WriteLine($"The session {session1.AgentSessionId} was created.");
        #endregion
        #region Snippet:Sample_DisableTheAgent_HostedAgentSessionsAgents_Async
        await agentsClient.DisableAgentAsync(agentVersion.Name);
        // The new session cannot be created.
        try
        {
            await agentsClient.CreateSessionAsync(agentVersion.Name, new VersionRefIndicator(agentVersion.Version));
            throw new InvalidOperationException("Stopped Agent was unexpectedly able to create session.");
        }
        catch (ClientResultException ex)
        {
            if (ex.Status != 403)
            {
                throw;
            }
            Console.WriteLine(ex.Message);
        }
        #endregion
        #region Snippet:Sample_EnableTheAgent_HostedAgentSessionsAgents_Async
        await agentsClient.EnableAgentAsync(agentVersion.Name);
        ProjectAgentSession session2 = await agentsClient.CreateSessionAsync(agentVersion.Name, new VersionRefIndicator(agentVersion.Version));
        Console.WriteLine($"The session {session2.AgentSessionId} was created.");
        #endregion
        #region Snippet:DeleteHostedAgentSessionsAgents_HostedAgentSessionsAgents_Async
        await agentsClient.DeleteAgentAsync(agentVersion.Name, force: true);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void HostedAgentDisableSync()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var dockerImage = System.Environment.GetEnvironmentVariable("AGENT_DOCKER_IMAGE");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var dockerImage = TestEnvironment.AGENT_DOCKER_IMAGE;
#endif
        AgentAdministrationClient agentsClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());

        #region Snippet:Sample_CreateAgent_HostedAgentSessionsAgents_Sync
        HostedAgentDefinition agentDefinition = GetAgentDefinition(
            dockerImage: dockerImage
        );
        ProjectsAgentVersionCreationOptions creationOptions = new(agentDefinition);
        creationOptions.Metadata["enableVnextExperience"] = "true";
        ProjectsAgentVersion agentVersion = agentsClient.CreateAgentVersion(
            agentName: "myHostedAgent",
            options: creationOptions);
        #endregion
        #region Snippet:Sample_WaitForDeployment_HostedAgentSessionsAgents_Sync
        while (agentVersion.Status != AgentVersionStatus.Active && agentVersion.Status != AgentVersionStatus.Failed)
        {
            Thread.Sleep(500);
            agentVersion = agentsClient.GetAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        }
        if (agentVersion.Status != AgentVersionStatus.Active)
        {
            throw new InvalidOperationException($"The Agent deployment failed, status: {agentVersion.Status}");
        }
        #endregion
        #region Snippet:Sample_CreateTheEndpoint_HostedAgentSessionsAgents_Sync
        AgentEndpointConfiguration config = new()
        {
            VersionSelector = new([new FixedRatioVersionSelectionRule(agentVersion: agentVersion.Version, trafficPercentage: 100)]),
            ProtocolConfiguration = new()
            {
                Responses = new()
            }
        };
        PatchAgentOptions patchOptions = new()
        {
            AgentEndpoint = config,
        };
        ProjectsAgentRecord patchedRecord = agentsClient.PatchAgent(
            agentName: agentVersion.Name,
            patchAgentOptions: patchOptions);
        Console.WriteLine($"The Agent {patchedRecord.Name} was patched.");
        #endregion
        // If we have occasionally disabled the Agent, enable it again.
        agentsClient.EnableAgent(agentVersion.Name);
        #region Snippet:Sample_CreateSession_HostedAgentSessionsAgents_Sync
        ProjectAgentSession session1 = agentsClient.CreateSession(agentVersion.Name, new VersionRefIndicator(agentVersion.Version));
        Console.WriteLine($"The session {session1.AgentSessionId} was created.");
        #endregion
        #region Snippet:Sample_DisableTheAgent_HostedAgentSessionsAgents_Sync
        agentsClient.DisableAgent(agentVersion.Name);
        // The new session cannot be created.
        try
        {
            agentsClient.CreateSession(agentVersion.Name, new VersionRefIndicator(agentVersion.Version));
            throw new InvalidOperationException("Stopped Agent was unexpectedly able to create session.");
        }
        catch (ClientResultException ex)
        {
            if (ex.Status != 403)
            {
                throw;
            }
            Console.WriteLine(ex.Message);
        }
        #endregion
        #region Snippet:Sample_EnableTheAgent_HostedAgentSessionsAgents_Sync
        agentsClient.EnableAgent(agentVersion.Name);
        ProjectAgentSession session2 = agentsClient.CreateSession(agentVersion.Name, new VersionRefIndicator(agentVersion.Version));
        Console.WriteLine($"The session {session2.AgentSessionId} was created.");
        #endregion
        #region Snippet:DeleteHostedAgentSessionsAgents_HostedAgentSessionsAgents_Sync
        agentsClient.DeleteAgent(agentVersion.Name, force: true);
        #endregion
    }

    public Sample_HostedAgentDisable(bool isAsync) : base(isAsync)
    { }
}
