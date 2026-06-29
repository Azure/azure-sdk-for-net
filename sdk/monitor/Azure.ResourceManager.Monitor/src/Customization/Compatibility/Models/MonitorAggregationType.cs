// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Monitor.Models
{
    /// <summary> The aggregation type of the metric. </summary>
    [Obsolete("This type is no longer supported. Use MonitorMetricAggregationType for MonitorMetricDefinition and MonitorAggregationKind for SubscriptionScopeMetricDefinition instead.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum MonitorAggregationType
    {
        /// <summary> None. </summary>
        None = 0,
        /// <summary> Average. </summary>
        Average = 1,
        /// <summary> Count. </summary>
        Count = 2,
        /// <summary> Minimum. </summary>
        Minimum = 3,
        /// <summary> Maximum. </summary>
        Maximum = 4,
        /// <summary> Total. </summary>
        Total = 5
    }
}
