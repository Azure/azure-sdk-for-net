// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests;

public partial class Sample_Agent_Connected_Agent : SamplesBase<AIProjectsTestEnvironment>
{
    [Test]
    [AsyncOnly]
    public async Task ConnectedAgentExampleAsync()
    {
        #region Snippet:ConnectedAgent_CreateProject
#if SNIPPET
        var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif

        var projectClient = new AIProjectClient(connectionString, new DefaultAzureCredential());

        AgentsClient agentClient = projectClient.GetAgentsClient();
        #endregion
        #region Snippet:ConnectedAgentAsync_CreateConnectedAgent
        Agent connectedAgent = await agentClient.CreateAgentAsync(
           model: modelDeploymentName,
           name: "stock_price_bot",
           instructions: "Your job is to get the stock price of a company. If you don't know the realtime stock price, return the last known stock price.");

        ConnectedAgentToolDefinition connectedAgentDefinition = new(new ConnectedAgentDetails(connectedAgent.Id, connectedAgent.Name, "Gets the stock price of a company"));
        #endregion
        #region Snippet:ConnectedAgentAsync_CreateAgent
        Agent agent = await agentClient.CreateAgentAsync(
           model: modelDeploymentName,
           name: "my-assistant",
           instructions: "You are a helpful assistant, and use the connected agent to get stock prices.",
           tools: [ connectedAgentDefinition ]);
        #endregion
        // Create thread for communication
        # region Snippet:ConnectedAgentAsync_CreateThreadMessage
        AgentThread thread = await agentClient.CreateThreadAsync();

        // Create message to thread
        ThreadMessage message = await agentClient.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "What is the stock price of Microsoft?");

        // Run the agent
        ThreadRun run = await agentClient.CreateRunAsync(thread, agent);
        do
        {
            await Task.Delay(TimeSpan.FromMilliseconds(500));
            run = await agentClient.GetRunAsync(thread.Id, run.Id);
        }
        while (run.Status == RunStatus.Queued
            || run.Status == RunStatus.InProgress);

        Assert.AreEqual(
            RunStatus.Completed,
            run.Status,
            run.LastError?.Message);
        #endregion

        #region Snippet:ConnectedAgentAsync_Print
        PageableList<ThreadMessage> messages = await agentClient.GetMessagesAsync(
            threadId: thread.Id,
            order: ListSortOrder.Ascending
        );

        foreach (ThreadMessage threadMessage in messages)
        {
            Console.Write($"{threadMessage.CreatedAt:yyyy-MM-dd HH:mm:ss} - {threadMessage.Role,10}: ");
            foreach (MessageContent contentItem in threadMessage.ContentItems)
            {
                if (contentItem is MessageTextContent textItem)
                {
                    string response = textItem.Text;
                    if (textItem.Annotations != null)
                    {
                        foreach (MessageTextAnnotation annotation in textItem.Annotations)
                        {
                            if (annotation is MessageTextUrlCitationAnnotation urlAnnotation)
                            {
                                response = response.Replace(urlAnnotation.Text, $" [{urlAnnotation.UrlCitation.Title}]({urlAnnotation.UrlCitation.Url})");
                            }
                        }
                    }
                    Console.Write($"Agent response: {response}");
                }
                else if (contentItem is MessageImageFileContent imageFileItem)
                {
                    Console.Write($"<image from ID: {imageFileItem.FileId}");
                }
                Console.WriteLine();
            }
        }
        #endregion
        #region Snippet:ConnectedAgentCleanupAsync
        await agentClient.DeleteThreadAsync(threadId: thread.Id);
        await agentClient.DeleteAgentAsync(agentId: agent.Id);
        await agentClient.DeleteAgentAsync(agentId: connectedAgent.Id);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void ConnectedAgentExample()
    {
#if SNIPPET
        var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif

        var projectClient = new AIProjectClient(connectionString, new DefaultAzureCredential());
        AgentsClient agentClient = projectClient.GetAgentsClient();
        #region Snippet:ConnectedAgent_CreateConnectedAgent
        Agent connectedAgent = agentClient.CreateAgent(
           model: modelDeploymentName,
           name: "stock_price_bot",
           instructions: "Your job is to get the stock price of a company. If you don't know the realtime stock price, return the last known stock price.");

        ConnectedAgentToolDefinition connectedAgentDefinition = new(new ConnectedAgentDetails(connectedAgent.Id, connectedAgent.Name, "Gets the stock price of a company"));
        #endregion
        #region Snippet:ConnectedAgent_CreateAgent
        Agent agent = agentClient.CreateAgent(
           model: modelDeploymentName,
           name: "my-assistant",
           instructions: "You are a helpful assistant, and use the connected agent to get stock prices.",
           tools: [ connectedAgentDefinition ]);
        #endregion
        // Create thread for communication
        # region Snippet:ConnectedAgent_CreateThreadMessage
        AgentThread thread = agentClient.CreateThread();

        // Create message to thread
        ThreadMessage message = agentClient.CreateMessage(
            thread.Id,
            MessageRole.User,
            "What is the stock price of Microsoft?");

        // Run the agent
        ThreadRun run = agentClient.CreateRun(thread, agent);
        do
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(500));
            run = agentClient.GetRun(thread.Id, run.Id);
        }
        while (run.Status == RunStatus.Queued
            || run.Status == RunStatus.InProgress);

        Assert.AreEqual(
            RunStatus.Completed,
            run.Status,
            run.LastError?.Message);
        #endregion

        #region Snippet:ConnectedAgent_Print
        PageableList<ThreadMessage> messages = agentClient.GetMessages(
            threadId: thread.Id,
            order: ListSortOrder.Ascending
        );

        foreach (ThreadMessage threadMessage in messages)
        {
            Console.Write($"{threadMessage.CreatedAt:yyyy-MM-dd HH:mm:ss} - {threadMessage.Role,10}: ");
            foreach (MessageContent contentItem in threadMessage.ContentItems)
            {
                if (contentItem is MessageTextContent textItem)
                {
                    string response = textItem.Text;
                    if (textItem.Annotations != null)
                    {
                        foreach (MessageTextAnnotation annotation in textItem.Annotations)
                        {
                            if (annotation is MessageTextUrlCitationAnnotation urlAnnotation)
                            {
                                response = response.Replace(urlAnnotation.Text, $" [{urlAnnotation.UrlCitation.Title}]({urlAnnotation.UrlCitation.Url})");
                            }
                        }
                    }
                    Console.Write($"Agent response: {response}");
                }
                else if (contentItem is MessageImageFileContent imageFileItem)
                {
                    Console.Write($"<image from ID: {imageFileItem.FileId}");
                }
                Console.WriteLine();
            }
        }
        #endregion
        #region Snippet:ConnectedAgentCleanup
        agentClient.DeleteThread(threadId: thread.Id);
        agentClient.DeleteAgent(agentId: agent.Id);
        agentClient.DeleteAgent(agentId: connectedAgent.Id);
        #endregion
    }
}
