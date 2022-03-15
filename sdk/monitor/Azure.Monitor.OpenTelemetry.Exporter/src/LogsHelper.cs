// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using Microsoft.Extensions.Logging;
using OpenTelemetry;
using OpenTelemetry.Logs;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    internal class LogsHelper
    {
        private const int Version = 2;

        internal static List<TelemetryItem> OtelToAzureMonitorLogs(Batch<LogRecord> batchLogRecord, string roleName, string roleInstance, string instrumentationKey)
        {
            List<TelemetryItem> telemetryItems = new List<TelemetryItem>();
            TelemetryItem telemetryItem;

            foreach (var logRecord in batchLogRecord)
            {
                telemetryItem = new TelemetryItem(logRecord, roleName, roleInstance, instrumentationKey);
                if (logRecord.Exception != null)
                {
                    telemetryItem.Data = new MonitorBase
                    {
                        BaseType = "ExceptionData",
                        BaseData = new TelemetryExceptionData(Version, logRecord),
                    };
                }
                else
                {
                    telemetryItem.Data = new MonitorBase
                    {
                        BaseType = "MessageData",
                        BaseData = new MessageData(Version, logRecord),
                    };
                }

                telemetryItems.Add(telemetryItem);
            }

            return telemetryItems;
        }

        internal static string GetMessageAndSetProperties(LogRecord logRecord, IDictionary<string, string> properties)
        {
            string message = logRecord.FormattedMessage;

            // Both logRecord.State and logRecord.StateValues will not be set at the same time for LogRecord.
            // Either logRecord.State != null or logRecord.StateValues will be called.
            if (logRecord.State != null)
            {
                if (logRecord.State is IReadOnlyCollection<KeyValuePair<string, object>> stateDictionary)
                {
                    ExtractProperties(ref message, properties, stateDictionary);
                }
            }

            if (logRecord.StateValues != null)
            {
                ExtractProperties(ref message, properties, logRecord.StateValues);
            }

            if (logRecord.EventId.Id != 0)
            {
                properties.Add("EventId", logRecord.EventId.Id.ToString(CultureInfo.InvariantCulture));
            }

            if (!string.IsNullOrEmpty(logRecord.EventId.Name))
            {
                properties.Add("EventName", logRecord.EventId.Name);
            }

            return message;
        }

        internal static string GetProblemId(Exception exception)
        {
            string methodName = "UnknownMethod";
            int methodOffset = System.Diagnostics.StackFrame.OFFSET_UNKNOWN;

            var exceptionType = exception.GetType().FullName;
            var strackTrace = new StackTrace(exception);
            var exceptionStackFrame = strackTrace.GetFrame(0);

            if (exceptionStackFrame != null)
            {
                MethodBase methodBase = exceptionStackFrame.GetMethod();

                if (methodBase != null)
                {
                    methodName = (methodBase.DeclaringType?.FullName ?? "Global") + "." + methodBase.Name;
                    methodOffset = exceptionStackFrame.GetILOffset();
                }
            }

            string problemId;
            if (methodOffset == System.Diagnostics.StackFrame.OFFSET_UNKNOWN)
            {
                problemId = exceptionType + " at " + methodName;
            }
            else
            {
                problemId = exceptionType + " at " + methodName + ":" + methodOffset.ToString(CultureInfo.InvariantCulture);
            }

            return problemId;
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

        private static void ExtractProperties(ref string message, IDictionary<string, string> properties, IReadOnlyCollection<KeyValuePair<string, object>> stateDictionary)
        {
            foreach (KeyValuePair<string, object> item in stateDictionary)
            {
                if (item.Key == "{OriginalFormat}")
                {
                    if (message == null)
                    {
                        message = item.Value.ToString();
                    }
                    else
                    {
                        properties.Add("OriginalFormat", item.Value.ToString());
                    }
                }
                else
                {
                    properties.Add(item.Key, item.Value.ToString());
                }
            }
        }
    }
}
