// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI;
using OpenAI.Responses;

namespace Azure.AI.Agents.Tests.Samples;

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
        AgentClient client = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        #endregion
        #region Snippet:Sample_CreateContainerApp_ContainerApp_Async
        AgentVersion containerAgentVersion = await client.CreateAgentVersionAsync(
            agentName: "containerAgent",
            options: new(new ContainerAppAgentDefinition(
                containerProtocolVersions: [new ProtocolVersionRecord(protocol: AgentCommunicationMethod.Responses, version: "1")],
                containerAppResourceId: containerAppResourceId,
                ingressSubdomainSuffix: ingressSubdomainSuffix)));
        #endregion
        #region Snippet:Sample_CreateConversation_ContainerApp_Async
        OpenAIClient openAIClient = client.GetOpenAIClient();
        OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(modelDeploymentName);
        ConversationClient conversationClient = client.GetConversationClient();
        AgentConversationCreationOptions conversationOptions = new();
        conversationOptions.Items.Add(
            ResponseItem.CreateUserMessageItem("What is the size of France in square miles?")
        );
        AgentConversation conversation = await conversationClient.CreateConversationAsync(options: conversationOptions);
        #endregion
        #region Snippet:Sample_CommunicateWithTheAgent_ContainerApp_Async
        AgentReference agentReference = new(name: containerAgentVersion.Name)
        {
            Version = containerAgentVersion.Version,
        };

        OpenAIResponse response = await responseClient.CreateResponseAsync(
            agentRef: agentReference,
            conversation: conversation
        );
        response = await WaitResponseAsync(responseClient, response);
        Console.WriteLine(response.GetOutputText());

        await conversationClient.CreateConversationItemsAsync(
            conversationId: conversation.Id,
            items: [ResponseItem.CreateUserMessageItem("And what is the capital city?")]);
        response = await responseClient.CreateResponseAsync(
            agentRef: agentReference,
            conversation: conversation
        );
        response = await WaitResponseAsync(responseClient, response);
        Console.WriteLine(response.GetOutputText());
        #endregion
        #region Snippet:Sample_Cleanup_ContainerApp_Async
        await conversationClient.DeleteConversationAsync(conversationId:conversation.Id);
        await client.DeleteAgentVersionAsync(agentName: containerAgentVersion.Name, agentVersion: containerAgentVersion.Version);
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
        AgentClient client = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        #region Snippet:Sample_CreateContainerApp_ContainerApp_Sync
        AgentVersion containerAgentVersion = client.CreateAgentVersion(
            agentName: "containerAgent",
            options: new(new ContainerAppAgentDefinition(
                containerProtocolVersions: [new ProtocolVersionRecord(protocol: AgentCommunicationMethod.Responses, version: "1")],
                containerAppResourceId: containerAppResourceId,
                ingressSubdomainSuffix: ingressSubdomainSuffix)));
        #endregion
        #region Snippet:Sample_CreateConversation_ContainerApp_Sync
        OpenAIClient openAIClient = client.GetOpenAIClient();
        OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(modelDeploymentName);
        ConversationClient conversationClient = client.GetConversationClient();
        AgentConversationCreationOptions conversationOptions = new();
        conversationOptions.Items.Add(
            ResponseItem.CreateUserMessageItem("What is the size of France in square miles?")
        );
        AgentConversation conversation = conversationClient.CreateConversation(options: conversationOptions);
        #endregion
        #region Snippet:Sample_CommunicateWithTheAgent_ContainerApp_Sync
        AgentReference agentReference = new(name: containerAgentVersion.Name)
        {
            Version = containerAgentVersion.Version,
        };

        OpenAIResponse response = responseClient.CreateResponse(
            agentRef: agentReference,
            conversation: conversation
        );
        response = WaitResponse(responseClient, response);
        Console.WriteLine(response.GetOutputText());

        conversationClient.CreateConversationItems(
            conversationId: conversation.Id,
            items: [ResponseItem.CreateUserMessageItem("And what is the capital city?")]);
        response = responseClient.CreateResponse(
            agentRef: agentReference,
            conversation: conversation
        );
        response = WaitResponse(responseClient, response);
        Console.WriteLine(response.GetOutputText());
        #endregion
        #region Snippet:Sample_Cleanup_ContainerApp_Sync
        conversationClient.DeleteConversation(conversationId: conversation.Id);
        client.DeleteAgentVersion(agentName: containerAgentVersion.Name, agentVersion: containerAgentVersion.Version);
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
