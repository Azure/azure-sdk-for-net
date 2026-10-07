// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Monitor.Models
{
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
}
