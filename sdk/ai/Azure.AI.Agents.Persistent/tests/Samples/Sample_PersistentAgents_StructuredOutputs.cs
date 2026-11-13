// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Agents.Persistent.Tests;

public partial class Sample_PersistentAgents_StructuredOutputs : SamplesBase<AIAgentsTestEnvironment>
{
    #region Snippet:StructuredOutputs_CreateAgent_CreateSchema
    private static readonly BinaryData s_calendarSchema = BinaryData.FromObjectAsJson(
    new
    {
        additionalProperties = false,
        properties = new
        {
            name = new
            {
                title = "Name",
                type = "string"
            },
            date = new
            {
                description = "Date in YYYY-MM-DD format",
                title = "Date",
                type = "string"
            },
            participants = new
            {
                items = new { type = "string" },
                title = "Participants",
                type = "array"
            }
        },
        required = new List<string> { "name", "date", "participants" },
        title = "CalendarEvent",
        type = "object",
    });
    #endregion

    [Test]
    [AsyncOnly]
    public async Task StructuredOutputsAsync()
    {
        #region Snippet:StructuredOutputs_CreateAgentClient
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());
        #endregion
        // Step 1: Create an agent
        #region Snippet:StructuredOutputs_CreateAgent_Async
        ResponseFormatJsonSchemaType responseSchemaType = new(
            new ResponseFormatJsonSchema(name: "Calendar", schema: s_calendarSchema)
        );
        BinaryData responseFormat = ((IJsonModel<ResponseFormatJsonSchemaType>)responseSchemaType).Write(ModelReaderWriterOptions.Json);

        // NOTE: To reuse existing agent, fetch it with client.Administration.GetAgent(agentId)
        PersistentAgent agent = await client.Administration.CreateAgentAsync(
            model: modelDeploymentName,
            name: "Calendar events",
            instructions: "You are a helpful assistant that extracts calendar event information from the input user messages," +
                          "and returns it in the desired structured output format.",
            responseFormat: responseFormat
        );
        #endregion

        // Step 2: Create a thread
        #region Snippet:StructuredOutputs_CreateThread_Async
        PersistentAgentThread thread = await client.Threads.CreateThreadAsync();
        #endregion

        // Step 3: Add a message to a thread
        #region Snippet:StructuredOutputs_CreateMessage_Async
        PersistentThreadMessage message = await client.Messages.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "Alice and Bob are going to a science fair this Friday, November 7, 2025.");
        #endregion

        // Step 4: Run the agent
        #region Snippet:StructuredOutputs_CreateRun_Async
        ThreadRun run = await client.Runs.CreateRunAsync(
            thread.Id,
            agent.Id,
            additionalInstructions: "Please address the user as Jane Doe. The user has a premium account.");
        #endregion

        #region Snippet:StructuredOutputs_WaitForRun_Async
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

        #region Snippet:StructuredOutputs_ListUpdatedMessages_Async
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
        #region Snippet:StructuredOutputs_Cleanup_Async
        // NOTE: Comment out these two lines if you plan to reuse the agent later.
        await client.Threads.DeleteThreadAsync(threadId: thread.Id);
        await client.Administration.DeleteAgentAsync(agentId: agent.Id);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void StructuredOutputsSync()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());
        // Step 1: Create an agent
        #region Snippet:StructuredOutputs_CreateAgent_Sync
        ResponseFormatJsonSchemaType responseSchemaType = new(
            new ResponseFormatJsonSchema(name: "Calendar", schema: s_calendarSchema)
        );
        BinaryData responseFormat = ((IJsonModel<ResponseFormatJsonSchemaType>)responseSchemaType).Write(ModelReaderWriterOptions.Json);

        // NOTE: To reuse existing agent, fetch it with client.Administration.GetAgent(agentId)
        PersistentAgent agent = client.Administration.CreateAgent(
            model: modelDeploymentName,
            name: "Calendar events",
            instructions: "You are a helpful assistant that extracts calendar event information from the input user messages," +
                          "and returns it in the desired structured output format.",
            responseFormat: responseFormat
        );
        #endregion

        // Step 2: Create a thread
        #region Snippet:StructuredOutputs_CreateThread_Sync
        PersistentAgentThread thread = client.Threads.CreateThread();
        #endregion

        // Step 3: Add a message to a thread
        #region Snippet:StructuredOutputs_CreateMessage_Sync
        PersistentThreadMessage message = client.Messages.CreateMessage(
            thread.Id,
            MessageRole.User,
            "Alice and Bob are going to a science fair this Friday, November 7, 2025.");
        #endregion

        // Step 4: Run the agent
        #region Snippet:StructuredOutputs_CreateRun_Sync
        ThreadRun run = client.Runs.CreateRun(
            thread.Id,
            agent.Id,
            additionalInstructions: "Please address the user as Jane Doe. The user has a premium account.");
        #endregion

        #region Snippet:StructuredOutputs_WaitForRun_Sync
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

        #region Snippet:StructuredOutputs_ListUpdatedMessages_Sync
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
        #region Snippet:StructuredOutputs_Cleanup_Sync
        // NOTE: Comment out these two lines if you plan to reuse the agent later.
        client.Threads.DeleteThread(threadId: thread.Id);
        client.Administration.DeleteAgent(agentId: agent.Id);
        #endregion
    }
}
