// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Determines the condition of the <see cref="HealthcareEntityAssertion"/>.
    /// For example, "If the patient has a fever, he has pneumonia", the diagnosis of pneumonia
    /// is 'conditional' on whether the patient has a fever.
    /// </summary>
    [CodeGenModel("Conditionality")]
    public enum EntityConditionality
    {
        /// <summary> Hypothetical. </summary>
        Hypothetical,
        /// <summary> Conditional. </summary>
        Conditional
    }
}
