// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    public struct Sentiment
    {
        /// <summary>
        /// Gets redicted sentiment for document.
        /// </summary>
        public SentimentClass SentimentClass { get; internal set; }

        /// <summary>
        /// </summary>
        public double PositiveScore { get; internal set; }

        /// <summary>
        /// </summary>
        public double NeutralScore { get; internal set; }

        /// <summary>
        /// </summary>
        public double NegativeScore { get; internal set; }

        /// <summary>
        /// Gets start position (in Unicode characters) for the entity
        /// match text.
        /// Start position (in Unicode characters) for the entity text.
        /// </summary>
        public int Offset { get; internal set; }

        /// <summary>
        /// Gets length (in Unicode characters) for the entity match
        /// text.
        /// Length (in Unicode characters) for the entity text.
        /// </summary>
        public int Length { get; internal set; }
    }
}
