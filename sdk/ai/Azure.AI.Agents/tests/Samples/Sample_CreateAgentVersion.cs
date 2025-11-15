// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI;
using OpenAI.Responses;

namespace Azure.AI.Agents.Tests.Samples;

[Ignore("Samples represented as tests only for validation of compilation.")]
public class Sample_CreateAgentVersion : AgentsTestBase
{
    [Test]
    [AsyncOnly]
    public async Task CreateAgentVersionAsync()
    {
        #region Snippet:Sample_CreateAgentClient_2
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AgentClient client = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        #endregion

        #region Snippet:Sample_CreateAgentVersion_Async_2
        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a prompt agent."
        };
        AgentVersion agentVersion = await client.CreateAgentVersionAsync(
            agentName: "myAgent",
            options: new(agentDefinition));
        #endregion
        #region Snippet:Sample_ListAgentVersions_Async_2
        var agentVersions = client.GetAgentVersionsAsync(agentName: "myAgent");
        await foreach (AgentVersion oneAgentVersion in agentVersions)
        {
            Console.WriteLine($"Agent: {oneAgentVersion.Id}, Name: {oneAgentVersion.Name}, Version: {oneAgentVersion.Version}");
        }
        #endregion

        #region Snippet:Sample_CreateConversation_Async_2
        ConversationClient Conversations = client.GetConversationClient();
        AgentConversation conversation = await Conversations.CreateConversationAsync();
        ModelReaderWriterOptions options = new("W");
        BinaryData conversationBin = ((IPersistableModel<AgentConversation>)conversation).Write(options);
        #endregion

        #region Snippet:Sample_GetResponse_Async_2
        OpenAIClient openAIClient = client.GetOpenAIClient();
        OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(modelDeploymentName);

        ResponseCreationOptions responseOptions = new();
        responseOptions.SetAgentReference(new AgentReference(name: agentVersion.Name));
        responseOptions.SetConversationReference(conversation.Id);

        OpenAIResponse response = await responseClient.CreateResponseAsync(
            [ResponseItem.CreateUserMessageItem("Hello, tell me a joke.")],
            responseOptions);

        #endregion
        #region Snippet:Sample_WriteOutput_Async_2
        while (response.Status != ResponseStatus.Incomplete && response.Status != ResponseStatus.Failed && response.Status != ResponseStatus.Completed){
            await Task.Delay(TimeSpan.FromMilliseconds(500));
            response = await responseClient.GetResponseAsync(responseId:  response.Id);
        }

        Console.WriteLine(response.GetOutputText());
        #endregion
        #region Snippet:Sample_Cleanup_Async_2
        await Conversations.DeleteConversationAsync(conversationId: conversation.Id);
        await client.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void CreateAgentVersion()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AgentClient client = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());

        #region Snippet:Sample_CreateAgentVersion_Sync_2
        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a prompt agent."
        };
        AgentVersion agentVersion = client.CreateAgentVersion(
            agentName: "myAgent",
            options: new(agentDefinition));
        #endregion
        #region Snippet:Sample_ListAgentVersions_Sync_2
        var agentVersions = client.GetAgentVersions(agentName: "myAgent");
        foreach (AgentVersion oneAgentVersion in agentVersions)
        {
            Console.WriteLine($"Agent: {oneAgentVersion.Id}, Name: {oneAgentVersion.Name}, Version: {oneAgentVersion.Version}");
        }
        #endregion

        #region Snippet:Sample_CreateConversation_Sync_2
        ConversationClient Conversations = client.GetConversationClient();
        AgentConversation conversation = Conversations.CreateConversation();
        ModelReaderWriterOptions options = new("W");
        BinaryData conversationBin = ((IPersistableModel<AgentConversation>)conversation).Write(options);
        #endregion

        #region Snippet:Sample_GetResponse_Sync_2
        OpenAIClient openAIClient = client.GetOpenAIClient();
        OpenAIResponseClient responsesClient = openAIClient.GetOpenAIResponseClient(modelDeploymentName);

        ResponseCreationOptions responseOptions = new();
        responseOptions.SetAgentReference(new AgentReference(agentVersion.Name));
        responseOptions.SetConversationReference(conversation.Id);

        OpenAIResponse response = responsesClient.CreateResponse(
            [ResponseItem.CreateUserMessageItem("Hello, tell me a joke.")],
            responseOptions);

        #endregion
        #region Snippet:Sample_WriteOutput_Sync_2
        while (response.Status != ResponseStatus.Incomplete && response.Status != ResponseStatus.Failed && response.Status != ResponseStatus.Completed)
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(500));
            response = responsesClient.GetResponse(responseId: response.Id);
        }

        Console.WriteLine(response.GetOutputText());
        #endregion
        #region Snippet:Sample_Cleanup_Sync_2
        Conversations.DeleteConversation(conversationId: conversation.Id);
        client.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    public Sample_CreateAgentVersion(bool isAsync) : base(isAsync)
    { }
}
