// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.Metrics;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.CustomerSdkStats
{
    /// <summary>
    /// Provides OpenTelemetry meters for customer SDK stats.
    /// </summary>
    internal static class CustomerSdkStatsMeters
    {
        /// <summary>
        /// The meter name for customer SDK stats.
        /// </summary>
        public const string MeterName = "Azure.Monitor.OpenTelemetry.Exporter.CustomerSdkStats";

        /// <summary>
        /// The meter instance for customer SDK stats.
        /// </summary>
        public static readonly Meter Meter = new(MeterName, "1.0.0");

        /// <summary>
        /// Counter for successful telemetry items sent to Application Insights.
        /// </summary>
        public static readonly Counter<long> ItemSuccessCount = Meter.CreateCounter<long>(
            "preview.item.success.count",
            description: "Count of successful telemetry items sent to Application Insights");

        /// <summary>
        /// Counter for dropped telemetry items.
        /// </summary>
        public static readonly Counter<long> ItemDroppedCount = Meter.CreateCounter<long>(
            "preview.item.dropped.count",
            description: "Count of dropped telemetry items");

        /// <summary>
        /// Counter for retried telemetry items.
        /// </summary>
        public static readonly Counter<long> ItemRetryCount = Meter.CreateCounter<long>(
            "preview.item.retry.count",
            description: "Count of retried telemetry items");
    }
}
