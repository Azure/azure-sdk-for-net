// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Text.Json;
using static Azure.AI.Inference.Telemetry.OpenTelemetryInternalConstants;
using static Azure.AI.Inference.Telemetry.OpenTelemetryConstants;

namespace Azure.AI.Inference.Telemetry
{
    internal class OpenTelemetryScope : IDisposable
    {
        /// <summary>
        /// Activity source is used to save events and log the tags.
        /// On the ApplicationInsights events are logged to traces table.
        /// The tags are not logged, but are shown in the console.
        /// </summary>
        private static readonly ActivitySource s_chatSource = new ActivitySource(ActivitySourceName);
        /// <summary>
        /// Add histograms to log metrics.
        /// On the ApplicationInsights metrics are logged to customMetrics table.
        /// </summary>
        private static readonly Meter s_meter = new Meter(ActivitySourceName);
        private static readonly Histogram<double> s_duration = s_meter.CreateHistogram<double>(
            GenAiClientOperationDurationMetricName, "s", "Measures GenAI operation duration.");
        private static readonly Histogram<long> s_tokens = s_meter.CreateHistogram<long>(
            GenAiClientTokenUsageMetricName, "{token}", "Measures the number of input and output token used.");

        private readonly Activity m_activity;
        private readonly Stopwatch m_duration;
        private readonly TagList m_commonTags;
        private readonly string m_caller;
        private readonly bool m_traceContent;
        private readonly bool m_enableTelemetry;
        private readonly DiagnosticListener m_source = null;
        private readonly StreamingRecordedResponse m_recordedStreamingResponse;

        /// <summary>
        /// Return the content of the message.
        /// Content accessor is implemented only on the exact class, but not on the abstract generated class.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        public static string GetContent(ChatRequestMessage message)
        {
            if (message.GetType() == typeof(ChatRequestAssistantMessage))
                return ((ChatRequestAssistantMessage)message).Content;
            if (message.GetType() == typeof(ChatRequestSystemMessage))
                return ((ChatRequestSystemMessage)message).Content;
            if (message.GetType() == typeof(ChatRequestToolMessage))
                return ((ChatRequestToolMessage)message).Content;
            if (message.GetType() == typeof(ChatRequestUserMessage))
                return ((ChatRequestUserMessage)message).Content;
            return "";
        }

        public static bool GetSwithVariableVal(string name)
        {
            string enable = Environment.GetEnvironmentVariable(name);
            return enable != null && (enable.Equals("true", StringComparison.OrdinalIgnoreCase) || enable.Equals("1"));
        }

        /// <summary>
        /// Set the tag on the activity, if the tag is present.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name">The name of tag to set.</param>
        /// <param name="value">Nullable value to be set.</param>
        private void SetTagMaybe<T>(string name, T? value) where T: struct
        {
            if (value.HasValue)
                m_activity?.SetTag(name, value.Value);
        }

        /// <summary>
        /// Create the instance of OpenTelemetryScope. This constructor logs request
        /// and starts the execution timer.
        /// </summary>
        /// <param name="requestOptions">The request options used in the call.</param>
        /// <param name="endpoint">The endpoint being called.</param>
        /// <param name="caller">The calling method.</param>
        public OpenTelemetryScope(ChatCompletionsOptions requestOptions, Uri endpoint, string caller=null)
        {
            m_enableTelemetry = GetSwithVariableVal(EnvironmentVariableSwitchName);
            if (!m_enableTelemetry)
                return;
            m_traceContent = GetSwithVariableVal(EnvironmentVariableTraceContents);
            m_recordedStreamingResponse = new(m_traceContent);
            var model = requestOptions.Model ?? "chat";
            var activityName = $"Complete_{model}";
            m_activity = s_chatSource.CreateActivity(activityName, ActivityKind.Client);
            m_caller = caller;
            if (!string.IsNullOrEmpty(caller))
            {
                m_source = new("Azure.AI.Inference");
                m_source.Write($"{m_caller}.Start", activityName);
            }
            m_activity?.Start();
            // Record the request to telemetry;
            m_commonTags = new TagList{
                { GenAiSystemKey, GenAiSystemValue},
                { GenAiResponseModelKey, requestOptions.Model},
                { ServerAddressKey, endpoint.Host },
                { GenAiOperationNameKey, "chat"}
            };
            // Only record port if it is different from 443
            if (endpoint.Port != 443)
                m_commonTags.Add(ServerPortKey, endpoint.Port);
            // Set tags for reporting them to console.
            foreach (KeyValuePair<string, object> kv in m_commonTags)
            {
                m_activity?.SetTag(kv.Key, kv.Value);
            }
            SetTagMaybe(GenAiRequestMaxTokensKey, requestOptions.MaxTokens);
            SetTagMaybe(GenAiRequestTemperatureKey, requestOptions.Temperature);
            if (requestOptions.AdditionalProperties != null && requestOptions.AdditionalProperties.ContainsKey("top_p"))
            {
                SetTagMaybe(
                    GenAiRequestTopPKey,
                    JsonSerializer.Deserialize<double?>(requestOptions.AdditionalProperties["top_p"]));
            }
            if (m_traceContent)
            {
                // Log all messages as the events.
                foreach (ChatRequestMessage message in requestOptions.Messages)
                {
                    TagList requestTags = new() {
                    { GenAiSystemKey, GenAiSystemValue},
                    { GenAiEventContent, GetContent(message)}
                };
                    m_activity?.AddEvent(
                        new ActivityEvent(
                            $"gen_ai.{message.Role}.message",
                            DateTimeOffset.Now,
                            new ActivityTagsCollection(requestTags)
                        )
                    );
                }
            }
            m_duration = Stopwatch.StartNew();
        }

        public void RecordResponse(ChatCompletions response)
        {
            RecordResponseInternal(new SingleRecordedResponse(response, m_traceContent));
        }

        public void UpdateStreamResponse<T>(T item)
        {
            if (!m_enableTelemetry || item is not StreamingChatCompletionsUpdate)
                return;
            StreamingChatCompletionsUpdate castedItem = item as StreamingChatCompletionsUpdate;
            m_recordedStreamingResponse.Update(castedItem);
        }

        public void RecordStreamingResponse()
        {
            RecordResponseInternal(m_recordedStreamingResponse);
        }

        /// <summary>
        /// Log the error.
        /// </summary>
        /// <param name="e">Exception thrown by completion call.</param>
        public void RecordError(Exception e)
        {
            if (!m_enableTelemetry)
                return;
            if (!string.IsNullOrEmpty(m_caller))
                m_source.Write(m_caller + ".Exception", e);
            s_duration.Record(m_duration.Elapsed.TotalSeconds, m_commonTags);
            var errorType = e?.GetType()?.FullName;
            if ( e is Azure.RequestFailedException requestFailed)
            {
                errorType = requestFailed.Status.ToString();
            }
            m_activity?.SetTag(ErrorTypeKey, errorType);
            m_activity?.SetStatus(ActivityStatusCode.Error, e?.Message ?? errorType);
        }

        /// <summary>
        /// Record the events and metrics associated with the response.
        /// </summary>
        /// <param name="recordedResponse"></param>
        private void RecordResponseInternal(AbstractRecordedResponse recordedResponse)
        {
            if (!m_enableTelemetry || recordedResponse.IsEmpty)
                return;
            TagList tags = m_commonTags;
            // Find index of model tag.
            object objOldModel = m_activity?.GetTagItem(GenAiResponseModelKey);
            if (objOldModel != null)
            {
                tags.Remove(new KeyValuePair<string, object> (GenAiResponseModelKey, objOldModel));
            }
            tags.Add(GenAiResponseModelKey, recordedResponse.Model);
            // Record duration metric
            s_duration.Record(m_duration.Elapsed.TotalSeconds, tags);
            // Record input tokens
            if (recordedResponse.PromptTokens.HasValue)
            {
                TagList input_tags = tags;
                input_tags.Add(GenAiUsageInputTokensKey, "input");
                s_tokens.Record(recordedResponse.PromptTokens.Value, input_tags);
                m_activity?.SetTag(GenAiUsageInputTokensKey, recordedResponse.PromptTokens);
            }
            // Record output tokens
            if (recordedResponse.CompletionTokens.HasValue)
            {
                TagList output_tags = tags;
                output_tags.Add(GenAiUsageOutputTokensKey, "output");
                s_tokens.Record(recordedResponse.CompletionTokens.Value, output_tags);
                m_activity?.SetTag(GenAiUsageOutputTokensKey, recordedResponse.CompletionTokens);
            }

            // Record the event for each response
            string[] choices = recordedResponse.GetSerializedCompletions();
            if (m_traceContent)
            {
                foreach (string choice in choices)
                {
                    TagList completionTags = new()
                {
                    { GenAiSystemKey, GenAiSystemValue},
                    { GenAiEventContent, JsonSerializer.Serialize(choice) }
                };
                    m_activity?.AddEvent(new ActivityEvent(
                            GenAiChoice,
                            default,
                            new ActivityTagsCollection(completionTags)
                    ));
                }
            }
            // Set activity tags
            if (!string.IsNullOrEmpty(recordedResponse.FinishReason))
            {
                m_activity?.SetTag(GenAiResponseFinishReasonKey, recordedResponse.FinishReason);
            }
            m_activity?.SetTag(GenAiResponseModelKey, recordedResponse.Model);
            m_activity?.SetTag(GenAiResponseIdKey, recordedResponse.Id);
            m_activity?.SetStatus(ActivityStatusCode.Ok);
        }

        public void Dispose()
        {
            m_activity?.Stop();
            m_source?.Dispose();
        }
    }
}
