// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using OpenTelemetry.Logs;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    internal class AzureMonitorLogExporter : BaseAzureMonitorExporter<LogRecord>
    {
        public AzureMonitorLogExporter(AzureMonitorExporterOptions options)
            : this(new AzureMonitorTransmitter(options))
        { }

        internal AzureMonitorLogExporter(ITransmitter transmitter)
            : base(transmitter, LogsHelper.OtelToAzureMonitorLogs)
        { }
    }
}
