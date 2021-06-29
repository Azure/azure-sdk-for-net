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
        private const uint DefaultMaxEventCount = 100;

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
                    _events.TryDequeue(out _);
                }

                // Make sure we can format the event
                EventSourceEventFormatting.Format(eventData);
                _events.Enqueue(eventData);
            }
        }

        public TestEventListener() : this(DefaultMaxEventCount)
        { }

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
