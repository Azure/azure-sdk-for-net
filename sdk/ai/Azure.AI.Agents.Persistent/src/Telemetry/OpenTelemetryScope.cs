// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
using static Azure.AI.Agents.Persistent.Telemetry.OpenTelemetryConstants;

namespace Azure.AI.Agents.Persistent.Telemetry
{
    internal class StreamingMessage
    {
        public StreamingMessage(PersistentThreadMessage message, RunStep runStep)
        {
            Message = message;
            RunStep = runStep;
        }
        public RunStep RunStep { get; set; }
        public PersistentThreadMessage Message { get; set; }
    }

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
        private RecordedResponse _response;
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
        /// Create the instance of OpenTelemetryScope for agent creation.
        /// This constructor logs request and starts the execution timer.
        /// </summary>
        /// <param name="content">The request options used in the call.</param>
        /// <param name="endpoint">The endpoint being called.</param>
        public static OpenTelemetryScope StartCreateAgent(RequestContent content, Uri endpoint)
        {
            if (!s_enableTelemetry || !(s_agentSource.HasListeners() || s_duration.Enabled))
            {
                return null;
            }

            // We have to deserialize CreateAgent reques before creating the scope since
            // agent name is part of that span name.
            var createAgentRequest = DeserializeCreateAgentRequest(content);

            string operationName = OperationNameValueCreateAgent + " " + createAgentRequest.Name;
            var scope = new OpenTelemetryScope(operationName, endpoint, OperationNameValueCreateAgent);
            if (scope._activity?.IsAllDataRequested != true && !s_duration.Enabled)
            {
                return null;
            }

            scope.SetTagMaybe(GenAiRequestModelKey, createAgentRequest.Model);
            scope.SetTagMaybe(GenAiAgentNameKey, createAgentRequest.Name);
            scope.SetTagMaybe(GenAiRequestTemperatureKey, createAgentRequest.Temperature);
            scope.SetTagMaybe(GenAiRequestTopPKey, createAgentRequest.TopP);

            string evnt = s_traceContent ? JsonSerializer.Serialize(
                new EventContent (createAgentRequest.Instructions),
                EventsContext.Default.EventContent
            ) : JsonSerializer.Serialize("", EventsContext.Default.String);
            ActivityTagsCollection messageTags = new() {
                   { GenAiSystemKey, GenAiSystemValue},
                   { GenAiEventContent, evnt  }
            };

            scope._activity?.AddEvent(
                new ActivityEvent(EventNameSystemMessage, tags: messageTags)
            );
            return scope;
        }

        /// <summary>
        /// Create the instance of OpenTelemetryScope for thread creation.
        /// This constructor logs request and starts the execution timer.
        /// </summary>
        /// <param name="content">The request options used in the call.</param>
        /// <param name="endpoint">The endpoint being called.</param>
        public static OpenTelemetryScope StartCreateThread(RequestContent content, Uri endpoint)
        {
            if (!s_enableTelemetry || !(s_agentSource.HasListeners() || s_duration.Enabled))
            {
                return null;
            }

            var scope = new OpenTelemetryScope(OperationNameValueCreateThread, endpoint);
            if (scope._activity?.IsAllDataRequested != true && !s_duration.Enabled)
            {
                return null;
            }

            return scope;
        }

        /// <summary>
        /// Create the instance of OpenTelemetryScope for message creation.
        /// This constructor logs request and starts the execution timer.
        /// </summary>
        /// <param name="threadId">The id of the thread to which the message is created.</param>
        /// <param name="content">The request options used in the call.</param>
        /// <param name="endpoint">The endpoint being called.</param>
        public static OpenTelemetryScope StartCreateMessage(string threadId, RequestContent content, Uri endpoint)
        {
            if (!s_enableTelemetry || !(s_agentSource.HasListeners() || s_duration.Enabled))
            {
                return null;
            }

            var scope = new OpenTelemetryScope(OperationNameValueCreateMessage, endpoint);
            if (scope._activity?.IsAllDataRequested != true && !s_duration.Enabled)
            {
                return null;
            }

            CreateMessageRequest createMessageRequest = DeserializeCreateMessageRequest(content);
            string evnt;
            if (s_traceContent)
            {
                string message = createMessageRequest.Content.ToString().Trim('"');
                evnt = JsonSerializer.Serialize(
                    new EventContentRole(content: message, role:createMessageRequest.Role.ToString()),
                    EventsContext.Default.EventContentRole
                );
            }
            else
            {
                evnt = JsonSerializer.Serialize(
                    new EventRole(role: createMessageRequest.Role.ToString()),
                    EventsContext.Default.EventRole
                );
            }

            scope.SetTagMaybe(GenAiThreadIdKey, threadId);
            ActivityTagsCollection messageTags = new() {
                   { GenAiSystemKey, GenAiSystemValue},
                   { GenAiThreadIdKey, threadId},
                   { GenAiEventContent, evnt }
            };
            scope._activity?.AddEvent(
                new ActivityEvent(EventNameUserMessage, tags: messageTags)
            );
            return scope;
        }

        /// <summary>
        /// Create the instance of OpenTelemetryScope for run creation.
        /// This constructor logs request and starts the execution timer.
        /// </summary>
        /// <param name="threadId">The id of the thread that is processed with the run.</param>
        /// <param name="content">The request options used in the call.</param>
        /// <param name="endpoint">The endpoint being called.</param>
        public static OpenTelemetryScope StartCreateRun(string threadId, RequestContent content, Uri endpoint)
        {
            if (!s_enableTelemetry || !(s_agentSource.HasListeners() || s_duration.Enabled))
            {
                return null;
            }

            var createRunRequest = DeserializeCreateRunRequest(content);

            var scope = new OpenTelemetryScope(OperationNameValueStartThreadRun, endpoint);
            if (scope._activity?.IsAllDataRequested != true && !s_duration.Enabled)
            {
                return null;
            }

            scope.SetTagMaybe(GenAiThreadIdKey, threadId);
            var agentId = createRunRequest.AssistantId;
            scope.SetTagMaybe(GenAiAgentIdKey, agentId);

            return scope;
        }

        /// <summary>
        /// Create the instance of OpenTelemetryScope for streaming a run.
        /// This constructor logs request and starts the execution timer.
        /// </summary>
        /// <param name="threadId">The id of the thread that is processed as part of this run.</param>
        /// <param name="agentId">The id of the agent that will process the run.</param>
        /// <param name="endpoint">The endpoint being called.</param>
        public static OpenTelemetryScope StartCreateRunStreaming(string threadId, string agentId, Uri endpoint)
        {
            if (!s_enableTelemetry || !(s_agentSource.HasListeners() || s_duration.Enabled))
            {
                return null;
            }

            var scope = new OpenTelemetryScope(OperationNameValueProcessThreadRun, endpoint);
            if (scope._activity?.IsAllDataRequested != true && !s_duration.Enabled)
            {
                return null;
            }

            scope.SetTagMaybe(GenAiThreadIdKey, threadId);
            scope.SetTagMaybe(GenAiAgentIdKey, agentId);

            return scope;
        }

        /// <summary>
        /// Create the instance of OpenTelemetryScope for run creation.
        /// This constructor logs request and starts the execution timer.
        /// </summary>
        /// <param name="content">The request options used in the call.</param>
        /// <param name="endpoint">The endpoint being called.</param>
        public static OpenTelemetryScope StartCreateRun(RequestContent content, Uri endpoint)
        {
            if (!s_enableTelemetry || !(s_agentSource.HasListeners() || s_duration.Enabled))
            {
                return null;
            }

            var scope = new OpenTelemetryScope(OperationNameValueStartThreadRun, endpoint);
            if (scope._activity?.IsAllDataRequested != true && !s_duration.Enabled)
            {
                return null;
            }

            var createThreadAndRunRequest = DeserializeCreateThreadAndRunRequest(content);
            var agentId = createThreadAndRunRequest.AssistantId;
            scope.SetTagMaybe(GenAiAgentIdKey, agentId);

            return scope;
        }

        /// <summary>
        /// Create the instance of OpenTelemetryScope for getting a rung.
        /// This constructor logs request and starts the execution timer.
        /// </summary>
        /// <param name="runId">The id of the run that is retrieved.</param>
        /// <param name="threadId">The id of the thread that is processed by the run.</param>
        /// <param name="endpoint">The endpoint being called.</param>
        public static OpenTelemetryScope StartGetRun(string runId, string threadId, Uri endpoint)
        {
            if (!s_enableTelemetry || !(s_agentSource.HasListeners() || s_duration.Enabled))
            {
                return null;
            }

            var scope = new OpenTelemetryScope(OperationNameValueGetThreadRun, endpoint);
            if (scope._activity?.IsAllDataRequested != true && !s_duration.Enabled)
            {
                return null;
            }

            scope.SetTagMaybe(GenAiRunIdKey, runId);
            scope.SetTagMaybe(GenAiThreadIdKey, threadId);

            return scope;
        }

        /// <summary>
        /// Create the instance of OpenTelemetryScope for listing messages.
        /// This constructor logs request and starts the execution timer.
        /// </summary>
        /// <param name="threadId">The id of the thread to which the message is created.</param>
        /// <param name="runId">The id of the run for which to get messages.</param>
        /// <param name="endpoint">The endpoint being called.</param>
        public static OpenTelemetryScope StartListMessages(string threadId, string runId, Uri endpoint)
        {
            if (!s_enableTelemetry || !(s_agentSource.HasListeners() || s_duration.Enabled))
            {
                return null;
            }

            var scope = new OpenTelemetryScope(OperationNameValueListMessage, endpoint);
            if (scope._activity?.IsAllDataRequested != true && !s_duration.Enabled)
            {
                return null;
            }

            scope.SetTagMaybe(GenAiThreadIdKey, threadId);
            scope.SetTagMaybe(GenAiRunIdKey, runId);

            return scope;
        }

        /// <summary>
        /// Create the instance of OpenTelemetryScope for submitting tool outputs.
        /// This constructor logs request and starts the execution timer.
        /// </summary>
        /// <param name="threadId">The id of the thread to which the message is created.</param>
        /// <param name="runId">The id of the run for which to get messages.</param>
        /// <param name="content">The request options used in the call.</param>
        /// <param name="endpoint">The endpoint being called.</param>
        public static OpenTelemetryScope StartSubmitToolOutputs(string threadId, string runId, RequestContent content, Uri endpoint)
        {
            if (!s_enableTelemetry || !(s_agentSource.HasListeners() || s_duration.Enabled))
            {
                return null;
            }

            var submitToolOutputsRequest = DeserializeSubmitToolOutputsToRunRequest(content);

            var scope = new OpenTelemetryScope(OperationNameValueSubmitToolOutputs, endpoint);
            if (scope._activity?.IsAllDataRequested != true && !s_duration.Enabled)
            {
                return null;
            }

            scope.SetTagMaybe(GenAiThreadIdKey, threadId);
            scope.SetTagMaybe(GenAiRunIdKey, runId);

            // Log tool outputs as events
            if (submitToolOutputsRequest.ToolOutputs != null)
            {
                foreach (var toolOutput in submitToolOutputsRequest.ToolOutputs)
                {
                    scope.RecordToolOutputEvent(toolOutput);
                }
            }

            return scope;
        }

        /// <summary>
        /// Create the instance of OpenTelemetryScope for listing run steps.
        /// This constructor logs request and starts the execution timer.
        /// </summary>
        /// <param name="threadId">The id of the thread to which the message is created.</param>
        /// <param name="runId">The id of the run for which to get messages.</param>
        /// <param name="endpoint">The endpoint being called.</param>
        public static OpenTelemetryScope StartListRunSteps(string threadId, string runId, Uri endpoint)
        {
            if (!s_enableTelemetry || !(s_agentSource.HasListeners() || s_duration.Enabled))
            {
                return null;
            }

            var scope = new OpenTelemetryScope(OperationNameValueListRunSteps, endpoint);
            if (scope._activity?.IsAllDataRequested != true && !s_duration.Enabled)
            {
                return null;
            }

            scope.SetTagMaybe(GenAiThreadIdKey, threadId);
            scope.SetTagMaybe(GenAiRunIdKey, runId);

            return scope;
        }

        private static CreateAgentRequest DeserializeCreateAgentRequest(RequestContent content)
        {
            // Convert RequestContent to a JSON string
            using var stream = new MemoryStream();
            content.WriteTo(stream, CancellationToken.None);
            stream.Position = 0;

            // Parse the JSON into a CreateAgentRequest object
            using var document = JsonDocument.Parse(stream);
            return CreateAgentRequest.DeserializeCreateAgentRequest(document.RootElement);
        }

        private static CreateMessageRequest DeserializeCreateMessageRequest(RequestContent content)
        {
            // Convert RequestContent to a JSON string
            using var stream = new MemoryStream();
            content.WriteTo(stream, CancellationToken.None);
            stream.Position = 0;

            // Parse the JSON into a CreateMessageRequest object
            using var document = JsonDocument.Parse(stream);
            return CreateMessageRequest.DeserializeCreateMessageRequest(document.RootElement);
        }

        private static CreateRunRequest DeserializeCreateRunRequest(RequestContent content)
        {
            // Convert RequestContent to a JSON string
            using var stream = new MemoryStream();
            content.WriteTo(stream, CancellationToken.None);
            stream.Position = 0;

            // Parse the JSON into a CreateMessageRequest object
            using var document = JsonDocument.Parse(stream);
            return CreateRunRequest.DeserializeCreateRunRequest(document.RootElement);
        }

        private static CreateThreadAndRunRequest DeserializeCreateThreadAndRunRequest(RequestContent content)
        {
            // Convert RequestContent to a JSON string
            using var stream = new MemoryStream();
            content.WriteTo(stream, CancellationToken.None);
            stream.Position = 0;

            // Parse the JSON into a CreateMessageRequest object
            using var document = JsonDocument.Parse(stream);
            return CreateThreadAndRunRequest.DeserializeCreateThreadAndRunRequest(document.RootElement);
        }

        private static SubmitToolOutputsToRunRequest DeserializeSubmitToolOutputsToRunRequest(RequestContent content)
        {
            // Convert RequestContent to a JSON string
            using var stream = new MemoryStream();
            content.WriteTo(stream, CancellationToken.None);
            stream.Position = 0;

            // Parse the JSON into a CreateMessageRequest object
            using var document = JsonDocument.Parse(stream);
            return SubmitToolOutputsToRunRequest.DeserializeSubmitToolOutputsToRunRequest(document.RootElement);
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

        public void RecordCreateAgentResponse(Response response)
        {
            if (s_enableTelemetry)
            {
                _response = new RecordedResponse(s_traceContent);
                var agentResponse = Response.FromValue(PersistentAgent.FromResponse(response), response);
                _response.AgentId = agentResponse.Value.Id;
            }
        }

        public void RecordCreateThreadResponse(Response response)
        {
            if (s_enableTelemetry)
            {
                _response = new RecordedResponse(s_traceContent);
                var threadResponse = Response.FromValue(PersistentAgentThread.FromResponse(response), response);
                _response.ThreadId = threadResponse.Value.Id;
            }
        }

        public void RecordCreateMessageResponse(Response response)
        {
            if (s_enableTelemetry)
            {
                _response = new RecordedResponse(s_traceContent);
                var messageResponse = Response.FromValue(PersistentThreadMessage.FromResponse(response), response);
                _response.MessageId = messageResponse.Value.Id;
                _response.ThreadId = messageResponse.Value.ThreadId;
            }
        }

        public void RecordCreateRunResponse(Response response)
        {
            if (s_enableTelemetry)
            {
                _response = new RecordedResponse(s_traceContent);
                var runResponse = Response.FromValue(ThreadRun.FromResponse(response), response);
                _response.RunId = runResponse.Value.Id;
                _response.ThreadId = runResponse.Value.ThreadId;
                _response.Model = runResponse.Value.Model;
                _response.RunStatus = runResponse.Value.Status.ToString();
            }
        }

        public void RecordGetRunResponse(Response response)
        {
            if (s_enableTelemetry)
            {
                _response = new RecordedResponse(s_traceContent);
                var runResponse = Response.FromValue(ThreadRun.FromResponse(response), response);
                _response.RunId = runResponse.Value.Id;
                _response.AgentId = runResponse.Value.AssistantId;
                _response.Model = runResponse.Value.Model;
                _response.RunStatus = runResponse.Value.Status.ToString();
                if (runResponse.Value.Usage != null)
                {
                    _response.CompletionTokens = (int)runResponse.Value.Usage.CompletionTokens;
                    _response.PromptTokens = (int)runResponse.Value.Usage.PromptTokens;
                }
            }
        }

        public void RecordListMessagesResponse(Response response)
        {
            if (s_enableTelemetry)
            {
                _response = new RecordedResponse(s_traceContent);
            }
        }

        public void RecordSubmitToolOutputsResponse(Response response, bool stream = false)
        {
            if (s_enableTelemetry)
            {
                _response = new RecordedResponse(s_traceContent);
                if (!stream)
                {
                    ThreadRun run = Response.FromValue(ThreadRun.FromResponse(response), response);
                    _response.Model = run.Model;
                    _response.Stream = stream;
                }
            }
        }

        public void RecordListRunStepsResponse(Response response)
        {
            if (s_enableTelemetry)
            {
                _response = new RecordedResponse(s_traceContent);
            }
        }

        /// <summary>
        /// Records a tool output as an event in the OpenTelemetry span.
        /// </summary>
        /// <param name="toolOutput">The tool output to log.</param>
        private void RecordToolOutputEvent(ToolOutput toolOutput)
        {
            // Build the event body
            EventContentId eventBody = s_traceContent
                ? new
                EventContentId(
                    content: toolOutput.Output,
                    id: toolOutput.ToolCallId
                )
                : new
                EventContentId(
                    content: string.Empty,
                    id: toolOutput.ToolCallId
                );

            // Serialize the event body
            string serializedEventBody = JsonSerializer.Serialize(eventBody, EventsContext.Default.EventContentId);

            // Build the attributes
            var attributes = new Dictionary<string, object>
            {
                { GenAiEventContent, serializedEventBody }
            };

            // Record the event
            _activity?.AddEvent(new ActivityEvent(
                "gen_ai.tool.message",
                tags: new ActivityTagsCollection(attributes)
            ));
        }

        public void RecordPagedResponse(Response response)
        {
            if (response == null)
            {
                return;
            }

            if (!s_enableTelemetry)
            {
                return;
            }

            if (_response == null)
            {
                _response = new RecordedResponse(s_traceContent);
            }

            // Copy the content so we don't consume the original stream/buffer
            byte[] contentBytes;
            if (response.ContentStream != null)
            {
                // Copy the stream to a byte array
                using (var ms = new MemoryStream())
                {
                    long originalPosition = 0;
                    if (response.ContentStream.CanSeek)
                    {
                        originalPosition = response.ContentStream.Position;
                        response.ContentStream.Position = 0;
                    }
                    response.ContentStream.CopyTo(ms);
                    if (response.ContentStream.CanSeek)
                    {
                        response.ContentStream.Position = originalPosition;
                    }
                    contentBytes = ms.ToArray();
                }
            }
            else if (response.Content != null)
            {
                contentBytes = Encoding.UTF8.GetBytes(response.Content.ToString());
            }
            else
            {
                // No content to process
                return;
            }

            // Parse the copy
            using JsonDocument doc = JsonDocument.Parse(contentBytes);

            // Assume the items are under the "data" property (adjust if needed)
            if (doc.RootElement.TryGetProperty("data", out JsonElement dataElement) && dataElement.ValueKind == JsonValueKind.Array)
            {
                foreach (JsonElement itemElement in dataElement.EnumerateArray())
                {
                    if (_scopeType == OpenTelemetryScopeType.ListMessages)
                    {
                        // Deserialize the item as a PersistentThreadMessage
                        // Use your model's deserializer
                        PersistentThreadMessage message = PersistentThreadMessage.DeserializePersistentThreadMessage(itemElement);
                        if (_response.Messages == null)
                        {
                            _response.Messages = new List<PersistentThreadMessage>();
                        }
                        _response.Messages.Add(message);
                    }
                    else if (_scopeType == OpenTelemetryScopeType.ListRunSteps)
                    {
                        // Deserialize the item as a RunStep
                        // Use your model's deserializer
                        RunStep runStep = RunStep.DeserializeRunStep(itemElement);
                        if (_response.RunSteps == null)
                        {
                            _response.RunSteps = new List<RunStep>();
                        }
                        _response.RunSteps.Add(runStep);
                    }
                }
            }
        }

        public void RecordStreamingUpdate(StreamingUpdate update)
        {
            if (update == null || !s_enableTelemetry)
                return;

            if (_response == null)
            {
                _response = new RecordedResponse(s_traceContent);
                _response.Stream = true;
            }

            switch (update)
            {
                case RunUpdate runUpdate:
                    var threadRun = runUpdate.Value;
                    _response.LastRun = threadRun;
                    break;

                case MessageStatusUpdate statusUpdate:
                    var value = statusUpdate.Value;
                    var status = value.Status.ToString();
                    if (status == "completed" || status == "failed")
                    {
                        _response.LastMessage = value;
                    }
                    break;

                case RunStepUpdate runStepUpdate:
                    if (_response.RunSteps == null)
                        _response.RunSteps = new List<RunStep>();
                    var runStep = runStepUpdate.Value;
                    if ((runStep.Status == RunStepStatus.Completed) &&
                        (runStep.Type == RunStepType.ToolCalls) &&
                        (runStep.StepDetails is RunStepToolCallDetails toolCallDetails))
                    {
                        _response.RunSteps.Add(runStep);
                    }
                    else if ((runStep.Status == RunStepStatus.Completed) &&
                             (runStep.Type == RunStepType.MessageCreation) &&
                             (_response.LastMessage != null))
                    {
                        StreamingMessage message = new StreamingMessage(_response.LastMessage, runStep);
                        _response.AddStreamingMessage(message);
                        _response.LastMessage = null;
                    }
                    break;
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

            if (_response.LastRun != null)
            {
                _response.RunStatus = _response.LastRun.Status.ToString();
                _response.RunId = _response.LastRun.Id;
                _response.AgentId = _response.LastRun.AssistantId;
                _response.ThreadId = _response.LastRun.ThreadId;
                if (_response.LastRun.Usage != null)
                {
                    _response.CompletionTokens = (int?)_response.LastRun.Usage.CompletionTokens;
                    _response.PromptTokens = (int?)_response.LastRun.Usage.PromptTokens;
                }
                _response.Model = _response.LastRun.Model;
            }

            if (!string.IsNullOrEmpty(_response.Model))
            {
                finalTags.Add(GenAiResponseModelKey, _response.Model);
                _activity?.SetTag(GenAiResponseModelKey, _response.Model);
            }

            if (_response.PromptTokens.HasValue)
            {
                finalTags.Add(GenAiUsageInputTokensKey, _response.PromptTokens);
                _activity?.SetTag(GenAiUsageInputTokensKey, _response.PromptTokens);
            }

            if (_response.CompletionTokens.HasValue)
            {
                finalTags.Add(GenAiUsageOutputTokensKey, _response.CompletionTokens);
                _activity?.SetTag(GenAiUsageOutputTokensKey, _response.CompletionTokens);
            }

            SetTagMaybe(GenAiAgentIdKey, _response.AgentId);
            SetTagMaybe(GenAiThreadIdKey, _response.ThreadId);
            SetTagMaybe(GenAiMessageIdKey, _response.MessageId);
            SetTagMaybe(GenAiRunIdKey, _response.RunId);
            SetTagMaybe(GenAiRunStatusKey, _response.RunStatus);

            // Record input tokens
            if (_response.PromptTokens.HasValue)
            {
                TagList input_tags = finalTags;
                input_tags.Add(GenAiUsageInputTokensKey, "input");
                s_tokens.Record(_response.PromptTokens.Value, input_tags);
            }
            // Record output tokens
            if (_response.CompletionTokens.HasValue)
            {
                TagList output_tags = finalTags;
                output_tags.Add(GenAiUsageOutputTokensKey, "output");
                s_tokens.Record(_response.CompletionTokens.Value, output_tags);
            }

            if (_response.Messages != null)
            {
                foreach (PersistentThreadMessage threadMessage in _response.Messages)
                {
                    RecordThreadMessageEventAttributes(threadMessage);
                }
            }

            if (_response.StreamingMessages != null)
            {
                foreach (StreamingMessage streamingMessage in _response.StreamingMessages)
                {
                    SetTagMaybe(GenAiMessageIdKey, streamingMessage.Message.Id);
                    RecordThreadMessageEventAttributes(streamingMessage.Message, streamingMessage.RunStep);
                }
            }

            if (_response.RunSteps != null)
            {
                foreach (RunStep runStep in _response.RunSteps)
                {
                    RecordRunStepEventAttributes(runStep, _response.Stream);
                }
            }
        }

        private void RecordThreadMessageEventAttributes(PersistentThreadMessage threadMessage, RunStep runStep = null)
        {
            // Derive the event name based on the role
            string eventName = threadMessage.Role.ToString().ToLower() switch
            {
                "user" => EventNameUserMessage,
                "assistant" => EventNameAssistantMessage,
                _ => $"gen_ai.{threadMessage.Role.ToString().ToLower()}.message"
            };

            // Build the content body
            Dictionary<string, Dictionary<string, string>> contentBody = new();
            if (s_traceContent && threadMessage.ContentItems != null)
            {
                foreach (var content in threadMessage.ContentItems)
                {
                    if (content is MessageTextContent textContent)
                    {
                        var contentDetails = new Dictionary<string, string>
                        {
                            { "value", textContent.Text }
                        };

                        if (textContent.Annotations != null && textContent.Annotations.Count > 0)
                        {
                            contentDetails["annotations"] = string.Join(", ", textContent.Annotations);
                        }

                        contentBody["text"] = contentDetails;
                    }
                }
            }

            // Build the event body
            ThreadMessageEventAttributes eventBody = new(
                role: threadMessage.Role.ToString()
            );
            if (s_traceContent)
            {
                eventBody.content = contentBody;
            }

            if (threadMessage.Attachments != null && threadMessage.Attachments.Count > 0)
            {
                var attachmentList = new List<Dictionary<string, object>>();
                foreach (var attachment in threadMessage.Attachments)
                {
                    var attachmentBody = new Dictionary<string, object>
                    {
                        { "id", attachment.FileId }
                    };

                    if (attachment.Tools != null)
                    {
                        attachmentBody["tools"] = attachment.Tools
                            .Select(tool => tool.ToString())
                            .ToList();
                    }

                    attachmentList.Add(attachmentBody);
                }

                eventBody.attachments = attachmentList;
            }

            if (threadMessage.IncompleteDetails != null)
            {
                eventBody.incomplete_details = threadMessage.IncompleteDetails;
            }
            // Serialize the event body
            string serializedEventBody = JsonSerializer.Serialize(eventBody, EventsContext.Default.ThreadMessageEventAttributes);

            // Build the attributes
            Dictionary<string, object> attributes = new()
            {
                { GenAiSystemKey, GenAiSystemValue },
                { GenAiThreadIdKey, threadMessage.ThreadId }
            };

            if (!string.IsNullOrEmpty(threadMessage.AssistantId))
            {
                attributes[GenAiAgentIdKey] = threadMessage.AssistantId;
            }

            if (!string.IsNullOrEmpty(threadMessage.RunId))
            {
                attributes[GenAiRunIdKey] = threadMessage.RunId;
            }

            attributes[GenAiMessageStatusKey] = threadMessage.Status.ToString();

            if (!string.IsNullOrEmpty(threadMessage.Id))
            {
                attributes[GenAiMessageIdKey] = threadMessage.Id;
            }

            if (runStep != null)
            {
                if (runStep.Usage != null)
                {
                    attributes[GenAiUsageInputTokensKey] = runStep.Usage.PromptTokens;
                    attributes[GenAiUsageOutputTokensKey] = runStep.Usage.CompletionTokens;
                }
            }

            attributes[GenAiEventContent] = serializedEventBody;

            // Record the event
            _activity?.AddEvent(new ActivityEvent(
                eventName,
                tags: new ActivityTagsCollection(attributes)
            ));
        }

        /// <summary>
        /// Records a run step event in the OpenTelemetry span.
        /// </summary>
        /// <param name="runStep">The run step containing details about the event to be recorded.</param>
        /// <param name="stream">Is this run step recorded as part of streaming operation.</param>
        private void RecordRunStepEventAttributes(RunStep runStep, bool stream)
        {
            if (runStep == null)
            {
                return;
            }

            // Determine the event name based on the run step type and stream flag
            string runStepType = runStep.Type.ToString().ToLower();
            string eventName =
                (stream && runStepType == "tool_calls")
                ? "gen_ai.tool.message"
                : runStepType switch
                {
                    "message_creation" => "gen_ai.run_step.message_creation",
                    "tool_calls" => "gen_ai.run_step.tool_calls",
                    _ => $"gen_ai.run_step.{runStepType}"
                };

            // Build the attributes for the event
            var attributes = new Dictionary<string, object>
            {
                { GenAiSystemKey, GenAiSystemValue },
                { GenAiThreadIdKey, runStep.ThreadId },
                { GenAiAgentIdKey, runStep.AssistantId },
                { GenAiRunIdKey, runStep.RunId },
                { GenAiRunStepStatusKey, runStep.Status.ToString() },
                { GenAiRunStepStartTimestampKey, runStep.CreatedAt.ToUnixTimeSeconds() }
            };

            if (runStep.CompletedAt.HasValue)
            {
                attributes[GenAiRunStepEndTimestampKey] = runStep.CompletedAt.Value.ToUnixTimeSeconds();
            }

            if (runStep.CancelledAt.HasValue)
            {
                attributes[GenAiRunStepEndTimestampKey] = runStep.CancelledAt.Value.ToUnixTimeSeconds();
            }

            if (runStep.FailedAt.HasValue)
            {
                attributes[GenAiRunStepEndTimestampKey] = runStep.FailedAt.Value.ToUnixTimeSeconds();
            }

            if (runStep.LastError != null)
            {
                attributes[ErrorTypeKey] = runStep.LastError.Code;
                attributes[ErrorMessageKey] = runStep.LastError.Message;
            }

            if (runStep.Usage != null)
            {
                attributes[GenAiUsageInputTokensKey] = runStep.Usage.PromptTokens;
                attributes[GenAiUsageOutputTokensKey] = runStep.Usage.CompletionTokens;
            }

            // Handle specific run step types
            if (runStep.Type.ToString().ToLower() == "message_creation" && runStep.StepDetails is RunStepMessageCreationDetails messageDetails)
            {
                attributes[GenAiMessageIdKey] = messageDetails.MessageCreation.MessageId;
            }
            else if (runStep.Type.ToString().ToLower() == "tool_calls" && runStep.StepDetails is RunStepToolCallDetails toolCallDetails)
            {
                var toolCalls = ProcessToolCalls(toolCallDetails);
                if (toolCalls != null)
                {
                    attributes[GenAiEventContent] = JsonSerializer.Serialize(
                        new ToolCallAttribute(toolCalls),
                        EventsContext.Default.ToolCallAttribute);
                }
            }

            // Record the event
            _activity?.AddEvent(new ActivityEvent(eventName, tags: new ActivityTagsCollection(attributes)));
        }

        /// <summary>
        /// Processes tool calls and returns a list of tool call details.
        /// </summary>
        /// <param name="toolCallDetails">The tool call details to process.</param>
        /// <returns>A serialized list of processed tool call details.</returns>
        private List<JsonElement> ProcessToolCalls(RunStepToolCallDetails toolCallDetails)
        {
            //var toolCalls = new List<BasicToolCallAttributes>();
            var toolCalls = new List<JsonElement>();
            var outputList = new List<Dictionary<string, object>>(); // Collect outputs here

            foreach (var toolCall in toolCallDetails.ToolCalls)
            {
                JsonElement toolCallObj;
                if (!s_traceContent)
                {
                    toolCallObj = ToJsonElement(
                            JsonSerializer.Serialize(
                            new BasicToolCallAttributes(
                                id: toolCall.Id,
                                type: toolCall.Type
                            ),
                            EventsContext.Default.BasicToolCallAttributes
                        )
                    );
                }
                else
                {
                    switch (toolCall)
                    {
                        case RunStepFunctionToolCall functionToolCall:
                            toolCallObj = ToJsonElement(
                                JsonSerializer.Serialize(
                                    new FunctionToolCallEvent(
                                        id: toolCall.Id,
                                        type: toolCall.Type,
                                        function: new FunctionCall(
                                            name: functionToolCall.Name,
                                            arguments: JsonSerializer.Deserialize(functionToolCall.Arguments, jsonTypeInfo: EventsContext.Default.DictionaryStringString)
                                        )
                                    ),
                                    EventsContext.Default.FunctionToolCallEvent
                                )
                            );
                            break;

                        case RunStepCodeInterpreterToolCall codeInterpreterToolCall:
                            toolCallObj = ToJsonElement(
                                JsonSerializer.Serialize(
                                    new CodeInterpreterCallEvent(
                                        id: toolCall.Id,
                                        type: toolCall.Type,
                                        input: codeInterpreterToolCall.Input,
                                        outputs: codeInterpreterToolCall.Outputs
                                    ),
                                    EventsContext.Default.CodeInterpreterCallEvent
                                )
                            );
                            break;

                        case RunStepBingGroundingToolCall bingGroundingToolCall:
                            toolCallObj = ToJsonElement(
                                JsonSerializer.Serialize(
                                    new GenericToolCallEvent(
                                        id: toolCall.Id,
                                        type: toolCall.Type,
                                        details: bingGroundingToolCall.BingGrounding
                                    ),
                                    EventsContext.Default.GenericToolCallEvent
                                )
                            );
                            break;

                        default:
                            IReadOnlyDictionary<string, string> toolCallAttributeDetails = GetToolCallAttributes(toolCall);
                            toolCallObj = ToJsonElement(
                                JsonSerializer.Serialize(
                                    new GenericToolCallEvent(
                                        id: toolCall.Id,
                                        type: toolCall.Type,
                                        details: toolCallAttributeDetails
                                    ),
                                    EventsContext.Default.GenericToolCallEvent
                                )
                            );
                            break;
                    }
                }
                toolCalls.Add(toolCallObj);
            }

            return toolCalls;
        }

        private static JsonElement ToJsonElement(string toolCall)
        {
            using var memStream = new MemoryStream();
            memStream.Write(Encoding.UTF8.GetBytes(toolCall), 0, toolCall.Length);
            // Reset stream position to the beginning.
            memStream.Position = 0;
            using var tempDoc = JsonDocument.Parse(memStream);
            return tempDoc.RootElement.Clone();
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

        public static IReadOnlyDictionary<string, string> GetToolCallAttributes(RunStepToolCall toolCall)
        {
            if (toolCall == null)
            {
                throw new ArgumentNullException(nameof(toolCall));
            }

            // Get the actual type of the toolCall instance
            Type actualType = toolCall.GetType();

            // Create the attribute name by removing "RunStep" and "ToolCall" from the class name
            string attributeName = actualType.Name
                .Replace("RunStep", string.Empty)
                .Replace("ToolCall", string.Empty);

            // We cannot get the properties of an object, because Dynamic types are not AOT compatible.
            // Convert the call to JSON and get properties from it.
            using var memStream = new MemoryStream();
            toolCall.ToRequestContent().WriteTo(memStream, default);
            // Reset stream position to the beginning.
            memStream.Position = 0;
            using var tempDoc = JsonDocument.Parse(memStream);
            // Try to find a property with the parsed name
            var toolCallKind = tempDoc.RootElement.ValueKind;
            Dictionary<string, string> toolDetails = [];
            foreach (JsonProperty elem in tempDoc.RootElement.EnumerateObject())
            {
                if (string.Equals(toCamelCase(elem.Name), attributeName) && elem.Value.ValueKind == JsonValueKind.Object)
                {
                    foreach (JsonProperty detailElem in elem.Value.EnumerateObject())
                    {
                        if (detailElem.Value.ValueKind == JsonValueKind.String)
                        {
                            toolDetails[detailElem.Name] = detailElem.Value.GetString();
                        }
                    }
                }
            }
            // Return null if the property is not found or is not of the expected type
            return toolDetails;
        }

        private static string toCamelCase(string snakeCase)
        {
            string[] parts = snakeCase.Split('_');
            StringBuilder sbCamelCase = new();
            for (int i = 0; i < parts.Length; i++)
            {
                sbCamelCase.Append(char.ToUpper(parts[i][0]));
                sbCamelCase.Append(parts[i].Substring(1));
            }
            return sbCamelCase.ToString();
        }
    }
}
