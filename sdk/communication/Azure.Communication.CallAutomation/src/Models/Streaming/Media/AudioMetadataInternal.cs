// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Internal Metadata model for Audio Streaming.
    /// </summary>
    internal class AudioMetadataInternal
    {
        /// <summary>
        /// A unique identifier for the media subscription.
        /// </summary>
        [JsonPropertyName("subscriptionId")]
        public string MediaSubscriptionId { get; set; }

        /// <summary>
        /// The format used to encode the audio. Currently, only "pcm" (Pulse Code Modulation) is supported.
        /// </summary>
        [JsonPropertyName("encoding")]
        public string Encoding { get; set; }
        /// <summary>
        /// The number of samples per second in the audio. Supported values are 16kHz or 24kHz.
        /// </summary>
        [JsonPropertyName("sampleRate")]
        public int SampleRate { get; set; }
        /// <summary>
        /// Specifies the number of audio channels in the audio configuration.
        /// Currently, only "mono" (single channel) is supported.
        /// </summary>
        [JsonPropertyName("channels")]
        public int Channels { get; set; }
        /// <summary>
        /// The size of the audio data being sent, based on the sample rate and duration.
        /// </summary>
        [JsonPropertyName("length")]
        public int Length { get; set; }
    }
}
