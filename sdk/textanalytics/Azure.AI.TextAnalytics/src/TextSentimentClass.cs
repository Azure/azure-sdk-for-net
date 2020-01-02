// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// The predicted sentiment for a given span of text.
    /// </summary>
    #pragma warning disable CA1717 // Only FlagsAttribute enums should have plural names
    public enum TextSentimentClass
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
