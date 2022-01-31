// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using OpenTelemetry;
using OpenTelemetry.Metrics;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    internal class MetricHelper
    {
        private const int version = 2;

        internal static List<TelemetryItem> OtelToAzureMonitorMetrics(Batch<Metric> batch, string roleName, string roleInstance, string instrumentationKey)
        {
            List<TelemetryItem> telemetryItems = new List<TelemetryItem>();
            TelemetryItem telemetryItem;

            foreach (var metric in batch)
            {
                if (metric.MetricType == MetricType.DoubleSum || metric.MetricType == MetricType.DoubleGauge)
                {
                    foreach (ref var metricPoint in metric.GetMetricPoints())
                    {
                        string name = "Metric";
                        string utcTime = TelemetryItem.FormatUtcTimestamp(metricPoint.EndTime.UtcDateTime);
                        telemetryItem = new TelemetryItem(name, utcTime);
                        telemetryItem.Tags[ContextTagKeys.AiInternalSdkVersion.ToString()] = SdkVersionUtils.SdkVersion;
                        telemetryItem.InstrumentationKey = instrumentationKey;
                        telemetryItem.SetResource(roleName, roleInstance);

                        telemetryItem.Data = new MonitorBase
                        {
                            BaseType = "MetricData",
                            BaseData = new MetricsData(version, metric, ref metricPoint)
                        };
                        telemetryItems.Add(telemetryItem);
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
