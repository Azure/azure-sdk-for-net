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

        public enum RunType
        {
            Basic,
            Streaming,
            Error
        };

        [SetUp]
        public void setup()
        {
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
            Environment.SetEnvironmentVariable(OpenTelemetryConstants.EnvironmentVariableSwitchName, "1");
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
            Environment.SetEnvironmentVariable(OpenTelemetryConstants.EnvironmentVariableSwitchName, env);
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
            Environment.SetEnvironmentVariable(OpenTelemetryConstants.EnvironmentVariableSwitchName, "1");
            using var listener = new ValidatingActivityListener();
            using (var scope = new OpenTelemetryScope(requestOptions, endpoint))
            {
                Assert.True(scope.IsEnabled);
                Assert.False(scope.AreMetricsOn);
            }
            listener.ValidateStartActivity(requestOptions, endpoint);
        }

        [Test, Sequential]
        public void TestChatResponse(
            [Values(true, false)] bool modelChanged,
            [Values("gpt-3000", "gpt-3000-2024-09-06")] string modelNameReturned
            )
        {
            ChatCompletions completions = GetChatCompletions(modelNameReturned);
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
                    requestOptions.Model = modelNameReturned;
                    actListener.ValidateStartActivity(requestOptions, endpoint);
                    actListener.ValidateResponseEvents(response);
                    meterListener.ValidateTags(modelNameReturned, endpoint, true);
                    meterListener.VaidateDuration(modelNameReturned, endpoint);
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
                actListener.ValidateStartActivity(requestOptions, endpoint);
                actListener.ValidateErrorTag(
                    "System.Exception",
                    errMessage ?? "Exception of type 'System.Exception' was thrown.");
            }
        }

        [Test]
        public void TestStreamingResponse()
        {
            StreamingRecordedResponse resp = new();
            StreamingChatCompletionsUpdate[] updates = new StreamingChatCompletionsUpdate[]{
                GetFuncPart("first", "func1", "{\"arg1\": 42}"),
                GetFuncPart(" second", "func2", "{\"arg1\": 42,"),
                GetFuncPart(" third", "func2", "\"arg2\": 43}"),
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
                    actListener.ValidateStartActivity(requestOptions, endpoint);
                    actListener.ValidateResponseEvents(resp);
                    meterListener.ValidateTags("gpt-3000", endpoint, false);
                    meterListener.VaidateDuration("gpt-3000", endpoint);
                }
            }
        }

        [Test]
        public void testSwitchedOffTelemetry(
            [Values(RunType.Basic, RunType.Streaming, RunType.Error)] RunType rtype
            )
        {
            Environment.SetEnvironmentVariable(OpenTelemetryConstants.EnvironmentVariableSwitchName, "0");
            using (var actListener = new ValidatingActivityListener())
            {
                using (var meterListener = new ValidatingMeterListener())
                {
                    using (var scope = new OpenTelemetryScope(requestOptions, endpoint))
                    {
                        Assert.False(scope.IsEnabled);
                        Assert.True(scope.AreMetricsOn);
                        switch (rtype)
                        {
                            case RunType.Basic:
                                ChatCompletions completions = GetChatCompletions("gpt-3000");
                                scope.RecordResponse(completions);
                                break;
                            case RunType.Streaming:
                                scope.RecordStreamingResponse();
                                scope.UpdateStreamResponse(GetFuncPart("first", "func1", "{\"arg1\": 42}"));
                                scope.UpdateStreamResponse(GetFuncPart(" second", "func2", "{\"arg1\": 42,"));
                                scope.UpdateStreamResponse(GetFuncPart(" third", "func2", "\"arg2\": 43}"));
                                break;
                            case RunType.Error:
                                var ex = new Exception("Mock");
                                scope.RecordError(ex);
                                break;
                        }
                    }
                    actListener.VaidateTelemetryIsOff();
                    meterListener.VaidateMetricsAreOff();
                }
            }
        }
        #region Helpers
        private static StreamingChatCompletionsUpdate GetFuncPart(string content, string functionName, string argsUpdate)
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

        private static ChatCompletions GetChatCompletions(string model)
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

            return new ChatCompletions(
                 id: "4567",
                 created: DateTimeOffset.Now,
                 model: model,
                 usage: usage,
                 choices: choices,
                 serializedAdditionalRawData: new Dictionary<string, BinaryData>());
        }
        #endregion
    }
}
