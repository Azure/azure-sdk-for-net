// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Assistants.Tests;

public partial class Sample_Assistants_Code_Interpreter_File_Attachment : SamplesBase<AIAssistantsTestEnvironment>
{
    [Test]
    [AsyncOnly]
    public async Task CodeInterpreterFileAttachmentAsync()
    {
        #region Snippet:AssistantsCodeInterpreterFileAttachment_CreateClient
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AssistantsClient client = new(projectEndpoint, new DefaultAzureCredential());
        #endregion
        #region Snippet:AssistantsCreateAgentWithInterpreterTool
        List<ToolDefinition> tools = [ new CodeInterpreterToolDefinition() ];
        Assistant assistant = await client.CreateAssistantAsync(
            model: modelDeploymentName,
            name: "my-assistant",
            instructions: "You are a helpful assistant that can help fetch data from files you know about.",
            tools: tools
        );

        System.IO.File.WriteAllText(
            path: "sample_file_for_upload.txt",
            contents: "The word 'apple' uses the code 442345, while the word 'banana' uses the code 673457.");
        AssistantFile uploadedAssistantFile = await client.UploadFileAsync(
            filePath: "sample_file_for_upload.txt",
            purpose: AssistantFilePurpose.Assistants);
        var fileId = uploadedAssistantFile.Id;

        var attachment = new MessageAttachment(
            fileId: fileId,
            tools: tools
        );

        AssistantThread thread = await client.CreateThreadAsync();

        ThreadMessage message = await client.CreateMessageAsync(
            threadId: thread.Id,
            role: MessageRole.User,
            content: "Can you give me the documented codes for 'banana' and 'orange'?",
            attachments: [ attachment ]
        );
        #endregion
        #region Snippet:AssistantsCodeInterpreterFileAttachment_CreateRun
        ThreadRun run = await client.CreateRunAsync(
            thread.Id,
            assistant.Id
        );

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
        #region Snippet:AssistantsCodeInterpreterFileAttachment_PrintMessages
        PageableList<ThreadMessage> messages = await client.GetMessagesAsync(
            threadId: thread.Id,
            order: ListSortOrder.Ascending
        );
        WriteMessages(messages);
        #endregion
        #region Snippet:AssistantsCodeInterpreterFileAttachment_Cleanup
        await client.DeleteThreadAsync(thread.Id);
        await client.DeleteAssistantAsync(assistant.Id);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void CodeInterpreterFileAttachment()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;

#endif
        AssistantsClient client = new(projectEndpoint, new DefaultAzureCredential());
        #region Snippet:AssistantsCreateAgentWithInterpreterToolSync
        List<ToolDefinition> tools = [new CodeInterpreterToolDefinition()];
        Assistant assistant = client.CreateAssistant(
            model: modelDeploymentName,
            name: "my-assistant",
            instructions: "You are a helpful assistant that can help fetch data from files you know about.",
            tools: tools
        );

        System.IO.File.WriteAllText(
            path: "sample_file_for_upload.txt",
            contents: "The word 'apple' uses the code 442345, while the word 'banana' uses the code 673457.");
        AssistantFile uploadedAssistantFile = client.UploadFile(
            filePath: "sample_file_for_upload.txt",
            purpose: AssistantFilePurpose.Assistants);
        var fileId = uploadedAssistantFile.Id;

        var attachment = new MessageAttachment(
            fileId: fileId,
            tools: tools
        );

        AssistantThread thread = client.CreateThread();

        ThreadMessage message = client.CreateMessage(
            threadId: thread.Id,
            role: MessageRole.User,
            content: "Can you give me the documented codes for 'banana' and 'orange'?",
            attachments: [attachment]
        );
        #endregion
        #region Snippet:AssistantsCodeInterpreterFileAttachmentSync_CreateRun
        ThreadRun run = client.CreateRun(
            thread.Id,
            assistant.Id
        );

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
        #region Snippet:AssistantsCodeInterpreterFileAttachmentSync_PrintMessages
        PageableList<ThreadMessage> messages = client.GetMessages(
            threadId: thread.Id,
            order: ListSortOrder.Ascending
        );
        WriteMessages(messages);
        #endregion
        #region Snippet:AssistantsCodeInterpreterFileAttachmentSync_Cleanup
        client.DeleteThread(thread.Id);
        client.DeleteAssistant(assistant.Id);
        #endregion
    }

    #region Snippet:AssistantsCodeInterpreterFileAttachment_Print
    private static void WriteMessages(IEnumerable<ThreadMessage> messages)
    {
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
    #endregion
}
