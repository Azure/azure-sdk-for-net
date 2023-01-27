// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using OpenTelemetry;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal class AzureMonitorBatchActivityExportProcessor : BatchExportProcessor<Activity>
    {
        public AzureMonitorBatchActivityExportProcessor(BaseExporter<Activity> exporter) : base(exporter)
        {
        }

        public override void OnEnd(Activity data)
        {
            // All activities will be passed on to exporter to extract standard metrics
            // activities with Recorded = false will be sampled out on exporter side.
            OnExport(data);
        }
    }
}
