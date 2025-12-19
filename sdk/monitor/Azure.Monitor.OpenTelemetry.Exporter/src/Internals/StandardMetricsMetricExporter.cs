// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.Core.Pipeline;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using OpenTelemetry;
using OpenTelemetry.Metrics;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    /// <summary>
    /// A wrapper around AzureMonitorMetricExporter that provides a custom resource provider
    /// for performance counter metrics. This ensures that performance counters inherit the
    /// resource attributes from the main TracerProvider instead of using the MeterProvider's resource.
    /// </summary>
    internal sealed class StandardMetricsMetricExporter : BaseExporter<Metric>
    {
        private readonly ITransmitter _transmitter;
        private readonly string _instrumentationKey;
        private readonly Func<AzureMonitorResource?> _resourceProvider;
        private bool _disposed;

        public StandardMetricsMetricExporter(ITransmitter transmitter, Func<AzureMonitorResource?> resourceProvider)
        {
            _transmitter = transmitter ?? throw new ArgumentNullException(nameof(transmitter));
            _instrumentationKey = transmitter.InstrumentationKey;
            _resourceProvider = resourceProvider ?? throw new ArgumentNullException(nameof(resourceProvider));
        }

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
                    // Use the custom resource provider instead of ParentProvider?.GetResource()
                    var resource = _resourceProvider();
                    (var telemetryItems, var telemetrySchemaTypeCounter) = MetricHelper.OtelToAzureMonitorMetrics(batch, resource, _instrumentationKey);
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
                AzureMonitorExporterEventSource.Log.FailedToExport(nameof(StandardMetricsMetricExporter), _instrumentationKey, ex);
            }

            return exportResult;
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    AzureMonitorExporterEventSource.Log.DisposedObject(nameof(StandardMetricsMetricExporter));
                    _transmitter?.Dispose();
                }

                _disposed = true;
            }

            base.Dispose(disposing);
        }
    }
}
