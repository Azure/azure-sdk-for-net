// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    /// <summary>
    /// These tests depend on the <see cref="AzureMonitorExporterEventListener"/> to subscribe to the <see cref="AzureMonitorExporterEventSource"/> and write events to the <see cref="TelemetryDebugWriter"/>.
    /// </summary>
    public class AzureMonitorExporterEventSourceTests
    {
        /// <summary>
        /// This test uses reflection to invoke every Event method in our EventSource class.
        /// This validates that parameters are logged and helps to confirm that EventIds are correct.
        /// </summary>
        [Fact]
        public void EventSourceTest_AzureMonitorExporterEventSource()
        {
            EventSourceTestHelper.MethodsAreImplementedConsistentlyWithTheirAttributes(AzureMonitorExporterEventSource.Log);
        }

        public class TestListener : EventListener
        {
            private readonly List<EventSource> eventSources = new();
            private readonly Guid guid = Guid.NewGuid();

            public List<EventWrittenEventArgs> Events = new();

            public TestListener()
            {
                EventSource.SetCurrentThreadActivityId(guid);
            }

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
                if (eventSource.Name == AzureMonitorExporterEventSource.EventSourceName)
                {
                    this.eventSources.Add(eventSource);
                    this.EnableEvents(eventSource, EventLevel.Verbose, EventKeywords.All);
                }

                base.OnEventSourceCreated(eventSource);
            }

            protected override void OnEventWritten(EventWrittenEventArgs eventData)
            {
                if (eventData.ActivityId == this.guid)
                {
                    this.Events.Add(eventData);
                }
            }
        }
    }
}
