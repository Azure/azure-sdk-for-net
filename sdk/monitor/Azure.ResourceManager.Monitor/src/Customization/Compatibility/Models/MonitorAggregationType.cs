// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
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

#pragma warning disable SA1649 // Keep the compatibility helper next to the restored enum shim.
#pragma warning disable CS0618 // This helper intentionally bridges the obsolete enum to generated replacement types.
    internal static class MonitorAggregationTypeHelper
    {
        public static MonitorAggregationType? ToLegacyAggregationType(MonitorMetricAggregationType? value)
            => value.HasValue ? ToLegacyAggregationType(value.Value) : null;

        public static MonitorAggregationType ToLegacyAggregationType(MonitorMetricAggregationType value) => value.ToString() switch
        {
            "Average" => MonitorAggregationType.Average,
            "Count" => MonitorAggregationType.Count,
            "Minimum" => MonitorAggregationType.Minimum,
            "Maximum" => MonitorAggregationType.Maximum,
            "Total" => MonitorAggregationType.Total,
            _ => MonitorAggregationType.None
        };

        public static MonitorMetricAggregationType? FromLegacyAggregationType(MonitorAggregationType? value)
            => value.HasValue ? FromLegacyAggregationType(value.Value) : null;

        public static MonitorMetricAggregationType FromLegacyAggregationType(MonitorAggregationType value) => value switch
        {
            MonitorAggregationType.Average => MonitorMetricAggregationType.Average,
            MonitorAggregationType.Count => MonitorMetricAggregationType.Count,
            MonitorAggregationType.Minimum => MonitorMetricAggregationType.Minimum,
            MonitorAggregationType.Maximum => MonitorMetricAggregationType.Maximum,
            MonitorAggregationType.Total => MonitorMetricAggregationType.Total,
            _ => MonitorMetricAggregationType.None
        };

        public static MonitorAggregationType? ToLegacyAggregationType(MonitorAggregationKind? value)
            => value.HasValue ? ToLegacyAggregationType(value.Value) : null;

        public static MonitorAggregationType ToLegacyAggregationType(MonitorAggregationKind value) => value.ToString() switch
        {
            "Average" => MonitorAggregationType.Average,
            "Count" => MonitorAggregationType.Count,
            "Minimum" => MonitorAggregationType.Minimum,
            "Maximum" => MonitorAggregationType.Maximum,
            "Total" => MonitorAggregationType.Total,
            _ => MonitorAggregationType.None
        };
    }
#pragma warning restore CS0618
#pragma warning restore SA1649
}
