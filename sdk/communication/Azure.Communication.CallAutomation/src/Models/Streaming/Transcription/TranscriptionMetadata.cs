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
        internal TranscriptionMetadata(TranscriptionMetadataInternal transcriptionMetadataInternal)
        {
            TranscriptionSubscriptionId = transcriptionMetadataInternal.TranscriptionSubscriptionId;
            Locale = transcriptionMetadataInternal.Locale;
            CallConnectionId = transcriptionMetadataInternal.CallConnectionId;
            CorrelationId = transcriptionMetadataInternal.CorrelationId;
            SpeechRecognitionModelEndpointId = transcriptionMetadataInternal.SpeechRecognitionModelEndpointId;
            EnableSentimentAnalysis = transcriptionMetadataInternal.EnableSentimentAnalysis;
            PiiRedactionOptions = transcriptionMetadataInternal.PiiRedactionOptions;
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
        public string CorrelationId { get; }

        /// <summary>
        /// The custom speech recognition model endpoint id
        /// </summary>
        public string SpeechRecognitionModelEndpointId { get; }

        /// <summary>
        /// Gets or sets a value indicating if sentiment analysis should be used
        /// </summary>
        public bool? EnableSentimentAnalysis { get; }

        /// <summary>
        /// Gets or sets Options for Pii redaction
        /// </summary>
        public PiiRedactionOptions PiiRedactionOptions { get; }
    }
}
