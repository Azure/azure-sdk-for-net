// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Agents.Persistent.Tests;

public partial class Sample_PersistentAgents_Vector_Store_Batch_Enterprise_File_Search : SamplesBase<AIAgentsTestEnvironment>
{
    [Test]
    [AsyncOnly]
    public async Task VectorStoreBatchEnterpriseFileSearch()
    {
        #region Snippet:AgentsVectorStoreBatchEnterpriseFileSearch_CreateClient_Async
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var blobURI = System.Environment.GetEnvironmentVariable("AZURE_BLOB_URI");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelName = TestEnvironment.MODELDEPLOYMENTNAME;
        // For now we will take the File URI from the environment variables.
        // In future we may want to upload file to Azure here.
        var blobURI = TestEnvironment.AZURE_BLOB_URI;
#endif
        PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());
        #endregion
        #region Snippet:AgentsBatchFileAttachment
        var ds = new VectorStoreDataSource(
            assetIdentifier: blobURI,
            assetType: VectorStoreDataSourceAssetType.UriAsset
        );
        PersistentAgentsVectorStore vectorStore = await client.VectorStores.CreateVectorStoreAsync(
            name: "sample_vector_store"
        );

        VectorStoreFileBatch vctFile = await client.VectorStores.CreateVectorStoreFileBatchAsync(
            vectorStoreId: vectorStore.Id,
            dataSources: [ ds ]
        );
        Console.WriteLine($"Created vector store file batch, vector store file batch ID: {vctFile.Id}");

        FileSearchToolResource fileSearchResource = new([vectorStore.Id], null);
        #endregion
        #region  Snippet:AgentsVectorStoreBatchEnterpriseFileSearch_CreateAgentAndThread_Async
        List<ToolDefinition> tools = [new FileSearchToolDefinition()];
        // NOTE: To reuse existing agent, fetch it with client.Administration.GetAgent(agentId)
        PersistentAgent agent = await client.Administration.CreateAgentAsync(
            model: modelName,
            name: "my-agent",
            instructions: "You are helpful agent.",
            tools: tools,
            toolResources: new ToolResources() { FileSearch = fileSearchResource }
        );

        PersistentAgentThread thread = await client.Threads.CreateThreadAsync();

        PersistentThreadMessage message = await client.Messages.CreateMessageAsync(
            threadId: thread.Id,
            role: MessageRole.User,
            content: "What feature does Smart Eyewear offer?"
            );
        #endregion
        #region Snippet:AgentsVectorStoreBatchEnterpriseFileSearch_ThreadRun_Async
        ThreadRun run = await client.Runs.CreateRunAsync(
            thread,
            agent
        );

        do
        {
            await Task.Delay(TimeSpan.FromMilliseconds(500));
            run = await client.Runs.GetRunAsync(thread.Id, run.Id);
        }
        while (run.Status == RunStatus.Queued
            || run.Status == RunStatus.InProgress);
        Assert.AreEqual(
            RunStatus.Completed,
            run.Status,
            run.LastError?.Message);
        List<PersistentThreadMessage> messages = await client.Messages.GetMessagesAsync(
            threadId: thread.Id,
            order: ListSortOrder.Ascending
        ).ToListAsync();
        // Build the map of file IDs to file names.
        Dictionary<string, string> dtFiles = [];
        AsyncPageable<VectorStoreFile> storeFiles = client.VectorStores.GetVectorStoreFilesAsync(
            vectorStoreId: vectorStore.Id
        );
        await foreach (VectorStoreFile fle in storeFiles)
        {
            PersistentAgentFileInfo agentFile = await client.Files.GetFileAsync(fle.Id);
            Uri uriFile = new(agentFile.Filename);
            dtFiles.Add(fle.Id, uriFile.Segments[uriFile.Segments.Length - 1]);
        }
        WriteMessages(messages, dtFiles);
        #endregion
        #region Snippet:AgentsVectorStoreBatchEnterpriseFileSearch_Cleanup_Async
        // NOTE: Comment out this code block if you plan to reuse the agent later.
        bool delStatus = await client.VectorStores.DeleteVectorStoreAsync(vectorStore.Id);
        if (delStatus)
        {
            Console.WriteLine($"Deleted vector store {vectorStore.Id}");
        }
        else
        {
            Console.WriteLine($"Unable to delete vector store {vectorStore.Id}");
        }
        await client.Threads.DeleteThreadAsync(thread.Id);
        await client.Administration.DeleteAgentAsync(agent.Id);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void VectorStoreBatchEnterpriseFileSearchSync()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var blobURI = System.Environment.GetEnvironmentVariable("AZURE_BLOB_URI");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelName = TestEnvironment.MODELDEPLOYMENTNAME;
        // For now we will take the File URI from the environment variables.
        // In future we may want to upload file to Azure here.
        var blobURI = TestEnvironment.AZURE_BLOB_URI;
#endif
        PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());
        #region Snippet:AgentsBatchFileAttachment_Sync
        var ds = new VectorStoreDataSource(
            assetIdentifier: blobURI,
            assetType: VectorStoreDataSourceAssetType.UriAsset
        );
        PersistentAgentsVectorStore vectorStore = client.VectorStores.CreateVectorStore(
            name: "sample_vector_store"
        );

        VectorStoreFileBatch vctFile = client.VectorStores.CreateVectorStoreFileBatch(
            vectorStoreId: vectorStore.Id,
            dataSources: [ds]
        );
        Console.WriteLine($"Created vector store file batch, vector store file batch ID: {vctFile.Id}");

        FileSearchToolResource fileSearchResource = new([vectorStore.Id], null);
        #endregion
        #region  Snippet:AgentsVectorStoreBatchEnterpriseFileSearch_CreateAgentAndThread
        List<ToolDefinition> tools = [new FileSearchToolDefinition()];
        // NOTE: To reuse existing agent, fetch it with client.Administration.GetAgent(agentId)
        PersistentAgent agent = client.Administration.CreateAgent(
            model: modelName,
            name: "my-agent",
            instructions: "You are helpful agent.",
            tools: tools,
            toolResources: new ToolResources() { FileSearch = fileSearchResource }
        );

        PersistentAgentThread thread = client.Threads.CreateThread();

        PersistentThreadMessage message = client.Messages.CreateMessage(
            threadId: thread.Id,
            role: MessageRole.User,
            content: "What feature does Smart Eyewear offer?"
            );
        #endregion
        #region Snippet:AgentsVectorStoreBatchEnterpriseFileSearch_ThreadRun
        ThreadRun run = client.Runs.CreateRun(
            thread,
            agent
        );

        do
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(500));
            run = client.Runs.GetRun(thread.Id, run.Id);
        }
        while (run.Status == RunStatus.Queued
            || run.Status == RunStatus.InProgress);
        Assert.AreEqual(
            RunStatus.Completed,
            run.Status,
            run.LastError?.Message);
        Pageable<PersistentThreadMessage> messages = client.Messages.GetMessages(
            threadId: thread.Id,
            order: ListSortOrder.Ascending
        );
        // Build the map of file IDs to file names.
        Dictionary<string, string> dtFiles = [];
        Pageable<VectorStoreFile> storeFiles = client.VectorStores.GetVectorStoreFiles(
                vectorStoreId: vectorStore.Id
        );
        foreach (VectorStoreFile fle in storeFiles)
        {
            PersistentAgentFileInfo agentFile = client.Files.GetFile(fle.Id);
            Uri uriFile = new(agentFile.Filename);
            dtFiles.Add(fle.Id, uriFile.Segments[uriFile.Segments.Length - 1]);
        }
        WriteMessages(messages, dtFiles);
        #endregion
        #region Snippet:AgentsVectorStoreBatchEnterpriseFileSearch_Cleanup
        // NOTE: Comment out this code block if you plan to reuse the agent later.
        bool delStatus = client.VectorStores.DeleteVectorStore(vectorStore.Id);
        if (delStatus)
        {
            Console.WriteLine($"Deleted vector store {vectorStore.Id}");
        }
        else
        {
            Console.WriteLine($"Unable to delete vector store {vectorStore.Id}");
        }
        client.Threads.DeleteThread(thread.Id);
        client.Administration.DeleteAgent(agent.Id);
        #endregion
    }

    #region Snippet:AgentsVectorStoreBatchEnterpriseFileSearch_Print
    private static void WriteMessages(IEnumerable<PersistentThreadMessage> messages, Dictionary<string, string> fileIds)
    {
        foreach (PersistentThreadMessage threadMessage in messages)
        {
            Console.Write($"{threadMessage.CreatedAt:yyyy-MM-dd HH:mm:ss} - {threadMessage.Role,10}: ");
            foreach (MessageContent contentItem in threadMessage.ContentItems)
            {
                if (contentItem is MessageTextContent textItem)
                {
                    if (threadMessage.Role == MessageRole.Agent && textItem.Annotations.Count > 0)
                    {
                        string strMessage = textItem.Text;
                        foreach (MessageTextAnnotation annotation in textItem.Annotations)
                        {
                            if (annotation is MessageTextFilePathAnnotation pathAnnotation)
                            {
                                strMessage = replaceReferences(fileIds, pathAnnotation.FileId, pathAnnotation.Text, strMessage);
                            }
                            else if (annotation is MessageTextFileCitationAnnotation citationAnnotation)
                            {
                                strMessage = replaceReferences(fileIds, citationAnnotation.FileId, citationAnnotation.Text, strMessage);
                            }
                        }
                        Console.Write(strMessage);
                    }
                    else
                    {
                        Console.Write(textItem.Text);
                    }
                }
                else if (contentItem is MessageImageFileContent imageFileItem)
                {
                    Console.Write($"<image from ID: {imageFileItem.FileId}");
                }
                Console.WriteLine();
            }
        }
    }

    private static string replaceReferences(Dictionary<string, string> fileIds, string fileID, string placeholder, string text)
    {
        if (fileIds.TryGetValue(fileID, out string replacement))
            return text.Replace(placeholder, $" [{replacement}]");
        else
            return text.Replace(placeholder, $" [{fileID}]");
    }
    #endregion
}
