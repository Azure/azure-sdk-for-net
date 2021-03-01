// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Determines the Certainity of the <see cref="HealthcareEntityAssertion"/>
    /// It can be Positive, PositivePossible, NuetralPossible, NegativePossible and Negative.
    /// </summary>
    [CodeGenModel("Certainty")]
    public enum Certainty
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
