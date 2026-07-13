// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Monitor.Models
{
#pragma warning disable CS0618 // This helper intentionally bridges the obsolete enum to the generated replacement.
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
#pragma warning restore CS0618
}
