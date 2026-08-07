// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading;
using Azure.Core.Pipeline;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ShutdownPersistence;
using OpenTelemetry;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    /// <summary>
    /// An exporter that sends trace data to Application Insights.
    /// </summary>
    public sealed class AzureMonitorTraceExporter : BaseExporter<Activity>
    {
        private readonly ITransmitter _transmitter;
        private readonly string _instrumentationKey;
        private readonly float _sampleRate; // This value is recorded on TelemetryItem.SampleRate.
        private AzureMonitorResource? _resource;
        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureMonitorTraceExporter"/> class.
        /// </summary>
        /// <param name="options">Configuration options for the trace exporter.</param>
        public AzureMonitorTraceExporter(AzureMonitorExporterOptions options) : this(options, TransmitterFactory.Instance.Get(options))
        {
        }

        internal AzureMonitorTraceExporter(AzureMonitorExporterOptions options, ITransmitter transmitter)
        {
            _sampleRate = (float)Math.Round(options.SamplingRatio * 100);
            _transmitter = transmitter;
            _instrumentationKey = transmitter.InstrumentationKey;
        }

        internal AzureMonitorResource? TraceResource => _resource ??= ParentProvider?.GetResource().CreateAzureMonitorResource(_instrumentationKey);

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
        public override ExportResult Export(in Batch<Activity> batch)
        {
            // Prevent Azure Monitor's HTTP operations from being instrumented.
            using var scope = SuppressInstrumentationScope.Begin();

            ExportResult exportResult = ExportResult.Failure;

            try
            {
                (var telemetryItems, var telemetrySchemaTypeCounter) = TraceHelper.OtelToAzureMonitorTrace(batch, TraceResource, _instrumentationKey, _sampleRate);
                if (telemetryItems.Count > 0)
                {
                    exportResult = _transmitter.TrackAsync(telemetryItems, telemetrySchemaTypeCounter, TelemetryItemOrigin.AzureMonitorTraceExporter, false, CancellationToken.None).EnsureCompleted();
                }
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.FailedToExport(nameof(AzureMonitorTraceExporter), _instrumentationKey, ex);
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
                    AzureMonitorExporterEventSource.Log.DisposedObject(nameof(AzureMonitorTraceExporter));
                    _transmitter?.Dispose();
                }

                _disposed = true;
            }

            base.Dispose(disposing);
        }
    }
}
