// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Monitor.Models
{
#pragma warning disable CS0618 // This file intentionally restores and bridges the obsolete enum surface.
    /// <summary> The aggregation type of the metric. </summary>
    [Obsolete("This API is no longer supported. Use MonitorMetricAggregationType for MonitorMetricDefinition and MonitorAggregationKind for SubscriptionScopeMetricDefinition instead.", false)]
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

        public static IReadOnlyList<MonitorAggregationType> ToLegacyAggregationTypes(IEnumerable<MonitorMetricAggregationType> values)
        {
            if (values is null)
            {
                return default;
            }

            List<MonitorAggregationType> result = new List<MonitorAggregationType>();
            foreach (MonitorMetricAggregationType value in values)
            {
                result.Add(ToLegacyAggregationType(value));
            }
            return result;
        }

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

        public static IEnumerable<MonitorMetricAggregationType> FromLegacyAggregationTypes(IEnumerable<MonitorAggregationType> values)
        {
            if (values is null)
            {
                return default;
            }

            List<MonitorMetricAggregationType> result = new List<MonitorMetricAggregationType>();
            foreach (MonitorAggregationType value in values)
            {
                result.Add(FromLegacyAggregationType(value));
            }
            return result;
        }

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

        public static IList<MonitorAggregationType> ToLegacyAggregationTypes(IEnumerable<MonitorAggregationKind> values)
        {
            if (values is null)
            {
                return default;
            }

            List<MonitorAggregationType> result = new List<MonitorAggregationType>();
            foreach (MonitorAggregationKind value in values)
            {
                result.Add(ToLegacyAggregationType(value));
            }
            return result;
        }
    }
#pragma warning restore SA1649
#pragma warning restore CS0618
}
