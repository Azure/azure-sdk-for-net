// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenTelemetry;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    internal class AzureMonitorTestTraceExporter<Activity> : AzureMonitorBaseExporter<Activity>
        where Activity : class
    {
        public override ExportResult Export(in Batch<Activity> batch)
        {
            return ExportResult.Success;
        }
    }
}
