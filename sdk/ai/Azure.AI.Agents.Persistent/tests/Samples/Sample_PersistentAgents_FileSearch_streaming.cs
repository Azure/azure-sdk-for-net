// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Agents.Persistent.Tests;

public partial class Sample_PersistentAgents_FileSearch_Streaming : SamplesBase<AIAgentsTestEnvironment>
{
    [Test]
    [AsyncOnly]
    public async Task FilesSearchStreamingExampleAsync()
    {
        #region Snippet:AgentsFilesSearchStreamingExample_CreateClient
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());
        #endregion
        #region Snippet:AgentsUploadAgentFilesToUseStreaming
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

        #region Snippet:AgentsCreateVectorStoreStreaming
        // Create a vector store with the file and wait for it to be processed.
        // If you do not specify a vector store, create_message will create a vector store with a default expiration policy of seven days after they were last active
        PersistentAgentsVectorStore vectorStore = await client.VectorStores.CreateVectorStoreAsync(
            fileIds:  new List<string> { uploadedAgentFile.Id },
            name: "my_vector_store");
        #endregion

        #region Snippet:AgentsCreateAgentWithFilesStreaming
        FileSearchToolResource fileSearchToolResource = new FileSearchToolResource();
        fileSearchToolResource.VectorStoreIds.Add(vectorStore.Id);

        // Create an agent with toolResources and process agent run
        // NOTE: To reuse existing agent, fetch it with client.Administration.GetAgent(agentId)
        PersistentAgent agent = await client.Administration.CreateAgentAsync(
                model: modelDeploymentName,
                name: "SDK Test Agent - Retrieval",
                instructions: "You are a helpful agent that can help fetch data from files you know about.",
                tools: new List<ToolDefinition> { new FileSearchToolDefinition() },
                toolResources: new ToolResources() { FileSearch = fileSearchToolResource });
        #endregion

        #region Snippet:AgentsFilesSearchExampleStreaming_CreateThreadMessage
        // Create thread for communication
        PersistentAgentThread thread = await client.Threads.CreateThreadAsync();

        // Create message to thread
        PersistentThreadMessage messageResponse = await client.Messages.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "Can you give me the documented codes for 'banana' and 'orange'?");

        #endregion
        #region Snippet:AgentsFilesSearchExampleStreaming_StreamResults
        // Create the stream and parse output.
        CreateRunStreamingOptions runOptions = new()
        {
            Include = [RunAdditionalFieldList.FileSearchContents]
        };
        AsyncCollectionResult<StreamingUpdate> stream = client.Runs.CreateRunStreamingAsync(thread.Id, agent.Id, options: runOptions);
        await foreach (StreamingUpdate streamingUpdate in stream)
        {
            ParseStreamingUdate(streamingUpdate, fileIds);
        }
        #endregion

        #region Snippet:AgentsFilesSearchExampleSteaming_Cleanup
        // NOTE: Comment out these four lines if you plan to reuse the agent later.
        await client.VectorStores.DeleteVectorStoreAsync(vectorStore.Id);
        await client.Files.DeleteFileAsync(uploadedAgentFile.Id);
        await client.Threads.DeleteThreadAsync(thread.Id);
        await client.Administration.DeleteAgentAsync(agent.Id);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void FilesSearchStreamingExample()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());
        #region Snippet:AgentsUploadAgentFilesToUseStreaming_Sync
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

        #region Snippet:AgentsCreateVectorStoreStreaming_Sync
        // Create a vector store with the file and wait for it to be processed.
        // If you do not specify a vector store, create_message will create a vector store with a default expiration policy of seven days after they were last active
        PersistentAgentsVectorStore vectorStore = client.VectorStores.CreateVectorStore(
            fileIds: new List<string> { uploadedAgentFile.Id },
            name: "my_vector_store");
        #endregion

        #region Snippet:AgentsCreateAgentWithFilesStreaming_Sync
        FileSearchToolResource fileSearchToolResource = new FileSearchToolResource();
        fileSearchToolResource.VectorStoreIds.Add(vectorStore.Id);

        // Create an agent with toolResources and process agent run
        // NOTE: To reuse existing agent, fetch it with client.Administration.GetAgent(agentId)
        PersistentAgent agent = client.Administration.CreateAgent(
                model: modelDeploymentName,
                name: "SDK Test Agent - Retrieval",
                instructions: "You are a helpful agent that can help fetch data from files you know about.",
                tools: new List<ToolDefinition> { new FileSearchToolDefinition() },
                toolResources: new ToolResources() { FileSearch = fileSearchToolResource });
        #endregion

        #region Snippet:AgentsFilesSearchExampleStreaming_CreateThreadMessage_Sync
        // Create thread for communication
        PersistentAgentThread thread = client.Threads.CreateThread();

        // Create message to thread
        PersistentThreadMessage messageResponse = client.Messages.CreateMessage(
            thread.Id,
            MessageRole.User,
            "Can you give me the documented codes for 'banana' and 'orange'?");
        #endregion
        #region Snippet:AgentsFilesSearchExampleStreaming_StreamResults_Sync
        // Create the stream and parse output
        CreateRunStreamingOptions runOptions = new()
        {
            Include = [RunAdditionalFieldList.FileSearchContents]
        };
        CollectionResult<StreamingUpdate> stream = client.Runs.CreateRunStreaming(thread.Id, agent.Id, options: runOptions);
        foreach (StreamingUpdate streamingUpdate in stream)
        {
            ParseStreamingUdate(streamingUpdate, fileIds);
        }
        #endregion
        #region Snippet:AgentsFilesSearchExampleSteaming_Cleanup_Sync
        // NOTE: Comment out these four lines if you plan to reuse the agent later.
        client.VectorStores.DeleteVectorStore(vectorStore.Id);
        client.Files.DeleteFile(uploadedAgentFile.Id);
        client.Threads.DeleteThread(thread.Id);
        client.Administration.DeleteAgent(agent.Id);
        #endregion
    }

    #region Snippet:AgentsFilesSearchExampleStreaming_Print
    private static void ParseStreamingUdate(StreamingUpdate streamingUpdate, Dictionary<string, string> fileIds)
    {
        if (streamingUpdate.UpdateKind == StreamingUpdateReason.RunCreated)
        {
            Console.WriteLine("--- Run started! ---");
        }
        else if (streamingUpdate is MessageContentUpdate contentUpdate)
        {
            if (contentUpdate.TextAnnotation != null)
            {
                if (fileIds.TryGetValue(contentUpdate.TextAnnotation.InputFileId, out string annotation))
                {
                    Console.Write($" [see {annotation}]");
                }
                else
                {
                    Console.Write($" [see {contentUpdate.TextAnnotation.InputFileId}]");
                }
            }
            else
            {
                //Detect the reference placeholder and skip it. Instead we will print the actual reference.
                if (contentUpdate.Text[0] != (char)12304 || contentUpdate.Text[contentUpdate.Text.Length - 1] != (char)12305)
                    Console.Write(contentUpdate.Text);
            }
        }
        else if (streamingUpdate.UpdateKind == StreamingUpdateReason.RunStepCompleted)
        {
            if (streamingUpdate is RunStepUpdate runStep)
            {
                if (runStep.Value.StepDetails is RunStepToolCallDetails toolCallDetails)
                {
                    foreach (RunStepToolCall toolCall in toolCallDetails.ToolCalls)
                    {
                        if (toolCall is RunStepFileSearchToolCall fileSearh)
                        {
                            Console.WriteLine($"The search tool has found the next relevant content in the file {fileSearh.FileSearch.Results[0].FileName}:");
                            Console.WriteLine(fileSearh.FileSearch.Results[0].Content[0].Text);
                            Console.WriteLine("===============================================================");
                        }
                    }
                }
            }
        }
        else if (streamingUpdate.UpdateKind == StreamingUpdateReason.RunCompleted)
        {
            Console.WriteLine();
            Console.WriteLine("--- Run completed! ---");
        }
        else if (streamingUpdate.UpdateKind == StreamingUpdateReason.Error && streamingUpdate is RunUpdate errorStep)
        {
            throw new InvalidOperationException($"Error: {errorStep.Value.LastError}");
        }
    }
    #endregion
}
