// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ShutdownPersistence;
using OpenTelemetry;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    /// <summary>
    /// A batch processor that persists pending telemetry instead of transmitting it when the
    /// provider shuts down, so that process exit costs a file write rather than an ingestion round
    /// trip.
    /// </summary>
    internal sealed class AzureMonitorBatchActivityExportProcessor : BatchActivityExportProcessor
    {
        private readonly ITransmitter? _transmitter;

        public AzureMonitorBatchActivityExportProcessor(BaseExporter<Activity> exporter)
            : base(exporter)
        {
            _transmitter = (exporter as AzureMonitorTraceExporter)?.Transmitter;
        }

        protected override bool OnShutdown(int timeoutMilliseconds)
        {
            if (!PersistOnShutdownConfig.IsPersistOnShutdownEnabled)
            {
                return base.OnShutdown(timeoutMilliseconds);
            }

            return PersistOnShutdownHelper.PersistThenDrain(_transmitter, () => base.OnShutdown(timeoutMilliseconds), timeoutMilliseconds);
        }

        protected override bool OnForceFlush(int timeoutMilliseconds)
        {
            if (!PersistOnShutdownConfig.IsPersistOnForceFlushEnabled)
            {
                return base.OnForceFlush(timeoutMilliseconds);
            }

            return PersistOnShutdownHelper.PersistThenDrain(_transmitter, () => base.OnForceFlush(timeoutMilliseconds), timeoutMilliseconds);
        }
    }
}
