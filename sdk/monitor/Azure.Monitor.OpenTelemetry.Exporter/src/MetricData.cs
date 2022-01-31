// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;
using OpenTelemetry.Metrics;

namespace Azure.Monitor.OpenTelemetry.Exporter.Models
{
    internal partial class MetricsData
    {
        public MetricsData(int version, Metric metric, ref MetricPoint metricPoint) : base(version)
        {
            IList<MetricDataPoint> metricDataPoints = new List<MetricDataPoint>();
            MetricDataPoint metricDataPoint = null;
            switch (metric.MetricType)
            {
                case MetricType.DoubleSum:
                    metricDataPoint = new MetricDataPoint(metric.Name, metricPoint.GetSumDouble());
                    metricDataPoint.DataPointType = DataPointType.Aggregation;
                    break;
                case MetricType.DoubleGauge:
                    metricDataPoint = new MetricDataPoint(metric.Name, metricPoint.GetGaugeLastValueDouble());
                    metricDataPoint.DataPointType = DataPointType.Measurement;
                    break;
            }

            metricDataPoints.Add(metricDataPoint);
            Metrics = metricDataPoints;
            Properties = new ChangeTrackingDictionary<string, string>();
            foreach (var tag in metricPoint.Tags)
            {
                Properties.Add(new KeyValuePair<string, string>(tag.Key, tag.Value?.ToString()));
            }
        }
    }
}
