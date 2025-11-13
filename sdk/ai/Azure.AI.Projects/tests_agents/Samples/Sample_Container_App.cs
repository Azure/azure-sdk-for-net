// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Projects.OpenAI;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI;
using OpenAI.Conversations;
using OpenAI.Responses;

namespace Azure.AI.Projects.Tests.Samples;

[Ignore("Samples represented as tests only for validation of compilation.")]
public class Sample_Container_App : AgentsTestBase
{
    [Test]
    [AsyncOnly]
    public async Task SampleContainerAppAsync()
    {
        #region Snippet:Sample_Create_client_ContainerApp
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var containerAppResourceId = System.Environment.GetEnvironmentVariable("CONTAINER_APP_RESOURCE_ID");
        var ingressSubdomainSuffix = System.Environment.GetEnvironmentVariable("INGRESS_SUBDOMAIN_SUFFIX");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var containerAppResourceId = TestEnvironment.CONTAINER_APP_RESOURCE_ID;
        var ingressSubdomainSuffix = TestEnvironment.INGRESS_SUBDOMAIN_SUFFIX;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        #endregion
        #region Snippet:Sample_CreateContainerApp_ContainerApp_Async
        AgentVersion containerAgentVersion = await projectClient.Agents.CreateAgentVersionAsync(
            agentName: "containerAgent",
            options: new(new ContainerApplicationAgentDefinition(
                containerProtocolVersions: [new ProtocolVersionRecord(protocol: AgentCommunicationMethod.Responses, version: "1")],
                containerAppResourceId: containerAppResourceId,
                ingressSubdomainSuffix: ingressSubdomainSuffix)));
        #endregion
        #region Snippet:Sample_CreateConversation_ContainerApp_Async
        ProjectConversationCreationOptions conversationOptions = new();
        conversationOptions.Items.Add(
            ResponseItem.CreateUserMessageItem("What is the size of France in square miles?")
        );
        AgentConversation conversation = await projectClient.OpenAI.Conversations.CreateAgentConversationAsync(conversationOptions);
        #endregion
        #region Snippet:Sample_CommunicateWithTheAgent_ContainerApp_Async
        ResponseCreationOptions responseOptions = new()
        {
            Agent = containerAgentVersion,
            AgentConversationId = conversation.Id,
        };
        OpenAIResponse response = await projectClient.OpenAI.Responses.CreateResponseAsync([], responseOptions);
        response = await WaitResponseAsync(projectClient.OpenAI.Responses, response);
        Console.WriteLine(response.GetOutputText());

        await projectClient.OpenAI.Conversations.CreateAgentConversationItemsAsync(
            conversationId: conversation.Id,
            items: [ResponseItem.CreateUserMessageItem("And what is the capital city?")]);
        response = await projectClient.OpenAI.Responses.CreateResponseAsync([], responseOptions);
        response = await WaitResponseAsync(projectClient.OpenAI.Responses, response);
        Console.WriteLine(response.GetOutputText());
        #endregion
        #region Snippet:Sample_Cleanup_ContainerApp_Async
        await projectClient.OpenAI.Conversations.DeleteConversationAsync(conversationId:conversation.Id);
        await projectClient.Agents.DeleteAgentVersionAsync(agentName: containerAgentVersion.Name, agentVersion: containerAgentVersion.Version);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void SampleContainerAppSync()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var containerAppResourceId = System.Environment.GetEnvironmentVariable("CONTAINER_APP_RESOURCE_ID");
        var ingressSubdomainSuffix = System.Environment.GetEnvironmentVariable("INGRESS_SUBDOMAIN_SUFFIX");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var containerAppResourceId = TestEnvironment.CONTAINER_APP_RESOURCE_ID;
        var ingressSubdomainSuffix = TestEnvironment.INGRESS_SUBDOMAIN_SUFFIX;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        #region Snippet:Sample_CreateContainerApp_ContainerApp_Sync
        AgentVersion containerAgentVersion = projectClient.Agents.CreateAgentVersion(
            agentName: "containerAgent",
            options: new(new ContainerApplicationAgentDefinition(
                containerProtocolVersions: [new ProtocolVersionRecord(protocol: AgentCommunicationMethod.Responses, version: "1")],
                containerAppResourceId: containerAppResourceId,
                ingressSubdomainSuffix: ingressSubdomainSuffix)));
        #endregion
        #region Snippet:Sample_CreateConversation_ContainerApp_Sync
        ProjectConversationCreationOptions conversationOptions = new();
        conversationOptions.Items.Add(
            ResponseItem.CreateUserMessageItem("What is the size of France in square miles?")
        );
        AgentConversation conversation = projectClient.OpenAI.Conversations.CreateAgentConversation(options: conversationOptions);
        #endregion
        #region Snippet:Sample_CommunicateWithTheAgent_ContainerApp_Sync
        ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(containerAgentVersion, conversation);
        OpenAIResponse response = responseClient.CreateResponse([]);
        response = WaitResponse(projectClient.OpenAI.Responses, response);
        Console.WriteLine(response.GetOutputText());

        projectClient.OpenAI.Conversations.CreateAgentConversationItems(
            conversationId: conversation.Id,
            items: [ResponseItem.CreateUserMessageItem("And what is the capital city?")]);
        response = projectClient.OpenAI.Responses.CreateResponse([]);
        response = WaitResponse(projectClient.OpenAI.Responses, response);
        Console.WriteLine(response.GetOutputText());
        #endregion
        #region Snippet:Sample_Cleanup_ContainerApp_Sync
        projectClient.OpenAI.Conversations.DeleteConversation(conversationId: conversation.Id);
        projectClient.Agents.DeleteAgentVersion(agentName: containerAgentVersion.Name, agentVersion: containerAgentVersion.Version);
        #endregion
    }

    #region Snippet:Sample_WaitForRun_ContainerApp_Sync
    private static OpenAIResponse WaitResponse(OpenAIResponseClient responseClient, OpenAIResponse response)
    {
        while (response.Status != ResponseStatus.Incomplete && response.Status != ResponseStatus.Failed && response.Status != ResponseStatus.Completed)
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(500));
            response = responseClient.GetResponse(responseId: response.Id);
        }
        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
        return response;
    }
    #endregion

    #region Snippet:Sample_WaitForRun_ContainerApp_Async
    private static async Task<OpenAIResponse> WaitResponseAsync(OpenAIResponseClient responseClient, OpenAIResponse response)
    {
        while (response.Status != ResponseStatus.Incomplete && response.Status != ResponseStatus.Failed && response.Status != ResponseStatus.Completed)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(500));
            response = await responseClient.GetResponseAsync(responseId: response.Id);
        }
        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
        return response;
    }
    #endregion

    public Sample_Container_App(bool isAsync) : base(isAsync)
    { }
}
