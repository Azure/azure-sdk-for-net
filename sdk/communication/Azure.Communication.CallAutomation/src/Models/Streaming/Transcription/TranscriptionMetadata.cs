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
        internal TranscriptionMetadata(TranscriptionMetadataInternal metaData)
        {
            TranscriptionSubscriptionId = metaData.TranscriptionSubscriptionId;
            Locale = metaData.Locale;
            CallConnectionId = metaData.CallConnectionId;
            CorrelationId = metaData.CorrelationId;
            SpeechRecognitionModelEndpointId = metaData.SpeechRecognitionModelEndpointId;
        }
        /// <summary>
        /// Transcription Subscription Id.
        /// </summary>
        public string TranscriptionSubscriptionId { get; }

        /// <summary>
        /// The target locale in which the translated text needs to be
        /// </summary>
        public string Locale { get; }

        /// <summary>
        /// call connection Id.
        /// </summary>
        public string CallConnectionId { get; }

        /// <summary>
        /// correlation Id.
        /// </summary>
        public string CorrelationId { get; internal set; }

        /// <summary>
        /// The custom speech recognition model endpoint id
        /// </summary>
        public string SpeechRecognitionModelEndpointId { get; internal set; }
    }
}
