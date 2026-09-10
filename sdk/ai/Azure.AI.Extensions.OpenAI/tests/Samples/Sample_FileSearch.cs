// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.AI.Projects;
using Azure.AI.Projects.Agents;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Files;
using OpenAI.Responses;
using OpenAI.VectorStores;

namespace Azure.AI.Extensions.OpenAI.Tests.Samples;

public class Sample_FileSearch : ProjectsOpenAITestBase
{
    [Test]
    [AsyncOnly]
    public async Task FileSearchAsync()
    {
        IgnoreSampleMayBe();
        #region Snippet:Sample_CreateAgentClient_FileSearch
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());

        #endregion
        #region Snippet:Sample_UploadFile_FileSearch_Async
        string filePath = "sample_file_for_upload.txt";
        File.WriteAllText(
            path: filePath,
            contents: "The word 'apple' uses the code 442345, while the word 'banana' uses the code 673457.");
        OpenAIFileClient fileClient = projectClient.ProjectOpenAIClient.GetOpenAIFileClient();
        OpenAIFile uploadedFile = await fileClient.UploadFileAsync(filePath: filePath, purpose: FileUploadPurpose.Assistants);
        File.Delete(filePath);
        #endregion
        #region Snippet:Sample_CreateVectorStore_FileSearch_Async
        VectorStoreClient vctStoreClient = projectClient.ProjectOpenAIClient.GetVectorStoreClient();
        VectorStoreCreationOptions options = new()
        {
            Name = "MySampleStore",
            FileIds = { uploadedFile.Id }
        };
        VectorStore vectorStore = await vctStoreClient.CreateVectorStoreAsync(options);
        #endregion
        #region Snippet:Sample_CreateAgent_FileSearch_Async
        DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a helpful agent that can help fetch data from files you know about.",
            Tools = { ResponseTool.CreateFileSearchTool(vectorStoreIds: [vectorStore.Id]), }
        };
        ProjectsAgentVersion agentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
            agentName: "myAgent",
            options: new(agentDefinition));
        #endregion
        #region Snippet:Sample_CreateResponse_FileSearch_Async
        ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(agentVersion.Name);

        ResponseResult response = await responseClient.CreateResponseAsync("Can you give me the documented codes for 'banana' and 'orange'?");
        #endregion

        #region Snippet:Sample_WaitForResponse_FileSearch_Async
        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
        Console.WriteLine(response.GetOutputText());
        #endregion

        #region Snippet:Sample_Cleanup_FileSearch_Async
        await projectClient.AgentAdministrationClient.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
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
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());

        #region Snippet:Sample_UploadFile_FileSearch_Sync
        string filePath = "sample_file_for_upload.txt";
        File.WriteAllText(
            path: filePath,
            contents: "The word 'apple' uses the code 442345, while the word 'banana' uses the code 673457.");
        OpenAIFileClient fileClient = projectClient.ProjectOpenAIClient.GetOpenAIFileClient();
        OpenAIFile uploadedFile = fileClient.UploadFile(filePath: filePath, purpose: FileUploadPurpose.Assistants);
        File.Delete(filePath);
        #endregion
        #region Snippet:Sample_CreateVectorStore_FileSearch_Sync
        VectorStoreClient vctStoreClient = projectClient.ProjectOpenAIClient.GetVectorStoreClient();
        VectorStoreCreationOptions options = new()
        {
            Name = "MySampleStore",
            FileIds = { uploadedFile.Id }
        };
        VectorStore vectorStore = vctStoreClient.CreateVectorStore(options: options);
        #endregion
        #region Snippet:Sample_CreateAgent_FileSearch_Sync
        DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a helpful agent that can help fetch data from files you know about.",
            Tools = { ResponseTool.CreateFileSearchTool(vectorStoreIds: [vectorStore.Id]), }
        };
        ProjectsAgentVersion agentVersion = projectClient.AgentAdministrationClient.CreateAgentVersion(
            agentName: "myAgent",
            options: new(agentDefinition));
        #endregion
        #region Snippet:Sample_CreateResponse_FileSearch_Sync
        ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(agentVersion.Name);

        ResponseResult response = responseClient.CreateResponse("Can you give me the documented codes for 'banana' and 'orange'?");
        #endregion

        #region Snippet:Sample_WaitForResponse_FileSearch_Sync
        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
        Console.WriteLine(response.GetOutputText());
        #endregion

        #region Snippet:Sample_Cleanup_FileSearch_Sync
        projectClient.AgentAdministrationClient.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        vctStoreClient.DeleteVectorStore(vectorStoreId: vectorStore.Id);
        fileClient.DeleteFile(uploadedFile.Id);
        #endregion
    }

    public Sample_FileSearch(bool isAsync) : base(isAsync)
    { }
}
