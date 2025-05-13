// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Metadata for Transcription Streaming.
    /// </summary>
    public class TranscriptionMetadata : StreamingData
    {
        /// <summary>
        /// Transcription Subscription Id.
        /// </summary>
        [JsonPropertyName("subscriptionId")]
        public string TranscriptionSubscriptionId { get; internal set; }

        /// <summary>
        /// The target locale in which the translated text needs to be
        /// </summary>
        [JsonPropertyName("locale")]
        public string Locale { get; internal set; }

        /// <summary>
        /// call connection Id.
        /// </summary>
        [JsonPropertyName("callConnectionId")]
        public string CallConnectionId { get; internal set; }

        /// <summary>
        /// correlation Id.
        /// </summary>
        [JsonPropertyName("correlationId")]
        public string CorrelationId { get; internal set; }
    }
}
