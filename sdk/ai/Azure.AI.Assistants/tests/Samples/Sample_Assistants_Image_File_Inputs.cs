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

namespace Azure.AI.Assistants.Tests
{
    /// <summary>
    /// Demonstrates examples of sending an image file (along with optional text)
    /// as a structured content block in a single message.
    /// </summary>
    /// <remarks>
    /// The examples shows how to create an assistant, open a thread,
    /// post content blocks combining text and image inputs,
    /// and then run the assistant to see how it interprets the multimedia input.
    /// </remarks>
    public partial class Sample_Assistants_ImageFileInputs : SamplesBase<AIAssistantsTestEnvironment>
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
            #region Snippet:AssistantsImageFileInMessageCreateClient
#if SNIPPET
            var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
            var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
            var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
            var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
            var filePath = GetFile();
            // 1) Create an AssistantsClient for assistant-management and messaging.
            AssistantsClient client = new(connectionString, new DefaultAzureCredential());
            #endregion

            // 2) (Optional) Upload a file for referencing in your message:
            #region Snippet:AssistantsImageFileInMessageUpload
            string pathToImage = Path.Combine(
                    TestContext.CurrentContext.TestDirectory,
                    filePath
                );

            // The file might be an image or any relevant binary.
            // Make sure the server or container is set up for "Assistants" usage if required.
            AssistantFile uploadedFile = await client.UploadFileAsync(
                filePath: pathToImage,
                purpose: AssistantFilePurpose.Assistants
            );
            Console.WriteLine($"Uploaded file with ID: {uploadedFile.Id}");
            #endregion

            // 3) Create an assistant
            #region Snippet:AssistantsImageFileInMessageCreateAssistant
            Assistant assistant = await client.CreateAssistantAsync(
                model: modelDeploymentName,
                name: "File Image Understanding Assistant",
                instructions: "Analyze images from internally uploaded files."
            );
            #endregion

            // 4) Create a thread
            #region Snippet:AssistantsImageFileInMessageCreateThread
            AssistantThread thread = await client.CreateThreadAsync();
            #endregion

            // 5) Create a message referencing the uploaded file
            #region Snippet:AssistantsImageFileInMessageCreateMessage
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

            // 6) Run the assistant
            #region Snippet:AssistantsImageFileInMessageCreateRun
            ThreadRun run = await client.CreateRunAsync(
                threadId: thread.Id,
                assistantId: assistant.Id
            );
            #endregion

            // 7) Wait for the run to complete
            #region Snippet:AssistantsImageFileInMessageWaitForRun
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

            // 8) Retrieve messages (including any assistant responses) and print them
            #region Snippet:AssistantsImageFileInMessageReview
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
            #region Snippet:AssistantsImageFileInMessageCleanup
            await client.DeleteThreadAsync(thread.Id);
            await client.DeleteAssistantAsync(assistant.Id);
            #endregion
        }

        [Test]
        [SyncOnly]
        public void ImageFileInMessageExample()
        {
#if SNIPPET
            var connectionString = Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
            var modelDeploymentName = Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
            var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
            var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
            var filePath = GetFile();
            // 1) Create an AssistantsClient for assistant management and messaging.
            AssistantsClient client = new(connectionString, new DefaultAzureCredential());

            // 2) (Optional) Upload a file for referencing in your message:
            #region Snippet:AssistantsImageFileInMessageUpload_Sync
            string pathToImage = Path.Combine(
                TestContext.CurrentContext.TestDirectory,
                filePath
            );

            // The file might be an image or any relevant binary.
            // Make sure the server or container is set up for "Assistants" usage if required.
            AssistantFile uploadedFile = client.UploadFile(
                filePath: pathToImage,
                purpose: AssistantFilePurpose.Assistants
            );
            Console.WriteLine($"Uploaded file with ID: {uploadedFile.Id}");
            #endregion

            // 3) Create an assistant
            #region Snippet:AssistantsImageFileInMessageCreateAssistant_Sync
            Assistant assistant = client.CreateAssistant(
                model: modelDeploymentName,
                name: "File Image Understanding Assistant",
                instructions: "Analyze images from internally uploaded files."
            );
            #endregion

            // 4) Create a thread
            #region Snippet:AssistantsImageFileInMessageCreateThread_Sync
            AssistantThread thread = client.CreateThread();
            #endregion

            // 5) Create a message referencing the uploaded file
            #region Snippet:AssistantsImageFileInMessageCreateMessage_Sync
            var contentBlocks = new List<MessageInputContentBlock>
            {
                new MessageInputTextBlock("Here is an uploaded file. Please describe it:"),
                new MessageInputImageFileBlock(new MessageImageFileParam(uploadedFile.Id))
            };

            ThreadMessage imageMessage = client.CreateMessage(
                threadId: thread.Id,
                role: MessageRole.User,
                contentBlocks: contentBlocks
            );
            #endregion

            // 6) Run the assistant
            #region Snippet:AssistantsImageFileInMessageCreateRun_Sync
            ThreadRun run = client.CreateRun(
                threadId: thread.Id,
                assistantId: assistant.Id
            );
            #endregion

            // 7) Wait for the run to complete
            #region Snippet:AssistantsImageFileInMessageWaitForRun_Sync
            do
            {
                Thread.Sleep(500);
                run = client.GetRun(thread.Id, run.Id);
            }
            while (run.Status == RunStatus.Queued || run.Status == RunStatus.InProgress);

            if (run.Status != RunStatus.Completed)
            {
                throw new InvalidOperationException($"Run failed or was canceled: {run.LastError?.Message}");
            }
            #endregion

            // 8) Retrieve messages (including any assistant responses) and print them
            #region Snippet:AssistantsImageFileInMessageReview_Sync
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

            // 9) Cleanup
            #region Snippet:AssistantsImageFileInMessageCleanup_Sync
            client.DeleteThread(thread.Id);
            client.DeleteAssistant(assistant.Id);
            #endregion
        }
    }
}
