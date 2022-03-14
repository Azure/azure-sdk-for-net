// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;

using Azure.Core.Pipeline;

using OpenTelemetry;
using OpenTelemetry.Metrics;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    [AggregationTemporality(AggregationTemporality.Delta)]
    internal class AzureMonitorMetricExporter : BaseExporter<Metric>
    {
        private readonly ITransmitter _transmitter;
        private readonly string _instrumentationKey;
        private readonly ResourceParser _resourceParser;

        public AzureMonitorMetricExporter(AzureMonitorExporterOptions options) : this(new AzureMonitorTransmitter(options))
        {
        }

        internal AzureMonitorMetricExporter(ITransmitter transmitter)
        {
            _transmitter = transmitter;
            _instrumentationKey = transmitter.InstrumentationKey;
            _resourceParser = new ResourceParser();
        }

        /// <inheritdoc/>
        public override ExportResult Export(in Batch<Metric> batch)
        {
            // Prevent Azure Monitor's HTTP operations from being instrumented.
            using var scope = SuppressInstrumentationScope.Begin();

            try
            {
                if (_resourceParser.RoleName is null && _resourceParser.RoleInstance is null)
                {
                    var resource = ParentProvider.GetResource();
                    _resourceParser.UpdateRoleNameAndInstance(resource);
                }

                var telemetryItems = MetricHelper.OtelToAzureMonitorMetrics(batch, _resourceParser.RoleName, _resourceParser.RoleInstance, _instrumentationKey);

                // TODO: Handle return value, it can be converted as metrics.
                // TODO: Validate CancellationToken and async pattern here.
                var exportResult = _transmitter.TrackAsync(telemetryItems, false, CancellationToken.None).EnsureCompleted();

                return exportResult;
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.Write($"FailedToExport{EventLevelSuffix.Error}", ex.LogAsyncException());
                return ExportResult.Failure;
            }
        }
    }
}
