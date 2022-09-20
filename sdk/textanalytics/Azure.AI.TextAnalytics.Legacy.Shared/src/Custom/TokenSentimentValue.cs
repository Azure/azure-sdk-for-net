// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.TextAnalytics.Legacy.Models
{
    /// <summary> Targeted sentiment in the sentence. </summary>
    [CodeGenModel("TokenSentimentValue")]
    internal enum TokenSentimentValue
    {
        /// <summary> positive. </summary>
        Positive,
        /// <summary> mixed. </summary>
        Mixed,
        /// <summary> negative. </summary>
        Negative
    }
}
/**/
