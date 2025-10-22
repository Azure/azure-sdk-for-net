// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.AI.OpenAI.Chat;
using Azure.AI.OpenAI.Images;
using OpenAI.Chat;
using OpenAI.TestFramework;

namespace Azure.AI.OpenAI.Tests
{
    public partial class ChatTests
    {
        private static readonly JsonSerializerOptions SERIALIZER_OPTIONS = new()
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        private static readonly ChatTool TOOL_TEMPERATURE = ChatTool.CreateFunctionTool(
            "get_future_temperature",
            "requests the anticipated future temperature at a provided location to help inform advice about topics like choice of attire",
            BinaryData.FromString(
            """
            {
                "type": "object",
                "properties": {
                    "locationName": {
                        "type": "string",
                        "description": "the name or brief description of a location for weather information"
                    },
                    "date": {
                        "type": "string",
                        "description": "the day, month, and year for which to retrieve weather information"
                    }
                }
            }
            """));

        private class TemperatureFunctionRequestArguments
        {
            public string? LocationName { get; set; }
            public string? Date { get; set; }
        }

        public enum ToolChoiceTestType
        {
            None,
            Auto,
            Tool,
            Required
        }

        [RecordedTest]
        [TestCase(ToolChoiceTestType.None)]
        [TestCase(ToolChoiceTestType.Auto)]
        [TestCase(ToolChoiceTestType.Tool)]
        [TestCase(ToolChoiceTestType.Required)]
        public async Task SimpleToolWorks(ToolChoiceTestType toolChoice)
        {
            ChatClient client = GetTestClient();

            List<ChatMessage> messages = new()
            {
                new SystemChatMessage("You are a helpful assistant."),
                new UserChatMessage("What should I wear in Honolulu next Thursday?")
            };
            var requestOptions = new ChatCompletionOptions()
            {
                ToolChoice = toolChoice switch
                {
                    ToolChoiceTestType.None => ChatToolChoice.CreateNoneChoice(),
                    ToolChoiceTestType.Auto => ChatToolChoice.CreateAutoChoice(),
                    ToolChoiceTestType.Tool => ChatToolChoice.CreateFunctionChoice(TOOL_TEMPERATURE.FunctionName),
                    ToolChoiceTestType.Required => ChatToolChoice.CreateRequiredChoice(),
                    _ => throw new NotImplementedException(),
                },
                Tools = { TOOL_TEMPERATURE },
                MaxOutputTokenCount = 512,
            };

            ClientResult<ChatCompletion> response = await client.CompleteChatAsync(messages, requestOptions);
            Assert.That(response, Is.Not.Null);

            ChatCompletion completion = response.Value;
            Assert.IsNotNull(completion);
            Assert.That(completion.Id, Is.Not.Null.Or.Empty);

            RequestContentFilterResult filter = completion.GetRequestContentFilterResult();
            Assert.IsNotNull(filter);
            Assert.That(filter.SelfHarm, Is.Not.Null);
            Assert.That(filter.SelfHarm.Filtered, Is.False);
            Assert.That(filter.SelfHarm.Severity, Is.EqualTo(ContentFilterSeverity.Safe));

            if (toolChoice == ToolChoiceTestType.None)
            {
                Assert.That(completion.FinishReason, Is.EqualTo(ChatFinishReason.Stop));
                Assert.That(completion.ToolCalls, Has.Count.EqualTo(0));

                Assert.That(completion.Content, Has.Count.GreaterThan(0));
                Assert.That(completion.Content, Has.All.Not.Null);

                ChatMessageContentPart content = completion.Content[0];
                Assert.That(content.Kind, Is.EqualTo(ChatMessageContentPartKind.Text));
                Assert.That(content.Text, Is.Not.Null.Or.Empty);

                // test complete, as we were merely validating that we didn't get what we shouldn't
                return;
            }

            // TODO old tests look for stop reason of function_call for both auto and function, but the service currently returns "stop"
            // for function
            if (toolChoice == ToolChoiceTestType.Auto || toolChoice == ToolChoiceTestType.Required)
            {
                Assert.That(completion.FinishReason, Is.EqualTo(ChatFinishReason.ToolCalls));
            }
            else
            {
                Assert.That(completion.FinishReason, Is.EqualTo(ChatFinishReason.Stop));
            }

            Assert.That(completion.Content, Has.Count.EqualTo(0));
            Assert.That(completion.ToolCalls, Has.Count.EqualTo(1));
            Assert.That(completion.ToolCalls, Has.All.Not.Null);

            ChatToolCall toolCall = completion.ToolCalls[0];
            Assert.That(toolCall.Id, Is.Not.Null.Or.Empty);
            Assert.That(toolCall.Kind, Is.EqualTo(ChatToolCallKind.Function));
            Assert.That(toolCall.FunctionName, Is.EqualTo(TOOL_TEMPERATURE.FunctionName));
            Assert.That(toolCall.FunctionArguments, Is.Not.Null);
            var parsedArgs = JsonSerializer.Deserialize<TemperatureFunctionRequestArguments>(toolCall.FunctionArguments, SERIALIZER_OPTIONS)!;
            Assert.That(parsedArgs, Is.Not.Null);
            Assert.That(parsedArgs.LocationName, Is.Not.Null.Or.Empty);
            Assert.That(parsedArgs.Date, Is.Not.Null.Or.Empty);

            // Complete the tool call
            messages.Add(new AssistantChatMessage([toolCall]));
            messages.Add(new ToolChatMessage(toolCall.Id, JsonSerializer.Serialize(new
            {
                temperature = 31,
                unit = "celsius"
            })));

            requestOptions = new()
            {
                Tools = { TOOL_TEMPERATURE },
                MaxOutputTokenCount = requestOptions.MaxOutputTokenCount
            };

            completion = await client.CompleteChatAsync(messages, requestOptions);
            Assert.That(completion, Is.Not.Null);
            Assert.That(completion.FinishReason, Is.EqualTo(ChatFinishReason.Stop));

            RequestContentFilterResult promptFilter = completion.GetRequestContentFilterResult();
            Assert.That(promptFilter, Is.Not.Null);
            Assert.That(promptFilter.Hate, Is.Not.Null);
            Assert.That(promptFilter.Hate.Severity, Is.EqualTo(ContentFilterSeverity.Safe));
            Assert.That(promptFilter.Hate.Filtered, Is.False);

            ResponseContentFilterResult responseFilter = completion.GetResponseContentFilterResult();
            Assert.That(responseFilter, Is.Not.Null);
            Assert.That(responseFilter.Hate, Is.Not.Null);
            Assert.That(responseFilter.Hate.Severity, Is.EqualTo(ContentFilterSeverity.Safe));
            Assert.That(responseFilter.Hate.Filtered, Is.False);

            Assert.That(completion.Content, Has.Count.GreaterThan(0));
            Assert.That(completion.Content, Has.All.Not.Null);
            Assert.That(completion.Content[0].Text, Is.Not.Null.Or.Empty);
            Assert.That(completion.Content[0].Kind, Is.EqualTo(ChatMessageContentPartKind.Text));
        }

        [RecordedTest]
        [TestCase(ToolChoiceTestType.None)]
        [TestCase(ToolChoiceTestType.Auto)]
        [TestCase(ToolChoiceTestType.Tool)]
        [TestCase(ToolChoiceTestType.Required)]
        public async Task SimpleToolWorksStreaming(ToolChoiceTestType toolChoice)
        {
            StringBuilder content = new();
            bool foundPromptFilter = false;
            bool foundResponseFilter = false;
            string? toolId = null;
            string? toolName = null;
            StringBuilder toolArgs = new();

            ChatClient client = GetTestClient();

            List<ChatMessage> messages = new()
            {
                new SystemChatMessage("You are a helpful assistant."),
                new UserChatMessage("What should I wear in Honolulu next Thursday?")
            };
            var requestOptions = new ChatCompletionOptions()
            {
                ToolChoice = toolChoice switch
                {
                    ToolChoiceTestType.None => ChatToolChoice.CreateNoneChoice(),
                    ToolChoiceTestType.Auto => ChatToolChoice.CreateAutoChoice(),
                    ToolChoiceTestType.Tool => ChatToolChoice.CreateFunctionChoice(TOOL_TEMPERATURE.FunctionName),
                    ToolChoiceTestType.Required => ChatToolChoice.CreateRequiredChoice(),
                    _ => throw new NotImplementedException(),
                },
                Tools = { TOOL_TEMPERATURE },
                MaxOutputTokenCount = 512,
            };

            Action<StreamingChatCompletionUpdate> validateUpdate = (update) =>
            {
                Assert.That(update.ContentUpdate, Is.Not.Null);
                Assert.That(update.ContentUpdate, Has.All.Not.Null);
                Assert.That(update.ToolCallUpdates, Is.Not.Null);
                Assert.That(update.ToolCallUpdates, Has.All.Not.Null);

                if (update.ToolCallUpdates.Count > 0)
                {
                    Assert.That(update.ToolCallUpdates, Has.Count.EqualTo(1));

                    StreamingChatToolCallUpdate toolUpdate = update.ToolCallUpdates[0];
                    Assert.That(toolUpdate.Index, Is.EqualTo(0));
                    Assert.That(toolUpdate.ToolCallId, Is.Null.Or.Not.Empty);
                    toolId ??= toolUpdate.ToolCallId;
                    Assert.That(toolUpdate.FunctionName, Is.Null.Or.EqualTo(TOOL_TEMPERATURE.FunctionName));
                    toolName ??= toolUpdate.FunctionName;

                    Assert.That(toolUpdate.FunctionArgumentsUpdate, Is.Not.Null);
                    if (!toolUpdate.FunctionArgumentsUpdate.ToMemory().IsEmpty)
                    {
                        toolArgs.Append(toolUpdate.FunctionArgumentsUpdate.ToString());
                    }
                }

                foreach (var part in update.ContentUpdate)
                {
                    Assert.That(part.Kind, Is.EqualTo(ChatMessageContentPartKind.Text));
                    Assert.That(part.Text, Is.Not.Null); // Could be empty string

                    content.Append(part.Text);
                }

                var promptFilter = update.GetRequestContentFilterResult();
                if (!foundPromptFilter && promptFilter?.Hate != null)
                {
                    Assert.That(promptFilter.Hate.Filtered, Is.False);
                    Assert.That(promptFilter.Hate.Severity, Is.EqualTo(ContentFilterSeverity.Safe));
                    foundPromptFilter = true;
                }

                var responseFilter = update.GetResponseContentFilterResult();
                if (!foundResponseFilter && responseFilter?.Hate != null)
                {
                    Assert.That(responseFilter.Hate.Filtered, Is.False);
                    Assert.That(responseFilter.Hate.Severity, Is.EqualTo(ContentFilterSeverity.Safe));
                    foundResponseFilter = true;
                }
            };

            AsyncCollectionResult<StreamingChatCompletionUpdate> response = client.CompleteChatStreamingAsync(messages, requestOptions);
            Assert.That(response, Is.Not.Null);

            await foreach (StreamingChatCompletionUpdate update in response)
            {
                validateUpdate(update);
            }

            Assert.That(foundPromptFilter, Is.True);

            if (toolChoice != ToolChoiceTestType.None)
            {
                Assert.That(content, Has.Length.EqualTo(0));
                Assert.That(toolId, Is.Not.Null);
                Assert.That(toolName, Is.Not.Null);
                Assert.That(toolArgs, Has.Length.GreaterThan(0));
                var parsedArgs = JsonSerializer.Deserialize<TemperatureFunctionRequestArguments>(toolArgs.ToString(), SERIALIZER_OPTIONS)!;
                Assert.That(parsedArgs, Is.Not.Null);
                Assert.That(parsedArgs.LocationName, Is.Not.Null.Or.Empty);
                Assert.That(parsedArgs.Date, Is.Not.Null.Or.Empty);

                // Complete the tool call
                messages.Add(
                    new AssistantChatMessage(
                        [
                            ChatToolCall.CreateFunctionToolCall(
                                toolId,
                                toolName,
                                BinaryData.FromString(toolArgs.ToString())
                            )
                        ]
                    )
                );
                messages.Add(new ToolChatMessage(toolId, JsonSerializer.Serialize(new
                {
                    temperature = 31,
                    unit = "celsius"
                })));

                requestOptions = new()
                {
                    Tools = { TOOL_TEMPERATURE },
                    MaxOutputTokenCount = requestOptions.MaxOutputTokenCount
                };

                content.Clear();
                foundPromptFilter = false;
                foundResponseFilter = false;
                toolId = null;
                toolName = null;
                toolArgs.Clear();

                response = client.CompleteChatStreamingAsync(messages, requestOptions);
                Assert.That(response, Is.Not.Null);

                await foreach (StreamingChatCompletionUpdate update in response)
                {
                    validateUpdate(update);
                }
            }

            Assert.That(foundPromptFilter, Is.True);
            Assert.That(foundResponseFilter, Is.True);
            Assert.That(content.ToString(), Is.Not.Null.Or.Empty);
            Assert.That(toolId, Is.Null);
            Assert.That(toolName, Is.Null);
            Assert.That(toolArgs, Has.Length.EqualTo(0));
        }
    }
}
