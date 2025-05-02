// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Agents.Persistent.Custom;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Agents.Persistent.Tests;
public partial class Sample_PersistentAgents_Multiple_Messages : SamplesBase<AIAgentsTestEnvironment>
{
    [Test]
    [AsyncOnly]
    public async Task CreateAdditionalMessageExampleAsync()
    {
        #region Snippet:Sample_Agent_Multiple_Messages_CreateAsync
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        var agentClient = new PersistentAgentsClient(
            projectEndpoint,
            new DefaultAzureCredential());

        PersistentAgent agent = await agentClient.AgentsAdministration.CreateAgentAsync(
            model: modelDeploymentName,
            name: "Math Tutor",
            instructions: "You are a personal electronics tutor. Write and run code to answer questions.",
            tools: [new CodeInterpreterToolDefinition()]);
        #endregion
        #region Snippet:Sample_Agent_Multiple_Messages_RunAsync
        PersistentAgentThread thread = await agentClient.Threads.CreateThreadAsync();
        ThreadMessage message = await agentClient.Messages.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "What is the impedance formula?");

        ThreadRun agentRun = await agentClient.ThreadRuns.CreateRunAsync(
            threadId: thread.Id,
            agent.Id,
            additionalMessages: [
                new ThreadMessageOptions(
                    role: MessageRole.Agent,
                    content: "E=mc^2"
                ),
                new ThreadMessageOptions(
                    role: MessageRole.User,
                    content: "What is the impedance formula?"
                ),
            ]
        );

        do
        {
            await Task.Delay(TimeSpan.FromMilliseconds(500));
            agentRun = await agentClient.ThreadRuns.GetRunAsync(thread.Id, agentRun.Id);
        }
        while (agentRun.Status == RunStatus.Queued
            || agentRun.Status == RunStatus.InProgress);
        #endregion
        #region Snippet:Sample_Agent_Multiple_Messages_PrintAsync
        AsyncPageable<ThreadMessage> messages = agentClient.Messages.GetMessagesAsync(thread.Id, order:ListSortOrder.Ascending);

        await foreach (ThreadMessage threadMessage in messages)
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
    }

    [Test]
    [SyncOnly]
    public void CreateAdditionalMessageExample()
    {
        #region Snippet:Sample_Agent_Multiple_Messages_Create
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        var agentClient = new PersistentAgentsClient(
            projectEndpoint,
            new DefaultAzureCredential());

        PersistentAgent agent = agentClient.AgentsAdministration.CreateAgent(
            model: modelDeploymentName,
            name: "Math Tutor",
            instructions: "You are a personal electronics tutor. Write and run code to answer questions.",
            tools: [new CodeInterpreterToolDefinition()]);
        #endregion
        #region Snippet:Sample_Agent_Multiple_Messages_Run
        PersistentAgentThread thread = agentClient.Threads.CreateThread();
        ThreadMessage message = agentClient.Messages.CreateMessage(
            thread.Id,
            MessageRole.User,
            "What is the impedance formula?");

        ThreadRun agentRun = agentClient.ThreadRuns.CreateRun(
            threadId: thread.Id,
            agent.Id,
            additionalMessages: [
                new ThreadMessageOptions(
                    role: MessageRole.Agent,
                    content: "E=mc^2"
                ),
                new ThreadMessageOptions(
                    role: MessageRole.User,
                    content: "What is the impedance formula?"
                ),
            ]
        );

        do
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(500));
            agentRun = agentClient.ThreadRuns.GetRun(thread.Id, agentRun.Id);
        }
        while (agentRun.Status == RunStatus.Queued
            || agentRun.Status == RunStatus.InProgress);
        #endregion
        #region Snippet:Sample_Agent_Multiple_Messages_Print
        Pageable<ThreadMessage> messages = agentClient.Messages.GetMessages(thread.Id, order: ListSortOrder.Ascending);

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
    }
}
