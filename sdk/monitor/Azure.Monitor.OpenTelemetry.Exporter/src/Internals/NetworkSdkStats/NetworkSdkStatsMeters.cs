// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.Metrics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.NetworkSdkStats
{
    /// <summary>
    /// Provides the OpenTelemetry <see cref="Meter"/> and instruments used to publish
    /// short-interval Network SDKStats. Metric names follow the SDKStats specification.
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
    }
}
