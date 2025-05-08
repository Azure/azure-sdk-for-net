// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Threading;

namespace Azure.AI.Projects.Tests;

public partial class Sample_Agents_Azure_AI_Search : SamplesBase<AIProjectsTestEnvironment>
{
    [Test]
    [AsyncOnly]
    public async Task AzureAISearchExampleAsync()
    {
        #region Snippet:AzureAISearchExample_CreateProjectClient
#if SNIPPET
        var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        var projectClient = new AIProjectClient(connectionString, new DefaultAzureCredential());
        #endregion
        #region Snippet:CreateAgentWithAzureAISearchTool
        ListConnectionsResponse connections = await projectClient.GetConnectionsClient().GetConnectionsAsync(ConnectionType.AzureAISearch).ConfigureAwait(false);

        if (connections?.Value == null || connections.Value.Count == 0)
        {
            throw new InvalidOperationException("No connections found for the Azure AI Search.");
        }

        ConnectionResponse connection = connections.Value[0];

        AzureAISearchResource searchResource = new(
            connection.Id,
            "sample_index",
            5,
            "category eq 'sleeping bag'",
            AzureAISearchQueryType.Simple
        );
        ToolResources toolResource = new()
        {
            AzureAISearch = searchResource
        };

        AgentsClient agentClient = projectClient.GetAgentsClient();

        Agent agent = await agentClient.CreateAgentAsync(
           model: modelDeploymentName,
           name: "my-assistant",
           instructions: "You are a helpful assistant.",
           tools: [ new AzureAISearchToolDefinition() ],
           toolResources: toolResource);
        #endregion
        #region Snippet:AzureAISearchExample_CreateRun
        // Create thread for communication
        Response<AgentThread> threadResponse = await agentClient.CreateThreadAsync();
        AgentThread thread = threadResponse.Value;

        // Create message to thread
        ThreadMessage message = await agentClient.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "What is the temperature rating of the cozynights sleeping bag?");

        // Run the agent
        ThreadRun run = await agentClient.CreateRunAsync(thread, agent);

        do
        {
            await Task.Delay(TimeSpan.FromMilliseconds(500));
            run = await agentClient.GetRunAsync(thread.Id, run.Id);
        }
        while (run.Status == RunStatus.Queued
            || run.Status == RunStatus.InProgress);

        Assert.AreEqual(
            RunStatus.Completed,
            run.Status,
            run.LastError?.Message);
        #endregion
        #region Snippet:PopulateReferencesAgentWithAzureAISearchTool
        PageableList<ThreadMessage> messages = await agentClient.GetMessagesAsync(
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
        #region Snippet:AzureAISearchExample_Cleanup
        await agentClient.DeleteThreadAsync(thread.Id);
        await agentClient.DeleteAgentAsync(agent.Id);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void AzureAISearchExample()
    {
#if SNIPPET
        var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        var projectClient = new AIProjectClient(connectionString, new DefaultAzureCredential());
        #region Snippet:CreateAgentWithAzureAISearchTool_Sync
        ListConnectionsResponse connections = projectClient.GetConnectionsClient().GetConnections(ConnectionType.AzureAISearch);

        if (connections?.Value == null || connections.Value.Count == 0)
        {
            throw new InvalidOperationException("No connections found for the Azure AI Search.");
        }

        ConnectionResponse connection = connections.Value[0];

        AzureAISearchResource searchResource = new(
            connection.Id,
            "sample_index",
            5,
            "category eq 'sleeping bag'",
            AzureAISearchQueryType.Simple
        );
        ToolResources toolResource = new()
        {
            AzureAISearch = searchResource
        };

        AgentsClient agentClient = projectClient.GetAgentsClient();

        Agent agent = agentClient.CreateAgent(
           model: modelDeploymentName,
           name: "my-assistant",
           instructions: "You are a helpful assistant.",
           tools: [new AzureAISearchToolDefinition()],
           toolResources: toolResource);
        #endregion
        #region Snippet:AzureAISearchExample_CreateRun_Sync
        // Create thread for communication
        Response<AgentThread> threadResponse = agentClient.CreateThread();
        AgentThread thread = threadResponse.Value;

        // Create message to thread
        ThreadMessage message = agentClient.CreateMessage(
            thread.Id,
            MessageRole.User,
            "What is the temperature rating of the cozynights sleeping bag?");

        // Run the agent
        Response<ThreadRun> runResponse = agentClient.CreateRun(thread, agent);

        do
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(500));
            runResponse = agentClient.GetRun(thread.Id, runResponse.Value.Id);
        }
        while (runResponse.Value.Status == RunStatus.Queued
            || runResponse.Value.Status == RunStatus.InProgress);

        Assert.AreEqual(
            RunStatus.Completed,
            runResponse.Value.Status,
            runResponse.Value.LastError?.Message);
        #endregion
        #region Snippet:PopulateReferencesAgentWithAzureAISearchTool_Sync
        PageableList<ThreadMessage> messages = agentClient.GetMessages(
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
        #region Snippet:AzureAISearchExample_Cleanup_Sync
        agentClient.DeleteThread(thread.Id);
        agentClient.DeleteAgent(agent.Id);
        #endregion
    }
}
