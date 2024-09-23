// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Inference.Telemetry;
using Azure.AI.Inference.Tests.Utilities;
using Azure.Core.Sse;
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
            AppContext.SetSwitch(OpenTelemetryConstants.AppContextSwitch, true);
        }

        [Test]
        public void TestNoActivity()
        {
            // No activity means telemetry should be switched off.
            using var scope = new OpenTelemetryScope(requestOptions, endpoint);
            Assert.IsNull(Activity.Current);
        }

        [Test, Sequential]
        public void TestGetSwitch(
            [Values(null, "1", "true", "false", "neep")] string env,
            [Values(false, true, true, false, false)] bool expected
            )
        {
            Environment.SetEnvironmentVariable("some_env_123", env);
            Assert.AreEqual(expected, OpenTelemetryScope.GetSwitchVariableVal("some_env_123"));
        }

        [Test, Sequential]
        public void TestActivityOnOff(
            [Values(true, false)] bool contextSwitch,
            [Values(true, false)] bool hasActivity
            )
        {
            AppContext.SetSwitch(OpenTelemetryConstants.AppContextSwitch, contextSwitch);
            using var listener = new ValidatingActivityListener();
            using var metricsListener = new ValidatingMeterListener();
            SingleRecordedResponse response = null;
            using (var scope = new OpenTelemetryScope(requestOptions, endpoint))
            {
                if (hasActivity)
                {
                    AssertActivityEnabled(Activity.Current, requestOptions);
                }
                else
                {
                    Assert.IsNull(Activity.Current);
                }
                ChatCompletions completions = GetChatCompletions(requestOptions.Model);
                response = new(completions, false);
                scope.RecordResponse(completions);
            }
            if (!hasActivity)
            {
                listener.VaidateTelemetryIsOff();
                metricsListener.VaidateMetricsAreOff();
            }
            else
            {
                listener.ValidateStartActivity(requestOptions, endpoint, false);
                listener.ValidateResponseEvents(response, false);
                metricsListener.VaidateDuration(requestOptions.Model, endpoint);
                metricsListener.ValidateTags(requestOptions.Model, endpoint, true);
            }
        }

        [Test]
        public void TestNonStandardServerPort()
        {
            Environment.SetEnvironmentVariable(OpenTelemetryConstants.EnvironmentVariableTraceContents, "1");
            using var listener = new ValidatingActivityListener();
            using var metricsListener = new ValidatingMeterListener();
            SingleRecordedResponse response = null;
            var ep = new Uri("https://int.api.azureml-test.ms:9999");
            using (var scope = new OpenTelemetryScope(requestOptions, ep))
            {
                AssertActivityEnabled(Activity.Current, requestOptions);
                ChatCompletions completions = GetChatCompletions(requestOptions.Model);
                response = new(completions, true);
                scope.RecordResponse(completions);
            }
            listener.ValidateStartActivity(requestOptions, ep, true);
            listener.ValidateResponseEvents(response, true);
            metricsListener.VaidateDuration(requestOptions.Model, ep);
            metricsListener.ValidateTags(requestOptions.Model, ep, true);
        }

        [Test]
        public void TestStartActivity()
        {
            Environment.SetEnvironmentVariable(OpenTelemetryConstants.EnvironmentVariableTraceContents, "1");
            using var listener = new ValidatingActivityListener();
            using (var scope = new OpenTelemetryScope(requestOptions, endpoint))
            {
                AssertActivityEnabled(Activity.Current, requestOptions);
            }
            listener.ValidateStartActivity(requestOptions, endpoint, true);
        }

        [Test, Sequential]
        public void TestChatResponse(
            [Values(true, false, true, false)] bool modelChanged,
            [Values("gpt-3000", "gpt-3000-2024-09-06", "gpt-3000", "gpt-3000-2024-09-06")] string modelNameReturned,
            [Values(true, true, false, false)] bool traceContent
            )
        {
            Environment.SetEnvironmentVariable(OpenTelemetryConstants.EnvironmentVariableTraceContents,
                traceContent.ToString());
            ChatCompletions completions = GetChatCompletions(modelNameReturned);
            var response = new SingleRecordedResponse(completions, traceContent);
            using (var actListener = new ValidatingActivityListener())
            {
                using (var meterListener = new ValidatingMeterListener())
                {
                    using (var scope = new OpenTelemetryScope(requestOptions, endpoint))
                    {
                        AssertActivityEnabled(Activity.Current, requestOptions);
                        scope.RecordResponse(completions);
                    }
                    requestOptions.Model = modelNameReturned;
                    actListener.ValidateStartActivity(requestOptions, endpoint, traceContent);
                    actListener.ValidateResponseEvents(response, traceContent);
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
            Environment.SetEnvironmentVariable(OpenTelemetryConstants.EnvironmentVariableTraceContents, "1");
            using (var actListener = new ValidatingActivityListener())
            {
                using (var meterListener = new ValidatingMeterListener())
                {
                    using (var scope = new OpenTelemetryScope(requestOptions, endpoint))
                    {
                        AssertActivityEnabled(Activity.Current, requestOptions);
                        var ex = new Exception(errMessage);
                        scope.RecordError(ex);
                    }
                    meterListener.VaidateDuration(requestOptions.Model, endpoint, "System.Exception");
                }
                actListener.ValidateStartActivity(requestOptions, endpoint, true);
                actListener.ValidateErrorTag(
                    "System.Exception",
                    errMessage ?? "Exception of type 'System.Exception' was thrown.");
            }
        }

        [Test]
        public void TestStreamingResponse(
            [Values(true, false)] bool traceContent
            )
        {
            Environment.SetEnvironmentVariable(OpenTelemetryConstants.EnvironmentVariableTraceContents,
                traceContent.ToString());
            StreamingRecordedResponse resp = new(traceContent);
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
                        AssertActivityEnabled(Activity.Current, requestOptions);
                        foreach (StreamingChatCompletionsUpdate update in updates)
                        {
                            resp.Update(update);
                            scope.UpdateStreamResponse(update);
                        }
                        scope.RecordStreamingResponse();
                    }
                    actListener.ValidateStartActivity(requestOptions, endpoint, traceContent);
                    actListener.ValidateResponseEvents(resp, traceContent);
                    meterListener.ValidateTags("gpt-3000", endpoint, false);
                    meterListener.VaidateDuration("gpt-3000", endpoint);
                }
            }
        }

        [Test]
        public async Task TestMockSSEStream()
        {
            Environment.SetEnvironmentVariable(OpenTelemetryConstants.EnvironmentVariableTraceContents, "1");
            Stream stream = new MemoryStream();
            using var tokenSource = new CancellationTokenSource();
            CancellationToken ct = tokenSource.Token;

            using var actListener = new ValidatingActivityListener();
            using var meterListener = new ValidatingMeterListener();
            using var scope = new OpenTelemetryScope(requestOptions, endpoint);
            StreamingRecordedResponse resp = new(true);

            var task = Task.Run(async () => {
                var enumerator = SseAsyncEnumerator<StreamingChatCompletionsUpdate>.EnumerateFromSseStream(
                        stream,
                        StreamingChatCompletionsUpdate.DeserializeStreamingChatCompletionsUpdates,
                        ct,
                        scope);
                await foreach (var val in enumerator)
                {
                    resp.Update(val);
                }
                });
            tokenSource.Cancel();
            await task;
            actListener.ValidateStartActivity(requestOptions, endpoint, true);
            actListener.ValidateResponseEvents(resp, true);
            var errStr = typeof(TaskCanceledException).ToString();
            actListener.ValidateErrorTag(errStr, "A task was canceled.");
            meterListener.VaidateDuration(requestOptions.Model, endpoint, errStr);
        }

        [Test]
        public void TestSwitchedOffTelemetry(
            [Values(RunType.Basic, RunType.Streaming, RunType.Error)] RunType rtype
            )
        {
            AppContext.SetSwitch(OpenTelemetryConstants.AppContextSwitch, false);
            using (var actListener = new ValidatingActivityListener())
            {
                using (var meterListener = new ValidatingMeterListener())
                {
                    using (var scope = new OpenTelemetryScope(requestOptions, endpoint))
                    {
                        Assert.IsNull(Activity.Current);
                        switch (rtype)
                        {
                            case RunType.Basic:
                                ChatCompletions completions = GetChatCompletions("gpt-3000");
                                scope.RecordResponse(completions);
                                break;
                            case RunType.Streaming:
                                scope.UpdateStreamResponse(GetFuncPart("first", "func1", "{\"arg1\": 42}"));
                                scope.UpdateStreamResponse(GetFuncPart(" second", "func2", "{\"arg1\": 42,"));
                                scope.UpdateStreamResponse(GetFuncPart(" third", "func2", "\"arg2\": 43}"));
                                scope.RecordStreamingResponse();
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

        [Test]
        public void TestTracesOffMetricsOn(
            [Values(RunType.Basic, RunType.Streaming, RunType.Error)] RunType rtype
            )
        {
            using (var meterListener = new ValidatingMeterListener())
            {
                using (var scope = new OpenTelemetryScope(requestOptions, endpoint))
                {
                    Assert.IsNull(Activity.Current);
                    switch (rtype)
                    {
                        case RunType.Basic:
                            ChatCompletions completions = GetChatCompletions("gpt-3000");
                            scope.RecordResponse(completions);
                            break;
                        case RunType.Streaming:
                            scope.UpdateStreamResponse(GetFuncPart("first", "func1", "{\"arg1\": 42}"));
                            scope.UpdateStreamResponse(GetFuncPart(" second", "func2", "{\"arg1\": 42,"));
                            scope.UpdateStreamResponse(GetFuncPart(" third", "func2", "\"arg2\": 43}"));
                            scope.RecordStreamingResponse();
                            break;
                        case RunType.Error:
                            var ex = new Exception("Mock");
                            scope.RecordError(ex);
                            break;
                    }
                }
                if (rtype != RunType.Error)
                {
                    meterListener.ValidateTags("gpt-3000", endpoint, rtype == RunType.Basic);
                    meterListener.VaidateDuration("gpt-3000", endpoint);
                }
                else
                {
                    meterListener.VaidateDuration("gpt-3000", endpoint, "System.Exception");
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

        private void AssertActivityEnabled(Activity activity, ChatCompletionsOptions requestOptions)
        {
            Assert.IsNotNull(activity);
            Assert.AreEqual(activity.DisplayName, $"chat {requestOptions.Model}");
        }
        #endregion
    }
}
