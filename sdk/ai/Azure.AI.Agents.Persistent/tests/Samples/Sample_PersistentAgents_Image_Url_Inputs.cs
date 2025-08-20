// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Agents.Persistent.Tests
{
    /// <summary>
    /// Demonstrates examples of sending an image URL (along with optional text)
    /// as a structured content block in a single message.
    /// </summary>
    /// <remarks>
    /// The examples shows how to create an agent, open a thread,
    /// post content blocks combining text and image inputs,
    /// and then run the agent to see how it interprets the multimedia input.
    /// </remarks>
    public partial class Sample_PersistentAgents_ImageUrlInputs : SamplesBase<AIAgentsTestEnvironment>
    {
        [Test]
        [AsyncOnly]
        public async Task ImageUrlInMessageExampleAsync()
        {
            #region Snippet:AgentImageUrlInMessageCreateClient
#if SNIPPET
            var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
            var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
            var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
            var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
            // Create an AgentsClient, enabling agent-management and messaging.
            PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());
            #endregion

            // Step 1: Create an agent
            #region Snippet:AgentImageUrlInMessageCreateAgent
            PersistentAgent agent = await client.Administration.CreateAgentAsync(
                model: modelDeploymentName,
                name: "Image Understanding Agent",
                instructions: "You are an image-understanding agent. Analyze images and provide textual descriptions."
            );
            #endregion

            // Step 2: Create a thread
            #region Snippet:AgentImageUrlInMessageCreateThread
            PersistentAgentThread thread = await client.Threads.CreateThreadAsync();
            #endregion

            // Step 3: Create a message using multiple content blocks.
            // Here we combine a short text and an image URL in a single user message.
            #region Snippet:AgentImageUrlInMessageCreateMessage
            MessageImageUriParam imageUrlParam = new(
                uri: "https://upload.wikimedia.org/wikipedia/commons/thumb/d/dd/Gfp-wisconsin-madison-the-nature-boardwalk.jpg/2560px-Gfp-wisconsin-madison-the-nature-boardwalk.jpg"
            );
            imageUrlParam.Detail = ImageDetailLevel.High;
            var contentBlocks = new List<MessageInputContentBlock>
            {
                new MessageInputTextBlock("Could you describe this image?"),
                new MessageInputImageUriBlock(imageUrlParam)
            };

            PersistentThreadMessage imageMessage = await client.Messages.CreateMessageAsync(
                threadId: thread.Id,
                role: MessageRole.User,
                contentBlocks: contentBlocks
            );
            #endregion

            // Step 4: Run the agent against the thread that now has an image to analyze.
            #region Snippet:AgentImageUrlInMessageCreateRun
            ThreadRun run = await client.Runs.CreateRunAsync(
                threadId: thread.Id,
                assistantId: agent.Id
            );
            #endregion

            // Step 5: Wait for the run to complete.
            #region Snippet:AgentImageUrlInMessageWaitForRun
            do
            {
                await Task.Delay(TimeSpan.FromMilliseconds(500));
                run = await client.Runs.GetRunAsync(thread.Id, run.Id);
            }
            while (run.Status == RunStatus.Queued || run.Status == RunStatus.InProgress);

            if (run.Status != RunStatus.Completed)
            {
                throw new InvalidOperationException($"Run failed or was canceled: {run.LastError?.Message}");
            }
            #endregion

            // Step 6: Retrieve messages (including how the agent responds) and print their contents.
            #region Snippet:AgentImageUrlInMessageReview
            AsyncPageable<PersistentThreadMessage> messages = client.Messages.GetMessagesAsync(thread.Id);

            await foreach (PersistentThreadMessage msg in messages)
            {
                Console.WriteLine($"{msg.CreatedAt:yyyy-MM-dd HH:mm:ss} - {msg.Role,10}:");

                foreach (MessageContent content in msg.ContentItems)
                {
                    switch (content)
                    {
                        case MessageTextContent textItem:
                            Console.WriteLine($"  Text: {textItem.Text}");
                            break;

                        case MessageImageFileContent fileItem:
                            Console.WriteLine($"  Image File (internal ID): {fileItem.FileId}");
                            break;
                    }
                }
            }
            #endregion

            // Step 7: Cleanup
            #region Snippet:AgentImageUrlInMessageCleanup
            await client.Threads.DeleteThreadAsync(thread.Id);
            await client.Administration.DeleteAgentAsync(agent.Id);
            #endregion
        }

        [Test]
        [SyncOnly]
        public void ImageUrlInMessageExample()
        {
#if SNIPPET
            var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
            var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
            var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
            var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
            // Create an AgentsClient, enabling agent-management and messaging.
            PersistentAgentsClient client = new PersistentAgentsClient(projectEndpoint, new DefaultAzureCredential());

            // Step 1: Create an agent
            #region Snippet:AgentImageUrlInMessageCreateAgent_Sync
            PersistentAgent agent = client.Administration.CreateAgent(
                model: modelDeploymentName,
                name: "Image Understanding Agent",
                instructions: "You are an image-understanding agent. Analyze images and provide textual descriptions."
            );
            #endregion

            // Step 2: Create a thread
            #region Snippet:AgentImageUrlInMessageCreateThread_Sync
            PersistentAgentThread thread = client.Threads.CreateThread();
            #endregion

            // Step 3: Create a message using multiple content blocks.
            // Here we combine a short text and an image URL in a single user message.
            #region Snippet:AgentImageUrlInMessageCreateMessage_Sync
            MessageImageUriParam imageUrlParam = new(
                uri: "https://upload.wikimedia.org/wikipedia/commons/thumb/d/dd/Gfp-wisconsin-madison-the-nature-boardwalk.jpg/2560px-Gfp-wisconsin-madison-the-nature-boardwalk.jpg"
            );
            imageUrlParam.Detail = ImageDetailLevel.High;

            var contentBlocks = new List<MessageInputContentBlock>
            {
                new MessageInputTextBlock("Could you describe this image?"),
                new MessageInputImageUriBlock(imageUrlParam)
            };

            PersistentThreadMessage imageMessage = client.Messages.CreateMessage(
                threadId: thread.Id,
                role: MessageRole.User,
                contentBlocks: contentBlocks
            );
            #endregion

            // Step 4: Run the agent against the thread that has an image to analyze.
            #region Snippet:AgentImageUrlInMessageCreateRun_Sync
            ThreadRun run = client.Runs.CreateRun(
                threadId: thread.Id,
                assistantId: agent.Id
            );
            #endregion

            // Step 5: Wait for the run to complete.
            #region Snippet:AgentImageUrlInMessageWaitForRun_Sync
            do
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                run = client.Runs.GetRun(thread.Id, run.Id);
            }
            while (run.Status == RunStatus.Queued || run.Status == RunStatus.InProgress);

            if (run.Status != RunStatus.Completed)
            {
                throw new InvalidOperationException($"Run failed or was canceled: {run.LastError?.Message}");
            }
            #endregion

            // Step 6: Retrieve messages (including how the agent responds) and print their contents.
            #region Snippet:AgentImageUrlInMessageReview_Sync
            Pageable<PersistentThreadMessage> messages = client.Messages.GetMessages(thread.Id);

            foreach (PersistentThreadMessage msg in messages)
            {
                Console.WriteLine($"{msg.CreatedAt:yyyy-MM-dd HH:mm:ss} - {msg.Role,10}:");

                foreach (MessageContent content in msg.ContentItems)
                {
                    switch (content)
                    {
                        case MessageTextContent textItem:
                            Console.WriteLine($"  Text: {textItem.Text}");
                            break;

                        case MessageImageFileContent fileItem:
                            Console.WriteLine($"  Image File (internal ID): {fileItem.FileId}");
                            break;
                    }
                }
            }
            #endregion

            // Step 7: Cleanup
            #region Snippet:AgentImageUrlInMessageCleanup_Sync
            client.Threads.DeleteThread(thread.Id);
            client.Administration.DeleteAgent(agent.Id);
            #endregion
        }
    }
}
