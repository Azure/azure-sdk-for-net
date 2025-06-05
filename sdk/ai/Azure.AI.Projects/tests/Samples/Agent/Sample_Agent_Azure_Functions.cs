// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
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
        AgentsClient client = new(connectionString, new DefaultAzureCredential());

        #region Snippet:AzureFunctionsDefineFunctionTools
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
        Response<Agent> agentResponse = await client.CreateAgentAsync(
            model: "gpt-4",
            name: "azure-function-agent-foo",
                instructions: "You are a helpful support agent. Use the provided function any "
                + "time the prompt contains the string 'What would foo say?'. When you invoke "
                + "the function, ALWAYS specify the output queue uri parameter as "
                + $"'{storageQueueUri}/azure-function-tool-output'. Always responds with "
                + "\"Foo says\" and then the response from the tool.",
            tools: new List<ToolDefinition> { azureFnTool }
            );
        Agent agent = agentResponse.Value;
        #endregion

        Response<AgentThread> threadResponse = await client.CreateThreadAsync();
        AgentThread thread = threadResponse.Value;

        #region Snippet:AzureFunctionsHandlePollingWithRequiredAction
        Response<ThreadMessage> messageResponse = await client.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "What is the most prevalent element in the universe? What would foo say?");
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
