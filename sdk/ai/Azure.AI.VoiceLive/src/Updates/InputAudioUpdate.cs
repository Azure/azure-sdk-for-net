// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.VoiceLive
{
    /// <summary>
    /// Represents an update related to input audio processing.
    /// </summary>
    public sealed class InputAudioUpdate : VoiceLiveUpdate
    {
        private readonly VoiceLiveServerEvent _serverEvent;

        /// <summary>
        /// Initializes a new instance of the <see cref="InputAudioUpdate"/> class.
        /// </summary>
        /// <param name="kind">The update kind.</param>
        /// <param name="serverEvent">The underlying server event.</param>
        internal InputAudioUpdate(VoiceLiveUpdateKind kind, VoiceLiveServerEvent serverEvent)
            : base(kind)
        {
            Argument.AssertNotNull(serverEvent, nameof(serverEvent));
            _serverEvent = serverEvent;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InputAudioUpdate"/> class.
        /// </summary>
        /// <param name="kind">The update kind.</param>
        /// <param name="eventId">The event ID.</param>
        /// <param name="additionalBinaryDataProperties">Additional properties.</param>
        /// <param name="serverEvent">The underlying server event.</param>
        internal InputAudioUpdate(
            VoiceLiveUpdateKind kind,
            string eventId,
            IDictionary<string, BinaryData> additionalBinaryDataProperties,
            VoiceLiveServerEvent serverEvent)
            : base(kind, eventId, additionalBinaryDataProperties)
        {
            _serverEvent = serverEvent;
        }

        /// <summary>
        /// Gets the item ID associated with the input audio, if available.
        /// </summary>
        public string ItemId
        {
            get
            {
                return _serverEvent switch
                {
                    VoiceLiveServerEventInputAudioBufferSpeechStarted speechStarted => speechStarted.ItemId,
                    VoiceLiveServerEventInputAudioBufferSpeechStopped speechStopped => speechStopped.ItemId,
                    VoiceLiveServerEventInputAudioBufferCommitted committed => committed.ItemId,
                    VoiceLiveServerEventConversationItemInputAudioTranscriptionDelta transcriptionDelta => transcriptionDelta.ItemId,
                    VoiceLiveServerEventConversationItemInputAudioTranscriptionCompleted transcriptionCompleted => transcriptionCompleted.ItemId,
                    VoiceLiveServerEventConversationItemInputAudioTranscriptionFailed transcriptionFailed => transcriptionFailed.ItemId,
                    _ => null
                };
            }
        }

        /// <summary>
        /// Gets the previous item ID, if available.
        /// </summary>
        public string PreviousItemId
        {
            get
            {
                return _serverEvent switch
                {
                    VoiceLiveServerEventInputAudioBufferCommitted committed => committed.PreviousItemId,
                    _ => null
                };
            }
        }

        /// <summary>
        /// Gets the audio start time in milliseconds, if available.
        /// </summary>
        public int? AudioStartMs
        {
            get
            {
                return _serverEvent switch
                {
                    VoiceLiveServerEventInputAudioBufferSpeechStarted speechStarted => speechStarted.AudioStartMs,
                    _ => null
                };
            }
        }

        /// <summary>
        /// Gets the audio end time in milliseconds, if available.
        /// </summary>
        public int? AudioEndMs
        {
            get
            {
                return _serverEvent switch
                {
                    VoiceLiveServerEventInputAudioBufferSpeechStopped speechStopped => speechStopped.AudioEndMs,
                    _ => null
                };
            }
        }

        /// <summary>
        /// Gets the transcription delta text, if available.
        /// </summary>
        public string TranscriptionDelta
        {
            get
            {
                return _serverEvent switch
                {
                    VoiceLiveServerEventConversationItemInputAudioTranscriptionDelta transcriptionDelta => transcriptionDelta.Delta,
                    _ => null
                };
            }
        }

        /// <summary>
        /// Gets the completed transcription text, if available.
        /// </summary>
        public string TranscriptionText
        {
            get
            {
                return _serverEvent switch
                {
                    VoiceLiveServerEventConversationItemInputAudioTranscriptionCompleted transcriptionCompleted => transcriptionCompleted.Transcript,
                    _ => null
                };
            }
        }

        /// <summary>
        /// Gets the transcription error, if available.
        /// </summary>
        public ErrorDetails TranscriptionError
        {
            get
            {
                return _serverEvent switch
                {
                    VoiceLiveServerEventConversationItemInputAudioTranscriptionFailed transcriptionFailed => transcriptionFailed.Error,
                    _ => null
                };
            }
        }

        /// <summary>
        /// Gets the content index for transcription events, if available.
        /// </summary>
        public int? ContentIndex
        {
            get
            {
                return _serverEvent switch
                {
                    VoiceLiveServerEventConversationItemInputAudioTranscriptionDelta transcriptionDelta => transcriptionDelta.ContentIndex,
                    VoiceLiveServerEventConversationItemInputAudioTranscriptionCompleted transcriptionCompleted => transcriptionCompleted.ContentIndex,
                    VoiceLiveServerEventConversationItemInputAudioTranscriptionFailed transcriptionFailed => transcriptionFailed.ContentIndex,
                    _ => null
                };
            }
        }

        /// <summary>
        /// Gets a value indicating whether this update represents speech starting.
        /// </summary>
        public bool IsSpeechStarted => Kind == VoiceLiveUpdateKind.InputAudioSpeechStarted;

        /// <summary>
        /// Gets a value indicating whether this update represents speech stopping.
        /// </summary>
        public bool IsSpeechStopped => Kind == VoiceLiveUpdateKind.InputAudioSpeechStopped;

        /// <summary>
        /// Gets a value indicating whether this update represents audio being committed.
        /// </summary>
        public bool IsAudioCommitted => Kind == VoiceLiveUpdateKind.InputAudioBufferCommitted;

        /// <summary>
        /// Gets a value indicating whether this update represents audio being cleared.
        /// </summary>
        public bool IsAudioCleared => Kind == VoiceLiveUpdateKind.InputAudioBufferCleared;

        /// <summary>
        /// Gets a value indicating whether this update represents a transcription delta.
        /// </summary>
        public bool IsTranscriptionDelta => Kind == VoiceLiveUpdateKind.InputAudioTranscriptionDelta;

        /// <summary>
        /// Gets a value indicating whether this update represents completed transcription.
        /// </summary>
        public bool IsTranscriptionCompleted => Kind == VoiceLiveUpdateKind.InputAudioTranscriptionCompleted;

        /// <summary>
        /// Gets a value indicating whether this update represents a transcription error.
        /// </summary>
        public bool IsTranscriptionFailed => Kind == VoiceLiveUpdateKind.InputAudioTranscriptionFailed;
    }
}
