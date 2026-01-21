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
        private const string AvailabilityIdAttributeName = "microsoft.availability.id";
        private const string AvailabilityNameAttributeName = "microsoft.availability.name";
        private const string AvailabilityDurationAttributeName = "microsoft.availability.duration";
        private const string AvailabilitySuccessAttributeName = "microsoft.availability.success";
        private const string AvailabilityRunLocationAttributeName = "microsoft.availability.runLocation";
        private const string AvailabilityMessageAttributeName = "microsoft.availability.message";
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

        internal static (List<TelemetryItem> TelemetryItems, TelemetrySchemaTypeCounter TelemetrySchemaTypeCounter) OtelToAzureMonitorLogs(Batch<LogRecord> batchLogRecord, AzureMonitorResource? resource, string instrumentationKey)
        {
            List<TelemetryItem> telemetryItems = new List<TelemetryItem>(capacity: (int)batchLogRecord.Count);
            var telemetrySchemaTypeCounter = new TelemetrySchemaTypeCounter();
            TelemetryItem telemetryItem;

            foreach (var logRecord in batchLogRecord)
            {
                try
                {
                    var properties = new ChangeTrackingDictionary<string, string>();
                    ProcessLogRecordProperties(logRecord, properties, out string? message, out string? eventName, out string? microsoftClientIp, out AvailabilityInfo? availabilityInfo);

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
                        telemetrySchemaTypeCounter._exceptionCount++;
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
                        telemetrySchemaTypeCounter._eventCount++;
                    }
                    else if (availabilityInfo is not null)
                    {
                        telemetryItem = new TelemetryItem("Availability", logRecord, resource, instrumentationKey, microsoftClientIp)
                        {
                            Data = new MonitorBase
                            {
                                BaseType = "AvailabilityData",
                                BaseData = new AvailabilityData(Version, availabilityInfo.Value, properties, logRecord),
                            }
                        };
                        telemetrySchemaTypeCounter._availabilityCount++;
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
                        telemetrySchemaTypeCounter._traceCount++;
                    }

                    telemetryItems.Add(telemetryItem);
                }
                catch (Exception ex)
                {
                    AzureMonitorExporterEventSource.Log.FailedToConvertLogRecord(instrumentationKey, ex);
                }
            }

            return (telemetryItems, telemetrySchemaTypeCounter);
        }

        internal static void ProcessLogRecordProperties(LogRecord logRecord, IDictionary<string, string> properties, out string? message, out string? eventName, out string? microsoftClientIp, out AvailabilityInfo? availabilityInfo)
        {
            eventName = null;
            availabilityInfo = null;
            message = logRecord.Exception?.Message ?? logRecord.FormattedMessage;
            microsoftClientIp = null;
            bool hasAvailabilityData = false;

            foreach (KeyValuePair<string, object?> item in logRecord.Attributes ?? Enumerable.Empty<KeyValuePair<string, object?>>())
            {
                if (item.Key == CustomEventAttributeName)
                {
                    eventName = item.Value?.ToString();
                }
                else if (item.Key == AvailabilityNameAttributeName)
                {
                    hasAvailabilityData = true;
                    break;
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

            // If we detected availability data, do a second pass to extract all availability attributes
            if (hasAvailabilityData)
            {
                availabilityInfo = ExtractAvailabilityInfo(logRecord, properties, message, out microsoftClientIp);
            }

            logRecord.ForEachScope(s_processScope, properties);

            if (eventName is null && availabilityInfo is null) // we will omit the following properties if we've detected a custom event or availability.
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

        private static AvailabilityInfo? ExtractAvailabilityInfo(LogRecord logRecord, IDictionary<string, string> properties, string? message, out string? microsoftClientIp)
        {
            string? availabilityId = null;
            string? availabilityName = null;
            string? availabilityDuration = null;
            string? availabilitySuccess = null;
            string? availabilityRunLocation = null;
            string? availabilityMessage = null;
            microsoftClientIp = null;

            foreach (KeyValuePair<string, object?> item in logRecord.Attributes ?? Enumerable.Empty<KeyValuePair<string, object?>>())
            {
                if (item.Key == AvailabilityIdAttributeName)
                {
                    availabilityId = item.Value?.ToString();
                }
                else if (item.Key == AvailabilityNameAttributeName)
                {
                    availabilityName = item.Value?.ToString();
                }
                else if (item.Key == AvailabilityDurationAttributeName)
                {
                    availabilityDuration = item.Value?.ToString();
                }
                else if (item.Key == AvailabilitySuccessAttributeName)
                {
                    availabilitySuccess = item.Value?.ToString();
                }
                else if (item.Key == AvailabilityRunLocationAttributeName)
                {
                    availabilityRunLocation = item.Value?.ToString();
                }
                else if (item.Key == AvailabilityMessageAttributeName)
                {
                    availabilityMessage = item.Value?.ToString();
                }
                else if (item.Key == ClientIpAttributeName)
                {
                    microsoftClientIp = item.Value?.ToString().Truncate(SchemaConstants.AvailabilityData_Properties_MaxValueLength);
                }
                else if (item.Key.Length <= SchemaConstants.AvailabilityData_Properties_MaxValueLength && item.Value != null && !properties.ContainsKey(item.Key))
                {
                    properties.Add(item.Key, item.Value.ToString().Truncate(SchemaConstants.AvailabilityData_Properties_MaxValueLength)!);
                }
            }

            // Construct availability info if we have required fields
            if (!string.IsNullOrEmpty(availabilityId) && !string.IsNullOrEmpty(availabilityName) &&
                !string.IsNullOrEmpty(availabilityDuration) && !string.IsNullOrEmpty(availabilitySuccess))
            {
                return new AvailabilityInfo
                {
                    Id = availabilityId!,
                    Name = availabilityName!,
                    Duration = availabilityDuration!,
                    Success = bool.TryParse(availabilitySuccess, out var success) ? success : false,
                    RunLocation = availabilityRunLocation,
                    Message = availabilityMessage ?? message
                };
            }

            return null;
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

    /// <summary>
    /// Struct to hold availability test information extracted from log attributes.
    /// </summary>
    internal struct AvailabilityInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
        public bool Success { get; set; }
        public string? RunLocation { get; set; }
        public string? Message { get; set; }
    }
}
