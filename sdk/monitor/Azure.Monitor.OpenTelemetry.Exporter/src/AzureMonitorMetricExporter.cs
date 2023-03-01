// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.PersistentStorage;
using OpenTelemetry;
using OpenTelemetry.Metrics;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    internal class AzureMonitorMetricExporter : BaseExporter<Metric>
    {
        private readonly ITransmitter _transmitter;
        private readonly string _instrumentationKey;
        private readonly AzureMonitorPersistentStorage? _persistentStorage;
        private AzureMonitorResource? _resource;
        private bool _disposed;

        public AzureMonitorMetricExporter(AzureMonitorExporterOptions options, TokenCredential? credential = null) : this(TransmitterFactory.Instance.Get(options, credential))
        {
        }

        internal AzureMonitorMetricExporter(ITransmitter transmitter)
        {
            _transmitter = transmitter;
            _instrumentationKey = transmitter.InstrumentationKey;

            if (transmitter is AzureMonitorTransmitter azureMonitorTransmitter && azureMonitorTransmitter._fileBlobProvider != null)
            {
                _persistentStorage = new AzureMonitorPersistentStorage(transmitter);
            }
        }

        internal AzureMonitorResource? MetricResource => _resource ??= ParentProvider?.GetResource().UpdateRoleNameAndInstance();

        /// <inheritdoc/>
        public override ExportResult Export(in Batch<Metric> batch)
        {
            _persistentStorage?.StartExporterTimer();

            // Prevent Azure Monitor's HTTP operations from being instrumented.
            using var scope = SuppressInstrumentationScope.Begin();

            var exportResult = ExportResult.Failure;

            try
            {
                // In case of metrics, export is called
                // even if there are no items in batch
                if (batch.Count > 0)
                {
                    var telemetryItems = MetricHelper.OtelToAzureMonitorMetrics(batch, MetricResource, _instrumentationKey);
                    if (telemetryItems.Count > 0)
                    {
                        exportResult = _transmitter.TrackAsync(telemetryItems, false, CancellationToken.None).EnsureCompleted();
                    }
                }
                else
                {
                    exportResult = ExportResult.Success;
                }

                _persistentStorage?.StopExporterTimerAndTransmitFromStorage();
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.WriteError("FailedToExport", ex);
            }

            return exportResult;
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _transmitter?.Dispose();
                _disposed = true;
            }

            base.Dispose(disposing);
        }
    }
}
