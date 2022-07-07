// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.Core.Pipeline;

using OpenTelemetry;
using OpenTelemetry.Metrics;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal class StatsbeatExporter : BaseExporter<Metric>
    {
        private readonly ITransmitter _transmitter;
        private readonly string _instrumentationKey;

        public StatsbeatExporter(AzureMonitorExporterOptions options) : this(new AzureMonitorTransmitter(options))
        {
        }

        internal StatsbeatExporter(ITransmitter transmitter)
        {
            _transmitter = transmitter;
            _instrumentationKey = transmitter.InstrumentationKey;
        }

        /// <inheritdoc/>
        public override ExportResult Export(in Batch<Metric> batch)
        {
            // Prevent Azure Monitor's HTTP operations from being instrumented.
            using var scope = SuppressInstrumentationScope.Begin();

            try
            {
                var telemetryItems = MetricHelper.OtelToAzureMonitorMetrics(batch, ResourceParser.Statsbeat_RoleName, ResourceParser.Statsbeat_RoleInstance, _instrumentationKey);

                // TODO: Add overload in tranmitter with no loggging and failure handling
                var exportResult = _transmitter.TrackAsync(telemetryItems, false, CancellationToken.None).EnsureCompleted();

                return exportResult;
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.WriteError("FailedToExport", ex);
                return ExportResult.Failure;
            }
        }
    }
}
