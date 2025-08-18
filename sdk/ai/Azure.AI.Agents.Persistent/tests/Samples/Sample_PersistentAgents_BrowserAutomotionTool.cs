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

public partial class Sample_PersistentAgents_BrowserAutamotionTool : SamplesBase<AIAgentsTestEnvironment>
{
    [Test]
    [AsyncOnly]
    public async Task BrowserAutomationToolExampleAsync()
    {
        #region Snippet:PersistentAgents_BrowserAutomationTool_CreateClient
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var playwrightConnectionId = System.Environment.GetEnvironmentVariable("AZURE_PLAYWRIGHT_CONNECTION_ID");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var playwrightConnectionId = TestEnvironment.PLAYWRIGHT_CONNECTION_ID;
#endif
        PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());
        #endregion

        #region Snippet:PersistentAgents_BrowserAutomationTool_CreateAgent_Async
        BrowserAutomationToolDefinition browserToolDefinition = new(
            new BrowserAutomationToolParameters(
                new BrowserAutomationToolConnectionParameters(id: playwrightConnectionId)
            )
        );

        // Create an Agent with toolResources and process Agent run
        // NOTE: To reuse existing agent, fetch it with client.Administration.GetAgent(agentId)
        PersistentAgent agent = await client.Administration.CreateAgentAsync(
                model: modelDeploymentName,
                name: "SDK Test Agent - Retrieval",
                instructions: "You are an Agent helping with browser automation tasks. " +
                              "You can answer questions, provide information, and assist with various tasks " +
                              "related to web browsing using the Browser Automation tool available to you.",
                tools: [browserToolDefinition]
        );
        #endregion

        #region Snippet:PersistentAgents_BrowserAutomationTool_CreateThreadAndRun_Async
        // Create thread for communication
        PersistentAgentThread thread = await client.Threads.CreateThreadAsync();

        // Create message to thread
        PersistentThreadMessage messageResponse = await client.Messages.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            content: "Your goal is to report the percent of Microsoft year-to-date stock price change. " +
                     "To do that, go to the website finance.yahoo.com. " +
                     "At the top of the page, you will find a search bar." +
                     "Enter the value 'MSFT', to get information about the Microsoft stock price." +
                     "At the top of the resulting page you will see a default chart of Microsoft stock price." +
                     "Click on 'YTD' at the top of that chart, and report the percent value that shows up just below it."
            );

        // Run the Agent
        Console.WriteLine("Waiting for Agent run to complete. Please wait...");
        ThreadRun run = await client.Runs.CreateRunAsync(thread, agent);

        do
        {
            await Task.Delay(TimeSpan.FromMilliseconds(500));
            run = await client.Runs.GetRunAsync(thread.Id, run.Id);
        }
        while (run.Status == RunStatus.Queued
            || run.Status == RunStatus.InProgress);
        Assert.AreEqual(
            RunStatus.Completed,
            run.Status,
            run.LastError?.Message);
        List<PersistentThreadMessage> messages = await client.Messages.GetMessagesAsync(
            threadId: thread.Id,
            order: ListSortOrder.Ascending
        ).ToListAsync();
        WriteMessages(messages);
        #endregion
        #region Snippet:PersistentAgents_BrowserAutomationTool_ShowRunSteps_Async
        IReadOnlyList<RunStep> steps = await client.Runs.GetRunStepsAsync(run).ToListAsync();
        printRunStepInfo(steps);
        #endregion
        #region Snippet:PersistentAgents_BrowserAutomationTool_Cleanup_Async
        // NOTE: Comment out these four lines if you plan to reuse the agent later.
        await client.Threads.DeleteThreadAsync(thread.Id);
        await client.Administration.DeleteAgentAsync(agent.Id);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void BrowserAutomationToolExampleSync()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var playwrightConnectionId = System.Environment.GetEnvironmentVariable("AZURE_PLAYWRIGHT_CONNECTION_ID");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var playwrightConnectionId = TestEnvironment.PLAYWRIGHT_CONNECTION_ID;
#endif
        PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());

        #region Snippet:PersistentAgents_BrowserAutomationTool_CreateAgent_Sync
        BrowserAutomationToolDefinition browserToolDefinition = new(
            new BrowserAutomationToolParameters(
                new BrowserAutomationToolConnectionParameters(id: playwrightConnectionId)
            )
        );
        // Create an Agent with toolResources and process Agent run
        // NOTE: To reuse existing agent, fetch it with client.Administration.GetAgent(agentId)
        PersistentAgent agent = client.Administration.CreateAgent(
                model: modelDeploymentName,
                name: "SDK Test Agent - Retrieval",
                instructions: "You are an Agent helping with browser automation tasks. " +
                              "You can answer questions, provide information, and assist with various tasks " +
                              "related to web browsing using the Browser Automation tool available to you.",
                tools: [browserToolDefinition]
        );
        #endregion

        #region Snippet:PersistentAgents_BrowserAutomationTool_CreateThreadAndRun_Sync
        // Create thread for communication
        PersistentAgentThread thread = client.Threads.CreateThread();

        // Create message to thread
        PersistentThreadMessage messageResponse = client.Messages.CreateMessage(
            thread.Id,
            MessageRole.User,
            content: "Your goal is to report the percent of Microsoft year-to-date stock price change. " +
                     "To do that, go to the website finance.yahoo.com. " +
                     "At the top of the page, you will find a search bar." +
                     "Enter the value 'MSFT', to get information about the Microsoft stock price." +
                     "At the top of the resulting page you will see a default chart of Microsoft stock price." +
                     "Click on 'YTD' at the top of that chart, and report the percent value that shows up just below it."
        );

        // Run the Agent
        Console.WriteLine("Waiting for Agent run to complete. Please wait...");
        ThreadRun run = client.Runs.CreateRun(thread, agent);

        do
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(500));
            run = client.Runs.GetRun(thread.Id, run.Id);
        }
        while (run.Status == RunStatus.Queued
            || run.Status == RunStatus.InProgress);
        Assert.AreEqual(
            RunStatus.Completed,
            run.Status,
            run.LastError?.Message);
        Pageable<PersistentThreadMessage> messages = client.Messages.GetMessages(
            threadId: thread.Id,
            order: ListSortOrder.Ascending
        );
        WriteMessages(messages);
        #endregion
        #region Snippet:PersistentAgents_BrowserAutomationTool_ShowRunSteps_Sync
        IReadOnlyList<RunStep> steps = [..client.Runs.GetRunSteps(run)];
        printRunStepInfo(steps);
        #endregion
        #region Snippet:PersistentAgents_BrowserAutomationTool_Cleanup_Sync
        // NOTE: Comment out these four lines if you plan to reuse the agent later.
        client.Threads.DeleteThread(thread.Id);
        client.Administration.DeleteAgent(agent.Id);
        #endregion
    }

    #region Snippet:PersistentAgents_BrowserAutomationTool_Print
    private static void WriteMessages(IEnumerable<PersistentThreadMessage> messages)
    {
        foreach (PersistentThreadMessage threadMessage in messages)
        {
            Console.Write($"{threadMessage.CreatedAt:yyyy-MM-dd HH:mm:ss} - {threadMessage.Role,10}: ");
            foreach (MessageContent contentItem in threadMessage.ContentItems)
            {
                if (contentItem is MessageTextContent textItem)
                {
                    if (threadMessage.Role == MessageRole.Agent && textItem.Annotations.Count > 0)
                    {
                        Console.Write(textItem.Text);
                    }
                    else
                    {
                        Console.Write(textItem.Text);
                    }
                }
                else if (contentItem is MessageImageFileContent imageFileItem)
                {
                    Console.Write($"<image from ID: {imageFileItem.FileId}");
                }
                Console.WriteLine();
            }
        }
    }
    #endregion

    #region Snippet:PersistentAgents_BrowserAutomationTool_PrintSteps
    private static void printRunStepInfo(IReadOnlyList<RunStep> steps)
    {
        foreach (RunStep step in steps)
        {
            if (step.StepDetails is RunStepMessageCreationDetails messageCreationDetails)
            {
                Console.WriteLine($"Message creation step: messageID {messageCreationDetails.MessageCreation.MessageId}");
            }
            else if (step.StepDetails is RunStepToolCallDetails toolCallDetails)
            {
                Console.WriteLine($"Tool call step: Tool count: {toolCallDetails.ToolCalls.Count}; First tool {toolCallDetails.ToolCalls.First().Type}");
                foreach (RunStepToolCall call in toolCallDetails.ToolCalls)
                {
                    Console.WriteLine($"  Tool call ID: {call.Id}");
                    Console.WriteLine($"  Tool call type: {call.Type}");
                    if (call is RunStepBrowserAutomationToolCall browserTool)
                    {
                        Console.WriteLine($"    Browser automation input: {browserTool.BrowserAutomation.Input}");
                        Console.WriteLine($"    Browser automation output: {browserTool.BrowserAutomation.Output}");
                        Console.WriteLine($"    Browser automation steps:");
                        foreach (BrowserAutomationToolCallStep browserStep in browserTool.BrowserAutomation.Steps)
                        {
                            Console.WriteLine($"      Last step result: {browserStep.LastStepResult}");
                            Console.WriteLine($"      Current state: {browserStep.CurrentState}");
                            Console.WriteLine($"      Next step: {browserStep.NextStep}");
                            Console.WriteLine();
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine(step.RunId);
            }
        }
    }
    #endregion
}
