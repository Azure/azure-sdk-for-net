// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.Metrics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.NetworkSdkStats
{
    /// <summary>
    /// Provides the OpenTelemetry <see cref="Meter"/> and instruments used to publish
    /// short-interval Network SDKStats for requests and individual telemetry items.
    /// </summary>
    /// <remarks>
    /// Each stats owner has its own instruments so another owner's reader cannot export its counts.
    /// </remarks>
    internal sealed class NetworkSdkStatsMeters : IDisposable
    {
        internal const string ItemSuccessName = "Item_Success_Count";
        internal const string ItemDroppedName = "Item_Dropped_Count";
        internal const string ItemRetryName = "Item_Retry_Count";

        public readonly Meter Meter = new(StatsbeatConstants.NetworkSdkStatsMeterName, "1.0.0");

        public Counter<long> RequestSuccessCount { get; }
        public Counter<long> RequestFailureCount { get; }
        public Histogram<double> RequestDuration { get; }
        public Counter<long> RetryCount { get; }
        public Counter<long> ThrottleCount { get; }
        public Counter<long> ExceptionCount { get; }
        public Counter<long> ItemSuccessCount { get; }
        public Counter<long> ItemDroppedCount { get; }
        public Counter<long> ItemRetryCount { get; }

        public NetworkSdkStatsMeters()
        {
            RequestSuccessCount = Meter.CreateCounter<long>(
                "Request_Success_Count",
                description: "Count of requests accepted by the destination ingestion endpoint.");

            RequestFailureCount = Meter.CreateCounter<long>(
                "Request_Failure_Count",
                description: "Count of requests that returned a non-retryable, non-throttling failure from the destination ingestion endpoint.");

            RequestDuration = Meter.CreateHistogram<double>(
                "Request_Duration",
                unit: "ms",
                description: "Duration of requests to the destination ingestion endpoint.");

            RetryCount = Meter.CreateCounter<long>(
                "Retry_Count",
                description: "Count of requests for which the destination ingestion endpoint returned a retryable response.");

            ThrottleCount = Meter.CreateCounter<long>(
                "Throttle_Count",
                description: "Count of requests for which the destination ingestion endpoint returned a quota / rate-limit response.");

            ExceptionCount = Meter.CreateCounter<long>(
                "Exception_Count",
                description: "Count of requests that failed with an exception (no response code received).");
            ItemSuccessCount = Meter.CreateCounter<long>(ItemSuccessName, description: "Count of telemetry items accepted by ingestion.");
            ItemDroppedCount = Meter.CreateCounter<long>(ItemDroppedName, description: "Count of telemetry items discarded without another send attempt.");
            ItemRetryCount = Meter.CreateCounter<long>(ItemRetryName, description: "Count of telemetry items scheduled for another send attempt.");
        }

        public void Dispose() => Meter.Dispose();
    }
}
