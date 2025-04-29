// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Threading;
using OpenAI.Assistants;
using System.Text;

namespace Azure.AI.Projects.Tests;

public partial class Sample_Agents_Azure_AI_Search_Streaming : SamplesBase<AIProjectsTestEnvironment>
{
    [Test]
    [AsyncOnly]
    public async Task AzureAISearchStreamingExampleAsync()
    {
        #region Snippet:AzureAISearchStreamingExample_CreateProjectClient
#if SNIPPET
        var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        var projectClient = new AIProjectClient(connectionString, new DefaultAzureCredential());
        #endregion
        #region Snippet:AzureAISearchStreamingExample_CreateTool_Async
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
           tools: [new AzureAISearchToolDefinition()],
           toolResources: toolResource);
        #endregion
        #region Snippet:AzureAISearchStreamingExample_CreateThread_Async
        // Create thread for communication
        AgentThread thread = await agentClient.CreateThreadAsync();

        // Create message to thread
        ThreadMessage message = await agentClient.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "What is the temperature rating of the cozynights sleeping bag?");
        #endregion
        #region Snippet:AzureAISearchStreamingExample_PrintMessages_Async
        await foreach (StreamingUpdate streamingUpdate in agentClient.CreateRunStreamingAsync(thread.Id, agent.Id))
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
        #region Snippet:AzureAISearchStreamingExample_Cleanup_Async
        await agentClient.DeleteThreadAsync(thread.Id);
        await agentClient.DeleteAgentAsync(agent.Id);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void AzureAISearchStreamingExample()
    {
#if SNIPPET
        var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        var projectClient = new AIProjectClient(connectionString, new DefaultAzureCredential());
        #region Snippet:AzureAISearchStreamingExample_CreateTool
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
        #region Snippet:AzureAISearchStreamingExample_CreateThread
        // Create thread for communication
        AgentThread thread = agentClient.CreateThread();

        // Create message to thread
        ThreadMessage message = agentClient.CreateMessage(
            thread.Id,
            MessageRole.User,
            "What is the temperature rating of the cozynights sleeping bag?");
        #endregion
        #region Snippet:AzureAISearchStreamingExample_PrintMessages
        foreach (StreamingUpdate streamingUpdate in agentClient.CreateRunStreaming(thread.Id, agent.Id))
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
        #region Snippet:AzureAISearchStreamingExample_Cleanup
        agentClient.DeleteThread(thread.Id);
        agentClient.DeleteAgent(agent.Id);
        #endregion
    }
}
