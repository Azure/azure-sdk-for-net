// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI;
using OpenAI.Files;
using OpenAI.Responses;
using OpenAI.VectorStores;

namespace Azure.AI.Agents.Tests.Samples;

public class Sample_FileSearch : AgentsTestBase
{
    [Test]
    [AsyncOnly]
    public async Task FileSearchAsync()
    {
        IgnoreSampleMayBe();
        #region Snippet:Sample_CreateAgentClient_FileSearch
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AgentsClient client = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        OpenAIClient openAIClient = client.GetOpenAIClient();
        #endregion
        #region Snippet:Sample_UploadFile_FileSearch_Async
        string filePath = "sample_file_for_upload.txt";
        File.WriteAllText(
            path: filePath,
            contents: "The word 'apple' uses the code 442345, while the word 'banana' uses the code 673457.");
        OpenAIFileClient fileClient = openAIClient.GetOpenAIFileClient();
        OpenAIFile uploadedFile = await fileClient.UploadFileAsync(filePath: filePath, purpose: FileUploadPurpose.Assistants);
        File.Delete(filePath);
        #endregion
        #region Snippet:Sample_CreateVectorStore_FileSearch_Async
        VectorStoreClient vctStoreClient = openAIClient.GetVectorStoreClient();
        VectorStoreCreationOptions options = new()
        {
            Name = "MySampleStore",
            FileIds = { uploadedFile.Id }
        };
        VectorStore vectorStore = await vctStoreClient.CreateVectorStoreAsync(options);
        #endregion
        #region Snippet:Sample_CreateAgent_FileSearch_Async
        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a helpful agent that can help fetch data from files you know about.",
            Tools = { ResponseTool.CreateFileSearchTool(vectorStoreIds: [vectorStore.Id]), }
        };
        AgentVersion agentVersion = await client.CreateAgentVersionAsync(
            agentName: "myAgent",
            definition: agentDefinition,
            options: null);
        #endregion
        #region Snippet:Sample_CreateResponse_FileSearch_Async
        OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(modelDeploymentName);
        ResponseCreationOptions responseOptions = new();
        responseOptions.SetAgentReference(new AgentReference(name: agentVersion.Name));

        ResponseItem request = ResponseItem.CreateUserMessageItem("Can you give me the documented codes for 'banana' and 'orange'?");
        OpenAIResponse response = await responseClient.CreateResponseAsync(
            [request],
            responseOptions);
        #endregion

        #region Snippet:Sample_WaitForResponse_FileSearch_Async
        List<ResponseItem> updateItems = [request];
        while (response.Status != ResponseStatus.Incomplete && response.Status != ResponseStatus.Failed && response.Status != ResponseStatus.Completed)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(500));
            response = await responseClient.GetResponseAsync(responseId: response.Id);
        }
        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
        Console.WriteLine(response.GetOutputText());
        #endregion

        #region Snippet:Sample_Cleanup_FileSearch_Async
        await client.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        await vctStoreClient.DeleteVectorStoreAsync(vectorStoreId: vectorStore.Id);
        await fileClient.DeleteFileAsync(uploadedFile.Id);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void FileSearchSync()
    {
        IgnoreSampleMayBe();
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AgentsClient client = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        OpenAIClient openAIClient = client.GetOpenAIClient();

        #region Snippet:Sample_UploadFile_FileSearch_Sync
        string filePath = "sample_file_for_upload.txt";
        File.WriteAllText(
            path: filePath,
            contents: "The word 'apple' uses the code 442345, while the word 'banana' uses the code 673457.");
        OpenAIFileClient fileClient = openAIClient.GetOpenAIFileClient();
        OpenAIFile uploadedFile = fileClient.UploadFile(filePath: filePath, purpose: FileUploadPurpose.Assistants);
        File.Delete(filePath);
        #endregion
        #region Snippet:Sample_CreateVectorStore_FileSearch_Sync
        VectorStoreClient vctStoreClient = openAIClient.GetVectorStoreClient();
        VectorStoreCreationOptions options = new()
        {
            Name = "MySampleStore",
            FileIds = { uploadedFile.Id }
        };
        VectorStore vectorStore = vctStoreClient.CreateVectorStore(options: options);
        #endregion
        #region Snippet:Sample_CreateAgent_FileSearch_Sync
        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a helpful agent that can help fetch data from files you know about.",
            Tools = { ResponseTool.CreateFileSearchTool(vectorStoreIds: [vectorStore.Id]), }
        };
        AgentVersion agentVersion = client.CreateAgentVersion(
            agentName: "myAgent",
            definition: agentDefinition,
            options: null);
        #endregion
        #region Snippet:Sample_CreateResponse_FileSearch_Sync
        OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(modelDeploymentName);
        ResponseCreationOptions responseOptions = new();
        responseOptions.SetAgentReference(new AgentReference(name: agentVersion.Name));

        ResponseItem request = ResponseItem.CreateUserMessageItem("Can you give me the documented codes for 'banana' and 'orange'?");
        OpenAIResponse response = responseClient.CreateResponse(
            [request],
            responseOptions);
        #endregion

        #region Snippet:Sample_WaitForResponse_FileSearch_Sync
        List<ResponseItem> updateItems = [request];
        while (response.Status != ResponseStatus.Incomplete && response.Status != ResponseStatus.Failed && response.Status != ResponseStatus.Completed)
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(500));
            response = responseClient.GetResponse(responseId: response.Id);
        }
        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
        Console.WriteLine(response.GetOutputText());
        #endregion

        #region Snippet:Sample_Cleanup_FileSearch_Sync
        client.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        vctStoreClient.DeleteVectorStore(vectorStoreId: vectorStore.Id);
        fileClient.DeleteFile(uploadedFile.Id);
        #endregion
    }

    public Sample_FileSearch(bool isAsync) : base(isAsync)
    { }
}
