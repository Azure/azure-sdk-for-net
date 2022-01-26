// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using Azure.Monitor.OpenTelemetry.Exporter.Models;

using OpenTelemetry;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    /// <summary>
    /// This class is responsible for converting an OpenTelemetry <see cref="Batch{T}"/> of <see cref="Activity"/>
    /// into a collection of <see cref="TelemetryItem"/> for Azure Monitor.
    /// </summary>
    internal static class AzureMonitorConverter
    {
        private static readonly IReadOnlyDictionary<TelemetryType, string> Telemetry_Base_Type_Mapping = new Dictionary<TelemetryType, string>
        {
            [TelemetryType.Request] = "RequestData",
            [TelemetryType.Dependency] = "RemoteDependencyData",
            [TelemetryType.Message] = "MessageData",
            [TelemetryType.Event] = "EventData",
            [TelemetryType.Metric] = "MetricData"
        };

        internal static List<TelemetryItem> Convert(Batch<Activity> batchActivity, string roleName, string roleInstance, string instrumentationKey)
        {
            List<TelemetryItem> telemetryItems = new List<TelemetryItem>();
            TelemetryItem telemetryItem;

            foreach (var activity in batchActivity)
            {
                MonitorBase telemetryData = new MonitorBase();
                var monitorTags = EnumerateActivityTags(activity);
                telemetryItem = new TelemetryItem(activity, ref monitorTags);
                telemetryItem.InstrumentationKey = instrumentationKey;
                telemetryItem.SetResource(roleName, roleInstance);

                switch (activity.GetTelemetryType())
                {
                    case TelemetryType.Request:
                        telemetryData.BaseType = Telemetry_Base_Type_Mapping[TelemetryType.Request];
                        telemetryData.BaseData = TelemetryPartB.GetRequestData(activity, ref monitorTags);
                        break;
                    case TelemetryType.Dependency:
                        telemetryData.BaseType = Telemetry_Base_Type_Mapping[TelemetryType.Dependency];
                        telemetryData.BaseData = TelemetryPartB.GetRemoteDependencyData(activity, ref monitorTags);
                        break;
                }

                telemetryItem.Data = telemetryData;
                telemetryItems.Add(telemetryItem);
            }

            return telemetryItems;
        }

        internal static List<TelemetryItem> Convert(Batch<Metric> batch, string roleName, string roleInstance, string instrumentationKey)
        {
            List<TelemetryItem> telemetryItems = new List<TelemetryItem>();
            TelemetryItem telemetryItem;

            foreach (var metric in batch)
            {
                foreach (ref readonly var metricPoint in metric.GetMetricPoints())
                {
                    telemetryItem = new TelemetryItem(Telemetry_Base_Type_Mapping[TelemetryType.Metric], TelemetryItem.FormatUtcTimestamp(DateTime.UtcNow));
                    telemetryItem.InstrumentationKey = instrumentationKey;
                    telemetryItem.SetResource(roleName, roleInstance);

                    MonitorBase telemetryData = new MonitorBase();
                    telemetryData.BaseType = Telemetry_Base_Type_Mapping[TelemetryType.Metric];

                    IList<MetricDataPoint> metrics = new List<MetricDataPoint>();
                    MetricDataPoint metricDataPoint = new MetricDataPoint(metric.Meter.Name, metricPoint.GetSumDouble());
                    metrics.Add(metricDataPoint);
                    MetricsData metricsData = new MetricsData(2, metrics);
                    foreach (var tag in metricPoint.Tags)
                    {
                        metricsData.Properties.Add(new KeyValuePair<string, string>(tag.Key, tag.Value.ToString()));
                    }

                    telemetryData.BaseData = metricsData;
                    telemetryItem.Data = telemetryData;
                    telemetryItems.Add(telemetryItem);
                }
            }

            return telemetryItems;
        }

        internal static List<TelemetryItem> Convert(Batch<LogRecord> batchLogRecord, string roleName, string roleInstance, string instrumentationKey)
        {
            List<TelemetryItem> telemetryItems = new List<TelemetryItem>();
            TelemetryItem telemetryItem;

            foreach (var logRecord in batchLogRecord)
            {
                telemetryItem = new TelemetryItem(logRecord);
                telemetryItem.InstrumentationKey = instrumentationKey;
                telemetryItem.SetResource(roleName, roleInstance);
                telemetryItem.Data = new MonitorBase
                {
                    BaseType = Telemetry_Base_Type_Mapping[TelemetryType.Message],
                    BaseData = TelemetryPartB.GetMessageData(logRecord),
                };
                telemetryItems.Add(telemetryItem);
            }

            return telemetryItems;
        }

        internal static TagEnumerationState EnumerateActivityTags(Activity activity)
        {
            var monitorTags = new TagEnumerationState
            {
                PartBTags = AzMonList.Initialize(),
                PartCTags = AzMonList.Initialize()
            };

            monitorTags.ForEach(activity.TagObjects);
            return monitorTags;
        }
    }
}
