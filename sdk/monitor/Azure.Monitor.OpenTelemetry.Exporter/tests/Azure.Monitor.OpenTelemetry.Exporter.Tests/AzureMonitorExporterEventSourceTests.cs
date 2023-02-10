// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable // TODO: remove and fix errors

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using Azure.Core.Shared;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;

using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    /// <summary>
    /// These tests depend on the <see cref="AzureMonitorExporterEventListener"/> to subscribe to the <see cref="AzureMonitorExporterEventSource"/> and write events to the <see cref="TelemetryDebugWriter"/>.
    /// </summary>
    public class AzureMonitorExporterEventSourceTests
    {
        [Fact]
        public void VerifyEventSource_Critical() => Test(writeAction: AzureMonitorExporterEventSource.Log.WriteCritical, expectedId: 1, expectedName: "WriteCritical");

        [Fact]
        public void VerifyEventSource_Error() => Test(writeAction: AzureMonitorExporterEventSource.Log.WriteError, expectedId: 2, expectedName: "WriteError");

        [Fact]
        public void VerifyEventSource_Error_WithException() => TestException(writeAction: AzureMonitorExporterEventSource.Log.WriteError, expectedId: 2, expectedName: "WriteError");

        [Fact]
        public void VerifyEventSource_Error_WithAggregateException() => TestAggregateException(writeAction: AzureMonitorExporterEventSource.Log.WriteError, expectedId: 2, expectedName: "WriteError");

        [Fact]
        public void VerifyEventSource_Warning() => Test(writeAction: AzureMonitorExporterEventSource.Log.WriteWarning, expectedId: 3, expectedName: "WriteWarning");

        [Fact]
        public void VerifyEventSource_Warning_WithException() => TestException(writeAction: AzureMonitorExporterEventSource.Log.WriteWarning, expectedId: 3, expectedName: "WriteWarning");

        [Fact]
        public void VerifyEventSource_Warning_WithAggregateException() => TestAggregateException(writeAction: AzureMonitorExporterEventSource.Log.WriteWarning, expectedId: 3, expectedName: "WriteWarning");

        [Fact]
        public void VerifyEventSource_Informational() => Test(writeAction: AzureMonitorExporterEventSource.Log.WriteInformational, expectedId: 4, expectedName: "WriteInformational");

        [Fact]
        public void VerifyEventSource_Verbose() => Test(writeAction: AzureMonitorExporterEventSource.Log.WriteVerbose, expectedId: 5, expectedName: "WriteVerbose");

        private void Test(Action<string, string> writeAction, int expectedId, string expectedName)
        {
            using var listener = new TestListener();

            var name = nameof(AzureMonitorExporterEventSourceTests);

            writeAction(name, "hello world");

            var eventData = listener.Events.Single();
            Assert.Equal(AzureMonitorExporterEventSource.EventSourceName, eventData.EventSource.Name);
            Assert.Equal(expectedId, eventData.EventId);
            Assert.Equal(expectedName, eventData.EventName);

            var message = EventSourceEventFormatting.Format(eventData);
            Assert.Equal($"{name} - hello world", message);
        }

        private void TestException(Action<string, Exception> writeAction, int expectedId, string expectedName)
        {
            using var listener = new TestListener();

            var name = nameof(AzureMonitorExporterEventSourceTests);

            writeAction(name, new Exception("hello world"));

            var eventData = listener.Events.Single();
            Assert.Equal(AzureMonitorExporterEventSource.EventSourceName, eventData.EventSource.Name);
            Assert.Equal(expectedId, eventData.EventId);
            Assert.Equal(expectedName, eventData.EventName);

            var message = EventSourceEventFormatting.Format(eventData);
            Assert.Equal($"{name} - System.Exception: hello world", message);
        }

        private void TestAggregateException(Action<string, Exception> writeAction, int expectedId, string expectedName)
        {
            using var listener = new TestListener();

            var name = nameof(AzureMonitorExporterEventSourceTests);

            writeAction(name, new AggregateException(new Exception("hello world_1"), new Exception("hello world_2)")));

            var eventData = listener.Events.Single();
            Assert.Equal(AzureMonitorExporterEventSource.EventSourceName, eventData.EventSource.Name);
            Assert.Equal(expectedId, eventData.EventId);
            Assert.Equal(expectedName, eventData.EventName);

            var message = EventSourceEventFormatting.Format(eventData);
            Assert.Equal($"{name} - System.Exception: hello world_1", message);
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
                if (eventSource?.Name == AzureMonitorExporterEventSource.EventSourceName)
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
