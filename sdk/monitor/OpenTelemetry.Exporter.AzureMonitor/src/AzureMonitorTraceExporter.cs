// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
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
        public override async Task<ExportResult> ExportAsync(IEnumerable<Activity> batchActivity, CancellationToken cancellationToken)
        {
            if (batchActivity == null)
            {
                throw new ArgumentNullException(nameof(batchActivity));
            }

            // Handle return value, it can be converted as metrics.
            await this.AzureMonitorTransmitter.AddBatchActivityAsync(batchActivity, cancellationToken).ConfigureAwait(false);
            return ExportResult.Success;
        }

        /// <inheritdoc/>
        public override Task ShutdownAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
