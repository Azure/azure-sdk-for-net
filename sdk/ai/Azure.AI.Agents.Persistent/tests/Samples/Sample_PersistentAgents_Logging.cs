// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Agents.Persistent.Tests;

#region Snippet:Logging_LoggingPolicy
public class LoggingPolicy : HttpPipelinePolicy
{
    private static void ProcessMessage(HttpMessage message)
    {
        if (message.Request is not null && !message.HasResponse)
        {
            Console.WriteLine($"{message?.Request?.Method} URI: {message?.Request?.Uri}");
            Console.WriteLine($"--- New request ---");
            IEnumerable<string> headerPairs = message?.Request?.Headers.Select(header => $"\n    {header.Name}={(header.Name.ToLower().Contains("auth") ? "***" : header.Value)}");
            string headers = string.Join("", headerPairs);
            Console.WriteLine($"Request headers:{headers}");
            if (message.Request?.Content != null)
            {
                string contentType = "Unknown Content Type";
                if (message.Request.Headers.TryGetValue("Content-Type", out contentType) == true
                    && contentType == "application/json")
                {
                    using MemoryStream stream = new();
                    message.Request.Content.WriteTo(stream, default);
                    stream.Position = 0;
                    using StreamReader reader = new(stream);
                    string requestDump = reader.ReadToEnd();
                    stream.Position = 0;
                    requestDump = Regex.Replace(requestDump, @"""data"":[\\w\\r\\n]*""[^""]*""", @"""data"":""...""");
                    // Make sure JSON string is properly formatted.
                    JsonSerializerOptions jsonOptions = new()
                    {
                        WriteIndented = true,
                    };
                    JsonElement jsonElement = JsonSerializer.Deserialize<JsonElement>(requestDump);
                    Console.WriteLine("--- Begin request content ---");
                    Console.WriteLine(JsonSerializer.Serialize(jsonElement, jsonOptions));
                    Console.WriteLine("--- End request content ---");
                }
                else
                {
                    string length = message.Request.Content.TryComputeLength(out long numberLength)
                        ? $"{numberLength} bytes"
                        : "unknown length";
                    Console.WriteLine($"<< Non-JSON content: {contentType} >> {length}");
                }
            }
        }
        if (message.HasResponse)
        {
            IEnumerable<string> headerPairs = message?.Response?.Headers.Select(header => $"\n    {header.Name}={(header.Name.ToLower().Contains("auth") ? "***" : header.Value)}");
            string headers = string.Join("", headerPairs);
            Console.WriteLine($"Response headers:{headers}");
            if (message.BufferResponse)
            {
                Console.WriteLine("--- Begin response content ---");
                Console.WriteLine(message.Response.Content?.ToString());
                Console.WriteLine("--- End of response content ---");
            }
            else
            {
                Console.WriteLine("--- Response (unbuffered, content not rendered) ---");
            }
        }
    }
    public LoggingPolicy() { }

    public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
    {
        ProcessMessage(message); // for request
        System.Diagnostics.Stopwatch stopwatch = System.Diagnostics.Stopwatch.StartNew();
        try
        {
            ProcessNext(message, pipeline);
        }
        finally
        {
            Console.WriteLine($"Response time {stopwatch.Elapsed.TotalMilliseconds} ms");
        }
        ProcessMessage(message); // for response
    }

    public override async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
    {
        ProcessMessage(message); // for request
        System.Diagnostics.Stopwatch stopwatch = System.Diagnostics.Stopwatch.StartNew();
        try
        {
            await ProcessNextAsync(message, pipeline);
        }
        finally
        {
            Console.WriteLine($"Response time {stopwatch.Elapsed.TotalMilliseconds} ms");
        }
        ProcessMessage(message); // for response
    }
}
#endregion

public partial class Sample_PersistentAgents_Logging : SamplesBase<AIAgentsTestEnvironment>
{
    [Test]
    [AsyncOnly]
    public async Task LoggingExample()
    {
        #region Snippet:Logging_CreateAgentClient
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        PersistentAgentsAdministrationClientOptions options = new();
        options.AddPolicy(new LoggingPolicy(), HttpPipelinePosition.PerCall);
        PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential(), options);
        #endregion

        // Step 1: Create an agent
        #region Snippet:Logging_CreateAgent_Async
        // NOTE: To reuse existing agent, fetch it with client.Administration.GetAgent(agentId)
        PersistentAgent agent = await client.Administration.CreateAgentAsync(
            model: modelDeploymentName,
            name: "Math Tutor",
            instructions: "You are a personal math tutor. Write and run code to answer math questions."
        );
        #endregion

        //// Step 2: Create a thread
        #region Snippet:Logging_CreateThread_Async
        PersistentAgentThread thread = await client.Threads.CreateThreadAsync();
        #endregion

        // Step 3: Add a message to a thread
        #region Snippet:Logging_CreateMessage_Async
        PersistentThreadMessage message = await client.Messages.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "I need to solve the equation `3x + 11 = 14`. Can you help me?");
        #endregion

        // Step 4: Run the agent
        #region Snippet:Logging_CreateRun_Async
        ThreadRun run = await client.Runs.CreateRunAsync(
            thread.Id,
            agent.Id,
            additionalInstructions: "Please address the user as Jane Doe. The user has a premium account.");
        #endregion

        #region Snippet:Logging_WaitForRun_Async
        do
        {
            await Task.Delay(TimeSpan.FromMilliseconds(500));
            run = await client.Runs.GetRunAsync(thread.Id, run.Id);
        }
        while (run.Status == RunStatus.Queued
            || run.Status == RunStatus.InProgress);
        Assert.AreEqual(
            RunStatus.Completed,
            run.Status,
            run.LastError?.Message);
        #endregion

        #region Snippet:Logging_ListUpdatedMessages_Async
        AsyncPageable<PersistentThreadMessage> messages
            = client.Messages.GetMessagesAsync(
                threadId: thread.Id, order: ListSortOrder.Ascending);

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
        #region Snippet:Logging_Cleanup_Async
        // NOTE: Comment out these two lines if you plan to reuse the agent later.
        await client.Threads.DeleteThreadAsync(threadId: thread.Id);
        await client.Administration.DeleteAgentAsync(agentId: agent.Id);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void LoggingExampleSync()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        PersistentAgentsAdministrationClientOptions options = new();
        options.AddPolicy(new LoggingPolicy(), HttpPipelinePosition.PerCall);
        PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential(), options);

        // Step 1: Create an agent
        #region Snippet:Logging_CreateAgent_Sync
        // NOTE: To reuse existing agent, fetch it with client.Administration.GetAgent(agentId)
        PersistentAgent agent = client.Administration.CreateAgent(
            model: modelDeploymentName,
            name: "Math Tutor",
            instructions: "You are a personal math tutor. Write and run code to answer math questions."
        );
        #endregion

        //// Step 2: Create a thread
        #region Snippet:Logging_CreateThread_Sync
        PersistentAgentThread thread = client.Threads.CreateThread();
        #endregion

        // Step 3: Add a message to a thread
        #region Snippet:Logging_CreateMessage_Sync
        PersistentThreadMessage message = client.Messages.CreateMessage(
            thread.Id,
            MessageRole.User,
            "I need to solve the equation `3x + 11 = 14`. Can you help me?");
        #endregion

        // Step 4: Run the agent
        #region Snippet:Logging_CreateRun_Sync
        ThreadRun run = client.Runs.CreateRun(
            thread.Id,
            agent.Id,
            additionalInstructions: "Please address the user as Jane Doe. The user has a premium account.");
        #endregion

        #region Snippet:Logging_WaitForRun_Sync
        do
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(500));
            run = client.Runs.GetRun(thread.Id, run.Id);
        }
        while (run.Status == RunStatus.Queued
            || run.Status == RunStatus.InProgress);
        Assert.AreEqual(
            RunStatus.Completed,
            run.Status,
            run.LastError?.Message);
        #endregion

        #region Snippet:Logging_ListUpdatedMessages_Sync
        Pageable<PersistentThreadMessage> messages
            = client.Messages.GetMessages(
                threadId: thread.Id, order: ListSortOrder.Ascending);

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

        #region Snippet:Logging_Cleanup_Sync
        // NOTE: Comment out these two lines if you plan to reuse the agent later.
        client.Threads.DeleteThread(threadId: thread.Id);
        client.Administration.DeleteAgent(agentId: agent.Id);
        #endregion
    }
}
