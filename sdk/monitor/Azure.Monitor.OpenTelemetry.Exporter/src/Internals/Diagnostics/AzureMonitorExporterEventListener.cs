// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Azure.Core.Shared;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics
{
    internal class AzureMonitorExporterEventListener : EventListener
    {
        private readonly List<EventSource> eventSources = new List<EventSource>();

        public override void Dispose()
        {
            foreach (EventSource eventSource in eventSources)
            {
                DisableEvents(eventSource);
            }

            base.Dispose();
            GC.SuppressFinalize(this);
        }

        protected override void OnEventSourceCreated(EventSource eventSource)
        {
            if (eventSource.Name == AzureMonitorExporterEventSource.EventSourceName)
            {
                eventSources.Add(eventSource);
                EnableEvents(eventSource, EventLevel.Verbose, (EventKeywords)(-1));
            }

            base.OnEventSourceCreated(eventSource);
        }

        protected override void OnEventWritten(EventWrittenEventArgs eventData)
        {
            if (eventData.EventSource.Name == AzureMonitorExporterEventSource.EventSourceName)
            {
                string message = EventSourceEventFormatting.Format(eventData);
                TelemetryDebugWriter.WriteMessage($"{eventData.EventSource.Name} - EventId: [{eventData.EventId}], EventName: [{eventData.EventName}], Message: [{message}]");
            }
        }
    }
}
