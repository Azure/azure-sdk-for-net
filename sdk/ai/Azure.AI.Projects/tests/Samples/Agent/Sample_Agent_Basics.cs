// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests;

public partial class Sample_Agent_Basics : SamplesBase<AIProjectsTestEnvironment>
{
    [Test]
    [AsyncOnly]
    public async Task BasicExample()
    {
        #region Snippet:OverviewCreateAgentClient
#if SNIPPET
        var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AgentsClient client = new(connectionString, new DefaultAzureCredential());
        #endregion

        // Step 1: Create an agent
        #region Snippet:OverviewCreateAgent
        Agent agent = await client.CreateAgentAsync(
            model: modelDeploymentName,
            name: "Math Tutor",
            instructions: "You are a personal math tutor. Write and run code to answer math questions."
        );
        #endregion

        //// Step 2: Create a thread
        #region Snippet:OverviewCreateThread
        AgentThread thread = await client.CreateThreadAsync();
        #endregion

        Response<PageableList<AgentThread>> threadsListResponse = await client.GetThreadsAsync();

        // Step 3: Add a message to a thread
        #region Snippet:OverviewCreateMessage
        ThreadMessage message = await client.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "I need to solve the equation `3x + 11 = 14`. Can you help me?");
        #endregion

        // Intermission: message is now correlated with thread
        // Intermission: listing messages will retrieve the message just added

        Response<PageableList<ThreadMessage>> messagesListResponse = await client.GetMessagesAsync(thread.Id);

        // Step 4: Run the agent
        #region Snippet:OverviewCreateRun
        ThreadRun run = await client.CreateRunAsync(
            thread.Id,
            agent.Id,
            additionalInstructions: "Please address the user as Jane Doe. The user has a premium account.");
        #endregion

        #region Snippet:OverviewWaitForRun
        do
        {
            await Task.Delay(TimeSpan.FromMilliseconds(500));
            run = await client.GetRunAsync(thread.Id, run.Id);
        }
        while (run.Status == RunStatus.Queued
            || run.Status == RunStatus.InProgress);
        Assert.AreEqual(
            RunStatus.Completed,
            run.Status,
            run.LastError?.Message);
        #endregion

        #region Snippet:OverviewListUpdatedMessages
        PageableList<ThreadMessage> messages
            = await client.GetMessagesAsync(
                threadId: thread.Id, order: ListSortOrder.Ascending);

        foreach (ThreadMessage threadMessage in messages)
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
                    Console.Write($"<image from ID: {imageFileItem.FileId}");
                }
                Console.WriteLine();
            }
        }
        #endregion
        #region Snippet:OverviewCleanup
        await client.DeleteThreadAsync(threadId: thread.Id);
        await client.DeleteAgentAsync(agentId: agent.Id);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void BasicExampleSync()
    {
#if SNIPPET
        var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AgentsClient client = new(connectionString, new DefaultAzureCredential());

        // Step 1: Create an agent
        #region Snippet:OverviewCreateAgentSync
        Agent agent = client.CreateAgent(
            model: modelDeploymentName,
            name: "Math Tutor",
            instructions: "You are a personal math tutor. Write and run code to answer math questions."
        );
        #endregion

        //// Step 2: Create a thread
        #region Snippet:OverviewCreateThreadSync
        AgentThread thread = client.CreateThread();
        #endregion

        Response<PageableList<AgentThread>> threadsListResponse = client.GetThreads();
        Assert.That(threadsListResponse.Value.Data[0].Id == thread.Id);

        // Step 3: Add a message to a thread
        #region Snippet:OverviewCreateMessageSync
        ThreadMessage message = client.CreateMessage(
            thread.Id,
            MessageRole.User,
            "I need to solve the equation `3x + 11 = 14`. Can you help me?");
        #endregion

        // Intermission: message is now correlated with thread
        // Intermission: listing messages will retrieve the message just added

        Response<PageableList<ThreadMessage>> messagesListResponse = client.GetMessages(thread.Id);
        Assert.That(messagesListResponse.Value.Data[0].Id == message.Id);

        // Step 4: Run the agent
        #region Snippet:OverviewCreateRunSync
        ThreadRun run = client.CreateRun(
            thread.Id,
            agent.Id,
            additionalInstructions: "Please address the user as Jane Doe. The user has a premium account.");
        #endregion

        #region Snippet:OverviewWaitForRunSync
        do
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(500));
            run = client.GetRun(thread.Id, run.Id);
        }
        while (run.Status == RunStatus.Queued
            || run.Status == RunStatus.InProgress);
        Assert.AreEqual(
            RunStatus.Completed,
            run.Status,
            run.LastError?.Message);
        #endregion

        #region Snippet:OverviewListUpdatedMessagesSync
        PageableList<ThreadMessage> messages
            = client.GetMessages(
                threadId: thread.Id, order: ListSortOrder.Ascending);

        foreach (ThreadMessage threadMessage in messages)
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
                    Console.Write($"<image from ID: {imageFileItem.FileId}");
                }
                Console.WriteLine();
            }
        }
        #endregion

        #region Snippet:OverviewCleanupSync
        client.DeleteThread(threadId: thread.Id);
        client.DeleteAgent(agentId: agent.Id);
        #endregion
    }
}
