// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.OpenAI.Tests;

public class ChatFunctionsTests : OpenAITestBase
{
    public ChatFunctionsTests(bool isAsync)
        : base(isAsync)//, RecordedTestMode.Live)
    {
    }

    [RecordedTest]
    [TestCase(OpenAIClientServiceTarget.Azure)]
    [TestCase(OpenAIClientServiceTarget.NonAzure)]
    public async Task SimpleFunctionCallWorks(OpenAIClientServiceTarget serviceTarget)
    {
        OpenAIClient client = GetTestClient(serviceTarget);
        string deploymentOrModelName = OpenAITestBase.GetDeploymentOrModelName(
            serviceTarget,
            OpenAIClientScenario.ChatCompletions);

        var requestOptions = new ChatCompletionsOptions()
        {
            DeploymentName = deploymentOrModelName,
            Functions = { s_futureTemperatureFunction },
            Messages =
            {
                new ChatMessage(ChatRole.System, "You are a helpful assistant."),
                new ChatMessage(ChatRole.User, "What should I wear in Honolulu next Thursday?"),
            },
            MaxTokens = 512,
        };

        Response<ChatCompletions> response = await client.GetChatCompletionsAsync(requestOptions);
        Assert.That(response, Is.Not.Null);

        Assert.That(response.Value, Is.Not.Null);
        Assert.That(response.Value.Choices, Is.Not.Null.Or.Empty);
        Assert.That(response.Value.Choices[0].FinishReason, Is.EqualTo(CompletionsFinishReason.FunctionCall));
        Assert.That(response.Value.Choices[0].Message.Role, Is.EqualTo(ChatRole.Assistant));
        Assert.That(response.Value.Choices[0].Message.Content, Is.Null.Or.Empty);
        Assert.That(response.Value.Choices[0].Message.FunctionCall, Is.Not.Null);
        Assert.That(response.Value.Choices[0].Message.FunctionCall.Name, Is.EqualTo(s_futureTemperatureFunction.Name));
        Assert.That(response.Value.Choices[0].Message.FunctionCall.Arguments, Is.Not.Null.Or.Empty);

        ChatCompletionsOptions followupOptions = new()
        {
            DeploymentName = deploymentOrModelName,
            Functions = { s_futureTemperatureFunction },
            MaxTokens = 512,
        };
        foreach (ChatMessage originalMessage in requestOptions.Messages)
        {
            followupOptions.Messages.Add(originalMessage);
        }
        followupOptions.Messages.Add(response.Value.Choices[0].Message);
        followupOptions.Messages.Add(new ChatMessage()
        {
            Role = ChatRole.Function,
            Name = response.Value.Choices[0].Message.FunctionCall.Name,
            Content = JsonSerializer.Serialize(new
            {
                Temperature = "31",
                Unit = "celsius",
            },
            new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }),
        });

        Response<ChatCompletions> followupResponse = await client.GetChatCompletionsAsync(followupOptions);
        Assert.That(followupResponse, Is.Not.Null);
        Assert.That(followupResponse.Value, Is.Not.Null);
        Assert.That(followupResponse.Value.Choices, Is.Not.Null.Or.Empty);
        Assert.That(followupResponse.Value.Choices[0], Is.Not.Null);
        Assert.That(followupResponse.Value.Choices[0].Message, Is.Not.Null);
        Assert.That(followupResponse.Value.Choices[0].Message.Role, Is.EqualTo(ChatRole.Assistant));
        Assert.That(followupResponse.Value.Choices[0].Message.Content, Is.Not.Null.Or.Empty);
    }

    [RecordedTest]
    [TestCase(OpenAIClientServiceTarget.Azure)]
    [TestCase(OpenAIClientServiceTarget.NonAzure)]
    public async Task StreamingFunctionCallWorks(OpenAIClientServiceTarget serviceTarget)
    {
        OpenAIClient client = GetTestClient(serviceTarget);
        string deploymentOrModelName = OpenAITestBase.GetDeploymentOrModelName(serviceTarget, OpenAIClientScenario.ChatCompletions);

        var requestOptions = new ChatCompletionsOptions()
        {
            DeploymentName = deploymentOrModelName,
            Functions = { s_futureTemperatureFunction },
            Messages =
            {
                new ChatMessage(ChatRole.System, "You are a helpful assistant."),
                new ChatMessage(ChatRole.User, "What should I wear in Honolulu next Thursday?"),
            },
            MaxTokens = 512,
        };

        StreamingResponse<StreamingChatCompletionsUpdate> response
            = await client.GetChatCompletionsStreamingAsync(requestOptions);
        Assert.That(response, Is.Not.Null);

        ChatRole? streamedRole = default;
        string functionName = null;
        StringBuilder argumentsBuilder = new();

        await foreach (StreamingChatCompletionsUpdate chatUpdate in response)
        {
            if (chatUpdate.Role.HasValue)
            {
                Assert.That(streamedRole, Is.Null, "role should only appear once");
                streamedRole = chatUpdate.Role.Value;
            }
            if (!string.IsNullOrEmpty(chatUpdate.FunctionName))
            {
                Assert.That(functionName, Is.Null, "function_name should only appear once");
                functionName = chatUpdate.FunctionName;
            }
            argumentsBuilder.Append(chatUpdate.FunctionArgumentsUpdate);
        }

        Assert.That(streamedRole, Is.EqualTo(ChatRole.Assistant));
        Assert.That(functionName, Is.EqualTo(s_futureTemperatureFunction.Name));
        Assert.That(argumentsBuilder.Length, Is.GreaterThan(0));
    }

    private static readonly FunctionDefinition s_futureTemperatureFunction = new()
    {
        Name = "get_future_temperature",
        Description = "requests the anticipated future temperature at a provided location to help inform "
                + "advice about topics like choice of attire",
        Parameters = BinaryData.FromObjectAsJson(new
        {
            Type = "object",
            Properties = new
            {
                LocationName = new
                {
                    Type = "string",
                    Description = "the name or brief description of a location for weather information"
                },
                Date = new
                {
                    Type = "string",
                    Description = "the day, month, and year for which to retrieve weather information"
                }
            }
        },
            new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase })
    };

    private static readonly FunctionDefinition s_wordOfTheDayFunction = new()
    {
        Name = "get_word_of_the_day",
        Description = "requests a featured word for a given day of the week",
        Parameters = BinaryData.FromObjectAsJson(new
        {
            Type = "object",
            Properties = new
            {
                DayOfWeek = new
                {
                    Type = "string",
                    Description = "the name of a day of the week, like Wednesday",
                },
            }
        },
            new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase })
    };
}
