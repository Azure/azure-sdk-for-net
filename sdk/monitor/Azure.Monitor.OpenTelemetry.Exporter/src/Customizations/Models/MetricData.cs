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
                    metricDataPoint = new MetricDataPoint(metric.Name, metricPoint.GetSumDouble())
                    {
                        DataPointType = DataPointType.Aggregation
                    };
                    break;
                case MetricType.DoubleGauge:
                    metricDataPoint = new MetricDataPoint(metric.Name, metricPoint.GetGaugeLastValueDouble())
                    {
                        DataPointType = DataPointType.Measurement
                    };
                    break;
                case MetricType.LongSum:
                    // potential for minor precision loss implicitly going from long->double
                    // see: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/numeric-conversions#implicit-numeric-conversions
                    metricDataPoint = new MetricDataPoint(metric.Name, metricPoint.GetSumLong())
                    {
                        DataPointType = DataPointType.Aggregation
                    };
                    break;
                case MetricType.LongGauge:
                    // potential for minor precision loss implicitly going from long->double
                    // see: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/numeric-conversions#implicit-numeric-conversions
                    metricDataPoint = new MetricDataPoint(metric.Name, metricPoint.GetGaugeLastValueLong())
                    {
                        DataPointType = DataPointType.Measurement
                    };
                    break;
                case MetricType.Histogram:
                    metricDataPoint = new MetricDataPoint(metric.Name, metricPoint.GetHistogramSum());
                    metricDataPoint.DataPointType = DataPointType.Aggregation;
                    long histogramCount = metricPoint.GetHistogramCount();
                    // Current schema only supports int values for count
                    // if the value is within integer range we will use it otherwise ignore it.
                    metricDataPoint.Count = (histogramCount <= int.MaxValue && histogramCount >= int.MinValue) ? (int?)histogramCount : null;
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

        internal static bool IsSupportedType(MetricType metricType) =>
            metricType switch
            {
                MetricType.DoubleGauge => true,
                MetricType.DoubleSum => true,
                MetricType.LongGauge => true,
                MetricType.LongSum => true,
                MetricType.Histogram => true,
                _ => false
            };
    }
}
