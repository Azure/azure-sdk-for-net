// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Streaming Transcription.
    /// </summary>
    internal class TranscriptionDataInternal
    {
        /// <summary>
        /// The display form of the recognized word
        /// </summary>
        [JsonPropertyName("text")]
        public string Text { get; set; }

        /// <summary>
        /// The format of text
        /// </summary>
        [JsonPropertyName("format")]
        public string Format { get; set; }

        /// <summary>
        /// Confidence of recognition of the whole phrase, from 0.0 (no confidence) to 1.0 (full confidence)
        /// </summary>
        [JsonPropertyName("confidence")]
        public double Confidence { get; set; }

        /// <summary>
        /// The position of this payload
        /// </summary>

        [JsonPropertyName("offset")]
        public ulong Offset { get; set; }

        /// <summary>
        /// Duration in ticks. 1 tick = 100 nanoseconds.
        /// </summary>
        [JsonPropertyName("duration")]
        public ulong Duration { get; set; }

        /// <summary>
        /// The result for each word of the phrase
        /// </summary>
        [JsonPropertyName("words")]
        public IEnumerable<WordData> Words { get; set; }

        /// <summary>
        /// The identified speaker based on participant raw ID
        /// </summary>
        [JsonPropertyName("participantRawID")]
        public string ParticipantRawID { get; set; }

        /// <summary>
        /// Status of the result of transcription
        /// </summary>
        [JsonPropertyName("resultStatus")]
        public string ResultStatus { get; set; }
    }
}
