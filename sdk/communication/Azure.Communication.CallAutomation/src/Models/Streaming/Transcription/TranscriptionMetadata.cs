// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
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
            Locales = transcriptionMetadataInternal.Locales;
            CallConnectionId = transcriptionMetadataInternal.CallConnectionId;
            CorrelationId = transcriptionMetadataInternal.CorrelationId;
            SpeechRecognitionModelEndpointId = transcriptionMetadataInternal.SpeechRecognitionModelEndpointId;
            EnableSentimentAnalysis = transcriptionMetadataInternal.EnableSentimentAnalysis;
            PiiRedactionOptions = ConvertToPiiRedactionOptions(transcriptionMetadataInternal.PiiRedactionOptions);
        }
        /// <summary>
        /// Transcription Subscription Id.
        /// </summary>
        public string TranscriptionSubscriptionId { get; }

        /// <summary>
        /// The target locale in which the translated text needs to be
        /// </summary>
        public string Locale { get; }

        /// <summary> List of languages for Language Identification. </summary>
        public IList<string> Locales { get; }

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

        private static PiiRedactionOptions ConvertToPiiRedactionOptions(PiiRedactionOptionsInternal piiRedactionOptions)
        {
            return new PiiRedactionOptions() { Enable = piiRedactionOptions.Enable, RedactionType = piiRedactionOptions.RedactionType };
        }
    }
}
