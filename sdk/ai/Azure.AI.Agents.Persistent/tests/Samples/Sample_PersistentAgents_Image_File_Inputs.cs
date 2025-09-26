// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Agents.Persistent.Tests
{
    /// <summary>
    /// Demonstrates examples of sending an image file (along with optional text)
    /// as a structured content block in a single message.
    /// </summary>
    /// <remarks>
    /// The examples shows how to create an agent, open a thread,
    /// post content blocks combining text and image inputs,
    /// and then run the agent to see how it interprets the multimedia input.
    /// </remarks>
    public partial class Sample_PersistentAgents_ImageFileInputs : SamplesBase<AIAgentsTestEnvironment>
    {
        private static string GetFile([CallerFilePath] string pth = "")
        {
            var dirName = Path.GetDirectoryName(pth) ?? "";
            return Path.Combine(dirName, "image_file.png");
        }

        [Test]
        [AsyncOnly]
        public async Task ImageFileInMessageExampleAsync()
        {
            #region Snippet:AgentsImageFileInMessageCreateClient
#if SNIPPET
            var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
            var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
            var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
            var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
            var filePath = GetFile();
            // 1) Create an PersistentAgentsClient for agent-management and messaging.
            PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());
            #endregion

            // 2) (Optional) Upload a file for referencing in your message:
            #region Snippet:AgentsImageFileInMessageUpload
            string pathToImage = Path.Combine(
                    TestContext.CurrentContext.TestDirectory,
                    filePath
                );

            // The file might be an image or any relevant binary.
            // Make sure the server or container is set up for "Agents" usage if required.
            PersistentAgentFileInfo uploadedFile = await client.Files.UploadFileAsync(
                filePath: pathToImage,
                purpose: PersistentAgentFilePurpose.Agents
            );
            Console.WriteLine($"Uploaded file with ID: {uploadedFile.Id}");
            #endregion

            // 3) Create an agent
            #region Snippet:AgentsImageFileInMessageCreateAgent
            PersistentAgent agent = await client.Administration.CreateAgentAsync(
                model: modelDeploymentName,
                name: "File Image Understanding Agent",
                instructions: "Analyze images from internally uploaded files."
            );
            #endregion

            // 4) Create a thread
            #region Snippet:AgentsImageFileInMessageCreateThread
            PersistentAgentThread thread = await client.Threads.CreateThreadAsync();
            #endregion

            // 5) Create a message referencing the uploaded file
            #region Snippet:AgentsImageFileInMessageCreateMessage
            var contentBlocks = new List<MessageInputContentBlock>
            {
                new MessageInputTextBlock("Here is an uploaded file. Please describe it:"),
                new MessageInputImageFileBlock(new MessageImageFileParam(uploadedFile.Id))
            };

            PersistentThreadMessage imageMessage = await client.Messages.CreateMessageAsync(
                thread.Id,
                MessageRole.User,
                contentBlocks: contentBlocks
            );
            #endregion

            // 6) Run the agent
            #region Snippet:AgentsImageFileInMessageCreateRun
            ThreadRun run = await client.Runs.CreateRunAsync(
                threadId: thread.Id,
                assistantId: agent.Id
            );
            #endregion

            // 7) Wait for the run to complete
            #region Snippet:AgentsImageFileInMessageWaitForRun
            do
            {
                await Task.Delay(500);
                run = await client.Runs.GetRunAsync(thread.Id, run.Id);
            }
            while (run.Status == RunStatus.Queued || run.Status == RunStatus.InProgress);

            if (run.Status != RunStatus.Completed)
            {
                throw new InvalidOperationException($"Run failed or was canceled: {run.LastError?.Message}");
            }
            #endregion

            // 8) Retrieve messages (including any agent responses) and print them
            #region Snippet:AgentsImageFileInMessageReview
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

            // 9) Cleanup
            #region Snippet:AgentsImageFileInMessageCleanup
            await client.Threads.DeleteThreadAsync(thread.Id);
            await client.Administration.DeleteAgentAsync(agent.Id);
            #endregion
        }

        [Test]
        [SyncOnly]
        public void ImageFileInMessageExample()
        {
#if SNIPPET
            var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
            var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
            var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
            var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
            var filePath = GetFile();
            // 1) Create an AgentsClient for agent management and messaging.
            PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());

            // 2) (Optional) Upload a file for referencing in your message:
            #region Snippet:AgentsImageFileInMessageUpload_Sync
            string pathToImage = Path.Combine(
                TestContext.CurrentContext.TestDirectory,
                filePath
            );

            // The file might be an image or any relevant binary.
            // Make sure the server or container is set up for "Agents" usage if required.
            PersistentAgentFileInfo uploadedFile = client.Files.UploadFile(
                filePath: pathToImage,
                purpose: PersistentAgentFilePurpose.Agents
            );
            Console.WriteLine($"Uploaded file with ID: {uploadedFile.Id}");
            #endregion

            // 3) Create an agent
            #region Snippet:AgentsImageFileInMessageCreateAgent_Sync
            PersistentAgent agent = client.Administration.CreateAgent(
                model: modelDeploymentName,
                name: "File Image Understanding Agent",
                instructions: "Analyze images from internally uploaded files."
            );
            #endregion

            // 4) Create a thread
            #region Snippet:AgentsImageFileInMessageCreateThread_Sync
            PersistentAgentThread thread = client.Threads.CreateThread();
            #endregion

            // 5) Create a message referencing the uploaded file
            #region Snippet:AgentsImageFileInMessageCreateMessage_Sync
            var contentBlocks = new List<MessageInputContentBlock>
            {
                new MessageInputTextBlock("Here is an uploaded file. Please describe it:"),
                new MessageInputImageFileBlock(new MessageImageFileParam(uploadedFile.Id))
            };

            PersistentThreadMessage imageMessage = client.Messages.CreateMessage(
                threadId: thread.Id,
                role: MessageRole.User,
                contentBlocks: contentBlocks
            );
            #endregion

            // 6) Run the agent
            #region Snippet:AgentsImageFileInMessageCreateRun_Sync
            ThreadRun run = client.Runs.CreateRun(
                threadId: thread.Id,
                assistantId: agent.Id
            );
            #endregion

            // 7) Wait for the run to complete
            #region Snippet:AgentsImageFileInMessageWaitForRun_Sync
            do
            {
                Thread.Sleep(500);
                run = client.Runs.GetRun(thread.Id, run.Id);
            }
            while (run.Status == RunStatus.Queued || run.Status == RunStatus.InProgress);

            if (run.Status != RunStatus.Completed)
            {
                throw new InvalidOperationException($"Run failed or was canceled: {run.LastError?.Message}");
            }
            #endregion

            // 8) Retrieve messages (including any agent responses) and print them
            #region Snippet:AgentsImageFileInMessageReview_Sync
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

            // 9) Cleanup
            #region Snippet:AgentsImageFileInMessageCleanup_Sync
            client.Threads.DeleteThread(thread.Id);
            client.Administration.DeleteAgent(agent.Id);
            #endregion
        }
    }
}
