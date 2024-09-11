// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System;
using Azure.AI.Inference.Telemetry;
using NUnit.Framework;
using System.Text.Json;

namespace Azure.AI.Inference.Tests
{
    public class SingleRecordedResponseTest
    {
        [Test]
        public void TestWithoutTools()
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
            List<ChatChoice> choices = new();
            for (int i = 0; i < 3; i++)
            {
                choices.Add(
                    new ChatChoice(
                    index: i,
                    finishReason: i==2? CompletionsFinishReason.Stopped:CompletionsFinishReason.ContentFiltered,
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
            var response = new SingleRecordedResponse(completions);
            Assert.AreEqual("4567", response.Id);
            Assert.AreEqual(CompletionsFinishReason.Stopped.ToString(), response.FinishReason);
            Assert.AreEqual("Phi2000", response.Model);
            Assert.AreEqual(15, response.CompletionTokens);
            Assert.AreEqual(10, response.PromptTokens);
            //Check the content
            var strSerializedString = response.GetSerializedCompletions();
            Assert.AreEqual(strSerializedString.Length, 3);
            for (int i = 0; i < strSerializedString.Length; i++)
            {
                Dictionary<string, object> dtData = JsonSerializer.Deserialize<Dictionary<string, object>>(strSerializedString[i]);
                Assert.That(dtData.ContainsKey("message"));
                Dictionary<string, object> messageDict = JsonSerializer.Deserialize<Dictionary<string, object>>(dtData["message"].ToString());
                Assert.That(messageDict.ContainsKey("content"));
                Assert.AreEqual(messageDict["content"].ToString(), messages[i]);
                Assert.That(!messageDict.ContainsKey("tool_calls"));
                Assert.That(dtData.ContainsKey("finish_reason"));
                string stop = i == 2 ? CompletionsFinishReason.Stopped.ToString() : CompletionsFinishReason.ContentFiltered.ToString();
                Assert.AreEqual(dtData["finish_reason"].ToString(), stop);
                Assert.That(dtData.ContainsKey("index"));
                Assert.AreEqual(dtData["index"].ToString(), i.ToString());
            }
        }

        [Test]
        public void TestWithTools()
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
                    new ChatCompletionsFunctionToolCall(
                        id: "4",
                        function: new FunctionCall(
                            name: "func1",
                            arguments: "{\"arg1\": \"gg\"}"
                        )
                    ),
                    new ChatCompletionsFunctionToolCall(
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
            var response = new SingleRecordedResponse(completions);
            Assert.AreEqual("12", response.Id);
            Assert.AreEqual(CompletionsFinishReason.ContentFiltered.ToString(), response.FinishReason);
            Assert.AreEqual("Phi2001", response.Model);
            Assert.AreEqual(15, response.CompletionTokens);
            Assert.AreEqual(10, response.PromptTokens);
            var strSerializedString = response.GetSerializedCompletions();
            for (int i = 0; i < strSerializedString.Length; i++)
            {
                Dictionary<string, object> dtData = JsonSerializer.Deserialize<Dictionary<string, object>>(strSerializedString[i]);
                Assert.That(dtData.ContainsKey("message"));
                Dictionary<string, object> messageDict = JsonSerializer.Deserialize<Dictionary<string, object>>(dtData["message"].ToString());
                Assert.That(messageDict.ContainsKey("content"));
                Assert.AreEqual(messageDict["content"].ToString(), messages[i]);
                if (i != 2)
                {
                    Assert.That(!messageDict.ContainsKey("tool_calls"));
                }
                else
                {
                    Assert.That(messageDict.ContainsKey("tool_calls"));
                    List<Dictionary<string, object>> dtFnArgs = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(messageDict["tool_calls"].ToString());
                    Assert.AreEqual(dtFnArgs.Count, 2);
                    Dictionary<string, object> params1 = new() { { "arg1", "gg" } };
                    Assert.That(dtFnArgs[0]["arg1"].ToString().Equals(params1["arg1"]));
                    params1 = new() { { "arg1", "gg" }, { "arg2", "432" } };
                    Assert.That(dtFnArgs[1]["arg1"].ToString().Equals(params1["arg1"]) && dtFnArgs[1]["arg2"].ToString().Equals(params1["arg2"]));
                }
                Assert.That(dtData.ContainsKey("finish_reason"));
                string stop = i == 2 ? CompletionsFinishReason.ContentFiltered.ToString() : CompletionsFinishReason.ToolCalls.ToString();
                Assert.AreEqual(dtData["finish_reason"].ToString(), stop);
                Assert.That(dtData.ContainsKey("index"));
                Assert.AreEqual(dtData["index"].ToString(), i.ToString());
            }
        }
    }
}
