// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

using Azure.Monitor.OpenTelemetry.Exporter.Models;

using OpenTelemetry;
using OpenTelemetry.Metrics;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal class MetricHelper
    {
        private const int Version = 2;

        internal static List<TelemetryItem> OtelToAzureMonitorMetrics(Batch<Metric> batch, string roleName, string roleInstance, string instrumentationKey)
        {
            List<TelemetryItem> telemetryItems = new();
            foreach (var metric in batch)
            {
                if (MetricsData.IsSupportedType(metric.MetricType))
                {
                    foreach (ref readonly var metricPoint in metric.GetMetricPoints())
                    {
                        telemetryItems.Add(new TelemetryItem(metricPoint.EndTime.UtcDateTime, roleName, roleInstance, instrumentationKey)
                        {
                            Data = new MonitorBase
                            {
                                BaseType = "MetricData",
                                BaseData = new MetricsData(Version, metric, metricPoint)
                            }
                        });
                    }
                }
                else
                {
                    // log not supported
                }
            }

            return telemetryItems;
        }
    }
}
