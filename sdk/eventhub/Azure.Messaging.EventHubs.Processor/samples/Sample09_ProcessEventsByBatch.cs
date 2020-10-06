// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Processor.Samples.Infrastructure;
using Azure.Messaging.EventHubs.Producer;
using Azure.Storage.Blobs;

namespace Azure.Messaging.EventHubs.Processor.Samples
{
    /// <summary>
    ///   An example of grouping events into batches for downstream processing.
    /// </summary>
    ///
    public class Sample09_ProcessEventsByBatch : IEventHubsBlobCheckpointSample
    {
        /// <summary>
        ///   The name of the sample.
        /// </summary>
        ///
        public string Name => nameof(Sample09_ProcessEventsByBatch);

        /// <summary>
        ///   A short description of the sample.
        /// </summary>
        ///
        public string Description => "An example of grouping events into batches for downstream processing.";

        /// <summary>
        ///   Runs the sample using the specified Event Hubs and Azure storage connection information.
        /// </summary>
        ///
        /// <param name="eventHubsConnectionString">The connection string for the Event Hubs namespace that the sample should target.</param>
        /// <param name="eventHubName">The name of the Event Hub, sometimes known as its path, that the sample should run against.</param>
        /// <param name="blobStorageConnectionString">The connection string for the storage account where checkpoints and state should be persisted.</param>
        /// <param name="blobContainerName">The name of the blob storage container where checkpoints and state should be persisted.</param>
        ///
        public async Task RunAsync(string eventHubsConnectionString,
                                   string eventHubName,
                                   string blobStorageConnectionString,
                                   string blobContainerName)
        {
            // In order to ensure efficient communication with the Event Hubs service and the best throughput possible for dispatching events to be processed,
            // the Event Processor client is eagerly reading from each partition of the Event Hub and staging events.  The processor will dispatch an event
            // to the "ProcessEvent" handler immediately when one is available.  Each call to the handler passes a single event and the context of the partition
            // from which the event was read.  This pattern is intended to allow developers to act on an event as soon as possible, and present a straightforward
            // and understandable interface.
            //
            // This approach is optimized for scenarios where the processing of events can be performed quickly and without heavy resource costs.  For scenarios
            // where that is not the case, it may be advantageous to collect the events into batches and send them to be processed outside of the context
            // of the "ProcessEvent" handler.
            //
            // In this example, our "ProcessEvent" handler will group events into batches by partition, sending them for downstream processing when the desired
            // batch size was reached or when no event was available for more than a maximum wait time interval.

            int desiredBatchSize = 3;
            TimeSpan maximumWaitTime = TimeSpan.FromMilliseconds(150);

            // The Event Processor client will preserve the order that events were enqueued in a partition by waiting for the "ProcessEvent" handler to
            // complete before it is invoked with a new event for the same partition.  However, partitions are processed concurrently, so the
            // handler is likely to be executing for multiple partitions at the same time.
            //
            // To account for this, we'll use a concurrent dictionary to track batches, grouping them by partition.

            ConcurrentDictionary<string, List<ProcessEventArgs>> eventBatches = new ConcurrentDictionary<string, List<ProcessEventArgs>>();

            // Create our Event Processor client, specifying the maximum wait time as an option to ensure that
            // our handler is invoked when no event was available.

            EventProcessorClientOptions clientOptions = new EventProcessorClientOptions
            {
                MaximumWaitTime = maximumWaitTime
            };

            string consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;
            BlobContainerClient storageClient = new BlobContainerClient(blobStorageConnectionString, blobContainerName);
            EventProcessorClient processor = new EventProcessorClient(storageClient, consumerGroup, eventHubsConnectionString, eventHubName, clientOptions);

            // For this example, we'll create a simple event handler that writes to the
            // console each time it was invoked.

            int eventIndex = 0;

            async Task processEventHandler(ProcessEventArgs eventArgs)
            {
                if (eventArgs.CancellationToken.IsCancellationRequested)
                {
                    return;
                }

                try
                {
                    // Retrieve or create the active batch for the current partition.

                    List<ProcessEventArgs> currentBatch = eventBatches.GetOrAdd(eventArgs.Partition.PartitionId, _ => new List<ProcessEventArgs>());
                    bool sendBatchForProcessing = false;

                    // If there was an event emitted, add the event and check to see if the size of the batch has reached the desired
                    // size.  If so, it will need to be sent.
                    //
                    // NOTE:  There is a bug in the Event Hubs preview 6 library causing "HasEvents" to return the
                    //        wrong value.  We'll substitute a check against the "Data" property to work around it.
                    //
                    //        if (eventArgs.HasEvents) {} is the preferred snippet.
                    //
                    if (eventArgs.Data != null)
                    {
                        currentBatch.Add(eventArgs);
                        sendBatchForProcessing = (currentBatch.Count >= desiredBatchSize);
                    }
                    else
                    {
                        // There was no event available within the interval requested by the maximum
                        // wait time, send the batch for processing if it contains any events.

                        sendBatchForProcessing = (currentBatch.Count > 0);
                    }

                    // It is important to be aware that no events for the partition will be processed until the handler returns,
                    // so you may wish to delegate processing to a downstream service or background task in order to maintain
                    // throughput.
                    //
                    // In this example, if the batch is to be sent, we'll delegate to simple helper method that will write
                    // to the console.  If sending our batch completed successfully, we'll checkpoint using the last
                    // event and clear the batch.

                    if (sendBatchForProcessing)
                    {
                        await SendEventBatchAsync(currentBatch.Select(item => item.Data));
                        await currentBatch[currentBatch.Count - 1].UpdateCheckpointAsync();
                        currentBatch.Clear();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine($"An error was observed while processing events.  Message: { ex.Message }");
                    Console.WriteLine();
                }

                ++eventIndex;
            };

            // For this example, exceptions will just be logged to the console.

            Task processErrorHandler(ProcessErrorEventArgs eventArgs)
            {
                if (eventArgs.CancellationToken.IsCancellationRequested)
                {
                    return Task.CompletedTask;
                }

                Console.WriteLine();
                Console.WriteLine("===============================");
                Console.WriteLine($"The error handler was invoked during the operation: { eventArgs.Operation ?? "Unknown" }, for Exception: { eventArgs.Exception.Message }");
                Console.WriteLine("===============================");
                Console.WriteLine();

                return Task.CompletedTask;
            }

            processor.ProcessEventAsync += processEventHandler;
            processor.ProcessErrorAsync += processErrorHandler;

            try
            {
                Console.WriteLine("Starting the Event Processor client...");
                Console.WriteLine();

                eventIndex = 0;
                await processor.StartProcessingAsync();

                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(TimeSpan.FromSeconds(90));

                // We'll publish a batch of events for our processor to receive. We'll split the events into a couple of batches to
                // increase the chance they'll be spread around to different partitions and introduce a delay between batches to
                // allow for the handler to be invoked without an available event interleaved.

                var expectedEvents = new List<EventData>()
                {
                   new EventData(Encoding.UTF8.GetBytes("First Event, First Batch")),
                   new EventData(Encoding.UTF8.GetBytes("Second Event, First Batch")),
                   new EventData(Encoding.UTF8.GetBytes("Third Event, First Batch")),

                   new EventData(Encoding.UTF8.GetBytes("First Event, Second Batch")),
                   new EventData(Encoding.UTF8.GetBytes("Second Event, Second Batch")),
                   new EventData(Encoding.UTF8.GetBytes("Third Event, Second Batch")),

                   new EventData(Encoding.UTF8.GetBytes("First Event, Third Batch")),
                   new EventData(Encoding.UTF8.GetBytes("Second Event, Third Batch")),
                   new EventData(Encoding.UTF8.GetBytes("Third Event, Third Batch")),

                   new EventData(Encoding.UTF8.GetBytes("First Event, Fourth Batch")),
                   new EventData(Encoding.UTF8.GetBytes("Second Event, Fourth Batch")),
                   new EventData(Encoding.UTF8.GetBytes("Third Event, Fourth Batch")),

                   new EventData(Encoding.UTF8.GetBytes("First Event, Fifth Batch")),
                   new EventData(Encoding.UTF8.GetBytes("Second Event, Fifth Batch")),
                   new EventData(Encoding.UTF8.GetBytes("Third Event, Fifth Batch")),

                   new EventData(Encoding.UTF8.GetBytes("First Event, Fifth Batch")),
                   new EventData(Encoding.UTF8.GetBytes("Second Event, Fifth Batch")),
                   new EventData(Encoding.UTF8.GetBytes("Third Event, Fifth Batch")),

                   new EventData(Encoding.UTF8.GetBytes("First Event, Sixth Batch")),
                   new EventData(Encoding.UTF8.GetBytes("Second Event, Sixth Batch")),
                   new EventData(Encoding.UTF8.GetBytes("Third Event, Sixth Batch")),

                   new EventData(Encoding.UTF8.GetBytes("First Event, Seventh Batch")),
                   new EventData(Encoding.UTF8.GetBytes("Second Event, Seventh Batch")),
                   new EventData(Encoding.UTF8.GetBytes("Third Event, Seventh Batch"))
                };

                int sentIndex = 0;
                int numberOfBatches = 3;
                int eventsPerBatch = (expectedEvents.Count / numberOfBatches);

                await using (var producer = new EventHubProducerClient(eventHubsConnectionString, eventHubName))
                {
                    while (sentIndex < expectedEvents.Count)
                    {
                        using EventDataBatch eventBatch = await producer.CreateBatchAsync();

                        for (int index = 0; index < eventsPerBatch; ++index)
                        {
                            eventBatch.TryAdd(expectedEvents[sentIndex]);
                            ++sentIndex;
                        }

                        await producer.SendAsync(eventBatch);
                        await Task.Delay(250, cancellationSource.Token);
                    }
                }

                // We'll allow the Event Processor client to read and dispatch the events that we published, along with
                // ensuring a few invocations with no event.  Note that, due to non-determinism in the timing, we may or may
                // not see all of the events from our batches read.

                while ((!cancellationSource.IsCancellationRequested) && (eventIndex <= expectedEvents.Count + 5))
                {
                    await Task.Delay(TimeSpan.FromMilliseconds(250));
                }

                // Once we arrive at this point, either cancellation was requested or we have processed all of our events.  In
                // both cases, we'll want to shut down the processor.

                Console.WriteLine();
                Console.WriteLine("Stopping the processor...");

                await processor.StopProcessingAsync();
            }
            finally
            {
                // It is encouraged that you unregister your handlers when you have finished
                // using the Event Processor to ensure proper cleanup.  This is especially
                // important when using lambda expressions or handlers in any form that may
                // contain closure scopes or hold other references.

                processor.ProcessEventAsync -= processEventHandler;
                processor.ProcessErrorAsync -= processErrorHandler;
            }

            // The Event Processor client has been stopped and is not explicitly disposable; there
            // is nothing further that we need to do for cleanup.

            Console.WriteLine();
        }

        /// <summary>
        ///   A helper method to simulate sending an event batch for processing.
        /// </summary>
        ///
        /// <param name="eventBatch">The event batch to "send".</param>
        ///
        private async Task SendEventBatchAsync(IEnumerable<EventData> eventBatch)
        {
            StringBuilder batchMessage = new StringBuilder();
            int eventCount = 0;

            foreach (EventData data in eventBatch)
            {
                batchMessage.AppendLine($"\tEvent: { Encoding.UTF8.GetString(data.EventBody.ToBytes().ToArray()) }");
                ++eventCount;
            }

            Console.WriteLine($"Event Batch with { eventCount } events sent:{ Environment.NewLine }{ batchMessage.ToString() }{ Environment.NewLine }");
            await Task.Delay(50);
        }
    }
}
