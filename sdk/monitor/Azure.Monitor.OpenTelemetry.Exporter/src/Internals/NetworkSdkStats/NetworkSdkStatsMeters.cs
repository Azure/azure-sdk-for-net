// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.Metrics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.NetworkSdkStats
{
    /// <summary>
    /// Provides the OpenTelemetry <see cref="Meter"/> and instruments used to publish
    /// short-interval Network SDKStats (request success / failure / retry / throttle /
    /// exception counts and request duration). Metric names follow the SDKStats specification.
    /// </summary>
    /// <remarks>
    /// The meter is process-static (matching the existing Statsbeat meters); per-instance
    /// dimension context is added by <see cref="NetworkSdkStatsManager"/> at recording time.
    /// </remarks>
    internal static class NetworkSdkStatsMeters
    {
        public static readonly Meter Meter = new(StatsbeatConstants.NetworkSdkStatsMeterName, "1.0.0");

        public static readonly Counter<long> RequestSuccessCount = Meter.CreateCounter<long>(
            "Request_Success_Count",
            description: "Count of requests accepted by the destination ingestion endpoint.");

        public static readonly Counter<long> RequestFailureCount = Meter.CreateCounter<long>(
            "Request_Failure_Count",
            description: "Count of requests that returned a non-retryable, non-throttling failure from the destination ingestion endpoint.");

        public static readonly Histogram<double> RequestDuration = Meter.CreateHistogram<double>(
            "Request_Duration",
            unit: "ms",
            description: "Duration of requests to the destination ingestion endpoint.");

        public static readonly Counter<long> RetryCount = Meter.CreateCounter<long>(
            "Retry_Count",
            description: "Count of requests for which the destination ingestion endpoint returned a retryable response.");

        public static readonly Counter<long> ThrottleCount = Meter.CreateCounter<long>(
            "Throttle_Count",
            description: "Count of requests for which the destination ingestion endpoint returned a quota / rate-limit response.");

        public static readonly Counter<long> ExceptionCount = Meter.CreateCounter<long>(
            "Exception_Count",
            description: "Count of requests that failed with an exception (no response code received).");
    }
}
