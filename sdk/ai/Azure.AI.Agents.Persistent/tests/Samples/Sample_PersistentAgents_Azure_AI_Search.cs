// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Threading;

namespace Azure.AI.Agents.Persistent.Tests;

public partial class Sample_PersistentAgents_Azure_AI_Search : SamplesBase<AIAgentsTestEnvironment>
{
    [Test]
    [AsyncOnly]
    public async Task AzureAISearchExampleAsync()
    {
        #region Snippet:AgentsAzureAISearchExample_CreateProjectClient
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var connectionID = System.Environment.GetEnvironmentVariable("AZURE_AI_CONNECTION_ID");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var connectionID = TestEnvironment.AI_SEARCH_CONNECTION_ID;
#endif
        #endregion
        #region Snippet:AgentsCreateAgentWithAzureAISearchTool
        AzureAISearchToolResource searchResource = new(
            connectionID,
            "sample_index",
            5,
            "category eq 'sleeping bag'",
            AzureAISearchQueryType.Simple
        );
        ToolResources toolResource = new()
        {
            AzureAISearch = searchResource
        };

        PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());

        PersistentAgent agent = await client.Administration.CreateAgentAsync(
           model: modelDeploymentName,
           name: "my-agent",
           instructions: "You are a helpful agent.",
           tools: [ new AzureAISearchToolDefinition() ],
           toolResources: toolResource);
        #endregion
        #region Snippet:AgentsAzureAISearchExample_CreateRun
        // Create thread for communication
        PersistentAgentThread thread = await client.Threads.CreateThreadAsync();

        // Create message to thread
        PersistentThreadMessage message = await client.Messages.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "What is the temperature rating of the cozynights sleeping bag?");

        // Run the agent
        ThreadRun run = await client.Runs.CreateRunAsync(thread, agent);

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
        #region Snippet:AgentsPopulateReferencesAgentWithAzureAISearchTool
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
                    // We need to annotate only Agent messages.
                    if (threadMessage.Role == MessageRole.Agent && textItem.Annotations.Count > 0)
                    {
                        string annotatedText = textItem.Text;
                        foreach (MessageTextAnnotation annotation in textItem.Annotations)
                        {
                            if (annotation is MessageTextUriCitationAnnotation uriAnnotation)
                            {
                                annotatedText = annotatedText.Replace(
                                    uriAnnotation.Text,
                                    $" [see {uriAnnotation.UriCitation.Title}] ({uriAnnotation.UriCitation.Uri})");
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
        #region Snippet:AgentsAzureAISearchExample_Cleanup
        await client.Threads.DeleteThreadAsync(thread.Id);
        await client.Administration.DeleteAgentAsync(agent.Id);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void AzureAISearchExample()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var connectionID = System.Environment.GetEnvironmentVariable("AZURE_AI_CONNECTION_ID");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var connectionID = TestEnvironment.AI_SEARCH_CONNECTION_ID;
#endif
        #region Snippet:AgentsCreateAgentWithAzureAISearchTool_Sync
        AzureAISearchToolResource searchResource = new(
            connectionID,
            "sample_index",
            5,
            "category eq 'sleeping bag'",
            AzureAISearchQueryType.Simple
        );
        ToolResources toolResource = new()
        {
            AzureAISearch = searchResource
        };

        PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());

        PersistentAgent agent = client.Administration.CreateAgent(
           model: modelDeploymentName,
           name: "my-agent",
           instructions: "You are a helpful agent.",
           tools: [new AzureAISearchToolDefinition()],
           toolResources: toolResource);
        #endregion
        #region Snippet:AgentsAzureAISearchExample_CreateRun_Sync
        // Create thread for communication
        PersistentAgentThread thread = client.Threads.CreateThread();

        // Create message to thread
        PersistentThreadMessage message = client.Messages.CreateMessage(
            thread.Id,
            MessageRole.User,
            "What is the temperature rating of the cozynights sleeping bag?");

        // Run the agent
        Response<ThreadRun> runResponse = client.Runs.CreateRun(thread, agent);

        do
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(500));
            runResponse = client.Runs.GetRun(thread.Id, runResponse.Value.Id);
        }
        while (runResponse.Value.Status == RunStatus.Queued
            || runResponse.Value.Status == RunStatus.InProgress);

        Assert.AreEqual(
            RunStatus.Completed,
            runResponse.Value.Status,
            runResponse.Value.LastError?.Message);
        #endregion
        #region Snippet:AgentsPopulateReferencesAgentWithAzureAISearchTool_Sync
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
                    // We need to annotate only Agent messages.
                    if (threadMessage.Role == MessageRole.Agent && textItem.Annotations.Count > 0)
                    {
                        string annotatedText = textItem.Text;
                        foreach (MessageTextAnnotation annotation in textItem.Annotations)
                        {
                            if (annotation is MessageTextUriCitationAnnotation uriAnnotation)
                            {
                                annotatedText = annotatedText.Replace(
                                    uriAnnotation.Text,
                                    $" [see {uriAnnotation.UriCitation.Title}] ({uriAnnotation.UriCitation.Uri})");
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
        #region Snippet:AgentsAzureAISearchExample_Cleanup_Sync
        client.Threads.DeleteThread(thread.Id);
        client.Administration.DeleteAgent(agent.Id);
        #endregion
    }
}
