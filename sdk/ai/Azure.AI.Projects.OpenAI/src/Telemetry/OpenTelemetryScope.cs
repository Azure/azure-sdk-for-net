// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using static Azure.AI.Projects.OpenAI.Telemetry.OpenTelemetryConstants;

namespace Azure.AI.Projects.OpenAI.Telemetry
{
    internal class OpenTelemetryScope : IDisposable
    {
        internal enum OpenTelemetryScopeType
        {
            Unknown,
            CreateAgent,
            CreateThread,
            CreateMessage,
            CreateRun,
            ListMessages,
            SubmitToolOutputs,
            ListRunSteps
        }

        /// <summary>
        /// Activity source is used to save events and log the tags.
        /// On the ApplicationInsights events are logged to traces table.
        /// The tags are not logged, but are shown in the console.
        /// </summary>
        private static readonly ActivitySource s_agentSource = new(ClientName);
        /// <summary>
        /// Add histograms to log metrics.
        /// On the ApplicationInsights metrics are logged to customMetrics table.
        /// </summary>
        private static readonly Meter s_meter = new Meter(ClientName);
        private static readonly Histogram<double> s_duration = s_meter.CreateHistogram<double>(
            GenAiClientOperationDurationMetricName, "s", "Measures GenAI operation duration.");
        private static readonly Histogram<long> s_tokens = s_meter.CreateHistogram<long>(
            GenAiClientTokenUsageMetricName, "{token}", "Measures the number of input and output token used.");
        private static readonly JsonSerializerOptions s_jsonOptions = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping // Allow non-ASCII characters
        };

        private readonly Activity _activity;
        private readonly Stopwatch _duration;
        private readonly TagList _commonTags;
        private static bool s_traceContent = AppContextSwitchHelper.GetConfigValue(
            TraceContentsSwitch,
            TraceContentsEnvironmentVariable);
        private static bool s_enableTelemetry = AppContextSwitchHelper.GetConfigValue(
            EnableOpenTelemetrySwitch,
            EnableOpenTelemetryEnvironmentVariable);
        // private RecordedResponse _response;
        private string _errorType;
        private Exception _exception;

        private int _hasEnded = 0;
        private readonly OpenTelemetryScopeType _scopeType;
        private static void ReinitializeConfiguration()
        {
            s_traceContent = AppContextSwitchHelper.GetConfigValue(
                TraceContentsSwitch,
                TraceContentsEnvironmentVariable);

            s_enableTelemetry = AppContextSwitchHelper.GetConfigValue(
                EnableOpenTelemetrySwitch,
                EnableOpenTelemetryEnvironmentVariable);
        }

        /// <summary>
        /// Sets telemetry tags and events for agent definition, handling both PromptAgentDefinition and other types.
        /// </summary>
        /// <param name="scope">The OpenTelemetryScope instance to set tags on.</param>
        /// <param name="agentDefinition">The agent definition to process.</param>
        /// <param name="agentName">The name of the agent.</param>
        private static void SetAgentDefinitionTelemetryTags(OpenTelemetryScope scope, AgentDefinition agentDefinition, string agentName)
        {
            if (agentDefinition is PromptAgentDefinition promptAgentDefinition)
            {
                scope.SetTagMaybe(GenAiRequestModelKey, promptAgentDefinition.Model);
                scope.SetTagMaybe(GenAiAgentNameKey, agentName);
                scope.SetTagMaybe(GenAiRequestTemperatureKey, promptAgentDefinition.Temperature);
                scope.SetTagMaybe(GenAiRequestTopPKey, promptAgentDefinition.TopP);

                var reasoningOptions = promptAgentDefinition.ReasoningOptions;
                if (reasoningOptions != null)
                {
                    scope.SetTagMaybe(GenAiRequestReasoningEffort, reasoningOptions.ReasoningEffortLevel);
                    scope.SetTagMaybe(GenAiRequestReasoningSummary, reasoningOptions.ReasoningSummaryVerbosity);
                }

                // TODO: check if structured outputs should be events and follow content recording flag
                //var structuredInputs = promptAgentDefinition.StructuredInputs;

                string evnt = s_traceContent ? JsonSerializer.Serialize(
                    new EventContent (promptAgentDefinition.Instructions),
                    EventsContext.Default.EventContent
                ) : JsonSerializer.Serialize("", EventsContext.Default.String);

                ActivityTagsCollection messageTags = new() {
                    { GenAiSystemKey, GenAiSystemValue},
                    { GenAiEventContent, evnt  }
                };

                scope._activity?.AddEvent(
                    new ActivityEvent(EventNameSystemMessage, tags: messageTags)
                );
            }
            else
            {
                // Handle other agent definition types or set default values
                scope.SetTagMaybe(GenAiRequestModelKey, "unknown");
                scope.SetTagMaybe(GenAiAgentNameKey, agentName);
                scope.SetTagMaybe(GenAiRequestTemperatureKey, null);
                scope.SetTagMaybe(GenAiRequestTopPKey, null);
            }
        }

        private OpenTelemetryScope(string activityName, Uri endpoint, string operationName=null)
        {
            _scopeType = activityName switch
            {
                var n when n == OperationNameValueCreateAgent => OpenTelemetryScopeType.CreateAgent,
                var n when n == OperationNameValueCreateThread => OpenTelemetryScopeType.CreateThread,
                var n when n == OperationNameValueCreateMessage => OpenTelemetryScopeType.CreateMessage,
                var n when n == OperationNameValueStartThreadRun => OpenTelemetryScopeType.CreateRun,
                var n when n == OperationNameValueListMessage => OpenTelemetryScopeType.ListMessages,
                var n when n == OperationNameValueSubmitToolOutputs => OpenTelemetryScopeType.SubmitToolOutputs,
                var n when n == OperationNameValueListRunSteps => OpenTelemetryScopeType.ListRunSteps,
                _ => OpenTelemetryScopeType.Unknown
            };

            if (operationName == null)
            {
                operationName = activityName;
            }

            _activity = s_agentSource.StartActivity(activityName, ActivityKind.Client);

            // suppress nested client activities from generated code.
            _activity?.SetCustomProperty("az.sdk.scope", bool.TrueString);

            // Record the request to telemetry.
            _commonTags = new TagList()
            {
                { GenAiSystemKey, GenAiSystemValue},
                { GenAiOperationNameKey, operationName},
                { ServerAddressKey, endpoint.Host }
            };
            // Only record port if it is different from 443.
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
            _duration = Stopwatch.StartNew();
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
            //TagList finalTags = _commonTags;

            //if (_errorType == null && !IsResponseValid(_response))
            //{
            //    // If there is no response and no error, it is an unexpected error.
            //    _errorType = "error";
            //}

            //if (_errorType != null)
            //{
            //    finalTags.Add(ErrorTypeKey, _errorType);
            //    _activity?.SetTag(ErrorTypeKey, _errorType);
            //    _activity?.SetStatus(ActivityStatusCode.Error, _exception?.Message);
            //}

            //if (_response == null)
            //{
            //    s_duration.Record(_duration.Elapsed.TotalSeconds, finalTags);
            //    return;
            //}

            //if (!string.IsNullOrEmpty(_response.Model))
            //{
            //    finalTags.Add(GenAiResponseModelKey, _response.Model);
            //    _activity?.SetTag(GenAiResponseModelKey, _response.Model);
            //}

            //if (!string.IsNullOrEmpty(_response.Version))
            //{
            //    finalTags.Add(GenAiAgentVersion, _response.Version);
            //    _activity?.SetTag(GenAiAgentVersion, _response.Version);
            //}

            //if (_response.PromptTokens.HasValue)
            //{
            //    finalTags.Add(GenAiUsageInputTokensKey, _response.PromptTokens);
            //    _activity?.SetTag(GenAiUsageInputTokensKey, _response.PromptTokens);
            //}

            //if (_response.CompletionTokens.HasValue)
            //{
            //    finalTags.Add(GenAiUsageOutputTokensKey, _response.CompletionTokens);
            //    _activity?.SetTag(GenAiUsageOutputTokensKey, _response.CompletionTokens);
            //}

            //SetTagMaybe(GenAiAgentIdKey, _response.AgentId);
            //SetTagMaybe(GenAiThreadIdKey, _response.ThreadId);
            //SetTagMaybe(GenAiMessageIdKey, _response.MessageId);
            //SetTagMaybe(GenAiRunIdKey, _response.RunId);
            //SetTagMaybe(GenAiRunStatusKey, _response.RunStatus);

            //// Record input tokens
            //if (_response.PromptTokens.HasValue)
            //{
            //    TagList input_tags = finalTags;
            //    input_tags.Add(GenAiUsageInputTokensKey, "input");
            //    s_tokens.Record(_response.PromptTokens.Value, input_tags);
            //}
            //// Record output tokens
            //if (_response.CompletionTokens.HasValue)
            //{
            //    TagList output_tags = finalTags;
            //    output_tags.Add(GenAiUsageOutputTokensKey, "output");
            //    s_tokens.Record(_response.CompletionTokens.Value, output_tags);
            //}
        }

        public void Dispose()
        {
            // check if the scope has already ended
            if (s_enableTelemetry && Interlocked.Exchange(ref _hasEnded, 1) == 0)
            {
                //_response ??= _buffer?.ToResponse();
                End();
                _activity?.Dispose();
            }
        }

        private static bool IsResponseValid(RecordedResponse response)
        {
            return response != null;// && response.Id != null && response.FinishReasons != null;
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

        private void SetTagMaybe(string name, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                _activity?.SetTag(name, value);
            }
        }

        internal static void ResetEnvironmentForTests()
        {
            s_traceContent = AppContextSwitchHelper.GetConfigValue(TraceContentsSwitch, TraceContentsEnvironmentVariable);
            s_enableTelemetry = AppContextSwitchHelper.GetConfigValue(EnableOpenTelemetrySwitch, EnableOpenTelemetryEnvironmentVariable);
        }
    }
}
