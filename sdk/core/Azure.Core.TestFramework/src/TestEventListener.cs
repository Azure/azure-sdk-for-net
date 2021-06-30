// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using Azure.Core.Shared;

namespace Azure.Core.TestFramework
{
    public class TestEventListener : EventListener
    {
        private volatile bool _disposed;
        private readonly ConcurrentQueue<EventWrittenEventArgs> _events = new ConcurrentQueue<EventWrittenEventArgs>();
        private uint _maxEventCount;
        private const uint DefaultMaxEventCount = 1000;

        public IEnumerable<EventWrittenEventArgs> EventData => _events;

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
                    throw new Exception($"Number of events has exceeded {_maxEventCount}. Create {typeof(TestEventListener)} with a larger 'maxEventCount'.");
                }

                // Make sure we can format the event
                EventSourceEventFormatting.Format(eventData);
                _events.Enqueue(eventData);
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="TestEventListener"/>.
        /// </summary>
        public TestEventListener() : this(DefaultMaxEventCount)
        { }

        /// <summary>
        /// Creates an instance of <see cref="TestEventListener"/>.
        /// </summary>
        /// <param name="maxEventCount">Maximum number of events that the listener can store in <see cref="EventData"/>.
        /// <para>If the number of events exceeds the value, an <see cref="Exception"/> is thrown.</para></param>
        public TestEventListener(uint maxEventCount)
        {
            _maxEventCount = maxEventCount;
        }

        public EventWrittenEventArgs SingleEventById(int id, Func<EventWrittenEventArgs, bool> filter = null)
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
    }
}
