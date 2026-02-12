// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Responses;

namespace Azure.AI.Projects.OpenAI.Tests.Samples;

public class Sample_MCPTool : ProjectsOpenAITestBase
{
    [Test]
    [AsyncOnly]
    public async Task MCPToolAsync()
    {
        IgnoreSampleMayBe();
        #region Snippet:Sample_CreateAgentClient_MCPTool
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());

        #endregion
        #region Snippet:Sample_CreateAgent_MCPTool_Async
        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a helpful agent that can use MCP tools to assist users. Use the available MCP tools to answer questions and perform tasks.",
            Tools = { ResponseTool.CreateMcpTool(
                serverLabel: "api-specs",
                serverUri: new Uri("https://gitmcp.io/Azure/azure-rest-api-specs"),
                toolCallApprovalPolicy: new McpToolCallApprovalPolicy(GlobalMcpToolCallApprovalPolicy.AlwaysRequireApproval
            )) }
        };
        AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
            agentName: "myAgent",
            options: new(agentDefinition));
        #endregion
        #region Snippet:Sample_CreateResponse_MCPTool_Async
        ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);

        CreateResponseOptions nextResponseOptions = new([ResponseItem.CreateUserMessageItem("Please summarize the Azure REST API specifications Readme")]);
        ResponseResult latestResponse = null;

        while (nextResponseOptions is not null)
        {
            latestResponse = await responseClient.CreateResponseAsync(nextResponseOptions);
            nextResponseOptions = null;

            foreach (ResponseItem responseItem in latestResponse.OutputItems)
            {
                if (responseItem is McpToolCallApprovalRequestItem mcpToolCall)
                {
                    nextResponseOptions = new CreateResponseOptions()
                    {
                        PreviousResponseId = latestResponse.Id,
                    };
                    if (string.Equals(mcpToolCall.ServerLabel, "api-specs"))
                    {
                        Console.WriteLine($"Approving {mcpToolCall.ServerLabel}...");
                        // Automatically approve the MCP request to allow the agent to proceed
                        // In production, you might want to implement more sophisticated approval logic
                        nextResponseOptions.InputItems.Add(ResponseItem.CreateMcpApprovalResponseItem(approvalRequestId: mcpToolCall.Id, approved: true));
                    }
                    else
                    {
                        Console.WriteLine($"Rejecting unknown call {mcpToolCall.ServerLabel}...");
                        nextResponseOptions.InputItems.Add(ResponseItem.CreateMcpApprovalResponseItem(approvalRequestId: mcpToolCall.Id, approved: false));
                    }
                }
            }
        }
        Console.WriteLine(latestResponse.GetOutputText());
        #endregion

        #region Snippet:Sample_Cleanup_MCPTool_Async
        await projectClient.Agents.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void MCPTool()
    {
        IgnoreSampleMayBe();
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());

        #region Snippet:Sample_CreateAgent_MCPTool_Sync
        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a helpful agent that can use MCP tools to assist users. Use the available MCP tools to answer questions and perform tasks.",
            Tools = { ResponseTool.CreateMcpTool(
                serverLabel: "api-specs",
                serverUri: new Uri("https://gitmcp.io/Azure/azure-rest-api-specs"),
                toolCallApprovalPolicy: new McpToolCallApprovalPolicy(GlobalMcpToolCallApprovalPolicy.AlwaysRequireApproval
            )) }
        };
        AgentVersion agentVersion = projectClient.Agents.CreateAgentVersion(
            agentName: "myAgent",
            options: new(agentDefinition));
        #endregion
        #region Snippet:Sample_CreateResponse_MCPTool_Sync
        ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);

        CreateResponseOptions nextResponseOptions = new([ResponseItem.CreateUserMessageItem("Please summarize the Azure REST API specifications Readme")]);
        ResponseResult latestResponse = null;

        while (nextResponseOptions is not null)
        {
            latestResponse = responseClient.CreateResponse(nextResponseOptions);
            nextResponseOptions = null;

            foreach (ResponseItem responseItem in latestResponse.OutputItems)
            {
                if (responseItem is McpToolCallApprovalRequestItem mcpToolCall)
                {
                    nextResponseOptions = new CreateResponseOptions()
                    {
                        PreviousResponseId = latestResponse.Id,
                    };
                    if (string.Equals(mcpToolCall.ServerLabel, "api-specs"))
                    {
                        Console.WriteLine($"Approving {mcpToolCall.ServerLabel}...");
                        // Automatically approve the MCP request to allow the agent to proceed
                        // In production, you might want to implement more sophisticated approval logic
                        nextResponseOptions.InputItems.Add(ResponseItem.CreateMcpApprovalResponseItem(approvalRequestId: mcpToolCall.Id, approved: true));
                    }
                    else
                    {
                        Console.WriteLine($"Rejecting unknown call {mcpToolCall.ServerLabel}...");
                        nextResponseOptions.InputItems.Add(ResponseItem.CreateMcpApprovalResponseItem(approvalRequestId: mcpToolCall.Id, approved: false));
                    }
                }
            }
        }
        Console.WriteLine(latestResponse.GetOutputText());
        #endregion

        #region Snippet:Sample_Cleanup_MCPTool_Sync
        projectClient.Agents.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    public Sample_MCPTool(bool isAsync) : base(isAsync)
    { }
}
