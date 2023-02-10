// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// Streaming audio.
    /// </summary>
    internal class MediaStreamingAudioInternal
    {
        /// <summary>
        /// The audio data.
        /// </summary>
        [JsonPropertyName("data")]
        public byte[] Data { get; set; }

        /// <summary>
        /// The timestamp of thwn the media was sourced.
        /// </summary>
        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Participant ID
        /// </summary>
        [JsonPropertyName("participantId")]
        public string ParticipantId { get; set; }
        /// <summary>
        /// Indicates if the received audio buffer contains only silence.
        /// </summary>
        [JsonPropertyName("isSilence")]
        public bool IsSilence { get; set; }
    }
}
