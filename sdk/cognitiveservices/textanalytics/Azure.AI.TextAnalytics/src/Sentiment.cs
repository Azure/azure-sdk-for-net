// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    public struct Sentiment
    {
        /// <summary>
        /// Predicted sentiment for document.
        /// </summary>
        public SentimentClass SentimentClass { get; set; }

        /// <summary>
        /// </summary>
        public double PositiveScore { get; set; }

        /// <summary>
        /// </summary>
        public double NeutralScore { get; set; }

        /// <summary>
        /// </summary>
        public double NegativeScore { get; set; }

        /// <summary>
        /// Gets or sets start position (in Unicode characters) for the entity
        /// match text.
        /// Start position (in Unicode characters) for the entity text.
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// Gets or sets length (in Unicode characters) for the entity match
        /// text.
        /// Length (in Unicode characters) for the entity text.
        /// </summary>
        public int Length { get; set; }
    }
}
