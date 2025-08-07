// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.OpenAI.Assistants.Tests;

public class RetrievalTests : AssistantsTestBase
{
    public RetrievalTests(bool isAsync)
        : base(isAsync) // RecordedTestMode.Live)
    {
    }

    [RecordedTest]
    [TestCase(OpenAIClientServiceTarget.NonAzure)]
    [TestCase(OpenAIClientServiceTarget.Azure)]
    public async Task BasicRetrievalWorks(OpenAIClientServiceTarget target)
    {
        AssistantsClient client = GetTestClient(target);
        string deploymentOrModelName = GetDeploymentOrModelName(target);

        OpenAIFile uploadedFile = null;
        using (TestRecording.DisableRecordingScope disableBodyRecordingScope = Recording.DisableRequestBodyRecording())
        {
            Response<OpenAIFile> uploadFileResponse = await client.UploadFileAsync(
                BinaryData.FromString("The number for the color 'red' is 1. The number for the color 'blue' is 2. The number for the color 'green' is 4.").ToStream(),
                OpenAIFilePurpose.Assistants);
            AssertSuccessfulResponse(uploadFileResponse);
            EnsuredFileDeletions.Add((client, uploadFileResponse.Value.Id));
            uploadedFile = uploadFileResponse.Value;
        }

        Response<Assistant> assistantCreationResponse
            = await client.CreateAssistantAsync(new AssistantCreationOptions(deploymentOrModelName)
            {
                Name = "AOAI SDK Test Assistant - Delete Me",
                Description = "Created by automated tests to exercise the API; should not be used",
                Instructions = "You are a very generic assistant.",
                Tools = { new RetrievalToolDefinition() },
                FileIds = { uploadedFile.Id },
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
                            "Hello, assistant! What's the mathematical product of the numbers for the colors blue and green?")
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
        Assert.That(messages.Count, Is.EqualTo(2));

        // Messages are most recent first in the list
        ThreadMessage latestMessage = messages[0];

        Assert.That(latestMessage.Role, Is.EqualTo(MessageRole.Assistant));
        Assert.That(latestMessage.ContentItems, Is.Not.Null.Or.Empty);
        MessageTextContent textContent = latestMessage.ContentItems[0] as MessageTextContent;
        Assert.That(textContent, Is.Not.Null);
        Assert.That(textContent.Text.Contains('8'));
    }
}
