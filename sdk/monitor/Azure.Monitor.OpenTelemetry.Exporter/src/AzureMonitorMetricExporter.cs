// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using OpenTelemetry.Metrics;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    internal class AzureMonitorMetricExporter : BaseAzureMonitorExporter<Metric>
    {
        public AzureMonitorMetricExporter(AzureMonitorExporterOptions options)
            : this(new AzureMonitorTransmitter(options))
        { }

        internal AzureMonitorMetricExporter(ITransmitter transmitter)
            : base(transmitter, MetricHelper.OtelToAzureMonitorMetrics)
        { }
    }
}
