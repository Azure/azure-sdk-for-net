// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Diagnostics.Tracing;
using System.Linq;

using NUnit.Framework;

namespace OpenTelemetry.Exporter.AzureMonitor
{
    public class AzureMonitorTraceExporterEventSourceTests
    {
        [Test]
        public void TestWarning()
        {
            var listener = new InMemoryEventListener(AzureMonitorTraceExporterEventSource.Log);

            string testMessage = "hello, this is a warning";
            AzureMonitorTraceExporterEventSource.Log.WriteWarning(testMessage);

            listener.Messages.TryDequeue(out string message);
            Assert.AreEqual(testMessage, message);
        }

        [Test]
        public void TestError()
        {
            var listener = new InMemoryEventListener(AzureMonitorTraceExporterEventSource.Log);

            string testMessage = "hello, this is an error";
            AzureMonitorTraceExporterEventSource.Log.WriteError(testMessage);

            listener.Messages.TryDequeue(out string message);
            Assert.AreEqual(testMessage, message);
        }

        [Test]
        public void TestVerbose()
        {
            var listener = new InMemoryEventListener(AzureMonitorTraceExporterEventSource.Log);

            string testMessage = "hello, this is a verbose";
            AzureMonitorTraceExporterEventSource.Log.WriteVerbose(testMessage);

            listener.Messages.TryDequeue(out string message);
            Assert.AreEqual(testMessage, message);
        }

        [Test]
        public void TestException()
        {
            var listener = new InMemoryEventListener(AzureMonitorTraceExporterEventSource.Log);
            string message = "test message";
            string prefix = "my custom prefix";

            try
            {
                TestClassThrowsException.ThrowException(message);
            }
            catch (Exception ex)
            {
                AzureMonitorTraceExporterEventSource.Log.WriteException(prefix, ex);
            }

            listener.Messages.TryDequeue(out string result);

            var test = result.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            Assert.IsTrue(test[0].StartsWith(prefix));
            Assert.IsTrue(test[0].Contains(message));
        }

        private class TestClassThrowsException
        {
            public static void ThrowException(string message) => One(message);

            private static void One(string message) => Two(message);

            private static void Two(string message) => Three(message);

            private static void Three(string message) => throw new Exception(message);
        }

        private class InMemoryEventListener : EventListener
        {
            public ConcurrentQueue<string> Messages = new ConcurrentQueue<string>();
            public ConcurrentQueue<EventWrittenEventArgs> Events = new ConcurrentQueue<EventWrittenEventArgs>();

            public InMemoryEventListener(EventSource eventSource, EventLevel minLevel = EventLevel.Verbose) => this.EnableEvents(eventSource, minLevel);

            protected override void OnEventWritten(EventWrittenEventArgs eventData)
            {
                this.Events.Enqueue(eventData);
                this.Messages.Enqueue(eventData.Payload.Any() ? string.Format(eventData.Message, eventData.Payload.ToArray()) : eventData.Message);
            }
        }
    }
}
