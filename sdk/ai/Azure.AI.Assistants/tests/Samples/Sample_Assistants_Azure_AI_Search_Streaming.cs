// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Azure.AI.Assistants.Tests;

public partial class Sample_Assistants_Azure_AI_Search_Streaming : SamplesBase<AIAssistantsTestEnvironment>
{
    [Test]
    [AsyncOnly]
    public async Task AzureAISearchStreamingExampleAsync()
    {
        #region Snippet:AssistantsAzureAISearchStreamingExample_CreateProjectClient
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
        #region Snippet:AssistantsAzureAISearchStreamingExample_CreateTool_Async
        AISearchIndexResource indexList = new(connectionID, "sample_index")
        {
            QueryType = AzureAISearchQueryType.VectorSemanticHybrid
        };
        ToolResources searchResource = new ToolResources
        {
            AzureAISearch = new AzureAISearchResource
            {
                IndexList = { indexList }
            }
        };

        AssistantsClient client = new(connectionString, new DefaultAzureCredential());

        Assistant assistant = await client.CreateAssistantAsync(
           model: modelDeploymentName,
           name: "my-assistant",
           instructions: "You are a helpful assistant.",
           tools: [ new AzureAISearchToolDefinition() ],
           toolResources: searchResource);
        #endregion
        #region Snippet:AssistantsAzureAISearchStreamingExample_CreateThread_Async
        // Create thread for communication
        AssistantThread thread = await client.CreateThreadAsync();

        // Create message to thread
        ThreadMessage message = await client.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "What is the temperature rating of the cozynights sleeping bag?");
        #endregion
        #region Snippet:AssistantsAzureAISearchStreamingExample_PrintMessages_Async
        await foreach (StreamingUpdate streamingUpdate in client.CreateRunStreamingAsync(thread.Id, assistant.Id))
        {
            if (streamingUpdate.UpdateKind == StreamingUpdateReason.RunCreated)
            {
                Console.WriteLine("--- Run started! ---");
            }
            else if (streamingUpdate is MessageContentUpdate contentUpdate)
            {
                if (contentUpdate.TextAnnotation != null)
                {
                    Console.Write($" [see {contentUpdate.TextAnnotation.Title}] ({contentUpdate.TextAnnotation.Url})");
                }
                else
                {
                    //Detect the reference placeholder and skip it. Instead we will print the actual reference.
                    if (contentUpdate.Text[0] != (char)12304 || contentUpdate.Text[contentUpdate.Text.Length - 1] != (char)12305)
                        Console.Write(contentUpdate.Text);
                }
            }
            else if (streamingUpdate.UpdateKind == StreamingUpdateReason.RunCompleted)
            {
                Console.WriteLine();
                Console.WriteLine("--- Run completed! ---");
            }
        }
        #endregion
        #region Snippet:AssistantsAzureAISearchStreamingExample_Cleanup_Async
        await client.DeleteThreadAsync(thread.Id);
        await client.DeleteAssistantAsync(assistant.Id);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void AzureAISearchStreamingExample()
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
        #region Snippet:AssistantsAzureAISearchStreamingExample_CreateTool
        AISearchIndexResource indexList = new(connectionID, "sample_index")
        {
            QueryType = AzureAISearchQueryType.VectorSemanticHybrid
        };
        ToolResources searchResource = new ToolResources
        {
            AzureAISearch = new AzureAISearchResource
            {
                IndexList = { indexList }
            }
        };

        AssistantsClient client = new(connectionString, new DefaultAzureCredential());

        Assistant assistant = client.CreateAssistant(
           model: modelDeploymentName,
           name: "my-assistant",
           instructions: "You are a helpful assistant.",
           tools: [new AzureAISearchToolDefinition()],
           toolResources: searchResource);
        #endregion
        #region Snippet:AssistantsAzureAISearchStreamingExample_CreateThread
        // Create thread for communication
        AssistantThread thread = client.CreateThread();

        // Create message to thread
        ThreadMessage message = client.CreateMessage(
            thread.Id,
            MessageRole.User,
            "What is the temperature rating of the cozynights sleeping bag?");
        #endregion
        #region Snippet:AssistantsAzureAISearchStreamingExample_PrintMessages
        foreach (StreamingUpdate streamingUpdate in client.CreateRunStreaming(thread.Id, assistant.Id))
        {
            if (streamingUpdate.UpdateKind == StreamingUpdateReason.RunCreated)
            {
                Console.WriteLine("--- Run started! ---");
            }
            else if (streamingUpdate is MessageContentUpdate contentUpdate)
            {
                if (contentUpdate.TextAnnotation != null)
                {
                    Console.Write($" [see {contentUpdate.TextAnnotation.Title}] ({contentUpdate.TextAnnotation.Url})");
                }
                else
                {
                    //Detect the reference placeholder and skip it. Instead we will print the actual reference.
                    if (contentUpdate.Text[0] != (char)12304 || contentUpdate.Text[contentUpdate.Text.Length - 1] != (char)12305)
                        Console.Write(contentUpdate.Text);
                }
            }
            else if (streamingUpdate.UpdateKind == StreamingUpdateReason.RunCompleted)
            {
                Console.WriteLine();
                Console.WriteLine("--- Run completed! ---");
            }
        }
        #endregion
        #region Snippet:AssistantsAzureAISearchStreamingExample_Cleanup
        client.DeleteThread(thread.Id);
        client.DeleteAssistant(assistant.Id);
        #endregion
    }
}
