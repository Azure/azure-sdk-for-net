// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Tracing;

namespace Azure.Base.Testing
{
    public class TestEventListener : EventListener
    {
        private volatile bool _disposed;
        private ConcurrentQueue<EventWrittenEventArgs> _events = new ConcurrentQueue<EventWrittenEventArgs>();

        public IEnumerable<EventWrittenEventArgs> EventData => _events;

        protected override void OnEventWritten(EventWrittenEventArgs eventData)
        {
            if (!_disposed)
            {
                _events.Enqueue(eventData);
            }
        }

        public override void Dispose()
        {
            _disposed = true;
            base.Dispose();
        }
    }
}