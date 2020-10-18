// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;

namespace OpenTelemetry.Exporter.AzureMonitor
{
    [EventSource(Name = EventSourceName)]
    internal sealed class AzureMonitorTraceExporterEventSource : EventSource
    {
        private const string EventSourceName = "OpenTelemetry-TraceExporter-AzureMonitor";
        public static AzureMonitorTraceExporterEventSource Log = new AzureMonitorTraceExporterEventSource();
        public readonly IReadOnlyDictionary<string, EventLevel> EventLevelMap = new Dictionary<string, EventLevel>
        {
            [EventLevelSuffix.Critical] = EventLevel.Critical,
            [EventLevelSuffix.Error] = EventLevel.Error,
            [EventLevelSuffix.Warning] = EventLevel.Warning,
            [EventLevelSuffix.Informational] = EventLevel.Informational,
            [EventLevelSuffix.Verbose] = EventLevel.Verbose
        };

        [NonEvent]
        public void Write(string name, object value)
        {
            var eventLevel = EventLevelMap[name.Substring(name.LastIndexOf('.'))];
            if (this.IsEnabled(eventLevel, EventKeywords.All))
            {
                switch (eventLevel)
                {
                    case EventLevel.Critical:
                        WriteCritical($"{name.TrimEnd(EventLevelSuffix.Critical)} - {GetMessage(value)}");
                        break;
                    case EventLevel.Error:
                        WriteError($"{name.TrimEnd(EventLevelSuffix.Error)} - {GetMessage(value)}");
                        break;
                    case EventLevel.Informational:
                        WriteInformational($"{name.TrimEnd(EventLevelSuffix.Informational)} - {GetMessage(value)}");
                        break;
                    case EventLevel.Verbose:
                        WriteVerbose($"{name.TrimEnd(EventLevelSuffix.Verbose)} - {GetMessage(value)}");
                        break;
                    case EventLevel.Warning:
                        WriteWarning($"{name.TrimEnd(EventLevelSuffix.Warning)} - {GetMessage(value)}");
                        break;
                }
            }
        }

        [Event(1, Message = "{0}", Level = EventLevel.Critical)]
        public void WriteCritical(string message) => this.WriteEvent(1, message);

        [Event(2, Message = "{0}", Level = EventLevel.Error)]
        public void WriteError(string message) => this.WriteEvent(2, message);

        [Event(3, Message = "{0}", Level = EventLevel.Warning)]
        public void WriteWarning(string message) => this.WriteEvent(3, message);

        [Event(4, Message = "{0}", Level = EventLevel.Informational)]
        public void WriteInformational(string message) => this.WriteEvent(4, message);

        [Event(5, Message = "{0}", Level = EventLevel.Verbose)]
        public void WriteVerbose(string message) => this.WriteEvent(5, message);

        private static string GetMessage(object value)
        {
            return value is Exception exception ? exception.ToInvariantString() : value.ToString();
        }
    }
}
