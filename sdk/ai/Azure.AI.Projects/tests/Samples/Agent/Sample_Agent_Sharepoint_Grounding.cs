// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests;

public partial class Sample_Agent_Sharepoint_Grounding : SamplesBase<AIProjectsTestEnvironment>
{
    [Test]
    public async Task SharepointGroundingExample()
    {
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
        var modelName = TestEnvironment.MODELDEPLOYMENTNAME;

        var clientOptions = new AIProjectClientOptions();

        // Adding the custom headers policy
        clientOptions.AddPolicy(new CustomHeadersPolicy(), HttpPipelinePosition.PerCall);
        var projectClient = new AIProjectClient(connectionString, new AzureCliCredential(), clientOptions);

        ConnectionResponse sharepointConnection = await projectClient.GetConnectionsClient().GetConnectionAsync(TestEnvironment.SHAREPOINTCONNECTIONNAME);
        var connectionId = sharepointConnection.Id;

        AgentsClient agentClient = projectClient.GetAgentsClient();

        ToolConnectionList connectionList = new ToolConnectionList
        {
            ConnectionList = { new ToolConnection(connectionId) }
        };
        SharepointToolDefinition sharepointGroundingTool = new SharepointToolDefinition(connectionList);

        Response<Agent> agentResponse = await agentClient.CreateAgentAsync(
           model: modelName,
           name: "my-assistant",
           instructions: "You are a helpful assistant.",
           tools: new List<ToolDefinition> { sharepointGroundingTool });
        Agent agent = agentResponse.Value;

        // Create thread for communication
        Response<AgentThread> threadResponse = await agentClient.CreateThreadAsync();
        AgentThread thread = threadResponse.Value;

        // Create message to thread
        Response<ThreadMessage> messageResponse = await agentClient.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "<Sharepoint specific question here>");
        ThreadMessage message = messageResponse.Value;

        // Run the agent
        Response<ThreadRun> runResponse = await agentClient.CreateRunAsync(thread, agent);

        do
        {
            await Task.Delay(TimeSpan.FromMilliseconds(500));
            runResponse = await agentClient.GetRunAsync(thread.Id, runResponse.Value.Id);
        }
        while (runResponse.Value.Status == RunStatus.Queued
            || runResponse.Value.Status == RunStatus.InProgress);

        Response<PageableList<ThreadMessage>> afterRunMessagesResponse
            = await agentClient.GetMessagesAsync(thread.Id);
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
