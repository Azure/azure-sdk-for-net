// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Responses;

namespace Azure.AI.Projects.OpenAI.Tests.Samples;

public class Sample_AgentToAgent : ProjectsOpenAITestBase
{
    [Test]
    [AsyncOnly]
    public async Task AgentToAgentAsync()
    {
        IgnoreSampleMayBe();
        #region Snippet:Sample_CreateAgentClient_AgentToAgent
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var a2aConnectionName = System.Environment.GetEnvironmentVariable("A2A_CONNECTION_NAME");
        var a2aBaseUri = System.Environment.GetEnvironmentVariable("A2A_BASE_URI");

#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var a2aConnectionName = TestEnvironment.A2A_CONNECTION_NAME;
        var a2aBaseUri = TestEnvironment.A2A_BASE_URI;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());

        #endregion
        #region Snippet:Sample_CreateAgent_AgentToAgent_Async
        AIProjectConnection a2aConnection = projectClient.Connections.GetConnection(a2aConnectionName);
        A2APreviewTool a2aTool = new()
        {
            ProjectConnectionId = a2aConnection.Id
        };
        if (!string.Equals(a2aConnection.Type.ToString(), "RemoteA2A"))
        {
            if (a2aBaseUri is null)
            {
                throw new InvalidOperationException($"The connection {a2aConnection.Name} is of {a2aConnection.Type.ToString()} type and does not carry the A2A service base URI. Please provide this value through A2A_BASE_URI environment variable.");
            }
            a2aTool.BaseUri = new Uri(a2aBaseUri);
        }
        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a helpful assistant.",
            Tools = { a2aTool }
        };
        AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
            agentName: "myAgent",
            options: new(agentDefinition));
        #endregion
        #region Snippet:Sample_CreateResponse_AgentToAgent_Async
        ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);
        CreateResponseOptions responseOptions = new()
        {
            ToolChoice = ResponseToolChoice.CreateRequiredChoice(),
            InputItems =
            {
                ResponseItem.CreateUserMessageItem("What can the secondary agent do?"),
            },
        };
        ResponseResult response = await responseClient.CreateResponseAsync(responseOptions);
        #endregion

        #region Snippet:Sample_WaitForResponse_AgentToAgent
        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
        Console.WriteLine(response.GetOutputText());
        #endregion

        #region Snippet:Sample_Cleanup_AgentToAgent_Async
        await projectClient.Agents.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void AgentToAgent()
    {
        IgnoreSampleMayBe();
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var a2aConnectionName = System.Environment.GetEnvironmentVariable("A2A_CONNECTION_NAME");
        var a2aBaseUri = System.Environment.GetEnvironmentVariable("A2A_BASE_URI");

#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var a2aConnectionName = TestEnvironment.A2A_CONNECTION_NAME;
        var a2aBaseUri = TestEnvironment.A2A_BASE_URI;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());

        #region Snippet:Sample_CreateAgent_AgentToAgent_Sync
        AIProjectConnection a2aConnection = projectClient.Connections.GetConnection(a2aConnectionName);
        A2APreviewTool a2aTool = new()
        {
            ProjectConnectionId = a2aConnection.Id
        };
        if (!string.Equals(a2aConnection.Type.ToString(), "RemoteA2A"))
        {
            if (a2aBaseUri is null)
            {
                throw new InvalidOperationException($"The connection {a2aConnection.Name} is of {a2aConnection.Type.ToString()} type and does not carry the A2A service base URI. Please provide this value through A2A_BASE_URI environment variable.");
            }
            a2aTool.BaseUri = new Uri(a2aBaseUri);
        }
        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a helpful assistant.",
            Tools = { a2aTool }
        };
        AgentVersion agentVersion = projectClient.Agents.CreateAgentVersion(
            agentName: "myAgent",
            options: new(agentDefinition));
        #endregion
        #region Snippet:Sample_CreateResponse_AgentToAgent_Sync
        ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);
        CreateResponseOptions responseOptions = new()
        {
            ToolChoice = ResponseToolChoice.CreateRequiredChoice(),
            InputItems = { ResponseItem.CreateUserMessageItem("What can the secondary agent do?") },
        };
        ResponseResult response = responseClient.CreateResponse(responseOptions);
        #endregion

        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
        Console.WriteLine(response.GetOutputText());

        #region Snippet:Sample_Cleanup_AgentToAgent_Sync
        projectClient.Agents.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    public Sample_AgentToAgent(bool isAsync) : base(isAsync)
    { }
}
