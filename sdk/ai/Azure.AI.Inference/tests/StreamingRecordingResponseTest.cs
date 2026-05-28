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

            CollectionAssert.AreEqual(new[] { "stop" }, response.FinishReasons);
            Assert.AreEqual(response.Model, "gpt-100o");
            Assert.AreEqual(response.Id, withUsage?"4":"3");

            Assert.AreEqual(response.CompletionTokens, withUsage ? 7 : null);
            Assert.AreEqual(response.PromptTokens, withUsage ? 3 : null);

            Assert.AreEqual(1, response.Choices.Length);

            var choiceEvent = JsonSerializer.SerializeToNode(response.Choices[0]);
            var message = choiceEvent["message"];
            Assert.NotNull(message);

            if (traceContent)
            {
                Assert.NotNull(message["content"]);
                Assert.AreEqual("First second third", message["content"].GetValue<string>());
                Assert.Null(message["tool_calls"]);
            }
            else
            {
                Assert.Null(message["content"]);
            }

            var finishReason = choiceEvent["finish_reason"];
            Assert.NotNull(finishReason);
            Assert.AreEqual("stop", finishReason.GetValue<string>());

            Assert.NotNull(choiceEvent["index"]);
            Assert.AreEqual(0, choiceEvent["index"].GetValue<int>());
        }

        [Test]
        public void TestWithTools([Values(true, false)] bool traceContent)
        {
            ResponseBuffer resp = new(traceContent);
            resp.Update(GetToolUpdate("first", "func1", "{\"arg1\": 42}", "tool_call_1", 0, false));
            resp.Update(GetToolUpdate(" second", "func2", "{\"arg1\": 42,", "tool_call_2", 1, false));
            resp.Update(GetToolUpdate(" third", "func2", "\"arg2\": 43}", "tool_call_2", 1, true));

            RecordedResponse response = resp.ToResponse();
            Assert.AreEqual(response.Id, "1");
            CollectionAssert.AreEqual(new[] { "tool_calls" }, response.FinishReasons);
            Assert.AreEqual(response.Model, "gpt-100o");

            Assert.AreEqual(1, response.Choices.Length);

            var choiceEvent = JsonSerializer.SerializeToNode(response.Choices[0]);
            var message = choiceEvent["message"];
            Assert.NotNull(message);

            if (traceContent)
            {
                Assert.AreEqual("first second third", message["content"].GetValue<string>());
            }

            Assert.NotNull(message["tool_calls"]);

            Assert.IsInstanceOf(typeof(JsonArray), message["tool_calls"]);
            JsonArray toolCallsArray = message["tool_calls"].AsArray();
            Assert.AreEqual(2, toolCallsArray.Count);

            Assert.AreEqual("tool_call_1", toolCallsArray[0]["id"].GetValue<string>());
            Assert.AreEqual("tool_call_2", toolCallsArray[1]["id"].GetValue<string>());

            Assert.AreEqual("func1", toolCallsArray[0]["function"]["name"].GetValue<string>());
            Assert.AreEqual("func2", toolCallsArray[1]["function"]["name"].GetValue<string>());

            if (traceContent)
            {
                Assert.AreEqual("{\"arg1\": 42}", toolCallsArray[0]["function"]["arguments"].GetValue<string>());
                Assert.AreEqual("{\"arg1\": 42,\"arg2\": 43}", toolCallsArray[1]["function"]["arguments"].GetValue<string>());
            }
            else
            {
                Assert.Null(toolCallsArray[0]["function"]["arguments"]);
                Assert.Null(toolCallsArray[1]["function"]["arguments"]);
            }

            var finishReason = choiceEvent["finish_reason"];
            Assert.NotNull(finishReason);
            Assert.AreEqual("tool_calls", finishReason.GetValue<string>());

            Assert.NotNull(choiceEvent["index"]);
            Assert.AreEqual(0, choiceEvent["index"].GetValue<int>());
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
