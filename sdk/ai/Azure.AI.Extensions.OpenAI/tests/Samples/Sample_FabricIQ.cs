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
#pragma warning disable AAIP001
public class Sample_FabricIQ : ProjectsOpenAITestBase
{
    [Test]
    [AsyncOnly]
    public async Task FabricIQAsync()
    {
        IgnoreSampleMayBe();
        #region Snippet:Sample_CreateAgentClient_FabricIQ
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
        var fabricIQProjectConnectionName = System.Environment.GetEnvironmentVariable("FABRIC_IQ_PROJECT_CONNECTION_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
        var fabricIQProjectConnectionName = TestEnvironment.FABRIC_IQ_PROJECT_CONNECTION_NAME;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        string fabricIQProjectConnectionId = (await projectClient.Connections.GetConnectionAsync(fabricIQProjectConnectionName)).Value.Id;
        #endregion
        #region Snippet:Sample_CreateAgent_FabricIQ_Async
        FabricIQPreviewTool fabricIQTool = new(projectConnectionId: fabricIQProjectConnectionId)
        {
            RequireApproval = new McpToolCallApprovalPolicy(GlobalMcpToolCallApprovalPolicy.NeverRequireApproval),
        };
        DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "Use the available Fabric IQ tools to answer questions and perform tasks.",
            Tools = { fabricIQTool },
        };
        ProjectsAgentVersion agentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
            agentName: "myFabricIQAgent",
            options: new(agentDefinition));
        #endregion
        #region Snippet:Sample_CreateResponse_FabricIQ_Async
        ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(agentVersion.Name);
        CreateResponseOptions responseOptions = new()
        {
            ToolChoice = ResponseToolChoice.CreateRequiredChoice(),
            InputItems = { ResponseItem.CreateUserMessageItem("Tell me weather history in London, Ohio.") },
        };
        ResponseResult response = await responseClient.CreateResponseAsync(responseOptions);
        #endregion

        #region Snippet:Sample_PrintResponse_FabricIQ
        Console.WriteLine(response.GetOutputText());
        #endregion

        #region Snippet:Sample_Cleanup_FabricIQ_Async
        await projectClient.AgentAdministrationClient.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void FabricIQ()
    {
        IgnoreSampleMayBe();
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
        var fabricIQProjectConnectionName = System.Environment.GetEnvironmentVariable("FABRIC_IQ_PROJECT_CONNECTION_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
        var fabricIQProjectConnectionName = TestEnvironment.FABRIC_IQ_PROJECT_CONNECTION_NAME;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        string fabricIQProjectConnectionId = projectClient.Connections.GetConnection(fabricIQProjectConnectionName).Id;
        #region Snippet:Sample_CreateAgent_FabricIQ_Sync
        FabricIQPreviewTool fabricIQTool = new(projectConnectionId: fabricIQProjectConnectionId)
        {
            RequireApproval = new McpToolCallApprovalPolicy(GlobalMcpToolCallApprovalPolicy.NeverRequireApproval),
        };
        DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "Use the available Fabric IQ tools to answer questions and perform tasks.",
            Tools = { fabricIQTool },
        };
        ProjectsAgentVersion agentVersion = projectClient.AgentAdministrationClient.CreateAgentVersion(
            agentName: "myFabricIQAgent",
            options: new(agentDefinition));
        #endregion
        #region Snippet:Sample_CreateResponse_FabricIQ_Sync
        ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(agentVersion.Name);
        CreateResponseOptions responseOptions = new()
        {
            ToolChoice = ResponseToolChoice.CreateRequiredChoice(),
            InputItems = { ResponseItem.CreateUserMessageItem("Tell me weather history in London, Ohio.") },
        };
        ResponseResult response = responseClient.CreateResponse(responseOptions);
        #endregion

        Console.WriteLine(response.GetOutputText());

        #region Snippet:Sample_Cleanup_FabricIQ_Sync
        projectClient.AgentAdministrationClient.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    public Sample_FabricIQ(bool isAsync) : base(isAsync)
    { }
}
