// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenTelemetry;
using OpenTelemetry.Metrics;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics
{
    internal sealed class LiveMetricsExporter : BaseExporter<Metric>
    {
        private readonly string _instrumentationKey;
        private LiveMetricsResource? _resource;
        private bool _disposed;

        public LiveMetricsExporter(LiveMetricsExporterOptions options)
        {
            _instrumentationKey = "";
        }

        internal LiveMetricsResource? MetricResource => _resource ??= ParentProvider?.GetResource().CreateAzureMonitorResource(_instrumentationKey);

        public override ExportResult Export(in Batch<Metric> batch)
        {
            return ExportResult.Success;
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                }

                _disposed = true;
            }

            base.Dispose(disposing);
        }
    }
}
