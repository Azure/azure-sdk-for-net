// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests;
public partial class Sample_Agent_Multiple_Messages : SamplesBase<AIProjectsTestEnvironment>
{
    [Test]
    public async Task CreateAdditionalMessageExample()
    {
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
        var clientOptions = new AIProjectClientOptions();

        clientOptions.AddPolicy(new CustomHeadersPolicy(), HttpPipelinePosition.PerCall);
        var projectClient = new AIProjectClient(
            connectionString,
            new DefaultAzureCredential(),
            clientOptions);
        var agentClient = projectClient.GetAgentsClient();

        Response<Agent> agentResponse = await agentClient.CreateAgentAsync(
            model: "gpt-4-1106-preview",
            name: "Math Tutor",
            instructions: "You are a personal electronics tutor. Write and run code to answer questions.",
            tools: [new CodeInterpreterToolDefinition()]);
        Agent agent = agentResponse.Value;

        var threadResponse = await agentClient.CreateThreadAsync();
        var thread= threadResponse.Value;
        Response<ThreadMessage> messageResponse = await agentClient.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "What is the impedance formula?");
        ThreadMessage message = messageResponse.Value;

        var agentRun = await agentClient.CreateRunAsync(
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
            agentRun = await agentClient.GetRunAsync(thread.Id, agentRun.Value.Id);
        }
        while (agentRun.Value.Status == RunStatus.Queued
            || agentRun.Value.Status == RunStatus.InProgress);

        Response<PageableList<ThreadMessage>> afterRunMessagesResponse
            = await agentClient.GetMessagesAsync(thread.Id);
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
    }
}
