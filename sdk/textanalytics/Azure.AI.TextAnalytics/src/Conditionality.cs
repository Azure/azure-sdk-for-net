// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.TextAnalytics.Models
{
    [CodeGenModel("Conditionality")]
    internal enum Conditionality
    {
				/// <summary> Hypothetical. </summary>
        Hypothetical,
        /// <summary> Conditional. </summary>
        Conditional
    }
}
