// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using OpenAI.Models;

namespace Azure.AI.Projects.Tests;

public partial class Sample_Agent_FileSearch : SamplesBase<AIProjectsTestEnvironment>
{
    [Test]
    [AsyncOnly]
    public async Task FilesSearchExampleAsync()
    {
        #region Snippet:FilesSearchExample_CreateClient
#if SNIPPET
        var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AgentsClient client = new(connectionString, new DefaultAzureCredential());
        #endregion
        #region Snippet:UploadAgentFilesToUse
        // Upload a file and wait for it to be processed
        File.WriteAllText(
            path: "sample_file_for_upload.txt",
            contents: "The word 'apple' uses the code 442345, while the word 'banana' uses the code 673457.");
        AgentFile uploadedAgentFile = await client.UploadFileAsync(
            filePath: "sample_file_for_upload.txt",
            purpose: AgentFilePurpose.Agents);
        Dictionary<string, string> fileIds = new()
        {
            { uploadedAgentFile.Id, uploadedAgentFile.Filename }
        };
        #endregion

        #region Snippet:CreateVectorStore
        // Create a vector store with the file and wait for it to be processed.
        // If you do not specify a vector store, create_message will create a vector store with a default expiration policy of seven days after they were last active
        VectorStore vectorStore = await client.CreateVectorStoreAsync(
            fileIds:  new List<string> { uploadedAgentFile.Id },
            name: "my_vector_store");
        #endregion

        #region Snippet:CreateAgentWithFiles
        FileSearchToolResource fileSearchToolResource = new FileSearchToolResource();
        fileSearchToolResource.VectorStoreIds.Add(vectorStore.Id);

        // Create an agent with toolResources and process assistant run
        Agent agent = await client.CreateAgentAsync(
                model: modelDeploymentName,
                name: "SDK Test Agent - Retrieval",
                instructions: "You are a helpful agent that can help fetch data from files you know about.",
                tools: new List<ToolDefinition> { new FileSearchToolDefinition() },
                toolResources: new ToolResources() { FileSearch = fileSearchToolResource });
        #endregion

        #region Snippet:FilesSearchExample_CreateThreadAndRun
        // Create thread for communication
        AgentThread thread = await client.CreateThreadAsync();

        // Create message to thread
        ThreadMessage messageResponse = await client.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "Can you give me the documented codes for 'banana' and 'orange'?");

        // Run the agent
        ThreadRun run = await client.CreateRunAsync(thread, agent);

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
        WriteMessages(messages, fileIds);
        #endregion
        #region Snippet:FilesSearchExample_Cleanup
        await client.DeleteVectorStoreAsync(vectorStore.Id);
        await client.DeleteFileAsync(uploadedAgentFile.Id);
        await client.DeleteThreadAsync(thread.Id);
        await client.DeleteAgentAsync(agent.Id);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void FilesSearchExample()
    {
#if SNIPPET
        var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AgentsClient client = new(connectionString, new DefaultAzureCredential());
        #region Snippet:UploadAgentFilesToUse_Sync
        // Upload a file and wait for it to be processed
        File.WriteAllText(
            path: "sample_file_for_upload.txt",
            contents: "The word 'apple' uses the code 442345, while the word 'banana' uses the code 673457.");
        AgentFile uploadedAgentFile = client.UploadFile(
            filePath: "sample_file_for_upload.txt",
            purpose: AgentFilePurpose.Agents);
        Dictionary<string, string> fileIds = new()
        {
            { uploadedAgentFile.Id, uploadedAgentFile.Filename }
        };
        #endregion

        #region Snippet:CreateVectorStore_Sync
        // Create a vector store with the file and wait for it to be processed.
        // If you do not specify a vector store, create_message will create a vector store with a default expiration policy of seven days after they were last active
        VectorStore vectorStore = client.CreateVectorStore(
            fileIds: new List<string> { uploadedAgentFile.Id },
            name: "my_vector_store");
        #endregion

        #region Snippet:CreateAgentWithFiles_Sync
        FileSearchToolResource fileSearchToolResource = new FileSearchToolResource();
        fileSearchToolResource.VectorStoreIds.Add(vectorStore.Id);

        // Create an agent with toolResources and process assistant run
        Agent agent = client.CreateAgent(
                model: modelDeploymentName,
                name: "SDK Test Agent - Retrieval",
                instructions: "You are a helpful agent that can help fetch data from files you know about.",
                tools: new List<ToolDefinition> { new FileSearchToolDefinition() },
                toolResources: new ToolResources() { FileSearch = fileSearchToolResource });
        #endregion

        #region Snippet:FilesSearchExample_CreateThreadAndRun_Sync
        // Create thread for communication
        AgentThread thread = client.CreateThread();

        // Create message to thread
        ThreadMessage messageResponse = client.CreateMessage(
            thread.Id,
            MessageRole.User,
            "Can you give me the documented codes for 'banana' and 'orange'?");

        // Run the agent
        ThreadRun run = client.CreateRun(thread, agent);

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
        PageableList<ThreadMessage> messages = client.GetMessages(
            threadId: thread.Id,
            order: ListSortOrder.Ascending
        );
        WriteMessages(messages, fileIds);
        #endregion
        #region Snippet:FilesSearchExample_Cleanup_Sync
        client.DeleteVectorStore(vectorStore.Id);
        client.DeleteFile(uploadedAgentFile.Id);
        client.DeleteThread(thread.Id);
        client.DeleteAgent(agent.Id);
        #endregion
    }

    #region Snippet:FilesSearchExample_Print
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
