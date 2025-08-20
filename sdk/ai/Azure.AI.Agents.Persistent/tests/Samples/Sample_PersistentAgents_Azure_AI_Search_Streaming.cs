// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Azure.AI.Agents.Persistent.Tests;

public partial class Sample_PersistentAgents_Azure_AI_Search_Streaming : SamplesBase<AIAgentsTestEnvironment>
{
    [Test]
    [AsyncOnly]
    public async Task AzureAISearchStreamingExampleAsync()
    {
        #region Snippet:AgentsAzureAISearchStreamingExample_CreateProjectClient
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
        #region Snippet:AgentsAzureAISearchStreamingExample_CreateTool_Async
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
        #region Snippet:AgentsAzureAISearchStreamingExample_CreateThread_Async
        // Create thread for communication
        PersistentAgentThread thread = await client.Threads.CreateThreadAsync();

        // Create message to thread
        PersistentThreadMessage message = await client.Messages.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "What is the temperature rating of the cozynights sleeping bag?");
        #endregion
        #region Snippet:AgentsAzureAISearchStreamingExample_PrintMessages_Async
        await foreach (StreamingUpdate streamingUpdate in client.Runs.CreateRunStreamingAsync(thread.Id, agent.Id))
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
        #region Snippet:AgentsAzureAISearchStreamingExample_Cleanup_Async
        await client.Threads.DeleteThreadAsync(thread.Id);
        await client.Administration.DeleteAgentAsync(agent.Id);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void AzureAISearchStreamingExample()
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
        #region Snippet:AgentsAzureAISearchStreamingExample_CreateTool
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
        #region Snippet:AgentsAzureAISearchStreamingExample_CreateThread
        // Create thread for communication
        PersistentAgentThread thread = client.Threads.CreateThread();

        // Create message to thread
        PersistentThreadMessage message = client.Messages.CreateMessage(
            thread.Id,
            MessageRole.User,
            "What is the temperature rating of the cozynights sleeping bag?");
        #endregion
        #region Snippet:AgentsAzureAISearchStreamingExample_PrintMessages
        foreach (StreamingUpdate streamingUpdate in client.Runs.CreateRunStreaming(thread.Id, agent.Id))
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
        #region Snippet:AgentsAzureAISearchStreamingExample_Cleanup
        client.Threads.DeleteThread(thread.Id);
        client.Administration.DeleteAgent(agent.Id);
        #endregion
    }
}
