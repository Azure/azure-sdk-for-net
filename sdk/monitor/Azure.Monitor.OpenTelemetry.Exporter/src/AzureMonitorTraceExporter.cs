// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading;
using Azure.Core.Pipeline;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.MultiTenant;
using OpenTelemetry;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    /// <summary>
    /// An exporter that sends trace data to Application Insights.
    /// </summary>
    public sealed class AzureMonitorTraceExporter : BaseExporter<Activity>
    {
        private readonly ITransmitter _transmitter;
        private readonly IMultiTenantTransmitter? _multiTenantTransmitter;
        private readonly string _instrumentationKey;
        private readonly float _sampleRate; // This value is recorded on TelemetryItem.SampleRate.
        private readonly bool _multiTenantEnabled;
        private AzureMonitorResource? _resource;
        private EndpointRouteBatch? _routeBatch;
        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureMonitorTraceExporter"/> class.
        /// </summary>
        /// <param name="options">Configuration options for the trace exporter.</param>
        public AzureMonitorTraceExporter(AzureMonitorExporterOptions options) : this(options, TransmitterFactory.Instance.Get(options))
        {
        }

        internal AzureMonitorTraceExporter(AzureMonitorExporterOptions options, ITransmitter transmitter)
            : this(options, transmitter, MultiTenantConfig.Enabled)
        {
        }

        /// <remarks>
        /// The gate is a constructor parameter so a test can exercise either path without mutating
        /// process-wide state that other tests observe.
        /// </remarks>
        internal AzureMonitorTraceExporter(AzureMonitorExporterOptions options, ITransmitter transmitter, bool multiTenantEnabled)
        {
            _sampleRate = (float)Math.Round(options.SamplingRatio * 100);
            _transmitter = transmitter;
            _instrumentationKey = transmitter.InstrumentationKey;
            _multiTenantEnabled = multiTenantEnabled;

            if (_multiTenantEnabled)
            {
                if (transmitter is not IMultiTenantTransmitter multiTenantTransmitter)
                {
                    // The caller already took a reference on the shared transmitter, which owns
                    // storage timers and statsbeat, so it has to be released before unwinding.
                    transmitter.Dispose();

                    throw new NotSupportedException($"Multi-tenant export requires a transmitter implementing {nameof(IMultiTenantTransmitter)}.");
                }

                _multiTenantTransmitter = multiTenantTransmitter;

                AzureMonitorExporterEventSource.Log.MultiTenantExportEnabled();
            }
        }

        internal AzureMonitorResource? TraceResource => _resource ??= ParentProvider?.GetResource().CreateAzureMonitorResource(_instrumentationKey);

        internal ITransmitter Transmitter => _transmitter;

        /// <inheritdoc/>
        public override ExportResult Export(in Batch<Activity> batch)
        {
            // Prevent Azure Monitor's HTTP operations from being instrumented.
            using var scope = SuppressInstrumentationScope.Begin();

            if (_multiTenantEnabled)
            {
                return ExportMultiTenant(batch);
            }

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

        private ExportResult ExportMultiTenant(in Batch<Activity> batch)
        {
            // A concurrent Export takes a fresh batch rather than sharing the cached one.
            var routeBatch = Interlocked.Exchange(ref _routeBatch, null) ?? new EndpointRouteBatch();

            try
            {
                TraceHelper.OtelToAzureMonitorTraceMultiTenant(batch, TraceResource, _sampleRate, routeBatch);

                if (routeBatch.Count == 0)
                {
                    // Most tenants do not enable observability, so a batch carrying no routing tags
                    // is the normal steady state rather than a failed export.
                    return ExportResult.Success;
                }

                // Blocks until every group has been sent, so Reset cannot run under a consumer that
                // still holds a group's item list.
                return _multiTenantTransmitter!.Track(routeBatch, TelemetryItemOrigin.AzureMonitorTraceExporter, CancellationToken.None);
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.FailedToExport(nameof(AzureMonitorTraceExporter), _instrumentationKey, ex);
                return ExportResult.Failure;
            }
            finally
            {
                routeBatch.Reset();
                Interlocked.Exchange(ref _routeBatch, routeBatch);
            }
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
