// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.AI.Inference.Telemetry;
using Azure.AI.Inference.Tests.Utilities;
using NUnit.Framework;

namespace Azure.AI.Inference.Tests
{
    public class OpenTelemetryScopeTest
    {
        private ChatCompletionsOptions requestOptions;
        private readonly Uri endpoint = new Uri("https://int.api.azureml-test.ms/nexus");

        [SetUp]
        public void setup() {
            requestOptions = new ChatCompletionsOptions()
            {
                Messages =
                {
                    new ChatRequestSystemMessage("You are a helpful assistant."),
                    new ChatRequestUserMessage("What is the capital of France?"),
                },
                Model = "gpt-3000",
                Temperature = 1,
                MaxTokens = 100500,
                AdditionalProperties = { { "top_p", BinaryData.FromObjectAsJson(42) } }
            };
            Environment.SetEnvironmentVariable(OpenTelemetryScope.ENABLE_ENV, "1");
        }

        [Test]
        public void TestNoActivity()
        {
            // No activity means telemetry should be switched off.
            using var scope = new OpenTelemetryScope(requestOptions, endpoint);
            Assert.False(scope.IsEnabled);
            Assert.False(scope.AreMetricsOn);
        }

        [Test, Sequential]
        public void TestActivityOnOff(
            [Values(null, "1", "true", "false", "neep")] string env,
            [Values(false, true, true, false, false)] bool hasActivity
            )
        {
            Environment.SetEnvironmentVariable(OpenTelemetryScope.ENABLE_ENV, env);
            using var listener = new ValidatingActivityListener();
            using (var scope = new OpenTelemetryScope(requestOptions, endpoint))
            {
                Assert.AreEqual(scope.IsEnabled, hasActivity);
                Assert.False(scope.AreMetricsOn);
            }
        }

        [Test]
        public void TestStartActivity()
        {
            Environment.SetEnvironmentVariable(OpenTelemetryScope.ENABLE_ENV, "1");
            using var listener = new ValidatingActivityListener();
            using (var scope = new OpenTelemetryScope(requestOptions, endpoint))
            {
                Assert.True(scope.IsEnabled);
                Assert.False(scope.AreMetricsOn);
            }
            listener.validateStartActivity(requestOptions, endpoint);
        }

        [Test]
        public void TestChatResponse()
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
                    finishReason: i == 2 ? CompletionsFinishReason.Stopped : CompletionsFinishReason.ContentFiltered,
                    message: new ChatResponseMessage(
                        role: roles[i],
                        content: messages[i]
                    ),
                    serializedAdditionalRawData: new Dictionary<string, BinaryData>()));
            }

            var completions = new ChatCompletions(
                id: "4567",
                created: DateTimeOffset.Now,
                model: "gpt-3000",
                usage: usage,
                choices: choices,
                serializedAdditionalRawData: new Dictionary<string, BinaryData>());
            var response = new SingleRecordedResponse(completions);
            using (var actListener = new ValidatingActivityListener())
            {
                using (var meterListener = new ValidatingMeterListener())
                {
                    using (var scope = new OpenTelemetryScope(requestOptions, endpoint))
                    {
                        Assert.True(scope.IsEnabled);
                        Assert.True(scope.AreMetricsOn);
                        scope.RecordResponse(completions);
                    }
                    actListener.validateStartActivity(requestOptions, endpoint);
                    actListener.validateResponseEvents(response);
                    meterListener.ValidateTags("gpt-3000", endpoint, true);
                    meterListener.VaidateDuration("gpt-3000", endpoint);
                }
            }
        }

        [Test]
        public void TestErrorResponse(
            [Values(null, "My error description")] string errMessage
            )
        {
            using (var actListener = new ValidatingActivityListener())
            {
                using (var meterListener = new ValidatingMeterListener())
                {
                    using (var scope = new OpenTelemetryScope(requestOptions, endpoint))
                    {
                        Assert.True(scope.IsEnabled);
                        Assert.True(scope.AreMetricsOn);
                        var ex = new Exception(errMessage);
                        scope.RecordError(ex);
                    }
                }
                actListener.validateStartActivity(requestOptions, endpoint);
                actListener.validateErrorTag(
                    "System.Exception",
                    errMessage ?? "Exception of type 'System.Exception' was thrown.");
            }
        }

        [Test]
        public void TestStreamingResponse()
        {
            StreamingRecordedResponse resp = new();
            StreamingChatCompletionsUpdate[] updates = new StreamingChatCompletionsUpdate[]{
                getFuncPart("first", "func1", "{\"arg1\": 42}"),
                getFuncPart(" second", "func2", "{\"arg1\": 42,"),
                getFuncPart(" third", "func2", "\"arg2\": 43}"),
            };
            using (var actListener = new ValidatingActivityListener())
            {
                using (var meterListener = new ValidatingMeterListener())
                {
                    using (var scope = new OpenTelemetryScope(requestOptions, endpoint))
                    {
                        Assert.True(scope.IsEnabled);
                        Assert.True(scope.AreMetricsOn);
                        foreach (StreamingChatCompletionsUpdate update in updates)
                        {
                            resp.Update(update);
                            scope.UpdateStreamResponse(update);
                        }
                        scope.RecordStreamingResponse();
                    }
                    actListener.validateStartActivity(requestOptions, endpoint);
                    actListener.validateResponseEvents(resp);
                    meterListener.ValidateTags("gpt-3000", endpoint, false);
                    meterListener.VaidateDuration("gpt-3000", endpoint);
                }
            }
        }

        private static StreamingChatCompletionsUpdate getFuncPart(string content, string functionName, string argsUpdate)
        {
            Dictionary<string, string> dtCalls = new()
            {
                { "name", functionName },
                { "arguments", argsUpdate }
            };
            Dictionary<string, object> dtToolCall = new() { { "function", dtCalls } };

            return new StreamingChatCompletionsUpdate(
                id: "1",
                model: "gpt-3000",
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
    }
}
