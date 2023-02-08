// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Language.Conversations
{
    /// <summary> Represents the confidence scores between 0 and 1 across all sentiment classes: positive, neutral, negative. </summary>
    public partial class SentimentConfidenceScores
    {
        /// <summary> Initializes a new instance of SentimentConfidenceScores. </summary>
        /// <param name="positive"> Confidence score for positive sentiment. </param>
        /// <param name="neutral"> Confidence score for neutral sentiment. </param>
        /// <param name="negative"> Confidence score for negative sentiment. </param>
        public SentimentConfidenceScores(double positive, double neutral, double negative)
        {
            Positive = positive;
            Neutral = neutral;
            Negative = negative;
        }

        /// <summary> Confidence score for positive sentiment. </summary>
        public double Positive { get; set; }
        /// <summary> Confidence score for neutral sentiment. </summary>
        public double Neutral { get; set; }
        /// <summary> Confidence score for negative sentiment. </summary>
        public double Negative { get; set; }
    }
}
