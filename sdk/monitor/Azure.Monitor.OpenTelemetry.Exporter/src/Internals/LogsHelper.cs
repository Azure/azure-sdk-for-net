// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.CustomerSdkStats;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Models;

using Microsoft.Extensions.Logging;

using OpenTelemetry;
using OpenTelemetry.Logs;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal static class LogsHelper
    {
        private const string CustomEventAttributeName = "microsoft.custom_event.name";
        private const string ClientIpAttributeName = "microsoft.client.ip";
        private const int Version = 2;
        private static readonly Action<LogRecordScope, IDictionary<string, string>> s_processScope = (scope, properties) =>
        {
            foreach (KeyValuePair<string, object?> scopeItem in scope)
            {
                if (string.IsNullOrEmpty(scopeItem.Key) || scopeItem.Key == "{OriginalFormat}")
                {
                    continue;
                }

                // Note: if Key exceeds MaxLength, the entire KVP will be dropped.
                if (scopeItem.Key.Length <= SchemaConstants.MessageData_Properties_MaxKeyLength && scopeItem.Value != null)
                {
                    try
                    {
                        if (!properties.ContainsKey(scopeItem.Key))
                        {
                            properties.Add(scopeItem.Key, Convert.ToString(scopeItem.Value, CultureInfo.InvariantCulture)?.Truncate(SchemaConstants.MessageData_Properties_MaxValueLength)!);
                        }
                    }
                    catch (Exception ex)
                    {
                        AzureMonitorExporterEventSource.Log.FailedToAddScopeItem(scopeItem.Key, ex);
                    }
                }
            }
        };

        internal static (List<TelemetryItem> TelemetryItems, TelemetryCounter TelemetryCounter) OtelToAzureMonitorLogs(Batch<LogRecord> batchLogRecord, AzureMonitorResource? resource, string instrumentationKey)
        {
            List<TelemetryItem> telemetryItems = new List<TelemetryItem>();
            var telemetryCounter = new TelemetryCounter();
            TelemetryItem telemetryItem;

            foreach (var logRecord in batchLogRecord)
            {
                try
                {
                    var properties = new ChangeTrackingDictionary<string, string>();
                    ProcessLogRecordProperties(logRecord, properties, out string? message, out string? eventName, out string? microsoftClientIp);

                    if (logRecord.Exception is not null)
                    {
                        telemetryItem = new TelemetryItem("Exception", logRecord, resource, instrumentationKey, microsoftClientIp)
                        {
                            Data = new MonitorBase
                            {
                                BaseType = "ExceptionData",
                                BaseData = new TelemetryExceptionData(Version, logRecord, message, properties),
                            }
                        };
                        telemetryCounter._exceptionCount++;
                    }
                    else if (eventName is not null)
                    {
                        telemetryItem = new TelemetryItem("Event", logRecord, resource, instrumentationKey, microsoftClientIp)
                        {
                            Data = new MonitorBase
                            {
                                BaseType = "EventData",
                                BaseData = new TelemetryEventData(Version, eventName, properties, message, logRecord),
                            }
                        };
                        telemetryCounter._eventCount++;
                    }
                    else
                    {
                        telemetryItem = new TelemetryItem("Message", logRecord, resource, instrumentationKey, microsoftClientIp)
                        {
                            Data = new MonitorBase
                            {
                                BaseType = "MessageData",
                                BaseData = new MessageData(Version, logRecord, message, properties),
                            }
                        };
                        telemetryCounter._traceCount++;
                    }

                    telemetryItems.Add(telemetryItem);
                }
                catch (Exception ex)
                {
                    AzureMonitorExporterEventSource.Log.FailedToConvertLogRecord(instrumentationKey, ex);
                }
            }

            return (telemetryItems, telemetryCounter);
        }

        internal static void ProcessLogRecordProperties(LogRecord logRecord, IDictionary<string, string> properties, out string? message, out string? eventName, out string? microsoftClientIp)
        {
            eventName = null;
            message = logRecord.Exception?.Message ?? logRecord.FormattedMessage;
            microsoftClientIp = null;

            foreach (KeyValuePair<string, object?> item in logRecord.Attributes ?? Enumerable.Empty<KeyValuePair<string, object?>>())
            {
                if (item.Key == CustomEventAttributeName)
                {
                    eventName = item.Value?.ToString();
                }

                else if (item.Key == ClientIpAttributeName)
                {
                    microsoftClientIp = item.Value?.ToString().Truncate(SchemaConstants.MessageData_Properties_MaxValueLength);
                }
                // Note: if Key exceeds MaxLength, the entire KVP will be dropped.
                else if (item.Key.Length <= SchemaConstants.MessageData_Properties_MaxKeyLength && item.Value != null)
                {
                    try
                    {
                        if (item.Key == "{OriginalFormat}")
                        {
                            if (logRecord.Exception?.Message != null)
                            {
                                properties.Add("OriginalFormat", item.Value.ToString().Truncate(SchemaConstants.MessageData_Properties_MaxValueLength)!);
                            }
                            else if (message == null)
                            {
                                message = item.Value.ToString();
                            }
                        }
                        else
                        {
                            if (!properties.ContainsKey(item.Key))
                            {
                                properties.Add(item.Key, item.Value.ToString().Truncate(SchemaConstants.MessageData_Properties_MaxValueLength)!);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        AzureMonitorExporterEventSource.Log.FailedToAddLogAttribute(item.Key, ex);
                    }
                }
            }

            logRecord.ForEachScope(s_processScope, properties);

            if (eventName is null) // we will omit the following properties if we've detected a custom event.
            {
                var categoryName = logRecord.CategoryName;
                if (!properties.ContainsKey("CategoryName") && !string.IsNullOrEmpty(categoryName))
                {
                    properties.Add("CategoryName", categoryName.Truncate(SchemaConstants.KVP_MaxValueLength)!);
                }

                if (!properties.ContainsKey("EventId") && logRecord.EventId.Id != 0)
                {
                    properties.Add("EventId", logRecord.EventId.Id.ToString(CultureInfo.InvariantCulture));
                }

                if (!properties.ContainsKey("EventName") && !string.IsNullOrEmpty(logRecord.EventId.Name))
                {
                    properties.Add("EventName", logRecord.EventId.Name!.Truncate(SchemaConstants.KVP_MaxValueLength));
                }
            }
        }

        internal static string GetProblemId(Exception exception)
        {
            string methodName = "UnknownMethod";
            int methodOffset = System.Diagnostics.StackFrame.OFFSET_UNKNOWN;

            var exceptionType = exception.GetType().FullName;
            var stackTrace = new StackTrace(exception);
            var exceptionStackFrame = stackTrace.GetFrame(0);

            if (exceptionStackFrame != null)
            {
                MethodBase? methodBase = exceptionStackFrame.GetMethodWithoutWarning();

                if (methodBase == null)
                {
                    // In an AOT scenario GetMethod() will return null.
                    // Instead, call ToString() which gives a string like this:
                    // "MethodName + 0x00 at offset 000 in file:line:column <filename unknown>:0:0"
                    methodName = exceptionStackFrame.ToString();
                    methodOffset = System.Diagnostics.StackFrame.OFFSET_UNKNOWN;
                }
                else
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
    }
}
