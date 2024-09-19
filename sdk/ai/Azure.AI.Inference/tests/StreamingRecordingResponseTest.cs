// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using Azure.AI.Inference.Telemetry;
using System;
using System.Collections.Generic;
using System.Text.Json;

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
            StreamingRecordedResponse resp = new(traceContent);
            Assert.True(resp.IsEmpty);
            resp.Update(new(
                id: "1",
                model: "gpt-100o",
                created: DateTimeOffset.Now,
                role: ChatRole.Assistant,
                finishReason: CompletionsFinishReason.Stopped,
                contentUpdate: "First"
            ));
            Assert.False(resp.IsEmpty);
            resp.Update(new(
                id: "2",
                model: "gpt-100o",
                created: DateTimeOffset.Now,
                role: ChatRole.Assistant,
                finishReason: CompletionsFinishReason.Stopped,
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
                    usage: new CompletionsUsage(
                        totalTokens: 10,
                        completionTokens: 7,
                        promptTokens: 3
                        ),
                    choices: new List<StreamingChatChoiceUpdate>()
                ));
            }

            Assert.AreEqual(resp.FinishReason, CompletionsFinishReason.Stopped.ToString());
            Assert.AreEqual(resp.Model, "gpt-100o");
            Assert.AreEqual(resp.Id, withUsage?"4":"3");

            Assert.AreEqual(resp.CompletionTokens, withUsage ? 7 : StreamingRecordedResponse.NOT_SET);
            Assert.AreEqual(resp.PromptTokens, withUsage ? 3 : StreamingRecordedResponse.NOT_SET);

            string[] strSerialized = resp.GetSerializedCompletions();
            Assert.AreEqual(strSerialized.Length, 1);
            Dictionary<string, object> dtData = JsonSerializer.Deserialize<Dictionary<string, object>>(strSerialized[0]);
            if (traceContent)
            {
                Assert.That(dtData.ContainsKey("message"));
                Dictionary<string, object> messageDict = JsonSerializer.Deserialize<Dictionary<string, object>>(dtData["message"].ToString());
                Assert.That(messageDict.ContainsKey("content"));
                Assert.AreEqual(messageDict["content"].ToString(), "First second third");
                Assert.That(!messageDict.ContainsKey("tool_calls"));
            }
            else
            {
                Assert.False(dtData.ContainsKey("content"));
            }
            Assert.That(dtData.ContainsKey("finish_reason"));
            Assert.AreEqual(dtData["finish_reason"].ToString(), CompletionsFinishReason.Stopped.ToString());
            Assert.That(dtData.ContainsKey("index"));
            Assert.AreEqual(dtData["index"].ToString(), "0");
        }

        [Test]
        public void TestWithTools([Values(true, false)] bool traceContent)
        {
            StreamingRecordedResponse resp = new(traceContent);
            resp.Update(getFuncPart("first", "func1", "{\"arg1\": 42}"));
            resp.Update(getFuncPart(" second", "func2", "{\"arg1\": 42,"));
            resp.Update(getFuncPart(" third", "func2", "\"arg2\": 43}"));

            Assert.AreEqual(resp.Id, "1");
            Assert.AreEqual(resp.FinishReason, CompletionsFinishReason.ToolCalls.ToString());
            Assert.AreEqual(resp.Model, "gpt-100o");

            string[] strSerialized = resp.GetSerializedCompletions();
            Assert.AreEqual(strSerialized.Length, 1);
            Dictionary<string, object> dtData = JsonSerializer.Deserialize<Dictionary<string, object>>(strSerialized[0]);
            // Message
            Assert.That(dtData.ContainsKey("message"));
            Dictionary<string, object> messageDict = JsonSerializer.Deserialize<Dictionary<string, object>>(dtData["message"].ToString());
            if (traceContent)
            {
                Assert.That(messageDict.ContainsKey("content"));
                Assert.AreEqual(messageDict["content"].ToString(), "first second third");
            }
            // Tools
            Assert.That(messageDict.ContainsKey("tool_calls"));
            List<Dictionary<string, object>> dtFnArgs = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(messageDict["tool_calls"].ToString());
            if (traceContent)
            {
                Assert.AreEqual(dtFnArgs.Count, 2);
                Dictionary<string, object> params1 = new() { { "arg1", "42" } };
                Assert.That(dtFnArgs[0]["arg1"].ToString().Equals(params1["arg1"]));
                params1 = new() { { "arg1", "42" }, { "arg2", "43" } };
                Assert.That(dtFnArgs[1]["arg1"].ToString().Equals(params1["arg1"]) && dtFnArgs[1]["arg2"].ToString().Equals(params1["arg2"]));
            }
            else
            {
                Assert.AreEqual(dtFnArgs.Count, 0);
            }
            // Other fields.
            Assert.That(dtData.ContainsKey("finish_reason"));
            Assert.AreEqual(dtData["finish_reason"].ToString(), CompletionsFinishReason.ToolCalls.ToString());
            Assert.That(dtData.ContainsKey("index"));
            Assert.AreEqual(dtData["index"].ToString(), "0");
        }

        #region Helpers
        private static StreamingChatCompletionsUpdate getFuncPart(string content, string functionName, string argsUpdate)
        {
            Dictionary<string, string> dtCalls =  new()
            {
                { "name", functionName },
                { "arguments", argsUpdate }
            };
            Dictionary<string, object> dtToolCall=new() { { "function", dtCalls } };

            return new StreamingChatCompletionsUpdate(
                id: "1",
                model: "gpt-100o",
                created: DateTimeOffset.Now,
                role: ChatRole.Assistant,
                contentUpdate: content,
                finishReason: CompletionsFinishReason.ToolCalls,
                functionName: functionName,
                functionArgumentsUpdate: argsUpdate,
                toolCallUpdate: StreamingToolCallUpdate.DeserializeStreamingToolCallUpdate(
                    JsonSerializer.SerializeToElement(dtToolCall)
                )
            );
        }
        #endregion
    }
}
