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

public partial class Sample_PersistentAgents_Enterprise_File_Search : SamplesBase<AIAgentsTestEnvironment>
{
    [Test]
    [AsyncOnly]
    public async Task EnterpriseFileSearchAsync()
    {
        #region Snippet:AgentsEnterpriseFileSearch_CreateProject
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var blobURI = Environment.GetEnvironmentVariable("AZURE_BLOB_URI");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        // For now we will take the File URI from the environment variables.
        // In future we may want to upload file to Azure here.
        var blobURI = TestEnvironment.AZURE_BLOB_URI;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());
        #endregion
        #region Snippet:AgentsCreateVectorStoreBlob
        var ds = new VectorStoreDataSource(
            assetIdentifier: blobURI,
            assetType: VectorStoreDataSourceAssetType.UriAsset
        );
        PersistentAgentsVectorStore vectorStore = await client.VectorStores.CreateVectorStoreAsync(
            name: "sample_vector_store",
            storeConfiguration: new VectorStoreConfiguration(
                dataSources: [ ds ]
            )
        );

        FileSearchToolResource fileSearchResource = new([vectorStore.Id], null);

        List<ToolDefinition> tools = [new FileSearchToolDefinition()];
        PersistentAgent agent = await client.Administration.CreateAgentAsync(
            model: modelDeploymentName,
            name: "my-agent",
            instructions: "You are helpful agent.",
            tools: tools,
            toolResources: new ToolResources() { FileSearch = fileSearchResource }
        );
        #endregion
        #region Snippet:AgentsEnterpriseFileSearchAsync_CreateThreadMessage
        PersistentAgentThread thread = await client.Threads.CreateThreadAsync();

        PersistentThreadMessage message = await client.Messages.CreateMessageAsync(
            threadId: thread.Id,
            role: MessageRole.User,
            content: "What feature does Smart Eyewear offer?"
            );

        ThreadRun run = await client.Runs.CreateRunAsync(
            thread.Id,
            agent.Id
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
        #endregion
        #region Snippet:AgentsEnterpriseFileSearchAsync_ListUpdatedMessages
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
        #region Snippet:AgentsEnterpriseFileSearchAsync_Cleanup
        bool delTask = await client.VectorStores.DeleteVectorStoreAsync(vectorStore.Id);
        if (delTask)
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
    public void EnterpriseFileSearch()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var blobURI = Environment.GetEnvironmentVariable("AZURE_BLOB_URI");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        // For now we will take the File URI from the environment variables.
        // In future we may want to upload file to Azure here.
        var blobURI = TestEnvironment.AZURE_BLOB_URI;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());
        #region Snippet:AgentsCreateVectorStoreBlobSync
        var ds = new VectorStoreDataSource(
            assetIdentifier: blobURI,
            assetType: VectorStoreDataSourceAssetType.UriAsset
        );
        PersistentAgentsVectorStore vectorStore = client.VectorStores.CreateVectorStore(
            name: "sample_vector_store",
            storeConfiguration: new VectorStoreConfiguration(
                dataSources: [ds]
            )
        );

        FileSearchToolResource fileSearchResource = new([vectorStore.Id], null);

        List<ToolDefinition> tools = [new FileSearchToolDefinition()];
        PersistentAgent agent = client.Administration.CreateAgent(
            model: modelDeploymentName,
            name: "my-agent",
            instructions: "You are helpful agent.",
            tools: tools,
            toolResources: new ToolResources() { FileSearch = fileSearchResource }
        );
        #endregion
        #region Snippet:AgentsEnterpriseFileSearch_CreateThreadMessage
        PersistentAgentThread thread = client.Threads.CreateThread();

        PersistentThreadMessage message = client.Messages.CreateMessage(
            threadId: thread.Id,
            role: MessageRole.User,
            content: "What feature does Smart Eyewear offer?"
        );

        ThreadRun run = client.Runs.CreateRun(
            thread.Id,
            agent.Id
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
        #endregion
        #region Snippet:AgentsEnterpriseFileSearch_ListUpdatedMessages
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
        #region Snippet:AgentsEnterpriseFileSearch_Cleanup
        bool delTask = client.VectorStores.DeleteVectorStore(vectorStore.Id);
        if (delTask)
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

    #region Snippet:AgentsEnterpriseFileSearch_WriteMessages
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
