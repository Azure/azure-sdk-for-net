// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Diagnostics.Metrics;
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
        // Conversation ID back-filled from response.done (response.conversation_id)
        private string _conversationId;

        // --- Session-level counters (Interlocked for concurrent send/recv tasks) ---
        private long _turnCount;
        private long _interruptionCount;
        private long _audioBytesSent;
        private long _audioBytesReceived;
        private long _mcpCallCount;
        private long _mcpListToolsCount;

        // --- Accumulated token counts (for metrics; updated on each response.done) ---
        private long _totalInputTokens;
        private long _totalOutputTokens;

        // --- Session duration (for metrics) ---
        private Stopwatch _sessionStopwatch;

        // --- First-token latency tracking ---
        // Timestamp (Stopwatch.GetTimestamp()) recorded when response.create is sent.
        private long _responseCreateTimestamp;
        // 0 = not yet recorded for this response cycle, 1 = already recorded.
        private int _firstTokenLatencyRecorded;
        // Latency value in ms; -1.0 = not yet recorded. Written once under the CAS gate above.
        private double _firstTokenLatencyMs = -1.0;

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
            _sessionStopwatch = Stopwatch.StartNew();

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
            _sessionStopwatch?.Stop();
            double sessionDurationSeconds = _sessionStopwatch?.Elapsed.TotalSeconds ?? 0;

            Activity activity = Interlocked.Exchange(ref _connectActivity, null);
            if (activity == null)
            {
                // Still record metrics even if no activity (metrics don't require tracing to be active)
                RecordSessionMetrics(sessionDurationSeconds, error, errorFromActivity: false);
                return;
            }

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
                if (_firstTokenLatencyMs >= 0) activity.SetTag(Keys.GenAiVoiceFirstTokenLatencyMs, _firstTokenLatencyMs);

                if (error != null)
                {
                    activity.SetStatus(ActivityStatusCode.Error, error.Message);
                    activity.SetTag(Keys.ErrorType, error.GetType().FullName);
                    activity.SetTag(Keys.ErrorMessage, error.Message);
                }
            }

            activity.Stop();
            RecordSessionMetrics(sessionDurationSeconds, error, errorFromActivity: true);
        }

        private void RecordSessionMetrics(double durationSeconds, Exception error, bool errorFromActivity)
        {
            TagList tags = BuildCommonMetricTags();
            if (error != null)
                tags.Add(Keys.ErrorType, error.GetType().FullName);

            VoiceLiveMeter.OperationDuration.Record(durationSeconds, tags);

            long inputTokens = Interlocked.Read(ref _totalInputTokens);
            long outputTokens = Interlocked.Read(ref _totalOutputTokens);

            if (inputTokens > 0)
            {
                TagList inputTags = tags;
                inputTags.Add(Keys.GenAiTokenType, "input");
                VoiceLiveMeter.TokenUsage.Record(inputTokens, inputTags);
            }
            if (outputTokens > 0)
            {
                TagList outputTags = tags;
                outputTags.Add(Keys.GenAiTokenType, "output");
                VoiceLiveMeter.TokenUsage.Record(outputTokens, outputTags);
            }
        }

        private TagList BuildCommonMetricTags()
        {
            var tags = new TagList
            {
                { Keys.GenAiSystem, Keys.GenAiSystemValue },
                { Keys.GenAiProviderName, Keys.GenAiProviderValue },
                { Keys.GenAiOperationName, Keys.OperationNameConnect },
                { Keys.ServerAddress, _serverAddress },
            };
            if (_serverPort > 0 && _serverPort != 443)
                tags.Add(Keys.ServerPort, _serverPort);
            if (!string.IsNullOrEmpty(_model))
                tags.Add(Keys.GenAiRequestModel, _model);
            return tags;
        }

        // ─── Close span (session teardown) ──────────────────────────────────────────

        /// <summary>
        /// Starts a child "close" Activity parented to the connect Activity.
        /// Returns null if no listeners are registered or the connect span does not exist.
        /// The caller MUST call activity.Stop() (or use in a try/finally block).
        /// </summary>
        public Activity StartCloseActivity()
        {
            if (_connectActivity == null || !ActivitySource.HasListeners())
                return null;

            var activity = ActivitySource.StartActivity(
                Keys.OperationNameClose,
                ActivityKind.Client,
                parentContext: _connectActivity.Context);

            if (activity?.IsAllDataRequested == true)
                SetCommonAttributes(activity, Keys.OperationNameClose);

            return activity;
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
                if (!string.IsNullOrEmpty(_conversationId))
                    activity.SetTag(Keys.GenAiConversationId, _conversationId);
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
                if (!string.IsNullOrEmpty(_conversationId))
                    activity.SetTag(Keys.GenAiConversationId, _conversationId);
                activity.SetTag(Keys.GenAiVoiceEventType, eventType);
            }

            return activity;
        }

        // ─── Send-side enrichment ────────────────────────────────────────────────────

        /// <summary>
        /// Enriches the root connect Activity with session configuration from a session.update command.
        /// Temperature, max_output_tokens, instructions, tools, and audio formats are session-level
        /// attributes that belong on the connect span, not the transient send span.
        /// </summary>
        public void EnrichSendSessionUpdate(Activity sendActivity, JsonElement root)
        {
            Activity connectActivity = _connectActivity;

            if (root.TryGetProperty("session", out var session))
            {
                if (connectActivity?.IsAllDataRequested == true)
                {
                    if (session.TryGetProperty("temperature", out var temp) && temp.ValueKind == JsonValueKind.Number)
                        connectActivity.SetTag(Keys.GenAiRequestTemperature, temp.GetDouble());

                    if (session.TryGetProperty("max_response_output_tokens", out var maxTokens) && maxTokens.ValueKind == JsonValueKind.Number)
                        connectActivity.SetTag(Keys.GenAiRequestMaxOutputTokens, maxTokens.GetInt32());

                    // Attributes are always set when present; only the span event is content-recording gated.
                    if (session.TryGetProperty("instructions", out var instructions) && instructions.ValueKind == JsonValueKind.String)
                    {
                        string instructionsText = instructions.GetString();
                        connectActivity.SetTag(Keys.GenAiSystemMessage, instructionsText);
                        EmitSystemInstructionsEvent(instructionsText);
                    }

                    if (session.TryGetProperty("tools", out var tools) && tools.ValueKind != JsonValueKind.Null)
                        connectActivity.SetTag(Keys.GenAiRequestTools, tools.GetRawText());

                    if (session.TryGetProperty("input_audio_format", out var inputFmt) && inputFmt.ValueKind == JsonValueKind.String)
                        connectActivity.SetTag(Keys.GenAiVoiceInputAudioFormat, inputFmt.GetString());

                    if (session.TryGetProperty("output_audio_format", out var outputFmt) && outputFmt.ValueKind == JsonValueKind.String)
                        connectActivity.SetTag(Keys.GenAiVoiceOutputAudioFormat, outputFmt.GetString());

                    if (session.TryGetProperty("input_audio_sample_rate", out var inputRate) && inputRate.ValueKind == JsonValueKind.Number)
                        connectActivity.SetTag(Keys.GenAiVoiceInputSampleRate, inputRate.GetInt32());

                    if (session.TryGetProperty("output_audio_sample_rate", out var outputRate) && outputRate.ValueKind == JsonValueKind.Number)
                        connectActivity.SetTag(Keys.GenAiVoiceOutputSampleRate, outputRate.GetInt32());
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

        /// <summary>Called for audio-data send commands; tracks approximate base64-decoded bytes sent.</summary>
        public void OnSendAudioData(JsonElement root)
        {
            // audio field name differs between event types:
            //   input_audio_buffer.append  → "audio"
            //   input_audio_buffer.turn_append → "audio"
            if (root.TryGetProperty("audio", out var audio) && audio.ValueKind == JsonValueKind.String)
            {
                string b64 = audio.GetString();
                if (b64 != null)
                {
                    long bytes = (long)(b64.Length * 3L / 4);
                    if (bytes > 0)
                        Interlocked.Add(ref _audioBytesSent, bytes);
                }
            }
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
        /// Adds a gen_ai.output.messages event to the recv activity.
        /// Always emits gen_ai.system and gen_ai.voice.event_type.
        /// When <paramref name="forceContent"/> is non-null, includes it unconditionally (structured
        /// content from done events is always useful regardless of the content recording flag).
        /// Otherwise falls back to raw <paramref name="jsonContent"/> gated by the content recording flag.
        /// </summary>
        public void AddRecvContentEvent(Activity activity, string eventType, string jsonContent, string forceContent = null)
        {
            if (activity?.IsAllDataRequested != true)
                return;

            var tags = new ActivityTagsCollection
            {
                { Keys.GenAiSystem, Keys.GenAiSystemValue },
                { Keys.GenAiVoiceEventType, eventType }
            };
            if (forceContent != null)
                tags.Add(Keys.GenAiEventContent, forceContent);
            else if (_enableContentRecording && !string.IsNullOrEmpty(jsonContent))
                tags.Add(Keys.GenAiEventContent, jsonContent);
            activity.AddEvent(new ActivityEvent("gen_ai.output.messages", tags: tags));
        }

        /// <summary>
        /// Extracts structured content from "done" recv events, matching the Python SDK convention.
        /// Returns a compact JSON object appropriate for the event type, or null for non-done events.
        /// The returned content is emitted unconditionally (force_content) — done events always carry
        /// useful structured metadata regardless of the content recording flag.
        /// </summary>
        public static string ExtractDoneEventContent(string eventType, JsonElement root)
        {
            switch (eventType)
            {
                case "response.text.done":
                    if (root.TryGetProperty("text", out var text) && text.ValueKind == JsonValueKind.String)
                        return "{\"text\":" + JsonSerializer.Serialize(text.GetString()) + "}";
                    break;

                case "response.audio_transcript.done":
                    if (root.TryGetProperty("transcript", out var transcript) && transcript.ValueKind == JsonValueKind.String)
                        return "{\"transcript\":" + JsonSerializer.Serialize(transcript.GetString()) + "}";
                    break;

                case "response.function_call_arguments.done":
                    if (root.TryGetProperty("name", out var fnName) && fnName.ValueKind == JsonValueKind.String
                        && root.TryGetProperty("arguments", out var args))
                        return "{\"name\":" + JsonSerializer.Serialize(fnName.GetString()) + ",\"arguments\":" + args.GetRawText() + "}";
                    break;

                case "response.content_part.done":
                    if (root.TryGetProperty("part", out var part))
                    {
                        bool hasText = part.TryGetProperty("text", out var pText) && pText.ValueKind == JsonValueKind.String;
                        bool hasTrans = part.TryGetProperty("transcript", out var pTrans) && pTrans.ValueKind == JsonValueKind.String;
                        if (hasText && hasTrans)
                            return "{\"text\":" + JsonSerializer.Serialize(pText.GetString()) + ",\"transcript\":" + JsonSerializer.Serialize(pTrans.GetString()) + "}";
                        if (hasText)
                            return "{\"text\":" + JsonSerializer.Serialize(pText.GetString()) + "}";
                        if (hasTrans)
                            return "{\"transcript\":" + JsonSerializer.Serialize(pTrans.GetString()) + "}";
                    }
                    break;

                case "response.output_item.done":
                    if (root.TryGetProperty("item", out var item))
                        return "{\"messages\":[" + item.GetRawText() + "]}";
                    break;

                case "response.done":
                    if (root.TryGetProperty("response", out var response)
                        && response.TryGetProperty("output", out var output)
                        && output.ValueKind == JsonValueKind.Array)
                        return "{\"messages\":" + output.GetRawText() + "}";
                    break;
            }

            return null;
        }

        /// <summary>
        /// Emits a gen_ai.system.instructions span event on the connect Activity.
        /// Only emitted when content recording is enabled. The event content is a JSON array
        /// with a single system-role message, matching the Python SDK convention.
        /// </summary>
        private void EmitSystemInstructionsEvent(string instructions)
        {
            if (!_enableContentRecording || string.IsNullOrEmpty(instructions))
                return;

            Activity connectActivity = _connectActivity;
            if (connectActivity?.IsAllDataRequested != true)
                return;

            string content = "[{\"role\":\"system\",\"content\":" + JsonSerializer.Serialize(instructions) + "}]";
            var tags = new ActivityTagsCollection
            {
                { Keys.GenAiProviderName, Keys.GenAiProviderValue },
                { Keys.GenAiEventContent, content }
            };
            connectActivity.AddEvent(new ActivityEvent(Keys.SystemInstructionEventName, tags: tags));
        }

        // ─── Recv-side enrichment ────────────────────────────────────────────────────

        /// <summary>
        /// Enriches the root connect Activity from a session.created or session.updated recv event.
        /// Back-fills session ID, agent ID/thread ID, and audio formats onto the connect span.
        /// The recv activity itself only gets session_id for correlation.
        /// </summary>
        public void EnrichRecvSessionEvent(Activity activity, JsonElement root)
        {
            if (!root.TryGetProperty("session", out var session))
                return;

            Activity connectActivity = _connectActivity;

            if (session.TryGetProperty("id", out var sessionId) && sessionId.ValueKind == JsonValueKind.String)
            {
                _sessionId = sessionId.GetString();
                if (connectActivity?.IsAllDataRequested == true)
                    connectActivity.SetTag(Keys.GenAiVoiceSessionId, _sessionId);
                if (activity?.IsAllDataRequested == true)
                    activity.SetTag(Keys.GenAiVoiceSessionId, _sessionId);
            }

            if (connectActivity?.IsAllDataRequested == true)
            {
                // Agent ID and thread ID are only present for agent sessions (Agent v2 / MCP).
                if (session.TryGetProperty("agent", out var agent))
                {
                    if (agent.TryGetProperty("agent_id", out var agentId) && agentId.ValueKind == JsonValueKind.String)
                        connectActivity.SetTag(Keys.GenAiAgentId, agentId.GetString());

                    if (agent.TryGetProperty("thread_id", out var threadId) && threadId.ValueKind == JsonValueKind.String)
                        connectActivity.SetTag(Keys.GenAiAgentThreadId, threadId.GetString());

                    // Fallback: use server-confirmed name if not already set from URL query params.
                    if (agent.TryGetProperty("name", out var aName) && aName.ValueKind == JsonValueKind.String
                        && string.IsNullOrEmpty(_agentName))
                        connectActivity.SetTag(Keys.GenAiAgentName, aName.GetString());
                }

                // Audio formats on the connect span (authoritative server-confirmed values).
                if (session.TryGetProperty("input_audio_format", out var inputFmt) && inputFmt.ValueKind == JsonValueKind.String)
                    connectActivity.SetTag(Keys.GenAiVoiceInputAudioFormat, inputFmt.GetString());

                if (session.TryGetProperty("output_audio_format", out var outputFmt) && outputFmt.ValueKind == JsonValueKind.String)
                    connectActivity.SetTag(Keys.GenAiVoiceOutputAudioFormat, outputFmt.GetString());

                if (session.TryGetProperty("input_audio_sample_rate", out var inputRate) && inputRate.ValueKind == JsonValueKind.Number)
                    connectActivity.SetTag(Keys.GenAiVoiceInputSampleRate, inputRate.GetInt32());

                if (session.TryGetProperty("output_audio_sample_rate", out var outputRate) && outputRate.ValueKind == JsonValueKind.Number)
                    connectActivity.SetTag(Keys.GenAiVoiceOutputSampleRate, outputRate.GetInt32());
            }
        }

        /// <summary>
        /// Enriches a recv activity for a response.done event with token usage, finish reason, and response ID.
        /// Also back-fills the finish reason to the connect span so the session-level status is visible.
        /// </summary>
        public void EnrichRecvResponseDone(Activity activity, JsonElement root)
        {
            if (!root.TryGetProperty("response", out var response))
                return;

            string finishReason = null;
            if (response.TryGetProperty("status", out var status) && status.ValueKind == JsonValueKind.String)
                finishReason = status.GetString();

            if (activity?.IsAllDataRequested == true)
            {
                if (response.TryGetProperty("id", out var id) && id.ValueKind == JsonValueKind.String)
                    activity.SetTag(Keys.GenAiResponseId, id.GetString());

                if (finishReason != null)
                    activity.SetTag(Keys.GenAiResponseFinishReasons, finishReason);
            }

            // Accumulate token counts for session-level metrics (runs regardless of tracing).
            if (response.TryGetProperty("usage", out var usage))
            {
                if (usage.TryGetProperty("input_tokens", out var inputTokens) && inputTokens.ValueKind == JsonValueKind.Number)
                {
                    if (activity?.IsAllDataRequested == true)
                        activity.SetTag(Keys.GenAiUsageInputTokens, inputTokens.GetInt32());
                    Interlocked.Add(ref _totalInputTokens, inputTokens.GetInt64());
                }
                if (usage.TryGetProperty("output_tokens", out var outputTokens) && outputTokens.ValueKind == JsonValueKind.Number)
                {
                    if (activity?.IsAllDataRequested == true)
                        activity.SetTag(Keys.GenAiUsageOutputTokens, outputTokens.GetInt32());
                    Interlocked.Add(ref _totalOutputTokens, outputTokens.GetInt64());
                }
            }

            // Back-fill finish reason to connect span (last response.done wins)
            if (finishReason != null)
            {
                Activity connectActivity = _connectActivity;
                if (connectActivity?.IsAllDataRequested == true)
                    connectActivity.SetTag(Keys.GenAiResponseFinishReasons, finishReason);
            }
        }

        /// <summary>
        /// Attempts to record first-token latency on the first response.audio.delta event.
        /// Returns the latency in milliseconds if recorded, null if already recorded for this response.
        /// Also stores the value for flushing to the connect span at session close.
        /// </summary>
        public double? TryRecordFirstTokenLatency()
        {
            if (Interlocked.CompareExchange(ref _firstTokenLatencyRecorded, 1, 0) == 0)
            {
                long createTs = Interlocked.Read(ref _responseCreateTimestamp);
                if (createTs > 0)
                {
                    double latency = (double)(Stopwatch.GetTimestamp() - createTs) / Stopwatch.Frequency * 1000.0;
                    _firstTokenLatencyMs = latency;
                    return latency;
                }
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
            // speech_started no longer increments turn_count; turns are counted on response.done.
        }

        /// <summary>Called when response.done is received; increments the completed-turn counter.</summary>
        public void OnRecvResponseDone()
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

        /// <summary>
        /// Enriches a recv activity for a server error event. Sets error status and adds a
        /// gen_ai.voice.error span event carrying the server-reported error code and message.
        /// </summary>
        public void EnrichRecvErrorEvent(Activity activity, JsonElement root)
        {
            string code = null;
            string message = null;

            if (root.TryGetProperty("error", out var error))
            {
                if (error.TryGetProperty("code", out var c) && c.ValueKind == JsonValueKind.String)
                    code = c.GetString();
                if (error.TryGetProperty("message", out var m) && m.ValueKind == JsonValueKind.String)
                    message = m.GetString();
            }

            if (activity?.IsAllDataRequested == true)
            {
                activity.SetStatus(ActivityStatusCode.Error, message ?? code ?? "server error");

                var tags = new ActivityTagsCollection();
                if (!string.IsNullOrEmpty(code))
                    tags.Add(Keys.GenAiVoiceErrorCode, code);
                if (!string.IsNullOrEmpty(message))
                    tags.Add(Keys.ErrorMessage, message);
                activity.AddEvent(new ActivityEvent(Keys.VoiceErrorEventName, tags: tags));
            }
        }

        /// <summary>
        /// Adds a gen_ai.voice.rate_limits.updated span event to the recv activity.
        /// The rate limits JSON payload is included when content recording is enabled.
        /// </summary>
        public void AddRateLimitsEvent(Activity activity, JsonElement root)
        {
            if (activity?.IsAllDataRequested != true)
                return;

            var tags = new ActivityTagsCollection();
            if (_enableContentRecording && root.TryGetProperty("rate_limits", out var rateLimits))
                tags.Add(Keys.GenAiEventContent, rateLimits.GetRawText());

            activity.AddEvent(new ActivityEvent(Keys.VoiceRateLimitsEventName, tags: tags));
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

        private static readonly System.Collections.Generic.HashSet<string> s_itemBearingEvents =
            new System.Collections.Generic.HashSet<string>(System.StringComparer.Ordinal)
            {
                "conversation.item.created",
                "conversation.item.retrieved",
                "response.output_item.added",
                "response.output_item.done",
            };

        /// <summary>
        /// Extracts ID fields from any recv event and sets them on the span.
        /// Also back-fills conversation_id onto the connect span on first observation.
        /// </summary>
        public void ExtractRecvIds(Activity activity, JsonElement root, string eventType)
        {
            if (activity?.IsAllDataRequested != true)
                return;

            // Top-level IDs
            if (root.TryGetProperty("response_id", out var topResponseId) && topResponseId.ValueKind == JsonValueKind.String)
                activity.SetTag(Keys.GenAiResponseId, topResponseId.GetString());

            if (root.TryGetProperty("call_id", out var topCallId) && topCallId.ValueKind == JsonValueKind.String)
                activity.SetTag(Keys.GenAiVoiceCallId, topCallId.GetString());

            if (root.TryGetProperty("previous_item_id", out var prevItemId) && prevItemId.ValueKind == JsonValueKind.String)
                activity.SetTag(Keys.GenAiVoicePreviousItemId, prevItemId.GetString());

            if (root.TryGetProperty("output_index", out var outputIdx) && outputIdx.ValueKind == JsonValueKind.Number)
                activity.SetTag(Keys.GenAiVoiceOutputIndex, outputIdx.GetInt32());

            // Nested response object — overrides top-level response_id when present
            if (root.TryGetProperty("response", out var response))
            {
                if (response.TryGetProperty("id", out var responseId) && responseId.ValueKind == JsonValueKind.String)
                    activity.SetTag(Keys.GenAiResponseId, responseId.GetString());

                if (response.TryGetProperty("conversation_id", out var convId) && convId.ValueKind == JsonValueKind.String)
                {
                    string conversationId = convId.GetString();
                    activity.SetTag(Keys.GenAiConversationId, conversationId);
                    SetConversationId(conversationId);
                }
            }

            // Nested item fields — only for item-bearing events
            if (s_itemBearingEvents.Contains(eventType))
            {
                if (root.TryGetProperty("item", out var item))
                {
                    if (item.TryGetProperty("id", out var itemId) && itemId.ValueKind == JsonValueKind.String)
                        activity.SetTag(Keys.GenAiVoiceItemId, itemId.GetString());

                    if (item.TryGetProperty("call_id", out var callId) && callId.ValueKind == JsonValueKind.String)
                        activity.SetTag(Keys.GenAiVoiceCallId, callId.GetString());

                    if (item.TryGetProperty("server_label", out var serverLabel) && serverLabel.ValueKind == JsonValueKind.String)
                        activity.SetTag(Keys.GenAiVoiceMcpServerLabel, serverLabel.GetString());

                    if (item.TryGetProperty("name", out var toolName) && toolName.ValueKind == JsonValueKind.String)
                        activity.SetTag(Keys.GenAiVoiceMcpToolName, toolName.GetString());

                    if (item.TryGetProperty("approval_request_id", out var approvalId) && approvalId.ValueKind == JsonValueKind.String)
                        activity.SetTag(Keys.GenAiVoiceMcpApprovalRequestId, approvalId.GetString());

                    if (item.TryGetProperty("approve", out var approve))
                        activity.SetTag(Keys.GenAiVoiceMcpApprove, approve.ValueKind == JsonValueKind.True);
                }
                else if (root.TryGetProperty("item_id", out var itemIdDirect) && itemIdDirect.ValueKind == JsonValueKind.String)
                {
                    activity.SetTag(Keys.GenAiVoiceItemId, itemIdDirect.GetString());
                }
            }
        }

        /// <summary>
        /// Extracts ID fields from send events that carry IDs (response.cancel, conversation.item.create).
        /// </summary>
        public void ExtractSendIds(Activity activity, JsonElement root, string eventType)
        {
            if (activity?.IsAllDataRequested != true)
                return;

            if (eventType == "response.cancel")
            {
                if (root.TryGetProperty("response_id", out var responseId) && responseId.ValueKind == JsonValueKind.String)
                    activity.SetTag(Keys.GenAiResponseId, responseId.GetString());
                return;
            }

            if (eventType == "conversation.item.create")
            {
                if (root.TryGetProperty("previous_item_id", out var prevItemId) && prevItemId.ValueKind == JsonValueKind.String)
                    activity.SetTag(Keys.GenAiVoicePreviousItemId, prevItemId.GetString());

                if (root.TryGetProperty("item", out var item))
                {
                    if (item.TryGetProperty("call_id", out var callId) && callId.ValueKind == JsonValueKind.String)
                        activity.SetTag(Keys.GenAiVoiceCallId, callId.GetString());

                    if (item.TryGetProperty("approval_request_id", out var approvalId) && approvalId.ValueKind == JsonValueKind.String)
                        activity.SetTag(Keys.GenAiVoiceMcpApprovalRequestId, approvalId.GetString());

                    if (item.TryGetProperty("approve", out var approve))
                        activity.SetTag(Keys.GenAiVoiceMcpApprove, approve.ValueKind == JsonValueKind.True);
                }
            }
        }

        private void SetConversationId(string conversationId)
        {
            if (string.IsNullOrEmpty(conversationId) || conversationId == _conversationId)
                return;
            _conversationId = conversationId;
            Activity connectActivity = _connectActivity;
            if (connectActivity?.IsAllDataRequested == true)
                connectActivity.SetTag(Keys.GenAiConversationId, conversationId);
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
