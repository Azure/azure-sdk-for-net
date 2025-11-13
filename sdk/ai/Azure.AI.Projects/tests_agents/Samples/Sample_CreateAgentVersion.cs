// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using Azure.AI.Projects.OpenAI;
using OpenAI;
using OpenAI.Responses;

namespace Azure.AI.Projects.Tests.Samples;

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
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        #endregion

        #region Snippet:Sample_CreateAgentVersion_Async
        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a prompt agent."
        };
        AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
            agentName: "myAgent",
            options: new(agentDefinition));
        #endregion
        #region Snippet:Sample_ListAgentVersions_Async
        var agentVersions = projectClient.Agents.GetAgentVersionsAsync(agentName: "myAgent");
        await foreach (AgentVersion oneAgentVersion in agentVersions)
        {
            Console.WriteLine($"Agent: {oneAgentVersion.Id}, Name: {oneAgentVersion.Name}, Version: {oneAgentVersion.Version}");
        }
        #endregion

        #region Snippet:Sample_CreateCoversation_Async
        AgentConversation conversation = await projectClient.OpenAI.Conversations.CreateAgentConversationAsync();
        ModelReaderWriterOptions options = new("W");
        BinaryData conversationBin = ((IPersistableModel<AgentConversation>)conversation).Write(options);
        #endregion

        #region Snippet:Sample_GetResponse_Async

        OpenAIResponseClient responseClient = projectClient.OpenAI.GetOpenAIResponseClient(modelDeploymentName);

        ResponseCreationOptions responseOptions = new()
        {
            Agent = agentVersion,
            AgentConversationId = conversation,
        };

        OpenAIResponse response = await responseClient.CreateResponseAsync("Hello, tell me a joke.");

        #endregion
        #region Snippet:Sample_WriteOutput_Async
        while (response.Status != ResponseStatus.Incomplete && response.Status != ResponseStatus.Failed && response.Status != ResponseStatus.Completed){
            await Task.Delay(TimeSpan.FromMilliseconds(500));
            response = await responseClient.GetResponseAsync(responseId:  response.Id);
        }

        Console.WriteLine(response.GetOutputText());
        #endregion
        #region Snippet:Sample_Cleanup_Async
        await projectClient.OpenAI.Conversations.DeleteConversationAsync(conversationId: conversation.Id);
        await projectClient.Agents.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
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
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());

        #region Snippet:Sample_CreateAgentVersion_Sync
        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a prompt agent."
        };
        AgentVersion agentVersion = projectClient.Agents.CreateAgentVersion(
            agentName: "myAgent",
            options: new(agentDefinition));
        #endregion
        #region Snippet:Sample_ListAgentVersions_Sync
        var agentVersions = projectClient.Agents.GetAgentVersions(agentName: "myAgent");
        foreach (AgentVersion oneAgentVersion in agentVersions)
        {
            Console.WriteLine($"Agent: {oneAgentVersion.Id}, Name: {oneAgentVersion.Name}, Version: {oneAgentVersion.Version}");
        }
        #endregion

        #region Snippet:Sample_CreateCoversation_Sync
        AgentConversation conversation = projectClient.OpenAI.Conversations.CreateAgentConversation();
        ModelReaderWriterOptions options = new("W");
        BinaryData conversationBin = ((IPersistableModel<AgentConversation>)conversation).Write(options);
        #endregion

        #region Snippet:Sample_GetResponse_Sync

        OpenAIResponseClient responsesClient = projectClient.OpenAI.GetOpenAIResponseClient(modelDeploymentName);

        OpenAIResponseClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(AGENT_NAME, conversation.Id);

        OpenAIResponse response = responsesClient.CreateResponse("Hello, tell me a joke.");

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
        projectClient.OpenAI.Conversations.DeleteConversation(conversationId: conversation.Id);
        projectClient.Agents.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    public Sample_CreateAgentVersion(bool isAsync) : base(isAsync)
    { }
}
