// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Monitor.OpenTelemetry.Exporter.Internals.ShutdownPersistence;
using OpenTelemetry.Metrics;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    /// <summary>
    /// A metric reader that persists the final collection instead of transmitting it when the
    /// provider shuts down, so that process exit costs a file write rather than an ingestion round
    /// trip.
    /// </summary>
    /// <remarks>
    /// ForceFlush is deliberately not hooked: <c>MetricReader.OnCollect</c> cannot distinguish a
    /// caller-initiated flush from the periodic collection, so covering it would change every
    /// export.
    /// </remarks>
    internal sealed class AzureMonitorPeriodicExportingMetricReader : PeriodicExportingMetricReader
    {
        private readonly ITransmitter? _transmitter;

        public AzureMonitorPeriodicExportingMetricReader(AzureMonitorMetricExporter exporter)
            : base(exporter)
        {
            _transmitter = exporter.Transmitter;
            TemporalityPreference = MetricReaderTemporalityPreference.Delta;
        }

        protected override bool OnShutdown(int timeoutMilliseconds)
        {
            if (!PersistOnShutdownConfig.IsPersistOnShutdownEnabled)
            {
                return base.OnShutdown(timeoutMilliseconds);
            }

            return PersistOnShutdownHelper.PersistThenDrain(_transmitter, () => base.OnShutdown(timeoutMilliseconds), timeoutMilliseconds);
        }
    }
}
