// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Assistants.Custom;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Assistants.Tests;
public partial class Sample_Assistants_Multiple_Messages : SamplesBase<AIAssistantsTestEnvironment>
{
    [Test]
    [AsyncOnly]
    public async Task CreateAdditionalMessageExampleAsync()
    {
        #region Snippet:Sample_Assistant_Multiple_Messages_CreateAsync
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        var assistantClient = new AssistantsClient(
            projectEndpoint,
            new DefaultAzureCredential());

        Assistant assistant = await assistantClient.CreateAssistantAsync(
            model: modelDeploymentName,
            name: "Math Tutor",
            instructions: "You are a personal electronics tutor. Write and run code to answer questions.",
            tools: [new CodeInterpreterToolDefinition()]);
        #endregion
        #region Snippet:Sample_Assistant_Multiple_Messages_RunAsync
        AssistantThread thread = await assistantClient.CreateThreadAsync();
        ThreadMessage message = await assistantClient.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "What is the impedance formula?");

        ThreadRun assistantRun = await assistantClient.CreateRunAsync(
            threadId: thread.Id,
            assistant.Id,
            additionalMessages: [
                new ThreadMessageOptions(
                    role: MessageRole.Assistant,
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
            assistantRun = await assistantClient.GetRunAsync(thread.Id, assistantRun.Id);
        }
        while (assistantRun.Status == RunStatus.Queued
            || assistantRun.Status == RunStatus.InProgress);
        #endregion
        #region Snippet:Sample_Assistant_Multiple_Messages_PrintAsync
        PageableList<ThreadMessage> messages = await assistantClient.GetMessagesAsync(thread.Id, order:ListSortOrder.Ascending);

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

    [Test]
    [SyncOnly]
    public void CreateAdditionalMessageExample()
    {
        #region Snippet:Sample_Assistant_Multiple_Messages_Create
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        var assistantClient = new AssistantsClient(
            projectEndpoint,
            new DefaultAzureCredential());

        Assistant assistant = assistantClient.CreateAssistant(
            model: modelDeploymentName,
            name: "Math Tutor",
            instructions: "You are a personal electronics tutor. Write and run code to answer questions.",
            tools: [new CodeInterpreterToolDefinition()]);
        #endregion
        #region Snippet:Sample_Assistant_Multiple_Messages_Run
        AssistantThread thread = assistantClient.CreateThread();
        ThreadMessage message = assistantClient.CreateMessage(
            thread.Id,
            MessageRole.User,
            "What is the impedance formula?");

        ThreadRun assistantRun = assistantClient.CreateRun(
            threadId: thread.Id,
            assistant.Id,
            additionalMessages: [
                new ThreadMessageOptions(
                    role: MessageRole.Assistant,
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
            assistantRun = assistantClient.GetRun(thread.Id, assistantRun.Id);
        }
        while (assistantRun.Status == RunStatus.Queued
            || assistantRun.Status == RunStatus.InProgress);
        #endregion
        #region Snippet:Sample_Assistant_Multiple_Messages_Print
        PageableList<ThreadMessage> messages = assistantClient.GetMessages(thread.Id, order: ListSortOrder.Ascending);

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
