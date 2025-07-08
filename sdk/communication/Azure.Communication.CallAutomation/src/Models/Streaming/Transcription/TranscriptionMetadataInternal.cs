// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Metadata for Transcription Streaming.
    /// </summary>
    internal class TranscriptionMetadataInternal
    {
        /// <summary>
        /// Transcription Subscription Id.
        /// </summary>
        [JsonPropertyName("subscriptionId")]
        public string TranscriptionSubscriptionId { get; set; }

        /// <summary>
        /// The target locale in which the translated text needs to be
        /// </summary>
        [JsonPropertyName("locale")]
        public string Locale { get; set; }

        /// <summary>
        /// call connection Id.
        /// </summary>
        [JsonPropertyName("callConnectionId")]
        public string CallConnectionId { get; set; }

        /// <summary>
        /// correlation Id.
        /// </summary>
        [JsonPropertyName("correlationId")]
        public string CorrelationId { get;  set; }

        /// <summary>
        /// The custom speech recognition model endpoint id
        /// </summary>
        [JsonPropertyName("speechRecognitionModelEndpointId")]
        public string SpeechRecognitionModelEndpointId { get; set; }
    }
}
