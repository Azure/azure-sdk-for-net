// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.Projects;
using Azure.AI.Projects.Agents;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI.Tests.Samples;
# pragma warning disable AAIP001

public class Sample_WorkIQ : ProjectsOpenAITestBase
{
    [Test]
    [AsyncOnly]
    public async Task WorkIQAsync()
    {
        IgnoreSampleMayBe();
        #region Snippet:Sample_CreateAgentClient_WorkIQ
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
        var workIQConnectionName = System.Environment.GetEnvironmentVariable("WORKIQ_CONNECTION_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
        var workIQConnectionName = TestEnvironment.WORKIQ_CONNECTION_NAME;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        #endregion
        #region Snippet:Sample_CreateAgent_WorkIQ_Async
        AIProjectConnection workIQConnection = await projectClient.Connections.GetConnectionAsync(workIQConnectionName);
        DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a helpful assistant that can access Microsoft 365 data through WorkIQ. Use the WorkIQ tool to search and retrieve information from emails, calendar events, Teams messages, and other Microsoft 365 content to assist users with their questions.",
            Tools = { new WorkIQPreviewTool(workIQConnection.Id), }
        };
        ProjectsAgentVersion agentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
            agentName: "myAgent",
            options: new(agentDefinition));
        #endregion
        #region Snippet:Sample_CreateResponse_WorkIQ_Async
        ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(agentVersion.Name);
        CreateResponseOptions responseOptions = new()
        {
            ToolChoice = ResponseToolChoice.CreateRequiredChoice(),
            InputItems = { ResponseItem.CreateUserMessageItem("What meetings do I have scheduled today?") },
        };
        ResponseResult response = await responseClient.CreateResponseAsync(responseOptions);
        #endregion

        #region Snippet:Sample_GetResponse_WorkIQ
        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
        Console.WriteLine(response.GetOutputText());
        #endregion

        #region Snippet:Sample_Cleanup_WorkIQ_Async
        await projectClient.AgentAdministrationClient.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void WorkIQSync()
    {
        IgnoreSampleMayBe();
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
        var workIQConnectionName = System.Environment.GetEnvironmentVariable("WORKIQ_CONNECTION_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
        var workIQConnectionName = TestEnvironment.WORKIQ_CONNECTION_NAME;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        #region Snippet:Sample_CreateAgent_WorkIQ_Sync
        AIProjectConnection workIQConnection = projectClient.Connections.GetConnection(workIQConnectionName);
        DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a helpful assistant that can access Microsoft 365 data through WorkIQ. Use the WorkIQ tool to search and retrieve information from emails, calendar events, Teams messages, and other Microsoft 365 content to assist users with their questions.",
            Tools = { new WorkIQPreviewTool(workIQConnection.Id), }
        };
        ProjectsAgentVersion agentVersion = projectClient.AgentAdministrationClient.CreateAgentVersion(
            agentName: "myAgent",
            options: new(agentDefinition));
        #endregion
        #region Snippet:Sample_CreateResponse_WorkIQ_Sync
        ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(agentVersion.Name);
        CreateResponseOptions responseOptions = new()
        {
            ToolChoice = ResponseToolChoice.CreateRequiredChoice(),
            InputItems = { ResponseItem.CreateUserMessageItem("What meetings do I have scheduled today?") },
        };
        ResponseResult response = responseClient.CreateResponse(responseOptions);
        #endregion

        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
        Console.WriteLine(response.GetOutputText());

        #region Snippet:Sample_Cleanup_WorkIQ_Sync
        projectClient.AgentAdministrationClient.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    public Sample_WorkIQ(bool isAsync) : base(isAsync)
    { }
}
