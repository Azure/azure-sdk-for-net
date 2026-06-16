// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Monitor.Models
{
    /// <summary> The threshold rule condition time aggregation type. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This API is no longer supported.", false)]
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
