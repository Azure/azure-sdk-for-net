// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests;

public partial class Sample_Agent_Basics : SamplesBase<AIProjectsTestEnvironment>
{
    [Test]
    public async Task BasicExample()
    {
        #region Snippet:OverviewCreateAgentClient
#if SNIPPET
        var connectionString = Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
#else
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
#endif
        AgentsClient client = new AgentsClient(connectionString, new DefaultAzureCredential());
        #endregion

        // Step 1: Create an agent
        #region Snippet:OverviewCreateAgent
        Response<Agent> agentResponse = await client.CreateAgentAsync(
            model: "gpt-4-1106-preview",
            name: "Math Tutor",
            instructions: "You are a personal math tutor. Write and run code to answer math questions.",
            tools: new List<ToolDefinition> { new CodeInterpreterToolDefinition() });
        Agent agent = agentResponse.Value;
        #endregion

        // Intermission: agent should now be listed

        Response<PageableList<Agent>> agentListResponse = await client.GetAgentsAsync();

        //// Step 2: Create a thread
        #region Snippet:OverviewCreateThread
        Response<AgentThread> threadResponse = await client.CreateThreadAsync();
        AgentThread thread = threadResponse.Value;
        #endregion

        // Step 3: Add a message to a thread
        #region Snippet:OverviewCreateMessage
        Response<ThreadMessage> messageResponse = await client.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "I need to solve the equation `3x + 11 = 14`. Can you help me?");
        ThreadMessage message = messageResponse.Value;
        #endregion

        // Intermission: message is now correlated with thread
        // Intermission: listing messages will retrieve the message just added

        Response<PageableList<ThreadMessage>> messagesListResponse = await client.GetMessagesAsync(thread.Id);
        Assert.That(messagesListResponse.Value.Data[0].Id == message.Id);

        // Step 4: Run the agent
        #region Snippet:OverviewCreateRun
        Response<ThreadRun> runResponse = await client.CreateRunAsync(
            thread.Id,
            agent.Id,
            additionalInstructions: "Please address the user as Jane Doe. The user has a premium account.");
        ThreadRun run = runResponse.Value;
        #endregion

        #region Snippet:OverviewWaitForRun
        do
        {
            await Task.Delay(TimeSpan.FromMilliseconds(500));
            runResponse = await client.GetRunAsync(thread.Id, runResponse.Value.Id);
        }
        while (runResponse.Value.Status == RunStatus.Queued
            || runResponse.Value.Status == RunStatus.InProgress);
        #endregion

        #region Snippet:OverviewListUpdatedMessages
        Response<PageableList<ThreadMessage>> afterRunMessagesResponse
            = await client.GetMessagesAsync(thread.Id);
        IReadOnlyList<ThreadMessage> messages = afterRunMessagesResponse.Value.Data;

        // Note: messages iterate from newest to oldest, with the messages[0] being the most recent
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
