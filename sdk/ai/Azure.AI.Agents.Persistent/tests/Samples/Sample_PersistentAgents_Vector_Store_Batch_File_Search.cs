// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        PersistentAgentsVectorStore vectorStore = await client.VectorStores.CreateVectorStoreAsync(
            name: "sample_vector_store"
        );

        PersistentAgentFileInfo file = await client.Files.UploadFileAsync(filePath, PersistentAgentFilePurpose.Agents);
        Dictionary<string, string> dtReferences = new()
        {
            {file.Id, Path.GetFileName(file.Filename)}
        };

        VectorStoreFileBatch uploadTask = await client.VectorStores.CreateVectorStoreFileBatchAsync(
            vectorStoreId: vectorStore.Id,
            fileIds: [file.Id]
        );
        Console.WriteLine($"Created vector store file batch, vector store file batch ID: {uploadTask.Id}");

        FileSearchToolResource fileSearchResource = new([vectorStore.Id], null);

        List<ToolDefinition> tools = [new FileSearchToolDefinition()];
        // NOTE: To reuse existing agent, fetch it with client.Administration.GetAgent(agentId)
        PersistentAgent agent = await client.Administration.CreateAgentAsync(
            model: modelName,
            name: "my-agent",
            instructions: "You are helpful agent.",
            tools: tools,
            toolResources: new ToolResources() { FileSearch = fileSearchResource }
        );
        #endregion
        #region Snippet:AgentsVectorStoreBatchFileSearchAsyncThreadAndResponse
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
        List<PersistentThreadMessage> messages = await client.Messages.GetMessagesAsync(
            threadId: thread.Id,
            order: ListSortOrder.Ascending
        ).ToListAsync();
        WriteMessages(messages, dtReferences);
        #endregion

        #region Snippet:AgentsVectorStoreBatchFileSearchAsyncCleanup
        // NOTE: Comment out this code block if you plan to reuse the agent later.
        bool delTask = await client.VectorStores.DeleteVectorStoreAsync(vectorStore.Id);
        if (delTask)
        {
            Console.WriteLine($"Deleted vector store {vectorStore.Id}");
        }
        else
        {
            Console.WriteLine($"Unable to delete vector store {vectorStore.Id}");
        }
        await client.Administration.DeleteAgentAsync(agent.Id);
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

        PersistentAgentsVectorStore vectorStore = client.VectorStores.CreateVectorStore(
            name: "sample_vector_store"
        );

        PersistentAgentFileInfo file = client.Files.UploadFile(filePath, PersistentAgentFilePurpose.Agents);
        Dictionary<string, string> dtReferences = new()
        {
            {file.Id, Path.GetFileName(file.Filename)}
        };

        var uploadTask = client.VectorStores.CreateVectorStoreFileBatch(
            vectorStoreId: vectorStore.Id,
            fileIds: [file.Id]
        );
        Console.WriteLine($"Created vector store file batch, vector store file batch ID: {uploadTask.Value.Id}");

        FileSearchToolResource fileSearchResource = new([vectorStore.Id], null);

        List<ToolDefinition> tools = [new FileSearchToolDefinition()];
        // NOTE: To reuse existing agent, fetch it with client.Administration.GetAgent(agentId)
        PersistentAgent agent = client.Administration.CreateAgent(
            model: modelName,
            name: "my-agent",
            instructions: "You are helpful agent.",
            tools: tools,
            toolResources: new ToolResources() { FileSearch = fileSearchResource }
        );
        #endregion
        #region Snippet:AgentsVectorStoreBatchFileSearchThreadAndResponse
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
            run = client.Runs.GetRun(thread.Id,  run.Id);
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
        WriteMessages(messages, dtReferences);
        #endregion

        #region Snippet:AgentsVectorStoreBatchFileSearchCleanup
        // NOTE: Comment out this code block if you plan to reuse the agent later.
        bool delTask = client.VectorStores.DeleteVectorStore(vectorStore.Id);
        if (delTask)
        {
            Console.WriteLine($"Deleted vector store {vectorStore.Id}");
        }
        else
        {
            Console.WriteLine($"Unable to delete vector store {vectorStore.Id}");
        }
        client.Administration.DeleteAgent(agent.Id);
        #endregion
    }

    #region Snippet:AgentsVectorStoreBatchFileSearchParseResults
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
