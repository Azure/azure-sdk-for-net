// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using OpenTelemetry.Metrics;

namespace Azure.Monitor.OpenTelemetry.Exporter.Models
{
    internal partial class MetricsData
    {
        private const string azureMonitorResourceKey = "_OTELRESOURCE_";

        public MetricsData(int version, Metric metric, MetricPoint metricPoint) : base(version)
        {
            if (metric == null)
            {
                throw new ArgumentNullException(nameof(metric));
            }

            IList<MetricDataPoint> metricDataPoints = new List<MetricDataPoint>();
            MetricDataPoint metricDataPoint = new MetricDataPoint(metric, metricPoint);
            metricDataPoints.Add(metricDataPoint);
            Metrics = metricDataPoints;
            Properties = new ChangeTrackingDictionary<string, string>();
            foreach (var tag in metricPoint.Tags)
            {
                if (tag.Key.Length <= SchemaConstants.MetricsData_Properties_MaxKeyLength && tag.Value != null)
                {
                    // Note: if Key exceeds MaxLength or if Value is null, the entire KVP will be dropped.

                    if (tag.Value is Array array)
                    {
                        Properties.Add(new KeyValuePair<string, string>(tag.Key, array.ToCommaDelimitedString()));
                    }
                    else
                    {
                        Properties.Add(new KeyValuePair<string, string>(tag.Key, tag.Value.ToString().Truncate(SchemaConstants.MetricsData_Properties_MaxValueLength) ?? "null"));
                    }
                }
            }
        }

        /// <summary>
        /// This constructor is used only for creating resource metrics with the name "_OTELRESOURCE_".
        /// </summary>
        /// <param name="version">Schema version.</param>
        public MetricsData(int version) : base(version)
        {
            IList<MetricDataPoint> metricDataPoints = new List<MetricDataPoint>();
            MetricDataPoint metricDataPoint = new MetricDataPoint(azureMonitorResourceKey, 0);
            metricDataPoints.Add(metricDataPoint);
            Metrics = metricDataPoints;
            Properties = new ChangeTrackingDictionary<string, string>();
        }
    }
}
