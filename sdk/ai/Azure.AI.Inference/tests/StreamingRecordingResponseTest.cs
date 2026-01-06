// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using Azure.AI.Inference.Telemetry;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Azure.AI.Inference.Tests
{
    public class StreamingRecordingResponseTest
    {
        [Test]
        public void TestSeveralChunks(
            [Values(true, false)] bool withUsage,
            [Values(true, false)] bool traceContent
            )
        {
            CompletionsFinishReason? nullVal = null;
            ResponseBuffer resp = new(traceContent);
            resp.Update(new(
                id: "1",
                model: "gpt-100o",
                created: DateTimeOffset.Now,
                role: ChatRole.Assistant,
                finishReason: nullVal,
                contentUpdate: "First"
            ));
            resp.Update(new(
                id: "2",
                model: "gpt-100o",
                created: DateTimeOffset.Now,
                role: ChatRole.Assistant,
                finishReason: nullVal,
                contentUpdate: " second"
            ));
            resp.Update(new(
                id: "3",
                model: "gpt-100o",
                created: DateTimeOffset.Now,
                role: ChatRole.Assistant,
                finishReason: CompletionsFinishReason.Stopped,
                contentUpdate: " third"
            ));
            if (withUsage)
            {
                resp.Update(new StreamingChatCompletionsUpdate(
                    id: "4",
                    model: "gpt-100o",
                    created: DateTimeOffset.Now,
                    choices: new List<StreamingChatChoiceUpdate>(),
                    usage: new CompletionsUsage(
                        totalTokens: 10,
                        completionTokens: 7,
                        promptTokens: 3
                        )
                ));
            }

            RecordedResponse response = resp.ToResponse();

            Assert.That(response.FinishReasons, Is.EqualTo(new[] { "stop" }).AsCollection);
            Assert.Multiple(() =>
            {
                Assert.That("gpt-100o", Is.EqualTo(response.Model));
                Assert.That(withUsage ? "4" : "3", Is.EqualTo(response.Id));

                Assert.That(response.CompletionTokens, Is.EqualTo(withUsage ? 7 : null));
                Assert.That(response.PromptTokens, Is.EqualTo(withUsage ? 3 : null));

                Assert.That(response.Choices.Length, Is.EqualTo(1));
            });

            var choiceEvent = JsonSerializer.SerializeToNode(response.Choices[0]);
            var message = choiceEvent["message"];
            Assert.That(message, Is.Not.Null);

            if (traceContent)
            {
                Assert.That(message["content"], Is.Not.Null);
                Assert.Multiple(() =>
                {
                    Assert.That(message["content"].GetValue<string>(), Is.EqualTo("First second third"));
                    Assert.That(message["tool_calls"], Is.Null);
                });
            }
            else
            {
                Assert.That(message["content"], Is.Null);
            }

            var finishReason = choiceEvent["finish_reason"];
            Assert.That(finishReason, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(finishReason.GetValue<string>(), Is.EqualTo("stop"));

                Assert.That(choiceEvent["index"], Is.Not.Null);
            });
            Assert.That(choiceEvent["index"].GetValue<int>(), Is.EqualTo(0));
        }

        [Test]
        public void TestWithTools([Values(true, false)] bool traceContent)
        {
            ResponseBuffer resp = new(traceContent);
            resp.Update(GetToolUpdate("first", "func1", "{\"arg1\": 42}", "tool_call_1", 0, false));
            resp.Update(GetToolUpdate(" second", "func2", "{\"arg1\": 42,", "tool_call_2", 1, false));
            resp.Update(GetToolUpdate(" third", "func2", "\"arg2\": 43}", "tool_call_2", 1, true));

            RecordedResponse response = resp.ToResponse();
            Assert.That("1", Is.EqualTo(response.Id));
            Assert.That(response.FinishReasons, Is.EqualTo(new[] { "tool_calls" }).AsCollection);
            Assert.Multiple(() =>
            {
                Assert.That("gpt-100o", Is.EqualTo(response.Model));

                Assert.That(response.Choices.Length, Is.EqualTo(1));
            });

            var choiceEvent = JsonSerializer.SerializeToNode(response.Choices[0]);
            var message = choiceEvent["message"];
            Assert.That(message, Is.Not.Null);

            if (traceContent)
            {
                Assert.That(message["content"].GetValue<string>(), Is.EqualTo("first second third"));
            }

            Assert.That(message["tool_calls"], Is.Not.Null);

            Assert.That(message["tool_calls"], Is.InstanceOf(typeof(JsonArray)));
            JsonArray toolCallsArray = message["tool_calls"].AsArray();
            Assert.That(toolCallsArray, Has.Count.EqualTo(2));

            Assert.Multiple(() =>
            {
                Assert.That(toolCallsArray[0]["id"].GetValue<string>(), Is.EqualTo("tool_call_1"));
                Assert.That(toolCallsArray[1]["id"].GetValue<string>(), Is.EqualTo("tool_call_2"));

                Assert.That(toolCallsArray[0]["function"]["name"].GetValue<string>(), Is.EqualTo("func1"));
                Assert.That(toolCallsArray[1]["function"]["name"].GetValue<string>(), Is.EqualTo("func2"));
            });

            if (traceContent)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(toolCallsArray[0]["function"]["arguments"].GetValue<string>(), Is.EqualTo("{\"arg1\": 42}"));
                    Assert.That(toolCallsArray[1]["function"]["arguments"].GetValue<string>(), Is.EqualTo("{\"arg1\": 42,\"arg2\": 43}"));
                });
            }
            else
            {
                Assert.Multiple(() =>
                {
                    Assert.That(toolCallsArray[0]["function"]["arguments"], Is.Null);
                    Assert.That(toolCallsArray[1]["function"]["arguments"], Is.Null);
                });
            }

            var finishReason = choiceEvent["finish_reason"];
            Assert.That(finishReason, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(finishReason.GetValue<string>(), Is.EqualTo("tool_calls"));

                Assert.That(choiceEvent["index"], Is.Not.Null);
            });
            Assert.That(choiceEvent["index"].GetValue<int>(), Is.EqualTo(0));
        }

        #region Helpers
        private static StreamingChatCompletionsUpdate GetToolUpdate(string content, string functionName, string argsUpdate, string toolCallId, int index, bool isLast)
        {
            var toolUpdate = new {
                function = new {
                    name = functionName,
                    arguments = argsUpdate
                },
                type = "function",
                id = toolCallId,
                index
            };

            return new StreamingChatCompletionsUpdate(
                id: "1",
                model: "gpt-100o",
                created: DateTimeOffset.Now,
                role: ChatRole.Assistant,
                contentUpdate: content,
                finishReason: isLast ? CompletionsFinishReason.ToolCalls : (CompletionsFinishReason?) null,
                toolCallUpdate: StreamingChatResponseToolCallUpdate.DeserializeStreamingChatResponseToolCallUpdate(JsonSerializer.SerializeToElement(toolUpdate))
            );
        }
        #endregion
    }
}
