// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.TextAnalytics.Legacy.Models
{
    /// <summary> The predicted Sentiment for the sentence. </summary>
    [CodeGenModel("SentenceSentimentValue")]
    internal enum SentenceSentimentValue
    {
        /// <summary> positive. </summary>
        Positive,
        /// <summary> neutral. </summary>
        Neutral,
        /// <summary> negative. </summary>
        Negative
    }
}
