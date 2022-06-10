// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;

using Azure.Core.Shared;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    [EventSource(Name = EventSourceName)]
    internal sealed class AzureMonitorExporterEventSource : EventSource
    {
        internal const string EventSourceName = "OpenTelemetry-AzureMonitor-Exporter";

        internal static readonly AzureMonitorExporterEventSource Log = new AzureMonitorExporterEventSource();
        internal static readonly AzureMonitorExporterEventListener Listener = new AzureMonitorExporterEventListener();

        [Event(1, Message = "{0} - {1}", Level = EventLevel.Critical)]
        public void WriteCritical(string name, string message) => Write(EventLevel.Critical, 1, name, message);

        [Event(2, Message = "{0} - {1}", Level = EventLevel.Error)]
        public void WriteError(string name, string message) => Write(EventLevel.Error, 2, name, message);

        [NonEvent]
        public void WriteError(string name, Exception exception) => WriteException(EventLevel.Error, 2, name, exception);

        [Event(3, Message = "{0} - {1}", Level = EventLevel.Warning)]
        public void WriteWarning(string name, string message) => Write(EventLevel.Warning, 3, name, message);

        [NonEvent]
        public void WriteWarning(string name, Exception exception) => WriteException(EventLevel.Warning, 3, name, exception);

        [Event(4, Message = "{0} - {1}", Level = EventLevel.Informational)]
        public void WriteInformational(string name, string message) => Write(EventLevel.Informational, 4, name, message);

        [Event(5, Message = "{0} - {1}", Level = EventLevel.Verbose)]
        public void WriteVerbose(string name, string message) => Write(EventLevel.Verbose, 5, name, message);

        [NonEvent]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void Write(EventLevel eventLevel, int eventId, string name, string message)
        {
            if (IsEnabled(eventLevel, EventKeywords.All))
            {
                WriteEvent(eventId, name, message);
            }
        }

        [NonEvent]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void WriteException(EventLevel eventLevel, int eventId, string name, Exception exception)
        {
            if (IsEnabled(eventLevel, EventKeywords.All))
            {
                WriteEvent(eventId, name, exception.LogAsyncException().ToInvariantString());
            }
        }

        public class AzureMonitorExporterEventListener : EventListener
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
                if (eventSource?.Name == EventSourceName)
                {
                    eventSources.Add(eventSource);
                    EnableEvents(eventSource, EventLevel.Verbose, (EventKeywords)(-1));
                }

                base.OnEventSourceCreated(eventSource);
            }

            protected override void OnEventWritten(EventWrittenEventArgs eventData)
            {
                string message = EventSourceEventFormatting.Format(eventData);
                TelemetryDebugWriter.WriteMessage($"{eventData.EventSource.Name} - EventId: [{eventData.EventId}], EventName: [{eventData.EventName}], Message: [{message}]");
            }
        }
    }
}
