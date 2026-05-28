// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using Azure.Core;
using static Azure.AI.Inference.Telemetry.OpenTelemetryConstants;
using System.Threading.Tasks;
using System.Linq;
using System.Threading;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.AI.Inference.Telemetry
{
    internal class OpenTelemetryScope : IDisposable
    {
        /// <summary>
        /// Activity source is used to save events and log the tags.
        /// On the ApplicationInsights events are logged to traces table.
        /// The tags are not logged, but are shown in the console.
        /// </summary>
        private static readonly ActivitySource s_chatSource = new(ClientName);
        /// <summary>
        /// Add histograms to log metrics.
        /// On the ApplicationInsights metrics are logged to customMetrics table.
        /// </summary>
        private static readonly Meter s_meter = new Meter(ClientName);
        private static readonly Histogram<double> s_duration = s_meter.CreateHistogram<double>(
            GenAiClientOperationDurationMetricName, "s", "Measures GenAI operation duration.");
        private static readonly Histogram<long> s_tokens = s_meter.CreateHistogram<long>(
            GenAiClientTokenUsageMetricName, "{token}", "Measures the number of input and output token used.");
        private static readonly JsonSerializerOptions s_jsonOptions = new JsonSerializerOptions() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };

        private readonly Activity _activity;
        private readonly Stopwatch _duration;
        private readonly TagList _commonTags;
        private static bool s_traceContent = AppContextSwitchHelper.GetConfigValue(
            TraceContentsSwitch,
            TraceContentsEnvironmentVariable);
        private static bool s_enableTelemetry = AppContextSwitchHelper.GetConfigValue(
            EnableOpenTelemetrySwitch,
            EnableOpenTelemetryEnvironmentVariable);
        private RecordedResponse _response;
        private ResponseBuffer _buffer;
        private string _errorType;
        private Exception _exception;

        private int _hasEnded = 0;

        /// <summary>
        /// Create the instance of OpenTelemetryScope. This constructor logs request
        /// and starts the execution timer.
        /// </summary>
        /// <param name="requestOptions">The request options used in the call.</param>
        /// <param name="endpoint">The endpoint being called.</param>
        public static OpenTelemetryScope Start(ChatCompletionsOptions requestOptions, Uri endpoint)
        {
            return s_enableTelemetry ? new OpenTelemetryScope(requestOptions, endpoint) : null;
        }

        private OpenTelemetryScope(ChatCompletionsOptions requestOptions, Uri endpoint)
        {
            var activityName = requestOptions.Model == null ? "chat" : $"chat {requestOptions.Model}";
            _activity = s_chatSource.StartActivity(activityName, ActivityKind.Client);

            // suppress nested client activities from generated code.
            _activity?.SetCustomProperty("az.sdk.scope", bool.TrueString);

            // Record the request to telemetry;
            _commonTags = new TagList()
            {
                { GenAiSystemKey, GenAiSystemValue},
                { GenAiRequestModelKey, requestOptions.Model},
                { ServerAddressKey, endpoint.Host },
                { GenAiOperationNameKey, "chat"}
            };
            // Only record port if it is different from 443
            if (endpoint.Port != 443)
            {
                _commonTags.Add(ServerPortKey, endpoint.Port);
            }

            // Set tags for reporting them to console.
            foreach (KeyValuePair<string, object> kv in _commonTags)
            {
                _activity?.SetTag(kv.Key, kv.Value);
            }
            _activity?.SetTag(AzNamespaceKey, AzureRpNamespaceValue);
            SetTagMaybe(GenAiRequestMaxTokensKey, requestOptions.MaxTokens);
            SetTagMaybe(GenAiRequestTemperatureKey, requestOptions.Temperature);
            SetTagMaybe(GenAiRequestTopPKey, requestOptions.NucleusSamplingFactor);
            // Log all messages as the events.
            foreach (ChatRequestMessage message in requestOptions.Messages)
            {
                object evnt = GetContent(message);
                ActivityTagsCollection messageTags = new() {
                    { GenAiSystemKey, GenAiSystemValue},
                    { GenAiEventContent, evnt != null ? JsonSerializer.Serialize(evnt) : null  }
                };
                _activity?.AddEvent(
                    new ActivityEvent(GetEventName(message), tags: messageTags)
                );
            }
            _duration = Stopwatch.StartNew();
        }

        public void RecordResponse(ChatCompletions response)
        {
            if (s_enableTelemetry)
            {
                _response = new RecordedResponse(response, s_traceContent);
            }
        }

        public void UpdateStreamResponse<T>(T item)
        {
            if (s_enableTelemetry && item is StreamingChatCompletionsUpdate streamingUpdate)
            {
                _buffer ??= new ResponseBuffer(s_traceContent);
                _buffer.Update(streamingUpdate);
            }
        }

        /// <summary>
        /// Log the error.
        /// </summary>
        /// <param name="e">Exception thrown by completion call.</param>
        public void RecordError(Exception e)
        {
            if (s_enableTelemetry)
            {
                if (e is RequestFailedException requestFailed && requestFailed.Status != 0)
                {
                    _errorType = requestFailed.Status.ToString();
                }
                else
                {
                    _errorType = e?.GetType()?.FullName ?? "error";
                }
                _exception = e;
            }
        }

        /// <summary>
        /// Record the task cancellation event.
        /// </summary>
        public void RecordCancellation()
        {
            if (s_enableTelemetry)
            {
                _errorType = typeof(TaskCanceledException).FullName;
                _exception = null;
            }
        }

        /// <summary>
        /// Record the events and metrics associated with the response.
        /// </summary>
        private void End()
        {
            TagList finalTags = _commonTags;

            if (_errorType == null && !IsResponseValid(_response))
            {
                // If there is no response and no error, it is an unexpected error.
                _errorType = "error";
            }

            if (_errorType != null)
            {
                finalTags.Add(ErrorTypeKey, _errorType);
                _activity?.SetTag(ErrorTypeKey, _errorType);
                _activity?.SetStatus(ActivityStatusCode.Error, _exception?.Message);
            }

            if (_response == null)
            {
                s_duration.Record(_duration.Elapsed.TotalSeconds, finalTags);
                return;
            }

            finalTags.Add(GenAiResponseModelKey, _response.Model);
            _activity?.SetTag(GenAiResponseModelKey, _response.Model);

            // report duration
            s_duration.Record(_duration.Elapsed.TotalSeconds, finalTags);

            // Record input tokens
            if (_response.PromptTokens.HasValue)
            {
                TagList input_tags = finalTags;
                input_tags.Add(GenAiUsageInputTokensKey, "input");
                s_tokens.Record(_response.PromptTokens.Value, input_tags);
                _activity?.SetTag(GenAiUsageInputTokensKey, _response.PromptTokens);
            }
            // Record output tokens
            if (_response.CompletionTokens.HasValue)
            {
                TagList output_tags = finalTags;
                output_tags.Add(GenAiUsageOutputTokensKey, "output");
                s_tokens.Record(_response.CompletionTokens.Value, output_tags);
                _activity?.SetTag(GenAiUsageOutputTokensKey, _response.CompletionTokens);
            }

            // Record the event for each response
            if (_response.Choices != null)
            {
                foreach (var choice in _response.Choices)
                {
                    ActivityTagsCollection completionTags = new()
                    {
                        { GenAiSystemKey, GenAiSystemValue },
                        { GenAiEventContent, JsonSerializer.Serialize(choice, s_jsonOptions) }
                    };
                    _activity?.AddEvent(new ActivityEvent(GenAiChoice, tags: completionTags));
                }
            }
            // Set activity tags
            if (_response.FinishReasons?.Any() == true)
            {
                _activity?.SetTag(GenAiResponseFinishReasonsKey, _response.FinishReasons);
            }
            _activity?.SetTag(GenAiResponseIdKey, _response.Id);
        }

        public void Dispose()
        {
            // check if the scope has already ended
            if (s_enableTelemetry && Interlocked.Exchange(ref _hasEnded, 1) == 0)
            {
                _response ??= _buffer?.ToResponse();
                End();
                _activity?.Dispose();
            }
        }

        private static string GetEventName(ChatRequestMessage message)
        {
            switch (message)
            {
                case ChatRequestAssistantMessage:
                    return "gen_ai.assistant.message";
                case ChatRequestSystemMessage:
                    return "gen_ai.system.message";
                case ChatRequestToolMessage:
                    return "gen_ai.tool.message";
                case ChatRequestUserMessage:
                    return "gen_ai.user.message";
                default:
                    return $"gen_ai.{message.Role}.message";
            }
        }

        private static bool IsResponseValid(RecordedResponse response)
        {
            return response != null && response.Id != null && response.FinishReasons != null;
        }

        /// <summary>
        /// Return the content of the message.
        /// Content accessor is implemented only on the exact class, but not on the abstract generated class.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        private static object GetContent(ChatRequestMessage message)
        {
            if (message is ChatRequestAssistantMessage assistantMessage)
                return s_traceContent ? new { content = assistantMessage.Content } : null;
            if (message is ChatRequestSystemMessage systemMessage)
                return s_traceContent ? new { content = systemMessage.Content } : null;
            if (message is ChatRequestToolMessage toolMessage)
                return new { content = s_traceContent ? toolMessage.Content : null, id = toolMessage.ToolCallId };
            if (message is ChatRequestUserMessage userMessage)
                return s_traceContent ? new { content = userMessage.Content } : null;
            return null;
        }

        /// <summary>
        /// Set the tag on the activity, if the tag is present.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name">The name of tag to set.</param>
        /// <param name="value">Nullable value to be set.</param>
        private void SetTagMaybe<T>(string name, T? value) where T : struct
        {
            if (value.HasValue)
            {
                _activity?.SetTag(name, value.Value);
            }
        }

        internal static void ResetEnvironmentForTests()
        {
            s_traceContent = AppContextSwitchHelper.GetConfigValue(TraceContentsSwitch, TraceContentsEnvironmentVariable);
            s_enableTelemetry = AppContextSwitchHelper.GetConfigValue(EnableOpenTelemetrySwitch, EnableOpenTelemetryEnvironmentVariable);
        }
    }
}
