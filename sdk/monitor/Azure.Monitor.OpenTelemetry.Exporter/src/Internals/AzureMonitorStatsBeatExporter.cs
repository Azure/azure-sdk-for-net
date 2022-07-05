// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.Core.Pipeline;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;

using OpenTelemetry;
using OpenTelemetry.Metrics;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    internal class AzureMonitorStatsBeatExporter : BaseExporter<Metric>
    {
        private readonly ITransmitter _transmitter;
        private readonly string _instrumentationKey;

        public AzureMonitorStatsBeatExporter(AzureMonitorExporterOptions options) : this(new AzureMonitorTransmitter(options))
        {
        }

        internal AzureMonitorStatsBeatExporter(ITransmitter transmitter)
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
                var telemetryItems = MetricHelper.OtelToAzureMonitorMetrics(batch, StatsBeat.s_roleName, StatsBeat.s_roleInstance, _instrumentationKey);
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
