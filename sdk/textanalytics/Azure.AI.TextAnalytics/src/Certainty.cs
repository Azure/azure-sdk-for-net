// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.TextAnalytics.Models
{
    [CodeGenModel("Certainty")]
    internal enum Certainty
    {
        /// <summary> Positive. </summary>
        Positive,
        /// <summary> Positive Possible. </summary>
        PositivePossible,
        /// <summary> Neutral Possible. </summary>
        NeutralPossible,
        /// <summary> Negative Possible. </summary>
        NegativePossible,
        /// <summary> Negative. </summary>
        Negative
    }
}
