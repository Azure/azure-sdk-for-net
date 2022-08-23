// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json.Serialization;

namespace Azure.Communication.CallingServer.Models.Streaming
{
    /// <summary>
    /// Streaming audio.
    /// </summary>
    public class StreamingAudio
    {
        /// <summary>
        /// Base64 Encoded audio buffer data .
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
