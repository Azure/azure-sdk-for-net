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
        private const string EndUserPseudoIdAttributeName = "enduser.pseudo.id";
        private const string EndUserIdAttributeName = "enduser.id";
        private const string UserAgentOriginalAttributeName = "user_agent.original";
        private const string OperationNameAttributeName = "microsoft.operation_name";
        private const string SessionIdAttributeName = "microsoft.session.id";
        private const string DeviceIdAttributeName = "ai.device.id";
        private const string DeviceModelAttributeName = "ai.device.model";
        private const string DeviceTypeAttributeName = "ai.device.type";
        private const string DeviceOsVersionAttributeName = "ai.device.osVersion";
        private const string SyntheticSourceAttributeName = "microsoft.synthetic_source";
        private const string UserAccountIdAttributeName = "microsoft.user.account_id";
        private const string AvailabilityIdAttributeName = "microsoft.availability.id";
        private const string AvailabilityNameAttributeName = "microsoft.availability.name";
        private const string AvailabilityDurationAttributeName = "microsoft.availability.duration";
        private const string AvailabilitySuccessAttributeName = "microsoft.availability.success";
        private const string AvailabilityRunLocationAttributeName = "microsoft.availability.runLocation";
        private const string AvailabilityMessageAttributeName = "microsoft.availability.message";
        private const string AvailabilityTestTimestampAttributeName = "microsoft.availability.testTimestamp";
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
                            var maxValueLength = SchemaConstants.GenAiProperties.Contains(scopeItem.Key)
                                ? SchemaConstants.GenAi_Properties_MaxValueLength
                                : SchemaConstants.MessageData_Properties_MaxValueLength;
                            var stringValue = Convert.ToString(scopeItem.Value, CultureInfo.InvariantCulture)?.Truncate(maxValueLength)!;
                            properties.Add(scopeItem.Key, stringValue);
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
                    ProcessLogRecordProperties(logRecord, properties, out string? message, out string? eventName, out LogContextInfo logContext, out AvailabilityInfo? availabilityInfo);

                    if (logRecord.Exception is not null)
                    {
                        telemetryItem = new TelemetryItem("Exception", logRecord, resource, instrumentationKey, logContext)
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
                        telemetryItem = new TelemetryItem("Event", logRecord, resource, instrumentationKey, logContext)
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
                        DateTimeOffset envelopeTime = availabilityInfo.Value.TestTimestamp != null
                            && DateTimeOffset.TryParse(
                                availabilityInfo.Value.TestTimestamp,
                                CultureInfo.InvariantCulture,
                                System.Globalization.DateTimeStyles.RoundtripKind,
                                out var parsedTs)
                            ? parsedTs.ToUniversalTime()
                            : TelemetryItem.FormatUtcTimestamp(logRecord.Timestamp);

                        telemetryItem = new TelemetryItem("Availability", envelopeTime, logRecord, resource, instrumentationKey, logContext)
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
                        telemetryItem = new TelemetryItem("Message", logRecord, resource, instrumentationKey, logContext)
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

        internal static void ProcessLogRecordProperties(LogRecord logRecord, IDictionary<string, string> properties, out string? message, out string? eventName, out LogContextInfo logContext, out AvailabilityInfo? availabilityInfo)
        {
            eventName = null;
            availabilityInfo = null;
            message = logRecord.Exception?.Message ?? logRecord.FormattedMessage;
            logContext = default;
            bool hasAvailabilityData = false;

            foreach (KeyValuePair<string, object?> item in logRecord.Attributes ?? Enumerable.Empty<KeyValuePair<string, object?>>())
            {
                switch (item.Key)
                {
                    case CustomEventAttributeName:
                        eventName = item.Value?.ToString();
                        break;
                    case AvailabilityNameAttributeName:
                        hasAvailabilityData = true;
                        break;
                    case ClientIpAttributeName:
                        logContext.MicrosoftClientIp = item.Value?.ToString().Truncate(SchemaConstants.MessageData_Properties_MaxValueLength);
                        break;
                    case EndUserPseudoIdAttributeName:
                        logContext.EndUserPseudoId = item.Value?.ToString();
                        break;
                    case EndUserIdAttributeName:
                        logContext.EndUserId = item.Value?.ToString();
                        break;
                    case UserAgentOriginalAttributeName:
                        logContext.UserAgent = item.Value?.ToString();
                        break;
                    case OperationNameAttributeName:
                        logContext.OperationName = item.Value?.ToString();
                        break;
                    case SessionIdAttributeName:
                        logContext.SessionId = item.Value?.ToString();
                        break;
                    case DeviceIdAttributeName:
                        logContext.DeviceId = item.Value?.ToString();
                        break;
                    case DeviceModelAttributeName:
                        logContext.DeviceModel = item.Value?.ToString();
                        break;
                    case DeviceTypeAttributeName:
                        logContext.DeviceType = item.Value?.ToString();
                        break;
                    case DeviceOsVersionAttributeName:
                        logContext.DeviceOsVersion = item.Value?.ToString();
                        break;
                    case SyntheticSourceAttributeName:
                        logContext.SyntheticSource = item.Value?.ToString();
                        break;
                    case UserAccountIdAttributeName:
                        logContext.UserAccountId = item.Value?.ToString();
                        break;
                    default:
                        // Note: if Key exceeds MaxLength, the entire KVP will be dropped.
                        if (item.Key.Length <= SchemaConstants.MessageData_Properties_MaxKeyLength && item.Value != null)
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
                                        var maxValueLength = SchemaConstants.GenAiProperties.Contains(item.Key)
                                            ? SchemaConstants.GenAi_Properties_MaxValueLength
                                            : SchemaConstants.MessageData_Properties_MaxValueLength;
                                        var stringValue = item.Value.ToString().Truncate(maxValueLength)!;
                                        properties.Add(item.Key, stringValue);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                AzureMonitorExporterEventSource.Log.FailedToAddLogAttribute(item.Key, ex);
                            }
                        }

                        break;
                }

                if (hasAvailabilityData)
                {
                    break;
                }
            }

            // If we detected availability data, do a second pass to extract all availability attributes
            if (hasAvailabilityData)
            {
                availabilityInfo = ExtractAvailabilityInfo(logRecord, properties, message, out logContext);
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

        private static AvailabilityInfo? ExtractAvailabilityInfo(LogRecord logRecord, IDictionary<string, string> properties, string? message, out LogContextInfo logContext)
        {
            string? availabilityId = null;
            string? availabilityName = null;
            string? availabilityDuration = null;
            string? availabilitySuccess = null;
            string? availabilityRunLocation = null;
            string? availabilityMessage = null;
            string? availabilityTestTimestamp = null;
            logContext = default;

            foreach (KeyValuePair<string, object?> item in logRecord.Attributes ?? Enumerable.Empty<KeyValuePair<string, object?>>())
            {
                switch (item.Key)
                {
                    case AvailabilityIdAttributeName:
                        availabilityId = item.Value?.ToString();
                        break;
                    case AvailabilityNameAttributeName:
                        availabilityName = item.Value?.ToString();
                        break;
                    case AvailabilityDurationAttributeName:
                        availabilityDuration = item.Value?.ToString();
                        break;
                    case AvailabilitySuccessAttributeName:
                        availabilitySuccess = item.Value?.ToString();
                        break;
                    case AvailabilityRunLocationAttributeName:
                        availabilityRunLocation = item.Value?.ToString();
                        break;
                    case AvailabilityMessageAttributeName:
                        availabilityMessage = item.Value?.ToString();
                        break;
                    case AvailabilityTestTimestampAttributeName:
                        availabilityTestTimestamp = item.Value?.ToString();
                        break;
                    case ClientIpAttributeName:
                        logContext.MicrosoftClientIp = item.Value?.ToString().Truncate(SchemaConstants.AvailabilityData_Properties_MaxValueLength);
                        break;
                    case EndUserPseudoIdAttributeName:
                        logContext.EndUserPseudoId = item.Value?.ToString();
                        break;
                    case EndUserIdAttributeName:
                        logContext.EndUserId = item.Value?.ToString();
                        break;
                    case UserAgentOriginalAttributeName:
                        logContext.UserAgent = item.Value?.ToString();
                        break;
                    case OperationNameAttributeName:
                        logContext.OperationName = item.Value?.ToString();
                        break;
                    case SessionIdAttributeName:
                        logContext.SessionId = item.Value?.ToString();
                        break;
                    case DeviceIdAttributeName:
                        logContext.DeviceId = item.Value?.ToString();
                        break;
                    case DeviceModelAttributeName:
                        logContext.DeviceModel = item.Value?.ToString();
                        break;
                    case DeviceTypeAttributeName:
                        logContext.DeviceType = item.Value?.ToString();
                        break;
                    case DeviceOsVersionAttributeName:
                        logContext.DeviceOsVersion = item.Value?.ToString();
                        break;
                    case SyntheticSourceAttributeName:
                        logContext.SyntheticSource = item.Value?.ToString();
                        break;
                    case UserAccountIdAttributeName:
                        logContext.UserAccountId = item.Value?.ToString();
                        break;
                    default:
                        if (item.Key.Length <= SchemaConstants.AvailabilityData_Properties_MaxValueLength && item.Value != null && !properties.ContainsKey(item.Key))
                        {
                            properties.Add(item.Key, item.Value.ToString().Truncate(SchemaConstants.AvailabilityData_Properties_MaxValueLength)!);
                        }

                        break;
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
                    Message = availabilityMessage ?? message,
                    TestTimestamp = availabilityTestTimestamp
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
        public string? TestTimestamp { get; set; }
    }
}
