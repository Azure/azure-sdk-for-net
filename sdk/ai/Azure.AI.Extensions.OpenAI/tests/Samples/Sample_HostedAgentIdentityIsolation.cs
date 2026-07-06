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

public class Sample_HostedAgentIdentityIsolation : ProjectsOpenAITestBase
{
    #region Snippet:Sample_IdentityHeader_HostedAgentIdentityIsolation
    internal class UserIdentityHeaderPolicy(string user_identity) : PipelinePolicy
    {
        private const string image_deployment_header = "x-ms-user-identity";

        public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        {
            message.Request.Headers.Add(image_deployment_header, user_identity);
            ProcessNext(message, pipeline, currentIndex);
        }

        public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        {
            // Add your desired header name and value
            message.Request.Headers.Add(image_deployment_header, user_identity);
            await ProcessNextAsync(message, pipeline, currentIndex);
        }
    }
    #endregion
    #region Snippet:Sample_HostedAgentIdentityIsolationDefinition_HostedAgentIdentityIsolation
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
    public async Task HostedAgentIdentityIsolationCreateAsync()
    {
        IgnoreSampleMayBe();
        #region Snippet:Sample_CreateAgentClient_HostedAgentIdentityIsolation
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var dockerImage = System.Environment.GetEnvironmentVariable("AGENT_DOCKER_IMAGE");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var dockerImage = TestEnvironment.AGENT_DOCKER_IMAGE;
#endif
        Uri uriEndpoint = new(projectEndpoint);
        AzureCliCredential credential = new();
        AIProjectClient projectClient = new(endpoint: uriEndpoint, tokenProvider: credential);
        #endregion

        #region Snippet:Sample_CreateAgent_HostedAgentIdentityIsolation_Async
        HostedAgentDefinition agentDefinition = GetAgentDefinition(
            dockerImage: dockerImage
        );
        ProjectsAgentVersionCreationOptions creationOptions = new(agentDefinition);
        creationOptions.Metadata["enableVnextExperience"] = "true";
        ProjectsAgentVersion agentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
            agentName: "myHostedAgent1",
            options: creationOptions);
        #endregion
        #region Snippet:Sample_WaitForDeployment_HostedAgentIdentityIsolation_Async
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
        #region Snippet:Sample_CreateTheEndpoint_HostedAgentIdentityIsolation_Async
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
        #region Snippet:Sample_GetResponseFromAgentEndpointUser1_HostedAgentIdentityIsolation_Async
        string userID1 = Guid.NewGuid().ToString();
        string userID2 = Guid.NewGuid().ToString();
        ProjectOpenAIClientOptions options = new();
        options.AddPolicy(new UserIdentityHeaderPolicy(userID1), PipelinePosition.PerCall);
        ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgentEndpoint(agentVersion.Name, options: options);
        ResponseResult response = await responseClient.CreateResponseAsync("1 + 1 = ?");
        Console.WriteLine(response.GetOutputText());
        #endregion
        #region Snippet:Sample_GetResponseFromAgentEndpointUser2_HostedAgentIdentityIsolation_Async
        options = new();
        options.AddPolicy(new UserIdentityHeaderPolicy(userID2), PipelinePosition.PerCall);
        responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgentEndpoint(agentVersion.Name, options: options);
        try
        {
            ResponseResult followUp1 = await responseClient.CreateResponseAsync("Then add 10 to the previous result", previousResponseId: response.Id);
            throw new InvalidOperationException($"The {response.Id} was created for identity {userID1}, but was found for {userID2}.");
        }
        catch (ClientResultException ex)
        {
            if (ex.Status == 404)
            {
                Console.WriteLine("Agent: Expected isolation behavior confirmed. A different delegated user cannot continue the previous response chain and must start a new conversation.");
            }
            else
            {
                throw;
            }
        }
        #endregion
        #region Snippet:Sample_GetResponseFromAgentEndpointUser1Again_HostedAgentIdentityIsolation_Async
        options = new();
        options.AddPolicy(new UserIdentityHeaderPolicy(userID1), PipelinePosition.PerCall);
        responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgentEndpoint(agentVersion.Name, options: options);
        ResponseResult followUp = await responseClient.CreateResponseAsync("Then add 10 to the previous result", previousResponseId: response.Id);
        Console.WriteLine(followUp.GetOutputText());
        #endregion
        #region Snippet:DeleteHostedAgentIdentityIsolation_HostedAgentIdentityIsolation_Async
        await projectClient.AgentAdministrationClient.DeleteAgentAsync(agentVersion.Name, force: true);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void HostedAgentIdentityIsolationCreateSync()
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
        AzureCliCredential credential = new();
        AIProjectClient projectClient = new(endpoint: uriEndpoint, tokenProvider: credential);

        #region Snippet:Sample_CreateAgent_HostedAgentIdentityIsolation_Sync
        HostedAgentDefinition agentDefinition = GetAgentDefinition(
            dockerImage: dockerImage
        );
        ProjectsAgentVersionCreationOptions creationOptions = new(agentDefinition);
        creationOptions.Metadata["enableVnextExperience"] = "true";
        ProjectsAgentVersion agentVersion = projectClient.AgentAdministrationClient.CreateAgentVersion(
            agentName: "myHostedAgent1",
            options: creationOptions);
        #endregion
        #region Snippet:Sample_WaitForDeployment_HostedAgentIdentityIsolation_Sync
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
        #region Snippet:Sample_CreateTheEndpoint_HostedAgentIdentityIsolation_Sync
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
        #region Snippet:Sample_GetResponseFromAgentEndpointUser1_HostedAgentIdentityIsolation_Sync
        string userID1 = Guid.NewGuid().ToString();
        string userID2 = Guid.NewGuid().ToString();
        ProjectOpenAIClientOptions options = new();
        options.AddPolicy(new UserIdentityHeaderPolicy(userID1), PipelinePosition.PerCall);
        ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgentEndpoint(agentVersion.Name, options: options);
        ResponseResult response = responseClient.CreateResponse("1 + 1 = ?");
        Console.WriteLine(response.GetOutputText());
        #endregion
        #region Snippet:Sample_GetResponseFromAgentEndpointUser2_HostedAgentIdentityIsolation_Sync
        options = new();
        options.AddPolicy(new UserIdentityHeaderPolicy(userID2), PipelinePosition.PerCall);
        responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgentEndpoint(agentVersion.Name, options: options);
        try
        {
            ResponseResult followUp1 = responseClient.CreateResponse("Then add 10 to the previous result", previousResponseId: response.Id);
            throw new InvalidOperationException($"The {response.Id} was created for identity {userID1}, but was found for {userID2}.");
        }
        catch (ClientResultException ex)
        {
            if (ex.Status == 404)
            {
                Console.WriteLine("Agent: Expected isolation behavior confirmed. A different delegated user cannot continue the previous response chain and must start a new conversation.");
            }
            else
            {
                throw;
            }
        }
        #endregion
        #region Snippet:Sample_GetResponseFromAgentEndpointUser1Again_HostedAgentIdentityIsolation_Sync
        options = new();
        options.AddPolicy(new UserIdentityHeaderPolicy(userID1), PipelinePosition.PerCall);
        responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgentEndpoint(agentVersion.Name, options: options);
        ResponseResult followUp = responseClient.CreateResponse("Then add 10 to the previous result", previousResponseId: response.Id);
        Console.WriteLine(followUp.GetOutputText());
        #endregion
        #region Snippet:DeleteHostedAgentIdentityIsolation_HostedAgentIdentityIsolation_Sync
        projectClient.AgentAdministrationClient.DeleteAgent(agentVersion.Name, force: true);
        #endregion
    }

    public Sample_HostedAgentIdentityIsolation(bool isAsync) : base(isAsync)
    { }
}
