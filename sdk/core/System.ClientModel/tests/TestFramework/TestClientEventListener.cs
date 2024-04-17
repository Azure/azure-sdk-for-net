// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientModel.Tests
{
    public class TestClientEventListener : EventListener
    {
        private volatile bool _disposed;
        private readonly ConcurrentQueue<EventWrittenEventArgs> _events = new ConcurrentQueue<EventWrittenEventArgs>();
        private uint _maxEventCount;
        private const uint DefaultMaxEventCount = 1000;
        private string _eventSourceName = "System.ClientModel";
        private EventLevel _eventLevel;

        public IEnumerable<EventWrittenEventArgs> EventData => _events;

        /// <summary>
        /// Creates an instance of <see cref="TestEventListener"/>.
        /// </summary>
        /// <param name="maxEventCount">Maximum number of events that the listener can store in <see cref="EventData"/>.
        /// <para>If the number of events exceeds the value, an <see cref="Exception"/> is thrown.</para></param>
        public TestClientEventListener(uint maxEventCount, string eventSourceName, EventLevel eventLevel)
        {
            _maxEventCount = maxEventCount;
            _eventSourceName = eventSourceName;
            _eventLevel = eventLevel;
        }

        protected override void OnEventSourceCreated(EventSource eventSource)
        {
            if (eventSource.Name == _eventSourceName)
            {
                EnableEvents(eventSource, _eventLevel);
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
                if (_events.Count >= _maxEventCount)
                {
                    throw new Exception($"Number of events has exceeded {_maxEventCount}.");
                }

                // Make sure we can format the event
                Format(eventData);
                _events.Enqueue(eventData);
            }
        }

        public EventWrittenEventArgs SingleEventById(int id, Func<EventWrittenEventArgs, bool>? filter = default)
        {
            return EventsById(id).Single(filter ?? (_ => true));
        }

        public IEnumerable<EventWrittenEventArgs> EventsById(int id)
        {
            return _events.Where(e => e.EventId == id);
        }

        public override void Dispose()
        {
            _disposed = true;
            base.Dispose();
        }

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
    }
}
