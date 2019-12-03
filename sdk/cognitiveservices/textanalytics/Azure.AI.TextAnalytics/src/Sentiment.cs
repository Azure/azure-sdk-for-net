// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    public readonly struct Sentiment
    {
        internal Sentiment(SentimentClass sentimentClass, double positiveScore, double neutralScore, double negativeScore, int offset, int length)
        {
            SentimentClass = sentimentClass;
            PositiveScore = positiveScore;
            NeutralScore = neutralScore;
            NegativeScore = negativeScore;
            Offset = offset;
            Length = length;
        }

        /// <summary>
        /// Gets redicted sentiment for document.
        /// </summary>
        public SentimentClass SentimentClass { get; }

        /// <summary>
        /// </summary>
        public double PositiveScore { get; }

        /// <summary>
        /// </summary>
        public double NeutralScore { get; }

        /// <summary>
        /// </summary>
        public double NegativeScore { get; }

        /// <summary>
        /// Gets start position (in Unicode characters) for the entity
        /// match text.
        /// Start position (in Unicode characters) for the entity text.
        /// </summary>
        public int Offset { get; }

        /// <summary>
        /// Gets length (in Unicode characters) for the entity match
        /// text.
        /// Length (in Unicode characters) for the entity text.
        /// </summary>
        public int Length { get; }
    }
}
