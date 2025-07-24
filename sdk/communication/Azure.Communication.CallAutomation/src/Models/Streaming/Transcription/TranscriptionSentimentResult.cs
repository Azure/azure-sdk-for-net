// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Sentiment analysis result for a transcription.
    /// </summary>
    public class TranscriptionSentimentResult
    {
        /// <summary>
        /// sentiment
        /// </summary>
        [JsonPropertyName("sentiment")]
        public string TranscriptionSentiment { get; set; }
    }
}
