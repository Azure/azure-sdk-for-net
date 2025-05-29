// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using Azure.Core;
using static Azure.AI.Agents.Persistent.Telemetry.OpenTelemetryConstants;
using System.Threading.Tasks;
using System.Linq;
using System.Threading;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ClientModel.Primitives;
using System.Net;
using System.IO;
using System.Text.Encodings.Web;
using System.Text;
using System.Reflection;

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
        private static bool s_traceContent = true;
        private static bool s_enableTelemetry = true;
        //private static bool s_traceContent = AppContextSwitchHelper.GetConfigValue(
        //    TraceContentsSwitch,
        //    TraceContentsEnvironmentVariable);
        //private static bool s_enableTelemetry = AppContextSwitchHelper.GetConfigValue(
        //    EnableOpenTelemetrySwitch,
        //    EnableOpenTelemetryEnvironmentVariable);
        private RecordedResponse _response;
        private string _errorType;
        private Exception _exception;

        private int _hasEnded = 0;
        private readonly OpenTelemetryScopeType _scopeType;
        // In your handler class:

        /// <summary>
        /// Create the instance of OpenTelemetryScope for agent creation.
        /// This constructor logs request and starts the execution timer.
        /// </summary>
        /// <param name="content">The request options used in the call.</param>
        /// <param name="endpoint">The endpoint being called.</param>
        public static OpenTelemetryScope StartCreateAgent(RequestContent content, Uri endpoint)
        {
            if (!s_enableTelemetry)
            {
                return null;
            }
            // Deserialize the RequestContent into a CreateAgentRequest object
            var createAgentRequest = DeserializeCreateAgentRequest(content);

            var scope = new OpenTelemetryScope(OperationNameValueCreateAgent, endpoint);

            scope.SetTagMaybe(GenAiRequestModelKey, createAgentRequest.Model);
            scope.SetTagMaybe(GenAiAgentNameKey, createAgentRequest.Name);
            scope.SetTagMaybe(GenAiRequestTemperatureKey, createAgentRequest.Temperature);
            scope.SetTagMaybe(GenAiRequestTopPKey, createAgentRequest.TopP);

            object evnt = s_traceContent ? new { content = createAgentRequest.Instructions } : null;
            ActivityTagsCollection messageTags = new() {
                   { GenAiSystemKey, GenAiSystemValue},
                   { GenAiEventContent, evnt != null ? JsonSerializer.Serialize(evnt) : null  }
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
            if (!s_enableTelemetry)
            {
                return null;
            }
            // Deserialize the RequestContent into a CreateThreadRequest object
            var createThreadRequest = DeserializeCreateThreadRequest(content);
            var scope = new OpenTelemetryScope(OperationNameValueCreateThread, endpoint);

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
            if (!s_enableTelemetry)
            {
                return null;
            }

            var createMessageRequest = DeserializeCreateMessageRequest(content);
            object evnt = null;
            if (s_traceContent)
            {
                try
                {
                    // Attempt to deserialize as a string
                    string message = createMessageRequest.Content.ToString().Trim('"');
                    evnt = new { content = message, role = createMessageRequest.Role.ToString() };
                }
                catch
                {
                }
            }
            else
            {
                evnt = new { role = createMessageRequest.Role.ToString() };
            }

            var scope = new OpenTelemetryScope(OperationNameValueCreateMessage, endpoint);
            scope.SetTagMaybe(GenAiThreadIdKey, threadId);
            ActivityTagsCollection messageTags = new() {
                   { GenAiSystemKey, GenAiSystemValue},
                   { GenAiEventContent, evnt != null ? JsonSerializer.Serialize(evnt) : null  }
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
            if (!s_enableTelemetry)
            {
                return null;
            }

            var createRunRequest = DeserializeCreateRunRequest(content);

            var scope = new OpenTelemetryScope(OperationNameValueStartThreadRun, endpoint);
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
            if (!s_enableTelemetry)
            {
                return null;
            }

            var scope = new OpenTelemetryScope(OperationNameValueProcessThreadRun, endpoint);
            scope.SetTagMaybe(GenAiThreadIdKey, threadId);
            scope.SetTagMaybe(GenAiAgentIdKey, agentId);

            return scope;
        }

        /// <summary>
        /// Create the instance of OpenTelemetryScope for message creation.
        /// This constructor logs request and starts the execution timer.
        /// </summary>
        /// <param name="content">The request options used in the call.</param>
        /// <param name="endpoint">The endpoint being called.</param>
        public static OpenTelemetryScope StartCreateRun(RequestContent content, Uri endpoint)
        {
            if (!s_enableTelemetry)
            {
                return null;
            }

            var createThreadAndRunRequest = DeserializeCreateThreadAndRunRequest(content);

            var scope = new OpenTelemetryScope(OperationNameValueStartThreadRun, endpoint);
            var agentId = createThreadAndRunRequest.AssistantId;
            scope.SetTagMaybe(GenAiAgentIdKey, agentId);

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
            if (!s_enableTelemetry)
            {
                return null;
            }

            var scope = new OpenTelemetryScope(OperationNameValueListMessage, endpoint);
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
            if (!s_enableTelemetry)
            {
                return null;
            }

            var submitToolOutputsRequest = DeserializeSubmitToolOutputsToRunRequest(content);

            var scope = new OpenTelemetryScope(OperationNameValueSubmitToolOutputs, endpoint);
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
            if (!s_enableTelemetry)
            {
                return null;
            }
            var scope = new OpenTelemetryScope(OperationNameValueListRunSteps, endpoint);
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

        private static CreateThreadRequest DeserializeCreateThreadRequest(RequestContent content)
        {
            // Convert RequestContent to a JSON string
            using var stream = new MemoryStream();
            content.WriteTo(stream, CancellationToken.None);
            stream.Position = 0;

            // Parse the JSON into a CreateThreadRequest object
            using var document = JsonDocument.Parse(stream);
            return CreateThreadRequest.DeserializeCreateThreadRequest(document.RootElement);
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

        private OpenTelemetryScope(string activityName, Uri endpoint)
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

            _activity = s_agentSource.StartActivity(activityName, ActivityKind.Client);

            // suppress nested client activities from generated code.
            _activity?.SetCustomProperty("az.sdk.scope", bool.TrueString);

            // Record the request to telemetry.
            _commonTags = new TagList()
            {
                { GenAiSystemKey, GenAiSystemValue},
                { GenAiOperationNameKey, activityName},
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

        public void RecordListMessagesResponse(Response response)
        {
            if (s_enableTelemetry)
            {
                _response = new RecordedResponse(s_traceContent);
                //Response<InternalOpenAIPageableListOfThreadMessage> r1 = Response.FromValue(InternalOpenAIPageableListOfThreadMessage.FromResponse(response), response);
                //Response<PageableList<ThreadMessage>> r2 = Response.FromValue(PageableList<ThreadMessage>.Create(r1.Value), r1.GetRawResponse());
                //_response.Messages = r2;
            }
        }

        public void RecordSubmitToolOutputsResponse(Response response)
        {
            if (s_enableTelemetry)
            {
                _response = new RecordedResponse(s_traceContent);
                ThreadRun run = Response.FromValue(ThreadRun.FromResponse(response), response);
                _response.Model = run.Model;
            }
        }

        public void RecordListRunStepsResponse(Response response)
        {
            if (s_enableTelemetry)
            {
                _response = new RecordedResponse(s_traceContent);
                //Response<Pageable> r1 = Response.FromValue(Pageable.FromResponse(response), response);
                //Response<PageableList<RunStep>> r2 = Response.FromValue(PageableList<RunStep>.Create(r1.Value), r1.GetRawResponse());
                //_response.RunSteps = r2;
            }
        }

        /// <summary>
        /// Records a tool output as an event in the OpenTelemetry span.
        /// </summary>
        /// <param name="toolOutput">The tool output to log.</param>
        private void RecordToolOutputEvent(ToolOutput toolOutput)
        {
            // Build the event body
            var eventBody = s_traceContent
                ? new
                {
                    content = toolOutput.Output,
                    id = toolOutput.ToolCallId
                }
                : new
                {
                    content = string.Empty,
                    id = toolOutput.ToolCallId
                };

            // Serialize the event body
            string serializedEventBody = JsonSerializer.Serialize(eventBody, s_jsonOptions);

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
                _response = new RecordedResponse(s_traceContent);

            switch (update)
            {
                //case MessageContentUpdate contentUpdate:
                //    if (_currentStreamingMessage == null)
                //        _currentStreamingMessage = new StreamingMessage();

                //    if (!string.IsNullOrEmpty(contentUpdate.Text))
                //        _currentStreamingMessage.MessageText.Append(contentUpdate.Text);

                //    // Optionally set role/messageId if not already set
                //    if (string.IsNullOrEmpty(_currentStreamingMessage.Role) && contentUpdate.Role.HasValue)
                //        _currentStreamingMessage.Role = contentUpdate.Role.Value.ToString();
                //    if (string.IsNullOrEmpty(_currentStreamingMessage.MessageId))
                //        _currentStreamingMessage.MessageId = contentUpdate.MessageId;
                //    break;
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

            // report duration
            s_duration.Record(_duration.Elapsed.TotalSeconds, finalTags);

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
                    RecordThreadMessageEventAttributes(streamingMessage.Message, streamingMessage.RunStep);
                }
            }

            //if (_response.StreamingMessages != null)
            //{
            //    foreach (StreamingMessage streamingMessage in _response.StreamingMessages)
            //    {
            //        var jsonDocument = JsonDocument.Parse($@"
            //            {{
            //                ""id"": ""{streamingMessage.MessageId}"",
            //                ""thread_id"": ""{streamingMessage.ThreadId}"",
            //                ""assistant_id"": ""{streamingMessage.AgentId}"",
            //                ""run_id"": ""{streamingMessage.RunId}"",
            //                ""role"": ""{streamingMessage.Role}"",
            //                ""contentItems"": [
            //                    {{
            //                        ""type"": ""text"",
            //                        ""text"": {{
            //                            ""value"": {JsonSerializer.Serialize(streamingMessage.MessageText.ToString())}
            //                        }}
            //                    }}
            //                ]
            //            }}").RootElement;
            //        // With the following code:
            //        var threadMessage = PersistentThreadMessage.DeserializePersistentThreadMessage(jsonDocument);
            //        RecordThreadMessageEventAttributes(threadMessage);
            //    }
            //}

            if (_response.RunSteps != null)
            {
                foreach (RunStep runStep in _response.RunSteps)
                {
                    RecordRunStepEventAttributes(runStep);
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
            Dictionary<string, object> contentBody = new();
            if (s_traceContent && threadMessage.ContentItems != null)
            {
                foreach (var content in threadMessage.ContentItems)
                {
                    if (content is MessageTextContent textContent)
                    {
                        var contentDetails = new Dictionary<string, object>
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
            Dictionary<string, object> eventBody = new();
            if (s_traceContent)
            {
                eventBody["content"] = contentBody;
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

                eventBody["attachments"] = attachmentList;
            }

            if (threadMessage.IncompleteDetails != null)
            {
                eventBody["incomplete_details"] = threadMessage.IncompleteDetails;
            }

            eventBody["role"] = threadMessage.Role.ToString();

            // Serialize the event body
            string serializedEventBody = JsonSerializer.Serialize(eventBody, s_jsonOptions);

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

            attributes[GenAiMessageStatusKey] = threadMessage.Status;

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
        private void RecordRunStepEventAttributes(RunStep runStep)
        {
            if (runStep == null)
            {
                return;
            }

            // Determine the event name based on the run step type
            string eventName = runStep.Type.ToString().ToLower() switch
            {
                "message_creation" => "gen_ai.run_step.message_creation",
                "tool_calls" => "gen_ai.run_step.tool_calls",
                _ => $"gen_ai.run_step.{runStep.Type.ToString().ToLower()}"
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
                    attributes[GenAiEventContent] = JsonSerializer.Serialize(new { tool_calls = toolCalls }, s_jsonOptions);
                }
            }

            // Record the event
            _activity?.AddEvent(new ActivityEvent(eventName, tags: new ActivityTagsCollection(attributes)));
        }

        /// <summary>
        /// Processes tool calls and returns a list of tool call details.
        /// </summary>
        /// <param name="toolCallDetails">The tool call details to process.</param>
        /// <returns>A list of processed tool call details.</returns>
        private List<Dictionary<string, object>> ProcessToolCalls(RunStepToolCallDetails toolCallDetails)
        {
            var toolCalls = new List<Dictionary<string, object>>();
            var outputList = new List<Dictionary<string, object>>(); // Collect outputs here

            foreach (var toolCall in toolCallDetails.ToolCalls)
            {
                var toolCallAttributes = new Dictionary<string, object>
                       {
                           { "id", toolCall.Id },
                           { "type", toolCall.Type }
                       };

                if (s_traceContent)
                {
                    switch (toolCall)
                    {
                        case RunStepFunctionToolCall functionToolCall:
                            toolCallAttributes["function"] = new
                            {
                                name = functionToolCall.Name,
                                arguments = JsonSerializer.Deserialize<Dictionary<string, object>>(functionToolCall.Arguments)
                            };
                            break;

                        case RunStepCodeInterpreterToolCall codeInterpreterToolCall:
                            foreach (var output in codeInterpreterToolCall.Outputs)
                            {
                                var outputDictionary = ConvertToDictionary(output);
                                outputList.Add(outputDictionary); // Add output to the list
                            }
                            toolCallAttributes["code_interpreter"] = new
                            {
                                input = codeInterpreterToolCall.Input,
                                outputs = outputList
                            };
                            break;

                        case RunStepBingGroundingToolCall bingGroundingToolCall:
                            toolCallAttributes[toolCall.Type] = bingGroundingToolCall.BingGrounding;
                            break;

                        default:
                            var toolCallAttributeDetails = GetToolCallAttributes(toolCall);
                            if (toolCallAttributes != null)
                            {
                                toolCallAttributes[toolCall.Type] = toolCallAttributeDetails;
                            }
                            break;
                    }
                }

                toolCalls.Add(toolCallAttributes);
            }

            return toolCalls;
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

        // To convert an object to a dictionary, you can use the following method:
        public static Dictionary<string, object> ConvertToDictionary(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            return obj.GetType()
                      .GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance)
                      .ToDictionary(
                          prop => prop.Name,
                          prop => prop.GetValue(obj, null)
                      );
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

            // Try to find a property with the parsed name
            PropertyInfo property = actualType.GetProperty(attributeName, BindingFlags.Public | BindingFlags.Instance);

            if (property != null && property.PropertyType == typeof(IReadOnlyDictionary<string, string>))
            {
                // Get the value of the property
                return property.GetValue(toolCall) as IReadOnlyDictionary<string, string>;
            }

            // Return null if the property is not found or is not of the expected type
            return null;
        }
    }
}
