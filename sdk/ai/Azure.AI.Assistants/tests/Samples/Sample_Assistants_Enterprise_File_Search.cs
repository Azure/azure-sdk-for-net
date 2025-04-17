// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Assistants.Tests;

public partial class Sample_Assistants_Enterprise_File_Search : SamplesBase<AIAssistantsTestEnvironment>
{
    [Test]
    [AsyncOnly]
    public async Task EnterpriseFileSearchAsync()
    {
        #region Snippet:AssistantsEnterpriseFileSearch_CreateProject
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
        AssistantsClient client = new(projectEndpoint, new DefaultAzureCredential());
        #endregion
        #region Snippet:AssistantsCreateVectorStoreBlob
        var ds = new VectorStoreDataSource(
            assetIdentifier: blobURI,
            assetType: VectorStoreDataSourceAssetType.UriAsset
        );
        VectorStore vectorStore = await client.CreateVectorStoreAsync(
            name: "sample_vector_store",
            storeConfiguration: new VectorStoreConfiguration(
                dataSources: [ ds ]
            )
        );

        FileSearchToolResource fileSearchResource = new([vectorStore.Id], null);

        List<ToolDefinition> tools = [new FileSearchToolDefinition()];
        Assistant assistant = await client.CreateAssistantAsync(
            model: modelDeploymentName,
            name: "my-assistant",
            instructions: "You are helpful assistant.",
            tools: tools,
            toolResources: new ToolResources() { FileSearch = fileSearchResource }
        );
        #endregion
        #region Snippet:AssistantsEnterpriseFileSearchAsync_CreateThreadMessage
        AssistantThread thread = await client.CreateThreadAsync();

        ThreadMessage message = await client.CreateMessageAsync(
            threadId: thread.Id,
            role: MessageRole.User,
            content: "What feature does Smart Eyewear offer?"
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
        #region Snippet:AssistantsEnterpriseFileSearchAsync_ListUpdatedMessages
        PageableList<ThreadMessage> messages = await client.GetMessagesAsync(
            threadId: thread.Id,
            order: ListSortOrder.Ascending
        );
        // Build the map of file IDs to file names.
        string after = null;
        AssistantPageableListOfVectorStoreFile storeFiles;
        Dictionary<string, string> dtFiles = [];
        do
        {
            storeFiles = await client.GetVectorStoreFilesAsync(
                vectorStoreId: vectorStore.Id,
                after: after
            );
            after = storeFiles.LastId;
            foreach (VectorStoreFile fle in storeFiles.Data)
            {
                AssistantFile assistantFile = await client.GetFileAsync(fle.Id);
                Uri uriFile = new(assistantFile.Filename);
                dtFiles.Add(fle.Id, uriFile.Segments[uriFile.Segments.Length - 1]);
            }
        }
        while (storeFiles.HasMore);
        WriteMessages(messages, dtFiles);
        #endregion
        #region Snippet:AssistantsEnterpriseFileSearchAsync_Cleanup
        VectorStoreDeletionStatus delTask = await client.DeleteVectorStoreAsync(vectorStore.Id);
        if (delTask.Deleted)
        {
            Console.WriteLine($"Deleted vector store {vectorStore.Id}");
        }
        else
        {
            Console.WriteLine($"Unable to delete vector store {vectorStore.Id}");
        }
        await client.DeleteThreadAsync(thread.Id);
        await client.DeleteAssistantAsync(assistant.Id);
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
        AssistantsClient client = new(projectEndpoint, new DefaultAzureCredential());
        #region Snippet:AssistantsCreateVectorStoreBlobSync
        var ds = new VectorStoreDataSource(
            assetIdentifier: blobURI,
            assetType: VectorStoreDataSourceAssetType.UriAsset
        );
        VectorStore vectorStore = client.CreateVectorStore(
            name: "sample_vector_store",
            storeConfiguration: new VectorStoreConfiguration(
                dataSources: [ds]
            )
        );

        FileSearchToolResource fileSearchResource = new([vectorStore.Id], null);

        List<ToolDefinition> tools = [new FileSearchToolDefinition()];
        Assistant assistant = client.CreateAssistant(
            model: modelDeploymentName,
            name: "my-assistant",
            instructions: "You are helpful assistant.",
            tools: tools,
            toolResources: new ToolResources() { FileSearch = fileSearchResource }
        );
        #endregion
        #region Snippet:AssistantsEnterpriseFileSearch_CreateThreadMessage
        AssistantThread thread = client.CreateThread();

        ThreadMessage message = client.CreateMessage(
            threadId: thread.Id,
            role: MessageRole.User,
            content: "What feature does Smart Eyewear offer?"
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
        #region Snippet:AssistantsEnterpriseFileSearch_ListUpdatedMessages
        PageableList<ThreadMessage> messages = client.GetMessages(
            threadId: thread.Id,
            order: ListSortOrder.Ascending
        );
        // Build the map of file IDs to file names.
        string after = null;
        AssistantPageableListOfVectorStoreFile storeFiles;
        Dictionary<string, string> dtFiles = [];
        do
        {
            storeFiles = client.GetVectorStoreFiles(
                vectorStoreId: vectorStore.Id,
                after: after
            );
            after = storeFiles.LastId;
            foreach (VectorStoreFile fle in storeFiles.Data)
            {
                AssistantFile assistantFile = client.GetFile(fle.Id);
                Uri uriFile = new(assistantFile.Filename);
                dtFiles.Add(fle.Id, uriFile.Segments[uriFile.Segments.Length - 1]);
            }
        }
        while (storeFiles.HasMore);
        WriteMessages(messages, dtFiles);
        #endregion
        #region Snippet:AssistantsEnterpriseFileSearch_Cleanup
        VectorStoreDeletionStatus delTask = client.DeleteVectorStore(vectorStore.Id);
        if (delTask.Deleted)
        {
            Console.WriteLine($"Deleted vector store {vectorStore.Id}");
        }
        else
        {
            Console.WriteLine($"Unable to delete vector store {vectorStore.Id}");
        }
        client.DeleteThread(thread.Id);
        client.DeleteAssistant(assistant.Id);
        #endregion
    }

    #region Snippet:AssistantsEnterpriseFileSearch_WriteMessages
    private static void WriteMessages(IEnumerable<ThreadMessage> messages, Dictionary<string, string> fileIds)
    {
        foreach (ThreadMessage threadMessage in messages)
        {
            Console.Write($"{threadMessage.CreatedAt:yyyy-MM-dd HH:mm:ss} - {threadMessage.Role,10}: ");
            foreach (MessageContent contentItem in threadMessage.ContentItems)
            {
                if (contentItem is MessageTextContent textItem)
                {
                    if (threadMessage.Role == MessageRole.Assistant && textItem.Annotations.Count > 0)
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
