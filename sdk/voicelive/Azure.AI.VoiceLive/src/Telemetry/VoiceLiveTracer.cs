// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Text.Json;
using System.Threading;
using Keys = Azure.AI.VoiceLive.Telemetry.VoiceLiveTelemetryAttributeKeys;

namespace Azure.AI.VoiceLive.Telemetry
{
    /// <summary>
    /// Manages OpenTelemetry tracing for VoiceLive sessions using System.Diagnostics.ActivitySource.
    ///
    /// Span hierarchy:
    ///   connect (root, lives for session lifetime)
    ///     └─ send {event_type}  (child, short-lived per command sent)
    ///     └─ recv {event_type}  (child, short-lived per message received)
    ///
    /// All child spans use an explicit parent context to ensure correct parenting even when
    /// running across concurrent async tasks (send loop vs receive loop).
    /// </summary>
    internal sealed class VoiceLiveTracer
    {
        /// <summary>
        /// ActivitySource registered for this library. Consumers register an ActivityListener
        /// (e.g. via OpenTelemetry SDK) to receive spans.
        /// </summary>
        internal static readonly ActivitySource ActivitySource = new("Azure.AI.VoiceLive", "1.1.0");

        // Env-var-controlled content recording. Lazy so env vars are read once.
        private static readonly Lazy<bool> s_captureMessageContent = new(DetermineContentRecordingFromEnvironment);

        // Connection metadata (parsed from the endpoint URI once at construction time)
        private readonly string _serverAddress;
        private readonly int _serverPort;
        private readonly string _model;
        private readonly string _agentName;
        private readonly string _agentProjectName;
        private readonly string _agentVersion;
        private readonly bool _enableContentRecording;

        // Root "connect" Activity that spans the entire session lifetime.
        // Written once from StartConnectActivity and read from multiple async tasks — no lock needed
        // because StartConnectActivity completes before any send/recv begin.
        private Activity _connectActivity;

        // Session state set from session.created server event
        private string _sessionId;

        // --- Session-level counters (Interlocked for concurrent send/recv tasks) ---
        private long _turnCount;
        private long _interruptionCount;
        private long _audioBytesSent;
        private long _audioBytesReceived;
        private long _mcpCallCount;
        private long _mcpListToolsCount;

        // --- First-token latency tracking ---
        // Timestamp (Stopwatch.GetTimestamp()) recorded when response.create is sent.
        private long _responseCreateTimestamp;
        // 0 = not yet recorded for this response cycle, 1 = already recorded.
        private int _firstTokenLatencyRecorded;

        public VoiceLiveTracer(Uri endpoint, bool? enableContentRecordingOverride)
        {
            if (endpoint != null)
            {
                _serverAddress = endpoint.Host;
                _serverPort = endpoint.Port;

                // Extract model or agent parameters from the WebSocket endpoint query string.
                // Model session:  ?model=gpt-4o-realtime-preview
                // Agent session:  ?agent-name=foo&agent-project-name=bar&agent-version=1
                string query = endpoint.Query?.TrimStart('?');
                if (!string.IsNullOrEmpty(query))
                {
                    foreach (string part in query.Split('&'))
                    {
                        string[] kv = part.Split(new char[] { '=' }, 2);
                        if (kv.Length == 2)
                        {
                            string key = Uri.UnescapeDataString(kv[0]);
                            string value = Uri.UnescapeDataString(kv[1]);
                            switch (key)
                            {
                                case "model": _model = value; break;
                                case "agent-name": _agentName = value; break;
                                case "agent-project-name": _agentProjectName = value; break;
                                case "agent-version": _agentVersion = value; break;
                            }
                        }
                    }
                }
            }

            _enableContentRecording = enableContentRecordingOverride ?? s_captureMessageContent.Value;
        }

        /// <summary>Gets whether any ActivityListener is observing this source (zero-cost guard).</summary>
        public bool IsEnabled => ActivitySource.HasListeners();

        // ─── Connect span (session lifetime) ────────────────────────────────────────

        /// <summary>
        /// Starts the root "connect" Activity. Call once from ConnectAsync before the WebSocket
        /// handshake begins. Returns the activity so the caller can record a connect error if needed.
        /// </summary>
        public Activity StartConnectActivity()
        {
            if (!ActivitySource.HasListeners())
                return null;

            _connectActivity = ActivitySource.StartActivity(Keys.OperationNameConnect, ActivityKind.Client);
            if (_connectActivity?.IsAllDataRequested == true)
            {
                SetCommonAttributes(_connectActivity, Keys.OperationNameConnect);

                if (!string.IsNullOrEmpty(_model))
                    _connectActivity.SetTag(Keys.GenAiRequestModel, _model);

                if (!string.IsNullOrEmpty(_agentName))
                    _connectActivity.SetTag(Keys.GenAiAgentName, _agentName);
                if (!string.IsNullOrEmpty(_agentProjectName))
                    _connectActivity.SetTag(Keys.GenAiAgentProjectName, _agentProjectName);
                if (!string.IsNullOrEmpty(_agentVersion))
                    _connectActivity.SetTag(Keys.GenAiAgentVersion, _agentVersion);
            }

            return _connectActivity;
        }

        /// <summary>
        /// Ends the root "connect" Activity, recording session-level counters and any error.
        /// Safe to call multiple times — only the first call with an active Activity acts.
        /// </summary>
        public void EndConnectActivity(Exception error = null)
        {
            Activity activity = Interlocked.Exchange(ref _connectActivity, null);
            if (activity == null)
                return;

            if (activity.IsAllDataRequested)
            {
                long turns = Interlocked.Read(ref _turnCount);
                long interruptions = Interlocked.Read(ref _interruptionCount);
                long bytesSent = Interlocked.Read(ref _audioBytesSent);
                long bytesReceived = Interlocked.Read(ref _audioBytesReceived);
                long mcpCalls = Interlocked.Read(ref _mcpCallCount);
                long mcpListTools = Interlocked.Read(ref _mcpListToolsCount);

                if (turns > 0) activity.SetTag(Keys.GenAiVoiceTurnCount, turns);
                if (interruptions > 0) activity.SetTag(Keys.GenAiVoiceInterruptionCount, interruptions);
                if (bytesSent > 0) activity.SetTag(Keys.GenAiVoiceAudioBytesSent, bytesSent);
                if (bytesReceived > 0) activity.SetTag(Keys.GenAiVoiceAudioBytesReceived, bytesReceived);
                if (mcpCalls > 0) activity.SetTag(Keys.GenAiVoiceMcpCallCount, mcpCalls);
                if (mcpListTools > 0) activity.SetTag(Keys.GenAiVoiceMcpListToolsCount, mcpListTools);

                if (error != null)
                {
                    activity.SetStatus(ActivityStatusCode.Error, error.Message);
                    activity.SetTag(Keys.ErrorType, error.GetType().FullName);
                    activity.SetTag(Keys.ErrorMessage, error.Message);
                }
            }

            activity.Stop();
        }

        // ─── Send spans (per outgoing command) ──────────────────────────────────────

        /// <summary>
        /// Starts a child "send {eventType}" Activity parented to the connect Activity.
        /// Returns null if no listeners are registered or the connect span does not exist.
        /// The caller MUST call activity.Stop() (or use in a try/finally block).
        /// </summary>
        public Activity StartSendActivity(string eventType)
        {
            if (_connectActivity == null || !ActivitySource.HasListeners())
                return null;

            var activity = ActivitySource.StartActivity(
                $"send {eventType}",
                ActivityKind.Client,
                parentContext: _connectActivity.Context);

            if (activity?.IsAllDataRequested == true)
            {
                SetCommonAttributes(activity, Keys.OperationNameSend);

                if (!string.IsNullOrEmpty(_model))
                    activity.SetTag(Keys.GenAiRequestModel, _model);
                if (!string.IsNullOrEmpty(_sessionId))
                    activity.SetTag(Keys.GenAiVoiceSessionId, _sessionId);
                activity.SetTag(Keys.GenAiVoiceEventType, eventType);
            }

            return activity;
        }

        // ─── Recv spans (per incoming message) ──────────────────────────────────────

        /// <summary>
        /// Starts a child "recv {eventType}" Activity parented to the connect Activity.
        /// Returns null if no listeners are registered or the connect span does not exist.
        /// The caller MUST call activity.Stop() (or use in a try/finally block).
        /// </summary>
        public Activity StartRecvActivity(string eventType)
        {
            if (_connectActivity == null || !ActivitySource.HasListeners())
                return null;

            var activity = ActivitySource.StartActivity(
                $"recv {eventType}",
                ActivityKind.Client,
                parentContext: _connectActivity.Context);

            if (activity?.IsAllDataRequested == true)
            {
                SetCommonAttributes(activity, Keys.OperationNameRecv);

                if (!string.IsNullOrEmpty(_model))
                    activity.SetTag(Keys.GenAiRequestModel, _model);
                if (!string.IsNullOrEmpty(_sessionId))
                    activity.SetTag(Keys.GenAiVoiceSessionId, _sessionId);
                activity.SetTag(Keys.GenAiVoiceEventType, eventType);
            }

            return activity;
        }

        // ─── Send-side enrichment ────────────────────────────────────────────────────

        /// <summary>
        /// Enriches a send span for a session.update command with session configuration attributes.
        /// </summary>
        public void EnrichSendSessionUpdate(Activity activity, JsonElement root)
        {
            if (activity?.IsAllDataRequested != true)
                return;

            if (root.TryGetProperty("session", out var session))
            {
                if (session.TryGetProperty("temperature", out var temp) && temp.ValueKind == JsonValueKind.Number)
                    activity.SetTag(Keys.GenAiRequestTemperature, temp.GetDouble());

                if (session.TryGetProperty("max_response_output_tokens", out var maxTokens) && maxTokens.ValueKind == JsonValueKind.Number)
                    activity.SetTag(Keys.GenAiRequestMaxOutputTokens, maxTokens.GetInt32());

                if (_enableContentRecording)
                {
                    if (session.TryGetProperty("instructions", out var instructions) && instructions.ValueKind == JsonValueKind.String)
                        activity.SetTag(Keys.GenAiSystemMessage, instructions.GetString());

                    if (session.TryGetProperty("tools", out var tools) && tools.ValueKind != JsonValueKind.Null)
                        activity.SetTag(Keys.GenAiRequestTools, tools.GetRawText());
                }
            }
        }

        /// <summary>Records the timestamp at which response.create was sent, for first-token latency tracking.</summary>
        public void OnSendResponseCreate()
        {
            Interlocked.Exchange(ref _responseCreateTimestamp, Stopwatch.GetTimestamp());
            Interlocked.Exchange(ref _firstTokenLatencyRecorded, 0);
        }

        /// <summary>Called when response.cancel is sent; increments the session interruption counter.</summary>
        public void OnSendResponseCancel()
        {
            Interlocked.Increment(ref _interruptionCount);
        }

        /// <summary>Called for audio-data send commands; tracks approximate audio bytes sent.</summary>
        public void OnSendAudioData(long byteCount)
        {
            if (byteCount > 0)
                Interlocked.Add(ref _audioBytesSent, byteCount);
        }

        /// <summary>
        /// Adds a gen_ai.input.messages event to the send activity. Always emits gen_ai.system and
        /// gen_ai.voice.event_type; conditionally adds gen_ai.event.content when content recording is on.
        /// Only call for non-audio commands (audio content would be excessively large).
        /// </summary>
        public void AddSendContentEvent(Activity activity, string eventType, string jsonContent)
        {
            if (activity?.IsAllDataRequested != true)
                return;

            var tags = new ActivityTagsCollection
            {
                { Keys.GenAiSystem, Keys.GenAiSystemValue },
                { Keys.GenAiVoiceEventType, eventType }
            };
            if (_enableContentRecording && !string.IsNullOrEmpty(jsonContent))
                tags.Add(Keys.GenAiEventContent, jsonContent);
            activity.AddEvent(new ActivityEvent("gen_ai.input.messages", tags: tags));
        }

        /// <summary>
        /// Adds a gen_ai.output.messages event to the recv activity. Always emits gen_ai.system and
        /// gen_ai.voice.event_type; conditionally adds gen_ai.event.content when content recording is on.
        /// </summary>
        public void AddRecvContentEvent(Activity activity, string eventType, string jsonContent)
        {
            if (activity?.IsAllDataRequested != true)
                return;

            var tags = new ActivityTagsCollection
            {
                { Keys.GenAiSystem, Keys.GenAiSystemValue },
                { Keys.GenAiVoiceEventType, eventType }
            };
            if (_enableContentRecording && !string.IsNullOrEmpty(jsonContent))
                tags.Add(Keys.GenAiEventContent, jsonContent);
            activity.AddEvent(new ActivityEvent("gen_ai.output.messages", tags: tags));
        }

        // ─── Recv-side enrichment ────────────────────────────────────────────────────

        /// <summary>
        /// Enriches a recv activity for a session.created or session.updated event.
        /// Also propagates the session ID back to the connect activity.
        /// </summary>
        public void EnrichRecvSessionEvent(Activity activity, JsonElement root)
        {
            if (root.TryGetProperty("session", out var session))
            {
                if (session.TryGetProperty("id", out var sessionId) && sessionId.ValueKind == JsonValueKind.String)
                {
                    _sessionId = sessionId.GetString();
                    // Back-fill session ID on the connect span now that we know it
                    Activity connectActivity = _connectActivity;
                    if (connectActivity?.IsAllDataRequested == true)
                        connectActivity.SetTag(Keys.GenAiVoiceSessionId, _sessionId);
                }

                if (activity?.IsAllDataRequested == true)
                {
                    if (!string.IsNullOrEmpty(_sessionId))
                        activity.SetTag(Keys.GenAiVoiceSessionId, _sessionId);

                    if (session.TryGetProperty("model", out var model) && model.ValueKind == JsonValueKind.String)
                        activity.SetTag(Keys.GenAiResponseModel, model.GetString());

                    if (session.TryGetProperty("input_audio_format", out var inputFmt) && inputFmt.ValueKind == JsonValueKind.String)
                        activity.SetTag(Keys.GenAiVoiceInputAudioFormat, inputFmt.GetString());

                    if (session.TryGetProperty("output_audio_format", out var outputFmt) && outputFmt.ValueKind == JsonValueKind.String)
                        activity.SetTag(Keys.GenAiVoiceOutputAudioFormat, outputFmt.GetString());

                    if (session.TryGetProperty("input_audio_sample_rate", out var inputRate) && inputRate.ValueKind == JsonValueKind.Number)
                        activity.SetTag(Keys.GenAiVoiceInputSampleRate, inputRate.GetInt32());

                    if (session.TryGetProperty("output_audio_sample_rate", out var outputRate) && outputRate.ValueKind == JsonValueKind.Number)
                        activity.SetTag(Keys.GenAiVoiceOutputSampleRate, outputRate.GetInt32());
                }
            }
        }

        /// <summary>
        /// Enriches a recv activity for a response.done event with token usage, finish reason, and response ID.
        /// </summary>
        public void EnrichRecvResponseDone(Activity activity, JsonElement root)
        {
            if (activity?.IsAllDataRequested != true)
                return;

            if (!root.TryGetProperty("response", out var response))
                return;

            if (response.TryGetProperty("id", out var id) && id.ValueKind == JsonValueKind.String)
                activity.SetTag(Keys.GenAiResponseId, id.GetString());

            if (response.TryGetProperty("status", out var status) && status.ValueKind == JsonValueKind.String)
                activity.SetTag(Keys.GenAiResponseFinishReasons, status.GetString());

            if (response.TryGetProperty("usage", out var usage))
            {
                if (usage.TryGetProperty("input_tokens", out var inputTokens) && inputTokens.ValueKind == JsonValueKind.Number)
                    activity.SetTag(Keys.GenAiUsageInputTokens, inputTokens.GetInt32());
                if (usage.TryGetProperty("output_tokens", out var outputTokens) && outputTokens.ValueKind == JsonValueKind.Number)
                    activity.SetTag(Keys.GenAiUsageOutputTokens, outputTokens.GetInt32());
            }

            var eventTags = new ActivityTagsCollection
            {
                { Keys.GenAiSystem, Keys.GenAiSystemValue },
                { Keys.GenAiVoiceEventType, "response.done" }
            };
            if (_enableContentRecording)
            {
                string content = ExtractResponseDoneContent(response);
                if (!string.IsNullOrEmpty(content))
                    eventTags.Add(Keys.GenAiEventContent, content);
            }
            activity.AddEvent(new ActivityEvent("gen_ai.output.messages", tags: eventTags));
        }

        /// <summary>
        /// Attempts to record first-token latency on the first response.audio.delta event.
        /// Returns the latency in milliseconds if recorded, null if already recorded for this response.
        /// </summary>
        public double? TryRecordFirstTokenLatency()
        {
            if (Interlocked.CompareExchange(ref _firstTokenLatencyRecorded, 1, 0) == 0)
            {
                long createTs = Interlocked.Read(ref _responseCreateTimestamp);
                if (createTs > 0)
                    return (double)(Stopwatch.GetTimestamp() - createTs) / Stopwatch.Frequency * 1000.0;
            }
            return null;
        }

        /// <summary>Called on response.audio.delta; tracks approximate audio bytes received.</summary>
        public void OnRecvAudioDelta(JsonElement root)
        {
            if (root.TryGetProperty("delta", out var delta) && delta.ValueKind == JsonValueKind.String)
            {
                string b64 = delta.GetString();
                if (b64 != null)
                {
                    // Approximate decoded byte count from base64 length
                    long bytes = (long)(b64.Length * 3L / 4);
                    Interlocked.Add(ref _audioBytesReceived, bytes);
                }
            }
        }

        /// <summary>Called when input_audio_buffer.speech_started is received; increments the turn counter.</summary>
        public void OnRecvSpeechStarted()
        {
            Interlocked.Increment(ref _turnCount);
        }

        /// <summary>Called when an MCP list-tools operation completes or fails.</summary>
        public void OnRecvMcpListToolsDone()
        {
            Interlocked.Increment(ref _mcpListToolsCount);
        }

        /// <summary>Called when an MCP call operation completes or fails.</summary>
        public void OnRecvMcpCallDone()
        {
            Interlocked.Increment(ref _mcpCallCount);
        }

        /// <summary>Enriches an activity with MCP server/tool attributes.</summary>
        public void EnrichRecvMcpEvent(Activity activity, JsonElement root)
        {
            if (activity?.IsAllDataRequested != true)
                return;

            if (root.TryGetProperty("server_label", out var serverLabel) && serverLabel.ValueKind == JsonValueKind.String)
                activity.SetTag(Keys.GenAiVoiceMcpServerLabel, serverLabel.GetString());

            if (root.TryGetProperty("tool_name", out var toolName) && toolName.ValueKind == JsonValueKind.String)
                activity.SetTag(Keys.GenAiVoiceMcpToolName, toolName.GetString());
        }

        /// <summary>Enriches an activity with item ID / output index from item-bearing events.</summary>
        public void EnrichWithItemIds(Activity activity, JsonElement root)
        {
            if (activity?.IsAllDataRequested != true)
                return;

            // item ID may appear as root.item.id or root.item_id
            if (root.TryGetProperty("item", out var item))
            {
                if (item.TryGetProperty("id", out var itemId) && itemId.ValueKind == JsonValueKind.String)
                    activity.SetTag(Keys.GenAiVoiceItemId, itemId.GetString());
            }
            else if (root.TryGetProperty("item_id", out var itemIdDirect) && itemIdDirect.ValueKind == JsonValueKind.String)
            {
                activity.SetTag(Keys.GenAiVoiceItemId, itemIdDirect.GetString());
            }

            if (root.TryGetProperty("output_index", out var outputIndex) && outputIndex.ValueKind == JsonValueKind.Number)
                activity.SetTag(Keys.GenAiVoiceOutputIndex, outputIndex.GetInt32());
        }

        // ─── Error recording ─────────────────────────────────────────────────────────

        /// <summary>Marks an Activity as errored. Safe to call with a null activity.</summary>
        public static void RecordError(Activity activity, Exception error)
        {
            if (activity == null || error == null)
                return;

            activity.SetStatus(ActivityStatusCode.Error, error.Message);
            activity.SetTag(Keys.ErrorType, error.GetType().FullName);
            activity.SetTag(Keys.ErrorMessage, error.Message);
        }

        // ─── Helpers ─────────────────────────────────────────────────────────────────

        private void SetCommonAttributes(Activity activity, string operationName)
        {
            activity.SetTag(Keys.AzNamespace, Keys.AzNamespaceValue);
            activity.SetTag(Keys.GenAiProviderName, Keys.GenAiProviderValue);
            activity.SetTag(Keys.GenAiSystem, Keys.GenAiSystemValue);
            activity.SetTag(Keys.GenAiOperationName, operationName);

            if (!string.IsNullOrEmpty(_serverAddress))
                activity.SetTag(Keys.ServerAddress, _serverAddress);
            if (_serverPort > 0)
                activity.SetTag(Keys.ServerPort, _serverPort);
        }

        private static string ExtractResponseDoneContent(JsonElement response)
        {
            if (!response.TryGetProperty("output", out var output) || output.ValueKind != JsonValueKind.Array)
                return null;

            var sb = new System.Text.StringBuilder();
            foreach (var item in output.EnumerateArray())
            {
                if (item.TryGetProperty("type", out var type) && type.ValueKind == JsonValueKind.String
                    && type.GetString() == "function_call")
                {
                    if (item.TryGetProperty("arguments", out var args) && args.ValueKind == JsonValueKind.String)
                        sb.Append(args.GetString());
                    continue;
                }

                if (item.TryGetProperty("content", out var content) && content.ValueKind == JsonValueKind.Array)
                {
                    foreach (var part in content.EnumerateArray())
                    {
                        if (part.TryGetProperty("text", out var text) && text.ValueKind == JsonValueKind.String)
                            sb.Append(text.GetString());
                        else if (part.TryGetProperty("transcript", out var transcript) && transcript.ValueKind == JsonValueKind.String)
                            sb.Append(transcript.GetString());
                    }
                }
            }

            string result = sb.ToString();
            return string.IsNullOrEmpty(result) ? null : result;
        }

        private static bool DetermineContentRecordingFromEnvironment()
        {
            // OTel standard env var (preferred)
            string otelVar = Environment.GetEnvironmentVariable("OTEL_INSTRUMENTATION_GENAI_CAPTURE_MESSAGE_CONTENT");
            if (!string.IsNullOrEmpty(otelVar))
                return string.Equals(otelVar, "true", StringComparison.OrdinalIgnoreCase);

            // Azure legacy env var
            string azureVar = Environment.GetEnvironmentVariable("AZURE_TRACING_GEN_AI_CONTENT_RECORDING_ENABLED");
            if (!string.IsNullOrEmpty(azureVar))
                return string.Equals(azureVar, "true", StringComparison.OrdinalIgnoreCase);

            return false;
        }
    }
}
