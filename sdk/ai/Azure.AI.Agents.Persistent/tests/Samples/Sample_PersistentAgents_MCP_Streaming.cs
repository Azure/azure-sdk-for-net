// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Agents.Persistent.Tests;

public partial class Sample_PersistentAgents_MCP_Streaming : SamplesBase<AIAgentsTestEnvironment>
{
    [Test]
    [AsyncOnly]
    public async Task MCPStreamingExampleAsync()
    {
        #region Snippet:AgentsMCPStreaming_CreateProject
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var mcpServerUrl = System.Environment.GetEnvironmentVariable("MCP_SERVER_URL");
        var mcpServerLabel = System.Environment.GetEnvironmentVariable("MCP_SERVER_LABEL");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var mcpServerUrl = "https://gitmcp.io/Azure/azure-rest-api-specs";
        var mcpServerLabel = "github";
#endif
        PersistentAgentsClient agentClient = new(projectEndpoint, new DefaultAzureCredential());
        #endregion

        #region Snippet:AgentsMCPStreamingAsync_CreateMCPTool
        // Create MCP tool definition
        MCPToolDefinition mcpTool = new(mcpServerLabel, mcpServerUrl);

        // Configure allowed tools (optional)
        string searchApiCode = "search_azure_rest_api_code";
        mcpTool.AllowedTools.Add(searchApiCode);

        #endregion

        #region Snippet:AgentsMCPStreamingAsync_CreateAgent
        PersistentAgent agent = await agentClient.Administration.CreateAgentAsync(
           model: modelDeploymentName,
           name: "my-mcp-agent",
           instructions: "You are a helpful agent that can use MCP tools to assist users. Use the available MCP tools to answer questions and perform tasks.",
           tools: [mcpTool]
           );
        #endregion

        // Create thread for communication
        #region Snippet:AgentsMCPStreamingAsync_CreateThreadMessage
        PersistentAgentThread thread = await agentClient.Threads.CreateThreadAsync();

        // Create message to thread
        PersistentThreadMessage message = await agentClient.Messages.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "Please summarize the Azure REST API specifications Readme");

        MCPToolResource mcpToolResource = new(mcpServerLabel);
        mcpToolResource.UpdateHeader("SuperSecret", "123456");
        ToolResources toolResources = mcpToolResource.ToToolResources();
        CreateRunStreamingOptions options = new()
        {
            ToolResources = toolResources
        };
        #endregion
        #region Snippet:AgentsMCPStreamingAsync_UpdateCycle
        List<ToolApproval> toolApprovals = [];
        ThreadRun streamRun = null;
        AsyncCollectionResult<StreamingUpdate> stream = agentClient.Runs.CreateRunStreamingAsync(thread.Id, agent.Id, options: options);
        do
        {
            toolApprovals.Clear();
            await foreach (StreamingUpdate streamingUpdate in stream)
            {
                if (streamingUpdate.UpdateKind == StreamingUpdateReason.RunCreated)
                {
                    Console.WriteLine("--- Run started! ---");
                }
                else if (streamingUpdate is SubmitToolApprovalUpdate submitToolApprovalUpdate)
                {
                    Console.WriteLine($"Approving MCP tool call: {submitToolApprovalUpdate.Name}, Arguments: {submitToolApprovalUpdate.Arguments}");
                    toolApprovals.Add(new ToolApproval(submitToolApprovalUpdate.ToolCallId, approve: true)
                    {
                        Headers = { ["SuperSecret"] = "123456" }
                    });
                    streamRun = submitToolApprovalUpdate.Value;
                }
                else if (streamingUpdate is MessageContentUpdate contentUpdate)
                {
                    Console.Write(contentUpdate.Text);
                }
                else if (streamingUpdate.UpdateKind == StreamingUpdateReason.RunCompleted)
                {
                    Console.WriteLine();
                    Console.WriteLine("--- Run completed! ---");
                }
                else if (streamingUpdate.UpdateKind == StreamingUpdateReason.Error && streamingUpdate is RunUpdate errorStep)
                {
                    Console.WriteLine($"Error: {errorStep.Value.LastError}");
                }
            }
            if (toolApprovals.Count > 0)
            {
                stream = agentClient.Runs.SubmitToolOutputsToStreamAsync(streamRun, toolOutputs: [], toolApprovals: toolApprovals);
            }
        }
        while (toolApprovals.Count > 0);
        #endregion

        #region Snippet:AgentsMCPStreamingCleanupAsync
        await agentClient.Threads.DeleteThreadAsync(threadId: thread.Id);
        await agentClient.Administration.DeleteAgentAsync(agentId: agent.Id);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void MCPStreamingExample()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var mcpServerUrl = System.Environment.GetEnvironmentVariable("MCP_SERVER_URL");
        var mcpServerLabel = System.Environment.GetEnvironmentVariable("MCP_SERVER_LABEL");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var mcpServerUrl = "https://gitmcp.io/Azure/azure-rest-api-specs";
        var mcpServerLabel = "github";
#endif
        PersistentAgentsClient agentClient = new(projectEndpoint, new DefaultAzureCredential());

        // Create MCP tool definition
        MCPToolDefinition mcpTool = new(mcpServerLabel, mcpServerUrl);

        // Configure allowed tools (optional)
        string searchApiCode = "search_azure_rest_api_code";
        mcpTool.AllowedTools.Add(searchApiCode);

        #region Snippet:AgentsMCPStreaming_CreateAgent
        PersistentAgent agent = agentClient.Administration.CreateAgent(
           model: modelDeploymentName,
           name: "my-mcp-agent",
           instructions: "You are a helpful agent that can use MCP tools to assist users. Use the available MCP tools to answer questions and perform tasks.",
           tools: [mcpTool]);
        #endregion
        #region Snippet:AgentsMCPStreaming_CreateThreadMessage
        // Create thread for communication
        PersistentAgentThread thread = agentClient.Threads.CreateThread();

        // Create message to thread
        PersistentThreadMessage message = agentClient.Messages.CreateMessage(
            thread.Id,
            MessageRole.User,
            "Please summarize the Azure REST API specifications Readme");

        MCPToolResource mcpToolResource = new(mcpServerLabel);
        mcpToolResource.UpdateHeader("SuperSecret", "123456");
        ToolResources toolResources = mcpToolResource.ToToolResources();
        CreateRunStreamingOptions options = new()
        {
            ToolResources = toolResources
        };
        #endregion
        #region Snippet:AgentsMCPStreaming_UpdateCycle
        List<ToolApproval> toolApprovals = [];
        ThreadRun streamRun = null;
        CollectionResult<StreamingUpdate> stream = agentClient.Runs.CreateRunStreaming(thread.Id, agent.Id, options: options);
        do
        {
            toolApprovals.Clear();
            foreach (StreamingUpdate streamingUpdate in stream)
            {
                if (streamingUpdate.UpdateKind == StreamingUpdateReason.RunCreated)
                {
                    Console.WriteLine("--- Run started! ---");
                }
                else if (streamingUpdate is SubmitToolApprovalUpdate submitToolApprovalUpdate)
                {
                    Console.WriteLine($"Approving MCP tool call: {submitToolApprovalUpdate.Name}, Arguments: {submitToolApprovalUpdate.Arguments}");
                    toolApprovals.Add(new ToolApproval(submitToolApprovalUpdate.ToolCallId, approve: true)
                    {
                        Headers = { ["SuperSecret"] = "123456" }
                    });
                    streamRun = submitToolApprovalUpdate.Value;
                }
                else if (streamingUpdate is MessageContentUpdate contentUpdate)
                {
                    Console.Write(contentUpdate.Text);
                }
                else if (streamingUpdate.UpdateKind == StreamingUpdateReason.RunCompleted)
                {
                    Console.WriteLine();
                    Console.WriteLine("--- Run completed! ---");
                }
                else if (streamingUpdate.UpdateKind == StreamingUpdateReason.Error && streamingUpdate is RunUpdate errorStep)
                {
                    Console.WriteLine($"Error: {errorStep.Value.LastError}");
                }
            }
            if (toolApprovals.Count > 0)
            {
                stream = agentClient.Runs.SubmitToolOutputsToStream(streamRun, toolOutputs: [], toolApprovals: toolApprovals);
            }
        }
        while (toolApprovals.Count > 0);
        #endregion

        #region Snippet:AgentsMCPStreamingCleanup
        agentClient.Threads.DeleteThread(threadId: thread.Id);
        agentClient.Administration.DeleteAgent(agentId: agent.Id);
        #endregion
    }
}
