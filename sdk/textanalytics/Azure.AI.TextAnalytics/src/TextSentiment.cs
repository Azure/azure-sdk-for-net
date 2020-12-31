// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// The predicted sentiment for a given document.
    /// </summary>
    [CodeGenModel("DocumentSentimentValue")]
    public enum TextSentiment
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

        /// <summary>
        /// Indicates that the document contains mixed sentiments.
        /// </summary>
        Mixed,
    }
}
