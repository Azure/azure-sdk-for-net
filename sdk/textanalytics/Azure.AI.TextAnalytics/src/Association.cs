// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Determines the association of <see cref="HealthcareEntityAssertion"/>
    /// </summary>
    [CodeGenModel("Association")]
    public enum Association
    {
        /// <summary> subject. </summary>
        Subject,
        /// <summary> other. </summary>
        Other
    }
}
