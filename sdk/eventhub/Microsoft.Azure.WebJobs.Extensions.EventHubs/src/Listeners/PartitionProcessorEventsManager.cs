// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Azure.Messaging.EventHubs;
using Microsoft.Azure.WebJobs.EventHubs.Processor;
using Azure.Core;
using System.Security.Cryptography.X509Certificates;

namespace Microsoft.Azure.WebJobs.EventHubs.Listeners
{
    internal class PartitionProcessorEventsManager : IDisposable
    {
        private int _maxBatchSize;
        private int _minBatchSize;
        private readonly object _cachedEventsLock = new object();

        // This is internal for mocking purposes only.
        internal Queue<EventData> CachedEvents { get; set; }

        public bool HasCachedEvents
        {
            get
            {
                lock (_cachedEventsLock)
                {
                    return CachedEvents.Count > 0;
                }
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

        public EventData[] GetBatchofEventsWithCached(EventData[] events = null, bool timerTrigger = false)
        {
            EventData[] eventsToReturn;
            lock (_cachedEventsLock)
            {
                var totalEvents = CachedEvents.Count + events.Length;

                foreach (var eventData in events)
                {
                    CachedEvents.Enqueue(eventData);
                }

                if (totalEvents < _minBatchSize && !timerTrigger)
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
            }
            return eventsToReturn;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}