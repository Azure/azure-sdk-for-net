// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.TextAnalytics.Legacy.Models
{
    /// <summary> Predicted sentiment for document (Negative, Neutral, Positive, or Mixed). </summary>
    [CodeGenModel("DocumentSentimentValue")]
    internal enum DocumentSentimentValue
    {
        /// <summary> positive. </summary>
        Positive,
        /// <summary> neutral. </summary>
        Neutral,
        /// <summary> negative. </summary>
        Negative,
        /// <summary> mixed. </summary>
        Mixed
    }
}
