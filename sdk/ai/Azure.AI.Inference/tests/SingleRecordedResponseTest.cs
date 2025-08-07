// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System;
using Azure.AI.Inference.Telemetry;
using NUnit.Framework;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Azure.AI.Inference.Tests
{
    public class SingleRecordedResponseTest
    {
        [Test]
        public void TestWithoutTools(
            [Values(true, false)] bool traceContent
            )
        {
            CompletionsUsage usage = new(
                promptTokens: 10,
                completionTokens: 15,
                totalTokens: 25
            );
            string[] messages = new string[]{
                "You are helpful assistant.",
                "What is a capital of France.",
                "The capital of France is Paris."
            };
            ChatRole[] roles = new ChatRole[] {
                ChatRole.System, ChatRole.User, ChatRole.Assistant
            };
            CompletionsFinishReason?[] finishReasons = new CompletionsFinishReason?[]{
                CompletionsFinishReason.ContentFiltered,
                null,
                CompletionsFinishReason.Stopped
            };
            List<ChatChoice> choices = new();
            for (int i = 0; i < 3; i++)
            {
                choices.Add(
                    new ChatChoice(
                    index: i,
                    finishReason: finishReasons[i],
                    message: new ChatResponseMessage(
                        role: roles[i],
                        content: messages[i]
                    ),
                    serializedAdditionalRawData: new Dictionary<string, BinaryData>()));
            }

            var completions = new ChatCompletions(
                id: "4567",
                created: DateTimeOffset.Now,
                model: "Phi2000",
                usage: usage,
                choices: choices,
                serializedAdditionalRawData: new Dictionary<string, BinaryData>());
            var response = new RecordedResponse(completions, traceContent);
            Assert.AreEqual("4567", response.Id);
            CollectionAssert.AreEqual(
                new[] {"content_filter", null, "stop"},
                response.FinishReasons);
            Assert.AreEqual("Phi2000", response.Model);
            Assert.AreEqual(15, response.CompletionTokens);
            Assert.AreEqual(10, response.PromptTokens);

            Assert.AreEqual(3, response.Choices.Length);
            for (int i = 0; i < response.Choices.Length; i++)
            {
                var choiceEvent = JsonSerializer.SerializeToNode(response.Choices[i]);
                var message = choiceEvent["message"];
                Assert.NotNull(message);
                if (traceContent)
                {
                    Assert.NotNull(message["content"]);
                    Assert.AreEqual(messages[i], message["content"].GetValue<string>());
                    Assert.Null(message["tool_calls"]);
                }
                else
                {
                    Assert.Null(message["content"]);
                }

                if (finishReasons[i].HasValue)
                {
                    Assert.AreEqual(finishReasons[i].ToString(), choiceEvent["finish_reason"].GetValue<string>());
                }
                else
                {
                    Assert.IsNull(choiceEvent["finish_reason"]);
                }

                Assert.NotNull(choiceEvent["index"]);
                Assert.AreEqual(i, choiceEvent["index"].GetValue<int>());
            }
        }

        [Test]
        public void TestWithTools(
            [Values(true, false)] bool traceContent
            )
        {
            CompletionsUsage usage = new(
                promptTokens: 10,
                completionTokens: 15,
                totalTokens: 25
            );
            string[] messages = new string[]{
                "You are helpful assistant.",
                "What is a capital of France.",
                "The capital of France is Paris."
            };

            ChatRole[] roles = new ChatRole[] {
                ChatRole.System, ChatRole.User, ChatRole.Assistant
            };
            List<ChatCompletionsToolCall>[] toolCalls = new List<ChatCompletionsToolCall>[]
            {
                new(),
                null,
                new List<ChatCompletionsToolCall>()
                {
                    new ChatCompletionsToolCall(
                        id: "4",
                        function: new FunctionCall(
                            name: "func1",
                            arguments: "{\"arg1\": \"gg\"}"
                        )
                    ),
                    new ChatCompletionsToolCall(
                        id: "5",
                        function: new FunctionCall(
                            name: "func1",
                            arguments: "{\"arg1\": \"gg\",\"arg2\": 432}"
                        )
                    )
                }
            };
            List<ChatChoice> choices = new();
            for (int i = 0; i < 3; i++)
            {
                choices.Add(
                    new ChatChoice(
                    index: i,
                    finishReason: i == 2 ? CompletionsFinishReason.ContentFiltered : CompletionsFinishReason.ToolCalls,
                    message: new ChatResponseMessage(
                        role: roles[i],
                        content: messages[i],
                        toolCalls: toolCalls[i],
                        serializedAdditionalRawData: new Dictionary<string, BinaryData>()
                    ),
                    serializedAdditionalRawData: new Dictionary<string, BinaryData>()));
            }
            var completions = new ChatCompletions(
                id: "12",
                created: DateTimeOffset.Now,
                model: "Phi2001",
                usage: usage,
                choices: choices,
                serializedAdditionalRawData: new Dictionary<string, BinaryData>());
            var response = new RecordedResponse(completions, traceContent);
            Assert.AreEqual("12", response.Id);
            CollectionAssert.AreEqual(
                new List<string>()
                {
                    CompletionsFinishReason.ToolCalls.ToString(),
                    CompletionsFinishReason.ToolCalls.ToString(),
                    CompletionsFinishReason.ContentFiltered.ToString()
                },
                response.FinishReasons);

            Assert.AreEqual("Phi2001", response.Model);
            Assert.AreEqual(15, response.CompletionTokens);
            Assert.AreEqual(10, response.PromptTokens);

            for (int i = 0; i < response.Choices.Length; i++)
            {
                var choiceEvent = JsonSerializer.SerializeToNode(response.Choices[i]);
                var message = choiceEvent["message"];
                Assert.NotNull(message);
                if (traceContent || i == 2)
                {
                    if (traceContent)
                    {
                        Assert.AreEqual(messages[i], message["content"].GetValue<string>());
                    }
                    else
                    {
                        Assert.Null(message["content"]);
                    }
                }
                else
                {
                    Assert.Null(message["content"]);
                }

                if (i != 2)
                {
                    Assert.Null(message["tool_calls"]);
                }
                else
                {
                    Assert.IsInstanceOf(typeof(JsonArray), message["tool_calls"]);
                    JsonArray toolCallsArray = message["tool_calls"].AsArray();
                    Assert.AreEqual(2, toolCallsArray.Count);

                    Assert.AreEqual("4", toolCallsArray[0]["id"].GetValue<string>());
                    Assert.AreEqual("5", toolCallsArray[1]["id"].GetValue<string>());

                    Assert.AreEqual("func1", toolCallsArray[0]["function"]["name"].GetValue<string>());
                    Assert.AreEqual("func1", toolCallsArray[1]["function"]["name"].GetValue<string>());

                    if (traceContent)
                    {
                        Assert.AreEqual("{\"arg1\": \"gg\"}", toolCallsArray[0]["function"]["arguments"].GetValue<string>());
                        Assert.AreEqual("{\"arg1\": \"gg\",\"arg2\": 432}", toolCallsArray[1]["function"]["arguments"].GetValue<string>());
                    }
                    else
                    {
                        Assert.Null(toolCallsArray[0]["function"]["arguments"]);
                        Assert.Null(toolCallsArray[1]["function"]["arguments"]);
                    }
                }

                var finishReason = choiceEvent["finish_reason"];
                Assert.NotNull(finishReason);
                if (i == 2)
                {
                    Assert.AreEqual("content_filter", finishReason.GetValue<string>());
                }
                else
                {
                    Assert.AreEqual("tool_calls", finishReason.GetValue<string>());
                }

                Assert.NotNull(choiceEvent["index"]);
                Assert.AreEqual(i, choiceEvent["index"].GetValue<int>());
            }
        }
    }
}
