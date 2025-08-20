// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Agents.Persistent.Tests;

public partial class Sample_PersistentAgents_OpenAPI : SamplesBase<AIAgentsTestEnvironment>
{
    #region Snippet:AgentsOpenAPICallingExample_GetFile
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
        #region Snippet:AgentsOpenAPICallingExample_CreateClient
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());
        var file_path = GetFile();
        #endregion

        #region Snippet:AgentsOpenAPIDefineFunctionTools
        OpenApiAnonymousAuthDetails oaiAuth = new();
        OpenApiToolDefinition openapiTool = new(
            name: "get_weather",
            description: "Retrieve weather information for a location",
            spec: BinaryData.FromBytes(System.IO.File.ReadAllBytes(file_path)),
            openApiAuthentication: oaiAuth,
            defaultParams: [ "format" ]
        );

        PersistentAgent agent = await client.Administration.CreateAgentAsync(
            model: modelDeploymentName,
            name: "azure-function-agent-foo",
            instructions: "You are a helpful agent.",
            tools: [ openapiTool ]
        );
        #endregion

        #region Snippet:AgentsOpenAPIHandlePollingWithRequiredAction
        PersistentAgentThread thread = await client.Threads.CreateThreadAsync();
        PersistentThreadMessage message = await client.Messages.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "What's the weather in Seattle?");

        ThreadRun run = await client.Runs.CreateRunAsync(thread, agent);

        do
        {
            await Task.Delay(TimeSpan.FromMilliseconds(500));
            run = await client.Runs.GetRunAsync(thread.Id, run.Id);
        }
        while (run.Status == RunStatus.Queued
            || run.Status == RunStatus.InProgress
            || run.Status == RunStatus.RequiresAction);
        Assert.AreEqual(
            RunStatus.Completed,
            run.Status,
            run.LastError?.Message);
        #endregion

        #region Snippet:AgentsOpenAPI_Print
        AsyncPageable<PersistentThreadMessage> messages = client.Messages.GetMessagesAsync(
            threadId: thread.Id,
            order: ListSortOrder.Ascending
        );

        await foreach (PersistentThreadMessage threadMessage in messages)
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
        #region Snippet:AgentsOpenAPI_Cleanup
        await client.Threads.DeleteThreadAsync(thread.Id);
        await client.Administration.DeleteAgentAsync(agent.Id);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void OpenAPICallingExample()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());
        var file_path = GetFile();

        #region Snippet:AgentsOpenAPISyncDefineFunctionTools
        OpenApiAnonymousAuthDetails oaiAuth = new();
        OpenApiToolDefinition openapiTool = new(
            name: "get_weather",
            description: "Retrieve weather information for a location",
            spec: BinaryData.FromBytes(System.IO.File.ReadAllBytes(file_path)),
            openApiAuthentication: oaiAuth,
            defaultParams: ["format"]
        );

        PersistentAgent agent = client.Administration.CreateAgent(
            model: modelDeploymentName,
            name: "azure-function-agent-foo",
            instructions: "You are a helpful agent.",
            tools: [openapiTool]
        );
        #endregion

        #region Snippet:AgentsOpenAPISyncHandlePollingWithRequiredAction
        PersistentAgentThread thread = client.Threads.CreateThread();
        PersistentThreadMessage message = client.Messages.CreateMessage(
            thread.Id,
            MessageRole.User,
            "What's the weather in Seattle?");

        ThreadRun run = client.Runs.CreateRun(thread, agent);

        do
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(500));
            run = client.Runs.GetRun(thread.Id, run.Id);
        }
        while (run.Status == RunStatus.Queued
            || run.Status == RunStatus.InProgress
            || run.Status == RunStatus.RequiresAction);
        Assert.AreEqual(
            RunStatus.Completed,
            run.Status,
            run.LastError?.Message);
        #endregion

        #region Snippet:AgentsOpenAPISync_Print
        Pageable<PersistentThreadMessage> messages = client.Messages.GetMessages(
            threadId: thread.Id,
            order: ListSortOrder.Ascending
        );

        foreach (PersistentThreadMessage threadMessage in messages)
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
        #region Snippet:AgentsOpenAPISync_Cleanup
        client.Threads.DeleteThread(thread.Id);
        client.Administration.DeleteAgent(agent.Id);
        #endregion
    }
}
