// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    internal class AzureMonitorTraceExporter : BaseAzureMonitorExporter<Activity>
    {
        public AzureMonitorTraceExporter(AzureMonitorExporterOptions options)
            : this(new AzureMonitorTransmitter(options))
        { }

        internal AzureMonitorTraceExporter(ITransmitter transmitter)
            : base(transmitter, TraceHelper.OtelToAzureMonitorTrace)
        { }
    }
}
