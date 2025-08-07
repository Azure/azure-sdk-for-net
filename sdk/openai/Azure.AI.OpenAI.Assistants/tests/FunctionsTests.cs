// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.OpenAI.Assistants.Tests;

public class FunctionsTests : AssistantsTestBase
{
    public FunctionsTests(bool isAsync)
        : base(isAsync)//, RecordedTestMode.Live)
    {
    }

    [RecordedTest]
    [TestCase(OpenAIClientServiceTarget.NonAzure)]
    [TestCase(OpenAIClientServiceTarget.Azure)]
    public async Task CanCallParallelFunctions(OpenAIClientServiceTarget target)
    {
        AssistantsClient client = GetTestClient(target);

        FunctionToolDefinition favoriteVacationDestinationFunction = new(
            name: "getFavoriteVacationDestination",
            description: "Retrieves the user's unambiguously preferred location for vacations.");
        FunctionToolDefinition preferredAirlineForSeasonFunction = new(
            name: "getPreferredAirlineForSeason",
            description: "Given a season like winter or spring, retrieves the user's preferred airline carrier.",
            parameters: BinaryData.FromObjectAsJson(
                new
                {
                    Type = "object",
                    Properties = new
                    {
                        Season = new
                        {
                            Type = "string",
                            Enum = new[] { "spring", "summer", "fall", "winter" },
                        }
                    }
                },
                new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }));
        FunctionToolDefinition getFlightPriceFunction = new(
            name: "getAirlinePriceToDestinationForSeason",
            description: "Given a desired location, airline, and approximate time of year, retrieves estimated prices.",
            parameters: BinaryData.FromObjectAsJson(
                new
                {
                    Type = "object",
                    Properties = new
                    {
                        Destination = new
                        {
                            Type = "string",
                            Description = "A travel destination location.",
                        },
                        Airline = new
                        {
                            Type = "string",
                            Description = "The name of an airline that flights can be booked on.",
                        },
                        Time = new
                        {
                            Type = "string",
                            Description = "An approximate time of year at which travel is planned.",
                        },
                    }
                },
                new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }));

        Response<Assistant> assistantCreationResponse = await client.CreateAssistantAsync(new("gpt-4-1106-preview")
        {
            Tools =
            {
                getFlightPriceFunction,
                preferredAirlineForSeasonFunction,
                favoriteVacationDestinationFunction,
            },
            Name = "SDK test - function tools",
            Metadata = { TestMetadataPair },
        });
        AssertSuccessfulResponse(assistantCreationResponse);
        Assistant assistant = assistantCreationResponse.Value;

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
            "Assuming both my usual preferred vacation spot and favorite airline carrier, how much would it cost to fly there in September?",
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

        Assert.That(run.Status, Is.EqualTo(RunStatus.RequiresAction));
        SubmitToolOutputsAction outputsAction = run.RequiredAction as SubmitToolOutputsAction;
        Assert.That(outputsAction, Is.Not.Null);
        Assert.That(outputsAction.ToolCalls, Is.Not.Null.Or.Empty);
        foreach (RequiredToolCall toolCall in outputsAction.ToolCalls)
        {
            RequiredFunctionToolCall requiredFunctionCall = toolCall as RequiredFunctionToolCall;
            Assert.That(requiredFunctionCall, Is.Not.Null);
            Assert.That(requiredFunctionCall.Name, Is.Not.Null.Or.Empty);
            Assert.That(requiredFunctionCall.Arguments, Is.Not.Null.Or.Empty);
            JsonElement argumentsJson = JsonDocument.Parse(requiredFunctionCall.Arguments).RootElement;
            Assert.That(argumentsJson, Is.Not.Null);
            Assert.That(argumentsJson.ValueKind, Is.EqualTo(JsonValueKind.Object));
            List<JsonProperty> argumentProperties = argumentsJson.EnumerateObject().ToList();

            if (requiredFunctionCall.Name == favoriteVacationDestinationFunction.Name)
            {
                Assert.That(argumentProperties, Is.Empty);
            }
            else if (requiredFunctionCall.Name == preferredAirlineForSeasonFunction.Name)
            {
                Assert.That(argumentProperties.Count, Is.EqualTo(1));
                Assert.That(argumentProperties[0].Name, Is.EqualTo("season"));
                Assert.That(argumentProperties[0].Value.GetString(), Is.EqualTo("fall"));
            }
        }

        Response<PageableList<RunStep>> listRunStepResponse = await client.GetRunStepsAsync(run);
        AssertSuccessfulResponse(listRunStepResponse);
        IReadOnlyList<RunStep> runSteps = listRunStepResponse.Value.Data;
        Assert.That(runSteps, Is.Not.Null.Or.Empty);

        RunStepToolCallDetails runStepToolCallDetails = runSteps[0].StepDetails as RunStepToolCallDetails;
        Assert.That(runStepToolCallDetails, Is.Not.Null);
    }
}
