// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json.Serialization;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Streaming Audio.
    /// </summary>
    internal class AudioDataInternal
    {
        /// <summary>
        /// The audio data in base64 string.
        /// </summary>
        [JsonPropertyName("data")]
        public string Data { get; set; }

        /// <summary>
        /// The timestamp of thwn the media was sourced.
        /// </summary>
        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Participant ID.
        /// </summary>
        [JsonPropertyName("participantRawID")]
        public string ParticipantRawId { get; set; }
        /// <summary>
        /// Indicates if the received audio buffer contains only silence.
        /// </summary>
        [JsonPropertyName("silent")]
        public bool Silent { get; set; }
        /// <summary>
        /// Mark this audio data which signals the player when it reaches the mark position
        /// </summary>
        [JsonPropertyName("mark")]
        public MarkAudio Mark { get; set; }
    }
}
