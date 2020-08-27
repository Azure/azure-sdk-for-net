// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Specialized types of Sentiment Analysis, like for example Opinion Mining.
    /// </summary>
    [Flags]
    public enum AnalyzeSentimentType
    {
        /// <summary>
        /// Sentiment analysis for documents and its sentences.
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
