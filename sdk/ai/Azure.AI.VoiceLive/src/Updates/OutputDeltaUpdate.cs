// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.VoiceLive
{
    /// <summary>
    /// Represents an update containing delta (incremental) output data from the service.
    /// </summary>
    public sealed class OutputDeltaUpdate : VoiceLiveUpdate
    {
        private readonly VoiceLiveServerEvent _serverEvent;

        /// <summary>
        /// Initializes a new instance of the <see cref="OutputDeltaUpdate"/> class.
        /// </summary>
        /// <param name="kind">The update kind.</param>
        /// <param name="serverEvent">The underlying server event.</param>
        internal OutputDeltaUpdate(VoiceLiveUpdateKind kind, VoiceLiveServerEvent serverEvent)
            : base(kind)
        {
            Argument.AssertNotNull(serverEvent, nameof(serverEvent));
            _serverEvent = serverEvent;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OutputDeltaUpdate"/> class.
        /// </summary>
        /// <param name="kind">The update kind.</param>
        /// <param name="eventId">The event ID.</param>
        /// <param name="additionalBinaryDataProperties">Additional properties.</param>
        /// <param name="serverEvent">The underlying server event.</param>
        internal OutputDeltaUpdate(
            VoiceLiveUpdateKind kind,
            string eventId,
            IDictionary<string, BinaryData> additionalBinaryDataProperties,
            VoiceLiveServerEvent serverEvent)
            : base(kind, eventId, additionalBinaryDataProperties)
        {
            _serverEvent = serverEvent;
        }

        /// <summary>
        /// Gets the response ID associated with this delta.
        /// </summary>
        public string ResponseId
        {
            get
            {
                return _serverEvent switch
                {
                    VoiceLiveServerEventResponseTextDelta textDelta => textDelta.ResponseId,
                    VoiceLiveServerEventResponseAudioDelta audioDelta => audioDelta.ResponseId,
                    VoiceLiveServerEventResponseAudioTranscriptDelta transcriptDelta => transcriptDelta.ResponseId,
                    ResponseAnimationBlendshapeDeltaEvent blendshapeDelta => blendshapeDelta.ResponseId,
                    ResponseAnimationVisemeDeltaEvent visemeDelta => visemeDelta.ResponseId,
                    ResponseAudioTimestampDeltaEvent timestampDelta => timestampDelta.ResponseId,
                    _ => null
                };
            }
        }

        /// <summary>
        /// Gets the item ID associated with this delta.
        /// </summary>
        public string ItemId
        {
            get
            {
                return _serverEvent switch
                {
                    VoiceLiveServerEventResponseTextDelta textDelta => textDelta.ItemId,
                    VoiceLiveServerEventResponseAudioDelta audioDelta => audioDelta.ItemId,
                    VoiceLiveServerEventResponseAudioTranscriptDelta transcriptDelta => transcriptDelta.ItemId,
                    ResponseAnimationBlendshapeDeltaEvent blendshapeDelta => blendshapeDelta.ItemId,
                    ResponseAnimationVisemeDeltaEvent visemeDelta => visemeDelta.ItemId,
                    ResponseAudioTimestampDeltaEvent timestampDelta => timestampDelta.ItemId,
                    _ => null
                };
            }
        }

        /// <summary>
        /// Gets the output index for this delta.
        /// </summary>
        public int? OutputIndex
        {
            get
            {
                return _serverEvent switch
                {
                    VoiceLiveServerEventResponseTextDelta textDelta => textDelta.OutputIndex,
                    VoiceLiveServerEventResponseAudioDelta audioDelta => audioDelta.OutputIndex,
                    VoiceLiveServerEventResponseAudioTranscriptDelta transcriptDelta => transcriptDelta.OutputIndex,
                    ResponseAnimationBlendshapeDeltaEvent blendshapeDelta => blendshapeDelta.OutputIndex,
                    ResponseAnimationVisemeDeltaEvent visemeDelta => visemeDelta.OutputIndex,
                    ResponseAudioTimestampDeltaEvent timestampDelta => timestampDelta.OutputIndex,
                    _ => null
                };
            }
        }

        /// <summary>
        /// Gets the content index for this delta.
        /// </summary>
        public int? ContentIndex
        {
            get
            {
                return _serverEvent switch
                {
                    VoiceLiveServerEventResponseTextDelta textDelta => textDelta.ContentIndex,
                    VoiceLiveServerEventResponseAudioDelta audioDelta => audioDelta.ContentIndex,
                    VoiceLiveServerEventResponseAudioTranscriptDelta transcriptDelta => transcriptDelta.ContentIndex,
                    ResponseAnimationBlendshapeDeltaEvent blendshapeDelta => blendshapeDelta.ContentIndex,
                    ResponseAnimationVisemeDeltaEvent visemeDelta => visemeDelta.ContentIndex,
                    ResponseAudioTimestampDeltaEvent timestampDelta => timestampDelta.ContentIndex,
                    _ => null
                };
            }
        }

        /// <summary>
        /// Gets the text delta, if this is a text update.
        /// </summary>
        public string TextDelta
        {
            get
            {
                return _serverEvent switch
                {
                    VoiceLiveServerEventResponseTextDelta textDelta => textDelta.Delta,
                    VoiceLiveServerEventResponseAudioTranscriptDelta transcriptDelta => transcriptDelta.Delta,
                    _ => null
                };
            }
        }

        /// <summary>
        /// Gets the audio delta bytes, if this is an audio update.
        /// </summary>
        public BinaryData AudioDelta
        {
            get
            {
                return _serverEvent switch
                {
                    VoiceLiveServerEventResponseAudioDelta audioDelta => audioDelta.Delta,
                    _ => null
                };
            }
        }

        /// <summary>
        /// Gets the blendshape candidates, if this is an animation blendshape update.
        /// </summary>
        public IReadOnlyList<EmotionCandidate> BlendshapeCandidates
        {
            get
            {
                return _serverEvent switch
                {
                    ResponseAnimationBlendshapeDeltaEvent blendshapeDelta => blendshapeDelta.Delta,
                    _ => null
                };
            }
        }

        /// <summary>
        /// Gets the viseme candidates, if this is an animation viseme update.
        /// </summary>
        public IReadOnlyList<EmotionCandidate> VisemeCandidates
        {
            get
            {
                return _serverEvent switch
                {
                    ResponseAnimationVisemeDeltaEvent visemeDelta => visemeDelta.Delta,
                    _ => null
                };
            }
        }

        /// <summary>
        /// Gets the timestamp delta, if this is an audio timestamp update.
        /// </summary>
        public int? TimestampDelta
        {
            get
            {
                return _serverEvent switch
                {
                    ResponseAudioTimestampDeltaEvent timestampDelta => timestampDelta.Delta,
                    _ => null
                };
            }
        }

        /// <summary>
        /// Gets the timestamp type, if this is an audio timestamp update.
        /// </summary>
        public ResponseAudioTimestampDeltaEventTimestampType? TimestampType
        {
            get
            {
                return _serverEvent switch
                {
                    ResponseAudioTimestampDeltaEvent timestampDelta => timestampDelta.TimestampType,
                    _ => null
                };
            }
        }

        /// <summary>
        /// Gets a value indicating whether this update contains text data.
        /// </summary>
        public bool IsTextDelta => Kind == VoiceLiveUpdateKind.ResponseTextDelta || Kind == VoiceLiveUpdateKind.ResponseAudioTranscriptDelta;

        /// <summary>
        /// Gets a value indicating whether this update contains audio data.
        /// </summary>
        public bool IsAudioDelta => Kind == VoiceLiveUpdateKind.ResponseAudioDelta;

        /// <summary>
        /// Gets a value indicating whether this update contains animation blendshape data.
        /// </summary>
        public bool IsBlendshapeDelta => Kind == VoiceLiveUpdateKind.ResponseAnimationBlendshapesDelta;

        /// <summary>
        /// Gets a value indicating whether this update contains animation viseme data.
        /// </summary>
        public bool IsVisemeDelta => Kind == VoiceLiveUpdateKind.ResponseAnimationVisemeDelta;

        /// <summary>
        /// Gets a value indicating whether this update contains audio timestamp data.
        /// </summary>
        public bool IsTimestampDelta => Kind == VoiceLiveUpdateKind.ResponseAudioTimestampDelta;

        /// <summary>
        /// Gets a value indicating whether this update contains audio transcript data.
        /// </summary>
        public bool IsTranscriptDelta => Kind == VoiceLiveUpdateKind.ResponseAudioTranscriptDelta;
    }
}