// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.WebSockets;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Projects;

internal sealed class VoiceAgentRealtimeTelemetry
{
    internal const string SourceName = "Azure.AI.Projects.ProjectsRealtimeClient";
    internal const string Prefix = "az.ai.voice_agents.";
    private const int MaxMessageBytes = 1024 * 1024;
    private const int MaxResponses = 64;
    private const int MaxInputItems = 64;
    private const int MaxContentLength = 4096;
    private static readonly ActivitySource s_source = new(SourceName, typeof(VoiceAgentRealtimeTelemetry).Assembly.GetName().Version?.ToString());
    private readonly object _gate = new();
    private readonly Dictionary<string, ResponseActivity> _responses = new();
    private readonly Dictionary<string, InputAudio> _inputAudioItems = new();
    private readonly PendingAudio _pendingAudioCommits = new();
    private readonly PendingAudio _pendingAudioMessages = new();
    private readonly Uri _endpoint;
    private readonly string _agentName;
    private readonly bool _captureContent;
    private readonly bool _enableLogging;
    private readonly Activity _session;
    private Activity _connect;
    private MemoryStream _sendBuffer;
    private MemoryStream _receiveBuffer;
    private bool _skipSendMessage;
    private bool _skipReceiveMessage;
    private bool _ended;
    private string _model;
    private string _conversationId;
    private string _lastInput;
    private InputAudio _inputAudioBuffer;
    private long _inputSequence;
    private long _inputAudioBytes;
    private long _outputAudioBytes;
    private long _untrackedInputItems;
    private int _pendingAudioClears;
    private int _responsesFinished;
    private int _responsesUntracked;
    private int _eventsRecorded;
    private int _eventsUntracked;
    private int _pendingSends;
    private List<PendingInputEvent> _pendingInputEvents;
    private bool _pendingInputOverflow;
    private bool _pendingSendFailed;

    private VoiceAgentRealtimeTelemetry(Uri endpoint, string agentName, string transport, bool captureContent, bool enableLogging, Activity session)
    {
        _endpoint = endpoint;
        _agentName = agentName;
        _captureContent = captureContent;
        _enableLogging = enableLogging;
        _session = session;
        SetCommonTags(session);
        session.SetTag(Prefix + "connection.transport", transport);
        session.SetTag(Prefix + "connected", false);
        _connect = StartDetachedActivity("voice_agents.realtime.connect", session.Context);
        SetCommonTags(_connect);
        _connect?.SetTag(Prefix + "connection.transport", transport);
        LogConnection("connecting");
    }

    internal static VoiceAgentRealtimeTelemetry Start(Uri endpoint, string agentName, string queryString, bool enabled, bool enableLogging)
    {
        if (!enabled || !s_source.HasListeners() ||
            !AppContextSwitchHelper.GetConfigValue("Azure.Experimental.EnableGenAITracing", "AZURE_EXPERIMENTAL_ENABLE_GENAI_TRACING"))
        {
            return null;
        }

        Activity session = StartDetachedActivity("voice_agents.realtime.session", Activity.Current?.Context ?? default);
        if (session is null)
        {
            return null;
        }

        bool captureContent = AppContextSwitchHelper.GetConfigValue(
            "Azure.Experimental.TraceGenAIMessageContent", "OTEL_INSTRUMENTATION_GENAI_CAPTURE_MESSAGE_CONTENT");
        return new VoiceAgentRealtimeTelemetry(endpoint, agentName, GetTransport(queryString), captureContent, enableLogging, session);
    }

    private static string GetTransport(string queryString)
    {
        if (queryString != null)
        {
            foreach (string part in queryString.TrimStart('?').Split('&'))
            {
                int separator = part.IndexOf('=');
                if (separator >= 0 && Uri.UnescapeDataString(part.Substring(0, separator)) == "transport")
                {
                    string value = Uri.UnescapeDataString(part.Substring(separator + 1));
                    return value is "websocket" or "webrtc" ? value : "other";
                }
            }
        }
        return "websocket";
    }

    internal Activity ConnectionActivity => _connect;

    internal void AddTraceHeaders(IDictionary<string, string> headers)
    {
        if (_connect?.IdFormat != ActivityIdFormat.W3C)
        {
            return;
        }

        bool hasTraceParent = false;
        bool hasTraceState = false;
        foreach (string name in headers.Keys)
        {
            hasTraceParent |= string.Equals(name, "traceparent", StringComparison.OrdinalIgnoreCase);
            hasTraceState |= string.Equals(name, "tracestate", StringComparison.OrdinalIgnoreCase);
        }
        if (!hasTraceParent)
        {
            headers["traceparent"] = _connect.Id;
            if (!hasTraceState && !string.IsNullOrEmpty(_connect.TraceStateString))
            {
                headers["tracestate"] = _connect.TraceStateString;
            }
        }
    }

    internal void Connected()
    {
        lock (_gate)
        {
            StopDetachedActivity(_connect);
            _connect = null;
            _session.SetTag(Prefix + "connected", true);
            LogConnection("connected");
        }
    }

    internal void ConnectionFailed(Exception exception)
    {
        lock (_gate)
        {
            SetFailure(_connect, exception);
            SetFailure(_session, exception);
            AddEvent(_session, "voice_agents.connection.failed",
                new ActivityTagsCollection { { "error.type", SafeErrorType(exception) } });
            if (exception is not OperationCanceledException)
            {
                LogFailure(SafeErrorType(exception));
            }
            StopDetachedActivity(_connect);
            _connect = null;
            EndCore(null, false);
        }
    }

    internal void TransportFailed(Exception exception, bool isSend, WebSocketState socketState)
    {
        lock (_gate)
        {
            if (_ended)
            {
                return;
            }
            if (isSend)
            {
                AddEvent(_session, "voice_agents.send.failed", new ActivityTagsCollection
                {
                    { "error.type", SafeErrorType(exception) }
                });
                if (exception is not OperationCanceledException)
                {
                    LogFailure(SafeErrorType(exception));
                }
                if (socketState is WebSocketState.Aborted or WebSocketState.Closed)
                {
                    SetFailure(_session, exception);
                    EndCore(null, false);
                }
            }
            else if (exception is not OperationCanceledException)
            {
                SetFailure(_session, exception);
                AddEvent(_session, "voice_agents.receive.failed",
                    new ActivityTagsCollection { { "error.type", SafeErrorType(exception) } });
                LogFailure(SafeErrorType(exception));
                EndCore(null, false);
            }
            else
            {
                AddEvent(_session, "voice_agents.receive.cancelled");
                if (socketState is WebSocketState.Aborted or WebSocketState.Closed)
                {
                    SetFailure(_session, exception);
                    EndCore(null, false);
                }
            }
        }
    }

    internal void Close(WebSocketCloseStatus? status, bool wasClean)
    {
        lock (_gate)
        {
            EndCore(status, wasClean);
        }
    }

    internal void BeginSend()
    {
        lock (_gate)
        {
            if (!_ended)
            {
                if (_pendingSends == 0)
                {
                    _pendingInputOverflow = false;
                    _pendingSendFailed = false;
                }
                _pendingSends++;
            }
        }
    }

    internal void CompleteSend(ArraySegment<byte> bytes, bool endOfMessage, bool succeeded)
    {
        lock (_gate)
        {
            if (_ended)
            {
                return;
            }
            if (succeeded)
            {
                ObserveFrame(bytes, endOfMessage, true);
            }
            else
            {
                _pendingSendFailed = true;
                _sendBuffer?.Dispose();
                _sendBuffer = null;
                _skipSendMessage = !endOfMessage;
            }
            _pendingSends--;
            if (_pendingSends != 0)
            {
                return;
            }

            if (_pendingInputOverflow)
            {
                _inputAudioItems.Clear();
                _pendingAudioCommits.Items.Clear();
                _pendingAudioCommits.Skipped = 0;
                _pendingAudioMessages.Items.Clear();
                _pendingAudioMessages.Skipped = 0;
                _inputAudioBuffer = null;
                _pendingAudioClears = 0;
                _inputSequence++;
                _lastInput = null;
                _session.SetTag("gen_ai.input.messages", null);
            }
            else
            {
                if (!_pendingSendFailed)
                {
                    ResolvePendingInputs(0);
                }
                if (_pendingInputEvents != null)
                {
                    for (int index = 0; index < _pendingInputEvents.Count; index++)
                    {
                        ObserveInputEvent(_pendingInputEvents[index]);
                        if (!_pendingSendFailed)
                        {
                            ResolvePendingInputs(index + 1);
                        }
                    }
                }
            }
            if (_pendingSendFailed || _pendingInputOverflow)
            {
                DiscardPendingInputs();
            }
            _pendingInputEvents?.Clear();
            CompleteReadyResponses();
        }
    }

    private void ResolvePendingInputs(int observedEvents)
    {
        foreach (ResponseActivity response in _responses.Values)
        {
            if (response.PendingInput && response.PendingInputEvents == observedEvents)
            {
                response.PendingInput = false;
                response.InputSequence = _inputSequence;
                response.Activity?.SetTag("gen_ai.input.messages", _lastInput);
            }
        }
    }

    private void DiscardPendingInputs()
    {
        foreach (ResponseActivity response in _responses.Values)
        {
            if (response.PendingInput)
            {
                response.PendingInput = false;
                response.InputSequence = -1;
                response.Activity?.SetTag("gen_ai.input.messages", null);
            }
        }
    }

    private void CompleteReadyResponses()
    {
        List<string> completed = null;
        foreach (KeyValuePair<string, ResponseActivity> tracked in _responses)
        {
            if (tracked.Value.Finished && !tracked.Value.PendingInput)
            {
                (completed ??= new List<string>()).Add(tracked.Key);
            }
        }
        if (completed != null)
        {
            foreach (string id in completed)
            {
                Activity activity = _responses[id].Activity;
                _responses.Remove(id);
                StopDetachedActivity(activity);
            }
        }
    }

    internal void ObserveFrame(ArraySegment<byte> bytes, bool endOfMessage, bool isSend)
    {
        lock (_gate)
        {
            if (_ended)
            {
                return;
            }
            ref MemoryStream buffer = ref (isSend ? ref _sendBuffer : ref _receiveBuffer);
            ref bool skipMessage = ref (isSend ? ref _skipSendMessage : ref _skipReceiveMessage);
            if (skipMessage)
            {
                if (endOfMessage)
                {
                    skipMessage = false;
                }
                return;
            }
            if (bytes.Count + (buffer?.Length ?? 0) > MaxMessageBytes)
            {
                buffer?.Dispose();
                buffer = null;
                skipMessage = !endOfMessage;
                AddEvent(_session, "voice_agents.warning");
                return;
            }

            if (!endOfMessage || buffer != null)
            {
                buffer ??= new MemoryStream();
                buffer.Write(bytes.Array, bytes.Offset, bytes.Count);
                if (!endOfMessage)
                {
                    return;
                }
                ObserveMessage(new ReadOnlyMemory<byte>(buffer.GetBuffer(), 0, (int)buffer.Length), isSend);
                buffer.Dispose();
                buffer = null;
            }
            else
            {
                ObserveMessage(new ReadOnlyMemory<byte>(bytes.Array, bytes.Offset, bytes.Count), isSend);
            }
        }
    }

    private void ObserveMessage(ReadOnlyMemory<byte> bytes, bool isSend)
    {
        try
        {
            using JsonDocument document = JsonDocument.Parse(bytes);
            JsonElement root = document.RootElement;
            string type = String(root, "type");
            if (isSend)
            {
                ObserveSent(root, type);
            }
            else
            {
                ObserveReceived(root, type);
            }
        }
        catch (JsonException)
        {
            // Invalid protocol data remains the responsibility of the existing realtime reader.
            AddEvent(_session, "voice_agents.warning");
        }
        catch (FormatException)
        {
            AddEvent(_session, "voice_agents.warning");
        }
    }

    private void ObserveSent(JsonElement root, string type)
    {
        switch (type)
        {
            case "input_audio_buffer.append":
                _inputAudioBytes += AudioBytes(root, "audio");
                if (_inputAudioBuffer == null)
                {
                    _inputAudioBuffer = StartInputAudio();
                }
                else if (_inputAudioBuffer.Sequence != _inputSequence)
                {
                    _inputAudioBuffer.Sequence = ++_inputSequence;
                    SetInputAudioSummary(_inputAudioBuffer);
                }
                break;
            case "conversation.item.create":
                if (root.TryGetProperty("item", out JsonElement item) && item.ValueKind == JsonValueKind.Object)
                {
                    if (String(item, "type") == "function_call_output")
                    {
                        AddEvent(_session, "voice_agents.tool.output_sent", new ActivityTagsCollection
                        {
                            { "gen_ai.tool.call.id", Identifier(item, "call_id") }
                        });
                        _lastInput = MessageSummary("tool", "tool_call_response", _captureContent ? String(item, "output") : null,
                            Identifier(item, "call_id"));
                        _inputSequence++;
                    }
                    else
                    {
                        _lastInput = InputSummary(item);
                        long sequence = ++_inputSequence;
                        if (_lastInput != null)
                        {
                            if (String(item, "role") is not "assistant" and not "system" && HasAudioPart(item))
                            {
                                InputAudio input = new() { Sequence = sequence };
                                if (Identifier(item, "id") is string itemId)
                                {
                                    RememberInputAudio(itemId, input);
                                }
                                else
                                {
                                    EnqueueInputAudio(_pendingAudioMessages, input);
                                }
                            }
                        }
                    }
                    _session.SetTag("gen_ai.input.messages", _lastInput);
                }
                else
                {
                    AddEvent(_session, "voice_agents.warning");
                }
                break;
            case "response.cancel":
                AddEvent(_session, "voice_agents.response.cancel_requested");
                break;
            case "session.update":
                if (_captureContent && root.TryGetProperty("session", out JsonElement session) && String(session, "instructions") is string instructions)
                {
                    _session.SetTag("gen_ai.system_instructions", InstructionSummary(instructions));
                }
                AddEvent(_session, "voice_agents.session.update");
                break;
            case "input_audio_buffer.clear":
                ClearInputAudio();
                _pendingAudioClears++;
                AddEvent(_session, "input_audio_buffer.clear");
                break;
            case "input_audio_buffer.commit":
                if (_inputAudioBuffer != null)
                {
                    EnqueueInputAudio(_pendingAudioCommits, _inputAudioBuffer);
                    _inputAudioBuffer = null;
                }
                AddEvent(_session, "input_audio_buffer.commit");
                break;
        }
    }

    private void ObserveReceived(JsonElement root, string type)
    {
        if (TryObserveInputEvent(root, type))
        {
            return;
        }
        switch (type)
        {
            case "session.created":
            case "session.updated":
                if (root.TryGetProperty("session", out JsonElement session))
                {
                    _session.SetTag(Prefix + "session.id", Identifier(session, "id"));
                    _model = Identifier(session, "model") ?? _model;
                    _conversationId = Identifier(session, "conversation_id") ?? _conversationId;
                    _session.SetTag("gen_ai.request.model", _model);
                    _session.SetTag("gen_ai.conversation.id", _conversationId);
                    RecordAudioFormat(session, "input");
                    RecordAudioFormat(session, "output");
                }
                AddEvent(_session, "voice_agents." + type);
                break;
            case "response.created":
                if (root.TryGetProperty("response", out JsonElement created))
                {
                    StartResponse(created);
                }
                break;
            case "response.output_audio.delta":
            case "response.audio.delta":
                long count = AudioBytes(root, "delta");
                _outputAudioBytes += count;
                ResponseActivity audioResponse = FindResponse(root);
                if (audioResponse != null)
                {
                    if (count > 0 && audioResponse.OutputAudioBytes == 0)
                    {
                        audioResponse.Activity?.SetTag(Prefix + "response.time_to_first_audio_seconds",
                            (Stopwatch.GetTimestamp() - audioResponse.StartTimestamp) / (double)Stopwatch.Frequency);
                    }
                    audioResponse.OutputAudioBytes += count;
                }
                break;
            case "response.output_text.delta":
            case "response.text.delta":
                ResponseActivity textResponse = FindResponse(root);
                if (textResponse != null && !textResponse.FirstTextReceived && !string.IsNullOrEmpty(String(root, "delta")))
                {
                    textResponse.FirstTextReceived = true;
                    textResponse.Activity?.SetTag(Prefix + "response.time_to_first_text_seconds",
                        (Stopwatch.GetTimestamp() - textResponse.StartTimestamp) / (double)Stopwatch.Frequency);
                }
                break;
            case "response.done":
                if (root.TryGetProperty("response", out JsonElement response))
                {
                    FinishResponse(response);
                }
                break;
            case "response.function_call_arguments.done":
                ActivityTagsCollection toolTags = new()
                {
                    { "gen_ai.tool.call.id", Identifier(root, "call_id") },
                    { Prefix + "tool.kind", "function" }
                };
                if (_captureContent)
                {
                    toolTags.Add("gen_ai.tool.name", Limit(String(root, "name")));
                    toolTags.Add(Prefix + "tool.arguments", Limit(String(root, "arguments")));
                }
                AddEvent(FindResponse(root)?.Activity ?? _session, "voice_agents.tool.requested", toolTags);
                if (FindResponse(root) is ResponseActivity toolResponse && Identifier(root, "call_id") is string callId)
                {
                    toolResponse.ToolCalls ??= new Dictionary<string, ToolCall>();
                    if (toolResponse.ToolCalls.Count < 32 || toolResponse.ToolCalls.ContainsKey(callId))
                    {
                        toolResponse.ToolCalls[callId] = new ToolCall(
                            _captureContent ? Limit(String(root, "name")) : null,
                            _captureContent ? Limit(String(root, "arguments")) : null);
                    }
                }
                break;
            case "error":
            case "rtc.call.error":
                ActivityTagsCollection errorTags = new() { { "error.type", "service_error" } };
                if (root.TryGetProperty("error", out JsonElement error) && String(error, "code") is string code &&
                    code is "invalid_event" or "invalid_parameter" or "invalid_request_error" or "invalid_value" or
                        "response_cancel_not_active" or "input_audio_buffer_commit_empty" or "conversation_item_not_found" or
                        "rate_limit_exceeded" or "server_error" or "audio_unintelligible" or "authentication_error" or
                        "session_expired" or "unsupported_value" or "unsupported_parameter")
                {
                    errorTags.Add(Prefix + "error.code", code);
                }
                AddEvent(_session, type == "error" ? "voice_agents.server_error" : type, errorTags);
                LogFailure("service_error");
                break;
            case "warning":
                AddEvent(_session, "voice_agents.warning");
                break;
            case "response.mcp_call.completed":
            case "response.mcp_call.failed":
                AddEvent(_session, type, new ActivityTagsCollection { { Prefix + "item.id", Identifier(root, "item_id") } });
                break;
            case "session.subagent.started":
            case "session.subagent.completed":
            case "session.subagent.aborted":
                ActivityTagsCollection subagentTags = new()
                {
                    { Prefix + "subagent.consultation.id", Identifier(root, "consultation_id") }
                };
                if (String(root, "abort_reason") is string reason &&
                    reason is "unknown_target" or "timeout" or "cancelled" or "stopped_by_user" or "superseded" or "failed")
                {
                    subagentTags.Add(Prefix + "subagent.abort_reason", reason);
                }
                AddEvent(_session, type, subagentTags);
                break;
            case "conversation.item.deleted":
                AddEvent(_session, type);
                break;
        }
    }

    private bool TryObserveInputEvent(JsonElement root, string type)
    {
        string itemId;
        if (type is "conversation.item.added" or "conversation.item.created")
        {
            if (!root.TryGetProperty("item", out JsonElement item) || String(item, "role") != "user" ||
                !HasAudioPart(item) || Identifier(item, "id") is not string id)
            {
                return true;
            }
            itemId = id;
        }
        else if (type is "input_audio_buffer.speech_started" or "input_audio_buffer.committed" or "input_audio_buffer.cleared" or
            "conversation.item.input_audio_transcription.completed" or "conversation.item.input_audio_transcription.failed")
        {
            itemId = Identifier(root, "item_id");
        }
        else
        {
            return false;
        }

        PendingInputEvent input = new(type, itemId,
            _captureContent && type == "conversation.item.input_audio_transcription.completed" ? Limit(String(root, "transcript")) : null);
        if (_pendingSends == 0)
        {
            ObserveInputEvent(input);
        }
        else if (!_pendingInputOverflow)
        {
            // Replay only bounded metadata after the send outcome; VAD/ASR can arrive first.
            _pendingInputEvents ??= new List<PendingInputEvent>();
            if (_pendingInputEvents.Count < MaxInputItems)
            {
                _pendingInputEvents.Add(input);
            }
            else
            {
                _pendingInputOverflow = true;
                _pendingInputEvents.Clear();
                _untrackedInputItems++;
                AddEvent(_session, "voice_agents.warning");
                DiscardPendingInputs();
                CompleteReadyResponses();
            }
        }
        return true;
    }

    private void ObserveInputEvent(PendingInputEvent inputEvent)
    {
        switch (inputEvent.Type)
        {
            case "input_audio_buffer.speech_started":
                if (inputEvent.ItemId is string speechItem && !_inputAudioItems.ContainsKey(speechItem))
                {
                    InputAudio input = _inputAudioBuffer != null && _inputAudioBuffer.ItemId == null
                        ? _inputAudioBuffer : StartInputAudio();
                    RememberInputAudio(speechItem, input);
                    _inputAudioBuffer = input;
                }
                break;
            case "input_audio_buffer.committed":
                if (inputEvent.ItemId is string committedItem)
                {
                    bool pending = _pendingAudioCommits.Items.Count > 0 || _pendingAudioCommits.Skipped > 0;
                    InputAudio input = MatchInputAudio(_pendingAudioCommits, committedItem);
                    if (input == null && !pending)
                    {
                        input = _inputAudioBuffer ?? StartInputAudio();
                        RememberInputAudio(committedItem, input);
                    }
                    if (ReferenceEquals(_inputAudioBuffer, input))
                    {
                        _inputAudioBuffer = null;
                    }
                }
                AddEvent(_session, inputEvent.Type, timestamp: inputEvent.Timestamp);
                break;
            case "input_audio_buffer.cleared":
                if (_pendingAudioClears > 0)
                {
                    _pendingAudioClears--;
                }
                else
                {
                    ClearInputAudio();
                }
                AddEvent(_session, inputEvent.Type, timestamp: inputEvent.Timestamp);
                break;
            case "conversation.item.added":
            case "conversation.item.created":
                MatchInputAudio(_pendingAudioMessages, inputEvent.ItemId);
                break;
            case "conversation.item.input_audio_transcription.completed":
                if (inputEvent.ItemId is string transcriptItem &&
                    _inputAudioItems.TryGetValue(transcriptItem, out InputAudio transcribed))
                {
                    SetInputAudioSummary(transcribed, inputEvent.Transcript);
                }
                AddEvent(_session, "voice_agents.transcription.completed", timestamp: inputEvent.Timestamp);
                break;
            case "conversation.item.input_audio_transcription.failed":
                AddEvent(_session, "voice_agents.transcription.failed", timestamp: inputEvent.Timestamp);
                break;
        }
    }

    private static bool HasAudioPart(JsonElement item)
    {
        if (item.ValueKind == JsonValueKind.Object && item.TryGetProperty("content", out JsonElement content) &&
            content.ValueKind == JsonValueKind.Array)
        {
            foreach (JsonElement part in content.EnumerateArray())
            {
                if (String(part, "type") is "audio" or "input_audio")
                {
                    return true;
                }
            }
        }
        return false;
    }

    private InputAudio StartInputAudio()
    {
        InputAudio input = new() { Sequence = ++_inputSequence };
        SetInputAudioSummary(input);
        return input;
    }

    private void SetInputAudioSummary(InputAudio input, string transcript = null)
    {
        string summary = MessageSummary("user", "audio", _captureContent ? transcript : null);
        if (input.Sequence == _inputSequence)
        {
            _lastInput = summary;
            _session.SetTag("gen_ai.input.messages", summary);
        }
        foreach (ResponseActivity response in _responses.Values)
        {
            if (response.InputSequence == input.Sequence)
            {
                response.Activity?.SetTag("gen_ai.input.messages", summary);
            }
        }
    }

    private void ClearInputAudio()
    {
        if (_inputAudioBuffer?.Sequence == _inputSequence)
        {
            _inputSequence++;
            _lastInput = null;
            _session.SetTag("gen_ai.input.messages", null);
        }
        _inputAudioBuffer = null;
    }

    private void EnqueueInputAudio(PendingAudio pending, InputAudio input)
    {
        input.Pending = pending;
        // Preserve overflow positions until their acknowledgements arrive.
        if (pending.Items.Count >= MaxInputItems || pending.Skipped > 0)
        {
            input.Skipped = true;
            pending.Skipped++;
            _untrackedInputItems++;
        }
        else
        {
            pending.Items.Add(input);
        }
    }

    private InputAudio MatchInputAudio(PendingAudio pending, string itemId)
    {
        if (_inputAudioItems.TryGetValue(itemId, out InputAudio known))
        {
            if (ReferenceEquals(known.Pending, pending))
            {
                if (!pending.Items.Remove(known) && known.Skipped && pending.Skipped > 0)
                {
                    pending.Skipped--;
                }
                known.Pending = null;
                known.Skipped = false;
            }
            return known;
        }
        if (pending.Items.Count > 0)
        {
            InputAudio input = pending.Items[0];
            pending.Items.RemoveAt(0);
            input.Pending = null;
            RememberInputAudio(itemId, input);
            return input;
        }
        if (pending.Skipped > 0)
        {
            pending.Skipped--;
        }
        return null;
    }

    private void RememberInputAudio(string itemId, InputAudio input)
    {
        input.ItemId = itemId;
        _inputAudioItems[itemId] = input;
        if (_inputAudioItems.Count > MaxInputItems)
        {
            foreach (KeyValuePair<string, InputAudio> tracked in _inputAudioItems)
            {
                if (tracked.Value.Sequence != _inputSequence || tracked.Key != itemId)
                {
                    _inputAudioItems.Remove(tracked.Key);
                    break;
                }
            }
        }
    }

    private void RecordAudioFormat(JsonElement session, string direction)
    {
        if (session.ValueKind != JsonValueKind.Object)
        {
            return;
        }
        JsonElement format;
        JsonElement rate = default;
        if (session.TryGetProperty("audio", out JsonElement audio) && audio.ValueKind == JsonValueKind.Object &&
            audio.TryGetProperty(direction, out JsonElement settings) && settings.ValueKind == JsonValueKind.Object &&
            settings.TryGetProperty("format", out format))
        {
            if (format.ValueKind == JsonValueKind.Object && !format.TryGetProperty("rate", out rate))
            {
                format.TryGetProperty("sample_rate", out rate);
            }
        }
        else if (session.TryGetProperty(direction + "_audio_format", out format))
        {
            session.TryGetProperty(direction + "_audio_sample_rate", out rate);
        }
        else
        {
            return;
        }
        string value = format.ValueKind == JsonValueKind.String ? format.GetString() : String(format, "type");
        string safeFormat = value switch
        {
            "audio/pcm" or "pcm16" => "audio/pcm",
            "audio/pcmu" or "g711_ulaw" => "audio/pcmu",
            "audio/pcma" or "g711_alaw" => "audio/pcma",
            _ => null
        };
        _session.SetTag(Prefix + direction + ".audio.format", safeFormat);
        _session.SetTag(Prefix + direction + ".audio.sample_rate",
            safeFormat != null && rate.ValueKind == JsonValueKind.Number && rate.TryGetInt32(out int sampleRate) &&
            sampleRate >= 8000 && sampleRate <= 384000 ? sampleRate : (int?)null);
    }

    private void StartResponse(JsonElement response)
    {
        string id = Identifier(response, "id");
        if (id == null || _responses.ContainsKey(id))
        {
            return;
        }
        if (_responses.Count == MaxResponses)
        {
            _responsesUntracked++;
            return;
        }
        Activity activity = StartDetachedActivity("invoke_agent", _session.Context);
        SetCommonTags(activity);
        activity?.SetTag("gen_ai.operation.name", "invoke_agent");
        activity?.SetTag("gen_ai.response.id", id);
        activity?.SetTag("gen_ai.request.model", _model);
        activity?.SetTag("gen_ai.conversation.id", Identifier(response, "conversation_id") ?? _conversationId);
        // A receive can outrun the send continuation. Do not attribute a response
        // to the previous input while the outgoing send's outcome is unknown.
        if (_pendingSends == 0 && _lastInput != null)
        {
            activity?.SetTag("gen_ai.input.messages", _lastInput);
        }
        _responses.Add(id, new ResponseActivity(activity)
        {
            InputSequence = _pendingSends == 0 ? _inputSequence : -1,
            PendingInput = _pendingSends != 0 && !_pendingInputOverflow,
            PendingInputEvents = _pendingInputEvents?.Count ?? 0
        });
    }

    private void FinishResponse(JsonElement response)
    {
        string id = Identifier(response, "id");
        if (id == null || !_responses.TryGetValue(id, out ResponseActivity state) || state.Finished)
        {
            return;
        }
        state.Finished = true;
        string status = String(response, "status");
        string safeStatus = status is "completed" or "cancelled" or "failed" or "incomplete" ? status : "unknown";
        state.Activity?.SetTag(Prefix + "response.status", safeStatus);
        state.Activity?.SetTag(Prefix + "output.audio.bytes", state.OutputAudioBytes);
        _conversationId = Identifier(response, "conversation_id") ?? _conversationId;
        state.Activity?.SetTag("gen_ai.conversation.id", _conversationId);
        state.Activity?.SetTag("gen_ai.response.model", Identifier(response, "model") ?? _model);
        if (response.TryGetProperty("output_modalities", out JsonElement modalities) && modalities.ValueKind == JsonValueKind.Array)
        {
            List<string> outputModalities = new();
            foreach (JsonElement modality in modalities.EnumerateArray())
            {
                if (modality.ValueKind == JsonValueKind.String && modality.GetString() is string value && value is "text" or "audio")
                {
                    if (!outputModalities.Contains(value))
                    {
                        outputModalities.Add(value);
                    }
                }
            }
            state.Activity?.SetTag(Prefix + "response.output_modalities", outputModalities.ToArray());
        }
        if (safeStatus == "completed")
        {
            state.Activity?.SetStatus(ActivityStatusCode.Ok);
        }
        else if (safeStatus == "failed")
        {
            state.Activity?.SetStatus(ActivityStatusCode.Error);
            state.Activity?.SetTag("error.type", "response_failed");
        }
        if (response.TryGetProperty("usage", out JsonElement usage))
        {
            SetNumberTag(state.Activity, usage, "input_tokens", "gen_ai.usage.input_tokens");
            SetNumberTag(state.Activity, usage, "output_tokens", "gen_ai.usage.output_tokens");
        }
        RecordOutputMessages(state, response);
        if (state.PendingInput)
        {
            // Preserve the protocol boundary using the same monotonic clock as latency measurements.
            if (state.Activity != null)
            {
                long ticks = (long)((Stopwatch.GetTimestamp() - state.StartTimestamp) *
                    (TimeSpan.TicksPerSecond / (double)Stopwatch.Frequency));
                state.Activity.SetEndTime(state.Activity.StartTimeUtc.AddTicks(Math.Max(1L, ticks)));
            }
        }
        else
        {
            _responses.Remove(id);
            StopDetachedActivity(state.Activity);
        }
        _responsesFinished++;
    }

    private void RecordOutputMessages(ResponseActivity state, JsonElement response)
    {
        bool hasOutput = response.ValueKind == JsonValueKind.Object &&
            response.TryGetProperty("output", out JsonElement outputValue) && outputValue.ValueKind == JsonValueKind.Array;
        if (hasOutput || state.ToolCalls?.Count > 0)
        {
            using MemoryStream buffer = new();
            using Utf8JsonWriter writer = new(buffer);
            writer.WriteStartArray();
            int messageCount = 0;
            HashSet<string> observedCalls = new();
            if (hasOutput)
            {
            foreach (JsonElement item in response.GetProperty("output").EnumerateArray())
            {
                if (messageCount == 32)
                {
                    break;
                }
                if (String(item, "type") == "function_call")
                {
                    string callId = Identifier(item, "call_id");
                    ToolCall observed = null;
                    if (callId != null)
                    {
                        observedCalls.Add(callId);
                        state.ToolCalls?.TryGetValue(callId, out observed);
                    }
                    WriteMessage(writer, "assistant", "tool_call", null, callId,
                        _captureContent ? Limit(String(item, "name")) ?? observed?.Name : null,
                        _captureContent ? Limit(String(item, "arguments")) ?? observed?.Arguments : null);
                    messageCount++;
                }
                if (item.ValueKind == JsonValueKind.Object && item.TryGetProperty("content", out JsonElement content) && content.ValueKind == JsonValueKind.Array)
                {
                    foreach (JsonElement part in content.EnumerateArray())
                    {
                        string type = String(part, "type");
                        if (type is "text" or "output_text" or "audio" or "output_audio" && messageCount < 32)
                        {
                            string text = _captureContent ? String(part, "text") ?? String(part, "transcript") : null;
                            WriteMessage(writer, "assistant", type is "audio" or "output_audio" ? "audio" : "text", text);
                            messageCount++;
                        }
                    }
                }
            }
            }
            if (state.ToolCalls != null)
            {
                foreach (KeyValuePair<string, ToolCall> call in state.ToolCalls)
                {
                    if (messageCount >= 32)
                    {
                        break;
                    }
                    if (observedCalls.Add(call.Key))
                    {
                        WriteMessage(writer, "assistant", "tool_call", null, call.Key, call.Value.Name, call.Value.Arguments);
                        messageCount++;
                    }
                }
            }
            writer.WriteEndArray();
            writer.Flush();
            state.Activity?.SetTag("gen_ai.output.messages", new BinaryData(buffer.ToArray()).ToString());
        }
    }

    private ResponseActivity FindResponse(JsonElement root)
    {
        string id = Identifier(root, "response_id");
        return id != null && _responses.TryGetValue(id, out ResponseActivity result) && !result.Finished ? result : null;
    }

    private string InputSummary(JsonElement item)
    {
        string summary = null;
        string role = String(item, "role") switch
        {
            "assistant" => "assistant",
            "system" => "system",
            _ => "user"
        };
        if (item.TryGetProperty("content", out JsonElement content) && content.ValueKind == JsonValueKind.Array)
        {
            foreach (JsonElement part in content.EnumerateArray())
            {
                string type = String(part, "type");
                if (type is "input_audio" or "audio")
                {
                    _inputAudioBytes += AudioBytes(part, "audio");
                    summary ??= MessageSummary(role, "audio", null);
                }
                if (type is "input_text" or "text")
                {
                    summary ??= MessageSummary(role, "text", _captureContent ? String(part, "text") : null);
                }
            }
        }
        return summary;
    }

    private static string MessageSummary(string role, string type, string content, string callId = null)
    {
        using MemoryStream buffer = new();
        using Utf8JsonWriter writer = new(buffer);
        writer.WriteStartArray();
        WriteMessage(writer, role, type, content, callId);
        writer.WriteEndArray();
        writer.Flush();
        return new BinaryData(buffer.ToArray()).ToString();
    }

    private static void WriteMessage(Utf8JsonWriter writer, string role, string type, string content, string callId = null,
        string toolName = null, string arguments = null)
    {
        writer.WriteStartObject();
        writer.WriteString("role", role);
        writer.WriteStartArray("parts");
        WritePart(writer, type, content, callId, toolName, arguments);
        writer.WriteEndArray();
        writer.WriteEndObject();
    }

    private static string InstructionSummary(string instructions)
    {
        using MemoryStream buffer = new();
        using Utf8JsonWriter writer = new(buffer);
        writer.WriteStartArray();
        WritePart(writer, "text", instructions);
        writer.WriteEndArray();
        writer.Flush();
        return new BinaryData(buffer.ToArray()).ToString();
    }

    private static void WritePart(Utf8JsonWriter writer, string type, string content, string callId = null,
        string toolName = null, string arguments = null)
    {
        writer.WriteStartObject();
        writer.WriteString("type", type);
        if (callId != null)
        {
            writer.WriteString("id", callId);
        }
        if (content != null)
        {
            writer.WriteString(type == "tool_call_response" ? "response" : "content", Limit(content));
        }
        if (toolName != null)
        {
            writer.WriteString("name", toolName);
        }
        if (arguments != null)
        {
            writer.WriteString("arguments", arguments);
        }
        writer.WriteEndObject();
    }

    private void EndCore(WebSocketCloseStatus? code, bool wasClean)
    {
        if (_ended)
        {
            return;
        }
        _ended = true;
        foreach (ResponseActivity response in _responses.Values)
        {
            if (response.PendingInput)
            {
                response.Activity?.SetTag("gen_ai.input.messages", null);
            }
            if (!response.Finished)
            {
                response.Activity?.SetTag(Prefix + "response.status", "interrupted");
                response.Activity?.SetTag(Prefix + "output.audio.bytes", response.OutputAudioBytes);
                RecordOutputMessages(response, default);
            }
            StopDetachedActivity(response.Activity);
        }
        _responses.Clear();
        _pendingSends = 0;
        _pendingInputEvents?.Clear();
        _inputAudioItems.Clear();
        _pendingAudioCommits.Items.Clear();
        _pendingAudioMessages.Items.Clear();
        _inputAudioBuffer = null;
        _sendBuffer?.Dispose();
        _receiveBuffer?.Dispose();
        _sendBuffer = null;
        _receiveBuffer = null;
        _session.SetTag(Prefix + "input.audio.bytes", _inputAudioBytes);
        _session.SetTag(Prefix + "output.audio.bytes", _outputAudioBytes);
        if (_untrackedInputItems > 0)
        {
            _session.SetTag(Prefix + "input.items.untracked", _untrackedInputItems);
        }
        _session.SetTag(Prefix + "responses.finished", _responsesFinished);
        _session.SetTag("gen_ai.conversation.id", _conversationId);
        if (_lastInput != null)
        {
            _session.SetTag("gen_ai.input.messages", _lastInput);
        }
        if (_responsesUntracked > 0)
        {
            _session.SetTag(Prefix + "responses.untracked", _responsesUntracked);
        }
        if (_eventsUntracked > 0)
        {
            _session.SetTag(Prefix + "events.untracked", _eventsUntracked);
        }
        if (code.HasValue)
        {
            _session.SetTag(Prefix + "close.code", (int)code.Value);
            if ((int)code.Value >= 1002)
            {
                _session.SetStatus(ActivityStatusCode.Error);
                _session.SetTag("error.type", "websocket_close");
            }
        }
        _session.SetTag(Prefix + "close.was_clean", wasClean);
        LogConnection("closed");
        StopDetachedActivity(_session);
    }

    private void SetCommonTags(Activity activity)
    {
        activity?.SetTag("gen_ai.provider.name", "microsoft.foundry");
        activity?.SetTag("az.namespace", "Microsoft.CognitiveServices");
        activity?.SetTag("server.address", _endpoint.Host);
        if (_endpoint.Port != 443 && !_endpoint.IsDefaultPort)
        {
            activity?.SetTag("server.port", _endpoint.Port);
        }
        activity?.SetTag("gen_ai.agent.name", _agentName);
        activity?.SetTag("gen_ai.agent.type", "voice");
    }

    private void AddEvent(Activity activity, string name, ActivityTagsCollection tags = null, DateTimeOffset timestamp = default)
    {
        if (activity?.IsAllDataRequested == true)
        {
            if (_eventsRecorded < 256)
            {
                activity.AddEvent(new ActivityEvent(name, timestamp: timestamp, tags: tags));
                _eventsRecorded++;
            }
            else
            {
                _eventsUntracked++;
            }
        }
        if (_enableLogging && VoiceAgentRealtimeEventSource.Log.IsEnabled())
        {
            VoiceAgentRealtimeEventSource.Log.ProtocolEvent(name, _session.TraceId.ToString(), activity?.SpanId.ToString());
        }
    }

    private void LogConnection(string state)
    {
        if (_enableLogging && VoiceAgentRealtimeEventSource.Log.IsEnabled())
        {
            VoiceAgentRealtimeEventSource.Log.ConnectionState(state, _session.TraceId.ToString(), _session.SpanId.ToString());
        }
    }

    private void LogFailure(string errorType)
    {
        if (_enableLogging && VoiceAgentRealtimeEventSource.Log.IsEnabled())
        {
            VoiceAgentRealtimeEventSource.Log.Failure(errorType, _session.TraceId.ToString(), _session.SpanId.ToString());
        }
    }

    private static Activity StartDetachedActivity(string name, ActivityContext parent)
    {
        Activity previous = Activity.Current;
        try
        {
            return s_source.StartActivity(name, ActivityKind.Client, parent);
        }
        finally
        {
            // Session/response lifetimes must not become the caller's ambient Activity.
            Activity.Current = previous;
        }
    }

    private static void StopDetachedActivity(Activity activity)
    {
        Activity previous = Activity.Current;
        try
        {
            activity?.Stop();
        }
        finally
        {
            if (!ReferenceEquals(previous, activity))
            {
                Activity.Current = previous;
            }
        }
    }

    private static void SetFailure(Activity activity, Exception exception)
    {
        if (exception is OperationCanceledException)
        {
            activity?.SetTag(Prefix + "cancelled", true);
            return;
        }
        activity?.SetStatus(ActivityStatusCode.Error);
        activity?.SetTag("error.type", SafeErrorType(exception));
        if (exception is ClientResultException responseException)
        {
            activity?.SetTag("http.response.status_code", responseException.Status);
        }
    }

    private static string SafeErrorType(Exception exception) => exception switch
    {
        OperationCanceledException => nameof(OperationCanceledException),
        WebSocketException => nameof(WebSocketException),
        ClientResultException => nameof(ClientResultException),
        TimeoutException => nameof(TimeoutException),
        _ => nameof(Exception)
    };

    private static string String(JsonElement parent, string name)
        => parent.ValueKind == JsonValueKind.Object && parent.TryGetProperty(name, out JsonElement value) && value.ValueKind == JsonValueKind.String
            ? value.GetString() : null;

    private static string Identifier(JsonElement parent, string name)
    {
        string value = String(parent, name);
        return value?.Length <= 256 ? value : null;
    }

    private static string Limit(string value) => value?.Length > MaxContentLength ? value.Substring(0, MaxContentLength) : value;

    private static long AudioBytes(JsonElement parent, string name)
        => parent.ValueKind == JsonValueKind.Object && parent.TryGetProperty(name, out JsonElement value) && value.ValueKind == JsonValueKind.String
            ? value.GetBytesFromBase64().LongLength : 0;

    private static void SetNumberTag(Activity activity, JsonElement parent, string property, string tag)
    {
        if (parent.ValueKind == JsonValueKind.Object && parent.TryGetProperty(property, out JsonElement value) &&
            value.ValueKind == JsonValueKind.Number && value.TryGetInt64(out long number))
        {
            activity?.SetTag(tag, number);
        }
    }

    private sealed class ResponseActivity(Activity activity)
    {
        internal Activity Activity { get; } = activity;
        internal long StartTimestamp { get; } = Stopwatch.GetTimestamp();
        internal long OutputAudioBytes { get; set; }
        internal bool FirstTextReceived { get; set; }
        internal long InputSequence { get; set; }
        internal Dictionary<string, ToolCall> ToolCalls { get; set; }
        internal bool PendingInput { get; set; }
        internal bool Finished { get; set; }
        internal int PendingInputEvents { get; set; }
    }

    private sealed class ToolCall(string name, string arguments)
    {
        internal string Name { get; } = name;
        internal string Arguments { get; } = arguments;
    }

    private sealed class InputAudio
    {
        internal long Sequence { get; set; }
        internal string ItemId { get; set; }
        internal PendingAudio Pending { get; set; }
        internal bool Skipped { get; set; }
    }

    private sealed class PendingAudio
    {
        internal List<InputAudio> Items { get; } = new();
        internal long Skipped { get; set; }
    }

    private sealed class PendingInputEvent(string type, string itemId, string transcript)
    {
        internal string Type { get; } = type;
        internal string ItemId { get; } = itemId;
        internal string Transcript { get; } = transcript;
        internal DateTimeOffset Timestamp { get; } = DateTimeOffset.UtcNow;
    }
}
