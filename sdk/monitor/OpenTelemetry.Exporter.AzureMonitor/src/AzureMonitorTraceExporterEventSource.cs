// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.Tracing;
using System.Runtime.ExceptionServices;

namespace OpenTelemetry.Exporter.AzureMonitor
{
    [EventSource(Name = EventSourceName)]
    internal sealed class AzureMonitorTraceExporterEventSource : EventSource
    {
        private const string EventSourceName = "OpenTelemetry-TraceExporter-AzureMonitor";
        public static AzureMonitorTraceExporterEventSource Log = new AzureMonitorTraceExporterEventSource();

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

        [NonEvent]
        public void WriteException(Exception ex, bool rethrow = false)
        {
            if (this.IsEnabled(EventLevel.Error, EventKeywords.All))
            {
                this.WriteError(ex.ToInvariantString());
            }

            if (rethrow)
            {
                // re-throw with original stack trace
                var capture = ExceptionDispatchInfo.Capture(ex);
                capture?.Throw();
            }
        }
    }
}
