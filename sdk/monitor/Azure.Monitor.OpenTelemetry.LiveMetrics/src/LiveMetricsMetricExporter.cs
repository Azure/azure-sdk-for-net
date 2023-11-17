// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
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

            //Debug.Assert(batch.Count == 11);
            foreach (var metric in batch)
            {
                foreach (ref readonly var metricPoint in metric.GetMetricPoints())
                {
                    //Debug.WriteLine(LiveMetricConstants.Mappings[metric.Name]);

                    switch (metric.MetricType)
                    {
                        case MetricType.LongSum:
                            list.Add(new Models.MetricPoint
                            {
                                Name = LiveMetricConstants.Mappings[metric.Name],
                                Value = metricPoint.GetSumLong(),
                                Weight = 1
                            });
                            break;
                        case MetricType.Histogram:
                            list.Add(new Models.MetricPoint
                            {
                                Name = LiveMetricConstants.Mappings[metric.Name],
                                Value = (float)metricPoint.GetHistogramSum(),
                                Weight = (int)metricPoint.GetHistogramCount() // TODO: POSSIBLE OVERFLOW EXCEPTION (long -> int)
                            });
                            break;
                        case MetricType.DoubleGauge:
                            list.Add(new Models.MetricPoint
                            {
                                Name = LiveMetricConstants.Mappings[metric.Name],
                                Value = (float)metricPoint.GetGaugeLastValueDouble(),
                                Weight = 1
                            });
                            break;
                        default:
                            Debug.WriteLine($"Unsupported Metric Type {metric.MetricType} {metric.Name}");
                            break;
                    }
                }
            }
            //Debug.Assert(list.Count == 11);

            _metricPoints.Enqueue(list);
            Debug.Write($"Enqueue {_metricPoints.Count}. Count {list.Count}\n");

            return ExportResult.Success;
        }
    }
}
