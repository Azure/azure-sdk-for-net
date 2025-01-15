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

public partial class Sample_Agents_Code_Interpreter_File_Attachment : SamplesBase<AIProjectsTestEnvironment>
{
    private static string GetFile([CallerFilePath] string pth = "")
    {
        var dirName = Path.GetDirectoryName(pth) ?? "";
        return Path.Combine(dirName, "product_info_1.md");
    }

    [Test]
    public async Task CodeInterpreterFileAttachment()
    {
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
        var filePath = GetFile();
        var modelName = TestEnvironment.MODELDEPLOYMENTNAME;

        #region Snippet:CreateAgentWithInterpreterTool
        AgentsClient client = new AgentsClient(connectionString, new DefaultAzureCredential());

        List<ToolDefinition> tools = [ new CodeInterpreterToolDefinition() ];
        Response<Agent> agentResponse = await client.CreateAgentAsync(
            model: modelName,
            name: "my-assistant",
            instructions: "You are helpful assistant.",
            tools: tools
        );
        Agent agent = agentResponse.Value;

        var fileResponse = await client.UploadFileAsync(filePath, AgentFilePurpose.Agents);
        var fileId = fileResponse.Value.Id;

        var attachment = new MessageAttachment(
            fileId: fileId,
            tools: tools
        );

        Response<AgentThread> threadResponse = await client.CreateThreadAsync();
        AgentThread thread = threadResponse.Value;

        Response<ThreadMessage> messageResponse = await client.CreateMessageAsync(
            threadId: thread.Id,
            role: MessageRole.User,
            content: "What does the attachment say?",
            attachments: new List< MessageAttachment > { attachment}
            );
        ThreadMessage message = messageResponse.Value;
        #endregion
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
