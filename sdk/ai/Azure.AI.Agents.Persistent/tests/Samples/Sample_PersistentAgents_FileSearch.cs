// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Agents.Persistent.Tests;

public partial class Sample_PersistentAgents_FileSearch : SamplesBase<AIAgentsTestEnvironment>
{
    [Test]
    [AsyncOnly]
    public async Task FilesSearchExampleAsync()
    {
        #region Snippet:AgentsFilesSearchExample_CreateClient
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());
        #endregion
        #region Snippet:AgentsUploadAgentFilesToUse
        // Upload a file and wait for it to be processed
        System.IO.File.WriteAllText(
            path: "sample_file_for_upload.txt",
            contents: "The word 'apple' uses the code 442345, while the word 'banana' uses the code 673457.");
        PersistentAgentFileInfo uploadedAgentFile = await client.Files.UploadFileAsync(
            filePath: "sample_file_for_upload.txt",
            purpose: PersistentAgentFilePurpose.Agents);
        Dictionary<string, string> fileIds = new()
        {
            { uploadedAgentFile.Id, uploadedAgentFile.Filename }
        };
        #endregion

        #region Snippet:AgentsCreateVectorStore
        // Create a vector store with the file and wait for it to be processed.
        // If you do not specify a vector store, create_message will create a vector store with a default expiration policy of seven days after they were last active
        PersistentAgentsVectorStore vectorStore = await client.VectorStores.CreateVectorStoreAsync(
            fileIds:  new List<string> { uploadedAgentFile.Id },
            name: "my_vector_store");
        #endregion

        #region Snippet:AgentsCreateAgentWithFiles
        FileSearchToolResource fileSearchToolResource = new FileSearchToolResource();
        fileSearchToolResource.VectorStoreIds.Add(vectorStore.Id);

        // Create an agent with toolResources and process agent run
        PersistentAgent agent = await client.Administration.CreateAgentAsync(
                model: modelDeploymentName,
                name: "SDK Test Agent - Retrieval",
                instructions: "You are a helpful agent that can help fetch data from files you know about.",
                tools: new List<ToolDefinition> { new FileSearchToolDefinition() },
                toolResources: new ToolResources() { FileSearch = fileSearchToolResource });
        #endregion

        #region Snippet:AgentsFilesSearchExample_CreateThreadAndRun
        // Create thread for communication
        PersistentAgentThread thread = await client.Threads.CreateThreadAsync();

        // Create message to thread
        PersistentThreadMessage messageResponse = await client.Messages.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "Can you give me the documented codes for 'banana' and 'orange'?");

        // Run the agent
        ThreadRun run = await client.Runs.CreateRunAsync(thread, agent);

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
        WriteMessages(messages, fileIds);
        #endregion
        #region Snippet:AgentsFilesSearchExample_Cleanup
        await client.VectorStores.DeleteVectorStoreAsync(vectorStore.Id);
        await client.Files.DeleteFileAsync(uploadedAgentFile.Id);
        await client.Threads.DeleteThreadAsync(thread.Id);
        await client.Administration.DeleteAgentAsync(agent.Id);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void FilesSearchExample()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());
        #region Snippet:AgentsUploadAgentFilesToUse_Sync
        // Upload a file and wait for it to be processed
        System.IO.File.WriteAllText(
            path: "sample_file_for_upload.txt",
            contents: "The word 'apple' uses the code 442345, while the word 'banana' uses the code 673457.");
        PersistentAgentFileInfo uploadedAgentFile = client.Files.UploadFile(
            filePath: "sample_file_for_upload.txt",
            purpose: PersistentAgentFilePurpose.Agents);
        Dictionary<string, string> fileIds = new()
        {
            { uploadedAgentFile.Id, uploadedAgentFile.Filename }
        };
        #endregion

        #region Snippet:AgentsCreateVectorStore_Sync
        // Create a vector store with the file and wait for it to be processed.
        // If you do not specify a vector store, create_message will create a vector store with a default expiration policy of seven days after they were last active
        PersistentAgentsVectorStore vectorStore = client.VectorStores.CreateVectorStore(
            fileIds: new List<string> { uploadedAgentFile.Id },
            name: "my_vector_store");
        #endregion

        #region Snippet:AgentsCreateAgentWithFiles_Sync
        FileSearchToolResource fileSearchToolResource = new FileSearchToolResource();
        fileSearchToolResource.VectorStoreIds.Add(vectorStore.Id);

        // Create an agent with toolResources and process agent run
        PersistentAgent agent = client.Administration.CreateAgent(
                model: modelDeploymentName,
                name: "SDK Test Agent - Retrieval",
                instructions: "You are a helpful agent that can help fetch data from files you know about.",
                tools: new List<ToolDefinition> { new FileSearchToolDefinition() },
                toolResources: new ToolResources() { FileSearch = fileSearchToolResource });
        #endregion

        #region Snippet:AgentsFilesSearchExample_CreateThreadAndRun_Sync
        // Create thread for communication
        PersistentAgentThread thread = client.Threads.CreateThread();

        // Create message to thread
        PersistentThreadMessage messageResponse = client.Messages.CreateMessage(
            thread.Id,
            MessageRole.User,
            "Can you give me the documented codes for 'banana' and 'orange'?");

        // Run the agent
        ThreadRun run = client.Runs.CreateRun(thread, agent);

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
        WriteMessages(messages, fileIds);
        #endregion
        #region Snippet:AgentsFilesSearchExample_Cleanup_Sync
        client.VectorStores.DeleteVectorStore(vectorStore.Id);
        client.Files.DeleteFile(uploadedAgentFile.Id);
        client.Threads.DeleteThread(thread.Id);
        client.Administration.DeleteAgent(agent.Id);
        #endregion
    }

    #region Snippet:AgentsFilesSearchExample_Print
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
