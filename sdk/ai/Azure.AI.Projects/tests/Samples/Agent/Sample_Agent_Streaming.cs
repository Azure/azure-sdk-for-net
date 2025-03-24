// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests
{
    public class Sample_Agent_Streaming : SamplesBase<AIProjectsTestEnvironment>
    {
        [Test]
        [AsyncOnly]
        public async Task StreamingAsync()
        {
            #region Snippet:StreamingAsync_CreateClient
#if SNIPPET
            var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
            var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
            var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
            var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
            AgentsClient client = new(connectionString, new DefaultAzureCredential());
            #endregion
            #region Snippet:StreamingAsync_CreateAgent
            Agent agent = await client.CreateAgentAsync(
                model: modelDeploymentName,
                name: "My Friendly Test Assistant",
                instructions: "You politely help with math questions. Use the code interpreter tool when asked to visualize numbers.",
                tools: [ new CodeInterpreterToolDefinition() ]
            );
            #endregion
            # region Snippet:StreamingAsync_CreateThread
            AgentThread thread = await client.CreateThreadAsync();

            ThreadMessage message = await client.CreateMessageAsync(
                thread.Id,
                MessageRole.User,
                "Hi, Assistant! Draw a graph for a line with a slope of 4 and y-intercept of 9.");
            #endregion
            #region Snippet:StreamingAsync_StreamLoop
            await foreach (StreamingUpdate streamingUpdate in client.CreateRunStreamingAsync(thread.Id, agent.Id))
            {
                if (streamingUpdate.UpdateKind == StreamingUpdateReason.RunCreated)
                {
                    Console.WriteLine($"--- Run started! ---");
                }
                else if (streamingUpdate is MessageContentUpdate contentUpdate)
                {
                    Console.Write(contentUpdate.Text);
                    if (contentUpdate.ImageFileId is not null)
                    {
                        Console.WriteLine($"[Image content file ID: {contentUpdate.ImageFileId}");
                    }
                }
            }
            #endregion
            #region Snippet::StreamingAsync_Cleanup
            await client.DeleteThreadAsync(thread.Id);
            await client.DeleteAgentAsync(agent.Id);
            #endregion
        }

        [Test]
        [SyncOnly]
        public void Streaming()
        {
#if SNIPPET
            var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
            var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
            var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
            var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
            AgentsClient client = new(connectionString, new DefaultAzureCredential());
            #region Snippet:Streaming_CreateAgent
            Agent agent = client.CreateAgent(
                model: modelDeploymentName,
                name: "My Friendly Test Assistant",
                instructions: "You politely help with math questions. Use the code interpreter tool when asked to visualize numbers.",
                tools: [new CodeInterpreterToolDefinition()]
            );
            #endregion
            #region Snippet:Streaming_CreateThread
            AgentThread thread = client.CreateThread();

            ThreadMessage message = client.CreateMessage(
                thread.Id,
                MessageRole.User,
                "Hi, Assistant! Draw a graph for a line with a slope of 4 and y-intercept of 9.");
            #endregion
            #region Snippet:Streaming_StreamLoop
            foreach (StreamingUpdate streamingUpdate in client.CreateRunStreaming(thread.Id, agent.Id))
            {
                if (streamingUpdate.UpdateKind == StreamingUpdateReason.RunCreated)
                {
                    Console.WriteLine($"--- Run started! ---");
                }
                else if (streamingUpdate is MessageContentUpdate contentUpdate)
                {
                    Console.Write(contentUpdate.Text);
                    if (contentUpdate.ImageFileId is not null)
                    {
                        Console.WriteLine($"[Image content file ID: {contentUpdate.ImageFileId}");
                    }
                }
            }
            #endregion
            #region Snippet::Streaming_Cleanup
            client.DeleteThread(thread.Id);
            client.DeleteAgent(agent.Id);
            #endregion
        }
    }
}
