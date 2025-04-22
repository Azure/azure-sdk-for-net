// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Agents.Persistent.Custom;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Agents.Persistent.Tests;

public partial class Sample_PersistentAgents_Code_Interpreter_Enterprise_File_Search : SamplesBase<AIAgentsTestEnvironment>
{
    [Test]
    [AsyncOnly]
    public async Task CodeInterpreterEnterpriseSearch()
    {
        #region Snippet:AgentsCodeInterpreterEnterpriseSearch_CreateClient
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var blobURI = Environment.GetEnvironmentVariable("AZURE_BLOB_URI");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        // For now we will take the File URI from the environment variables.
        // In future we may want to upload file to Azure here.
        var blobURI = TestEnvironment.AZURE_BLOB_URI;
#endif
        PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());
        #endregion
        #region Snippet:AgentsCodeInterpreterEnterpriseSearchAsync_CreateAgent
        List<ToolDefinition> tools = [ new CodeInterpreterToolDefinition() ];
        PersistentAgent agent = await client.CreateAgentAsync(
            model: modelDeploymentName,
            name: "my-agent",
            instructions: "You are helpful agent.",
            tools: tools
        );
        #endregion

        #region Snippet:AgentsCreateMessageAttachmentWithBlobStore
        var ds = new VectorStoreDataSource(
            assetIdentifier: blobURI,
            assetType: VectorStoreDataSourceAssetType.UriAsset
        );

        var attachment = new MessageAttachment(
            ds: ds,
            tools: tools
        );
        #endregion
        #region Snippet:AgentsCodeInterpreterEnterpriseSearchAsync_CreateThreadRun
        PersistentAgentThread thread = await client.CreateThreadAsync();

        ThreadMessage message = await client.CreateMessageAsync(
            threadId: thread.Id,
            role: MessageRole.User,
            content: "What does the attachment say?",
            attachments: [ attachment ]
        );

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
        #region Snippet:AgentsCodeInterpreterEnterpriseSearchAsync_PrintMessages
        PageableList<ThreadMessage> messages = await client.GetMessagesAsync(
            threadId: thread.Id,
            order: ListSortOrder.Ascending
        );
        WriteMessages(messages);
        #endregion
        #region Snippet:AgentsCodeInterpreterEnterpriseSearchAsync_Cleanup
        await client.DeleteThreadAsync(thread.Id);
        await client.DeleteAgentAsync(agent.Id);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void CodeInterpreterEnterpriseSearchSync()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var blobURI = Environment.GetEnvironmentVariable("AZURE_BLOB_URI");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        // For now we will take the File URI from the environment variables.
        // In future we may want to upload file to Azure here.
        var blobURI = TestEnvironment.AZURE_BLOB_URI;
#endif
        PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());
        #region Snippet:AgentsCodeInterpreterEnterpriseSearch_CreateAgent
        List<ToolDefinition> tools = [new CodeInterpreterToolDefinition()];
        PersistentAgent agent = client.CreateAgent(
            model: modelDeploymentName,
            name: "my-agent",
            instructions: "You are helpful agent.",
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
        #region Snippet:AgentsCodeInterpreterEnterpriseSearch_CreateThreadRun
        PersistentAgentThread thread = client.CreateThread();

        ThreadMessage message = client.CreateMessage(
            threadId: thread.Id,
            role: MessageRole.User,
            content: "What does the attachment say?",
            attachments: [attachment]
        );

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
        #region Snippet:AgentsCodeInterpreterEnterpriseSearch_PrintMessages
        PageableList<ThreadMessage> messages = client.GetMessages(
            threadId: thread.Id,
            order: ListSortOrder.Ascending
        );
        WriteMessages(messages);
        #endregion
        #region Snippet:AgentsCodeInterpreterEnterpriseSearch_Cleanup
        client.DeleteThread(thread.Id);
        client.DeleteAgent(agent.Id);
        #endregion
    }

    #region Snippet:AgentsCodeInterpreterEnterpriseSearch_Print
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
