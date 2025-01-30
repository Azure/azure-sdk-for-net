// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Globalization;
using System.Linq;
using System.Text;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace ClientModel.Tests
{
    public class TestClientEventListener : EventListener
    {
        private volatile bool _disposed;
        private readonly ConcurrentQueue<EventWrittenEventArgs> _events = new();

        public IEnumerable<EventWrittenEventArgs> EventData => _events;

        /// <summary>
        /// Creates an instance of <see cref="TestClientEventListener"/>.
        /// </summary>
        public TestClientEventListener()
        {
        }

        protected override void OnEventSourceCreated(EventSource eventSource)
        {
            // The event source names have to be hardcoded and cannot be configured at runtime by the constructor. This
            // is because when an EventListener is instantiated, the OnEventWritten and OnEventSourceCreated callback methods can
            // be called before the constructor has completed
            // see: https://learn.microsoft.com/dotnet/api/system.diagnostics.tracing.eventlistener#remarks
            if (eventSource.Name == "System.ClientModel")
            {
                EnableEvents(eventSource, EventLevel.Verbose);
            }
        }

        protected override void OnEventWritten(EventWrittenEventArgs eventData)
        {
            // Work around https://github.com/dotnet/corefx/issues/42600
            if (eventData.EventId == -1)
            {
                return;
            }

            if (!_disposed)
            {
                // Make sure we can format the event
                Format(eventData);
                _events.Enqueue(eventData);
            }
        }

        public EventWrittenEventArgs GetAndValidateSingleEvent(int eventId, string expectedEventName, EventLevel expectedEventLevel, string expectedEventSourceName)
        {
            EventWrittenEventArgs args = SingleEventById(eventId);
            Assert.AreEqual(expectedEventName, args.EventName);
            Assert.AreEqual(expectedEventLevel, args.Level);
            Assert.AreEqual(expectedEventSourceName, args.EventSource.Name);
            string requestId = args.GetProperty<string>("requestId");
            Assert.That(string.IsNullOrEmpty(requestId), Is.False);
            return args;
        }

        public EventWrittenEventArgs SingleEventById(int id, Func<EventWrittenEventArgs, bool>? filter = default)
        {
            return EventsById(id).Single(filter ?? (_ => true));
        }

        public void ValidateNumberOfEventsById(int eventId, int expectedNumEvents)
        {
            Assert.AreEqual(expectedNumEvents, EventsById(eventId).Count());
        }

        public IEnumerable<EventWrittenEventArgs> EventsById(int id)
        {
            return _events.Where(e => e.EventId == id);
        }

        public void AssertNoContentLogged()
        {
            CollectionAssert.IsEmpty(EventsById(2)); // RequestContentEvent
            CollectionAssert.IsEmpty(EventsById(17)); // RequestContentTextEvent

            CollectionAssert.IsEmpty(EventsById(6)); // ResponseContentEvent
            CollectionAssert.IsEmpty(EventsById(13)); // ResponseContentTextEvent
            CollectionAssert.IsEmpty(EventsById(11)); // ResponseContentBlockEvent
            CollectionAssert.IsEmpty(EventsById(15)); // ResponseContentTextBlockEvent

            CollectionAssert.IsEmpty(EventsById(9)); // ErrorResponseContentEvent
            CollectionAssert.IsEmpty(EventsById(14)); // ErrorResponseContentTextEvent
            CollectionAssert.IsEmpty(EventsById(12)); // ErrorResponseContentBlockEvent
            CollectionAssert.IsEmpty(EventsById(16)); // ErrorResponseContentTextBlockEvent
        }

        public override void Dispose()
        {
            _disposed = true;
            base.Dispose();
        }

        #region Helpers

        private static string Format(EventWrittenEventArgs eventData)
        {
            var payloadArray = eventData.Payload?.ToArray() ?? Array.Empty<object?>();

            ProcessPayloadArray(payloadArray);

            if (eventData.Message != null)
            {
                try
                {
                    return string.Format(CultureInfo.InvariantCulture, eventData.Message, payloadArray);
                }
                catch (FormatException)
                {
                }
            }

            var stringBuilder = new StringBuilder();
            stringBuilder.Append(eventData.EventName);

            if (!string.IsNullOrWhiteSpace(eventData.Message))
            {
                stringBuilder.AppendLine();
                stringBuilder.Append(nameof(eventData.Message)).Append(" = ").Append(eventData.Message);
            }

            if (eventData.PayloadNames != null)
            {
                for (int i = 0; i < eventData.PayloadNames.Count; i++)
                {
                    stringBuilder.AppendLine();
                    stringBuilder.Append(eventData.PayloadNames[i]).Append(" = ").Append(payloadArray[i]);
                }
            }

            return stringBuilder.ToString();
        }

        private static void ProcessPayloadArray(object?[] payloadArray)
        {
            for (int i = 0; i < payloadArray.Length; i++)
            {
                payloadArray[i] = FormatValue(payloadArray[i]);
            }
        }

        private static object? FormatValue(object? o)
        {
            if (o is byte[] bytes)
            {
                var stringBuilder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "{0:X2}", b);
                }

                return stringBuilder.ToString();
            }

            return o;
        }

        #endregion
    }
}
