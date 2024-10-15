// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.AI.Client.Models;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.AI.Client.Tests;

public partial class Sample_Agent_FileSearch
{
    [Test]
    public async Task FilesSearchExample()
    {
        Agents client = new AzureAIClient(
            endpoint: new Uri(Environment.GetEnvironmentVariable("AZURE_AI_ENDPOINT")),
            subscriptionId: Environment.GetEnvironmentVariable("AZURE_AI_SUBSCRIPTION_ID"),
            resourceGroupName: Environment.GetEnvironmentVariable("AZURE_AI_RESOURCE_GROUP_NAME"),
            projectName: Environment.GetEnvironmentVariable("AZURE_AI_PROJECT_NAME"),
            credential: new DefaultAzureCredential()).GetAgentsClient();

        #region Snippet:UploadAgentFilesToUse
        // # Upload a file and wait for it to be processed
        File.WriteAllText(
            path: "sample_file_for_upload.txt",
            contents: "The word 'apple' uses the code 442345, while the word 'banana' uses the code 673457.");
        Response<OpenAIFile> uploadAgentFileResponse = await client.UploadFileAsync(
            filePath: "sample_file_for_upload.txt",
            purpose: OpenAIFilePurpose.Agents);

        OpenAIFile uploadedAgentFile = uploadAgentFileResponse.Value;
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

        Response<Agent> agentResponse = await client.CreateAgentAsync(
                model: "gpt-4-1106-preview",
                name: "SDK Test Agent - Retrieval",
                instructions: "You are a helpful agent that can help fetch data from files you know about.",
                tools: new List<ToolDefinition> { new FileSearchToolDefinition() },
                toolResources: new ToolResources() { FileSearch = fileSearchToolResource });
        Agent agent = agentResponse.Value;
        #endregion

        Response<AgentThread> threadResponse = await client.CreateThreadAsync();
        AgentThread thread = threadResponse.Value;

        Response<ThreadMessage> messageResponse = await client.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "Can you give me the documented codes for 'banana' and 'orange'?");
        ThreadMessage message = messageResponse.Value;

        Response<ThreadRun> runResponse = await client.CreateRunAsync(thread, agent);

        do
        {
            await Task.Delay(TimeSpan.FromMilliseconds(500));
            runResponse = await client.GetRunAsync(thread.Id, runResponse.Value.Id);
        }
        while (runResponse.Value.Status == RunStatus.Queued
            || runResponse.Value.Status == RunStatus.InProgress);

        Response<PageableList<ThreadMessage>> afterRunMessagesResponse
            = await client.GetMessagesAsync(thread.Id);
        IReadOnlyList<ThreadMessage> messages = afterRunMessagesResponse.Value.Data;

        // Note: messages iterate from newest to oldest, with the messages[0] being the most recent
        foreach (ThreadMessage threadMessage in messages)
        {
            Console.Write($"{threadMessage.CreatedAt:yyyy-MM-dd HH:mm:ss} - {threadMessage.Role,10}: ");
            foreach (MessageContent contentItem in threadMessage.ContentItems)
            {
                if (contentItem is MessageTextContent textItem)
                {
                    Console.Write(textItem.Text);
                }
                else if (contentItem is MessageImageFileContent imageFileItem)
                {
                    Console.Write($"<image from ID: {imageFileItem.FileId}");
                }
                Console.WriteLine();
            }
        }
    }
}
