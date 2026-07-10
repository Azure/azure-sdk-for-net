// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Projects;
using Azure.AI.Projects.Agents;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI.Tests.Samples;

public class Sample_HostedAgentSessions : ProjectsOpenAITestBase
{
    #region Snippet:Sample_HostedAgentSessionsDefinition_HostedAgentSessions
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

    #region Snippet:Sample_SessionHeaderPolicy_HostedAgentSessions
    private class SessionHeaderPolicy(string agentSessionID) : PipelinePolicy
    {
        private static readonly string _SESSION_HEADER = "x-agent-session-id";
        public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        {
            message.Request.Headers.Add(_SESSION_HEADER, agentSessionID);
            ProcessNext(message, pipeline, currentIndex);
        }

        public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        {
            message.Request.Headers.Add(_SESSION_HEADER, agentSessionID);
            await ProcessNextAsync(message, pipeline, currentIndex);
        }
    }
    #endregion

    [Test]
    [AsyncOnly]
    public async Task HostedAgentSessionsCreateAsync()
    {
        IgnoreSampleMayBe();
        #region Snippet:Sample_CreateAgentClient_HostedAgentSessions
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var dockerImage = System.Environment.GetEnvironmentVariable("AGENT_DOCKER_IMAGE");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var dockerImage = TestEnvironment.AGENT_DOCKER_IMAGE;
#endif
        Uri uriEndpoint = new(projectEndpoint);
        AIProjectClient projectClient = new(endpoint: uriEndpoint, tokenProvider: new DefaultAzureCredential());
        #endregion

        #region Snippet:Sample_CreateAgent_HostedAgentSessions_Async
        HostedAgentDefinition agentDefinition = GetAgentDefinition(
            dockerImage: dockerImage
        );
        ProjectsAgentVersionCreationOptions creationOptions = new(agentDefinition);
        creationOptions.Metadata["enableVnextExperience"] = "true";
        ProjectsAgentVersion agentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
            agentName: "myHostedAgent",
            options: creationOptions);
        #endregion
        #region Snippet:Sample_WaitForDeployment_HostedAgentSessions_Async
        while (agentVersion.Status != AgentVersionStatus.Active && agentVersion.Status != AgentVersionStatus.Failed)
        {
            await Task.Delay(500);
            agentVersion = await projectClient.AgentAdministrationClient.GetAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        }
        if (agentVersion.Status != AgentVersionStatus.Active)
        {
            throw new InvalidOperationException($"The Agent deployment failed, status: {agentVersion.Status}");
        }
        #endregion
        #region Snippet:Sample_CreateTheEndpoint_HostedAgentSessions_Async
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
        ProjectsAgentRecord patchedRecord = await projectClient.AgentAdministrationClient.PatchAgentAsync(
            agentName: agentVersion.Name,
            patchAgentOptions: patchOptions);
        Console.WriteLine($"The Agent {patchedRecord.Name} was patched.");
        #endregion
        // If we have occasionally disabled the Agent, enable it again.
        await projectClient.AgentAdministrationClient.EnableAgentAsync(agentVersion.Name);
        #region Snippet:Sample_GetResponseFromAgentEndpoint_HostedAgentSessions_Async
        ProjectAgentSession session1 = await projectClient.AgentAdministrationClient.CreateSessionAsync(agentVersion.Name, new VersionRefIndicator(agentVersion.Version));
        while (session1.Status != AgentSessionStatus.Failed && session1.Status != AgentSessionStatus.Active)
        {
            await Task.Delay(500);
            session1 = await projectClient.AgentAdministrationClient.GetSessionAsync(agentName: agentVersion.Name, sessionId: session1.AgentSessionId);
        }
        ProjectOpenAIClientOptions oaiOptions = new();
        oaiOptions.AddPolicy(new SessionHeaderPolicy(session1.AgentSessionId), PipelinePosition.PerCall);
        ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgentEndpoint(agentVersion.Name, options: oaiOptions);
        ResponseResult response = await responseClient.CreateResponseAsync("Hello, tell me a joke.");
        Console.WriteLine(response.GetOutputText());
        #endregion
        #region Snippet:Sample_DisableTheAgent_HostedAgentSessions_Async
        await projectClient.AgentAdministrationClient.DisableAgentAsync(agentVersion.Name);
        // The new session cannot be created.
        try
        {
            await projectClient.AgentAdministrationClient.CreateSessionAsync(agentVersion.Name, new VersionRefIndicator(agentVersion.Version));
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
        #region Snippet:Sample_EnableTheAgent_HostedAgentSessions_Async
        await projectClient.AgentAdministrationClient.EnableAgentAsync(agentVersion.Name);
        ProjectAgentSession session2 = await projectClient.AgentAdministrationClient.CreateSessionAsync(agentVersion.Name, new VersionRefIndicator(agentVersion.Version));
        while (session2.Status != AgentSessionStatus.Failed && session2.Status != AgentSessionStatus.Active)
        {
            await Task.Delay(500);
            session2 = await projectClient.AgentAdministrationClient.GetSessionAsync(agentName: agentVersion.Name, sessionId: session2.AgentSessionId);
        }
        oaiOptions = new();
        oaiOptions.AddPolicy(new SessionHeaderPolicy(session2.AgentSessionId), PipelinePosition.PerCall);
        responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgentEndpoint(agentVersion.Name, options: oaiOptions);
        response = await responseClient.CreateResponseAsync("Hello, tell me another joke.");
        Console.WriteLine(response.GetOutputText());
        #endregion
        #region Snippet:DeleteHostedAgentSessions_HostedAgentSessions_Async
        await projectClient.AgentAdministrationClient.DeleteAgentAsync(agentVersion.Name, force: true);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void HostedAgentSessionsCreateSync()
    {
        IgnoreSampleMayBe();
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var dockerImage = System.Environment.GetEnvironmentVariable("AGENT_DOCKER_IMAGE");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var dockerImage = TestEnvironment.AGENT_DOCKER_IMAGE;
#endif
        Uri uriEndpoint = new(projectEndpoint);
        AIProjectClient projectClient = new(endpoint: uriEndpoint, tokenProvider: new DefaultAzureCredential());

        #region Snippet:Sample_CreateAgent_HostedAgentSessions_Sync
        HostedAgentDefinition agentDefinition = GetAgentDefinition(
            dockerImage: dockerImage
        );
        ProjectsAgentVersionCreationOptions creationOptions = new(agentDefinition);
        creationOptions.Metadata["enableVnextExperience"] = "true";
        ProjectsAgentVersion agentVersion = projectClient.AgentAdministrationClient.CreateAgentVersion(
            agentName: "myHostedAgent",
            options: creationOptions);
        #endregion
        #region Snippet:Sample_WaitForDeployment_HostedAgentSessions_Sync
        while (agentVersion.Status != AgentVersionStatus.Active && agentVersion.Status != AgentVersionStatus.Failed)
        {
            Thread.Sleep(500);
            agentVersion = projectClient.AgentAdministrationClient.GetAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        }
        if (agentVersion.Status != AgentVersionStatus.Active)
        {
            throw new InvalidOperationException($"The Agent deployment failed, status: {agentVersion.Status}");
        }
        #endregion
        #region Snippet:Sample_CreateTheEndpoint_HostedAgentSessions_Sync
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
        ProjectsAgentRecord patchedRecord = projectClient.AgentAdministrationClient.PatchAgent(
            agentName: agentVersion.Name,
            patchAgentOptions: patchOptions);
        Console.WriteLine($"The Agent {patchedRecord.Name} was patched.");
        #endregion
        // If we have occasionally disabled the Agent, enable it again.
        projectClient.AgentAdministrationClient.EnableAgent(agentVersion.Name);
        #region Snippet:Sample_GetResponseFromAgentEndpoint_HostedAgentSessions_Sync
        ProjectAgentSession session1 = projectClient.AgentAdministrationClient.CreateSession(agentVersion.Name, new VersionRefIndicator(agentVersion.Version));
        while (session1.Status != AgentSessionStatus.Failed && session1.Status != AgentSessionStatus.Active)
        {
            Thread.Sleep(500);
            session1 = projectClient.AgentAdministrationClient.GetSession(agentName: agentVersion.Name, sessionId: session1.AgentSessionId);
        }
        ProjectOpenAIClientOptions oaiOptions = new();
        oaiOptions.AddPolicy(new SessionHeaderPolicy(session1.AgentSessionId), PipelinePosition.PerCall);
        ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgentEndpoint(agentVersion.Name, options: oaiOptions);
        ResponseResult response = responseClient.CreateResponse("Hello, tell me a joke.");
        Console.WriteLine(response.GetOutputText());
        #endregion
        #region Snippet:Sample_DisableTheAgent_HostedAgentSessions_Sync
        projectClient.AgentAdministrationClient.DisableAgent(agentVersion.Name);
        // The new session cannot be created.
        try
        {
            projectClient.AgentAdministrationClient.CreateSession(agentVersion.Name, new VersionRefIndicator(agentVersion.Version));
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
        #region Snippet:Sample_EnableTheAgent_HostedAgentSessions_Sync
        projectClient.AgentAdministrationClient.EnableAgent(agentVersion.Name);
        ProjectAgentSession session2 = projectClient.AgentAdministrationClient.CreateSession(agentVersion.Name, new VersionRefIndicator(agentVersion.Version));
        while (session2.Status != AgentSessionStatus.Failed && session2.Status != AgentSessionStatus.Active)
        {
            Thread.Sleep(500);
            session2 = projectClient.AgentAdministrationClient.GetSession(agentName: agentVersion.Name, sessionId: session2.AgentSessionId);
        }
        oaiOptions = new();
        oaiOptions.AddPolicy(new SessionHeaderPolicy(session2.AgentSessionId), PipelinePosition.PerCall);
        responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgentEndpoint(agentVersion.Name, options: oaiOptions);
        response = responseClient.CreateResponse("Hello, tell me another joke.");
        Console.WriteLine(response.GetOutputText());
        #endregion
        #region Snippet:DeleteHostedAgentSessions_HostedAgentSessions_Sync
        projectClient.AgentAdministrationClient.DeleteAgent(agentVersion.Name, force: true);
        #endregion
    }

    public Sample_HostedAgentSessions(bool isAsync) : base(isAsync)
    { }
}
