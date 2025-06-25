// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Agents.Persistent.Tests;

public partial class Sample_PersistentAgents_Multiple_Connected_Agents : SamplesBase<AIAgentsTestEnvironment>
{
    [Test]
    [AsyncOnly]
    public async Task MultipleConnectedAgentsExampleAsync()
    {
        #region Snippet:AgentsMultipleConnectedAgents_CreateProject
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        PersistentAgentsClient agentClient = new(projectEndpoint, new DefaultAzureCredential());
        #endregion
        #region Snippet:AgentsMultipleConnectedAgentsAsync_CreateSubAgents
        PersistentAgent stockPriceAgent = await agentClient.Administration.CreateAgentAsync(
            model: modelDeploymentName,
            name: "stock-price-bot",
            instructions: "Your job is to get the stock price of a company. If asked for the Microsoft stock price, always return $350.");

        PersistentAgent weatherAgent = await agentClient.Administration.CreateAgentAsync(
            model: modelDeploymentName,
            name: "weather-bot",
            instructions: "Your job is to get the weather for a given location. If asked for the weather in Seattle, always return 60 degrees and cloudy.");
        #endregion
        #region Snippet:AgentsMultipleConnectedAgents_GetConnectedAgents
        ConnectedAgentToolDefinition stockPriceConnectedAgentTool = new(
            new ConnectedAgentDetails(
                id: stockPriceAgent.Id,
                name: "stock_price_bot",
                description: "Gets the stock price of a company"
            )
        );

        ConnectedAgentToolDefinition weatherConnectedAgentTool = new(
            new ConnectedAgentDetails(
                id: weatherAgent.Id,
                name: "weather_bot",
                description: "Gets the weather for a given location"
            )
        );
        #endregion
        #region Snippet:AgentsMultipleConnectedAgentsAsync_CreateAgent
        PersistentAgent agent = await agentClient.Administration.CreateAgentAsync(
           model: modelDeploymentName,
           name: "my-assistant",
           instructions: "You are a helpful assistant, and use the connected agents to get stock prices and weather.",
           tools: [stockPriceConnectedAgentTool, weatherConnectedAgentTool]);
        #endregion
        // Create thread for communication
        #region Snippet:AgentsMultipleConnectedAgentsAsync_CreateThreadMessage
        PersistentAgentThread thread = await agentClient.Threads.CreateThreadAsync();

        // Create message to thread
        PersistentThreadMessage message = await agentClient.Messages.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "What is the stock price of Microsoft and the weather in Seattle?");

        // Run the agent
        ThreadRun run = await agentClient.Runs.CreateRunAsync(thread, agent);
        do
        {
            await Task.Delay(TimeSpan.FromMilliseconds(500));
            run = await agentClient.Runs.GetRunAsync(thread.Id, run.Id);
        }
        while (run.Status == RunStatus.Queued
            || run.Status == RunStatus.InProgress);

        Assert.AreEqual(
            RunStatus.Completed,
            run.Status,
            run.LastError?.Message);
        #endregion

        #region Snippet:AgentsMultipleConnectedAgentsAsync_Print
        AsyncPageable<PersistentThreadMessage> messages = agentClient.Messages.GetMessagesAsync(
            threadId: thread.Id,
            order: ListSortOrder.Ascending
        );

        await foreach (PersistentThreadMessage threadMessage in messages)
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
        #endregion
        #region Snippet:AgentsMultipleConnectedAgentsCleanupAsync
        await agentClient.Threads.DeleteThreadAsync(threadId: thread.Id);
        await agentClient.Administration.DeleteAgentAsync(agentId: agent.Id);
        await agentClient.Administration.DeleteAgentAsync(agentId: stockPriceAgent.Id);
        await agentClient.Administration.DeleteAgentAsync(agentId: weatherAgent.Id);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void MultipleConnectedAgentsExample()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        PersistentAgentsClient agentClient = new(projectEndpoint, new DefaultAzureCredential());
        #region Snippet:AgentsMultipleConnectedAgents_CreateSubAgents
        PersistentAgent stockPriceAgent = agentClient.Administration.CreateAgent(
            model: modelDeploymentName,
            name: "stock-price-bot",
            instructions: "Your job is to get the stock price of a company. If asked for the Microsoft stock price, always return $350.");

        PersistentAgent weatherAgent = agentClient.Administration.CreateAgent(
            model: modelDeploymentName,
            name: "weather-bot",
            instructions: "Your job is to get the weather for a given location. If asked for the weather in Seattle, always return 60 degrees and cloudy.");
        #endregion
        ConnectedAgentToolDefinition stockPriceConnectedAgentTool = new(
            new ConnectedAgentDetails(
                id: stockPriceAgent.Id,
                name: "stock_price_bot",
                description: "Gets the stock price of a company"
            )
        );

        ConnectedAgentToolDefinition weatherConnectedAgentTool = new(
            new ConnectedAgentDetails(
                id: weatherAgent.Id,
                name: "weather_bot",
                description: "Gets the weather for a given location"
            )
        );
        #region Snippet:AgentsMultipleConnectedAgents_CreateAgent
        PersistentAgent agent = agentClient.Administration.CreateAgent(
           model: modelDeploymentName,
           name: "my-assistant",
           instructions: "You are a helpful assistant, and use the connected agents to get stock prices and weather.",
           tools: [stockPriceConnectedAgentTool, weatherConnectedAgentTool]);
        #endregion
        // Create thread for communication
        #region Snippet:AgentsMultipleConnectedAgents_CreateThreadMessage
        PersistentAgentThread thread = agentClient.Threads.CreateThread();

        // Create message to thread
        PersistentThreadMessage message = agentClient.Messages.CreateMessage(
            thread.Id,
            MessageRole.User,
            "What is the stock price of Microsoft and the weather in Seattle?");

        // Run the agent
        ThreadRun run = agentClient.Runs.CreateRun(thread, agent);
        do
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(500));
            run = agentClient.Runs.GetRun(thread.Id, run.Id);
        }
        while (run.Status == RunStatus.Queued
            || run.Status == RunStatus.InProgress);

        Assert.AreEqual(
            RunStatus.Completed,
            run.Status,
            run.LastError?.Message);
        #endregion

        #region Snippet:AgentsMultipleConnectedAgents_Print
        Pageable<PersistentThreadMessage> messages = agentClient.Messages.GetMessages(
            threadId: thread.Id,
            order: ListSortOrder.Ascending
        );

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
        #endregion
        #region Snippet:AgentsMultipleConnectedAgentsCleanup
        agentClient.Threads.DeleteThread(threadId: thread.Id);
        agentClient.Administration.DeleteAgent(agentId: agent.Id);
        agentClient.Administration.DeleteAgent(agentId: stockPriceAgent.Id);
        agentClient.Administration.DeleteAgent(agentId: weatherAgent.Id);
        #endregion
    }
}
