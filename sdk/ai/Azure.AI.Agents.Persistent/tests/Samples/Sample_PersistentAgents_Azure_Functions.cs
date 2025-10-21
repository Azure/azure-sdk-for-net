// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Agents.Persistent.Tests;

public partial class Sample_PersistentAgents_Azure_Functions : SamplesBase<AIAgentsTestEnvironment>
{
    [Test]
    [AsyncOnly]
    public async Task AzureFunctionCallingExampleAsync()
    {
        #region Snippet:AgentsAzureFunctionsDefineFunctionTools
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var storageQueueUri = System.Environment.GetEnvironmentVariable("STORAGE_QUEUE_URI");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var storageQueueUri = TestEnvironment.STORAGE_QUEUE_URI;
#endif

        PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());

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

        #region Snippet:AgentsAzureFunctionsCreateAgentWithFunctionTools
        // NOTE: To reuse existing agent, fetch it with client.Administration.GetAgent(agentId)
        PersistentAgent agent = await client.Administration.CreateAgentAsync(
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
        #region Snippet:AgentsAzureFunctionsHandlePollingWithRequiredAction
        PersistentAgentThread thread = await client.Threads.CreateThreadAsync();

        PersistentThreadMessage message = await client.Messages.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "What is the most prevalent element in the universe? What would foo say?");

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

        #region Snippet:AgentsAzureFunctionsPrint
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
        #region Snippet:AgentsAzureFunctionsCleanup
        // NOTE: Comment out these two lines if you plan to reuse the agent later.
        await client.Threads.DeleteThreadAsync(thread.Id);
        await client.Administration.DeleteAgentAsync(agent.Id);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void AzureFunctionCallingExample()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var storageQueueUri = System.Environment.GetEnvironmentVariable("STORAGE_QUEUE_URI");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var storageQueueUri = TestEnvironment.STORAGE_QUEUE_URI;
#endif

        PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());

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

        #region Snippet:AgentsAzureFunctionsCreateAgentWithFunctionToolsSync
        // NOTE: To reuse existing agent, fetch it with client.Administration.GetAgent(agentId)
        PersistentAgent agent = client.Administration.CreateAgent(
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
        #region Snippet:AgentsAzureFunctionsHandlePollingWithRequiredActionSync
        PersistentAgentThread thread = client.Threads.CreateThread();

        PersistentThreadMessage message = client.Messages.CreateMessage(
            thread.Id,
            MessageRole.User,
            "What is the most prevalent element in the universe? What would foo say?");

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

        #region Snippet:AgentsAzureFunctionsPrintSync
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
        #region Snippet:AgentsAzureFunctionsCleanupSync
        // NOTE: Comment out these two lines if you plan to reuse the agent later.
        client.Threads.DeleteThread(thread.Id);
        client.Administration.DeleteAgent(agent.Id);
        #endregion
    }
}
