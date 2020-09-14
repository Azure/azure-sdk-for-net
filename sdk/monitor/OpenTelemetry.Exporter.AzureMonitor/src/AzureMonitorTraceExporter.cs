// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading;
using Azure.Core.Pipeline;
using OpenTelemetry.Trace;

namespace OpenTelemetry.Exporter.AzureMonitor
{
    public class AzureMonitorTraceExporter : ActivityExporter
    {
        private readonly AzureMonitorTransmitter AzureMonitorTransmitter;

        public AzureMonitorTraceExporter(AzureMonitorExporterOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            this.AzureMonitorTransmitter = new AzureMonitorTransmitter(options);
        }

        /// <inheritdoc/>
        public override ExportResult Export(in Batch<Activity> batch)
        {
            // Prevent Azure Monitor's HTTP operations from being instrumented.
            using var scope = SuppressInstrumentationScope.Begin();

            try
            {
                // TODO: Handle return value, it can be converted as metrics.
                // TODO: Validate CancellationToken and async pattern here.
                this.AzureMonitorTransmitter.AddBatchActivityAsync(batch, false, CancellationToken.None).EnsureCompleted();
                return ExportResult.Success;
            }
            catch (Exception ex)
            {
                AzureMonitorTraceExporterEventSource.Log.FailedExport(ex);
                return ExportResult.Failure;
            }

        }
    }
}
