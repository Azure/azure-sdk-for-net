// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Monitor.OpenTelemetry.LiveMetrics.Models;
using OpenTelemetry;
using OpenTelemetry.Metrics;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics
{
    internal sealed class LiveMetricsExporter : BaseExporter<Metric>
    {
        private readonly string _instrumentationKey;
        private readonly DoubleBuffer _doubleBuffer;
        private LiveMetricsResource? _resource;
        private bool _disposed;

        public LiveMetricsExporter(DoubleBuffer doubleBuffer, LiveMetricsExporterOptions options)
        {
            _instrumentationKey = "";
            _doubleBuffer = doubleBuffer;
        }

        internal LiveMetricsResource? MetricResource => _resource ??= ParentProvider?.GetResource().CreateAzureMonitorResource(_instrumentationKey);

        public override ExportResult Export(in Batch<Metric> batch)
        {
            MonitoringDataPoint monitoringDataPoint = new MonitoringDataPoint();
            DocumentBuffer filledBuffer = _doubleBuffer.FlipDocumentBuffers();

            foreach (var item in filledBuffer.ReadAllAndClear())
            {
                monitoringDataPoint.Documents.Add(item);
            }

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
