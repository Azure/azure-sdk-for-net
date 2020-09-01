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

            try
            {
                TestClassThrowsException.ThrowException(message);
            }
            catch (Exception ex)
            {
                AzureMonitorTraceExporterEventSource.Log.WriteException(ex);
            }

            listener.Messages.TryDequeue(out string result);

            var test = result.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            Assert.IsTrue(test[0].Contains(message));
        }

        /// <summary>
        /// This test verifies that <see cref="AzureMonitorTraceExporterEventSource.WriteException(Exception, bool)"/> can re-throw an exception without creating a new one.
        /// Creating a new exception would replace the call stack.
        /// </summary>
        [Test]
        public void TestException_VerifyRethrow()
        {
            // The listener is required to enable the EventSource.
            var listener = new InMemoryEventListener(AzureMonitorTraceExporterEventSource.Log);
            Exception exception1 = null, exception2 = null;

            try
            {
                try
                {
                    TestClassThrowsException.ThrowException(string.Empty);
                }
                catch (Exception ex1)
                {
                    exception1 = ex1;
                    AzureMonitorTraceExporterEventSource.Log.WriteException(ex1, rethrow: true);
                }
            }
            catch (Exception ex2)
            {
                // Exception2 IS the original exception, but this instance been re-thrown from the EventSource
                exception2 = ex2;
            }

            // Exception2 was rethrown, but is expected to contain the contents of Exception1.
            Assert.IsTrue(exception2.StackTrace.Contains(exception1.StackTrace));

            // Exception2 will include a message indicating that it was re-thrown from a different location
            Assert.IsTrue(exception2.StackTrace.Contains("--- End of stack trace from previous location where exception was thrown ---"));
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
