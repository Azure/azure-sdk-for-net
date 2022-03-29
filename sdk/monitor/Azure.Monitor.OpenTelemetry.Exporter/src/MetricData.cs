// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using OpenTelemetry.Metrics;

namespace Azure.Monitor.OpenTelemetry.Exporter.Models
{
    internal partial class MetricsData
    {
        // TODO: Change the export value when AzureMonitorExporterOptions
        // could take a customized ExportIntervalMilliseconds.
        internal const string DefaultExportIntervalMilliseconds = "60000";
        internal const string AggregationIntervalMsKey = "_MS.AggregationIntervalMs";

        public MetricsData(int version, Metric metric, MetricPoint metricPoint) : base(version)
        {
            if (metric == null)
            {
                throw new ArgumentNullException(nameof(metric));
            }

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
            Properties.Add(AggregationIntervalMsKey, DefaultExportIntervalMilliseconds);
        }
    }
}
