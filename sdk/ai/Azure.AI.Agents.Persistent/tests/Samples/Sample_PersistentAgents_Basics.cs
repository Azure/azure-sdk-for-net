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

public partial class Sample_PersistentAgents_Basics : SamplesBase<AIAgentsTestEnvironment>
{
    [Test]
    [AsyncOnly]
    public async Task BasicExample()
    {
        #region Snippet:AgentsOverviewCreateAgentClient
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());
        #endregion

        // Step 1: Create an agent
        #region Snippet:AgentsOverviewCreateAgent
        PersistentAgent agent = await client.Administration.CreateAgentAsync(
            model: modelDeploymentName,
            name: "Math Tutor",
            instructions: "You are a personal math tutor. Write and run code to answer math questions."
        );
        #endregion

        //// Step 2: Create a thread
        #region Snippet:AgentsOverviewCreateThread
        PersistentAgentThread thread = await client.Threads.CreateThreadAsync();
        #endregion

        // Step 3: Add a message to a thread
        #region Snippet:AgentsOverviewCreateMessage
        PersistentThreadMessage message = await client.Messages.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "I need to solve the equation `3x + 11 = 14`. Can you help me?");
        #endregion

        // Intermission: message is now correlated with thread
        // Intermission: listing messages will retrieve the message just added

        AsyncPageable<PersistentThreadMessage> messagesList = client.Messages.GetMessagesAsync(thread.Id);
        List<PersistentThreadMessage> messagesOne = await messagesList.ToListAsync();
        Assert.AreEqual(message.Id, messagesOne[0].Id);

        // Step 4: Run the agent
        #region Snippet:AgentsOverviewCreateRun
        ThreadRun run = await client.Runs.CreateRunAsync(
            thread.Id,
            agent.Id,
            additionalInstructions: "Please address the user as Jane Doe. The user has a premium account.");
        #endregion

        #region Snippet:AgentsOverviewWaitForRun
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
        #endregion

        #region Snippet:AgentsOverviewListUpdatedMessages
        AsyncPageable<PersistentThreadMessage> messages
            = client.Messages.GetMessagesAsync(
                threadId: thread.Id, order: ListSortOrder.Ascending);

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
                    Console.Write($"<image from ID: {imageFileItem.FileId}");
                }
                Console.WriteLine();
            }
        }
        #endregion
        #region Snippet:AgentsOverviewCleanup
        await client.Threads.DeleteThreadAsync(threadId: thread.Id);
        await client.Administration.DeleteAgentAsync(agentId: agent.Id);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void BasicExampleSync()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());

        // Step 1: Create an agent
        #region Snippet:AgentsOverviewCreateAgentSync
        PersistentAgent agent = client.Administration.CreateAgent(
            model: modelDeploymentName,
            name: "Math Tutor",
            instructions: "You are a personal math tutor. Write and run code to answer math questions."
        );
        #endregion

        //// Step 2: Create a thread
        #region Snippet:AgentsOverviewCreateThreadSync
        PersistentAgentThread thread = client.Threads.CreateThread();
        #endregion

        // Step 3: Add a message to a thread
        #region Snippet:AgentsOverviewCreateMessageSync
        PersistentThreadMessage message = client.Messages.CreateMessage(
            thread.Id,
            MessageRole.User,
            "I need to solve the equation `3x + 11 = 14`. Can you help me?");
        #endregion

        // Intermission: message is now correlated with thread
        // Intermission: listing messages will retrieve the message just added

        List<PersistentThreadMessage> messagesList = [..client.Messages.GetMessages(thread.Id)];
        Assert.AreEqual(message.Id, messagesList[0].Id);

        // Step 4: Run the agent
        #region Snippet:AgentsOverviewCreateRunSync
        ThreadRun run = client.Runs.CreateRun(
            thread.Id,
            agent.Id,
            additionalInstructions: "Please address the user as Jane Doe. The user has a premium account.");
        #endregion

        #region Snippet:AgentsOverviewWaitForRunSync
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
        #endregion

        #region Snippet:AgentsOverviewListUpdatedMessagesSync
        Pageable<PersistentThreadMessage> messages
            = client.Messages.GetMessages(
                threadId: thread.Id, order: ListSortOrder.Ascending);

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
                    Console.Write($"<image from ID: {imageFileItem.FileId}");
                }
                Console.WriteLine();
            }
        }
        #endregion

        #region Snippet:AgentsOverviewCleanupSync
        client.Threads.DeleteThread(threadId: thread.Id);
        client.Administration.DeleteAgent(agentId: agent.Id);
        #endregion
    }
}
