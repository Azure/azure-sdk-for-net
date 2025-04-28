// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests;

public partial class Sample_Agent_OpenAPI : SamplesBase<AIProjectsTestEnvironment>
{
    #region Snippet:OpenAPICallingExample_GetFile
    private static string GetFile([CallerFilePath] string pth = "")
    {
        var dirName = Path.GetDirectoryName(pth) ?? "";
        return Path.Combine(dirName, "weather_openapi.json");
    }
    #endregion

    [Test]
    [AsyncOnly]
    public async Task OpenAPICallingExampleAsync()
    {
        #region Snippet:OpenAPICallingExample_CreateClient
#if SNIPPET
        var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AgentsClient client = new(connectionString, new DefaultAzureCredential());
        var file_path = GetFile();
        #endregion

        #region Snippet:OpenAPIDefineFunctionTools
        OpenApiAnonymousAuthDetails oaiAuth = new();
        OpenApiToolDefinition openapiTool = new(
            name: "get_weather",
            description: "Retrieve weather information for a location",
            spec: BinaryData.FromBytes(File.ReadAllBytes(file_path)),
            auth: oaiAuth,
            defaultParams: ["format"]
        );

        Agent agent = await client.CreateAgentAsync(
            model: modelDeploymentName,
            name: "azure-function-agent-foo",
            instructions: "You are a helpful assistant.",
            tools: [ openapiTool ]
        );
        #endregion

        #region Snippet:OpenAPIHandlePollingWithRequiredAction
        AgentThread thread = await client.CreateThreadAsync();
        ThreadMessage message = await client.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "What's the weather in Seattle?");

        ThreadRun run = await client.CreateRunAsync(thread, agent);

        do
        {
            await Task.Delay(TimeSpan.FromMilliseconds(500));
            run = await client.GetRunAsync(thread.Id, run.Id);
        }
        while (run.Status == RunStatus.Queued
            || run.Status == RunStatus.InProgress
            || run.Status == RunStatus.RequiresAction);
        Assert.AreEqual(
            RunStatus.Completed,
            run.Status,
            run.LastError?.Message);
        #endregion

        #region Snippet:OpenAPI_Print
        PageableList<ThreadMessage> messages = await client.GetMessagesAsync(
            threadId: thread.Id,
            order: ListSortOrder.Ascending
        );

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
        #endregion
        #region Snippet:OpenAPI_Cleanup
        await client.DeleteThreadAsync(thread.Id);
        await client.DeleteAgentAsync(agent.Id);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void OpenAPICallingExample()
    {
#if SNIPPET
        var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AgentsClient client = new(connectionString, new DefaultAzureCredential());
        var file_path = GetFile();

        #region Snippet:OpenAPISyncDefineFunctionTools
        OpenApiAnonymousAuthDetails oaiAuth = new();
        OpenApiToolDefinition openapiTool = new(
            name: "get_weather",
            description: "Retrieve weather information for a location",
            spec: BinaryData.FromBytes(File.ReadAllBytes(file_path)),
            auth: oaiAuth,
            defaultParams: ["format"]
        );

        Agent agent = client.CreateAgent(
            model: modelDeploymentName,
            name: "azure-function-agent-foo",
            instructions: "You are a helpful assistant.",
            tools: [openapiTool]
        );
        #endregion

        #region Snippet:OpenAPISyncHandlePollingWithRequiredAction
        AgentThread thread = client.CreateThread();
        ThreadMessage message = client.CreateMessage(
            thread.Id,
            MessageRole.User,
            "What's the weather in Seattle?");

        ThreadRun run = client.CreateRun(thread, agent);

        do
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(500));
            run = client.GetRun(thread.Id, run.Id);
        }
        while (run.Status == RunStatus.Queued
            || run.Status == RunStatus.InProgress
            || run.Status == RunStatus.RequiresAction);
        Assert.AreEqual(
            RunStatus.Completed,
            run.Status,
            run.LastError?.Message);
        #endregion

        #region Snippet:OpenAPISync_Print
        PageableList<ThreadMessage> messages = client.GetMessages(
            threadId: thread.Id,
            order: ListSortOrder.Ascending
        );

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
        #endregion
        #region Snippet:OpenAPISync_Cleanup
        client.DeleteThread(thread.Id);
        client.DeleteAgent(agent.Id);
        #endregion
    }
}
