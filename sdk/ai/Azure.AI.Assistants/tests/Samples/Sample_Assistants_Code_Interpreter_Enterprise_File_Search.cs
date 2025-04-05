// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Assistants.Custom;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Assistants.Tests;

public partial class Sample_Assistants_Code_Interpreter_Enterprise_File_Search : SamplesBase<AIAssistantsTestEnvironment>
{
    [Test]
    [AsyncOnly]
    public async Task CodeInterpreterEnterpriseSearch()
    {
        #region Snippet:AssistantsCodeInterpreterEnterpriseSearch_CreateClient
#if SNIPPET
        var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var blobURI = Environment.GetEnvironmentVariable("AZURE_BLOB_URI");
#else
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        // For now we will take the File URI from the environment variables.
        // In future we may want to upload file to Azure here.
        var blobURI = TestEnvironment.AZURE_BLOB_URI;
#endif
        AssistantsClient client = new(connectionString, new DefaultAzureCredential());
        #endregion
        #region Snippet:AssistantsCodeInterpreterEnterpriseSearchAsync_CreateAgent
        List<ToolDefinition> tools = [ new CodeInterpreterToolDefinition() ];
        Assistant assistant = await client.CreateAssistantAsync(
            model: modelDeploymentName,
            name: "my-assistant",
            instructions: "You are helpful assistant.",
            tools: tools
        );
        #endregion

        #region Snippet:AssistantsCreateMessageAttachmentWithBlobStore
        var ds = new VectorStoreDataSource(
            assetIdentifier: blobURI,
            assetType: VectorStoreDataSourceAssetType.UriAsset
        );

        var attachment = new MessageAttachment(
            ds: ds,
            tools: tools
        );
        #endregion
        #region Snippet:AssistantsCodeInterpreterEnterpriseSearchAsync_CreateThreadRun
        AssistantThread thread = await client.CreateThreadAsync();

        ThreadMessage message = await client.CreateMessageAsync(
            threadId: thread.Id,
            role: MessageRole.User,
            content: "What does the attachment say?",
            attachments: [ attachment ]
        );

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
        #region Snippet:AssistantsCodeInterpreterEnterpriseSearchAsync_PrintMessages
        PageableList<ThreadMessage> messages = await client.GetMessagesAsync(
            threadId: thread.Id,
            order: ListSortOrder.Ascending
        );
        WriteMessages(messages);
        #endregion
        #region Snippet:AssistantsCodeInterpreterEnterpriseSearchAsync_Cleanup
        await client.DeleteThreadAsync(thread.Id);
        await client.DeleteAssistantAsync(assistant.Id);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void CodeInterpreterEnterpriseSearchSync()
    {
#if SNIPPET
        var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var blobURI = Environment.GetEnvironmentVariable("AZURE_BLOB_URI");
#else
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        // For now we will take the File URI from the environment variables.
        // In future we may want to upload file to Azure here.
        var blobURI = TestEnvironment.AZURE_BLOB_URI;
#endif
        AssistantsClient client = new(connectionString, new DefaultAzureCredential());
        #region Snippet:AssistantsCodeInterpreterEnterpriseSearch_CreateAgent
        List<ToolDefinition> tools = [new CodeInterpreterToolDefinition()];
        Assistant assistant = client.CreateAssistant(
            model: modelDeploymentName,
            name: "my-assistant",
            instructions: "You are helpful assistant.",
            tools: tools
        );
        #endregion

        var ds = new VectorStoreDataSource(
            assetIdentifier: blobURI,
            assetType: VectorStoreDataSourceAssetType.UriAsset
        );

        var attachment = new MessageAttachment(
            ds: ds,
            tools: tools
        );
        #region Snippet:AssistantsCodeInterpreterEnterpriseSearch_CreateThreadRun
        AssistantThread thread = client.CreateThread();

        ThreadMessage message = client.CreateMessage(
            threadId: thread.Id,
            role: MessageRole.User,
            content: "What does the attachment say?",
            attachments: [attachment]
        );

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
        #region Snippet:AssistantsCodeInterpreterEnterpriseSearch_PrintMessages
        PageableList<ThreadMessage> messages = client.GetMessages(
            threadId: thread.Id,
            order: ListSortOrder.Ascending
        );
        WriteMessages(messages);
        #endregion
        #region Snippet:AssistantsCodeInterpreterEnterpriseSearch_Cleanup
        client.DeleteThread(thread.Id);
        client.DeleteAssistant(assistant.Id);
        #endregion
    }

    #region Snippet:AssistantsCodeInterpreterEnterpriseSearch_Print
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
