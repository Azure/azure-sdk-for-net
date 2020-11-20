// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Azure.Core.Shared;

namespace Microsoft.OpenTelemetry.Exporter.AzureMonitor
{
    [EventSource(Name = EventSourceName)]
    internal sealed class AzureMonitorExporterEventSource : EventSource
    {
        private const string EventSourceName = "Microsoft-OpenTelemetry-Exporter-AzureMonitor";
        public static AzureMonitorExporterEventSource Log = new AzureMonitorExporterEventSource();
        public static AzureMonitorExporterEventListener Listener = new AzureMonitorExporterEventListener();

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
            var lastIndex = name.LastIndexOf('.');
            var eventLevel = EventLevelMap[name.Substring(lastIndex)];

            if (this.IsEnabled(eventLevel, EventKeywords.All))
            {
                var message = $"{name.Trim(lastIndex)} - {GetMessage(value)}";

                switch (eventLevel)
                {
                    case EventLevel.Critical:
                        WriteCritical(message);
                        break;
                    case EventLevel.Error:
                        WriteError(message);
                        break;
                    case EventLevel.Informational:
                        WriteInformational(message);
                        break;
                    case EventLevel.Verbose:
                        WriteVerbose(message);
                        break;
                    case EventLevel.Warning:
                        WriteWarning(message);
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

        public class AzureMonitorExporterEventListener : EventListener
        {
            private readonly List<EventSource> eventSources = new List<EventSource>();

            public override void Dispose()
            {
                foreach (EventSource eventSource in this.eventSources)
                {
                    this.DisableEvents(eventSource);
                }

                base.Dispose();
                GC.SuppressFinalize(this);
            }

            protected override void OnEventSourceCreated(EventSource eventSource)
            {
                if (eventSource?.Name == EventSourceName)
                {
                    this.eventSources.Add(eventSource);
                    this.EnableEvents(eventSource, EventLevel.Verbose, (EventKeywords)(-1));
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
