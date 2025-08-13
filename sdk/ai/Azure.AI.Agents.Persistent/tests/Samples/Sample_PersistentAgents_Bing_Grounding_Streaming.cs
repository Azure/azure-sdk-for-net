// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Agents.Persistent.Tests;

public partial class Sample_PersistentAgents_Bing_Grounding_Streaming : SamplesBase<AIAgentsTestEnvironment>
{
    [Test]
    [AsyncOnly]
    public async Task BingGroundingStreamingExampleAsync()
    {
        #region Snippet:AgentsBingGroundingStreaming_CreateProject
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var connectionId = System.Environment.GetEnvironmentVariable("AZURE_BING_CONNECTION_ID");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var connectionId = TestEnvironment.BING_CONNECTION_ID;
#endif
        PersistentAgentsClient agentClient = new(projectEndpoint, new DefaultAzureCredential());
        #endregion
        #region Snippet:AgentsBingGroundingStreaming_GetConnection
        BingGroundingToolDefinition bingGroundingTool = new(
            new BingGroundingSearchToolParameters(
                [new BingGroundingSearchConfiguration(connectionId)]
            )
        );
        #endregion
        #region Snippet:AgentsBingGroundingStreamingAsync_CreateAgent
        // NOTE: To reuse existing agent, fetch it with agentClient.Administration.GetAgent(agentId)
        PersistentAgent agent = await agentClient.Administration.CreateAgentAsync(
           model: modelDeploymentName,
           name: "my-agent",
           instructions: "You are a helpful agent.",
           tools: [ bingGroundingTool ]);
        #endregion
        // Create thread for communication
        #region Snippet:AgentsBingGroundingStreamingAsync_CreateThreadMessageAndStream
        PersistentAgentThread thread = await agentClient.Threads.CreateThreadAsync();

        // Create message to thread
        PersistentThreadMessage message = await agentClient.Messages.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "How does wikipedia explain Euler's Identity?");

        // Create the stream.
        AsyncCollectionResult<StreamingUpdate> stream = agentClient.Runs.CreateRunStreamingAsync(thread.Id, agent.Id);
        await foreach (StreamingUpdate streamingUpdate in stream)
        {
            ParseStreamingUpdate(streamingUpdate);
        }
        #endregion

        #region Snippet:AgentsBingGroundingStreamingCleanupAsync
        // NOTE: Comment out these two lines if you plan to reuse the agent later.
        await agentClient.Threads.DeleteThreadAsync(threadId: thread.Id);
        await agentClient.Administration.DeleteAgentAsync(agentId: agent.Id);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void BingGroundingStreamingExample()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var connectionId = System.Environment.GetEnvironmentVariable("AZURE_BING_CONNECTION_ID");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var connectionId = TestEnvironment.BING_CONNECTION_ID;
#endif
        PersistentAgentsClient agentClient = new(projectEndpoint, new DefaultAzureCredential());
        BingGroundingToolDefinition bingGroundingTool = new(
            new BingGroundingSearchToolParameters(
                [new BingGroundingSearchConfiguration(connectionId)]
            )
        );
        #region Snippet:AgentsBingGroundingStreaming_CreateAgent
        // NOTE: To reuse existing agent, fetch it with agentClient.Administration.GetAgent(agentId)
        PersistentAgent agent = agentClient.Administration.CreateAgent(
           model: modelDeploymentName,
           name: "my-agent",
           instructions: "You are a helpful agent.",
           tools: [bingGroundingTool]);
        #endregion
        // Create thread for communication
        #region Snippet:AgentsBingGroundingStreaming_CreateThreadMessageAndStream
        PersistentAgentThread thread = agentClient.Threads.CreateThread();

        // Create message to thread
        PersistentThreadMessage message = agentClient.Messages.CreateMessage(
            thread.Id,
            MessageRole.User,
            "How does wikipedia explain Euler's Identity?");

        // Create the stream.
        CollectionResult<StreamingUpdate> stream = agentClient.Runs.CreateRunStreaming(thread.Id, agent.Id);
        foreach (StreamingUpdate streamingUpdate in stream)
        {
            ParseStreamingUpdate(streamingUpdate);
        }
        #endregion
        #region Snippet:AgentsBingGroundingStreamingCleanup
        // NOTE: Comment out these two lines if you plan to reuse the agent later.
        agentClient.Threads.DeleteThread(threadId: thread.Id);
        agentClient.Administration.DeleteAgent(agentId: agent.Id);
        #endregion
    }

    #region Snippet:AgentsBingGroundingStreaming_Print
    private static void ParseStreamingUpdate(StreamingUpdate streamingUpdate)
    {
        if (streamingUpdate.UpdateKind == StreamingUpdateReason.RunCreated)
        {
            Console.WriteLine("--- Run started! ---");
        }
        else if (streamingUpdate is MessageContentUpdate contentUpdate)
        {
            if (contentUpdate.TextAnnotation is TextAnnotationUpdate uriAnnotation)
            {
                Console.Write($" [see {uriAnnotation.Title}]({uriAnnotation.Url})");
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
        else if (streamingUpdate is RunStepUpdate runStepUpdate)
        {
            if (runStepUpdate.Value.StepDetails is RunStepToolCallDetails toolCallDetails)
            {
                foreach (RunStepToolCall call in toolCallDetails.ToolCalls)
                {
                    if (call is RunStepBingGroundingToolCall bingCall)
                    {
                        if (bingCall.BingGrounding.TryGetValue("requesturl", out string reqURI))
                            Console.WriteLine($"Request url: {reqURI}");
                    }
                }
            }
        }
        else if (streamingUpdate.UpdateKind == StreamingUpdateReason.RunFailed && streamingUpdate is RunUpdate errorStep)
        {
            throw new InvalidOperationException($"Error: {errorStep.Value.LastError}");
        }
    }
    #endregion
}
