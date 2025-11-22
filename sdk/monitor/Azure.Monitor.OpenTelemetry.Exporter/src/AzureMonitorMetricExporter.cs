// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.Core.Pipeline;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using OpenTelemetry;
using OpenTelemetry.Metrics;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    internal sealed class AzureMonitorMetricExporter : BaseExporter<Metric>
    {
        private readonly ITransmitter _transmitter;
        private readonly string _instrumentationKey;
        private AzureMonitorResource? _resource;
        private bool _disposed;

        public AzureMonitorMetricExporter(AzureMonitorExporterOptions options) : this(TransmitterFactory.Instance.Get(options))
        {
        }

        internal AzureMonitorMetricExporter(ITransmitter transmitter)
        {
            _transmitter = transmitter;
            _instrumentationKey = transmitter.InstrumentationKey;
        }

        internal AzureMonitorResource? MetricResource => _resource ??= ParentProvider?.GetResource().CreateAzureMonitorResource(_instrumentationKey);

        /// <inheritdoc/>
        public override ExportResult Export(in Batch<Metric> batch)
        {
            // Prevent Azure Monitor's HTTP operations from being instrumented.
            using var scope = SuppressInstrumentationScope.Begin();

            var exportResult = ExportResult.Failure;

            try
            {
                // In case of metrics, export is called
                // even if there are no items in batch
                if (batch.Count > 0)
                {
                    (var telemetryItems, var telemetrySchemaTypeCounter) = MetricHelper.OtelToAzureMonitorMetrics(batch, MetricResource, _instrumentationKey);
                    if (telemetryItems.Count > 0)
                    {
                        exportResult = _transmitter.TrackAsync(telemetryItems, telemetrySchemaTypeCounter, TelemetryItemOrigin.AzureMonitorMetricExporter, false, CancellationToken.None).EnsureCompleted();
                    }
                }
                else
                {
                    exportResult = ExportResult.Success;
                }
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.FailedToExport(nameof(AzureMonitorMetricExporter), _instrumentationKey, ex);
            }

            return exportResult;
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    AzureMonitorExporterEventSource.Log.DisposedObject(nameof(AzureMonitorMetricExporter));
                    _transmitter?.Dispose();
                }

                _disposed = true;
            }

            base.Dispose(disposing);
        }
    }
}
