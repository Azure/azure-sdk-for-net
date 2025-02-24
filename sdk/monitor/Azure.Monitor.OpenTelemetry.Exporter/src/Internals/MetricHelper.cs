// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Models;

using OpenTelemetry;
using OpenTelemetry.Metrics;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal static class MetricHelper
    {
        private const int Version = 2;

        internal static List<TelemetryItem> OtelToAzureMonitorMetrics(Batch<Metric> batch, AzureMonitorResource? resource, string instrumentationKey) =>
            OtelToAzureMonitorMetrics(batch, resource, instrumentationKey, postProcess: null);

        internal static List<TelemetryItem> OtelToAzureMonitorMetrics(Batch<Metric> batch, AzureMonitorResource? resource, string instrumentationKey, Action<ITelemetryItem>? postProcess)
        {
            List<TelemetryItem> telemetryItems = new();
            foreach (var metric in batch)
            {
                foreach (ref readonly var metricPoint in metric.GetMetricPoints())
                {
                    try
                    {
                        var telemetryItem =
                            new TelemetryItem(metricPoint.EndTime.UtcDateTime, resource, instrumentationKey)
                            {
                                Data = new MonitorBase
                                {
                                    BaseType = "MetricData",
                                    BaseData = new MetricsData(Version, metric, metricPoint)
                                }
                            };
                        PostProcessTelemetryHelper.InvokePostProcess(telemetryItem, postProcess);
                        telemetryItems.Add(telemetryItem);
                    }
                    catch (Exception ex)
                    {
                        AzureMonitorExporterEventSource.Log.FailedToConvertMetricPoint(meterName: metric.MeterName, instrumentName: metric.Name, ex: ex);
                    }
                }
            }

            return telemetryItems;
        }
    }
}
