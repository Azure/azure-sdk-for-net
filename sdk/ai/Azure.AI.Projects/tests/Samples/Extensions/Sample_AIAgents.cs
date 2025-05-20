// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Agents.Persistent;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests;

public class Sample_AIAgents : SamplesBase<AIProjectsTestEnvironment>
{
    [Test]
    [SyncOnly]
    public void AgentsBasics()
    {
        #region Snippet:AI_Projects_ExtensionsAgentsBasicsSync
#if SNIPPET
        var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var endpoint = TestEnvironment.PROJECTENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
        PersistentAgentsClient agentsClient = projectClient.GetPersistentAgentsClient();

        // Step 1: Create an agent
        PersistentAgent agent = agentsClient.Administration.CreateAgent(
            model: modelDeploymentName,
            name: "Math Tutor",
            instructions: "You are a personal math tutor. Write and run code to answer math questions."
        );

        //// Step 2: Create a thread
        PersistentAgentThread thread = agentsClient.Threads.CreateThread();

        // Step 3: Add a message to a thread
        PersistentThreadMessage message = agentsClient.Messages.CreateMessage(
            thread.Id,
            MessageRole.User,
            "I need to solve the equation `3x + 11 = 14`. Can you help me?");

        // Intermission: message is now correlated with thread
        // Intermission: listing messages will retrieve the message just added

        List<PersistentThreadMessage> messagesList = [.. agentsClient.Messages.GetMessages(thread.Id)];
        Assert.AreEqual(message.Id, messagesList[0].Id);

        // Step 4: Run the agent
        ThreadRun run = agentsClient.Runs.CreateRun(
            thread.Id,
            agent.Id,
            additionalInstructions: "Please address the user as Jane Doe. The user has a premium account.");
        do
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(500));
            run = agentsClient.Runs.GetRun(thread.Id, run.Id);
        }
        while (run.Status == RunStatus.Queued
            || run.Status == RunStatus.InProgress);
        Assert.AreEqual(
            RunStatus.Completed,
            run.Status,
            run.LastError?.Message);

        Pageable<PersistentThreadMessage> messages
            = agentsClient.Messages.GetMessages(
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

        agentsClient.Threads.DeleteThread(threadId: thread.Id);
        agentsClient.Administration.DeleteAgent(agentId: agent.Id);
        #endregion

    }

    [Test]
    [AsyncOnly]
    public async Task AgentsBasicsAsync()
    {
        #region Snippet:AI_Projects_ExtensionsAgentsBasicsAsync
#if SNIPPET
        var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var endpoint = TestEnvironment.PROJECTENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
        PersistentAgentsClient agentsClient = projectClient.GetPersistentAgentsClient();
        #endregion

        // Step 1: Create an agent
        #region Snippet:AI_Projects_ExtensionsAgentsOverviewCreateAgent
        PersistentAgent agent = await agentsClient.Administration.CreateAgentAsync(
            model: modelDeploymentName,
            name: "Math Tutor",
            instructions: "You are a personal math tutor. Write and run code to answer math questions."
        );
        #endregion

        //// Step 2: Create a thread
        #region Snippet:AI_Projects_ExtensionsAgentsOverviewCreateThread
        PersistentAgentThread thread = await agentsClient.Threads.CreateThreadAsync();
        #endregion

        // Step 3: Add a message to a thread
        #region Snippet:AI_Projects_ExtensionsAgentsOverviewCreateMessage
        PersistentThreadMessage message = await agentsClient.Messages.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "I need to solve the equation `3x + 11 = 14`. Can you help me?");
        #endregion

        // Intermission: message is now correlated with thread
        // Intermission: listing messages will retrieve the message just added

        AsyncPageable<PersistentThreadMessage> messagesList = agentsClient.Messages.GetMessagesAsync(thread.Id);
        List<PersistentThreadMessage> messagesOne = await messagesList.ToListAsync();
        Assert.AreEqual(message.Id, messagesOne[0].Id);

        // Step 4: Run the agent
        #region Snippet:AI_Projects_ExtensionsAgentsOverviewCreateRun
        ThreadRun run = await agentsClient.Runs.CreateRunAsync(
            thread.Id,
            agent.Id,
            additionalInstructions: "Please address the user as Jane Doe. The user has a premium account.");
        #endregion

        #region Snippet:AI_Projects_ExtensionsAgentsOverviewWaitForRun
        do
        {
            await Task.Delay(TimeSpan.FromMilliseconds(500));
            run = await agentsClient.Runs.GetRunAsync(thread.Id, run.Id);
        }
        while (run.Status == RunStatus.Queued
            || run.Status == RunStatus.InProgress);
        Assert.AreEqual(
            RunStatus.Completed,
            run.Status,
            run.LastError?.Message);
        #endregion

        #region Snippet:AI_Projects_ExtensionsAgentsOverviewListUpdatedMessages
        AsyncPageable<PersistentThreadMessage> messages
            = agentsClient.Messages.GetMessagesAsync(
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
        #region Snippet:AI_Projects_ExtensionsAgentsOverviewCleanup
        await agentsClient.Threads.DeleteThreadAsync(threadId: thread.Id);

        await agentsClient.Administration.DeleteAgentAsync(agentId: agent.Id);
        #endregion
    }
}
