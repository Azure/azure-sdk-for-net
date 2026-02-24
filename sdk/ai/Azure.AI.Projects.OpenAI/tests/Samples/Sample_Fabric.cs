// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Responses;

namespace Azure.AI.Projects.OpenAI.Tests.Samples;

public class Sample_Fabric : ProjectsOpenAITestBase
{
    [Test]
    [AsyncOnly]
    public async Task FabricAsync()
    {
        IgnoreSampleMayBe();
        #region Snippet:Sample_CreateAgentClient_Fabric
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var fabricConnectionName = System.Environment.GetEnvironmentVariable("FABRIC_CONNECTION_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var fabricConnectionName = TestEnvironment.FABRIC_CONNECTION_NAME;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        #endregion
        #region Snippet:Sample_CreateAgent_Fabric_Async
        AIProjectConnection fabricConnection = await projectClient.Connections.GetConnectionAsync(fabricConnectionName);
        FabricDataAgentToolOptions fabricToolOption = new()
        {
            ProjectConnections = { new ToolProjectConnection(projectConnectionId: fabricConnection.Id) }
        };
        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a helpful assistant.",
            Tools = { new MicrosoftFabricPreviewTool(fabricToolOption), }
        };
        AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
            agentName: "myAgent",
            options: new(agentDefinition));
        #endregion
        #region Snippet:Sample_CreateResponse_Fabric_Async
        ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);
        CreateResponseOptions responseOptions = new()
        {
            ToolChoice = ResponseToolChoice.CreateRequiredChoice(),
            InputItems = { ResponseItem.CreateUserMessageItem("What was the number of public holidays in Norway in 2024?") },
        };
        ResponseResult response = await responseClient.CreateResponseAsync(responseOptions);
        #endregion

        #region Snippet:Sample_WaitForResponse_Fabric
        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
        Console.WriteLine(response.GetOutputText());
        #endregion

        #region Snippet:Sample_Cleanup_Fabric_Async
        await projectClient.Agents.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void Fabric()
    {
        IgnoreSampleMayBe();
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var fabricConnectionName = System.Environment.GetEnvironmentVariable("FABRIC_CONNECTION_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var fabricConnectionName = TestEnvironment.FABRIC_CONNECTION_NAME;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());

        #region Snippet:Sample_CreateAgent_Fabric_Sync
        AIProjectConnection fabricConnection = projectClient.Connections.GetConnection(fabricConnectionName);
        FabricDataAgentToolOptions fabricToolOption = new()
        {
            ProjectConnections = { new ToolProjectConnection(projectConnectionId: fabricConnection.Id) }
        };
        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a helpful assistant.",
            Tools = { new MicrosoftFabricPreviewTool(fabricToolOption), }
        };
        AgentVersion agentVersion = projectClient.Agents.CreateAgentVersion(
            agentName: "myAgent",
            options: new(agentDefinition));
        #endregion
        #region Snippet:Sample_CreateResponse_Fabric_Sync
        ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);
        CreateResponseOptions responseOptions = new()
        {
            ToolChoice = ResponseToolChoice.CreateRequiredChoice(),
            InputItems = { ResponseItem.CreateUserMessageItem("What was the number of public holidays in Norway in 2024?") },
        };
        ResponseResult response = responseClient.CreateResponse(responseOptions);
        #endregion

        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
        Console.WriteLine(response.GetOutputText());

        #region Snippet:Sample_Cleanup_Fabric_Sync
        projectClient.Agents.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    public Sample_Fabric(bool isAsync) : base(isAsync)
    { }
}
