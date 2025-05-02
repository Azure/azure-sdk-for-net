// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Assistants.Tests
{
    public class Sample_Assistants_Streaming : SamplesBase<AIAssistantsTestEnvironment>
    {
        [Test]
        [AsyncOnly]
        public async Task StreamingAsync()
        {
            #region Snippet:AssistantsStreamingAsync_CreateClient
#if SNIPPET
            var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
            var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
            var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
            var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
            AssistantsClient client = new(projectEndpoint, new DefaultAzureCredential());
            #endregion
            #region Snippet:AssistantsStreamingAsync_CreateAgent
            Assistant assistant = await client.CreateAssistantAsync(
                model: modelDeploymentName,
                name: "My Friendly Test Assistant",
                instructions: "You politely help with math questions. Use the code interpreter tool when asked to visualize numbers.",
                tools: [ new CodeInterpreterToolDefinition() ]
            );
            #endregion
            # region Snippet:AssistantsStreamingAsync_CreateThread
            AssistantThread thread = await client.CreateThreadAsync();

            ThreadMessage message = await client.CreateMessageAsync(
                thread.Id,
                MessageRole.User,
                "Hi, Assistant! Draw a graph for a line with a slope of 4 and y-intercept of 9.");
            #endregion
            #region Snippet:AssistantsStreamingAsync_StreamLoop
            await foreach (StreamingUpdate streamingUpdate in client.CreateRunStreamingAsync(thread.Id, assistant.Id))
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
            #region Snippet:AssistantsStreamingAsync_Cleanup
            await client.DeleteThreadAsync(thread.Id);
            await client.DeleteAssistantAsync(assistant.Id);
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
            AssistantsClient client = new(projectEndpoint, new DefaultAzureCredential());
            #region Snippet:AssistantsStreaming_CreateAgent
            Assistant assistant = client.CreateAssistant(
                model: modelDeploymentName,
                name: "My Friendly Test Assistant",
                instructions: "You politely help with math questions. Use the code interpreter tool when asked to visualize numbers.",
                tools: [new CodeInterpreterToolDefinition()]
            );
            #endregion
            #region Snippet:AssistantsStreaming_CreateThread
            AssistantThread thread = client.CreateThread();

            ThreadMessage message = client.CreateMessage(
                thread.Id,
                MessageRole.User,
                "Hi, Assistant! Draw a graph for a line with a slope of 4 and y-intercept of 9.");
            #endregion
            #region Snippet:AssistantsStreaming_StreamLoop
            foreach (StreamingUpdate streamingUpdate in client.CreateRunStreaming(thread.Id, assistant.Id))
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
            #region Snippet:AssistantsStreaming_Cleanup
            client.DeleteThread(thread.Id);
            client.DeleteAssistant(assistant.Id);
            #endregion
        }
    }
}
