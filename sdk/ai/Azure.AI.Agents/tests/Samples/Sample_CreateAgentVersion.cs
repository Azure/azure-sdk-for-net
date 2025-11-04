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
        #region Snippet:Sample_CreateAgentClient
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AgentsClient client = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        #endregion

        #region Snippet:Sample_CreateAgentVersion_Async
        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a prompt agent."
        };
        AgentVersion agentVersion = await client.CreateAgentVersionAsync(
            agentName: "myAgent",
            definition: agentDefinition, options: null);
        #endregion
        #region Snippet:Sample_ListAgentVersions_Async
        var agentVersions = client.GetAgentVersionsAsync(agentName: "myAgent");
        await foreach (AgentVersion oneAgentVersion in agentVersions)
        {
            Console.WriteLine($"Agent: {oneAgentVersion.Id}, Name: {oneAgentVersion.Name}, Version: {oneAgentVersion.Version}");
        }
        #endregion

        #region Snippet:Sample_CreateCoversation_Async
        ConversationClient coversations = client.GetConversationClient();
        AgentConversation conversation = await coversations.CreateConversationAsync();
        ModelReaderWriterOptions options = new("W");
        BinaryData conversationBin = ((IPersistableModel<AgentConversation>)conversation).Write(options);
        #endregion

        #region Snippet:Sample_GetResponse_Async
        OpenAIClient openAIClient = client.GetOpenAIClient();
        OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(modelDeploymentName);

        ResponseCreationOptions responseOptions = new()
        {
            Agent = agentVersion,
            Conversation = conversation,
        };

        OpenAIResponse response = await responseClient.CreateResponseAsync(
            [ResponseItem.CreateUserMessageItem("Hello, tell me a joke.")],
            responseOptions);

        #endregion
        #region Snippet:Sample_WriteOutput_Async
        while (response.Status != ResponseStatus.Incomplete && response.Status != ResponseStatus.Failed && response.Status != ResponseStatus.Completed){
            await Task.Delay(TimeSpan.FromMilliseconds(500));
            response = await responseClient.GetResponseAsync(responseId:  response.Id);
        }

        Console.WriteLine(response.GetOutputText());
        #endregion
        #region Snippet:Sample_Cleanup_Async
        await coversations.DeleteConversationAsync(conversationId: conversation.Id);
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
        AgentsClient client = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());

        #region Snippet:Sample_CreateAgentVersion_Sync
        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a prompt agent."
        };
        AgentVersion agentVersion = client.CreateAgentVersion(
            agentName: "myAgent",
            definition: agentDefinition, options: null);
        #endregion
        #region Snippet:Sample_ListAgentVersions_Sync
        var agentVersions = client.GetAgentVersions(agentName: "myAgent");
        foreach (AgentVersion oneAgentVersion in agentVersions)
        {
            Console.WriteLine($"Agent: {oneAgentVersion.Id}, Name: {oneAgentVersion.Name}, Version: {oneAgentVersion.Version}");
        }
        #endregion

        #region Snippet:Sample_CreateCoversation_Sync
        ConversationClient coversations = client.GetConversationClient();
        AgentConversation conversation = coversations.CreateConversation();
        ModelReaderWriterOptions options = new("W");
        BinaryData conversationBin = ((IPersistableModel<AgentConversation>)conversation).Write(options);
        #endregion

        #region Snippet:Sample_GetResponse_Sync
        OpenAIClient openAIClient = client.GetOpenAIClient();
        OpenAIResponseClient responsesClient = openAIClient.GetOpenAIResponseClient(modelDeploymentName);

        ResponseCreationOptions responseOptions = new()
        {
            Agent = agentVersion,
            Conversation = conversation,
        };

        OpenAIResponse response = responsesClient.CreateResponse(
            [ResponseItem.CreateUserMessageItem("Hello, tell me a joke.")],
            responseOptions);

        #endregion
        #region Snippet:Sample_WriteOutput_Sync
        while (response.Status != ResponseStatus.Incomplete && response.Status != ResponseStatus.Failed && response.Status != ResponseStatus.Completed)
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(500));
            response = responsesClient.GetResponse(responseId: response.Id);
        }

        Console.WriteLine(response.GetOutputText());
        #endregion
        #region Snippet:Sample_Cleanup_Sync
        coversations.DeleteConversation(conversationId: conversation.Id);
        client.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    public Sample_CreateAgentVersion(bool isAsync) : base(isAsync)
    { }
}
