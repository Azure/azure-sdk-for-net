// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;

using Microsoft.OpenTelemetry.Exporter.AzureMonitor.Models;

using OpenTelemetry;
using OpenTelemetry.Logs;

namespace Microsoft.OpenTelemetry.Exporter.AzureMonitor
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

        internal static List<TelemetryItem> Convert(Batch<Activity> batchActivity, string instrumentationKey)
        {
            List<TelemetryItem> telemetryItems = new List<TelemetryItem>();
            TelemetryItem telemetryItem;

            foreach (var activity in batchActivity)
            {
                MonitorBase telemetryData = new MonitorBase();
                telemetryItem = TelemetryPartA.GetTelemetryItem(activity, instrumentationKey);

                switch (activity.GetTelemetryType())
                {
                    case TelemetryType.Request:
                        telemetryData.BaseType = Telemetry_Base_Type_Mapping[TelemetryType.Request];
                        telemetryData.BaseData = TelemetryPartB.GetRequestData(activity);
                        break;
                    case TelemetryType.Dependency:
                        telemetryData.BaseType = Telemetry_Base_Type_Mapping[TelemetryType.Dependency];
                        telemetryData.BaseData = TelemetryPartB.GetRemoteDependencyData(activity);
                        break;
                }

                telemetryItem.Data = telemetryData;
                telemetryItems.Add(telemetryItem);
            }

            return telemetryItems;
        }

        internal static List<TelemetryItem> Convert(Batch<LogRecord> batchLogRecord, string instrumentationKey)
        {
            List<TelemetryItem> telemetryItems = new List<TelemetryItem>();
            TelemetryItem telemetryItem;

            foreach (var logRecord in batchLogRecord)
            {
                telemetryItem = TelemetryPartA.GetTelemetryItem(logRecord, instrumentationKey);
                telemetryItem.Data = new MonitorBase
                {
                    BaseType = Telemetry_Base_Type_Mapping[TelemetryType.Message],
                    BaseData = TelemetryPartB.GetMessageData(logRecord),
                };
                telemetryItems.Add(telemetryItem);
            }

            return telemetryItems;
        }
    }
}
