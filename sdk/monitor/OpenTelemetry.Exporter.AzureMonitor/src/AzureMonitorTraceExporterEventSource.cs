// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.Tracing;

namespace OpenTelemetry.Exporter.AzureMonitor
{
    [EventSource(Name = EventSourceName)]
    internal sealed class AzureMonitorTraceExporterEventSource : EventSource
    {
        private const string EventSourceName = "OpenTelemetry-TraceExporter-AzureMonitor";
        public static AzureMonitorTraceExporterEventSource Log = new AzureMonitorTraceExporterEventSource();

        [NonEvent]
        public void Write(string name, object value)
        {
            if (this.IsEnabled(EventLevel.Critical, EventKeywords.All) && name.EndsWith(EventLevelSuffix.Critical, StringComparison.Ordinal))
            {
                WriteCritical($"{name.TrimEnd(EventLevelSuffix.Critical)} - {GetMessage(value)}");
            }
            else if (this.IsEnabled(EventLevel.Error, EventKeywords.All) && name.EndsWith(EventLevelSuffix.Error, StringComparison.Ordinal))
            {
                WriteError($"{name.TrimEnd(EventLevelSuffix.Error)} - {GetMessage(value)}");
            }
            else if (this.IsEnabled(EventLevel.Warning, EventKeywords.All) && name.EndsWith(EventLevelSuffix.Warning, StringComparison.Ordinal))
            {
                WriteWarning($"{name.TrimEnd(EventLevelSuffix.Warning)} - {GetMessage(value)}");
            }
            else if (this.IsEnabled(EventLevel.Informational, EventKeywords.All) && name.EndsWith(EventLevelSuffix.Informational, StringComparison.Ordinal))
            {
                WriteInformational($"{name.TrimEnd(EventLevelSuffix.Informational)} - {GetMessage(value)}");
            }
            else if (this.IsEnabled(EventLevel.Verbose, EventKeywords.All) && name.EndsWith(EventLevelSuffix.Verbose, StringComparison.Ordinal))
            {
                WriteVerbose($"{name.TrimEnd(EventLevelSuffix.Verbose)} - {GetMessage(value)}");
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
