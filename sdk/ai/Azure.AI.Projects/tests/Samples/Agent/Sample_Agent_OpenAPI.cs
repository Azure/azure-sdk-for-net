// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests;

public partial class Sample_Agent_OpenAPI : SamplesBase<AIProjectsTestEnvironment>
{
    private static string GetFile([CallerFilePath] string pth = "")
    {
        var dirName = Path.GetDirectoryName(pth) ?? "";
        return Path.Combine(dirName, "weather_openapi.json");
    }

    [Test]
    public async Task OpenAPICallingExample()
    {
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
        var storageQueueUri = TestEnvironment.STORAGE_QUEUE_URI;
        AgentsClient client = new(connectionString, new DefaultAzureCredential());
        var file_path = GetFile();

        #region Snippet:OpenAPIDefineFunctionTools
        OpenApiAnonymousAuthDetails oaiAuth = new();
        OpenApiToolDefinition openapiTool = new(
            name: "get_weather",
            description: "Retrieve weather information for a location",
            spec: BinaryData.FromBytes(File.ReadAllBytes(file_path)),
            auth: oaiAuth
        );

        Response<Agent> agentResponse = await client.CreateAgentAsync(
            model: "gpt-4",
            name: "azure-function-agent-foo",
            instructions: "You are a helpful assistant.",
            tools: new List<ToolDefinition> { openapiTool }
            );
        Agent agent = agentResponse.Value;
        #endregion

        Response<AgentThread> threadResponse = await client.CreateThreadAsync();
        AgentThread thread = threadResponse.Value;

        #region Snippet:OpenAPIHandlePollingWithRequiredAction
        Response<ThreadMessage> messageResponse = await client.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "What's the weather in Seattle?");
        ThreadMessage message = messageResponse.Value;

        Response<ThreadRun> runResponse = await client.CreateRunAsync(thread, agent);

        do
        {
            await Task.Delay(TimeSpan.FromMilliseconds(500));
            runResponse = await client.GetRunAsync(thread.Id, runResponse.Value.Id);
        }
        while (runResponse.Value.Status == RunStatus.Queued
            || runResponse.Value.Status == RunStatus.InProgress
            || runResponse.Value.Status == RunStatus.RequiresAction);
        #endregion

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
