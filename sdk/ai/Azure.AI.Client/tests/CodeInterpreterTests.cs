// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.OpenAI.Assistants.Tests;

public class CodeInterpreterTests : AssistantsTestBase
{
    public CodeInterpreterTests(bool isAsync)
        : base(isAsync) // RecordedTestMode.Live)
    {
    }

    [RecordedTest]
    [TestCase(OpenAIClientServiceTarget.NonAzure)]
    [TestCase(OpenAIClientServiceTarget.Azure)]
    public async Task InterpreterGeneratedImageWorks(OpenAIClientServiceTarget target)
    {
        Agents client = GetTestClient(target);
        string deploymentOrModelName = GetDeploymentOrModelName(target);

        Response<Assistant> assistantCreationResponse
            = await client.CreateAssistantAsync(new AssistantCreationOptions(deploymentOrModelName)
            {
                Name = "AOAI SDK Test Assistant - Delete Me",
                Description = "Created by automated tests to exercise the API; should not be used",
                Instructions = "You are a very generic assistant. When appropriate, use the code interpreter tool to generate requested images.",
                Tools = { new CodeInterpreterToolDefinition() },
                Metadata = { TestMetadataPair },
            });
        AssertSuccessfulResponse(assistantCreationResponse);
        Assistant assistant = assistantCreationResponse.Value;

        Response<ThreadRun> runCreationResponse = await client.CreateThreadAndRunAsync(
            new CreateAndRunThreadOptions(assistantCreationResponse.Value.Id)
            {
                Metadata = { TestMetadataPair },
                Thread = new AssistantThreadCreationOptions()
                {
                    Metadata = { TestMetadataPair },
                    Messages =
                    {
                        new ThreadInitializationMessage(
                            MessageRole.User,
                            "Hello, assistant! Please make a picture that graphs the equation: y = 14x - 4")
                        {
                             Metadata = { TestMetadataPair },
                        }
                    },
                },
            });
        AssertSuccessfulResponse(runCreationResponse);
        ThreadRun run = runCreationResponse.Value;

        // Repeatedly retrieve the run (polling) until it's done
        do
        {
            await Task.Delay(RunPollingInterval);
            Response<ThreadRun> runRetrievalResponse = await client.GetRunAsync(run.ThreadId, run.Id);
            AssertSuccessfulResponse(runRetrievalResponse);
            run = runRetrievalResponse.Value;
        }
        while (run.Status == RunStatus.Queued || run.Status == RunStatus.InProgress);

        Assert.That(run.Status, Is.EqualTo(RunStatus.Completed));
        Assert.That(run.AssistantId, Is.EqualTo(assistant.Id));

        // List the messages on the thread, now updated from the completed run
        Response<PageableList<ThreadMessage>> messageListResponse = await client.GetMessagesAsync(run.ThreadId);
        AssertSuccessfulResponse(messageListResponse);
        IReadOnlyList<ThreadMessage> messages = messageListResponse.Value.Data;
        Assert.That(messages.Count, Is.GreaterThan(1));

        // Get an assistant-provided file ID
        string imageFileId = null;
        foreach (ThreadMessage message in messages)
        {
            if (message.Role == MessageRole.Assistant)
            {
                foreach (MessageContent messageContent in message.ContentItems)
                {
                    if (messageContent is MessageImageFileContent imageFileContent)
                    {
                        Assert.That(imageFileContent.FileId, Is.Not.Null.Or.Empty);
                        imageFileId = imageFileContent.FileId;
                        break;
                    }
                }
            }
        }
        Assert.That(imageFileId, Is.Not.Null.Or.Empty);

        // Ensure we can get the file metadata for the ID provided
        Response<OpenAIFile> imageFileResponse = await client.GetFileAsync(imageFileId);
        AssertSuccessfulResponse(imageFileResponse);
        Assert.That(imageFileResponse.Value.Filename, Is.Not.Null.Or.Empty);
        Assert.That(imageFileResponse.Value.Purpose, Is.EqualTo(OpenAIFilePurpose.AssistantsOutput));

        // Ensure we can get some binary image data for the ID provided
        Response<BinaryData> imageDataResponse = await client.GetFileContentAsync(imageFileId);
        AssertSuccessfulResponse(imageDataResponse);
        Assert.That(imageDataResponse.Value.ToArray().Length, Is.GreaterThan(0));
    }
}
