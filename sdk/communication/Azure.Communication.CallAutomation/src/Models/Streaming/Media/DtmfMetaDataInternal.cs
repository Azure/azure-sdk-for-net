// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json.Serialization;

namespace Azure.Communication.CallAutomation
{
    internal class DtmfMetaDataInternal
    {
        /// <summary>
        /// The dtmf data in base64 byte.
        /// </summary>
        [JsonPropertyName("data")]
        public string Data { get; set; }

        /// <summary>
        /// The timestamp indicating when the media content was received by the bot,
        /// or if the bot is sending media, the timestamp of when the media was sourced.
        /// The format is ISO 8601 (yyyy-mm-ddThh:mm).
        /// </summary>
        [JsonPropertyName("timestamp")]
        public DateTimeOffset Timestamp { get; set; }

        /// <summary>
        /// The raw ID of the participant.
        /// </summary>
        [JsonPropertyName("participantRawID")]
        public string Participant { get; set; }
    }
}
