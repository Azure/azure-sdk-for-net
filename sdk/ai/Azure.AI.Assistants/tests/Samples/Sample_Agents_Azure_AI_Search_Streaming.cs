// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Azure.AI.Assistants.Tests;

public partial class Sample_Agents_Azure_AI_Search_Streaming : SamplesBase<AIAssistantsTestEnvironment>
{
    [Test]
    [AsyncOnly]
    public async Task AzureAISearchStreamingExampleAsync()
    {
        #region Snippet:AssistantsAzureAISearchStreamingExample_CreateProjectClient
#if SNIPPET
        var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var projectClient = new AIProjectClient(connectionString, new DefaultAzureCredential());
#else
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        #endregion
        #region Snippet:AssistantsAzureAISearchStreamingExample_CreateTool_Async
#if SNIPPET
        ListConnectionsResponse connections = await projectClient.GetConnectionsClient().GetConnectionsAsync(ConnectionType.AzureAISearch).ConfigureAwait(false);

        if (connections?.Value == null || connections.Value.Count == 0)
        {
            throw new InvalidOperationException("No connections found for the Azure AI Search.");
        }

        ConnectionResponse connection = connections.Value[0];

        var connectionID = connection.Id;
#else
        var connectionID = TestEnvironment.AI_SEARCH_CONNECTION_ID;
#endif
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

        AIAssistantClient agentClient = new(connectionString, new DefaultAzureCredential());

        Agent agent = await agentClient.CreateAgentAsync(
           model: modelDeploymentName,
           name: "my-assistant",
           instructions: "You are a helpful assistant.",
           tools: [ new AzureAISearchToolDefinition() ],
           toolResources: searchResource);
        #endregion
        #region Snippet:AssistantsAzureAISearchStreamingExample_CreateThread_Async
        // Create thread for communication
        AgentThread thread = await agentClient.CreateThreadAsync();

        // Create message to thread
        ThreadMessage message = await agentClient.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "What is the temperature rating of the cozynights sleeping bag?");
        #endregion
        #region Snippet:AssistantsAzureAISearchStreamingExample_PrintMessages_Async
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
        #region Snippet:AssistantsAzureAISearchStreamingExample_Cleanup_Async
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
        var projectClient = new AIProjectClient(connectionString, new DefaultAzureCredential());
#else
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        #region Snippet:AssistantsAzureAISearchStreamingExample_CreateTool
#if SNIPPET
        ListConnectionsResponse connections = projectClient.GetConnectionsClient().GetConnections(ConnectionType.AzureAISearch);

        if (connections?.Value == null || connections.Value.Count == 0)
        {
            throw new InvalidOperationException("No connections found for the Azure AI Search.");
        }

        ConnectionResponse connection = connections.Value[0];
        var connectionID = connection.Id;
#else
        var connectionID = TestEnvironment.AI_SEARCH_CONNECTION_ID;
#endif
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

        AIAssistantClient agentClient = new(connectionString, new DefaultAzureCredential());

        Agent agent = agentClient.CreateAgent(
           model: modelDeploymentName,
           name: "my-assistant",
           instructions: "You are a helpful assistant.",
           tools: [new AzureAISearchToolDefinition()],
           toolResources: searchResource);
        #endregion
        #region Snippet:AssistantsAzureAISearchStreamingExample_CreateThread
        // Create thread for communication
        AgentThread thread = agentClient.CreateThread();

        // Create message to thread
        ThreadMessage message = agentClient.CreateMessage(
            thread.Id,
            MessageRole.User,
            "What is the temperature rating of the cozynights sleeping bag?");
        #endregion
        #region Snippet:AssistantsAzureAISearchStreamingExample_PrintMessages
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
        #region Snippet:AssistantsAzureAISearchStreamingExample_Cleanup
        agentClient.DeleteThread(thread.Id);
        agentClient.DeleteAgent(agent.Id);
        #endregion
    }
}
