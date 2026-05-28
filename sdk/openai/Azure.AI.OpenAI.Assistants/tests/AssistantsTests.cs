// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.OpenAI.Assistants.Tests;

public class AssistantsTests : AssistantsTestBase
{
    public AssistantsTests(bool isAsync)
        : base(isAsync) // , RecordedTestMode.Live)
    {
    }

    [RecordedTest]
    [TestCase(OpenAIClientServiceTarget.NonAzure)]
    [TestCase(OpenAIClientServiceTarget.Azure)]
    public async Task CanListAssistants(OpenAIClientServiceTarget target)
    {
        AssistantsClient client = GetTestClient(target);
        Response<PageableList<Assistant>> listResponse = await client.GetAssistantsAsync();
        AssertSuccessfulResponse(listResponse);
    }

    [RecordedTest]
    [TestCase(OpenAIClientServiceTarget.NonAzure)]
    [TestCase(OpenAIClientServiceTarget.Azure)]
    public async Task CanCreateRetrieveListAndDeleteAssistants(OpenAIClientServiceTarget target)
    {
        AssistantsClient client = GetTestClient(target);
        string deploymentName = GetDeploymentOrModelName(target);

        // No assistant should exist with the metadata K/V pair we're going to use
        Response<PageableList<Assistant>> listResponse = await client.GetAssistantsAsync();
        AssertSuccessfulResponse(listResponse);
        Assert.That(!listResponse.Value.Any(assistant => assistant.Metadata?.Contains(TestMetadataPair) == true));

        // Now create that assistant
        Response<Assistant> assistantCreationResponse
            = await client.CreateAssistantAsync(new AssistantCreationOptions(deploymentName)
            {
                Name = "AOAI SDK Test Assistant - Delete Me",
                Description = "Created by automated tests to exercise the API; should not be used",
                Tools = { new RetrievalToolDefinition() },
                Instructions = "You are a very generic assistant.",
                Metadata = { TestMetadataPair },
            });
        AssertSuccessfulResponse(assistantCreationResponse);

        // Retrieve the assistant we just created to ensure it's the same
        Response<Assistant> retrievalResponse
            = await client.GetAssistantAsync(assistantCreationResponse.Value.Id);
        AssertSuccessfulResponse(retrievalResponse);
        Assert.That(retrievalResponse.Value.Id, Is.EqualTo(assistantCreationResponse.Value.Id));

        // List the assistants again to ensure it's reporting the one new matching assistant
        listResponse = await client.GetAssistantsAsync();
        AssertSuccessfulResponse(listResponse);
        Assert.That(
            listResponse.Value.Data.Where(assistant => assistant.Metadata?.Contains(TestMetadataPair) == true).Count(),
            Is.EqualTo(1));

        // We shouldn't have the metadata K/V we'll add via modification yet
        Assert.That(retrievalResponse.Value.Metadata.ContainsKey("modification_key"), Is.False);

        // Now modify the assistant by adding a k/v
        Response<Assistant> modificationResponse = await client.UpdateAssistantAsync(
            assistantCreationResponse.Value.Id,
            new UpdateAssistantOptions()
            {
                Model = deploymentName,
                Metadata =
                {
                    [s_testMetadataKey] = TestMetadataValue,
                    ["modification_key"] = "modification_value",
                },
            });
        AssertSuccessfulResponse(modificationResponse);
        Assert.That(modificationResponse.Value.Metadata.ContainsKey("modification_key"), Is.True);

        // Delete the assistant we created
        Response<bool> deletionResponse = await client.DeleteAssistantAsync(assistantCreationResponse.Value.Id);

        // Ensure we again have no list matches
        listResponse = await client.GetAssistantsAsync();
        AssertSuccessfulResponse(listResponse);
        Assert.That(!listResponse.Value.Data.Any(assistant => assistant.Metadata?.Contains(TestMetadataPair) == true));
    }

    [RecordedTest]
    [TestCase(OpenAIClientServiceTarget.Azure)]
    [TestCase(OpenAIClientServiceTarget.NonAzure)]
    public async Task CanCreateRetrieveAndDeleteThreads(OpenAIClientServiceTarget serviceTarget)
    {
        AssistantsClient client = GetTestClient(serviceTarget);

        Response<AssistantThread> threadCreationResponse
            = await client.CreateThreadAsync(new AssistantThreadCreationOptions()
            {
                Metadata = { TestMetadataPair },
            });
        AssertSuccessfulResponse(threadCreationResponse);
        AssistantThread thread = threadCreationResponse.Value;
        EnsuredThreadDeletions.Add((client, thread.Id));
        Assert.That(thread.Metadata.Contains(TestMetadataPair));

        Response<AssistantThread> retrievalResponse = await client.GetThreadAsync(thread.Id);
        AssertSuccessfulResponse(retrievalResponse);
        Assert.That(retrievalResponse.Value.Id, Is.EqualTo(thread.Id));

        Response<bool> deletionResponse = await client.DeleteThreadAsync(thread.Id);
        AssertSuccessfulResponse(deletionResponse);
        EnsuredThreadDeletions.Remove((client, thread.Id));
    }

    [RecordedTest]
    [TestCase(OpenAIClientServiceTarget.Azure)]
    [TestCase(OpenAIClientServiceTarget.NonAzure)]
    public async Task CanCreateAndModifyMessages(OpenAIClientServiceTarget serviceTarget)
    {
        AssistantsClient client = GetTestClient(serviceTarget);

        Response<AssistantThread> threadCreationResponse
            = await client.CreateThreadAsync(new AssistantThreadCreationOptions()
            {
                Metadata = { TestMetadataPair },
            });
        AssertSuccessfulResponse(threadCreationResponse);
        EnsuredThreadDeletions.Add((client, threadCreationResponse.Value.Id));

        Response<ThreadMessage> messageCreationResponse = await client.CreateMessageAsync(
            threadCreationResponse.Value.Id,
            MessageRole.User,
            "Hello, assistant! Can you help me?",
            fileIds: null,
            metadata: new Dictionary<string, string> { [s_testMetadataKey] = TestMetadataValue });
        AssertSuccessfulResponse(messageCreationResponse);

        Response<ThreadMessage> retrievalResponse
            = await client.GetMessageAsync(
                threadCreationResponse.Value.Id,
                messageCreationResponse.Value.Id);
        AssertSuccessfulResponse(retrievalResponse);

        Assert.That(retrievalResponse.Value.Metadata.ContainsKey("test_modification_key"), Is.False);

        Response<ThreadMessage> modificationResponse
            = await client.UpdateMessageAsync(
                threadCreationResponse.Value.Id,
                messageCreationResponse.Value.Id,
                new Dictionary<string, string>
                {
                    [s_testMetadataKey] = TestMetadataValue,
                    ["test_modification_key"] = "test_modification_value",
                });
        AssertSuccessfulResponse(modificationResponse);

        retrievalResponse = await client.GetMessageAsync(
            threadCreationResponse.Value.Id,
            messageCreationResponse.Value.Id);
        AssertSuccessfulResponse(retrievalResponse);
        Assert.That(retrievalResponse.Value.Metadata.ContainsKey("test_modification_key"), Is.True);

        // Delete what we created
        Response<bool> deletionResponse
            = await client.DeleteThreadAsync(threadCreationResponse.Value.Id);
        AssertSuccessfulResponse(deletionResponse);
        EnsuredThreadDeletions.Remove((client, threadCreationResponse.Value.Id));
    }

    [RecordedTest]
    [TestCase(OpenAIClientServiceTarget.Azure)]
    [TestCase(OpenAIClientServiceTarget.NonAzure)]
    public async Task CanRunAThread(OpenAIClientServiceTarget serviceTarget)
    {
        AssistantsClient client = GetTestClient(serviceTarget);

        // Create an assistant
        Response<Assistant> assistantCreationResponse
            = await client.CreateAssistantAsync(new AssistantCreationOptions("gpt-4-1106-preview")
            {
                Name = "AOAI SDK Test Assistant - Delete Me",
                Description = "Created by automated tests to exercise the API; should not be used",
                Tools = { new CodeInterpreterToolDefinition() },
                Instructions = "You are a very generic assistant.",
                Metadata = { TestMetadataPair },
            });
        AssertSuccessfulResponse(assistantCreationResponse);
        Assistant assistant = assistantCreationResponse.Value;

        // Create a thread
        Response<AssistantThread> threadCreationResponse
            = await client.CreateThreadAsync(new AssistantThreadCreationOptions()
            {
                Metadata = { TestMetadataPair },
            });
        AssertSuccessfulResponse(threadCreationResponse);
        EnsuredThreadDeletions.Add((client, threadCreationResponse.Value.Id));
        AssistantThread thread = threadCreationResponse.Value;

        // Create a message on the thread
        Response<ThreadMessage> messageCreationResponse = await client.CreateMessageAsync(
            threadCreationResponse.Value.Id,
            MessageRole.User,
            "Hello, assistant! Can you help me?",
            fileIds: null,
            metadata: new Dictionary<string, string> { [s_testMetadataKey] = TestMetadataValue });
        AssertSuccessfulResponse(messageCreationResponse);
        ThreadMessage userMessage = messageCreationResponse.Value;

        // Create a run of the thread
        Response<ThreadRun> runCreationResponse = await client.CreateRunAsync(
            thread.Id,
            new CreateRunOptions(assistant.Id)
            {
                Metadata = new Dictionary<string, string> { [s_testMetadataKey] = TestMetadataValue },
            });

        AssertSuccessfulResponse(runCreationResponse);
        ThreadRun run = runCreationResponse.Value;

        // Repeatedly retrieve the run (polling) until it's done
        do
        {
            await Task.Delay(RunPollingInterval);
            Response<ThreadRun> runRetrievalResponse = await client.GetRunAsync(thread.Id, run.Id);
            AssertSuccessfulResponse(runRetrievalResponse);
            run = runRetrievalResponse.Value;
        }
        while (run.Status == RunStatus.Queued || run.Status == RunStatus.InProgress);

        Assert.That(run.Status, Is.EqualTo(RunStatus.Completed));
        Assert.That(run.AssistantId, Is.EqualTo(assistant.Id));
        Assert.That(run.ThreadId, Is.EqualTo(thread.Id));

        // List the messages on the thread, now updated from the completed run
        Response<PageableList<ThreadMessage>> messageListResponse = await client.GetMessagesAsync(thread.Id);
        AssertSuccessfulResponse(messageListResponse);
        IReadOnlyList<ThreadMessage> messages = messageListResponse.Value.Data;
        Assert.That(messages.Count, Is.EqualTo(2));

        // Messages are in reverse order: the *second* index should be the assistant response
        Assert.That(messages[1].Role, Is.EqualTo(MessageRole.User));
        Assert.That(messages[1].Id, Is.EqualTo(userMessage.Id));
        Assert.That(messages[1].CreatedAt, Is.GreaterThanOrEqualTo(thread.CreatedAt));
        Assert.That(messages[1].ContentItems, Is.Not.Null.Or.Empty);
        Assert.That(
            (messages[1].ContentItems[0] as MessageTextContent).Text,
            Is.EqualTo((userMessage.ContentItems[0] as MessageTextContent).Text));

        // Messages are in reverse order: the second index should be the assistant response
        Assert.That(messages[0].Role, Is.EqualTo(MessageRole.Assistant));
        Assert.That(messages[0].AssistantId, Is.EqualTo(assistant.Id));
        Assert.That(messages[0].RunId, Is.EqualTo(run.Id));
        Assert.That(messages[0].ContentItems, Is.Not.Null.Or.Empty);
        Assert.That(
            (messages[0].ContentItems[0] as MessageTextContent).Text,
            Is.Not.Null.Or.Empty);
        Assert.That(messages[0].CreatedAt, Is.GreaterThan(messages[1].CreatedAt));

        // Get the steps associated with the run
        Response<PageableList<RunStep>> runStepsResponse = await client.GetRunStepsAsync(run);
        AssertSuccessfulResponse(runStepsResponse);
        IReadOnlyList<RunStep> runSteps = runStepsResponse.Value.Data;

        Assert.That(runSteps.Count, Is.EqualTo(1));
        Assert.That(runSteps[0].RunId, Is.EqualTo(run.Id));
        Assert.That(runSteps[0].AssistantId, Is.EqualTo(assistant.Id));
        Assert.That(runSteps[0].ThreadId, Is.EqualTo(thread.Id));
        Assert.That(runSteps[0].Status, Is.EqualTo(RunStepStatus.Completed));
        Assert.That(runSteps[0].CancelledAt.HasValue, Is.False);
        Assert.That(runSteps[0].CreatedAt, Is.GreaterThanOrEqualTo(thread.CreatedAt));
        Assert.That(runSteps[0].ExpiredAt.HasValue, Is.False);
        Assert.That(runSteps[0].FailedAt.HasValue, Is.False);
        Assert.That(runSteps[0].LastError, Is.Null);

        // The only step for the run should have created the assistant message
        RunStepMessageCreationDetails stepDetails = runSteps[0].StepDetails as RunStepMessageCreationDetails;
        Assert.That(stepDetails, Is.Not.Null);
        Assert.That(stepDetails.MessageCreation.MessageId, Is.EqualTo(messages[0].Id));

        // Check that we can retrieve the same run step
        Response<RunStep> runStepRetrievalResponse = await client.GetRunStepAsync(thread.Id, run.Id, runSteps[0].Id);
        AssertSuccessfulResponse(runStepRetrievalResponse);

        // Delete the assistant we created
        Response<bool> deletionResponse = await client.DeleteAssistantAsync(assistant.Id);
            AssertSuccessfulResponse(deletionResponse);

        // Delete the thread we created
        deletionResponse = await client.DeleteThreadAsync(thread.Id);
        AssertSuccessfulResponse(deletionResponse);
        EnsuredThreadDeletions.Remove((client, thread.Id));
    }
}
