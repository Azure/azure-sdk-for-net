// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using Microsoft.Extensions.Logging;
using OpenTelemetry;
using OpenTelemetry.Logs;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    internal class LogsHelper
    {
        private const int version = 2;

        internal static List<TelemetryItem> OtelToAzureMonitorLogs(Batch<LogRecord> batchLogRecord, string roleName, string roleInstance, string instrumentationKey)
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
                    BaseType = "MessageData",
                    BaseData = new MessageData(version, logRecord),
                };
                telemetryItems.Add(telemetryItem);
            }

            return telemetryItems;
        }

        /// <summary>
        /// Converts the <see cref="LogRecord.LogLevel"/> into corresponding Azure Monitor <see cref="SeverityLevel"/>.
        /// </summary>
        internal static SeverityLevel GetSeverityLevel(LogLevel logLevel)
        {
            switch (logLevel)
            {
                case LogLevel.Critical:
                    return SeverityLevel.Critical;
                case LogLevel.Error:
                    return SeverityLevel.Error;
                case LogLevel.Warning:
                    return SeverityLevel.Warning;
                case LogLevel.Information:
                    return SeverityLevel.Information;
                case LogLevel.Debug:
                case LogLevel.Trace:
                default:
                    return SeverityLevel.Verbose;
            }
        }
    }
}
