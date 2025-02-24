// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading;
using Azure.Core.Pipeline;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using OpenTelemetry;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    internal sealed class AzureMonitorTraceExporter : BaseExporter<Activity>
    {
        private readonly ITransmitter _transmitter;
        private readonly string _instrumentationKey;
        private readonly float _sampleRate; // This value is recorded on TelemetryItem.SampleRate.
        private readonly Action<ITelemetryItem>? _beforeTelemetrySent; // This is used to modify the telemetry item before it is sent to the transmitter.
        private AzureMonitorResource? _resource;
        private bool _disposed;

        public AzureMonitorTraceExporter(AzureMonitorExporterOptions options) : this(options, TransmitterFactory.Instance.Get(options))
        {
        }

        internal AzureMonitorTraceExporter(AzureMonitorExporterOptions options, ITransmitter transmitter)
        {
            _sampleRate = (float)Math.Round(options.SamplingRatio * 100);
            _transmitter = transmitter;
            _instrumentationKey = transmitter.InstrumentationKey;
            _beforeTelemetrySent = options.BeforeTelemetrySent;
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
                var telemetryItems = TraceHelper.OtelToAzureMonitorTrace(batch, TraceResource, _instrumentationKey, _sampleRate, _beforeTelemetrySent);
                if (telemetryItems.Count > 0)
                {
                    exportResult = _transmitter.TrackAsync(telemetryItems, TelemetryItemOrigin.AzureMonitorTraceExporter, false, CancellationToken.None).EnsureCompleted();
                }
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.FailedToExport(nameof(AzureMonitorTraceExporter), _instrumentationKey, ex);
            }

            return exportResult;
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    AzureMonitorExporterEventSource.Log.DisposedObject(nameof(AzureMonitorTraceExporter));
                    _transmitter?.Dispose();
                }

                _disposed = true;
            }

            base.Dispose(disposing);
        }
    }
}
