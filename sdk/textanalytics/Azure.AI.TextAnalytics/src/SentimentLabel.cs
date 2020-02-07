// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// The predicted sentiment label for a given span of text.
    /// </summary>
    public enum SentimentLabel
    #pragma warning restore
    {
        /// <summary>
        /// Indicates that the sentiment is positive.
        /// </summary>
        Positive,

        /// <summary>
        /// Indicates that the lacks a sentiment.
        /// </summary>
        Neutral,

        /// <summary>
        /// Indicates that the sentiment is negative.
        /// </summary>
        Negative,

        /// <summary>
        /// Indicates that the contains mixed sentiments.
        /// </summary>
        Mixed,
    }
}
