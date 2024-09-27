// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Inference.Telemetry;
using Azure.AI.Inference.Tests.Utilities;
using Azure.Core.Sse;
using NUnit.Framework;
using static Azure.AI.Inference.Tests.Utilities.TelemetryUtils;

namespace Azure.AI.Inference.Tests
{
    [NonParallelizable]
    public partial class OpenTelemetryScopeTest
    {
        private ChatCompletionsOptions _requestOptions;
        private readonly Uri _endpoint = new Uri("https://int.api.azureml-test.ms/nexus");

        public enum RunType
        {
            Basic,
            Streaming,
            Error
        };

        [SetUp]
        public void Setup()
        {
            _requestOptions = new ChatCompletionsOptions()
            {
                Messages =
                {
                    new ChatRequestSystemMessage("You are a helpful assistant."),
                    new ChatRequestUserMessage("What is the capital of France?"),
                },
                Model = "gpt-3000",
                Temperature = 1,
                MaxTokens = 100500,
                NucleusSamplingFactor = 42
            };
        }

        [Test]
        public void TestNoActivity()
        {
            // No activity means telemetry should be switched off.
            using var scope = OpenTelemetryScope.Start(_requestOptions, _endpoint);
            Assert.IsNull(Activity.Current);
        }

        [Test, NonParallelizable]
        public void TestActivityOnOffAppContextSwitch([Values(true, false)] bool enableOTel)
        {
            using var _ = ConfigureInstrumentation(enableOTel, false);
            TestActivityOnOffHelper(enableOTel);
        }

        [Test, NonParallelizable]
        public void TestActivityOnOffAppEnvVar([Values(true, false)] bool enableOTel)
        {
            using var _ = ConfigureInstrumentation(enableOTel, false);
            TestActivityOnOffHelper(enableOTel);
        }

        [Test]
        public void TestNonStandardServerPort()
        {
            using var _ = ConfigureInstrumentation(true, true);

            using var listener = new ValidatingActivityListener();
            using var metricsListener = new ValidatingMeterListener();
            SingleRecordedResponse response = null;
            var ep = new Uri("https://int.api.azureml-test.ms:9999");
            using (var scope = OpenTelemetryScope.Start(_requestOptions, ep))
            {
                AssertActivityEnabled(Activity.Current, _requestOptions);
                ChatCompletions completions = GetChatCompletions(_requestOptions.Model);
                response = new(completions, true);
                scope.RecordResponse(completions);
            }
            listener.ValidateStartActivity(_requestOptions, ep, true);
            listener.ValidateResponseEvents(response, true);
            metricsListener.ValidateDuration(_requestOptions.Model, response.Model, ep);
            metricsListener.ValidateTags(_requestOptions.Model, response.Model, ep, true);
        }

        [Test]
        public void TestStartActivity([Values(true, false)] bool noModel)
        {
            using var _ = ConfigureInstrumentation(true, true);
            using var listener = new ValidatingActivityListener();
            if (noModel)
            {
                _requestOptions.Model = null;
            }
            using (var scope = OpenTelemetryScope.Start(_requestOptions, _endpoint))
            {
                AssertActivityEnabled(Activity.Current, _requestOptions);
            }
            listener.ValidateStartActivity(_requestOptions, _endpoint, true);
        }

        [Test, Sequential]
        public void TestChatResponse(
            [Values("gpt-3000", "gpt-3000-2024-09-06", "gpt-3000", "gpt-3000-2024-09-06")] string responseModel,
            [Values(true, true, false, false)] bool traceContent
            )
        {
            using var _ = ConfigureInstrumentation(true, traceContent);

            ChatCompletions completions = GetChatCompletions(responseModel);
            var response = new SingleRecordedResponse(completions, traceContent);
            using (var actListener = new ValidatingActivityListener())
            {
                using (var meterListener = new ValidatingMeterListener())
                {
                    using (var scope = OpenTelemetryScope.Start(_requestOptions, _endpoint))
                    {
                        AssertActivityEnabled(Activity.Current, _requestOptions);
                        scope.RecordResponse(completions);
                    }
                    actListener.ValidateStartActivity(_requestOptions, _endpoint, traceContent);
                    actListener.ValidateResponseEvents(response, traceContent);
                    meterListener.ValidateTags(_requestOptions.Model, responseModel, _endpoint, true);
                    meterListener.ValidateDuration(_requestOptions.Model, responseModel, _endpoint);
                }
            }
        }

        [Test]
        public void TestErrorResponse([Values(null, "My error description")] string errMessage)
        {
            using var _ = ConfigureInstrumentation(true, true);

            using (var actListener = new ValidatingActivityListener())
            using (var meterListener = new ValidatingMeterListener())
            {
                using (var scope = OpenTelemetryScope.Start(_requestOptions, _endpoint))
                {
                    AssertActivityEnabled(Activity.Current, _requestOptions);
                    scope.RecordError(new Exception(errMessage));
                }
                meterListener.ValidateDuration(_requestOptions.Model, null, _endpoint, "System.Exception");
                actListener.ValidateStartActivity(_requestOptions, _endpoint, true);
                actListener.ValidateErrorTag(
                    "System.Exception",
                    errMessage ?? "Exception of type 'System.Exception' was thrown.");
            }
        }

        [Test]
        public void TestStreamingResponseContextSwitch([Values(true, false)] bool traceContent)
        {
            using var _ = ConfigureInstrumentation(true, traceContent);
            TestStreamingResponseHelper(traceContent);
        }

        [Test]
        public void TestStreamingResponseEnvVar([Values(true, false)] bool traceContent)
        {
            using var _ = ConfigureInstrumentation(true, traceContent);
            TestStreamingResponseHelper(traceContent);
        }

        [Test]
        public async Task TestMockSSEStream()
        {
            using var _ = ConfigureInstrumentation(true, true);
            Stream stream = new MemoryStream();
            using var tokenSource = new CancellationTokenSource();
            CancellationToken ct = tokenSource.Token;

            using var actListener = new ValidatingActivityListener();
            using var meterListener = new ValidatingMeterListener();
            using var scope = OpenTelemetryScope.Start(_requestOptions, _endpoint);
            StreamingRecordedResponse resp = null;

            var task = Task.Run(async () => {
                var enumerator = SseAsyncEnumerator<StreamingChatCompletionsUpdate>.EnumerateFromSseStream(
                        stream,
                        StreamingChatCompletionsUpdate.DeserializeStreamingChatCompletionsUpdates,
                        scope,
                        ct);
                await foreach (StreamingChatCompletionsUpdate val in enumerator)
                {
                    resp ??= new(true);
                    resp.Update(val);
                }
                });
            tokenSource.Cancel();
            await task;
            actListener.ValidateStartActivity(_requestOptions, _endpoint, true);
            actListener.ValidateResponseEvents(resp, true);
            var errStr = typeof(TaskCanceledException).FullName;
            actListener.ValidateErrorTag(errStr, null);
            meterListener.ValidateDuration(_requestOptions.Model, null, _endpoint, errStr);
        }

        [Test]
        public void TestSwitchedOffTelemetry([Values(RunType.Basic, RunType.Streaming, RunType.Error)] RunType rtype)
        {
            using var _ = ConfigureInstrumentation(false, false);
            using (var actListener = new ValidatingActivityListener())
            using (var meterListener = new ValidatingMeterListener())
            {
                Assert.Null(OpenTelemetryScope.Start(_requestOptions, _endpoint));
                actListener.VaidateTelemetryIsOff();
                meterListener.VaidateMetricsAreOff();
            }
        }

        [Test]
        public void TestTracesOffMetricsOn([Values(RunType.Basic, RunType.Streaming, RunType.Error)] RunType rtype)
        {
            using var _ = ConfigureInstrumentation(true, false);

            string responseModel = "responseModel";
            using (var meterListener = new ValidatingMeterListener())
            {
                using (var scope = OpenTelemetryScope.Start(_requestOptions, _endpoint))
                {
                    Assert.IsNull(Activity.Current);
                    switch (rtype)
                    {
                        case RunType.Basic:
                            ChatCompletions completions = GetChatCompletions(responseModel);
                            scope.RecordResponse(completions);
                            break;
                        case RunType.Streaming:
                            scope.UpdateStreamResponse(GetFuncPart("first", "func1", "{\"arg1\": 42}", responseModel));
                            scope.UpdateStreamResponse(GetFuncPart(" second", "func2", "{\"arg1\": 42,", responseModel));
                            scope.UpdateStreamResponse(GetFuncPart(" third", "func2", "\"arg2\": 43}", responseModel));
                            break;
                        case RunType.Error:
                            scope.RecordError(new Exception("Mock"));
                            break;
                    }
                }
                if (rtype != RunType.Error)
                {
                    meterListener.ValidateTags(_requestOptions.Model, responseModel, _endpoint, rtype == RunType.Basic);
                    meterListener.ValidateDuration(_requestOptions.Model, responseModel, _endpoint);
                }
                else
                {
                    meterListener.ValidateDuration(_requestOptions.Model, null, _endpoint, "System.Exception");
                }
            }
        }

        #region Helpers

        private static StreamingChatCompletionsUpdate GetFuncPart(string content, string functionName, string argsUpdate, string responseModel)
        {
            Dictionary<string, string> dtCalls = new()
            {
                { "name", functionName },
                { "arguments", argsUpdate }
            };
            Dictionary<string, object> dtToolCall = new() { { "function", dtCalls } };

            return new StreamingChatCompletionsUpdate(
                id: "1",
                model: responseModel,
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

        private static ChatCompletions GetChatCompletions(string responseModel)
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
                 model: responseModel,
                 usage: usage,
                 choices: choices,
                 serializedAdditionalRawData: new Dictionary<string, BinaryData>());
        }

        private void AssertActivityEnabled(Activity activity, ChatCompletionsOptions requestOptions)
        {
            Assert.IsNotNull(activity);
            Assert.AreEqual(activity.DisplayName, _requestOptions.Model == null ? "chat" : $"chat {_requestOptions.Model}");
        }

        private void TestActivityOnOffHelper(bool enableOTel)
        {
            using var listener = new ValidatingActivityListener();
            using var metricsListener = new ValidatingMeterListener();
            SingleRecordedResponse response = null;
            using (var scope = OpenTelemetryScope.Start(_requestOptions, _endpoint))
            {
                if (enableOTel)
                {
                    AssertActivityEnabled(Activity.Current, _requestOptions);
                    ChatCompletions completions = GetChatCompletions(_requestOptions.Model);
                    response = new(completions, false);
                    scope.RecordResponse(completions);
                }
                else
                {
                    Assert.IsNull(Activity.Current);
                    Assert.IsNull(scope);
                }
            }

            if (!enableOTel)
            {
                listener.VaidateTelemetryIsOff();
                metricsListener.VaidateMetricsAreOff();
            }
            else
            {
                listener.ValidateStartActivity(_requestOptions, _endpoint, false);
                listener.ValidateResponseEvents(response, false);
                metricsListener.ValidateDuration(_requestOptions.Model, response.Model, _endpoint);
                metricsListener.ValidateTags(_requestOptions.Model, response.Model, _endpoint, true);
            }
        }

        private void TestStreamingResponseHelper(bool traceContent)
        {
            string responseModel = "responseModel";
            StreamingRecordedResponse resp = new(traceContent);
            StreamingChatCompletionsUpdate[] updates = new StreamingChatCompletionsUpdate[]{
                GetFuncPart("first", "func1", "{\"arg1\": 42}", responseModel),
                GetFuncPart(" second", "func2", "{\"arg1\": 42,", responseModel),
                GetFuncPart(" third", "func2", "\"arg2\": 43}", responseModel),
            };
            using (var actListener = new ValidatingActivityListener())
            using (var meterListener = new ValidatingMeterListener())
            {
                using (var scope =  OpenTelemetryScope.Start(_requestOptions, _endpoint))
                {
                    AssertActivityEnabled(Activity.Current, _requestOptions);
                    foreach (StreamingChatCompletionsUpdate update in updates)
                    {
                        resp.Update(update);
                        scope.UpdateStreamResponse(update);
                    }
                    scope.Dispose();
                }
                actListener.ValidateStartActivity(_requestOptions, _endpoint, traceContent);
                actListener.ValidateResponseEvents(resp, traceContent);
                meterListener.ValidateTags(_requestOptions.Model, responseModel, _endpoint, false);
                meterListener.ValidateDuration(_requestOptions.Model, responseModel, _endpoint);
            }
        }
        #endregion
    }
}
