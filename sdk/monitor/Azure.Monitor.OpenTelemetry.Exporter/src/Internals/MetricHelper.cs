// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.CustomerSdkStats;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Models;

using OpenTelemetry;
using OpenTelemetry.Metrics;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal static class MetricHelper
    {
        private const int Version = 2;

        internal static (List<TelemetryItem> TelemetryItems, TelemetryCounter TelemetryCounter) OtelToAzureMonitorMetrics(Batch<Metric> batch, AzureMonitorResource? resource, string instrumentationKey)
        {
            List<TelemetryItem> telemetryItems = new();

            foreach (var metric in batch)
            {
                foreach (ref readonly var metricPoint in metric.GetMetricPoints())
                {
                    try
                    {
                        telemetryItems.Add(new TelemetryItem(metricPoint.EndTime.UtcDateTime, resource, instrumentationKey)
                        {
                            Data = new MonitorBase
                            {
                                BaseType = "MetricData",
                                BaseData = new MetricsData(Version, metric, metricPoint)
                            }
                        });
                    }
                    catch (Exception ex)
                    {
                        AzureMonitorExporterEventSource.Log.FailedToConvertMetricPoint(meterName: metric.MeterName, instrumentName: metric.Name, ex: ex);
                    }
                }
            }

            return (telemetryItems, new TelemetryCounter() { _metricCount = telemetryItems.Count});
        }
    }
}
