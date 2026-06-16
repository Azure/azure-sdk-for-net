// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.Monitor.Models
{
#pragma warning disable CS0618 // This bridge intentionally serializes the obsolete restored enum.
    internal static partial class MonitorAggregationTypeExtensions
    {
        public static string ToSerialString(this MonitorAggregationType value) => value.ToString();

        public static MonitorAggregationType ToMonitorAggregationType(this string value) => (MonitorAggregationType)Enum.Parse(typeof(MonitorAggregationType), value);
    }
#pragma warning restore CS0618
}
