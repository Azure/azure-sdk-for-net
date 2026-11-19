// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
    /// Each stats owner has its own instruments so another owner's reader cannot export its counts.
    /// </remarks>
    internal sealed class NetworkSdkStatsMeters : IDisposable
    {
        public readonly Meter Meter = new(StatsbeatConstants.NetworkSdkStatsMeterName, "1.0.0");

        public Counter<long> RequestSuccessCount { get; }
        public Counter<long> RequestFailureCount { get; }
        public Histogram<double> RequestDuration { get; }
        public Counter<long> RetryCount { get; }
        public Counter<long> ThrottleCount { get; }
        public Counter<long> ExceptionCount { get; }

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
        }

        public void Dispose() => Meter.Dispose();
    }
}
