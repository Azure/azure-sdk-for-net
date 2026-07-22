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
public class Sample_WebIQ : ProjectsOpenAITestBase
{
    [Test]
    [AsyncOnly]
    public async Task WebIQAsync()
    {
        IgnoreSampleMayBe();
        #region Snippet:Sample_CreateAgentClient_WebIQ
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
        var WebIQProjectConnectionName = System.Environment.GetEnvironmentVariable("WEB_IQ_PROJECT_CONNECTION_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
        var WebIQProjectConnectionName = TestEnvironment.WEB_IQ_PROJECT_CONNECTION_NAME;
#endif
        AIProjectClientOptions options = new();
        options.AddPolicy(GetDumpPolicy(), System.ClientModel.Primitives.PipelinePosition.PerCall);
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new AzureCliCredential(), options: options);
        #endregion
        #region Snippet:Sample_CreateAgent_WebIQ_Async
        string WebIQProjectConnectionId = (await projectClient.Connections.GetConnectionAsync(WebIQProjectConnectionName)).Value.Id;
        WebIQPreviewTool WebIQTool = new(projectConnectionId: WebIQProjectConnectionId)
        {
            RequireApproval = new McpToolCallApprovalPolicy(GlobalMcpToolCallApprovalPolicy.NeverRequireApproval),
        };
        DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "Use the available Web IQ tools to answer questions and perform tasks.",
            Tools = { WebIQTool },
        };
        ProjectsAgentVersion agentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
            agentName: "myWebIQAgent",
            options: new(agentDefinition));
        #endregion
        #region Snippet:Sample_CreateResponse_WebIQ_Async
        ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(agentVersion.Name);
        CreateResponseOptions responseOptions = new()
        {
            ToolChoice = ResponseToolChoice.CreateRequiredChoice(),
            InputItems = { ResponseItem.CreateUserMessageItem("Tell me weather history in London, Ohio.") },
        };
        ResponseResult response = await responseClient.CreateResponseAsync(responseOptions);
        #endregion

        #region Snippet:Sample_PrintResponse_WebIQ
        Console.WriteLine(response.GetOutputText());
        #endregion

        #region Snippet:Sample_Cleanup_WebIQ_Async
        await projectClient.AgentAdministrationClient.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void WebIQSync()
    {
        IgnoreSampleMayBe();
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
        var WebIQProjectConnectionName = System.Environment.GetEnvironmentVariable("WEB_IQ_PROJECT_CONNECTION_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
        var WebIQProjectConnectionName = TestEnvironment.WEB_IQ_PROJECT_CONNECTION_NAME;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new AzureCliCredential());
        string WebIQProjectConnectionId = projectClient.Connections.GetConnection(WebIQProjectConnectionName).Id;
        #region Snippet:Sample_CreateAgent_WebIQ_Sync
        WebIQPreviewTool WebIQTool = new(projectConnectionId: WebIQProjectConnectionId)
        {
            RequireApproval = new McpToolCallApprovalPolicy(GlobalMcpToolCallApprovalPolicy.NeverRequireApproval),
        };
        DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "Use the available Web IQ tools to answer questions and perform tasks.",
            Tools = { WebIQTool },
        };
        ProjectsAgentVersion agentVersion = projectClient.AgentAdministrationClient.CreateAgentVersion(
            agentName: "myWebIQAgent",
            options: new(agentDefinition));
        #endregion
        #region Snippet:Sample_CreateResponse_WebIQ_Sync
        ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(agentVersion.Name);
        CreateResponseOptions responseOptions = new()
        {
            ToolChoice = ResponseToolChoice.CreateRequiredChoice(),
            InputItems = { ResponseItem.CreateUserMessageItem("Tell me weather history in London, Ohio.") },
        };
        ResponseResult response = responseClient.CreateResponse(responseOptions);
        #endregion

        Console.WriteLine(response.GetOutputText());

        #region Snippet:Sample_Cleanup_WebIQ_Sync
        projectClient.AgentAdministrationClient.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    public Sample_WebIQ(bool isAsync) : base(isAsync)
    { }
}
