// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.Core.Pipeline;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ShutdownPersistence;
using OpenTelemetry;
using OpenTelemetry.Logs;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    /// <summary>
    /// An exporter that sends logs to Application Insights.
    /// </summary>
    public sealed class AzureMonitorLogExporter : BaseExporter<LogRecord>
    {
        private readonly ITransmitter _transmitter;
        private readonly string _instrumentationKey;
        private AzureMonitorResource? _resource;
        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of Azure Monitor Log Exporter.
        /// </summary>
        /// <param name="options">Configuration options for the exporter.</param>
        public AzureMonitorLogExporter(AzureMonitorExporterOptions options) : this(TransmitterFactory.Instance.Get(options))
        {
        }

        internal AzureMonitorLogExporter(ITransmitter transmitter)
        {
            _transmitter = transmitter;
            _instrumentationKey = transmitter.InstrumentationKey;
        }

        internal AzureMonitorResource? LogResource => _resource ??= ParentProvider?.GetResource().CreateAzureMonitorResource(_instrumentationKey);

        internal ITransmitter Transmitter => _transmitter;

        /// <inheritdoc/>
        protected override bool OnShutdown(int timeoutMilliseconds)
        {
            // Only reached when a caller supplied their own processor, which has already exported
            // the final batch. Kicks the storage drain so anything previously persisted still gets
            // a chance to upload.
            _transmitter.DrainStorage(PersistOnShutdownConfig.ResolveDrainWait(timeoutMilliseconds));

            return base.OnShutdown(timeoutMilliseconds);
        }

        /// <inheritdoc/>
        public override ExportResult Export(in Batch<LogRecord> batch)
        {
            // Prevent Azure Monitor's HTTP operations from being instrumented.
            using var scope = SuppressInstrumentationScope.Begin();

            ExportResult exportResult = ExportResult.Failure;

            try
            {
                (var telemetryItems, var telemetrySchemaTypeCounter) = LogsHelper.OtelToAzureMonitorLogs(batch, LogResource, _instrumentationKey);
                if (telemetryItems.Count > 0)
                {
                    exportResult = _transmitter.TrackAsync(telemetryItems, telemetrySchemaTypeCounter, TelemetryItemOrigin.AzureMonitorLogExporter, false, CancellationToken.None).EnsureCompleted();
                }
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.FailedToExport(nameof(AzureMonitorLogExporter), _instrumentationKey, ex);
            }

            return exportResult;
        }

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    AzureMonitorExporterEventSource.Log.DisposedObject(nameof(AzureMonitorLogExporter));
                    _transmitter?.Dispose();
                }

                _disposed = true;
            }

            base.Dispose(disposing);
        }
    }
}
