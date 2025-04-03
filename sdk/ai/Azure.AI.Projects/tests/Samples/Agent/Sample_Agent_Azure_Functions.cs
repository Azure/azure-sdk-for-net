// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests;

public partial class Sample_Agent_Azure_Functions : SamplesBase<AIProjectsTestEnvironment>
{
    [Test]
    [AsyncOnly]
    public async Task AzureFunctionCallingExampleAsync()
    {
        #region Snippet:AzureFunctionsDefineFunctionTools
#if SNIPPET
        var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var storageQueueUri = System.Environment.GetEnvironmentVariable("STORAGE_QUEUE_URI");
#else
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var storageQueueUri = TestEnvironment.STORAGE_QUEUE_URI;
#endif

        AgentsClient client = new(connectionString, new DefaultAzureCredential());

        AzureFunctionToolDefinition azureFnTool = new(
            name: "foo",
            description: "Get answers from the foo bot.",
            inputBinding: new AzureFunctionBinding(
                new AzureFunctionStorageQueue(
                    queueName: "azure-function-foo-input",
                    storageServiceEndpoint: storageQueueUri
                )
            ),
            outputBinding: new AzureFunctionBinding(
                new AzureFunctionStorageQueue(
                    queueName: "azure-function-tool-output",
                    storageServiceEndpoint: storageQueueUri
                )
            ),
            parameters: BinaryData.FromObjectAsJson(
                    new
                    {
                        Type = "object",
                        Properties = new
                        {
                            query = new
                            {
                                Type = "string",
                                Description = "The question to ask.",
                            },
                            outputqueueuri = new
                            {
                                Type = "string",
                                Description = "The full output queue uri."
                            }
                        },
                    },
                new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }
            )
        );
        #endregion

        #region Snippet:AzureFunctionsCreateAgentWithFunctionTools
        Agent agent = await client.CreateAgentAsync(
            model: modelDeploymentName,
            name: "azure-function-agent-foo",
                instructions: "You are a helpful support agent. Use the provided function any "
                + "time the prompt contains the string 'What would foo say?'. When you invoke "
                + "the function, ALWAYS specify the output queue uri parameter as "
                + $"'{storageQueueUri}/azure-function-tool-output'. Always responds with "
                + "\"Foo says\" and then the response from the tool.",
            tools: [ azureFnTool ]
            );
        #endregion
        #region Snippet:AzureFunctionsHandlePollingWithRequiredAction
        AgentThread thread = await client.CreateThreadAsync();

        ThreadMessage message = await client.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "What is the most prevalent element in the universe? What would foo say?");

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

        #region Snippet:AzureFunctionsPrint
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
        #region Snippet:AzureFunctionsCleanup
        await client.DeleteThreadAsync(thread.Id);
        await client.DeleteAgentAsync(agent.Id);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void AzureFunctionCallingExample()
    {
#if SNIPPET
        var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var storageQueueUri = System.Environment.GetEnvironmentVariable("STORAGE_QUEUE_URI");
#else
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var storageQueueUri = TestEnvironment.STORAGE_QUEUE_URI;
#endif

        AgentsClient client = new(connectionString, new DefaultAzureCredential());

        AzureFunctionToolDefinition azureFnTool = new(
            name: "foo",
            description: "Get answers from the foo bot.",
            inputBinding: new AzureFunctionBinding(
                new AzureFunctionStorageQueue(
                    queueName: "azure-function-foo-input",
                    storageServiceEndpoint: storageQueueUri
                )
            ),
            outputBinding: new AzureFunctionBinding(
                new AzureFunctionStorageQueue(
                    queueName: "azure-function-tool-output",
                    storageServiceEndpoint: storageQueueUri
                )
            ),
            parameters: BinaryData.FromObjectAsJson(
                    new
                    {
                        Type = "object",
                        Properties = new
                        {
                            query = new
                            {
                                Type = "string",
                                Description = "The question to ask.",
                            },
                            outputqueueuri = new
                            {
                                Type = "string",
                                Description = "The full output queue uri."
                            }
                        },
                    },
                new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }
            )
        );

        #region Snippet:AzureFunctionsCreateAgentWithFunctionToolsSync
        Agent agent = client.CreateAgent(
            model: modelDeploymentName,
            name: "azure-function-agent-foo",
                instructions: "You are a helpful support agent. Use the provided function any "
                + "time the prompt contains the string 'What would foo say?'. When you invoke "
                + "the function, ALWAYS specify the output queue uri parameter as "
                + $"'{storageQueueUri}/azure-function-tool-output'. Always responds with "
                + "\"Foo says\" and then the response from the tool.",
            tools: [azureFnTool]
            );
        #endregion
        #region Snippet:AzureFunctionsHandlePollingWithRequiredActionSync
        AgentThread thread = client.CreateThread();

        ThreadMessage message = client.CreateMessage(
            thread.Id,
            MessageRole.User,
            "What is the most prevalent element in the universe? What would foo say?");

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

        #region Snippet:AzureFunctionsPrintSync
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
        #region Snippet:AzureFunctionsCleanupSync
        client.DeleteThread(thread.Id);
        client.DeleteAgent(agent.Id);
        #endregion
    }
}
