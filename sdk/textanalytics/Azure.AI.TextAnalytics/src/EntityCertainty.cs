// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Determines the Certainity of the <see cref="HealthcareEntityAssertion"/>
    /// For example, in "The patient may have a fever", the fever entity is not 100% certain, but is instead
    /// "PositivePossible".
    /// </summary>
    [CodeGenModel("Certainty")]
    public enum EntityCertainty
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
