// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Determines the condition of the <see cref="HealthcareEntityAssertion"/>
    /// </summary>
    [CodeGenModel("Conditionality")]
    public enum Conditionality
    {
        /// <summary> Hypothetical. </summary>
        Hypothetical,
        /// <summary> Conditional. </summary>
        Conditional
    }
}
