// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Producer;
using Azure.Messaging.EventHubs.Samples.Infrastructure;

namespace Azure.Messaging.EventHubs.Samples
{
    /// <summary>
    ///   An example of publishing events using multiple batches.
    /// </summary>
    ///
    public class Sample04_PublishMultipleEventBatches : IEventHubsSample
    {
        /// <summary>
        ///   The name of the sample.
        /// </summary>
        ///
        public string Name => nameof(Sample04_PublishMultipleEventBatches);

        /// <summary>
        ///   A short description of the sample.
        /// </summary>
        ///
        public string Description => "An example of publishing events using multiple batches.";

        /// <summary>
        ///   Runs the sample using the specified Event Hubs connection information.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string for the Event Hubs namespace that the sample should target.</param>
        /// <param name="eventHubName">The name of the Event Hub, sometimes known as its path, that the sample should run against.</param>
        ///
        public async Task RunAsync(string connectionString,
                                   string eventHubName)
        {
             // It is important to be aware that the EventDataBatch is responsible for unmanaged resources and should be disposed
             // after it has been published.  A batch cannot be reused nor published multiple times.  In the case where the events
             // that you would like to publish do not fit into a single batch, a new batch should be created.
             //
             // In this example, we'll create a set of events that will need to span multiple batches to publish.  As with earlier
             // examples, we'll begin by creating an Event Hub producer client to create the batches and publish events using automatic routing.

            await using (var producerClient = new EventHubProducerClient(connectionString, eventHubName))
            {
                // Because the maximum size of an event batch is dictated by the Event Hubs service and varies between the different
                // service plan levels, we'll create a batch to query for its maximum allowed size before we create our events.

                long maximumBatchSize;

                using (EventDataBatch measureBatch = await producerClient.CreateBatchAsync())
                {
                    maximumBatchSize = measureBatch.MaximumSizeInBytes;
                }

                // Create our set of events such that we'll need three batches to publish them all.

                int eventsPerBatch = 4;
                int batchCount = 3;
                int eventCount = (batchCount * eventsPerBatch);
                long eventSize = (maximumBatchSize / eventsPerBatch);

                Queue<EventData> eventsToPublish = new Queue<EventData>(eventCount);

                for (int index = 0; index < eventCount; ++index)
                {
                    // Because the content of the event is not interesting to us, we'll
                    // use an empty array of the correct size.

                    eventsToPublish.Enqueue(new EventData(new byte[eventSize]));
                }

                // Now that our events are available, create the batches and send them.

                int currentBatch = 0;

                while (eventsToPublish.Count > 0)
                {
                    using (EventDataBatch eventBatch = await producerClient.CreateBatchAsync())
                    {
                        while ((TryDequeue(eventsToPublish, out EventData currentEvent)) && (eventBatch.TryAdd(currentEvent)))
                        {
                        }

                        // When an event could not be dequeued or could not be added to the batch, then the batch is ready to be published.

                        if (eventBatch.Count > 0)
                        {
                            await producerClient.SendAsync(eventBatch);

                            ++currentBatch;
                            Console.WriteLine($"Batch: { currentBatch } containing { eventBatch.Count } events was published.  { eventsToPublish.Count } remain.");
                        }
                    }

                    // At this point, the batch has passed it's "using" scope and has been safely disposed of.  If there are events remaining in the
                    // queue, a new batch will be created for them.
                }

                Console.WriteLine();
                Console.WriteLine("All events have been published.");
            }

            // At this point, our client has passed its "using" scope and has safely been disposed of.  We
            // have no further obligations.

            Console.WriteLine();
        }

        /// <summary>
        ///   Attempts to dequeue an event from the specified <paramref name="queue"/>.
        /// </summary>
        ///
        /// <param name="queue">The queue to attempt to dequeue from.</param>
        /// <param name="currentEvent">The current event that was dequeued, or <c>null</c> if no event was available.</param>
        ///
        /// <returns><c>true</c> if an event was dequeued; otherwise, <c>false</c>.</returns>
        ///
        private static bool TryDequeue(Queue<EventData> queue,
                                       out EventData currentEvent)
        {
            if (queue.Count > 0)
            {
                currentEvent = queue.Dequeue();
                return true;
            }

            currentEvent = null;
            return false;
        }
    }
}
