// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Monitor.Models
{
    // TypeSpec no longer models the legacy AlertRule threshold condition shape.
    // Keep this obsolete enum because ThresholdRuleCondition exposed it in the stable API.
    /// <summary> The threshold rule condition time aggregation type. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This type is no longer supported.", false)]
    public enum ThresholdRuleConditionTimeAggregationType
    {
        /// <summary> Average. </summary>
        Average,
        /// <summary> Minimum. </summary>
        Minimum,
        /// <summary> Maximum. </summary>
        Maximum,
        /// <summary> Total. </summary>
        Total,
        /// <summary> Last. </summary>
        Last
    }
}
