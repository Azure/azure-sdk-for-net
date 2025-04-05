// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Assistants.Tests;

public partial class Sample_Assistants_Bing_Grounding : SamplesBase<AIAssistantsTestEnvironment>
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

        AssistantsClient assistantClient = new(connectionString, new DefaultAzureCredential());
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
        Assistant assistant = await assistantClient.CreateAssistantAsync(
           model: modelDeploymentName,
           name: "my-assistant",
           instructions: "You are a helpful assistant.",
           tools: [ bingGroundingTool ]);
        #endregion
        // Create thread for communication
        #region Snippet:AssistantsBingGroundingAsync_CreateThreadMessage
        AssistantThread thread = await assistantClient.CreateThreadAsync();

        // Create message to thread
        ThreadMessage message = await assistantClient.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "How does wikipedia explain Euler's Identity?");

        // Run the assistant
        ThreadRun run = await assistantClient.CreateRunAsync(thread, assistant);
        do
        {
            await Task.Delay(TimeSpan.FromMilliseconds(500));
            run = await assistantClient.GetRunAsync(thread.Id, run.Id);
        }
        while (run.Status == RunStatus.Queued
            || run.Status == RunStatus.InProgress);

        Assert.AreEqual(
            RunStatus.Completed,
            run.Status,
            run.LastError?.Message);
        #endregion

        #region Snippet:AssistantsBingGroundingAsync_Print
        PageableList<ThreadMessage> messages = await assistantClient.GetMessagesAsync(
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
                    Console.Write($"Assistant response: {response}");
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
        await assistantClient.DeleteThreadAsync(threadId: thread.Id);
        await assistantClient.DeleteAssistantAsync(assistantId: assistant.Id);
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

        AssistantsClient assistantClient = new(connectionString, new DefaultAzureCredential());
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
        Assistant assistant = assistantClient.CreateAssistant(
           model: modelDeploymentName,
           name: "my-assistant",
           instructions: "You are a helpful assistant.",
           tools: [bingGroundingTool]);
        #endregion
        // Create thread for communication
        #region Snippet:AssistantsBingGrounding_CreateThreadMessage
        AssistantThread thread = assistantClient.CreateThread();

        // Create message to thread
        ThreadMessage message = assistantClient.CreateMessage(
            thread.Id,
            MessageRole.User,
            "How does wikipedia explain Euler's Identity?");

        // Run the assistant
        ThreadRun run = assistantClient.CreateRun(thread, assistant);
        do
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(500));
            run = assistantClient.GetRun(thread.Id, run.Id);
        }
        while (run.Status == RunStatus.Queued
            || run.Status == RunStatus.InProgress);

        Assert.AreEqual(
            RunStatus.Completed,
            run.Status,
            run.LastError?.Message);
        #endregion

        #region Snippet:AssistantsBingGrounding_Print
        PageableList<ThreadMessage> messages = assistantClient.GetMessages(
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
                    Console.Write($"Assistant response: {response}");
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
        assistantClient.DeleteThread(threadId: thread.Id);
        assistantClient.DeleteAssistant(assistantId: assistant.Id);
        #endregion
    }
}
