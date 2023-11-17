// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Internals;
using OpenTelemetry;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics
{
    /// <summary>
    /// Empty Exporter. This is used to enable the Manager Singleton.
    /// </summary>
    public class LiveMetricsTraceExporter : BaseExporter<Activity>
    {
        private readonly Manager _manager;

        /// <summary>
        /// TODO.
        /// </summary>
        public LiveMetricsTraceExporter(LiveMetricsExporterOptions options) : this(options, ManagerFactory.Instance.Get(options))
        {
        }

        internal LiveMetricsTraceExporter(LiveMetricsExporterOptions options, Manager manager)
        {
            _manager = manager;
        }

        /// <inheritdoc/>
        public override ExportResult Export(in Batch<Activity> batch)
        {
            return ExportResult.Success;
        }
    }
}
