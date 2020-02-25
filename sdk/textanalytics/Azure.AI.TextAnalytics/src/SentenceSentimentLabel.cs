// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// The predicted sentiment label for a given sentence.
    /// </summary>
    public enum SentenceSentimentLabel
    {
        /// <summary>
        /// Indicates that the sentiment is positive.
        /// </summary>
        Positive,

        /// <summary>
        /// Indicates that the sentiment is neutral.
        /// </summary>
        Neutral,

        /// <summary>
        /// Indicates that the sentiment is negative.
        /// </summary>
        Negative,
    }
}
