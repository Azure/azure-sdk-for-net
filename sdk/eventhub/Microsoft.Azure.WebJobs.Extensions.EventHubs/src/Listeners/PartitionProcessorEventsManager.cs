// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Azure.Messaging.EventHubs;
using Microsoft.Azure.WebJobs.EventHubs.Processor;
using Azure.Core;

namespace Microsoft.Azure.WebJobs.EventHubs.Listeners
{
    internal class PartitionProcessorEventsManager : IDisposable
    {
        private SemaphoreSlim _storedEventsGuard;
        private int _maxBatchSize;
        private int _minBatchSize;

        // This is internal for mocking purposes only.
        internal ConcurrentQueue<EventData> StoredEvents { get; set; }

        public bool HasStoredEvents
        {
            get
            {
                try
                {
                    _storedEventsGuard.Wait();
                    return !StoredEvents.IsEmpty;
                }
                finally
                {
                    _storedEventsGuard.Release();
                }
            }
        }

        public PartitionProcessorEventsManager(int maxBatchSize, int minBatchSize)
        {
            StoredEvents = new ConcurrentQueue<EventData>();
            _maxBatchSize = maxBatchSize;
            _minBatchSize = minBatchSize;
            _storedEventsGuard = new SemaphoreSlim(1, 1);
        }

        public void PartitionClosing()
        {
            StoredEvents = new ConcurrentQueue<EventData>();
        }

        public EventData[] ProcessWithStoredEvents(EventProcessorHostPartition partitionContext, List<EventData> events = null, bool timerTrigger = false, CancellationToken cancellationToken = default)
        {
            try
            {
                _storedEventsGuard.Wait(cancellationToken);
                events ??= new List<EventData>();
                var totalEvents = StoredEvents.Count + events.Count;

                foreach (var eventData in events)
                {
                    StoredEvents.Enqueue(eventData);
                }

                if (totalEvents < _minBatchSize && !timerTrigger)
                {
                    return Array.Empty<EventData>();
                }
                else
                {
                    var eventsToReturn = new List<EventData>();
                    for (int i = 0; i < _maxBatchSize; i++)
                    {
                        var hasNext = StoredEvents.TryDequeue(out var nextEvent);

                        if (hasNext)
                        {
                            eventsToReturn.Add(nextEvent);
                        }
                        else
                        {
                            return eventsToReturn.ToArray();
                        }
                    }
                    return eventsToReturn.ToArray();
                }
            }
            finally
            {
                _storedEventsGuard.Release();
            }
        }

        public void Dispose()
        {
            _storedEventsGuard?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}