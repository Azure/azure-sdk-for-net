// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
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
            using var _ = ConfigureInstrumentation(true, false);

            using var listener = new ValidatingActivityListener();
            using var metricsListener = new ValidatingMeterListener();
            var ep = new Uri("https://int.api.azureml-test.ms:9999");

            RecordedResponse expectedResponse = new()
            {
                Id = "id",
                Model = "model",
                FinishReasons = new[] { "stop" },
                PromptTokens = 10,
                CompletionTokens = 15,
                Choices = new[] { new { finish_reason = "stop", index = 0, message = new { } } }
            };

            using (var scope = OpenTelemetryScope.Start(_requestOptions, ep))
            {
                AssertActivityEnabled(Activity.Current, _requestOptions);
                ChatCompletions completions = GetChatCompletions(expectedResponse);
                scope.RecordResponse(completions);
            }
            listener.ValidateStartActivity(_requestOptions, ep, false);

            listener.ValidateResponse(expectedResponse, null, null);
            metricsListener.ValidateDuration(_requestOptions.Model, expectedResponse.Model, ep, null);
            metricsListener.ValidateUsage(_requestOptions.Model, expectedResponse.Model, ep);
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

            RecordedResponse expectedResponse = new()
            {
                Id = "4567",
                Model = responseModel,
                FinishReasons = new[] { "content_filter", "content_filter", "stop" },
                PromptTokens = 10,
                CompletionTokens = 15,
                Choices = new[]
                {
                    new { finish_reason = "content_filter", index = 0, message = (object) new { } },
                    new { finish_reason = "content_filter", index = 1, message = (object) new { content = traceContent ? "What is a capital of France." : null } },
                    new { finish_reason = "stop", index = 2, message = (object) new { content = traceContent ? "The capital of France is Paris." : null } },
                },
            };

            ChatCompletions completions = GetChatCompletions(expectedResponse);
            using (var actListener = new ValidatingActivityListener())
            using (var meterListener = new ValidatingMeterListener())
            {
                using (var scope = OpenTelemetryScope.Start(_requestOptions, _endpoint))
                {
                    AssertActivityEnabled(Activity.Current, _requestOptions);
                    scope.RecordResponse(completions);
                }
                actListener.ValidateStartActivity(_requestOptions, _endpoint, traceContent);
                actListener.ValidateResponse(expectedResponse, null, null);
                meterListener.ValidateUsage(_requestOptions.Model, expectedResponse.Model, _endpoint);
                meterListener.ValidateDuration(_requestOptions.Model, expectedResponse.Model, _endpoint, null);
            }
        }

        [Test]
        public void TestEmptyResponse()
        {
            using var _ = ConfigureInstrumentation(true, true);

            using (var actListener = new ValidatingActivityListener())
            using (var meterListener = new ValidatingMeterListener())
            {
                using (var scope = OpenTelemetryScope.Start(_requestOptions, _endpoint))
                {
                }
                actListener.ValidateStartActivity(_requestOptions, _endpoint, true);
                actListener.ValidateResponse(null, "error", null);
                meterListener.ValidateUsageIsNotReported();
                meterListener.ValidateDuration(_requestOptions.Model, null, _endpoint, "error");
            }
        }

        [Test]
        public void TestErrorResponse([Values(null, "My error description")] string errMessage)
        {
            using var _ = ConfigureInstrumentation(true, true);

            var exception = new Exception(errMessage);

            using (var actListener = new ValidatingActivityListener())
            using (var meterListener = new ValidatingMeterListener())
            {
                using (var scope = OpenTelemetryScope.Start(_requestOptions, _endpoint))
                {
                    AssertActivityEnabled(Activity.Current, _requestOptions);
                    scope.RecordError(exception);
                }
                meterListener.ValidateDuration(_requestOptions.Model, null, _endpoint, exception.GetType().FullName);
                actListener.ValidateStartActivity(_requestOptions, _endpoint, true);
                actListener.ValidateResponse(null, exception.GetType().FullName, exception.Message);
            }
        }

        [Test]
        public void TestStreamingResponseWithToolCallsInChoices([Values(true, false)] bool traceContent)
        {
            using var _ = ConfigureInstrumentation(true, traceContent);
            string model = "responseModel";
            StreamingChatCompletionsUpdate[] updates = new StreamingChatCompletionsUpdate[]{
                GetStreamingToolUpdate("first", "func1", "{\"arg1\": 42}", "1", model, "tool_call_1", CompletionsFinishReason.ToolCalls, 0),
                GetStreamingToolUpdate(" second", "func2", "{\"arg1\": 42,", "1", model, "tool_call_2", null, 1),
                GetStreamingToolUpdate(" third", "func2", "\"arg2\": 43}", "1", model, "tool_call_2", CompletionsFinishReason.ToolCalls, 1),
            };

            RecordedResponse expectedResponse = new RecordedResponse()
            {
                Id = "1",
                Model = model,
                FinishReasons = new[] { "tool_calls" },
                Choices = new[] { new {
                        finish_reason = "tool_calls",
                        index = 0,
                        message = new {
                            content = traceContent ? "first second third" : null,
                            tool_calls = new[] {
                                new {
                                    id = "tool_call_1",
                                    type = "function",
                                    function = new
                                    {
                                        name = "func1",
                                        arguments = traceContent ? "{\"arg1\": 42}" : null
                                    },
                                },
                                new {
                                    id = "tool_call_2",
                                    type = "function",
                                    function = new
                                    {
                                        name = "func2",
                                        arguments = traceContent ? "{\"arg1\": 42,\"arg2\": 43}" : null
                                    },
                                }
                            }
                        }
                    }
                }
            };

            using (var actListener = new ValidatingActivityListener())
            using (var meterListener = new ValidatingMeterListener())
            {
                using (var scope = OpenTelemetryScope.Start(_requestOptions, _endpoint))
                {
                    AssertActivityEnabled(Activity.Current, _requestOptions);
                    foreach (StreamingChatCompletionsUpdate update in updates)
                    {
                        scope.UpdateStreamResponse(update);
                    }
                }
                actListener.ValidateStartActivity(_requestOptions, _endpoint, traceContent);
                actListener.ValidateResponse(expectedResponse, null, null);
                meterListener.ValidateUsageIsNotReported();
                meterListener.ValidateDuration(_requestOptions.Model, model, _endpoint, null);
            }
        }

        [Test]
        public async Task TestCancellationSSEStream()
        {
            using var _ = ConfigureInstrumentation(true, true);
            Stream stream = new MemoryStream();
            using var tokenSource = new CancellationTokenSource();
            CancellationToken ct = tokenSource.Token;

            using var actListener = new ValidatingActivityListener();
            using var meterListener = new ValidatingMeterListener();
            using var scope = OpenTelemetryScope.Start(_requestOptions, _endpoint);
            var enumerator = SseAsyncEnumerator<StreamingChatCompletionsUpdate>.EnumerateFromSseStream(
                        stream,
                        StreamingChatCompletionsUpdate.DeserializeStreamingChatCompletionsUpdates,
                        scope,
                        ct);

            Task t = Task.Run(() => enumerator.GetAsyncEnumerator().MoveNextAsync());
            tokenSource.Cancel();
            await t;

            actListener.ValidateStartActivity(_requestOptions, _endpoint, true);
            var errorType = typeof(TaskCanceledException).FullName;

            actListener.ValidateResponse(null, errorType, null);
            meterListener.ValidateUsageIsNotReported();
            meterListener.ValidateDuration(_requestOptions.Model, null, _endpoint, errorType);
        }

        [Test]
        public void TestStreamingPartialResponseAndError()
        {
            using var _ = ConfigureInstrumentation(true, true);

            using var actListener = new ValidatingActivityListener();
            using var meterListener = new ValidatingMeterListener();
            string responseModel = "responseModel";
            var error = new HttpRequestException("oops");
            using (var scope = OpenTelemetryScope.Start(_requestOptions, _endpoint))
            {
                scope.UpdateStreamResponse(GetStreamingContentUpdate("1", responseModel, 0, "first", (CompletionsFinishReason?)null));
                scope.UpdateStreamResponse(GetStreamingContentUpdate("1", responseModel, 0, " second", (CompletionsFinishReason?)null));
                scope.RecordError(error);
            }

            actListener.ValidateStartActivity(_requestOptions, _endpoint, true);
            RecordedResponse expectedResponse = new RecordedResponse()
            {
                Id = "1",
                Model = responseModel,
                FinishReasons = new string[] { null },
                Choices = new object[] {
                    new  {
                        index = 0,
                        message = new { content = "first second" }
                    }
                }
            };

            actListener.ValidateResponse(expectedResponse, error.GetType().FullName, error.Message);
            meterListener.ValidateUsageIsNotReported();
            meterListener.ValidateDuration(_requestOptions.Model, expectedResponse.Model, _endpoint, error.GetType().FullName);
        }

        [Test]
        public void TestStreamingPartialResponseAndCancellation()
        {
            using var _ = ConfigureInstrumentation(true, true);

            using var actListener = new ValidatingActivityListener();
            using var meterListener = new ValidatingMeterListener();
            string responseModel = "responseModel";
            using (var scope = OpenTelemetryScope.Start(_requestOptions, _endpoint))
            {
                scope.UpdateStreamResponse(GetStreamingContentUpdate("1", responseModel, 0, "first", (CompletionsFinishReason?)null));
                scope.RecordCancellation();
            }

            RecordedResponse expectedResponse = new RecordedResponse()
            {
                Id = "1",
                Model = responseModel,
                FinishReasons = new string[] { null },
                Choices = new object[] { new  { index = 0, message = new { content = "first" } } }
            };

            actListener.ValidateResponse(expectedResponse, typeof(TaskCanceledException).FullName, null);
            meterListener.ValidateUsageIsNotReported();
            meterListener.ValidateDuration(_requestOptions.Model, expectedResponse.Model, _endpoint, typeof(TaskCanceledException).FullName);
        }

        [Test]
        public void TestSwitchedOffTelemetry([Values(RunType.Basic, RunType.Streaming, RunType.Error)] RunType rtype)
        {
            using var _ = ConfigureInstrumentation(false, false);
            using (var actListener = new ValidatingActivityListener())
            using (var meterListener = new ValidatingMeterListener())
            {
                Assert.Null(OpenTelemetryScope.Start(_requestOptions, _endpoint));
                actListener.ValidateTelemetryIsOff();
                meterListener.ValidateMetricsAreOff();
            }
        }

        [Test]
        public void TestTracesOffMetricsOn([Values(RunType.Basic, RunType.Streaming, RunType.Error)] RunType rtype)
        {
            using var _ = ConfigureInstrumentation(true, false);

            RecordedResponse simpleResponse = new RecordedResponse()
            {
                Id = "1",
                Model = "model",
                FinishReasons = new[] { "stop" },
                PromptTokens = 10,
                CompletionTokens = 10,
                Choices = new[] { new { finish_reason = "stop", index = 0, message = new { } } }
            };

            using (var meterListener = new ValidatingMeterListener())
            {
                string errorType = null;
                using (var scope = OpenTelemetryScope.Start(_requestOptions, _endpoint))
                {
                    Assert.IsNull(Activity.Current);
                    switch (rtype)
                    {
                        case RunType.Basic:
                            ChatCompletions completions = GetChatCompletions(simpleResponse);
                            scope.RecordResponse(completions);
                            break;
                        case RunType.Streaming:
                            scope.UpdateStreamResponse(GetStreamingContentUpdate("1", simpleResponse.Model, 0, "first", null));
                            scope.UpdateStreamResponse(GetStreamingContentUpdate("1", simpleResponse.Model, 0, " second", null));
                            scope.UpdateStreamResponse(GetStreamingContentUpdate("1", simpleResponse.Model, 0, " third", null));
                            break;
                        case RunType.Error:
                            Exception exception = new Exception("Mock");
                            errorType = exception.GetType().FullName;
                            scope.RecordError(exception);
                            break;
                    }
                }

                if (rtype == RunType.Basic)
                {
                    meterListener.ValidateUsage(_requestOptions.Model, simpleResponse.Model, _endpoint);
                }
                else
                {
                    meterListener.ValidateUsageIsNotReported();
                }

                meterListener.ValidateDuration(_requestOptions.Model, rtype == RunType.Error ? null : simpleResponse.Model, _endpoint, errorType);
            }
        }

        #region Helpers
        private static ChatCompletions GetChatCompletions(RecordedResponse expectedResponse)
        {
            int promptTokens = expectedResponse.PromptTokens ?? 0;
            int completionTokens = expectedResponse.CompletionTokens ?? 0;
            CompletionsUsage usage = new(completionTokens, promptTokens, promptTokens + completionTokens);

            ChatChoice[] choices = expectedResponse.Choices.Select(c =>
                ChatChoice.DeserializeChatChoice(JsonSerializer.SerializeToElement(c))).ToArray();

            return new ChatCompletions(
                 id: expectedResponse.Id,
                 created: DateTimeOffset.Now,
                 model: expectedResponse.Model,
                 usage: usage,
                 choices: choices,
                 serializedAdditionalRawData: new Dictionary<string, BinaryData>());
        }

        private static StreamingChatCompletionsUpdate GetStreamingToolUpdate(string content, string functionName, string argsUpdate,
            string responseId, string responseModel, string toolCallId, CompletionsFinishReason? finishReason, int index)
        {
            var toolUpdate = new
            {
                function = new
                {
                    name = functionName,
                    arguments = argsUpdate
                },
                type = "function",
                id = toolCallId,
                index
            };

            return new StreamingChatCompletionsUpdate(
                id: responseId,
                model: responseModel,
                created: DateTimeOffset.Now,
                role: ChatRole.Assistant,
                contentUpdate: content,
                finishReason: finishReason,
                toolCallUpdate: StreamingChatResponseToolCallUpdate.DeserializeStreamingChatResponseToolCallUpdate(
                    JsonSerializer.SerializeToElement(toolUpdate)
                )
            );
        }

        private static StreamingChatCompletionsUpdate GetStreamingToolUpdate(string id, string model, int index, string content, CompletionsFinishReason? finishReason)
        {
            var contentUpdate = new { delta = new { content }, index, finishReason };

            IReadOnlyList<StreamingChatChoiceUpdate> choices = new List<StreamingChatChoiceUpdate>() { StreamingChatChoiceUpdate.DeserializeStreamingChatChoiceUpdate(JsonSerializer.SerializeToElement(contentUpdate)) };
            return new StreamingChatCompletionsUpdate(
                id: id,
                created: DateTimeOffset.Now,
                model: model,
                usage: null,
                choices: choices,
                serializedAdditionalRawData: new Dictionary<string, BinaryData>()
            );
        }

        private static StreamingChatCompletionsUpdate GetStreamingContentUpdate(string id, string model, int index, string content, CompletionsFinishReason? finishReason)
        {
            var contentUpdate = new { delta = new { content }, index, finishReason };

            IReadOnlyList<StreamingChatChoiceUpdate> choices = new List<StreamingChatChoiceUpdate>() {
                StreamingChatChoiceUpdate.DeserializeStreamingChatChoiceUpdate(JsonSerializer.SerializeToElement(contentUpdate))
            };
            return new StreamingChatCompletionsUpdate(
                id: id,
                created: DateTimeOffset.Now,
                model: model,
                usage: null,
                choices: choices,
                serializedAdditionalRawData: new Dictionary<string, BinaryData>()
            );
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
            RecordedResponse expectedResponse = new()
            {
                Id = "id",
                Model = "model",
                FinishReasons = new[] { "stop" },
                PromptTokens = 10,
                CompletionTokens = 15,
                Choices = new[] { new { finish_reason = "stop", index = 0, message = new { } } }
            };

            using (var scope = OpenTelemetryScope.Start(_requestOptions, _endpoint))
            {
                if (enableOTel)
                {
                    AssertActivityEnabled(Activity.Current, _requestOptions);
                    ChatCompletions completions = GetChatCompletions(expectedResponse);
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
                listener.ValidateTelemetryIsOff();
                metricsListener.ValidateMetricsAreOff();
            }
            else
            {
                listener.ValidateStartActivity(_requestOptions, _endpoint, false);
                listener.ValidateResponse(expectedResponse, null, null);
                metricsListener.ValidateDuration(_requestOptions.Model, expectedResponse.Model, _endpoint, null);
                metricsListener.ValidateUsage(_requestOptions.Model, expectedResponse.Model, _endpoint);
            }
        }
        #endregion
    }
}
