// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Monitor.Models
{
    internal static partial class MonitorAggregationTypeExtensions
    {
        public static string ToSerialString(this MonitorAggregationType value) => value.ToString();

        public static MonitorAggregationType ToMonitorAggregationType(this string value) => new MonitorAggregationType(value);
    }
}
