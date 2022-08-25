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
        [JsonConverter(typeof(BinaryDataConverter))]
        public BinaryData Data { get; set; }

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

        private class BinaryDataConverter : JsonConverter<BinaryData>
        {
            public override BinaryData Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                return new BinaryData(reader.GetBytesFromBase64());
            }

            public override void Write(Utf8JsonWriter writer, BinaryData value, JsonSerializerOptions options)
            {
                writer.WriteBase64StringValue(value);
            }
        }
    }
}
