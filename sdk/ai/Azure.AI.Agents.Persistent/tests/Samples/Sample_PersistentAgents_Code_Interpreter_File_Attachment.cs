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

namespace Azure.AI.Agents.Persistent.Tests;

public partial class Sample_PersistentAgents_Code_Interpreter_File_Attachment : SamplesBase<AIAgentsTestEnvironment>
{
    [Test]
    [AsyncOnly]
    public async Task CodeInterpreterFileAttachmentAsync()
    {
        #region Snippet:AgentsCodeInterpreterFileAttachment_CreateClient
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());
        #endregion
        #region Snippet:AgentsCreateAgentWithInterpreterTool
        List<ToolDefinition> tools = [ new CodeInterpreterToolDefinition() ];
        PersistentAgent agent = await client.CreateAgentAsync(
            model: modelDeploymentName,
            name: "my-agent",
            instructions: "You are a helpful agent that can help fetch data from files you know about.",
            tools: tools
        );

        System.IO.File.WriteAllText(
            path: "sample_file_for_upload.txt",
            contents: "The word 'apple' uses the code 442345, while the word 'banana' uses the code 673457.");
        PersistentAgentFile uploadedAgentFile = await client.UploadFileAsync(
            filePath: "sample_file_for_upload.txt",
            purpose: PersistentAgentFilePurpose.Agents);
        var fileId = uploadedAgentFile.Id;

        var attachment = new MessageAttachment(
            fileId: fileId,
            tools: tools
        );

        PersistentAgentThread thread = await client.CreateThreadAsync();

        ThreadMessage message = await client.CreateMessageAsync(
            threadId: thread.Id,
            role: MessageRole.User,
            content: "Can you give me the documented codes for 'banana' and 'orange'?",
            attachments: [ attachment ]
        );
        #endregion
        #region Snippet:AgentsCodeInterpreterFileAttachment_CreateRun
        ThreadRun run = await client.CreateRunAsync(
            thread.Id,
            agent.Id
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
        #region Snippet:AgentsCodeInterpreterFileAttachment_PrintMessages
        PageableList<ThreadMessage> messages = await client.GetMessagesAsync(
            threadId: thread.Id,
            order: ListSortOrder.Ascending
        );
        WriteMessages(messages);
        #endregion
        #region Snippet:AgentsCodeInterpreterFileAttachment_Cleanup
        await client.DeleteThreadAsync(thread.Id);
        await client.DeleteAgentAsync(agent.Id);
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
        PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());
        #region Snippet:AgentsCreateAgentWithInterpreterToolSync
        List<ToolDefinition> tools = [new CodeInterpreterToolDefinition()];
        PersistentAgent agent = client.CreateAgent(
            model: modelDeploymentName,
            name: "my-agent",
            instructions: "You are a helpful agent that can help fetch data from files you know about.",
            tools: tools
        );

        System.IO.File.WriteAllText(
            path: "sample_file_for_upload.txt",
            contents: "The word 'apple' uses the code 442345, while the word 'banana' uses the code 673457.");
        PersistentAgentFile uploadedAgentFile = client.UploadFile(
            filePath: "sample_file_for_upload.txt",
            purpose: PersistentAgentFilePurpose.Agents);
        var fileId = uploadedAgentFile.Id;

        var attachment = new MessageAttachment(
            fileId: fileId,
            tools: tools
        );

        PersistentAgentThread thread = client.CreateThread();

        ThreadMessage message = client.CreateMessage(
            threadId: thread.Id,
            role: MessageRole.User,
            content: "Can you give me the documented codes for 'banana' and 'orange'?",
            attachments: [attachment]
        );
        #endregion
        #region Snippet:AgentsCodeInterpreterFileAttachmentSync_CreateRun
        ThreadRun run = client.CreateRun(
            thread.Id,
            agent.Id
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
        #region Snippet:AgentsCodeInterpreterFileAttachmentSync_PrintMessages
        PageableList<ThreadMessage> messages = client.GetMessages(
            threadId: thread.Id,
            order: ListSortOrder.Ascending
        );
        WriteMessages(messages);
        #endregion
        #region Snippet:AgentsCodeInterpreterFileAttachmentSync_Cleanup
        client.DeleteThread(thread.Id);
        client.DeleteAgent(agent.Id);
        #endregion
    }

    #region Snippet:AgentsCodeInterpreterFileAttachment_Print
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
