// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Azure.Messaging.EventHubs;

namespace Microsoft.Azure.WebJobs.EventHubs.Listeners
{
    /// <summary>
    /// This class manages a queue of event data using a minimum and maximum batch size. This class is NOT thread safe.
    /// Concurrency must be managed by the class using this events manager.
    /// </summary>
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

        /// <summary>
        /// Try to create a batch from <paramref name="events"/> and any events stored in the cache. If <paramref name="allowPartialBatch"/>
        /// is true, this method return all events available even if there aren't enough to hit the minimum batch size threshold. If
        /// <paramref name="allowPartialBatch"/> is false, this method either returns a batch of at least the minimum batch size, or it returns
        /// nothing and retains all available events in the cache.
        /// </summary>
        /// <param name="events">An array of events to either add to a batch or cache.</param>
        /// <param name="allowPartialBatch">True if batches smaller than the minimum batch size can be returned.</param>
        /// <returns></returns>
        public EventData[] TryGetBatchofEventsWithCached(EventData[] events = null, bool allowPartialBatch= false)
        {
            EventData[] eventsToReturn;
            var inputEvents = events?.Length ?? 0;
            var totalEvents = CachedEvents.Count + inputEvents;

            // Enqueue all new events, if any, to the cache queue.
            if (events != null)
            {
                foreach (var eventData in events)
                {
                    CachedEvents.Enqueue(eventData);
                }
            }

            if (totalEvents < _minBatchSize && !allowPartialBatch)
            {
                // If we don't have enough events, and we can't return a partial batch, just return an empty array.
                eventsToReturn = Array.Empty<EventData>();
            }
            else
            {
                // If we have enough events, pull all the events off the queue to return.
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