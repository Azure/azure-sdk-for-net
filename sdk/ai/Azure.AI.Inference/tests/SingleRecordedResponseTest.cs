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
            Assert.That(response.Id, Is.EqualTo("4567"));
            CollectionAssert.AreEqual(
                new[] {"content_filter", null, "stop"},
                response.FinishReasons);
            Assert.That(response.Model, Is.EqualTo("Phi2000"));
            Assert.That(response.CompletionTokens, Is.EqualTo(15));
            Assert.That(response.PromptTokens, Is.EqualTo(10));

            Assert.That(response.Choices.Length, Is.EqualTo(3));
            for (int i = 0; i < response.Choices.Length; i++)
            {
                var choiceEvent = JsonSerializer.SerializeToNode(response.Choices[i]);
                var message = choiceEvent["message"];
                Assert.NotNull(message);
                if (traceContent)
                {
                    Assert.NotNull(message["content"]);
                    Assert.That(message["content"].GetValue<string>(), Is.EqualTo(messages[i]));
                    Assert.That(message["tool_calls"], Is.Null);
                }
                else
                {
                    Assert.That(message["content"], Is.Null);
                }

                if (finishReasons[i].HasValue)
                {
                    Assert.That(choiceEvent["finish_reason"].GetValue<string>(), Is.EqualTo(finishReasons[i].ToString()));
                }
                else
                {
                    Assert.That(choiceEvent["finish_reason"], Is.Null);
                }

                Assert.NotNull(choiceEvent["index"]);
                Assert.That(choiceEvent["index"].GetValue<int>(), Is.EqualTo(i));
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
            Assert.That(response.Id, Is.EqualTo("12"));
            CollectionAssert.AreEqual(
                new List<string>()
                {
                    CompletionsFinishReason.ToolCalls.ToString(),
                    CompletionsFinishReason.ToolCalls.ToString(),
                    CompletionsFinishReason.ContentFiltered.ToString()
                },
                response.FinishReasons);

            Assert.That(response.Model, Is.EqualTo("Phi2001"));
            Assert.That(response.CompletionTokens, Is.EqualTo(15));
            Assert.That(response.PromptTokens, Is.EqualTo(10));

            for (int i = 0; i < response.Choices.Length; i++)
            {
                var choiceEvent = JsonSerializer.SerializeToNode(response.Choices[i]);
                var message = choiceEvent["message"];
                Assert.NotNull(message);
                if (traceContent || i == 2)
                {
                    if (traceContent)
                    {
                        Assert.That(message["content"].GetValue<string>(), Is.EqualTo(messages[i]));
                    }
                    else
                    {
                        Assert.That(message["content"], Is.Null);
                    }
                }
                else
                {
                    Assert.That(message["content"], Is.Null);
                }

                if (i != 2)
                {
                    Assert.That(message["tool_calls"], Is.Null);
                }
                else
                {
                    Assert.IsInstanceOf(typeof(JsonArray), message["tool_calls"]);
                    JsonArray toolCallsArray = message["tool_calls"].AsArray();
                    Assert.That(toolCallsArray.Count, Is.EqualTo(2));

                    Assert.That(toolCallsArray[0]["id"].GetValue<string>(), Is.EqualTo("4"));
                    Assert.That(toolCallsArray[1]["id"].GetValue<string>(), Is.EqualTo("5"));

                    Assert.That(toolCallsArray[0]["function"]["name"].GetValue<string>(), Is.EqualTo("func1"));
                    Assert.That(toolCallsArray[1]["function"]["name"].GetValue<string>(), Is.EqualTo("func1"));

                    if (traceContent)
                    {
                        Assert.That(toolCallsArray[0]["function"]["arguments"].GetValue<string>(), Is.EqualTo("{\"arg1\": \"gg\"}"));
                        Assert.That(toolCallsArray[1]["function"]["arguments"].GetValue<string>(), Is.EqualTo("{\"arg1\": \"gg\",\"arg2\": 432}"));
                    }
                    else
                    {
                        Assert.That(toolCallsArray[0]["function"]["arguments"], Is.Null);
                        Assert.That(toolCallsArray[1]["function"]["arguments"], Is.Null);
                    }
                }

                var finishReason = choiceEvent["finish_reason"];
                Assert.NotNull(finishReason);
                if (i == 2)
                {
                    Assert.That(finishReason.GetValue<string>(), Is.EqualTo("content_filter"));
                }
                else
                {
                    Assert.That(finishReason.GetValue<string>(), Is.EqualTo("tool_calls"));
                }

                Assert.NotNull(choiceEvent["index"]);
                Assert.That(choiceEvent["index"].GetValue<int>(), Is.EqualTo(i));
            }
        }
    }
}
