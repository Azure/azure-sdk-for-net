// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.AI.VoiceLive
{
    /// <summary>
    /// Represents the kind of update received from the VoiceLive service.
    /// </summary>
    public readonly partial struct VoiceLiveUpdateKind : IEquatable<VoiceLiveUpdateKind>
    {
        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of <see cref="VoiceLiveUpdateKind"/>.
        /// </summary>
        /// <param name="value">The string value of the update kind.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        public VoiceLiveUpdateKind(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        // Session events
        /// <summary>A session was started.</summary>
        public static VoiceLiveUpdateKind SessionStarted { get; } = new VoiceLiveUpdateKind("session.created");
        
        /// <summary>A session was updated/configured.</summary>
        public static VoiceLiveUpdateKind SessionUpdated { get; } = new VoiceLiveUpdateKind("session.updated");
        
        /// <summary>Avatar connection is being established.</summary>
        public static VoiceLiveUpdateKind SessionAvatarConnecting { get; } = new VoiceLiveUpdateKind("session.avatar.connecting");

        // Input audio events
        /// <summary>Input audio buffer was committed.</summary>
        public static VoiceLiveUpdateKind InputAudioBufferCommitted { get; } = new VoiceLiveUpdateKind("input_audio_buffer.committed");
        
        /// <summary>Input audio buffer was cleared.</summary>
        public static VoiceLiveUpdateKind InputAudioBufferCleared { get; } = new VoiceLiveUpdateKind("input_audio_buffer.cleared");
        
        /// <summary>Speech started in input audio buffer.</summary>
        public static VoiceLiveUpdateKind InputAudioSpeechStarted { get; } = new VoiceLiveUpdateKind("input_audio_buffer.speech_started");
        
        /// <summary>Speech stopped in input audio buffer.</summary>
        public static VoiceLiveUpdateKind InputAudioSpeechStopped { get; } = new VoiceLiveUpdateKind("input_audio_buffer.speech_stopped");

        // Conversation item events
        /// <summary>A conversation item was created.</summary>
        public static VoiceLiveUpdateKind ConversationItemCreated { get; } = new VoiceLiveUpdateKind("conversation.item.created");
        
        /// <summary>A conversation item was retrieved.</summary>
        public static VoiceLiveUpdateKind ConversationItemRetrieved { get; } = new VoiceLiveUpdateKind("conversation.item.retrieved");
        
        /// <summary>A conversation item was truncated.</summary>
        public static VoiceLiveUpdateKind ConversationItemTruncated { get; } = new VoiceLiveUpdateKind("conversation.item.truncated");
        
        /// <summary>A conversation item was deleted.</summary>
        public static VoiceLiveUpdateKind ConversationItemDeleted { get; } = new VoiceLiveUpdateKind("conversation.item.deleted");

        // Input audio transcription events
        /// <summary>Input audio transcription completed.</summary>
        public static VoiceLiveUpdateKind InputAudioTranscriptionCompleted { get; } = new VoiceLiveUpdateKind("conversation.item.input_audio_transcription.completed");
        
        /// <summary>Input audio transcription delta.</summary>
        public static VoiceLiveUpdateKind InputAudioTranscriptionDelta { get; } = new VoiceLiveUpdateKind("conversation.item.input_audio_transcription.delta");
        
        /// <summary>Input audio transcription failed.</summary>
        public static VoiceLiveUpdateKind InputAudioTranscriptionFailed { get; } = new VoiceLiveUpdateKind("conversation.item.input_audio_transcription.failed");

        // Response events
        /// <summary>A response was created/started.</summary>
        public static VoiceLiveUpdateKind ResponseStarted { get; } = new VoiceLiveUpdateKind("response.created");
        
        /// <summary>A response was completed/done.</summary>
        public static VoiceLiveUpdateKind ResponseCompleted { get; } = new VoiceLiveUpdateKind("response.done");

        // Response output item events
        /// <summary>A response output item was added.</summary>
        public static VoiceLiveUpdateKind ResponseOutputItemAdded { get; } = new VoiceLiveUpdateKind("response.output_item.added");
        
        /// <summary>A response output item was completed.</summary>
        public static VoiceLiveUpdateKind ResponseOutputItemDone { get; } = new VoiceLiveUpdateKind("response.output_item.done");

        // Response content part events
        /// <summary>A response content part was added.</summary>
        public static VoiceLiveUpdateKind ResponseContentPartAdded { get; } = new VoiceLiveUpdateKind("response.content_part.added");
        
        /// <summary>A response content part was completed.</summary>
        public static VoiceLiveUpdateKind ResponseContentPartDone { get; } = new VoiceLiveUpdateKind("response.content_part.done");

        // Response streaming events
        /// <summary>Response text delta (streaming text).</summary>
        public static VoiceLiveUpdateKind ResponseTextDelta { get; } = new VoiceLiveUpdateKind("response.text.delta");
        
        /// <summary>Response text completed.</summary>
        public static VoiceLiveUpdateKind ResponseTextDone { get; } = new VoiceLiveUpdateKind("response.text.done");
        
        /// <summary>Response audio delta (streaming audio).</summary>
        public static VoiceLiveUpdateKind ResponseAudioDelta { get; } = new VoiceLiveUpdateKind("response.audio.delta");
        
        /// <summary>Response audio completed.</summary>
        public static VoiceLiveUpdateKind ResponseAudioDone { get; } = new VoiceLiveUpdateKind("response.audio.done");
        
        /// <summary>Response audio transcript delta (streaming transcript).</summary>
        public static VoiceLiveUpdateKind ResponseAudioTranscriptDelta { get; } = new VoiceLiveUpdateKind("response.audio_transcript.delta");
        
        /// <summary>Response audio transcript completed.</summary>
        public static VoiceLiveUpdateKind ResponseAudioTranscriptDone { get; } = new VoiceLiveUpdateKind("response.audio_transcript.done");

        // Animation and visual events
        /// <summary>Response animation blendshapes delta.</summary>
        public static VoiceLiveUpdateKind ResponseAnimationBlendshapesDelta { get; } = new VoiceLiveUpdateKind("response.animation_blendshapes.delta");
        
        /// <summary>Response animation blendshapes completed.</summary>
        public static VoiceLiveUpdateKind ResponseAnimationBlendshapesDone { get; } = new VoiceLiveUpdateKind("response.animation_blendshapes.done");
        
        /// <summary>Response animation viseme delta.</summary>
        public static VoiceLiveUpdateKind ResponseAnimationVisemeDelta { get; } = new VoiceLiveUpdateKind("response.animation_viseme.delta");
        
        /// <summary>Response animation viseme completed.</summary>
        public static VoiceLiveUpdateKind ResponseAnimationVisemeDone { get; } = new VoiceLiveUpdateKind("response.animation_viseme.done");
        
        /// <summary>Response audio timestamp delta.</summary>
        public static VoiceLiveUpdateKind ResponseAudioTimestampDelta { get; } = new VoiceLiveUpdateKind("response.audio_timestamp.delta");
        
        /// <summary>Response audio timestamp completed.</summary>
        public static VoiceLiveUpdateKind ResponseAudioTimestampDone { get; } = new VoiceLiveUpdateKind("response.audio_timestamp.done");
        
        /// <summary>Response emotion hypothesis.</summary>
        public static VoiceLiveUpdateKind ResponseEmotionHypothesis { get; } = new VoiceLiveUpdateKind("response.emotion_hypothesis");

        // Error events
        /// <summary>An error occurred.</summary>
        public static VoiceLiveUpdateKind Error { get; } = new VoiceLiveUpdateKind("error");

        /// <summary>
        /// An update that does not map to a known kind.
        /// </summary>
        public static VoiceLiveUpdateKind Unknown { get; } = new VoiceLiveUpdateKind("unknown");

        /// <inheritdoc/>
        public static bool operator ==(VoiceLiveUpdateKind left, VoiceLiveUpdateKind right) => left.Equals(right);

        /// <inheritdoc/>
        public static bool operator !=(VoiceLiveUpdateKind left, VoiceLiveUpdateKind right) => !left.Equals(right);

        /// <summary>
        /// Converts a string to a <see cref="VoiceLiveUpdateKind"/>.
        /// </summary>
        /// <param name="value">The string value to convert.</param>
        public static implicit operator VoiceLiveUpdateKind(string value) => new VoiceLiveUpdateKind(value);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is VoiceLiveUpdateKind other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(VoiceLiveUpdateKind other) => string.Equals(_value, other._value, StringComparison.OrdinalIgnoreCase);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.OrdinalIgnoreCase.GetHashCode(_value) : 0;

        /// <inheritdoc/>
        public override string ToString() => _value;

        internal string ToSerialString() => _value;

        internal static VoiceLiveUpdateKind FromServerEventType(string serverEventType)
        {
            return serverEventType?.ToLowerInvariant() switch
            {
                "error" => Error,
                "session.avatar.connecting" => SessionAvatarConnecting,
                "session.created" => SessionStarted,
                "session.updated" => SessionUpdated,
                "conversation.item.input_audio_transcription.completed" => InputAudioTranscriptionCompleted,
                "conversation.item.input_audio_transcription.delta" => InputAudioTranscriptionDelta,
                "conversation.item.input_audio_transcription.failed" => InputAudioTranscriptionFailed,
                "conversation.item.created" => ConversationItemCreated,
                "conversation.item.retrieved" => ConversationItemRetrieved,
                "conversation.item.truncated" => ConversationItemTruncated,
                "conversation.item.deleted" => ConversationItemDeleted,
                "input_audio_buffer.committed" => InputAudioBufferCommitted,
                "input_audio_buffer.cleared" => InputAudioBufferCleared,
                "input_audio_buffer.speech_started" => InputAudioSpeechStarted,
                "input_audio_buffer.speech_stopped" => InputAudioSpeechStopped,
                "response.created" => ResponseStarted,
                "response.done" => ResponseCompleted,
                "response.output_item.added" => ResponseOutputItemAdded,
                "response.output_item.done" => ResponseOutputItemDone,
                "response.content_part.added" => ResponseContentPartAdded,
                "response.content_part.done" => ResponseContentPartDone,
                "response.text.delta" => ResponseTextDelta,
                "response.text.done" => ResponseTextDone,
                "response.audio_transcript.delta" => ResponseAudioTranscriptDelta,
                "response.audio_transcript.done" => ResponseAudioTranscriptDone,
                "response.audio.delta" => ResponseAudioDelta,
                "response.audio.done" => ResponseAudioDone,
                "response.animation_blendshapes.delta" => ResponseAnimationBlendshapesDelta,
                "response.animation_blendshapes.done" => ResponseAnimationBlendshapesDone,
                "response.emotion_hypothesis" => ResponseEmotionHypothesis,
                "response.audio_timestamp.delta" => ResponseAudioTimestampDelta,
                "response.audio_timestamp.done" => ResponseAudioTimestampDone,
                "response.animation_viseme.delta" => ResponseAnimationVisemeDelta,
                "response.animation_viseme.done" => ResponseAnimationVisemeDone,
                _ => Unknown
            };
        }
    }
}