// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests
{
    /// <summary>
    /// Demonstrates examples of sending an image URL and image file (along with optional text)
    /// as a structured content block in a single message.
    /// </summary>
    /// <remarks>
    /// The examples shows how to create an agent, open a thread,
    /// post content blocks combining text and image inputs,
    /// and then run the agent to see how it interprets the multimedia input.
    /// </remarks>
    public partial class Sample_Agent_ContentBlocks : SamplesBase<AIProjectsTestEnvironment>
    {
        [Test]
        [AsyncOnly]
        public async Task ImageUrlInMessageExampleAsync()
        {
            #region Snippet:ImageUrlInMessageCreateClient
#if SNIPPET
            var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
            var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
            var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
            var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
            // Create an AgentsClient, enabling agent-management and messaging.
            AgentsClient client = new AgentsClient(connectionString, new DefaultAzureCredential());
            #endregion

            // Step 1: Create an agent
            #region Snippet:ImageUrlInMessageCreateAgent
            Agent agent = await client.CreateAgentAsync(
                model: modelDeploymentName,
                name: "Image Understanding Agent",
                instructions: "You are an image-understanding assistant. Analyze images and provide textual descriptions."
            );
            #endregion

            // Step 2: Create a thread
            #region Snippet:ImageUrlInMessageCreateThread
            AgentThread thread = await client.CreateThreadAsync();
            #endregion

            // Step 3: Create a message using multiple content blocks.
            // Here we combine a short text and an image URL in a single user message.
            #region Snippet:ImageUrlInMessageCreateMessage
            var contentBlocks = new List<MessageInputContentBlock>
            {
                new MessageInputTextBlock("Could you describe this image?"),
                new MessageInputImageUrlBlock(new MessageImageUrlParam(
                    "https://upload.wikimedia.org/wikipedia/commons/thumb/d/dd/Gfp-wisconsin-madison-the-nature-boardwalk.jpg/2560px-Gfp-wisconsin-madison-the-nature-boardwalk.jpg"
                ))
            };

            ThreadMessage imageMessage = await client.CreateMessageAsync(
                threadId: thread.Id,
                role: MessageRole.User,
                contentBlocks: contentBlocks
            );
            #endregion

            // Step 4: Run the agent against the thread that now has an image to analyze.
            #region Snippet:ImageUrlInMessageCreateRun
            ThreadRun run = await client.CreateRunAsync(
                threadId: thread.Id,
                assistantId: agent.Id
            );
            #endregion

            // Step 5: Wait for the run to complete.
            #region Snippet:ImageUrlInMessageWaitForRun
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

            // Step 6: Retrieve messages (including how the agent responds) and print their contents.
            #region Snippet:ImageUrlInMessageReview
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
            #region Snippet:ImageUrlInMessageCleanup
            await client.DeleteThreadAsync(thread.Id);
            await client.DeleteAgentAsync(agent.Id);
            #endregion
        }

        [Test]
        [AsyncOnly]
        public async Task ImageFileInMessageExampleAsync()
        {
#if SNIPPET
            var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
            var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
            var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
            var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
            // 1) Create an AgentsClient for agent-management and messaging.
            AgentsClient client = new AgentsClient(connectionString, new DefaultAzureCredential());

            // 2) (Optional) Upload a file for referencing in your message:
            #region Snippet:ImageFileInMessageUpload
            // The file might be an image or any relevant binary.
            // Make sure the server or container is set up for "Agents" usage if required.
            AgentFile uploadedFile = await client.UploadFileAsync(
                filePath: "sample_file_for_upload.jpg",
                purpose: AgentFilePurpose.Agents
            );
            Console.WriteLine($"Uploaded file with ID: {uploadedFile.Id}");
            #endregion

            // 3) Create an agent
            #region Snippet:ImageFileInMessageCreateAgent
            Agent agent = await client.CreateAgentAsync(
                model: modelDeploymentName,
                name: "File Image Understanding Agent",
                instructions: "Analyze images from internally uploaded files."
            );
            #endregion

            // 4) Create a thread
            #region Snippet:ImageFileInMessageCreateThread
            AgentThread thread = await client.CreateThreadAsync();
            #endregion

            // 5) Create a message referencing the uploaded file
            #region Snippet:ImageFileInMessageCreateMessage
            var contentBlocks = new List<MessageInputContentBlock>
            {
                new MessageInputTextBlock("Here is an uploaded file. Please describe it:"),
                new MessageInputImageFileBlock(new MessageImageFileParam(uploadedFile.Id))
            };

            ThreadMessage imageMessage = await client.CreateMessageAsync(
                thread.Id,
                MessageRole.User,
                contentBlocks: contentBlocks
            );
            #endregion

            // 6) Run the agent
            #region Snippet:ImageFileInMessageCreateRun
            ThreadRun run = await client.CreateRunAsync(
                threadId: thread.Id,
                assistantId: agent.Id
            );
            #endregion

            // 7) Wait for the run to complete
            #region Snippet:ImageFileInMessageWaitForRun
            do
            {
                await Task.Delay(500);
                run = await client.GetRunAsync(thread.Id, run.Id);
            }
            while (run.Status == RunStatus.Queued || run.Status == RunStatus.InProgress);

            if (run.Status != RunStatus.Completed)
            {
                throw new InvalidOperationException($"Run failed or was canceled: {run.LastError?.Message}");
            }
            #endregion

            // 8) Retrieve messages (including any agent responses) and print them
            #region Snippet:ImageFileInMessageReview
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

            // 9) Cleanup
            #region Snippet:ImageFileInMessageCleanup
            await client.DeleteThreadAsync(thread.Id);
            await client.DeleteAgentAsync(agent.Id);
            #endregion
        }
    }
}
