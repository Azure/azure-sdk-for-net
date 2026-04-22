// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Projects;
using Azure.AI.Projects.Agents;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI.Tests.Samples;

# pragma warning disable AAIP001
public class Sample_HostedAgent : ProjectsOpenAITestBase
{
    #region Snippet:Sample_HostedAgentDefinition_HostedAgent
    private static HostedAgentDefinition GetAgentDefinition(string dockerImage)
    {
        HostedAgentDefinition agentDefinition = new(
            versions: [new ProtocolVersionRecord(ProjectsAgentProtocol.Responses, "1.0.0")],
            cpu: "0.5",
            memory: "1Gi"
        )
        {
            Image = dockerImage,
        };
        return agentDefinition;
    }
    #endregion

    [Test]
    [AsyncOnly]
    public async Task HostedAgentCreateAsync()
    {
        IgnoreSampleMayBe();
        #region Snippet:Sample_CreateAgentClient_HostedAgent
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var containerImage = System.Environment.GetEnvironmentVariable("FOUNDRY_AGENT_CONTAINER_IMAGE");
        var dockerImage = System.Environment.GetEnvironmentVariable("AGENT_DOCKER_IMAGE");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var containerImage = TestEnvironment.FOUNDRY_AGENT_CONTAINER_IMAGE;
        var dockerImage = TestEnvironment.AGENT_DOCKER_IMAGE;
#endif
        Uri uriEndpoint = new(projectEndpoint);
        DefaultAzureCredential credential = new();
        AIProjectClient projectClient = new(endpoint: uriEndpoint, tokenProvider: credential);
        #endregion

        #region Snippet:Sample_CreateAgent_HostedAgent_Async
        HostedAgentDefinition agentDefinition = GetAgentDefinition(
            dockerImage: dockerImage
        );
        ProjectsAgentVersionCreationOptions creationOptions = new(agentDefinition);
        creationOptions.Metadata["enableVnextExperience"] = "true";
        ProjectsAgentVersion agentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
            agentName: "myHostedAgent",
            options: creationOptions);
        #endregion
        #region Snippet:Sample_WaitForDeployment_HostedAgent_Async
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
        #region Snippet:Sample_CreateTheEndpoint_HostedAgent_Async
        AgentEndpoint config = new()
        {
            VersionSelector = new([new FixedRatioVersionSelectionRule(agentVersion: agentVersion.Version, trafficPercentage: 100)]),
            Protocols = { AgentEndpointProtocol.Responses }
        };
        PatchAgentOptions patchOptions = new()
        {
            AgentEndpoint = config,
        };
        ProjectsAgentRecord patchedRecord = await projectClient.AgentAdministrationClient.PatchAgentObjectAsync(
            agentName: agentVersion.Name,
            patchAgentOptions: patchOptions);
        Console.WriteLine($"The Agent {patchedRecord.Name} was patched.");
        #endregion
        #region Snippet:Sample_GetResponseFromAgentEndpoint_HostedAgent_Async
        ProjectOpenAIClientOptions responsesOptions = new()
        {
            AgentName = agentVersion.Name
        };
        ProjectOpenAIClient openAIClient = new(uriEndpoint, credential, responsesOptions);
        ProjectResponsesClient responseClient = openAIClient.GetProjectResponsesClient();
        ResponseResult response = await responseClient.CreateResponseAsync("Hello, tell me a joke.");
        Console.WriteLine(response.GetOutputText());
        #endregion
        #region Snippet:DeleteHostedAgent_HostedAgent_Async
        await projectClient.AgentAdministrationClient.DeleteAgentAsync(agentVersion.Name);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void HostedAgentCreateSync()
    {
        IgnoreSampleMayBe();
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var containerImage = System.Environment.GetEnvironmentVariable("FOUNDRY_AGENT_CONTAINER_IMAGE");
        var dockerImage = System.Environment.GetEnvironmentVariable("AGENT_DOCKER_IMAGE");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var containerImage = TestEnvironment.FOUNDRY_AGENT_CONTAINER_IMAGE;
        var dockerImage = TestEnvironment.AGENT_DOCKER_IMAGE;
#endif
        Uri uriEndpoint = new(projectEndpoint);
        DefaultAzureCredential credential = new();
        AIProjectClient projectClient = new(endpoint: uriEndpoint, tokenProvider: credential);

        #region Snippet:Sample_CreateAgent_HostedAgent_Sync
        HostedAgentDefinition agentDefinition = GetAgentDefinition(
            dockerImage: dockerImage
        );
        ProjectsAgentVersionCreationOptions creationOptions = new(agentDefinition);
        creationOptions.Metadata["enableVnextExperience"] = "true";
        ProjectsAgentVersion agentVersion = projectClient.AgentAdministrationClient.CreateAgentVersion(
            agentName: "myHostedAgent",
            options: creationOptions);
        #endregion
        #region Snippet:Sample_WaitForDeployment_HostedAgent_Sync
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
        #region Snippet:Sample_CreateTheEndpoint_HostedAgent_Sync
        AgentEndpoint config = new()
        {
            VersionSelector = new([new FixedRatioVersionSelectionRule(agentVersion: agentVersion.Version, trafficPercentage: 100)]),
            Protocols = { AgentEndpointProtocol.Responses }
        };
        PatchAgentOptions patchOptions = new()
        {
            AgentEndpoint = config,
        };
        ProjectsAgentRecord patchedRecord = projectClient.AgentAdministrationClient.PatchAgentObject(
            agentName: agentVersion.Name,
            patchAgentOptions: patchOptions);
        Console.WriteLine($"The Agent {patchedRecord.Name} was patched.");
        #endregion
        #region Snippet:Sample_GetResponseFromAgentEndpoint_HostedAgent_Sync
        ProjectOpenAIClientOptions responsesOptions = new()
        {
            AgentName = agentVersion.Name
        };
        ProjectOpenAIClient openAIClient = new(uriEndpoint, credential, responsesOptions);
        ProjectResponsesClient responseClient = openAIClient.GetProjectResponsesClient();
        ResponseResult response = responseClient.CreateResponse("Hello, tell me a joke.");
        Console.WriteLine(response.GetOutputText());
        #endregion
        #region Snippet:DeleteHostedAgent_HostedAgent_Sync
        projectClient.AgentAdministrationClient.DeleteAgent(agentVersion.Name);
        #endregion
    }

    public Sample_HostedAgent(bool isAsync) : base(isAsync)
    { }
}
