// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// The sentiment confidence scores, by sentiment.
    /// </summary>
    [CodeGenModel("SentimentConfidenceScorePerLabel")]
    public partial class SentimentConfidenceScores
    {
        internal SentimentConfidenceScores(double positive, double neutral, double negative)
        {
            Positive = positive;
            Neutral = neutral;
            Negative = negative;
        }

        /// <summary>
        /// Gets a score between 0 and 1, indicating the confidence that the
        /// sentiment of the analyzed text is positive.
        /// </summary>
        public double Positive { get; }

        /// <summary>
        /// Gets a score between 0 and 1, indicating the confidence that the
        /// sentiment of the analyzed text is neutral.
        /// </summary>
        public double Neutral { get; }

        /// <summary>
        /// Gets a score between 0 and 1, indicating the confidence that the
        /// sentiment of the analyzed text is negative.
        /// </summary>
        public double Negative { get; }
    }
}
