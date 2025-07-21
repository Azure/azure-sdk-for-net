// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using System.ClientModel.Primitives;

namespace Azure.AI.VoiceLive
{
    /// <summary>
    /// Factory for creating VoiceLiveUpdate instances from server events.
    /// </summary>
    internal static class VoiceLiveUpdateFactory
    {
        /// <summary>
        /// Creates a VoiceLiveUpdate from a VoiceLiveServerEvent.
        /// </summary>
        /// <param name="serverEvent">The server event to convert.</param>
        /// <returns>The corresponding update, or null if the event cannot be converted.</returns>
        public static VoiceLiveUpdate CreateUpdate(VoiceLiveServerEvent serverEvent)
        {
            if (serverEvent == null)
                return null;

            // Get the event type from the server event
            string eventType = GetEventTypeFromServerEvent(serverEvent);
            VoiceLiveUpdateKind kind = VoiceLiveUpdateKind.FromServerEventType(eventType);

            return CreateUpdateFromServerEvent(serverEvent, kind);
        }

        /// <summary>
        /// Creates a VoiceLiveUpdate from a JSON element.
        /// </summary>
        /// <param name="element">The JSON element containing the update data.</param>
        /// <param name="kind">The update kind.</param>
        /// <param name="eventId">The event ID.</param>
        /// <param name="additionalBinaryDataProperties">Additional properties.</param>
        /// <param name="options">Serialization options.</param>
        /// <returns>The corresponding update.</returns>
        public static VoiceLiveUpdate CreateUpdate(
            JsonElement element,
            VoiceLiveUpdateKind kind,
            string eventId,
            IDictionary<string, BinaryData> additionalBinaryDataProperties,
            ModelReaderWriterOptions options)
        {
            // Try to deserialize the element as a server event first
            var serverEvent = DeserializeServerEvent(element, options);
            if (serverEvent != null)
            {
                return CreateUpdateFromServerEvent(serverEvent, kind, eventId, additionalBinaryDataProperties);
            }

            // If we can't deserialize as a server event, create a generic update
            return new GenericUpdate(kind, eventId, additionalBinaryDataProperties);
        }

        private static VoiceLiveUpdate CreateUpdateFromServerEvent(
            VoiceLiveServerEvent serverEvent,
            VoiceLiveUpdateKind kind,
            string eventId = null,
            IDictionary<string, BinaryData> additionalBinaryDataProperties = null)
        {
            return kind switch
            {
                // Session events
                VoiceLiveUpdateKind.SessionStarted when serverEvent is VoiceLiveServerEventSessionCreated sessionCreated 
                    => new SessionStartedUpdate(kind, eventId, additionalBinaryDataProperties, sessionCreated),

                // Input audio events
                VoiceLiveUpdateKind.InputAudioBufferCommitted
                or VoiceLiveUpdateKind.InputAudioBufferCleared
                or VoiceLiveUpdateKind.InputAudioSpeechStarted
                or VoiceLiveUpdateKind.InputAudioSpeechStopped
                or VoiceLiveUpdateKind.InputAudioTranscriptionCompleted
                or VoiceLiveUpdateKind.InputAudioTranscriptionDelta
                or VoiceLiveUpdateKind.InputAudioTranscriptionFailed
                    => new InputAudioUpdate(kind, eventId, additionalBinaryDataProperties, serverEvent),

                // Response delta events
                VoiceLiveUpdateKind.ResponseTextDelta
                or VoiceLiveUpdateKind.ResponseAudioDelta
                or VoiceLiveUpdateKind.ResponseAudioTranscriptDelta
                or VoiceLiveUpdateKind.ResponseAnimationBlendshapesDelta
                or VoiceLiveUpdateKind.ResponseAnimationVisemeDelta
                or VoiceLiveUpdateKind.ResponseAudioTimestampDelta
                    => new OutputDeltaUpdate(kind, eventId, additionalBinaryDataProperties, serverEvent),

                // Response streaming events
                VoiceLiveUpdateKind.ResponseStarted
                or VoiceLiveUpdateKind.ResponseCompleted
                or VoiceLiveUpdateKind.ResponseOutputItemAdded
                or VoiceLiveUpdateKind.ResponseOutputItemDone
                or VoiceLiveUpdateKind.ResponseContentPartAdded
                or VoiceLiveUpdateKind.ResponseContentPartDone
                or VoiceLiveUpdateKind.ResponseTextDone
                or VoiceLiveUpdateKind.ResponseAudioDone
                or VoiceLiveUpdateKind.ResponseAudioTranscriptDone
                or VoiceLiveUpdateKind.ResponseAnimationBlendshapesDone
                or VoiceLiveUpdateKind.ResponseAnimationVisemeDone
                or VoiceLiveUpdateKind.ResponseAudioTimestampDone
                    => new OutputStreamingUpdate(kind, eventId, additionalBinaryDataProperties, serverEvent),

                // Error events
                VoiceLiveUpdateKind.Error when serverEvent is VoiceLiveServerEventError errorEvent
                    => new ErrorUpdate(kind, eventId, additionalBinaryDataProperties, errorEvent),

                // Generic/unknown events
                _ => new GenericUpdate(kind, eventId, additionalBinaryDataProperties, serverEvent)
            };
        }

        private static string GetEventTypeFromServerEvent(VoiceLiveServerEvent serverEvent)
        {
            return serverEvent switch
            {
                VoiceLiveServerEventError => "error",
                VoiceLiveServerEventSessionAvatarConnecting => "session.avatar.connecting",
                VoiceLiveServerEventSessionCreated => "session.created",
                VoiceLiveServerEventSessionUpdated => "session.updated",
                VoiceLiveServerEventConversationItemInputAudioTranscriptionCompleted => "conversation.item.input_audio_transcription.completed",
                VoiceLiveServerEventConversationItemInputAudioTranscriptionDelta => "conversation.item.input_audio_transcription.delta",
                VoiceLiveServerEventConversationItemInputAudioTranscriptionFailed => "conversation.item.input_audio_transcription.failed",
                VoiceLiveServerEventConversationItemCreated => "conversation.item.created",
                VoiceLiveServerEventConversationItemRetrieved => "conversation.item.retrieved",
                VoiceLiveServerEventConversationItemTruncated => "conversation.item.truncated",
                VoiceLiveServerEventConversationItemDeleted => "conversation.item.deleted",
                VoiceLiveServerEventInputAudioBufferCommitted => "input_audio_buffer.committed",
                VoiceLiveServerEventInputAudioBufferCleared => "input_audio_buffer.cleared",
                VoiceLiveServerEventInputAudioBufferSpeechStarted => "input_audio_buffer.speech_started",
                VoiceLiveServerEventInputAudioBufferSpeechStopped => "input_audio_buffer.speech_stopped",
                VoiceLiveServerEventResponseCreated => "response.created",
                VoiceLiveServerEventResponseDone => "response.done",
                VoiceLiveServerEventResponseOutputItemAdded => "response.output_item.added",
                VoiceLiveServerEventResponseOutputItemDone => "response.output_item.done",
                VoiceLiveServerEventResponseContentPartAdded => "response.content_part.added",
                VoiceLiveServerEventResponseContentPartDone => "response.content_part.done",
                VoiceLiveServerEventResponseTextDelta => "response.text.delta",
                VoiceLiveServerEventResponseTextDone => "response.text.done",
                VoiceLiveServerEventResponseAudioTranscriptDelta => "response.audio_transcript.delta",
                VoiceLiveServerEventResponseAudioTranscriptDone => "response.audio_transcript.done",
                VoiceLiveServerEventResponseAudioDelta => "response.audio.delta",
                VoiceLiveServerEventResponseAudioDone => "response.audio.done",
                ResponseAnimationBlendshapeDeltaEvent => "response.animation_blendshapes.delta",
                ResponseAnimationBlendshapeDoneEvent => "response.animation_blendshapes.done",
                ResponseEmotionHypothesis => "response.emotion_hypothesis",
                ResponseAudioTimestampDeltaEvent => "response.audio_timestamp.delta",
                ResponseAudioTimestampDoneEvent => "response.audio_timestamp.done",
                ResponseAnimationVisemeDeltaEvent => "response.animation_viseme.delta",
                ResponseAnimationVisemeDoneEvent => "response.animation_viseme.done",
                _ => "unknown"
            };
        }

        private static VoiceLiveServerEvent DeserializeServerEvent(JsonElement element, ModelReaderWriterOptions options)
        {
            try
            {
                // Try to deserialize using the VoiceLiveServerEvent deserializer
                return VoiceLiveServerEvent.DeserializeVoiceLiveServerEvent(element, options);
            }
            catch
            {
                // If deserialization fails, return null
                return null;
            }
        }

        /// <summary>
        /// Generic update implementation for unknown or unsupported event types.
        /// </summary>
        private sealed class GenericUpdate : VoiceLiveUpdate
        {
            private readonly VoiceLiveServerEvent _serverEvent;

            public GenericUpdate(VoiceLiveUpdateKind kind, string eventId, IDictionary<string, BinaryData> additionalBinaryDataProperties, VoiceLiveServerEvent serverEvent = null)
                : base(kind, eventId, additionalBinaryDataProperties)
            {
                _serverEvent = serverEvent;
            }

            /// <summary>
            /// Gets the underlying server event, if available.
            /// </summary>
            public VoiceLiveServerEvent ServerEvent => _serverEvent;
        }
    }
}