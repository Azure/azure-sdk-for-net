// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading;
using Azure.Core.Pipeline;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using OpenTelemetry;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    internal class AzureMonitorTraceExporter : BaseExporter<Activity>
    {
        private readonly ITransmitter _transmitter;
        private readonly string _instrumentationKey;
        private AzureMonitorResource? _resource;
        private bool _disposed;

        public AzureMonitorTraceExporter(AzureMonitorExporterOptions options) : this(TransmitterFactory.Instance.Get(options))
        {
        }

        internal AzureMonitorTraceExporter(ITransmitter transmitter)
        {
            _transmitter = transmitter;
            _instrumentationKey = transmitter.InstrumentationKey;
        }

        internal AzureMonitorResource? TraceResource => _resource ??= ParentProvider?.GetResource().CreateAzureMonitorResource(_instrumentationKey);

        /// <inheritdoc/>
        public override ExportResult Export(in Batch<Activity> batch)
        {
            // Prevent Azure Monitor's HTTP operations from being instrumented.
            using var scope = SuppressInstrumentationScope.Begin();

            ExportResult exportResult = ExportResult.Failure;

            try
            {
                var telemetryItems = TraceHelper.OtelToAzureMonitorTrace(batch, TraceResource, _instrumentationKey);
                if (telemetryItems.Count > 0)
                {
                    exportResult = _transmitter.TrackAsync(telemetryItems, false, CancellationToken.None).EnsureCompleted();
                }
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
                if (disposing)
                {
                    _transmitter?.Dispose();
                }

                _disposed = true;
            }

            base.Dispose(disposing);
        }
    }
}
