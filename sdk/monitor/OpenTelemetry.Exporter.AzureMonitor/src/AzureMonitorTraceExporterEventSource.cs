// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.Tracing;

namespace OpenTelemetry.Exporter.AzureMonitor
{
    [EventSource(Name = EventSourceName)]
    internal sealed class AzureMonitorTraceExporterEventSource : EventSource
    {
        private const string EventSourceName = "OpenTelemetry-TraceExporter-AzureMonitor";
        public static AzureMonitorTraceExporterEventSource Log = new AzureMonitorTraceExporterEventSource();

        [NonEvent]
        public void ConfigurationStringParseWarning(string message)
        {
            if (this.IsEnabled(EventLevel.Warning, (EventKeywords)(-1)))
            {
                this.WarnToParseConfigurationString(message);
            }
        }

        [Event(1, Message = "{0}", Level = EventLevel.Warning)]
        public void WarnToParseConfigurationString(string message) => this.WriteEvent(1, message);
    }
}
