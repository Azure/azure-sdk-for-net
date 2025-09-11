// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Agents.Persistent.Tests;

public partial class Sample_PersistentAgents_MCP : SamplesBase<AIAgentsTestEnvironment>
{
    [Test]
    [AsyncOnly]
    public async Task MCPExampleAsync()
    {
        #region Snippet:AgentsMCP_CreateProject
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

        #region Snippet:AgentsMCP_CreateMCPTool
        // Create MCP tool definitions
        MCPToolDefinition mcpTool = new(mcpServerLabel, mcpServerUrl);
        MCPToolDefinition mcpTool2 = new(mcpServerLabel2, mcpServerUrl2);

        // Configure allowed tools (optional)
        string searchApiCode = "search_azure_rest_api_code";
        mcpTool.AllowedTools.Add(searchApiCode);

        #endregion

        #region Snippet:AgentsMCPAsync_CreateAgent
        PersistentAgent agent = await agentClient.Administration.CreateAgentAsync(
           model: modelDeploymentName,
           name: "my-mcp-agent",
           instructions: "You are a helpful agent that can use MCP tools to assist users. Use the available MCP tools to answer questions and perform tasks.",
           tools: [mcpTool, mcpTool2]
           );
        #endregion

        // Create thread for communication
        #region Snippet:AgentsMCPAsync_CreateThreadMessage
        PersistentAgentThread thread = await agentClient.Threads.CreateThreadAsync();

        // Create message to thread
        PersistentThreadMessage message = await agentClient.Messages.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "Please summarize the Azure REST API specifications Readme and give the basic information on TypeSpec.");

        MCPToolResource mcpToolResource = new(mcpServerLabel);
        mcpToolResource.UpdateHeader("SuperSecret", "123456");
        // By default all the tools require approvals. To set the absolute trust for the tool please uncomment the
        // next code.
        // mcpToolResource.RequireApproval = new MCPApproval("never");
        // If using multiple tools it is possible to set the trust per tool.
        // var mcpApprovalPerTool = new MCPApprovalPerTool()
        // {
        //     Always= new MCPToolList(["non_trusted_tool1", "non_trusted_tool2"]),
        //     Never = new MCPToolList(["trusted_tool1", "trusted_tool2"]),
        // };
        // mcpToolResource.RequireApproval = new MCPApproval(perToolApproval: mcpApprovalPerTool);
        // Note: This functionality is available since version 1.2.0-beta.4.
        // In older versions please use serialization into binary object as discussed in the issue
        // https://github.com/Azure/azure-sdk-for-net/issues/52213
        ToolResources toolResources = mcpToolResource.ToToolResources();
        toolResources.Mcp.Add(new MCPToolResource(mcpServerLabel2));

        // Run the agent with MCP tool resources
        ThreadRun run = await agentClient.Runs.CreateRunAsync(thread, agent, toolResources);

        // Handle run execution and tool approvals
        while (run.Status == RunStatus.Queued || run.Status == RunStatus.InProgress || run.Status == RunStatus.RequiresAction)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(1000));
            run = await agentClient.Runs.GetRunAsync(thread.Id, run.Id);

            if (run.Status == RunStatus.RequiresAction && run.RequiredAction is SubmitToolApprovalAction toolApprovalAction)
            {
                var toolApprovals = new List<ToolApproval>();
                foreach (var toolCall in toolApprovalAction.SubmitToolApproval.ToolCalls)
                {
                    if (toolCall is RequiredMcpToolCall mcpToolCall)
                    {
                        Console.WriteLine($"Approving MCP tool call: {mcpToolCall.Name}");
                        toolApprovals.Add(new ToolApproval(mcpToolCall.Id, approve: true)
                        {
                            Headers = { ["SuperSecret"] = "123456" }
                        });
                    }
                }

                if (toolApprovals.Count > 0)
                {
                    run = await agentClient.Runs.SubmitToolOutputsToRunAsync(thread.Id, run.Id, toolApprovals: toolApprovals);
                }
            }
        }

        Assert.AreEqual(
            RunStatus.Completed,
            run.Status,
            run.LastError?.Message);
        #endregion

        #region Snippet:AgentsMCPAsync_PrintRunSteps
        IReadOnlyList<RunStep> runSteps = [.. agentClient.Runs.GetRunSteps(run: run)];
        PrintActivitySteps(runSteps);
        #endregion
        #region Snippet:AgentsMCPAsync_Print
        IReadOnlyList<PersistentThreadMessage> messages = await agentClient.Messages.GetMessagesAsync(
            threadId: thread.Id,
            order: ListSortOrder.Ascending
        ).ToListAsync();

        PrintMessages(messages);
        #endregion

        #region Snippet:AgentsMCPCleanupAsync
        await agentClient.Threads.DeleteThreadAsync(threadId: thread.Id);
        await agentClient.Administration.DeleteAgentAsync(agentId: agent.Id);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void MCPExample()
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

        #region Snippet:AgentsMCP_CreateAgent
        PersistentAgent agent = agentClient.Administration.CreateAgent(
           model: modelDeploymentName,
           name: "my-mcp-agent",
           instructions: "You are a helpful agent that can use MCP tools to assist users. Use the available MCP tools to answer questions and perform tasks.",
           tools: [mcpTool, mcpTool2]);
        #endregion

        // Create thread for communication
        #region Snippet:AgentsMCP_CreateThreadMessage
        PersistentAgentThread thread = agentClient.Threads.CreateThread();

        // Create message to thread
        PersistentThreadMessage message = agentClient.Messages.CreateMessage(
            thread.Id,
            MessageRole.User,
            "Please summarize the Azure REST API specifications Readme and give the basic information on TypeSpec.");

        MCPToolResource mcpToolResource = new(mcpServerLabel);
        mcpToolResource.UpdateHeader("SuperSecret", "123456");
        // By default all the tools require approvals. To set the absolute trust for the tool please uncomment the
        // next code.
        // mcpToolResource.RequireApproval = new MCPApproval("never");
        // If using multiple tools it is possible to set the trust per tool.
        // var mcpApprovalPerTool = new MCPApprovalPerTool()
        // {
        //     Always= new MCPToolList(["non_trusted_tool1", "non_trusted_tool2"]),
        //     Never = new MCPToolList(["trusted_tool1", "trusted_tool2"]),
        // };
        // mcpToolResource.RequireApproval = new MCPApproval(perToolApproval: mcpApprovalPerTool);
        // Note: This functionality is available since version 1.2.0-beta.4.
        // In older versions please use serialization into binary object as discussed in the issue
        // https://github.com/Azure/azure-sdk-for-net/issues/52213
        ToolResources toolResources = mcpToolResource.ToToolResources();
        toolResources.Mcp.Add(new MCPToolResource(mcpServerLabel2));

        // Run the agent with MCP tool resources
        ThreadRun run = agentClient.Runs.CreateRun(thread, agent, toolResources);

        // Handle run execution and tool approvals
        while (run.Status == RunStatus.Queued || run.Status == RunStatus.InProgress || run.Status == RunStatus.RequiresAction)
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(1000));
            run = agentClient.Runs.GetRun(thread.Id, run.Id);

            if (run.Status == RunStatus.RequiresAction && run.RequiredAction is SubmitToolApprovalAction toolApprovalAction)
            {
                var toolApprovals = new List<ToolApproval>();
                foreach (var toolCall in toolApprovalAction.SubmitToolApproval.ToolCalls)
                {
                    if (toolCall is RequiredMcpToolCall mcpToolCall)
                    {
                        Console.WriteLine($"Approving MCP tool call: {mcpToolCall.Name}, Arguments: {mcpToolCall.Arguments}");
                        toolApprovals.Add(new ToolApproval(mcpToolCall.Id, approve: true)
                        {
                            Headers = { ["SuperSecret"] = "123456" }
                        });
                    }
                }

                if (toolApprovals.Count > 0)
                {
                    run = agentClient.Runs.SubmitToolOutputsToRun(thread.Id, run.Id, toolApprovals: toolApprovals);
                }
            }
        }

        Assert.AreEqual(
            RunStatus.Completed,
            run.Status,
            run.LastError?.Message);
        #endregion

        #region Snippet:AgentsMCP_PrintRunSteps
        IReadOnlyList<RunStep> runSteps = [..agentClient.Runs.GetRunSteps(run: run)];
        PrintActivitySteps(runSteps);
        #endregion
        #region Snippet:AgentsMCP_Print
        IReadOnlyList<PersistentThreadMessage> messages = [..agentClient.Messages.GetMessages(
            threadId: thread.Id,
            order: ListSortOrder.Ascending
        )];

        PrintMessages(messages);
        #endregion

        #region Snippet:AgentsMCPCleanup
        agentClient.Threads.DeleteThread(threadId: thread.Id);
        agentClient.Administration.DeleteAgent(agentId: agent.Id);
        #endregion
    }

    #region Snippet:AgentsMcpPrintActivityStep
    private static void PrintActivitySteps(IReadOnlyList<RunStep> runSteps)
    {
        foreach (RunStep step in runSteps)
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
    }
    #endregion

    #region Snippet:AgentsMcpPrintMessages
    private static void PrintMessages(IReadOnlyList<PersistentThreadMessage> messages)
    {
        foreach (PersistentThreadMessage threadMessage in messages)
        {
            Console.Write($"{threadMessage.CreatedAt:yyyy-MM-dd HH:mm:ss} - {threadMessage.Role,10}: ");
            foreach (MessageContent contentItem in threadMessage.ContentItems)
            {
                if (contentItem is MessageTextContent textItem)
                {
                    Console.Write(textItem.Text);
                }
                else if (contentItem is MessageImageFileContent imageFileItem)
                {
                    Console.Write($"<image from ID: {imageFileItem.FileId}>");
                }
                Console.WriteLine();
            }
        }
    }
    #endregion
}
