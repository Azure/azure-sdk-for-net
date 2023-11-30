// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Azure.AI.OpenAI.Tests;

public class ChatToolsTests : OpenAITestBase
{
    public ChatToolsTests(bool isAsync)
        : base(Scenario.ChatTools, isAsync)//, RecordedTestMode.Live)
    {
    }

    [RecordedTest]
    [TestCase(Service.Azure)]
    [TestCase(Service.NonAzure)]
    public async Task SimpleFunctionToolWorks(Service serviceTarget)
    {
        OpenAIClient client = GetTestClient(serviceTarget);
        string deploymentOrModelName = GetDeploymentOrModelName(serviceTarget);

        var requestOptions = new ChatCompletionsOptions()
        {
            DeploymentName = deploymentOrModelName,
            Tools = { s_futureTemperatureTool },
            Messages =
            {
                new ChatRequestSystemMessage("You are a helpful assistant."),
                new ChatRequestUserMessage("What should I wear in Honolulu next Thursday?"),
            },
            MaxTokens = 512,
        };

        Response<ChatCompletions> response = await client.GetChatCompletionsAsync(requestOptions);
        Assert.That(response, Is.Not.Null);

        Assert.That(response.Value, Is.Not.Null);
        Assert.That(response.Value.Choices, Is.Not.Null.Or.Empty);

        ChatChoice choice = response.Value.Choices[0];
        Assert.That(choice.FinishReason, Is.EqualTo(CompletionsFinishReason.ToolCalls));

        ChatResponseMessage message = choice.Message;
        Assert.That(message.Role, Is.EqualTo(ChatRole.Assistant));
        Assert.That(message.Content, Is.Null.Or.Empty);
        Assert.That(message.ToolCalls, Is.Not.Null.Or.Empty);
        Assert.That(message.ToolCalls.Count, Is.EqualTo(1));
        ChatCompletionsFunctionToolCall functionToolCall = message.ToolCalls[0] as ChatCompletionsFunctionToolCall;
        Assert.That(functionToolCall, Is.Not.Null);
        Assert.That(functionToolCall.Name, Is.EqualTo(s_futureTemperatureFunction.Name));
        Assert.That(functionToolCall.Arguments, Is.Not.Null.Or.Empty);

        Dictionary<string, string> arguments
            = JsonConvert.DeserializeObject<Dictionary<string, string>>(functionToolCall.Arguments);
        Assert.That(arguments.ContainsKey("locationName"));
        Assert.That(arguments.ContainsKey("date"));

        ChatCompletionsOptions followupOptions = new()
        {
            DeploymentName = deploymentOrModelName,
            Tools = { s_futureTemperatureTool },
            MaxTokens = 512,
        };
        // Include all original messages
        foreach (ChatRequestMessage originalMessage in requestOptions.Messages)
        {
            followupOptions.Messages.Add(originalMessage);
        }
        // And the tool call message just received back from the assistant
        followupOptions.Messages.Add(new ChatRequestAssistantMessage(choice.Message.Content)
        {
            ToolCalls = { functionToolCall },
        });

        // And also the tool message that resolves the tool call
        followupOptions.Messages.Add(new ChatRequestToolMessage(
            toolCallId: functionToolCall.Id,
            content: "31 celsius"));

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
    [TestCase(Service.Azure)]
    [TestCase(Service.NonAzure)]
    public async Task StreamingToolCallWorks(Service serviceTarget)
    {
        OpenAIClient client = GetTestClient(serviceTarget);
        string deploymentOrModelName = GetDeploymentOrModelName(serviceTarget);

        var requestOptions = new ChatCompletionsOptions()
        {
            DeploymentName = deploymentOrModelName,
            Tools = { s_futureTemperatureTool },
            Messages =
            {
                new ChatRequestSystemMessage("You are a helpful assistant."),
                new ChatRequestUserMessage("What should I wear in Honolulu next Thursday?"),
            },
            MaxTokens = 512,
            ChoiceCount = 3,
        };

        StreamingResponse<StreamingChatCompletionsUpdate> response
            = await client.GetChatCompletionsStreamingAsync(requestOptions);
        Assert.That(response, Is.Not.Null);

        Dictionary<int, ChatRole> rolesByChoiceIndex = new();
        Dictionary<int, string> toolCallIdsByChoiceIndex = new();
        Dictionary<int, string> toolCallFunctionNamesByChoiceIndex = new();
        Dictionary<int, StringBuilder> toolCallFunctionArgumentsByChoiceIndex = new();

        await foreach (StreamingChatCompletionsUpdate chatUpdate in response)
        {
            if (chatUpdate.Role.HasValue)
            {
                Assert.That(rolesByChoiceIndex.ContainsKey(chatUpdate.ChoiceIndex.Value), Is.False);
                rolesByChoiceIndex[chatUpdate.ChoiceIndex.Value] = chatUpdate.Role.Value;
            }
            if (chatUpdate.ToolCallUpdate is not null)
            {
                Assert.That(chatUpdate.ToolCallUpdate, Is.InstanceOf<ChatCompletionsFunctionToolCall>());
            }
            if (chatUpdate.ToolCallUpdate is ChatCompletionsFunctionToolCall functionToolCall)
            {
                if (!string.IsNullOrEmpty(functionToolCall.Id))
                {
                    Assert.That(toolCallIdsByChoiceIndex.ContainsKey(chatUpdate.ChoiceIndex.Value), Is.False);
                    toolCallIdsByChoiceIndex[chatUpdate.ChoiceIndex.Value] = functionToolCall.Id;
                }
                if (functionToolCall.Name != null)
                {
                    Assert.That(toolCallFunctionNamesByChoiceIndex.ContainsKey(chatUpdate.ChoiceIndex.Value), Is.False);
                    toolCallFunctionNamesByChoiceIndex[chatUpdate.ChoiceIndex.Value] = functionToolCall.Name;
                }
                if (functionToolCall.Arguments != null)
                {
                    if (!toolCallFunctionArgumentsByChoiceIndex.ContainsKey(chatUpdate.ChoiceIndex.Value))
                    {
                        toolCallFunctionArgumentsByChoiceIndex[chatUpdate.ChoiceIndex.Value] = new();
                    }
                    toolCallFunctionArgumentsByChoiceIndex[chatUpdate.ChoiceIndex.Value].Append(functionToolCall.Arguments);
                }
            }
        }

        for (int i = 0; i < requestOptions.ChoiceCount; i++)
        {
            Assert.That(rolesByChoiceIndex[i], Is.EqualTo(ChatRole.Assistant));
            Assert.That(toolCallIdsByChoiceIndex[i], Is.Not.Null.Or.Empty);
            Assert.That(toolCallFunctionNamesByChoiceIndex[i], Is.EqualTo(s_futureTemperatureTool.Function.Name));
            Assert.That(toolCallFunctionArgumentsByChoiceIndex[i].Length, Is.GreaterThan(0));
        }
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

    private static ChatCompletionsFunctionToolDefinition s_futureTemperatureTool = new(new()
    {
        Name = s_futureTemperatureFunction.Name,
        Description = s_futureTemperatureFunction.Description,
        Parameters = s_futureTemperatureFunction.Parameters,
    });
}
