// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
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
        : base(Scenario.ChatTools, isAsync) // , RecordedTestMode.Live)
    {
    }

    public enum ToolChoiceTestType
    {
        DoNotSpecifyToolChoice,
        UseAutoPresetToolChoice,
        UseNonePresetToolChoice,
        UseFunctionByExplicitToolDefinitionForToolChoice,
        UseFunctionByExplicitFunctionDefinitionForToolChoice,
        UseFunctionByImplicitToolDefinitionForToolChoice,
        UseFunctionByImplicitFunctionDefinitionForToolChoice,
    }

    [RecordedTest]
    [TestCase(Service.NonAzure)]
    [TestCase(Service.NonAzure, ToolChoiceTestType.UseAutoPresetToolChoice)]
    [TestCase(Service.NonAzure, ToolChoiceTestType.UseNonePresetToolChoice)]
    [TestCase(Service.NonAzure, ToolChoiceTestType.UseFunctionByExplicitToolDefinitionForToolChoice)]
    [TestCase(Service.Azure)]
    [TestCase(Service.Azure, ToolChoiceTestType.UseAutoPresetToolChoice)]
    [TestCase(Service.Azure, ToolChoiceTestType.UseNonePresetToolChoice)]
    [TestCase(Service.Azure, ToolChoiceTestType.UseFunctionByExplicitToolDefinitionForToolChoice)]
    [TestCase(Service.Azure, ToolChoiceTestType.UseFunctionByExplicitFunctionDefinitionForToolChoice)]
    [TestCase(Service.Azure, ToolChoiceTestType.UseFunctionByImplicitToolDefinitionForToolChoice)]
    [TestCase(Service.Azure, ToolChoiceTestType.UseFunctionByImplicitFunctionDefinitionForToolChoice)]
    public async Task SimpleFunctionToolWorks(
        Service serviceTarget,
        ToolChoiceTestType toolChoiceType = ToolChoiceTestType.DoNotSpecifyToolChoice)
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

        requestOptions.ToolChoice = toolChoiceType switch
        {
            ToolChoiceTestType.UseAutoPresetToolChoice => ChatCompletionsToolChoice.Auto,
            ToolChoiceTestType.UseNonePresetToolChoice => ChatCompletionsToolChoice.None,
            ToolChoiceTestType.UseFunctionByExplicitToolDefinitionForToolChoice => new ChatCompletionsToolChoice(s_futureTemperatureTool),
            ToolChoiceTestType.UseFunctionByExplicitFunctionDefinitionForToolChoice => new ChatCompletionsToolChoice(s_futureTemperatureFunction),
            ToolChoiceTestType.UseFunctionByImplicitToolDefinitionForToolChoice => s_futureTemperatureTool,
            ToolChoiceTestType.UseFunctionByImplicitFunctionDefinitionForToolChoice => s_futureTemperatureFunction,
            _ => null,
        };

        Response<ChatCompletions> response = await client.GetChatCompletionsAsync(requestOptions);
        Assert.That(response, Is.Not.Null);

        Assert.That(response.Value, Is.Not.Null);
        Assert.That(response.Value.Choices, Is.Not.Null.Or.Empty);

        ChatChoice choice = response.Value.Choices[0];

        if (toolChoiceType == ToolChoiceTestType.UseNonePresetToolChoice)
        {
            Assert.That(choice.FinishReason, Is.EqualTo(CompletionsFinishReason.Stopped));
            Assert.That(choice.Message.ToolCalls, Is.Null.Or.Empty);
            // We finish the test here as there's no further exercise for 'none' beyond ensuring we didn't do what we
            // weren't meant to
            return;
        }
        else if (toolChoiceType == ToolChoiceTestType.UseAutoPresetToolChoice || toolChoiceType == ToolChoiceTestType.DoNotSpecifyToolChoice)
        {
            Assert.That(choice.FinishReason, Is.EqualTo(CompletionsFinishReason.ToolCalls));
            // and continue the test
        }
        else
        {
            Assert.That(choice.FinishReason, Is.EqualTo(CompletionsFinishReason.Stopped));
            // and continue the test, as we will have tool_calls
        }

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
        followupOptions.Messages.Add(new ChatRequestAssistantMessage(choice.Message));

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
            Tools = { s_getUserNumberForColorTool },
            Messages =
            {
                new ChatRequestSystemMessage("You are a helpful assistant."),
                new ChatRequestUserMessage("What's the sum of the numbers for red, green, and blue?"),
            },
            MaxTokens = 512,
            ChoiceCount = 3,
        };

        StreamingResponse<StreamingChatCompletionsUpdate> response
            = await client.GetChatCompletionsStreamingAsync(requestOptions);
        Assert.That(response, Is.Not.Null);

        Dictionary<int, ChatRole> rolesByChoiceIndex = new();
        Dictionary<int, StringBuilder> contentBuildersByChoiceIndex = new();
        Dictionary<(int, int), string> toolCallIdsByChoiceAndCallIndices = new();
        Dictionary<(int, int), string> toolCallFunctionNamesByChoiceAndCallIndices = new();
        Dictionary<(int, int), StringBuilder> toolCallFunctionArgumentsByChoiceAndCallIndices = new();

        await foreach (StreamingChatCompletionsUpdate chatUpdate in response)
        {
            if (chatUpdate.ChoiceIndex.HasValue)
            {
                if (!contentBuildersByChoiceIndex.ContainsKey(chatUpdate.ChoiceIndex.Value))
                {
                    contentBuildersByChoiceIndex[chatUpdate.ChoiceIndex.Value] = new();
                }
                contentBuildersByChoiceIndex[chatUpdate.ChoiceIndex.Value].Append(chatUpdate.ContentUpdate);
            }
            if (chatUpdate.Role.HasValue)
            {
                Assert.That(rolesByChoiceIndex.ContainsKey(chatUpdate.ChoiceIndex.Value), Is.False);
                Assert.That(chatUpdate.ChoiceIndex, Is.Not.Null);
                rolesByChoiceIndex[chatUpdate.ChoiceIndex.Value] = chatUpdate.Role.Value;
            }
            if (chatUpdate.ToolCallUpdate is not null)
            {
                Assert.That(chatUpdate.ToolCallUpdate, Is.InstanceOf<StreamingToolCallUpdate>());
            }
            if (chatUpdate.ToolCallUpdate is StreamingFunctionToolCallUpdate functionToolCallUpdate)
            {
                Assert.That(chatUpdate.ChoiceIndex, Is.Not.Null);
                int choiceIndex = chatUpdate.ChoiceIndex.Value;
                int callIndex = functionToolCallUpdate.ToolCallIndex;
                (int, int) mapKey = (choiceIndex, callIndex);
                if (!string.IsNullOrEmpty(functionToolCallUpdate.Id))
                {
                    Assert.That(toolCallIdsByChoiceAndCallIndices.ContainsKey(mapKey), Is.False);
                    toolCallIdsByChoiceAndCallIndices[mapKey] = functionToolCallUpdate.Id;
                }
                if (functionToolCallUpdate.Name != null)
                {
                    Assert.That(toolCallFunctionNamesByChoiceAndCallIndices.ContainsKey(mapKey), Is.False);
                    toolCallFunctionNamesByChoiceAndCallIndices[mapKey] = functionToolCallUpdate.Name;
                }
                if (functionToolCallUpdate.ArgumentsUpdate != null)
                {
                    if (!toolCallFunctionArgumentsByChoiceAndCallIndices.ContainsKey(mapKey))
                    {
                        toolCallFunctionArgumentsByChoiceAndCallIndices[mapKey] = new();
                    }
                    toolCallFunctionArgumentsByChoiceAndCallIndices[mapKey]
                        .Append(functionToolCallUpdate.ArgumentsUpdate);
                }
            }
        }

        Assert.That(
            rolesByChoiceIndex.Count,
            Is.EqualTo(1),
            $"{nameof(requestOptions.ChoiceCount)} should be ignored when providing tools!");
        Assert.That(toolCallIdsByChoiceAndCallIndices.Count, Is.EqualTo(3));
        Assert.That(toolCallFunctionNamesByChoiceAndCallIndices.Count, Is.EqualTo(3));
        Assert.That(toolCallFunctionArgumentsByChoiceAndCallIndices.Count, Is.EqualTo(3));

        foreach (int roleChoiceIndex in rolesByChoiceIndex.Keys)
        {
            Assert.That(rolesByChoiceIndex[roleChoiceIndex], Is.EqualTo(ChatRole.Assistant));
            foreach (KeyValuePair<(int, int), string> pair in toolCallIdsByChoiceAndCallIndices)
            {
                (int choiceIndex, int callIndex) = pair.Key;
                Assert.That(choiceIndex, Is.EqualTo(roleChoiceIndex));
                string id = pair.Value;
                Assert.That(choiceIndex >= 0 && choiceIndex < requestOptions.ChoiceCount, Is.True);
                Assert.That(callIndex >= 0 && callIndex <= 3, Is.True);
                Assert.That(id, Is.Not.Null.Or.Empty);
                Assert.That(toolCallFunctionNamesByChoiceAndCallIndices[(choiceIndex, callIndex)],
                    Is.EqualTo(s_getUserNumberForColorTool.Name));
                string arguments = toolCallFunctionArgumentsByChoiceAndCallIndices[(choiceIndex, callIndex)].ToString();
                using JsonDocument deserializedArguments = JsonDocument.Parse(arguments);
            }
        }

        ChatRequestAssistantMessage assistantHistoryMessage = new(contentBuildersByChoiceIndex.First().Value.ToString());
        foreach ((int, int) choiceAndCallKey in toolCallIdsByChoiceAndCallIndices.Keys)
        {
            assistantHistoryMessage.ToolCalls.Add(new ChatCompletionsFunctionToolCall(
                id: toolCallIdsByChoiceAndCallIndices[choiceAndCallKey],
                name: toolCallFunctionNamesByChoiceAndCallIndices[choiceAndCallKey],
                arguments: toolCallFunctionArgumentsByChoiceAndCallIndices[choiceAndCallKey].ToString()));
        }
        requestOptions.Messages.Add(assistantHistoryMessage);

        foreach (string toolCallId in toolCallIdsByChoiceAndCallIndices.Values)
        {
            requestOptions.Messages.Add(new ChatRequestToolMessage(
                "red is 1; green is 2; blue is 4; yellow is 8; chartreuse is 16",
                toolCallId));
        }

        StreamingResponse<StreamingChatCompletionsUpdate> followupResponse
            = await client.GetChatCompletionsStreamingAsync(requestOptions);
        Assert.That(response, Is.Not.Null);

        List<StringBuilder> followupContentBuilders = new();
        await foreach (StreamingChatCompletionsUpdate followupUpdate in followupResponse)
        {
            if (followupUpdate.ChoiceIndex.HasValue)
            {
                Assert.That(followupUpdate.ChoiceIndex.Value, Is.GreaterThanOrEqualTo(0));
                Assert.That(followupUpdate.ChoiceIndex.Value, Is.LessThan(requestOptions.ChoiceCount));
                while (followupContentBuilders.Count <= followupUpdate.ChoiceIndex.Value)
                {
                    followupContentBuilders.Add(new());
                }
                followupContentBuilders[followupUpdate.ChoiceIndex.Value].Append(followupUpdate.ContentUpdate);

                if (followupUpdate.Role.HasValue)
                {
                    Assert.That(followupUpdate.Role, Is.EqualTo(ChatRole.Assistant));
                }
            }
        }

        Assert.That(followupContentBuilders.Count, Is.EqualTo(requestOptions.ChoiceCount));
        foreach (StringBuilder contentBuilder in followupContentBuilders)
        {
            Assert.That(contentBuilder.ToString().Contains("7"));
        }
    }

    [RecordedTest]
    [TestCase(Service.Azure)]
    [TestCase(Service.NonAzure)]
    public async Task JsonModeWorks(Service serviceTarget)
    {
        OpenAIClient client = GetTestClient(serviceTarget);
        string deploymentOrModelName = GetDeploymentOrModelName(serviceTarget);

        ChatCompletionsOptions chatCompletionsOptions = new()
        {
            DeploymentName = deploymentOrModelName,
            Messages = { new ChatRequestUserMessage("give me a list of five fruits. JSON is a delightful wire format, don't you think?") },
            ResponseFormat = ChatCompletionsResponseFormat.JsonObject,
        };

        Response<ChatCompletions> response = await client.GetChatCompletionsAsync(chatCompletionsOptions);
        Assert.That(response, Is.Not.Null);
        Assert.That(response.Value, Is.InstanceOf<ChatCompletions>());
        Assert.That(response.Value.Choices?.Count, Is.EqualTo(1));

        string content = response.Value.Choices[0].Message.Content;
        var jsonDocument = JsonDocument.Parse(content);
        Assert.That(jsonDocument?.RootElement, Is.Not.Null);

        int fruitCount = 0;

        foreach (JsonProperty property in jsonDocument.RootElement.EnumerateObject())
        {
            Assert.That(property.Name.Contains("fruit"));
            Assert.That(property.Value.ValueKind, Is.EqualTo(JsonValueKind.Array));
            foreach (JsonElement fruitItem in property.Value.EnumerateArray())
            {
                Assert.That(fruitItem.ValueKind, Is.EqualTo(JsonValueKind.String));
                fruitCount++;
            }
        }

        Assert.That(fruitCount, Is.GreaterThan(0));
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

    private static ChatCompletionsFunctionToolDefinition s_getUserNumberForColorTool = new()
    {
        Name = "getUserNumberForColor",
        Description = "Gets a number from the user that's associated with a provided color.",
        Parameters = BinaryData.FromObjectAsJson(new
        {
            Type = "object",
            Properties = new
            {
                Color = new
                {
                    Type = "string",
                    Enum = new dynamic[] { "red", "blue", "green", "yellow", "chartreuse" },
                }
            }
        },
        new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }),
    };
}
