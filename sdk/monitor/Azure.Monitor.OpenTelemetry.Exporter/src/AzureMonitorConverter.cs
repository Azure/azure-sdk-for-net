// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;

using Azure.Monitor.OpenTelemetry.Exporter.Models;

using OpenTelemetry;
using OpenTelemetry.Logs;
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
        };

        internal static List<TelemetryItem> Convert(Batch<Activity> batchActivity, Resource resource, string instrumentationKey)
        {
            List<TelemetryItem> telemetryItems = new List<TelemetryItem>();
            TelemetryItem telemetryItem;

            foreach (var activity in batchActivity)
            {
                MonitorBase telemetryData = new MonitorBase();
                var monitorTags = EnumerateActivityTags(activity);
                telemetryItem = TelemetryPartA.GetTelemetryItem(activity, ref monitorTags, resource, instrumentationKey);

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

        internal static List<TelemetryItem> Convert(Batch<LogRecord> batchLogRecord, Resource resource, string instrumentationKey)
        {
            List<TelemetryItem> telemetryItems = new List<TelemetryItem>();
            TelemetryItem telemetryItem;

            foreach (var logRecord in batchLogRecord)
            {
                telemetryItem = TelemetryPartA.GetTelemetryItem(logRecord, resource, instrumentationKey);
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
