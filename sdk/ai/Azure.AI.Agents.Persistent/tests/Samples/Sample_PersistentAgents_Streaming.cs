// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Agents.Persistent.Tests
{
    public class Sample_PersistentAgents_Streaming : SamplesBase<AIAgentsTestEnvironment>
    {
        [Test]
        [AsyncOnly]
        public async Task StreamingAsync()
        {
            #region Snippet:AgentsStreamingAsync_CreateClient
#if SNIPPET
            var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
            var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
            var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
            var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
            PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());
            #endregion
            #region Snippet:AgentsStreamingAsync_CreateAgent
            PersistentAgent agent = await client.Administration.CreateAgentAsync(
                model: modelDeploymentName,
                name: "My Friendly Test Agent",
                instructions: "You politely help with math questions. Use the code interpreter tool when asked to visualize numbers.",
                tools: [ new CodeInterpreterToolDefinition() ]
            );
            #endregion
            # region Snippet:AgentsStreamingAsync_CreateThread
            PersistentAgentThread thread = await client.Threads.CreateThreadAsync();

            PersistentThreadMessage message = await client.Messages.CreateMessageAsync(
                thread.Id,
                MessageRole.User,
                "Hi, Agent! Draw a graph for a line with a slope of 4 and y-intercept of 9.");
            #endregion
            #region Snippet:AgentsStreamingAsync_StreamLoop
            await foreach (StreamingUpdate streamingUpdate in client.Runs.CreateRunStreamingAsync(thread.Id, agent.Id))
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
            #region Snippet:AgentsStreamingAsync_Cleanup
            await client.Threads.DeleteThreadAsync(thread.Id);
            await client.Administration.DeleteAgentAsync(agent.Id);
            #endregion
        }

        [Test]
        [SyncOnly]
        public void Streaming()
        {
#if SNIPPET
            var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
            var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
            var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
            var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
            PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());
            #region Snippet:AgentsStreaming_CreateAgent
            PersistentAgent agent = client.Administration.CreateAgent(
                model: modelDeploymentName,
                name: "My Friendly Test Agent",
                instructions: "You politely help with math questions. Use the code interpreter tool when asked to visualize numbers.",
                tools: [new CodeInterpreterToolDefinition()]
            );
            #endregion
            #region Snippet:AgentsStreaming_CreateThread
            PersistentAgentThread thread = client.Threads.CreateThread();

            PersistentThreadMessage message = client.Messages.CreateMessage(
                thread.Id,
                MessageRole.User,
                "Hi, Agent! Draw a graph for a line with a slope of 4 and y-intercept of 9.");
            #endregion
            #region Snippet:AgentsStreaming_StreamLoop
            foreach (StreamingUpdate streamingUpdate in client.Runs.CreateRunStreaming(thread.Id, agent.Id))
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
            #region Snippet:AgentsStreaming_Cleanup
            client.Threads.DeleteThread(thread.Id);
            client.Administration.DeleteAgent(agent.Id);
            #endregion
        }
    }
}
