// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Extensions.OpenAI;
using Azure.AI.Projects;
using Azure.AI.Projects.Agents;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI.Tests.Samples;

public class Sample_CreateAgentVersion : ProjectsOpenAITestBase
{
    [Test]
    [AsyncOnly]
    public async Task CreateAgentVersionAsync()
    {
        IgnoreSampleMayBe();
        #region Snippet:Sample_CreateAgentClient
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        #endregion

        #region Snippet:Sample_CreateAgentVersion_Async
        DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a prompt agent."
        };
        ProjectsAgentVersion agentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
            agentName: "myAgent",
            options: new(agentDefinition));
        #endregion
        #region Snippet:Sample_ListAgentVersions_Async
        var agentVersions = projectClient.AgentAdministrationClient.GetAgentVersionsAsync(agentName: "myAgent");
        await foreach (ProjectsAgentVersion oneAgentVersion in agentVersions)
        {
            Console.WriteLine($"Agent: {oneAgentVersion.Id}, Name: {oneAgentVersion.Name}, Version: {oneAgentVersion.Version}");
        }
        #endregion

        #region Snippet:Sample_CreateConversation_Async
        ProjectConversation conversation
            = await projectClient.ProjectOpenAIClient.GetProjectConversationsClient().CreateProjectConversationAsync();
        #endregion

        #region Snippet:Sample_CreateSimpleResponse_Async

        ProjectResponsesClient responseClient
            = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(new(name: agentVersion.Name, version: agentVersion.Version), conversation.Id);

        ResponseResult response = await responseClient.CreateResponseAsync("Hello, tell me a joke.");

        #endregion
        #region Snippet:Sample_WriteOutput_Async
        Console.WriteLine(response.GetOutputText());
        #endregion
        #region Snippet:Sample_Cleanup_Async
        await projectClient.ProjectOpenAIClient.GetProjectConversationsClient().DeleteConversationAsync(conversationId: conversation.Id);
        await projectClient.AgentAdministrationClient.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void CreateAgentVersion()
    {
        IgnoreSampleMayBe();
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());

        #region Snippet:Sample_CreateAgentVersion_Sync
        DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a prompt agent."
        };
        ProjectsAgentVersion agentVersion = projectClient.AgentAdministrationClient.CreateAgentVersion(
            agentName: "myAgent",
            options: new(agentDefinition));
        #endregion
        #region Snippet:Sample_ListAgentVersions_Sync
        var agentVersions = projectClient.AgentAdministrationClient.GetAgentVersions(agentName: "myAgent");
        foreach (ProjectsAgentVersion oneAgentVersion in agentVersions)
        {
            Console.WriteLine($"Agent: {oneAgentVersion.Id}, Name: {oneAgentVersion.Name}, Version: {oneAgentVersion.Version}");
        }
        #endregion

        #region Snippet:Sample_CreateConversation_Sync
        ProjectConversation conversation
            = projectClient.ProjectOpenAIClient.GetProjectConversationsClient().CreateProjectConversation();
        #endregion

        #region Snippet:Sample_CreateSimpleResponse_Sync

        ProjectResponsesClient responseClient
            = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(new(name: agentVersion.Name, version: agentVersion.Version), conversation.Id);

        ResponseResult response = responseClient.CreateResponse("Hello, tell me a joke.");

        #endregion
        #region Snippet:Sample_WriteOutput_Sync
        Console.WriteLine(response.GetOutputText());
        #endregion
        #region Snippet:Sample_Cleanup_Sync
        projectClient.ProjectOpenAIClient.GetProjectConversationsClient().DeleteConversation(conversationId: conversation.Id);
        projectClient.AgentAdministrationClient.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    public Sample_CreateAgentVersion(bool isAsync) : base(isAsync)
    { }
}
