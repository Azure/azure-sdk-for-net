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
        public void FailedExport(Exception ex)
        {
            if (this.IsEnabled(EventLevel.Error, EventKeywords.All))
            {
                this.FailedExport(ex.ToInvariantString());
            }
        }

        [NonEvent]
        public void SdkVersionCreateFailed(Exception ex)
        {
            if (this.IsEnabled(EventLevel.Warning, EventKeywords.All))
            {
                this.WarnSdkVersionCreateException(ex.ToInvariantString());
            }
        }

        [NonEvent]
        public void ConnectionStringError(Exception ex)
        {
            if (this.IsEnabled(EventLevel.Error, EventKeywords.All))
            {
                this.ConnectionStringError(ex.ToInvariantString());
            }
        }

        [Event(1, Message = "Failed to export activities: '{0}'", Level = EventLevel.Error)]
        public void FailedExport(string exception) => this.WriteEvent(1, exception);

        [Event(2, Message = "Error creating SdkVersion : '{0}'", Level = EventLevel.Warning)]
        public void WarnSdkVersionCreateException(string message) => this.WriteEvent(2, message);

        [Event(3, Message = "Connection String Error: '{0}'", Level = EventLevel.Error)]
        public void ConnectionStringError(string message) => this.WriteEvent(3, message);
    }
}
