// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.VoiceLive.Telemetry;
using Azure.Core;

namespace Azure.AI.VoiceLive
{
    public partial class VoiceLiveSession
    {
        /// <summary>
        /// Gets all server events from the VoiceLive service as an asynchronous enumerable.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>An asynchronous enumerable of VoiceLive server events.</returns>
        /// <remarks>
        /// This method provides streaming access to all server events from the service, including session events,
        /// input audio processing events, response streaming, and error notifications.
        ///
        /// The method handles WebSocket message fragmentation automatically and ensures that complete
        /// messages are processed before yielding events.
        /// </remarks>
        public async IAsyncEnumerable<SessionUpdate> GetUpdatesAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            ThrowIfDisposed();

            // Ensure we're connected before starting to receive updates
            if (WebSocket?.State != WebSocketState.Open)
            {
                throw new InvalidOperationException("Session must be connected before retrieving updates.");
            }

            // Use lock to ensure only one reader at a time
            lock (_singleReceiveLock)
            {
                if (_receiveCollectionResult != null)
                {
                    throw new InvalidOperationException("Only one update enumeration can be active at a time.");
                }

                _receiveCollectionResult = new AsyncVoiceLiveMessageCollectionResult(WebSocket, _contentLogger, _connectionId, cancellationToken);
            }

            try
            {
                await foreach (BinaryData message in _receiveCollectionResult.WithCancellation(cancellationToken))
                {
                    // Process the message and yield any server events
                    foreach (SessionUpdate serverEvent in ProcessMessage(message))
                    {
                        yield return serverEvent;
                    }
                }
            }
            finally
            {
                lock (_singleReceiveLock)
                {
                    _receiveCollectionResult = null;
                }
            }
        }

        /// <summary>
        /// Gets server events of a specific type from the VoiceLive service.
        /// </summary>
        /// <typeparam name="T">The specific type of server event to filter for.</typeparam>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>An asynchronous enumerable of server events of the specified type.</returns>
        public async IAsyncEnumerable<T> GetUpdatesAsync<T>([EnumeratorCancellation] CancellationToken cancellationToken = default)
            where T : SessionUpdate
        {
            await foreach (SessionUpdate serverEvent in GetUpdatesAsync(cancellationToken).ConfigureAwait(false))
            {
                if (serverEvent is T typedEvent)
                {
                    yield return typedEvent;
                }
            }
        }

        /// <summary>
        /// Waits for the next server event of a specific type.
        /// </summary>
        /// <typeparam name="T">The type of server event to wait for.</typeparam>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>The next server event of the specified type.</returns>
        public async Task<T> WaitForUpdateAsync<T>(CancellationToken cancellationToken = default)
            where T : SessionUpdate
        {
            await foreach (T serverEvent in GetUpdatesAsync<T>(cancellationToken).ConfigureAwait(false))
            {
                return serverEvent;
            }

            throw new OperationCanceledException("No server event received before cancellation.", cancellationToken);
        }

        /// <summary>
        /// Processes a WebSocket message and converts it to VoiceLive server events.
        /// </summary>
        /// <param name="message">The message to process.</param>
        /// <returns>An enumerable of server events extracted from the message.</returns>
        private IEnumerable<SessionUpdate> ProcessMessage(BinaryData message)
        {
            if (message == null || message.ToArray().Length == 0)
            {
                yield break;
            }

            SessionUpdate sessionUpdate = null;

            // Try to parse as JSON first
            using JsonDocument document = JsonDocument.Parse(message);
            JsonElement root = document.RootElement;

            // Extract the event type string before deserialization for telemetry routing.
            string eventType = null;
            if (root.TryGetProperty("type", out var typeEl) && typeEl.ValueKind == JsonValueKind.String)
                eventType = typeEl.GetString();

            // Instrument the recv span synchronously. The span starts and stops before yielding
            // so it only covers message parsing/enrichment, not the caller's processing time.
            InstrumentRecvEvent(eventType, root);

            // Deserialize as a server event
            sessionUpdate = SessionUpdate.DeserializeSessionUpdate(root, ModelSerializationExtensions.WireOptions);

            if (sessionUpdate != null)
            {
                yield return sessionUpdate;
            }
        }

        /// <summary>
        /// Creates a short-lived recv span for the given event type, enriches it with typed attributes,
        /// and stops it synchronously. Telemetry errors are swallowed to never break message processing.
        /// </summary>
        private void InstrumentRecvEvent(string eventType, JsonElement root)
        {
            if (_tracer == null || !_tracer.IsEnabled || string.IsNullOrEmpty(eventType))
                return;

            // Skip high-frequency delta events that would dominate traces without adding value.
            if (eventType == "response.text.delta" || eventType == "response.audio_transcript.delta")
                return;

            Activity activity = null;
            try
            {
                activity = _tracer.StartRecvActivity(eventType);

                switch (eventType)
                {
                    case "session.created":
                    case "session.updated":
                        _tracer.EnrichRecvSessionEvent(activity, root);
                        break;

                    case "response.done":
                        _tracer.EnrichRecvResponseDone(activity, root);
                        break;

                    case "response.audio.delta":
                        // First audio delta → record first-token latency
                        double? latencyMs = _tracer.TryRecordFirstTokenLatency();
                        if (latencyMs.HasValue && activity?.IsAllDataRequested == true)
                            activity.SetTag(VoiceLiveTelemetryAttributeKeys.GenAiVoiceFirstTokenLatencyMs, latencyMs.Value);
                        _tracer.OnRecvAudioDelta(root);
                        break;

                    case "input_audio_buffer.speech_started":
                        _tracer.OnRecvSpeechStarted();
                        break;

                    case "mcp_list_tools.completed":
                    case "mcp_list_tools.failed":
                        _tracer.OnRecvMcpListToolsDone();
                        _tracer.EnrichRecvMcpEvent(activity, root);
                        break;

                    case "response.mcp_call.completed":
                    case "response.mcp_call.failed":
                        _tracer.OnRecvMcpCallDone();
                        _tracer.EnrichRecvMcpEvent(activity, root);
                        break;

                    case "conversation.item.created":
                    case "conversation.item.retrieved":
                    case "response.output_item.added":
                    case "response.output_item.done":
                        _tracer.EnrichWithItemIds(activity, root);
                        break;
                }
            }
            catch
            {
                // Telemetry errors must never disrupt message processing
            }
            finally
            {
                activity?.Stop();
            }
        }
    }
}
