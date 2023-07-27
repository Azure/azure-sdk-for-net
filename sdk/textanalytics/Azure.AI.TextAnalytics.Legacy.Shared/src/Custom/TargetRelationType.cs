// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.TextAnalytics.Legacy.Models
{
    /// <summary> The type related to the target. </summary>
    [CodeGenModel("TargetRelationType")]
    internal enum TargetRelationType
    {
        /// <summary> assessment. </summary>
        Assessment,
        /// <summary> target. </summary>
        Target
    }
}
