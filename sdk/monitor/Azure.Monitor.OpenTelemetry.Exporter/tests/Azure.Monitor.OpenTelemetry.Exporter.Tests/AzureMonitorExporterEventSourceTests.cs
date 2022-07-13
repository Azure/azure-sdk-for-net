// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;

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

            // When running tests parallel, it's possible for one test to collect the messages from another test.
            // We use a guid here to be able to find the specific message created by this test.
            var name = $"{nameof(AzureMonitorExporterEventSourceTests)}.{Guid.NewGuid()}";

            writeAction(name, "hello world");

            var eventData = FindEvent(listener.Events, name);
            Assert.Equal(AzureMonitorExporterEventSource.EventSourceName, eventData.EventSource.Name);
            Assert.Equal(expectedId, eventData.EventId);
            Assert.Equal(expectedName, eventData.EventName);

            var message = EventSourceEventFormatting.Format(eventData);
            Assert.Equal($"{name} - hello world", message);
        }

        private void TestException(Action<string, Exception> writeAction, int expectedId, string expectedName)
        {
            using var listener = new TestListener();

            // When running tests parallel, it's possible for one test to collect the messages from another test.
            // We use a guid here to be able to find the specific message created by this test.
            var name = $"{nameof(AzureMonitorExporterEventSourceTests)}.{Guid.NewGuid()}";

            writeAction(name, new Exception("hello world"));

            var eventData = FindEvent(listener.Events, name);
            Assert.Equal(AzureMonitorExporterEventSource.EventSourceName, eventData.EventSource.Name);
            Assert.Equal(expectedId, eventData.EventId);
            Assert.Equal(expectedName, eventData.EventName);

            var message = EventSourceEventFormatting.Format(eventData);
            Assert.Equal($"{name} - System.Exception: hello world", message);
        }

        private void TestAggregateException(Action<string, Exception> writeAction, int expectedId, string expectedName)
        {
            using var listener = new TestListener();

            // When running tests parallel, it's possible for one test to collect the messages from another test.
            // We use a guid here to be able to find the specific message created by this test.
            var name = $"{nameof(AzureMonitorExporterEventSourceTests)}.{Guid.NewGuid()}";

            writeAction(name, new AggregateException(new Exception("hello world_1"), new Exception("hello world_2)")));

            var eventData = FindEvent(listener.Events, name);
            Assert.Equal(AzureMonitorExporterEventSource.EventSourceName, eventData.EventSource.Name);
            Assert.Equal(expectedId, eventData.EventId);
            Assert.Equal(expectedName, eventData.EventName);

            var message = EventSourceEventFormatting.Format(eventData);
            Assert.Equal($"{name} - System.Exception: hello world_1", message);
        }

        private static EventWrittenEventArgs FindEvent(List<EventWrittenEventArgs> list, string name)
        {
            // Note: cannot use Linq here. If the listener grabs another event, Linq will throw InvalidOperationException.

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Payload.Contains(name))
                {
                    return list[i];
                }
            }

            throw new Exception("not found");
        }

        public class TestListener : EventListener
        {
            private readonly List<EventSource> eventSources = new();

            public List<EventWrittenEventArgs> Events = new();

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
                    this.EnableEvents(eventSource, EventLevel.Verbose, (EventKeywords)(-1));
                }

                base.OnEventSourceCreated(eventSource);
            }

            protected override void OnEventWritten(EventWrittenEventArgs eventData)
            {
                this.Events.Add(eventData);
            }
        }
    }
}
