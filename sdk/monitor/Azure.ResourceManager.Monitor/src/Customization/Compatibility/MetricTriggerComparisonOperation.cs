// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Monitor.Models
{
#pragma warning disable CS0618 // This file intentionally restores and bridges the obsolete enum surface.
    // The generated comparison enum is intentionally renamed to MetricTriggerComparisonOperator.
    // Keep this legacy enum with stable numeric values because enum numeric values are binary-compatible API.
    /// <summary> The operator that is used to compare the metric data and the threshold. </summary>
    [Obsolete("This API is no longer supported. Use MetricTriggerComparisonOperator instead.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum MetricTriggerComparisonOperation
    {
        /// <summary> Equals. </summary>
        EqualsValue = 0,
        /// <summary> NotEquals. </summary>
        NotEquals = 1,
        /// <summary> GreaterThan. </summary>
        GreaterThan = 2,
        /// <summary> GreaterThanOrEqual. </summary>
        GreaterThanOrEqual = 3,
        /// <summary> LessThan. </summary>
        LessThan = 4,
        /// <summary> LessThanOrEqual. </summary>
        LessThanOrEqual = 5
    }

#pragma warning disable SA1649 // Keep the compatibility helper next to the restored enum shim.
    internal static class MetricTriggerComparisonOperationHelper
    {
        public static MetricTriggerComparisonOperation ToLegacyComparisonOperation(MetricTriggerComparisonOperator value) => value switch
        {
            MetricTriggerComparisonOperator.NotEquals => MetricTriggerComparisonOperation.NotEquals,
            MetricTriggerComparisonOperator.GreaterThan => MetricTriggerComparisonOperation.GreaterThan,
            MetricTriggerComparisonOperator.GreaterThanOrEqual => MetricTriggerComparisonOperation.GreaterThanOrEqual,
            MetricTriggerComparisonOperator.LessThan => MetricTriggerComparisonOperation.LessThan,
            MetricTriggerComparisonOperator.LessThanOrEqual => MetricTriggerComparisonOperation.LessThanOrEqual,
            _ => MetricTriggerComparisonOperation.EqualsValue
        };

        public static MetricTriggerComparisonOperator FromLegacyComparisonOperation(MetricTriggerComparisonOperation value) => value switch
        {
            MetricTriggerComparisonOperation.NotEquals => MetricTriggerComparisonOperator.NotEquals,
            MetricTriggerComparisonOperation.GreaterThan => MetricTriggerComparisonOperator.GreaterThan,
            MetricTriggerComparisonOperation.GreaterThanOrEqual => MetricTriggerComparisonOperator.GreaterThanOrEqual,
            MetricTriggerComparisonOperation.LessThan => MetricTriggerComparisonOperator.LessThan,
            MetricTriggerComparisonOperation.LessThanOrEqual => MetricTriggerComparisonOperator.LessThanOrEqual,
            _ => MetricTriggerComparisonOperator.Equals
        };
    }
#pragma warning restore SA1649
#pragma warning restore CS0618
}
