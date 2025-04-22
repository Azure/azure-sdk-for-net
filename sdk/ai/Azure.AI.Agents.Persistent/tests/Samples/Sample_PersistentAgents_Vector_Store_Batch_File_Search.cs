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

public partial class Sample_PersistentAgents_Vector_Store_Batch_File_Search : SamplesBase<AIAgentsTestEnvironment>
{
    private static string GetFile([CallerFilePath] string pth = "")
    {
        var dirName = Path.GetDirectoryName(pth) ?? "";
        return Path.Combine(dirName, "product_info_1.md");
    }

    [Test]
    [AsyncOnly]
    public async Task VectorStoreBatchFileSearchAsync()
    {
        #region Snippet:AgentsVectorStoreBatchFileAsyncSearchCreateVectorStore
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        var filePath = GetFile();
        PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());

        VectorStore vectorStore = await client.CreateVectorStoreAsync(
            name: "sample_vector_store"
        );

        PersistentAgentFile file = await client.UploadFileAsync(filePath, PersistentAgentFilePurpose.Agents);
        Dictionary<string, string> dtReferences = new()
        {
            {file.Id, Path.GetFileName(file.Filename)}
        };

        VectorStoreFileBatch uploadTask = await client.CreateVectorStoreFileBatchAsync(
            vectorStoreId: vectorStore.Id,
            fileIds: [file.Id]
        );
        Console.WriteLine($"Created vector store file batch, vector store file batch ID: {uploadTask.Id}");

        FileSearchToolResource fileSearchResource = new([vectorStore.Id], null);

        List<ToolDefinition> tools = [new FileSearchToolDefinition()];
        PersistentAgent agent = await client.CreateAgentAsync(
            model: modelName,
            name: "my-agent",
            instructions: "You are helpful agent.",
            tools: tools,
            toolResources: new ToolResources() { FileSearch = fileSearchResource }
        );
        #endregion
        #region Snippet:AgentsVectorStoreBatchFileSearchAsyncThreadAndResponse
        PersistentAgentThread thread = await client.CreateThreadAsync();

        ThreadMessage message = await client.CreateMessageAsync(
            threadId: thread.Id,
            role: MessageRole.User,
            content: "What feature does Smart Eyewear offer?"
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
        PageableList<ThreadMessage> messages = await client.GetMessagesAsync(
            threadId: thread.Id,
            order: ListSortOrder.Ascending
        );
        WriteMessages(messages, dtReferences);
        #endregion

        #region Snippet:AgentsVectorStoreBatchFileSearchAsyncCleanup
        VectorStoreDeletionStatus delTask = await client.DeleteVectorStoreAsync(vectorStore.Id);
        if (delTask.Deleted)
        {
            Console.WriteLine($"Deleted vector store {vectorStore.Id}");
        }
        else
        {
            Console.WriteLine($"Unable to delete vector store {vectorStore.Id}");
        }
        await client.DeleteAgentAsync(agent.Id);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void VectorStoreBatchFileSearch()
    {
        #region Snippet:AgentsVectorStoreBatchFileSearchCreateVectorStore
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        var filePath = GetFile();
        PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());

        VectorStore vectorStore = client.CreateVectorStore(
            name: "sample_vector_store"
        );

        PersistentAgentFile file = client.UploadFile(filePath, PersistentAgentFilePurpose.Agents);
        Dictionary<string, string> dtReferences = new()
        {
            {file.Id, Path.GetFileName(file.Filename)}
        };

        var uploadTask = client.CreateVectorStoreFileBatch(
            vectorStoreId: vectorStore.Id,
            fileIds: [file.Id]
        );
        Console.WriteLine($"Created vector store file batch, vector store file batch ID: {uploadTask.Value.Id}");

        FileSearchToolResource fileSearchResource = new([vectorStore.Id], null);

        List<ToolDefinition> tools = [new FileSearchToolDefinition()];
        PersistentAgent agent = client.CreateAgent(
            model: modelName,
            name: "my-agent",
            instructions: "You are helpful agent.",
            tools: tools,
            toolResources: new ToolResources() { FileSearch = fileSearchResource }
        );
        #endregion
        #region Snippet:AgentsVectorStoreBatchFileSearchThreadAndResponse
        PersistentAgentThread thread = client.CreateThread();

        ThreadMessage message = client.CreateMessage(
            threadId: thread.Id,
            role: MessageRole.User,
            content: "What feature does Smart Eyewear offer?"
            );

        ThreadRun run = client.CreateRun(
            thread.Id,
            agent.Id
        );

        do
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(500));
            run = client.GetRun(thread.Id,  run.Id);
        }
        while (run.Status == RunStatus.Queued
            || run.Status == RunStatus.InProgress);

        Assert.AreEqual(
            RunStatus.Completed,
            run.Status,
            run.LastError?.Message);
        PageableList<ThreadMessage> messages = client.GetMessages(
            threadId: thread.Id,
            order: ListSortOrder.Ascending
        );
        WriteMessages(messages, dtReferences);
        #endregion

        #region Snippet:AgentsVectorStoreBatchFileSearchCleanup
        VectorStoreDeletionStatus delTask = client.DeleteVectorStore(vectorStore.Id);
        if (delTask.Deleted)
        {
            Console.WriteLine($"Deleted vector store {vectorStore.Id}");
        }
        else
        {
            Console.WriteLine($"Unable to delete vector store {vectorStore.Id}");
        }
        client.DeleteAgent(agent.Id);
        #endregion
    }

    #region Snippet:AgentsVectorStoreBatchFileSearchParseResults
    private static void WriteMessages(IEnumerable<ThreadMessage> messages, Dictionary<string, string> fileIds)
    {
        foreach (ThreadMessage threadMessage in messages)
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
