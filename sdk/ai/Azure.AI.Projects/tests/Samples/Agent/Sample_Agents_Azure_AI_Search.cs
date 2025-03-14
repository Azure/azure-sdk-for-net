// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Collections.Generic;
using NUnit.Framework.Internal;

namespace Azure.AI.Projects.Tests;

public partial class Sample_Agents_Azure_AI_Search : SamplesBase<AIProjectsTestEnvironment>
{
    [Test]
    public async Task AzureAISearchExample()
    {
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
        var modelName = TestEnvironment.MODELDEPLOYMENTNAME;

        var clientOptions = new AIProjectClientOptions();

        // Adding the custom headers policy
        clientOptions.AddPolicy(new CustomHeadersPolicy(), HttpPipelinePosition.PerCall);
        var projectClient = new AIProjectClient(connectionString, new DefaultAzureCredential(), clientOptions);
        #region Snippet:CreateAgentWithAzureAISearchTool
        ListConnectionsResponse connections = await projectClient.GetConnectionsClient().GetConnectionsAsync(ConnectionType.AzureAISearch).ConfigureAwait(false);

        if (connections?.Value == null || connections.Value.Count == 0)
        {
            throw new InvalidOperationException("No connections found for the Azure AI Search.");
        }

        ConnectionResponse connection = connections.Value[0];

        ToolResources searchResource = new ToolResources
        {
            AzureAISearch = new AzureAISearchResource
            {
                IndexList = { new IndexResource(connection.Id, "sample_index") }
            }
        };

        AgentsClient agentClient = projectClient.GetAgentsClient();

        Response<Agent> agentResponse = await agentClient.CreateAgentAsync(
           model: modelName,
           name: "my-assistant",
           instructions: "You are a helpful assistant.",
           tools: new List<ToolDefinition> { new AzureAISearchToolDefinition() },
           toolResources: searchResource);
        Agent agent = agentResponse.Value;
        #endregion
        // Create thread for communication
        Response<AgentThread> threadResponse = await agentClient.CreateThreadAsync();
        AgentThread thread = threadResponse.Value;

        // Create message to thread
        Response<ThreadMessage> messageResponse = await agentClient.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "What is the temperature rating of the cozynights sleeping bag?");
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

        Assert.AreEqual(
            RunStatus.Completed,
            runResponse.Value.Status,
            runResponse.Value.LastError?.Message);
        #region Snippet:PopulateReferencesAgentWithAzureAISearchTool
        PageableList<ThreadMessage> messages = await agentClient.GetMessagesAsync(
            threadId: thread.Id,
            order: ListSortOrder.Ascending
        );

        // Note: messages iterate from newest to oldest, with the messages[0] being the most recent
        foreach (ThreadMessage threadMessage in messages)
        {
            Console.Write($"{threadMessage.CreatedAt:yyyy-MM-dd HH:mm:ss} - {threadMessage.Role,10}: ");
            foreach (MessageContent contentItem in threadMessage.ContentItems)
            {
                if (contentItem is MessageTextContent textItem)
                {
                    // We need to annotate only Agent messages.
                    if (threadMessage.Role == MessageRole.Agent && textItem.Annotations.Count > 0)
                    {
                        string annotatedText = textItem.Text;
                        foreach (MessageTextAnnotation annotation in textItem.Annotations)
                        {
                            if (annotation is MessageTextUrlCitationAnnotation urlAnnotation)
                            {
                                annotatedText = annotatedText.Replace(
                                    urlAnnotation.Text,
                                    $" [see {urlAnnotation.UrlCitation.Title}] ({urlAnnotation.UrlCitation.Url})");
                            }
                        }
                        Console.Write(annotatedText);
                    }
                    else
                    {
                        Console.Write(textItem.Text);
                    }
                }
                else if (contentItem is MessageImageFileContent imageFileItem)
                {
                    Console.Write($"<image from ID: {imageFileItem.FileId}");
                }
                Console.WriteLine();
            }
        }
        #endregion
    }
}
