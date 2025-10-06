// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.Monitor.Models
{
    internal static partial class MonitorConditionOperatorExtensions
    {
        // Fix for issue: https://github.com/Azure/azure-sdk-for-net/issues/41377
        // The swagger has enum value `Equals`, but the service response is `Equal`
        public static string ToSerialString(this MonitorConditionOperator value) => value switch
        {
            MonitorConditionOperator.GreaterThan => "GreaterThan",
            MonitorConditionOperator.GreaterThanOrEqual => "GreaterThanOrEqual",
            MonitorConditionOperator.LessThan => "LessThan",
            MonitorConditionOperator.LessThanOrEqual => "LessThanOrEqual",
            // Original enum value is `Equals`, changed to actual service response `Equal`
            MonitorConditionOperator.EqualsValue => "Equal",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown MonitorConditionOperator value.")
        };

        public static MonitorConditionOperator ToMonitorConditionOperator(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "GreaterThan")) return MonitorConditionOperator.GreaterThan;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "GreaterThanOrEqual")) return MonitorConditionOperator.GreaterThanOrEqual;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "LessThan")) return MonitorConditionOperator.LessThan;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "LessThanOrEqual")) return MonitorConditionOperator.LessThanOrEqual;
            // Original enum value is `Equals`, changed to actual service response `Equal`
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Equal")) return MonitorConditionOperator.EqualsValue;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown MonitorConditionOperator value.");
        }
    }
}
