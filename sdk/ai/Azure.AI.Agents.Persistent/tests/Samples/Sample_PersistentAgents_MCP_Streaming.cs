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
        var mcpServerUrl2 = System.Environment.GetEnvironmentVariable("MCP_SERVER_URL2");
        var mcpServerLabel = System.Environment.GetEnvironmentVariable("MCP_SERVER_LABEL");
        var mcpServerLabel2 = System.Environment.GetEnvironmentVariable("MCP_SERVER_LABEL2");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var mcpServerUrl = "https://gitmcp.io/Azure/azure-rest-api-specs";
        var mcpServerUrl2 = "https://learn.microsoft.com/api/mcp";
        var mcpServerLabel = "github";
        var mcpServerLabel2 = "microsoft_learn";
#endif
        PersistentAgentsClient agentClient = new(projectEndpoint, new DefaultAzureCredential());
        #endregion

        #region Snippet:AgentsMCPStreamingAsync_CreateMCPTool
        // Create MCP tool definitions
        MCPToolDefinition mcpTool = new(mcpServerLabel, mcpServerUrl);
        MCPToolDefinition mcpTool2 = new(mcpServerLabel2, mcpServerUrl2);

        // Configure allowed tools (optional)
        string searchApiCode = "search_azure_rest_api_code";
        mcpTool.AllowedTools.Add(searchApiCode);

        #endregion

        #region Snippet:AgentsMCPStreamingAsync_CreateAgent
        PersistentAgent agent = await agentClient.Administration.CreateAgentAsync(
           model: modelDeploymentName,
           name: "my-mcp-agent",
           instructions: "You are a helpful agent that can use MCP tools to assist users. Use the available MCP tools to answer questions and perform tasks.",
           tools: [mcpTool, mcpTool2]
           );
        #endregion

        // Create thread for communication
        #region Snippet:AgentsMCPStreamingAsync_CreateThreadMessage
        PersistentAgentThread thread = await agentClient.Threads.CreateThreadAsync();

        // Create message to thread
        PersistentThreadMessage message = await agentClient.Messages.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "Please summarize the Azure REST API specifications Readme and give the basic information on TypeSpec.");

        MCPToolResource mcpToolResource = new(mcpServerLabel);
        mcpToolResource.UpdateHeader("SuperSecret", "123456");
        ToolResources toolResources = mcpToolResource.ToToolResources();
        toolResources.Mcp.Add(new MCPToolResource(mcpServerLabel2));
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
                else if (streamingUpdate is RunStepUpdate runStepUpdate)
                {
                    PrintActivityStep(runStepUpdate.Value);
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
        var mcpServerUrl2 = System.Environment.GetEnvironmentVariable("MCP_SERVER_URL2");
        var mcpServerLabel = System.Environment.GetEnvironmentVariable("MCP_SERVER_LABEL");
        var mcpServerLabel2 = System.Environment.GetEnvironmentVariable("MCP_SERVER_LABEL2");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var mcpServerUrl = "https://gitmcp.io/Azure/azure-rest-api-specs";
        var mcpServerUrl2 = "https://learn.microsoft.com/api/mcp";
        var mcpServerLabel = "github";
        var mcpServerLabel2 = "microsoft_learn";
#endif
        PersistentAgentsClient agentClient = new(projectEndpoint, new DefaultAzureCredential());

        // Create MCP tool definitions
        MCPToolDefinition mcpTool = new(mcpServerLabel, mcpServerUrl);
        MCPToolDefinition mcpTool2 = new(mcpServerLabel2, mcpServerUrl2);

        // Configure allowed tools (optional)
        string searchApiCode = "search_azure_rest_api_code";
        mcpTool.AllowedTools.Add(searchApiCode);

        #region Snippet:AgentsMCPStreaming_CreateAgent
        PersistentAgent agent = agentClient.Administration.CreateAgent(
           model: modelDeploymentName,
           name: "my-mcp-agent",
           instructions: "You are a helpful agent that can use MCP tools to assist users. Use the available MCP tools to answer questions and perform tasks.",
           tools: [mcpTool, mcpTool2]);
        #endregion
        #region Snippet:AgentsMCPStreaming_CreateThreadMessage
        // Create thread for communication
        PersistentAgentThread thread = agentClient.Threads.CreateThread();

        // Create message to thread
        PersistentThreadMessage message = agentClient.Messages.CreateMessage(
            thread.Id,
            MessageRole.User,
            "Please summarize the Azure REST API specifications Readme and give the basic information on TypeSpec.");

        MCPToolResource mcpToolResource = new(mcpServerLabel);
        mcpToolResource.UpdateHeader("SuperSecret", "123456");
        ToolResources toolResources = mcpToolResource.ToToolResources();
        toolResources.Mcp.Add(new MCPToolResource(mcpServerLabel2));
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
                else if (streamingUpdate is RunStepUpdate runStepUpdate)
                {
                    PrintActivityStep(runStepUpdate.Value);
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

    #region Snippet:AgentsMCPStreaming_PrintActivityStep
    private static void PrintActivityStep(RunStep step)
    {
        if (step.StepDetails is RunStepActivityDetails activityDetails)
        {
            foreach (RunStepDetailsActivity activity in activityDetails.Activities)
            {
                foreach (KeyValuePair<string, ActivityFunctionDefinition> activityFunction in activity.Tools)
                {
                    Console.WriteLine($"The function {activityFunction.Key} with description \"{activityFunction.Value.Description}\" will be called.");
                    if (activityFunction.Value.Parameters.Properties.Count > 0)
                    {
                        Console.WriteLine("Function parameters:");
                        foreach (KeyValuePair<string, FunctionArgument> arg in activityFunction.Value.Parameters.Properties)
                        {
                            Console.WriteLine($"\t{arg.Key}");
                            Console.WriteLine($"\t\tType: {arg.Value.Type}");
                            if (!string.IsNullOrEmpty(arg.Value.Description))
                                Console.WriteLine($"\t\tDescription: {arg.Value.Description}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("This function has no parameters");
                    }
                }
            }
        }
    }
    #endregion
}
