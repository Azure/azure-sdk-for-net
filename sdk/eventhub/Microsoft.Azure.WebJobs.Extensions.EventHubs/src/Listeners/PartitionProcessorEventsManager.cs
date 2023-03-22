// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Azure.Messaging.EventHubs;

namespace Microsoft.Azure.WebJobs.EventHubs.Listeners
{
    internal class PartitionProcessorEventsManager : IDisposable
    {
        private int _maxBatchSize;
        private int _minBatchSize;

        // This is internal for mocking purposes only.
        internal Queue<EventData> CachedEvents { get; set; }

        public bool HasCachedEvents
        {
            get
            {
                return CachedEvents.Count > 0;
            }
        }

        public PartitionProcessorEventsManager(int maxBatchSize, int minBatchSize)
        {
            CachedEvents = new Queue<EventData>();
            _maxBatchSize = maxBatchSize;
            _minBatchSize = minBatchSize;
        }

        public void ClearEventCache()
        {
            CachedEvents.Clear();
        }

        public EventData[] GetBatchofEventsWithCached(EventData[] events = null, bool allowPartialBatch= false)
        {
            EventData[] eventsToReturn;
            var inputEvents = events?.Length ?? 0;
            var totalEvents = CachedEvents.Count + inputEvents;

            if (events != null)
            {
                foreach (var eventData in events)
                {
                    CachedEvents.Enqueue(eventData);
                }
            }

            if (totalEvents < _minBatchSize && !allowPartialBatch)
            {
                eventsToReturn = Array.Empty<EventData>();
            }
            else
            {
                var sizeOfBatch = totalEvents > _maxBatchSize ? _maxBatchSize : totalEvents;
                eventsToReturn = new EventData[sizeOfBatch];
                for (int i = 0; i < sizeOfBatch; i++)
                {
                    var nextEvent = CachedEvents.Dequeue();
                    eventsToReturn[i] = nextEvent;
                }
            }
            return eventsToReturn;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}