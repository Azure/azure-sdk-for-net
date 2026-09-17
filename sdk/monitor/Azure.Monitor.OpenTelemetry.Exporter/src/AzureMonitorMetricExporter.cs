// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.Core.Pipeline;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.MultiEndpoint;
using OpenTelemetry;
using OpenTelemetry.Metrics;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    /// <summary>
    /// An exporter that sends metrics to Application Insights.
    /// </summary>
    public sealed class AzureMonitorMetricExporter : BaseExporter<Metric>
    {
        private readonly ITransmitter _transmitter;
        private readonly string _instrumentationKey;
        private readonly bool _multiEndpointEnabled;
        private readonly IMultiEndpointTransmitter? _multiEndpointTransmitter;
        private EndpointRouteBatch? _routeBatch;
        private AzureMonitorResource? _resource;
        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureMonitorMetricExporter"/> class.
        /// </summary>
        /// <param name="options">Configuration options for the metric exporter.</param>
        public AzureMonitorMetricExporter(AzureMonitorExporterOptions options) : this(TransmitterFactory.Instance.Get(options))
        {
        }

        internal AzureMonitorMetricExporter(ITransmitter transmitter)
            : this(transmitter, MultiEndpointConfig.Enabled)
        {
        }

        /// <summary>
        /// Builds an exporter for the SDK's own telemetry (Statsbeat, Customer SDK Stats), which is
        /// addressed to the exporter's own connection string and carries no routing dimensions.
        /// Routing would drop every measurement while reporting success, blinding us to the very
        /// feature being rolled out.
        /// </summary>
        internal static AzureMonitorMetricExporter CreateForInternalTelemetry(AzureMonitorExporterOptions options)
            => CreateForInternalTelemetry(TransmitterFactory.Instance.Get(options));

        /// <remarks>
        /// Takes the transmitter so a test can observe which path the exporter used without building
        /// a real one.
        /// </remarks>
        internal static AzureMonitorMetricExporter CreateForInternalTelemetry(ITransmitter transmitter)
            => new(transmitter, multiEndpointEnabled: false);

        /// <remarks>
        /// The gate is a constructor parameter so a test can exercise either path without mutating
        /// process-wide state that other tests observe.
        /// </remarks>
        internal AzureMonitorMetricExporter(ITransmitter transmitter, bool multiEndpointEnabled)
        {
            _transmitter = transmitter;
            _instrumentationKey = transmitter.InstrumentationKey;
            _multiEndpointEnabled = multiEndpointEnabled;

            if (_multiEndpointEnabled)
            {
                if (transmitter is not IMultiEndpointTransmitter multiEndpointTransmitter)
                {
                    // The caller already took a reference on the shared transmitter, which owns
                    // storage timers and statsbeat, so it has to be released before unwinding.
                    transmitter.Dispose();

                    throw new NotSupportedException($"Multi-endpoint routing requires a transmitter implementing {nameof(IMultiEndpointTransmitter)}.");
                }

                _multiEndpointTransmitter = multiEndpointTransmitter;

                AzureMonitorExporterEventSource.Log.MultiEndpointRoutingEnabled();
            }
        }

        internal AzureMonitorResource? MetricResource => _resource ??= ParentProvider?.GetResource().CreateAzureMonitorResource(_instrumentationKey);

        internal ITransmitter Transmitter => _transmitter;

        /// <inheritdoc/>
        public override ExportResult Export(in Batch<Metric> batch)
        {
            // Prevent Azure Monitor's HTTP operations from being instrumented.
            using var scope = SuppressInstrumentationScope.Begin();

            if (_multiEndpointEnabled)
            {
                return ExportMultiEndpoint(batch);
            }

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

        private ExportResult ExportMultiEndpoint(in Batch<Metric> batch)
        {
            if (batch.Count == 0)
            {
                return ExportResult.Success;
            }

            // A concurrent Export takes a fresh batch rather than sharing the cached one.
            var routeBatch = Interlocked.Exchange(ref _routeBatch, null) ?? new EndpointRouteBatch();
            routeBatch.BeginExport();

            try
            {
                MetricHelper.OtelToAzureMonitorMetricsMultiEndpoint(batch, MetricResource, routeBatch);

                if (routeBatch.Count == 0)
                {
                    // Routing dimensions are stamped upstream only on measurements meant to be routed;
                    // a collection where nothing carried them is not addressed to any endpoint, so
                    // report success rather than treating an empty routed batch as a failed export.
                    return ExportResult.Success;
                }

                // Blocks until every group has been sent, so Reset cannot run under a consumer that
                // still holds a group's item list.
                return _multiEndpointTransmitter!.Track(routeBatch, TelemetryItemOrigin.AzureMonitorMetricExporter, CancellationToken.None);
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.FailedToExport(nameof(AzureMonitorMetricExporter), _instrumentationKey, ex);
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
                    AzureMonitorExporterEventSource.Log.DisposedObject(nameof(AzureMonitorMetricExporter));
                    _transmitter?.Dispose();
                }

                _disposed = true;
            }

            base.Dispose(disposing);
        }
    }
}
