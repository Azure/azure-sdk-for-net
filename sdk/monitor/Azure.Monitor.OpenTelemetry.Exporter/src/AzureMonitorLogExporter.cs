// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.Core.Pipeline;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform;
using OpenTelemetry;
using OpenTelemetry.Logs;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    internal sealed class AzureMonitorLogExporter : BaseExporter<LogRecord>
    {
        private readonly ITransmitter _transmitter;
        private readonly string _instrumentationKey;
        private AzureMonitorResource? _resource;
        private bool _disposed;
        private bool _shouldSample;

        public AzureMonitorLogExporter(AzureMonitorExporterOptions options) : this(TransmitterFactory.Instance.Get(options), new DefaultPlatform())
        {
        }

        internal AzureMonitorLogExporter(ITransmitter transmitter, IPlatform defaultPlatform)
        {
            _transmitter = transmitter;
            _instrumentationKey = transmitter.InstrumentationKey;

            var enableLogSampling = defaultPlatform?.GetEnvironmentVariable(EnvironmentVariableConstants.ENABLE_LOG_SAMPLING);
            if (string.Equals(enableLogSampling, "true", StringComparison.OrdinalIgnoreCase))
            {
                _shouldSample = true;
            }
        }

        internal AzureMonitorResource? LogResource => _resource ??= ParentProvider?.GetResource().CreateAzureMonitorResource(_instrumentationKey);

        /// <inheritdoc/>
        public override ExportResult Export(in Batch<LogRecord> batch)
        {
            // Prevent Azure Monitor's HTTP operations from being instrumented.
            using var scope = SuppressInstrumentationScope.Begin();

            ExportResult exportResult = ExportResult.Failure;

            try
            {
                var telemetryItems = LogsHelper.OtelToAzureMonitorLogs(batch, LogResource, _instrumentationKey, _shouldSample);
                if (telemetryItems.Count > 0)
                {
                    exportResult = _transmitter.TrackAsync(telemetryItems, TelemetryItemOrigin.AzureMonitorLogExporter, false, CancellationToken.None).EnsureCompleted();
                }
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.FailedToExport(nameof(AzureMonitorLogExporter), _instrumentationKey, ex);
            }

            return exportResult;
        }

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
