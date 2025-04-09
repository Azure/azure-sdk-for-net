// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Threading;

namespace Azure.AI.Assistants.Tests;

public partial class Sample_Assistants_Azure_AI_Search : SamplesBase<AIAssistantsTestEnvironment>
{
    [Test]
    [AsyncOnly]
    public async Task AzureAISearchExampleAsync()
    {
        #region Snippet:AssistantsAzureAISearchExample_CreateProjectClient
#if SNIPPET
        var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var connectionID = System.Environment.GetEnvironmentVariable("AZURE_AI_CONNECTION_ID");
#else
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var connectionID = TestEnvironment.AI_SEARCH_CONNECTION_ID;
#endif
        #endregion
        #region Snippet:AssistantsCreateAgentWithAzureAISearchTool
        AzureAISearchResource searchResource = new(
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

        AssistantsClient client = new(connectionString, new DefaultAzureCredential());

        Assistant assistant = await client.CreateAssistantAsync(
           model: modelDeploymentName,
           name: "my-assistant",
           instructions: "You are a helpful assistant.",
           tools: [ new AzureAISearchToolDefinition() ],
           toolResources: toolResource);
        #endregion
        #region Snippet:AssistantsAzureAISearchExample_CreateRun
        // Create thread for communication
        AssistantThread thread = await client.CreateThreadAsync();

        // Create message to thread
        ThreadMessage message = await client.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "What is the temperature rating of the cozynights sleeping bag?");

        // Run the agent
        ThreadRun run = await client.CreateRunAsync(thread, assistant);

        do
        {
            await Task.Delay(TimeSpan.FromMilliseconds(500));
            run = await client.GetRunAsync(thread.Id, run.Id);
        }
        while (run.Status == RunStatus.Queued
            || run.Status == RunStatus.InProgress);

        Assert.AreEqual(
            RunStatus.Completed,
            run.Status,
            run.LastError?.Message);
        #endregion
        #region Snippet:AssistantsPopulateReferencesAgentWithAzureAISearchTool
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
                    // We need to annotate only Agent messages.
                    if (threadMessage.Role == MessageRole.Assistant && textItem.Annotations.Count > 0)
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
        #region Snippet:AssistantsAzureAISearchExample_Cleanup
        await client.DeleteThreadAsync(thread.Id);
        await client.DeleteAssistantAsync(assistant.Id);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void AzureAISearchExample()
    {
#if SNIPPET
        var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var connectionID = System.Environment.GetEnvironmentVariable("AZURE_AI_CONNECTION_ID");
#else
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var connectionID = TestEnvironment.AI_SEARCH_CONNECTION_ID;
#endif
        #region Snippet:AssistantsCreateAgentWithAzureAISearchTool_Sync
        AzureAISearchResource searchResource = new(
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

        AssistantsClient client = new(connectionString, new DefaultAzureCredential());

        Assistant assistant = client.CreateAssistant(
           model: modelDeploymentName,
           name: "my-assistant",
           instructions: "You are a helpful assistant.",
           tools: [new AzureAISearchToolDefinition()],
           toolResources: toolResource);
        #endregion
        #region Snippet:AssistantsAzureAISearchExample_CreateRun_Sync
        // Create thread for communication
        AssistantThread thread = client.CreateThread();

        // Create message to thread
        ThreadMessage message = client.CreateMessage(
            thread.Id,
            MessageRole.User,
            "What is the temperature rating of the cozynights sleeping bag?");

        // Run the agent
        Response<ThreadRun> runResponse = client.CreateRun(thread, assistant);

        do
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(500));
            runResponse = client.GetRun(thread.Id, runResponse.Value.Id);
        }
        while (runResponse.Value.Status == RunStatus.Queued
            || runResponse.Value.Status == RunStatus.InProgress);

        Assert.AreEqual(
            RunStatus.Completed,
            runResponse.Value.Status,
            runResponse.Value.LastError?.Message);
        #endregion
        #region Snippet:AssistantsPopulateReferencesAgentWithAzureAISearchTool_Sync
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
                    // We need to annotate only Agent messages.
                    if (threadMessage.Role == MessageRole.Assistant && textItem.Annotations.Count > 0)
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
        #region Snippet:AssistantsAzureAISearchExample_Cleanup_Sync
        client.DeleteThread(thread.Id);
        client.DeleteAssistant(assistant.Id);
        #endregion
    }
}
