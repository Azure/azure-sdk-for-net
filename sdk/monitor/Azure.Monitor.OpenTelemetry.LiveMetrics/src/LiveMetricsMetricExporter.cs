// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Internals;
using OpenTelemetry;
using OpenTelemetry.Metrics;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics
{
    /// <summary>
    /// Converts OTel Metrics to Azure Monitor Metrics.
    /// </summary>
    internal class LiveMetricsMetricExporter : BaseExporter<Metric>
    {
        private readonly ConcurrentQueue<List<Models.MetricPoint>> _metricPoints;

        /// <summary>
        /// TODO.
        /// </summary>
        public LiveMetricsMetricExporter(ConcurrentQueue<List<Models.MetricPoint>> metricPoints)
        {
            _metricPoints = metricPoints;
        }

        /// <inheritdoc/>
        public override ExportResult Export(in Batch<Metric> batch)
        {
            var list = new List<Models.MetricPoint>(capacity: (int)batch.Count); // TODO: POSSIBLE OVERFLOW EXCEPTION (long -> int)

            foreach (var metric in batch)
            {
                foreach (ref readonly var metricPoint in metric.GetMetricPoints())
                {
                    if (DataTranslator.TryConvertOTelToAzure(metric, metricPoint, out var azureMetricPoint))
                    {
                        list.Add(azureMetricPoint);
                    }
                }
            }

            _metricPoints.Enqueue(list);
            Debug.Write($"Enqueue {_metricPoints.Count}. Count {list.Count}\n");

            return ExportResult.Success;
        }
    }
}
