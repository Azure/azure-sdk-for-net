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

namespace Azure.AI.Projects.Tests;

public partial class Sample_Agents_Code_Interpreter_File_Attachment : SamplesBase<AIProjectsTestEnvironment>
{
    [Test]
    [AsyncOnly]
    public async Task CodeInterpreterFileAttachmentAsync()
    {
        #region Snippet:CodeInterpreterFileAttachment_CreateClient
#if SNIPPET
        var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AgentsClient client = new AgentsClient(connectionString, new DefaultAzureCredential());
        #endregion
        #region Snippet:CreateAgentWithInterpreterTool
        List<ToolDefinition> tools = [ new CodeInterpreterToolDefinition() ];
        Agent agent = await client.CreateAgentAsync(
            model: modelDeploymentName,
            name: "my-assistant",
            instructions: "You are a helpful agent that can help fetch data from files you know about.",
            tools: tools
        );

        File.WriteAllText(
            path: "sample_file_for_upload.txt",
            contents: "The word 'apple' uses the code 442345, while the word 'banana' uses the code 673457.");
        AgentFile uploadedAgentFile = await client.UploadFileAsync(
            filePath: "sample_file_for_upload.txt",
            purpose: AgentFilePurpose.Agents);
        var fileId = uploadedAgentFile.Id;

        var attachment = new MessageAttachment(
            fileId: fileId,
            tools: tools
        );

        AgentThread thread = await client.CreateThreadAsync();

        ThreadMessage message = await client.CreateMessageAsync(
            threadId: thread.Id,
            role: MessageRole.User,
            content: "Can you give me the documented codes for 'banana' and 'orange'?",
            attachments: [ attachment ]
        );
        #endregion
        #region Snippet:CodeInterpreterFileAttachment_CreateRun
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
        #region Snippet:CodeInterpreterFileAttachment_PrintMessages
        PageableList<ThreadMessage> messages = await client.GetMessagesAsync(
            threadId: thread.Id,
            order: ListSortOrder.Ascending
        );
        WriteMessages(messages);
        #endregion
        #region Snippet:CodeInterpreterFileAttachment_Cleanup
        await client.DeleteThreadAsync(thread.Id);
        await client.DeleteAgentAsync(agent.Id);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void CodeInterpreterFileAttachment()
    {
#if SNIPPET
        var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;

#endif
        AgentsClient client = new AgentsClient(connectionString, new DefaultAzureCredential());
        #region Snippet:CreateAgentWithInterpreterToolSync
        List<ToolDefinition> tools = [new CodeInterpreterToolDefinition()];
        Agent agent = client.CreateAgent(
            model: modelDeploymentName,
            name: "my-assistant",
            instructions: "You are a helpful agent that can help fetch data from files you know about.",
            tools: tools
        );

        File.WriteAllText(
            path: "sample_file_for_upload.txt",
            contents: "The word 'apple' uses the code 442345, while the word 'banana' uses the code 673457.");
        AgentFile uploadedAgentFile = client.UploadFile(
            filePath: "sample_file_for_upload.txt",
            purpose: AgentFilePurpose.Agents);
        var fileId = uploadedAgentFile.Id;

        var attachment = new MessageAttachment(
            fileId: fileId,
            tools: tools
        );

        AgentThread thread = client.CreateThread();

        ThreadMessage message = client.CreateMessage(
            threadId: thread.Id,
            role: MessageRole.User,
            content: "Can you give me the documented codes for 'banana' and 'orange'?",
            attachments: [attachment]
        );
        #endregion
        #region Snippet:CodeInterpreterFileAttachmentSync_CreateRun
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
        #region Snippet:CodeInterpreterFileAttachmentSync_PrintMessages
        PageableList<ThreadMessage> messages = client.GetMessages(
            threadId: thread.Id,
            order: ListSortOrder.Ascending
        );
        WriteMessages(messages);
        #endregion
        #region Snippet:CodeInterpreterFileAttachmentSync_Cleanup
        client.DeleteThread(thread.Id);
        client.DeleteAgent(agent.Id);
        #endregion
    }

    #region Snippet:CodeInterpreterFileAttachment_Print
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
