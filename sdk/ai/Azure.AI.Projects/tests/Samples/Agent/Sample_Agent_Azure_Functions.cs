// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests;

public partial class Sample_Agent_Azure_Functions : SamplesBase<AIProjectsTestEnvironment>
{
    [Test]
    public async Task AzureFunctionCallingExample()
    {
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
        var storageQueueUri = TestEnvironment.STORAGE_QUEUE_URI;
        // Add experimental headers policy
        AIProjectClientOptions clientOptions = new();
        clientOptions.AddPolicy(new ExperimentalHeaderPolicy(), HttpPipelinePosition.PerCall);
        AgentsClient client = new(connectionString, new DefaultAzureCredential(), clientOptions);

        #region Snippet:AzureFunctionsDefineFunctionTools
        // Example of Azure Function
        AzureFunctionToolDefinition azureFnTool = new(
            azureFunction: new AzureFunctionDefinition(
                name: "foo",
                description: "Get answers from the foo bot.",
                inputBinding: new AzureStorageQueueBinding(
                    new AzureFunctionStorageQueue(
                        queueName: "azure-function-foo-input",
                        storageQueueUri: storageQueueUri
                    )
                ),
                outputBinding: new AzureStorageQueueBinding(
                    new AzureFunctionStorageQueue(
                        queueName: "azure-function-tool-output",
                        storageQueueUri: storageQueueUri
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
            )
        );
        #endregion

        #region Snippet:AzureFunctionsCreateAgentWithFunctionTools
        Response<Agent> agentResponse = await client.CreateAgentAsync(
            model: "gpt-4",
            name: "SDK Test Agent - Functions",
                instructions: "You are a weather bot. Use the provided functions to help answer questions. "
                    + "Customize your responses to the user's preferences as much as possible and use friendly "
                    + "nicknames for cities whenever possible.",
            tools: new List<ToolDefinition> { azureFnTool }
            );
        Agent agent = agentResponse.Value;
        #endregion

        Response<AgentThread> threadResponse = await client.CreateThreadAsync();
        AgentThread thread = threadResponse.Value;

        Response<ThreadMessage> messageResponse = await client.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "What is the most prevalent element in the universe? What would foo say?");
        ThreadMessage message = messageResponse.Value;

        Response<ThreadRun> runResponse = await client.CreateRunAsync(thread, agent);

        #region Snippet:AzureFunctionsHandlePollingWithRequiredAction
        do
        {
            await Task.Delay(TimeSpan.FromMilliseconds(500));
            runResponse = await client.GetRunAsync(thread.Id, runResponse.Value.Id);
        }
        while (runResponse.Value.Status == RunStatus.Queued
            || runResponse.Value.Status == RunStatus.InProgress);
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
    private class ExperimentalHeaderPolicy : HttpPipelinePolicy
    {
        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            message.Request.Headers.Add("x-ms-enable-preview", "true");
            ProcessNext(message, pipeline);
        }
        public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            message.Request.Headers.Add("x-ms-enable-preview", "true");
            return ProcessNextAsync(message, pipeline);
        }
    }
}
