// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable // TODO: remove and fix errors

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Text;

using Azure.Monitor.OpenTelemetry.Exporter.Models;

using Microsoft.Extensions.Logging;

using OpenTelemetry;
using OpenTelemetry.Logs;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal class LogsHelper
    {
        private const int Version = 2;
        private static readonly ConcurrentDictionary<int, string> s_depthCache = new ConcurrentDictionary<int, string>();
        private static readonly Func<int, string> s_convertDepthToStringRef = ConvertDepthToString;

        internal static List<TelemetryItem> OtelToAzureMonitorLogs(Batch<LogRecord> batchLogRecord, AzureMonitorResource resource, string instrumentationKey)
        {
            List<TelemetryItem> telemetryItems = new List<TelemetryItem>();
            TelemetryItem telemetryItem;

            foreach (var logRecord in batchLogRecord)
            {
                telemetryItem = new TelemetryItem(logRecord, resource, instrumentationKey);
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
            string message = logRecord.Exception?.Message ?? logRecord.FormattedMessage;

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

            WriteScopeInformation(logRecord, properties);

            if (logRecord.EventId.Id != 0)
            {
                properties.Add("EventId", logRecord.EventId.Id.ToString(CultureInfo.InvariantCulture));
            }

            if (!string.IsNullOrEmpty(logRecord.EventId.Name))
            {
                properties.Add("EventName", logRecord.EventId.Name.Truncate(SchemaConstants.KVP_MaxValueLength));
            }

            return message;
        }

        internal static void WriteScopeInformation(LogRecord logRecord, IDictionary<string, string> properties)
        {
            StringBuilder builder = null;
            int originalScopeDepth = 1;
            logRecord.ForEachScope(ProcessScope, properties);

            void ProcessScope(LogRecordScope scope, IDictionary<string, string> properties)
            {
                int valueDepth = 1;
                foreach (KeyValuePair<string, object> scopeItem in scope)
                {
                    if (string.IsNullOrEmpty(scopeItem.Key))
                    {
                        builder ??= new StringBuilder();
                        builder.Append(" => ").Append(scope.Scope);
                    }
                    else if (scopeItem.Key == "{OriginalFormat}")
                    {
                        properties.Add($"OriginalFormatScope_{s_depthCache.GetOrAdd(originalScopeDepth, s_convertDepthToStringRef)}", Convert.ToString(scope.Scope.ToString(), CultureInfo.InvariantCulture));
                    }
                    else if (!properties.TryGetValue(scopeItem.Key, out _))
                    {
                        properties.Add(scopeItem.Key, Convert.ToString(scopeItem.Value, CultureInfo.InvariantCulture));
                    }
                    else
                    {
                        properties.Add($"{scopeItem.Key}_{s_depthCache.GetOrAdd(originalScopeDepth, s_convertDepthToStringRef)}_{s_depthCache.GetOrAdd(valueDepth, s_convertDepthToStringRef)}",
                                        Convert.ToString(scopeItem.Value, CultureInfo.InvariantCulture));
                        valueDepth++;
                    }
                }

                originalScopeDepth++;
            }

            if (builder?.Length > 0)
            {
                properties.Add("Scope", builder.ToString().Truncate(SchemaConstants.KVP_MaxValueLength));
            }
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
                        properties.Add("OriginalFormat", item.Value.ToString().Truncate(SchemaConstants.KVP_MaxValueLength));
                    }
                }
                else if (item.Key.Length <= SchemaConstants.KVP_MaxKeyLength)
                {
                    // Note: if Key exceeds MaxLength, the entire KVP will be dropped.

                    properties.Add(item.Key, item.Value.ToString().Truncate(SchemaConstants.KVP_MaxValueLength));
                }
            }
        }

        private static string ConvertDepthToString(int depth) => $"{depth}";
    }
}
