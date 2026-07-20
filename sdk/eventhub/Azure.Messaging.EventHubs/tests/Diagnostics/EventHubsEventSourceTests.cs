// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using Azure.Messaging.EventHubs.Diagnostics;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="EventHubsEventSource" />
    ///   class.
    /// </summary>
    ///
    /// <remarks>
    ///   These tests have a dependency on running asynchronously with other tests
    ///   in the assembly, as they capture events from a process-wide event source.
    /// </remarks>
    ///
    [TestFixture]
    [NonParallelizable]
    public class EventHubsEventSourceTests
    {
        /// <summary>
        ///   Verifies that each event declares an identifier that matches the identifier
        ///   used to write it.  A mismatch prevents the event from rendering for listeners.
        /// </summary>
        ///
        [Test]
        public void PrefetchSizeLimitReachedWritesTheEvent()
        {
            using var listener = new TestEventListener();

            EventHubsEventSource.Log.PrefetchSizeLimitReached("hub", "group", "0", 1024, 3);

            var capturedEvent = listener.Events.SingleOrDefault(item => item.EventId == 132);

            Assert.That(capturedEvent, Is.Not.Null, "The event should have been written with the identifier that it declares.");
            Assert.That(capturedEvent.Level, Is.EqualTo(EventLevel.Warning), "The event should have been written at the warning level.");
            Assert.That(capturedEvent.Payload.Count, Is.EqualTo(5), "The event should have been written with each of its arguments.");
        }

        /// <summary>
        ///   Verifies that each event declares an identifier that matches the identifier
        ///   used to write it.  A mismatch prevents the event from rendering for listeners.
        /// </summary>
        ///
        [Test]
        public void EventProcessorPartitionLegacyCheckpointFormatWritesTheEvent()
        {
            using var listener = new TestEventListener();

            EventHubsEventSource.Log.EventProcessorPartitionLegacyCheckpointFormat("0", "identifier", "hub", "group");

            var capturedEvent = listener.Events.SingleOrDefault(item => item.EventId == 131);

            Assert.That(capturedEvent, Is.Not.Null, "The event should have been written with the identifier that it declares.");
            Assert.That(capturedEvent.Payload.Count, Is.EqualTo(4), "The event should have been written with each of its arguments.");
        }

        /// <summary>
        ///   A listener that captures the events written to the Event Hubs
        ///   event source.
        /// </summary>
        ///
        private class TestEventListener : EventListener
        {
            /// <summary>The name of the event source to capture events for.</summary>
            private const string SourceName = "Azure-Messaging-EventHubs";

            /// <summary>The events that were captured.</summary>
            public readonly List<EventWrittenEventArgs> Events = new List<EventWrittenEventArgs>();

            /// <summary>
            ///   Enables the Event Hubs event source when it is observed.
            /// </summary>
            ///
            /// <param name="eventSource">The event source that was observed.</param>
            ///
            protected override void OnEventSourceCreated(EventSource eventSource)
            {
                if (eventSource.Name == SourceName)
                {
                    EnableEvents(eventSource, EventLevel.Verbose, EventKeywords.All);
                }

                base.OnEventSourceCreated(eventSource);
            }

            /// <summary>
            ///   Captures an event that was written by an enabled event source.
            /// </summary>
            ///
            /// <param name="eventData">The event that was written.</param>
            ///
            protected override void OnEventWritten(EventWrittenEventArgs eventData)
            {
                if (eventData.EventSource.Name == SourceName)
                {
                    lock (Events)
                    {
                        Events.Add(eventData);
                    }
                }
            }
        }
    }
}
