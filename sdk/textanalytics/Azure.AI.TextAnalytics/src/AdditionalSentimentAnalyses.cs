 // Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Additional types of Sentiment Analysis to be applied to the
    /// AnalyzeSentiment method, like for example Opinion Mining.
    /// </summary>
    [Flags]
    public enum AdditionalSentimentAnalyses
    {
        /// <summary>
        /// Use standard sentiment analysis for documents and its sentences.
        /// </summary>
        None = 0,

        /// <summary>
        /// Sentiment analysis results with Opinion Mining,
        /// also known as Aspect-based Sentiment Analysis.
        /// Only available for Text Analytics Service version v3.1-preview.1 and above.
        /// </summary>
        OpinionMining = 1,
    }
}
