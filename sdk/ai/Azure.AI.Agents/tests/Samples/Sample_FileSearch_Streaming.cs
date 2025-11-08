// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI;
using OpenAI.Files;
using OpenAI.Responses;
using OpenAI.VectorStores;

namespace Azure.AI.Agents.Tests.Samples;

public class Sample_FileSearch_Streaming : AgentsTestBase
{
    #region Snippet:Sample_ParseResponse_FileSearch_Streaming
    private static void ParseResponse(StreamingResponseUpdate streamResponse)
    {
        if (streamResponse is StreamingResponseCreatedUpdate createUpdate)
        {
            Console.WriteLine($"Stream response created with ID: {createUpdate.Response.Id}");
        }
        else if (streamResponse is StreamingResponseOutputTextDeltaUpdate textDelta)
        {
            Console.WriteLine($"Delta: {textDelta.Delta}");
        }
        else if (streamResponse is StreamingResponseOutputTextDoneUpdate textDoneUpdate)
        {
            Console.WriteLine($"Response done with full message: {textDoneUpdate.Text}");
        }
        else if (streamResponse is StreamingResponseOutputItemDoneUpdate itemDoneUpdate)
        {
            if (itemDoneUpdate.Item is MessageResponseItem messageItem)
            {
                foreach (ResponseContentPart part in messageItem.Content)
                {
                    foreach (ResponseMessageAnnotation annotation in part.OutputTextAnnotations)
                    {
                        if (annotation is FileCitationMessageAnnotation fileAnnotation)
                        {
                            // Note fileAnnotation.Filename will be available in OpenAI package versions
                            // greater then 2.6.0.
                            Console.WriteLine($"File Citation - File ID: {fileAnnotation.FileId}");
                        }
                    }
                }
            }
        }
        else if (streamResponse is StreamingResponseErrorUpdate errorUpdate)
        {
            throw new InvalidOperationException($"The stream has failed with the error: {errorUpdate.Message}");
        }
    }
    #endregion

    [Test]
    [AsyncOnly]
    public async Task FileSearch_StreamingAsync()
    {
        IgnoreSampleMayBe();
        #region Snippet:Sample_CreateAgentClient_FileSearch_Streaming
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AgentClient client = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        OpenAIClient openAIClient = client.GetOpenAIClient();
        #endregion
        #region Snippet:Sample_UploadFile_FileSearch_Streaming_Async
        string filePath = "sample_file_for_upload.txt";
        File.WriteAllText(
            path: filePath,
            contents: "The word 'apple' uses the code 442345, while the word 'banana' uses the code 673457.");
        OpenAIFileClient fileClient = openAIClient.GetOpenAIFileClient();
        OpenAIFile uploadedFile = await fileClient.UploadFileAsync(filePath: filePath, purpose: FileUploadPurpose.Assistants);
        File.Delete(filePath);
        #endregion
        #region Snippet:Sample_CreateVectorStore_FileSearch_Streaming_Async
        VectorStoreClient vctStoreClient = openAIClient.GetVectorStoreClient();
        VectorStoreCreationOptions options = new()
        {
            Name = "MySampleStore",
            FileIds = { uploadedFile.Id }
        };
        VectorStore vectorStore = await vctStoreClient.CreateVectorStoreAsync(options);
        #endregion
        #region Snippet:Sample_CreateAgent_FileSearch_Streaming_Async
        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a helpful agent that can help fetch data from files you know about.",
            Tools = { ResponseTool.CreateFileSearchTool(vectorStoreIds: [vectorStore.Id]), }
        };
        AgentVersion agentVersion = await client.CreateAgentVersionAsync(
            agentName: "myAgent",
            options: new(agentDefinition)
        );
        #endregion
        #region Snippet:Sample_CreateResponse_FileSearch_Streaming_Async
        OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(modelDeploymentName);
        ResponseCreationOptions responseOptions = new();
        ConversationClient conversationClient = client.GetConversationClient();
        AgentConversation conversation = await conversationClient.CreateConversationAsync();
        responseOptions.SetConversationReference(conversation.Id);
        responseOptions.SetAgentReference(new AgentReference(name: agentVersion.Name));

        ResponseItem request = ResponseItem.CreateUserMessageItem("Can you give me the documented codes for 'banana' and 'orange'?");
        #endregion

        #region Snippet:Sample_StreamingResponse_FileSearch_Streaming_Async
        await foreach (StreamingResponseUpdate streamResponse in responseClient.CreateResponseStreamingAsync([request], responseOptions))
        {
            ParseResponse(streamResponse);
        }
        #endregion
        #region Snippet:Sample_FollowUp_FileSearch_Streaming_Async
        Console.WriteLine("Demonstrating follow-up query with streaming...");
        request = ResponseItem.CreateUserMessageItem("What was my previous question about?");
        await foreach (StreamingResponseUpdate streamResponse in responseClient.CreateResponseStreamingAsync([request], responseOptions))
        {
            ParseResponse(streamResponse);
        }
        #endregion

        #region Snippet:Sample_Cleanup_FileSearch_Streaming_Async
        await client.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        await vctStoreClient.DeleteVectorStoreAsync(vectorStoreId: vectorStore.Id);
        await fileClient.DeleteFileAsync(uploadedFile.Id);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void FileSearch_StreamingSync()
    {
        IgnoreSampleMayBe();
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AgentClient client = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        OpenAIClient openAIClient = client.GetOpenAIClient();
        #region Snippet:Sample_UploadFile_FileSearch_Streaming_Sync
        string filePath = "sample_file_for_upload.txt";
        File.WriteAllText(
            path: filePath,
            contents: "The word 'apple' uses the code 442345, while the word 'banana' uses the code 673457.");
        OpenAIFileClient fileClient = openAIClient.GetOpenAIFileClient();
        OpenAIFile uploadedFile = fileClient.UploadFile(filePath: filePath, purpose: FileUploadPurpose.Assistants);
        File.Delete(filePath);
        #endregion
        #region Snippet:Sample_CreateVectorStore_FileSearch_Streaming_Sync
        VectorStoreClient vctStoreClient = openAIClient.GetVectorStoreClient();
        VectorStoreCreationOptions options = new()
        {
            Name = "MySampleStore",
            FileIds = { uploadedFile.Id }
        };
        VectorStore vectorStore = vctStoreClient.CreateVectorStore(options);
        #endregion
        #region Snippet:Sample_CreateAgent_FileSearch_Streaming_Sync
        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a helpful agent that can help fetch data from files you know about.",
            Tools = { ResponseTool.CreateFileSearchTool(vectorStoreIds: [vectorStore.Id]), }
        };
        AgentVersion agentVersion = client.CreateAgentVersion(
            agentName: "myAgent",
            options: new(agentDefinition)
        );
        #endregion
        #region Snippet:Sample_CreateResponse_FileSearch_Streaming_Sync
        OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(modelDeploymentName);
        ResponseCreationOptions responseOptions = new();
        ConversationClient conversationClient = client.GetConversationClient();
        AgentConversation conversation = conversationClient.CreateConversation();
        responseOptions.SetConversationReference(conversation.Id);
        responseOptions.SetAgentReference(new AgentReference(name: agentVersion.Name));

        ResponseItem request = ResponseItem.CreateUserMessageItem("Can you give me the documented codes for 'banana' and 'orange'?");
        #endregion

        #region Snippet:Sample_StreamingResponse_FileSearch_Streaming_Sync
        foreach (StreamingResponseUpdate streamResponse in responseClient.CreateResponseStreaming([request], responseOptions))
        {
            ParseResponse(streamResponse);
        }
        #endregion
        #region Snippet:Sample_FollowUp_FileSearch_Streaming_Sync
        Console.WriteLine("Demonstrating follow-up query with streaming...");
        request = ResponseItem.CreateUserMessageItem("What was my previous question about?");
        foreach (StreamingResponseUpdate streamResponse in responseClient.CreateResponseStreaming([request], responseOptions))
        {
            ParseResponse(streamResponse);
        }
        #endregion

        #region Snippet:Sample_Cleanup_FileSearch_Streaming_Sync
        client.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        vctStoreClient.DeleteVectorStore(vectorStoreId: vectorStore.Id);
        fileClient.DeleteFile(uploadedFile.Id);
        #endregion
    }

    public Sample_FileSearch_Streaming(bool isAsync) : base(isAsync)
    { }
}
