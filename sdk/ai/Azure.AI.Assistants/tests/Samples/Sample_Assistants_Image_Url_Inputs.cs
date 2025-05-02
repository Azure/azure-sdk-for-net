// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Assistants.Tests
{
    /// <summary>
    /// Demonstrates examples of sending an image URL (along with optional text)
    /// as a structured content block in a single message.
    /// </summary>
    /// <remarks>
    /// The examples shows how to create an assistant, open a thread,
    /// post content blocks combining text and image inputs,
    /// and then run the assistant to see how it interprets the multimedia input.
    /// </remarks>
    public partial class Sample_Assistants_ImageUrlInputs : SamplesBase<AIAssistantsTestEnvironment>
    {
        [Test]
        [AsyncOnly]
        public async Task ImageUrlInMessageExampleAsync()
        {
            #region Snippet:AssistantImageUrlInMessageCreateClient
#if SNIPPET
            var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
            var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
            var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
            var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
            // Create an AssistantsClient, enabling assistant-management and messaging.
            AssistantsClient client = new(projectEndpoint, new DefaultAzureCredential());
            #endregion

            // Step 1: Create an assistant
            #region Snippet:AssistantImageUrlInMessageCreateAssistant
            Assistant assistant = await client.CreateAssistantAsync(
                model: modelDeploymentName,
                name: "Image Understanding Assistant",
                instructions: "You are an image-understanding assistant. Analyze images and provide textual descriptions."
            );
            #endregion

            // Step 2: Create a thread
            #region Snippet:AssistantImageUrlInMessageCreateThread
            AssistantThread thread = await client.CreateThreadAsync();
            #endregion

            // Step 3: Create a message using multiple content blocks.
            // Here we combine a short text and an image URL in a single user message.
            #region Snippet:AssistantImageUrlInMessageCreateMessage
            MessageImageUrlParam imageUrlParam = new MessageImageUrlParam(
                url: "https://upload.wikimedia.org/wikipedia/commons/thumb/d/dd/Gfp-wisconsin-madison-the-nature-boardwalk.jpg/2560px-Gfp-wisconsin-madison-the-nature-boardwalk.jpg"
            );
            imageUrlParam.Detail = ImageDetailLevel.High;
            var contentBlocks = new List<MessageInputContentBlock>
            {
                new MessageInputTextBlock("Could you describe this image?"),
                new MessageInputImageUrlBlock(imageUrlParam)
            };

            ThreadMessage imageMessage = await client.CreateMessageAsync(
                threadId: thread.Id,
                role: MessageRole.User,
                contentBlocks: contentBlocks
            );
            #endregion

            // Step 4: Run the assistant against the thread that now has an image to analyze.
            #region Snippet:AssistantImageUrlInMessageCreateRun
            ThreadRun run = await client.CreateRunAsync(
                threadId: thread.Id,
                assistantId: assistant.Id
            );
            #endregion

            // Step 5: Wait for the run to complete.
            #region Snippet:AssistantImageUrlInMessageWaitForRun
            do
            {
                await Task.Delay(TimeSpan.FromMilliseconds(500));
                run = await client.GetRunAsync(thread.Id, run.Id);
            }
            while (run.Status == RunStatus.Queued || run.Status == RunStatus.InProgress);

            if (run.Status != RunStatus.Completed)
            {
                throw new InvalidOperationException($"Run failed or was canceled: {run.LastError?.Message}");
            }
            #endregion

            // Step 6: Retrieve messages (including how the assistant responds) and print their contents.
            #region Snippet:AssistantImageUrlInMessageReview
            PageableList<ThreadMessage> messages = await client.GetMessagesAsync(thread.Id);

            foreach (ThreadMessage msg in messages)
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
            #region Snippet:AssistantImageUrlInMessageCleanup
            await client.DeleteThreadAsync(thread.Id);
            await client.DeleteAssistantAsync(assistant.Id);
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
            // Create an AssistantsClient, enabling assistant-management and messaging.
            AssistantsClient client = new AssistantsClient(projectEndpoint, new DefaultAzureCredential());

            // Step 1: Create an assistant
            #region Snippet:AssistantImageUrlInMessageCreateAssistant_Sync
            Assistant assistant = client.CreateAssistant(
                model: modelDeploymentName,
                name: "Image Understanding Assistant",
                instructions: "You are an image-understanding assistant. Analyze images and provide textual descriptions."
            );
            #endregion

            // Step 2: Create a thread
            #region Snippet:AssistantImageUrlInMessageCreateThread_Sync
            AssistantThread thread = client.CreateThread();
            #endregion

            // Step 3: Create a message using multiple content blocks.
            // Here we combine a short text and an image URL in a single user message.
            #region Snippet:AssistantImageUrlInMessageCreateMessage_Sync
            MessageImageUrlParam imageUrlParam = new MessageImageUrlParam(
                url: "https://upload.wikimedia.org/wikipedia/commons/thumb/d/dd/Gfp-wisconsin-madison-the-nature-boardwalk.jpg/2560px-Gfp-wisconsin-madison-the-nature-boardwalk.jpg"
            );
            imageUrlParam.Detail = ImageDetailLevel.High;

            var contentBlocks = new List<MessageInputContentBlock>
            {
                new MessageInputTextBlock("Could you describe this image?"),
                new MessageInputImageUrlBlock(imageUrlParam)
            };

            ThreadMessage imageMessage = client.CreateMessage(
                threadId: thread.Id,
                role: MessageRole.User,
                contentBlocks: contentBlocks
            );
            #endregion

            // Step 4: Run the assistant against the thread that has an image to analyze.
            #region Snippet:AssistantImageUrlInMessageCreateRun_Sync
            ThreadRun run = client.CreateRun(
                threadId: thread.Id,
                assistantId: assistant.Id
            );
            #endregion

            // Step 5: Wait for the run to complete.
            #region Snippet:AssistantImageUrlInMessageWaitForRun_Sync
            do
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                run = client.GetRun(thread.Id, run.Id);
            }
            while (run.Status == RunStatus.Queued || run.Status == RunStatus.InProgress);

            if (run.Status != RunStatus.Completed)
            {
                throw new InvalidOperationException($"Run failed or was canceled: {run.LastError?.Message}");
            }
            #endregion

            // Step 6: Retrieve messages (including how the assistant responds) and print their contents.
            #region Snippet:AssistantImageUrlInMessageReview_Sync
            PageableList<ThreadMessage> messages = client.GetMessages(thread.Id);

            foreach (ThreadMessage msg in messages)
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
            #region Snippet:AssistantImageUrlInMessageCleanup_Sync
            client.DeleteThread(thread.Id);
            client.DeleteAssistant(assistant.Id);
            #endregion
        }
    }
}
