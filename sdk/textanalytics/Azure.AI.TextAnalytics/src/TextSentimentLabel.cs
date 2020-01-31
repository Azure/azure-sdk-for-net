// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// The predicted sentiment label for a given span of text.
    /// </summary>
    public enum TextSentimentLabel
    #pragma warning restore
    {
        /// <summary>
        /// Indicates that the text sentiment is positive.
        /// </summary>
        Positive,

        /// <summary>
        /// Indicates that the text lacks a sentiment.
        /// </summary>
        Neutral,

        /// <summary>
        /// Indicates that the text sentiment is negative.
        /// </summary>
        Negative,

        /// <summary>
        /// Indicates that the text contains mixed sentiments.
        /// </summary>
        Mixed,
    }
}
