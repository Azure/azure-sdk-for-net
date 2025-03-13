// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests;

public partial class Sample_Agents_Code_Interpreter_Enterprise_File_Search: SamplesBase<AIProjectsTestEnvironment>
{
    [Test]
    public async Task CodeInterpreterEnterpriseSearch()
    {
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
        // For now we will take the File URI from the environment variables.
        // In future we may want to upload file to Azure here.
        var blobURI = TestEnvironment.AZURE_BLOB_URI;
        var modelName = TestEnvironment.MODELDEPLOYMENTNAME;
        AgentsClient client = new AgentsClient(connectionString, new DefaultAzureCredential());

        List<ToolDefinition> tools = [ new CodeInterpreterToolDefinition() ];
        Response<Agent> agentResponse = await client.CreateAgentAsync(
            model: modelName,
            name: "my-assistant",
            instructions: "You are helpful assistant.",
            tools: tools
        );
        Agent agent = agentResponse.Value;

        #region Snippet:CreateMessageAttachmentWithBlobStore
        var ds = new VectorStoreDataSource(
            assetIdentifier: blobURI,
            assetType: VectorStoreDataSourceAssetType.UriAsset
        );

        var attachment = new MessageAttachment(
            ds: ds,
            tools: tools
        );
        #endregion

        Response<AgentThread> threadResponse = await client.CreateThreadAsync();
        AgentThread thread = threadResponse.Value;

        Response<ThreadMessage> messageResponse = await client.CreateMessageAsync(
            threadId: thread.Id,
            role: MessageRole.User,
            content: "What does the attachment say?",
            attachments: new List< MessageAttachment > { attachment}
            );
        ThreadMessage message = messageResponse.Value;

        Response<ThreadRun> runResponse = await client.CreateRunAsync(
            thread.Id,
            agent.Id
        );
        ThreadRun run = runResponse.Value;

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
        WriteMessages(messages);

        await client.DeleteAgentAsync(agentResponse.Value.Id);
    }

    private void WriteMessages(IEnumerable<ThreadMessage> messages)
    {
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
