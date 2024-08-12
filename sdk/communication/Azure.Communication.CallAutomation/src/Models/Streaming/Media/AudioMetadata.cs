// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Metadata for Audio Streaming.
    /// </summary>
    public class AudioMetadata : StreamingData
    {
        /// <summary>
        /// Subscription Id.
        /// </summary>
        [JsonPropertyName("subscriptionId")]
        public string MediaSubscriptionId { get; set; }

        /// <summary>
        /// The Encoding.
        /// </summary>
        [JsonPropertyName("encoding")]
        public string Encoding { get; set; }
        /// <summary>
        /// Sample Rate.
        /// </summary>
        [JsonPropertyName("sampleRate")]
        public int SampleRate { get; set; }
        /// <summary>
        /// Channels.
        /// </summary>
        [JsonPropertyName("channels")]
        public int Channels { get; set; }
        /// <summary>
        /// Length.
        /// </summary>
        [JsonPropertyName("length")]
        public int Length { get; set; }
    }
}
