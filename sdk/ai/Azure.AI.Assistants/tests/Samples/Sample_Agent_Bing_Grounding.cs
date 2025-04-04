// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Assistants.Tests;

public partial class Sample_Agent_Bing_Grounding : SamplesBase<AIAssistantsTestEnvironment>
{
    [Test]
    [AsyncOnly]
    public async Task BingGroundingExampleAsync()
    {
        #region Snippet:AssistantsBingGrounding_CreateProject
#if SNIPPET
        var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var bingConnectionName = System.Environment.GetEnvironmentVariable("BING_CONNECTION_NAME");
        var projectClient = new AIProjectClient(connectionString, new DefaultAzureCredential());
#else
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif

        AIAssistantClient agentClient = new(connectionString, new DefaultAzureCredential());
        #endregion
        #region Snippet:AssistantsBingGroundingAsync_GetConnection
#if SNIPPET
        ConnectionResponse bingConnection = await projectClient.GetConnectionsClient().GetConnectionAsync(bingConnectionName);
        var connectionId = bingConnection.Id;
#else
        var connectionId = TestEnvironment.BING_CONECTION_ID;
#endif
        ToolConnectionList connectionList = new()
        {
            ConnectionList = { new ToolConnection(connectionId) }
        };
        BingGroundingToolDefinition bingGroundingTool = new(connectionList);
        #endregion
        #region Snippet:AssistantsBingGroundingAsync_CreateAgent
        Agent agent = await agentClient.CreateAgentAsync(
           model: modelDeploymentName,
           name: "my-assistant",
           instructions: "You are a helpful assistant.",
           tools: [ bingGroundingTool ]);
        #endregion
        // Create thread for communication
        #region Snippet:AssistantsBingGroundingAsync_CreateThreadMessage
        AgentThread thread = await agentClient.CreateThreadAsync();

        // Create message to thread
        ThreadMessage message = await agentClient.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "How does wikipedia explain Euler's Identity?");

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

        #region Snippet:AssistantsBingGroundingAsync_Print
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
        #region Snippet:AssistantsBingGroundingCleanupAsync
        await agentClient.DeleteThreadAsync(threadId: thread.Id);
        await agentClient.DeleteAgentAsync(agentId: agent.Id);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void BingGroundingExample()
    {
#if SNIPPET
        var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var bingConnectionName = System.Environment.GetEnvironmentVariable("BING_CONNECTION_NAME");
        var projectClient = new AIProjectClient(connectionString, new DefaultAzureCredential());
#else
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var bingConnectionName = TestEnvironment.BINGCONNECTIONNAME;
#endif

        AIAssistantClient agentClient = new(connectionString, new DefaultAzureCredential());
        #region Snippet:AssistantsBingGrounding_GetConnection
#if SNIPPET
        ConnectionResponse bingConnection = projectClient.GetConnectionsClient().GetConnection(bingConnectionName);
        var connectionId = bingConnection.Id;
#else
        var connectionId = TestEnvironment.BING_CONECTION_ID;
#endif

        ToolConnectionList connectionList = new()
        {
            ConnectionList = { new ToolConnection(connectionId) }
        };
        BingGroundingToolDefinition bingGroundingTool = new(connectionList);
        #endregion
        #region Snippet:AssistantsBingGrounding_CreateAgent
        Agent agent = agentClient.CreateAgent(
           model: modelDeploymentName,
           name: "my-assistant",
           instructions: "You are a helpful assistant.",
           tools: [bingGroundingTool]);
        #endregion
        // Create thread for communication
        #region Snippet:AssistantsBingGrounding_CreateThreadMessage
        AgentThread thread = agentClient.CreateThread();

        // Create message to thread
        ThreadMessage message = agentClient.CreateMessage(
            thread.Id,
            MessageRole.User,
            "How does wikipedia explain Euler's Identity?");

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

        #region Snippet:AssistantsBingGrounding_Print
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
        #region Snippet:AssistantsBingGroundingCleanup
        agentClient.DeleteThread(threadId: thread.Id);
        agentClient.DeleteAgent(agentId: agent.Id);
        #endregion
    }
}
