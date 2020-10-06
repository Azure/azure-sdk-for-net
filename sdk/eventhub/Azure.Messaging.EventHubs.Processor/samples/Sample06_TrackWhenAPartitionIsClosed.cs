// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
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
    ///   An introduction to the Event Processor client, illustrating how to track when processing stops for a partition.
    /// </summary>
    ///
    public class Sample06_TrackWhenAPartitionIsClosed : IEventHubsBlobCheckpointSample
    {
        /// <summary>
        ///   The name of the sample.
        /// </summary>
        ///
        public string Name => nameof(Sample06_TrackWhenAPartitionIsClosed);

        /// <summary>
        ///   A short description of the sample.
        /// </summary>
        ///
        public string Description => "An introduction to the Event Processor client, illustrating how to track when processing stops for a partition.";

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
            // When the Event Processor client begins processing, it will take ownership over a set of Event Hub partitions to process.  The ownership that a
            // processor has of a partition is transient; ownership may be relinquished by the processor in several scenarios:
            //
            // - Because processors work collaboratively within the context of a consumer group, they will share responsibility for partitions of the Event Hub,
            //   with ownership of a partition potentially moving from one processor to another.
            //
            // - If a processor encounters an issue and believes that it cannot safely recover processing for a partition that it has ownership of, it will
            //   relinquish ownership and allow the partition to be claimed by another processor or may reclaim it with fresh state itself.  This scenario will
            //   also result in errors being sent for processing by the handler.
            //
            // - Should there be a request for a processor to stop processing, it will relinquish ownership of its partitions to allow for other processors to
            //   potentially claim them so that processing continues as event processor instances are scaled for the consumer group.
            //
            // In any of these cases, the "PartitionClosing" event will be triggered on the processor.  While there are no actions that you may take to influence
            // the closing of a partition, this event serves as the logical partner of the "PartitionInitializing" event, allowing you to track the partitions owned
            // by the processor.

            string consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;
            BlobContainerClient storageClient = new BlobContainerClient(blobStorageConnectionString, blobContainerName);
            EventProcessorClient processor = new EventProcessorClient(storageClient, consumerGroup, eventHubsConnectionString, eventHubName);

            // For this example, we'll keep a list of partitions that are owned by our processor instance and keep it up to
            // date with the last event processed for that partition.  When our processor closes that partition, we'll ensure that we
            // have an up-to-date checkpoint based on the last event.

            int eventsProcessed = 0;
            ConcurrentDictionary<string, ProcessEventArgs> ownedPartitions = new ConcurrentDictionary<string, ProcessEventArgs>();

            // The handler for partition initialization is responsible for beginning to track the partition.

            Task partitionInitializingHandler(PartitionInitializingEventArgs eventArgs)
            {
                if (eventArgs.CancellationToken.IsCancellationRequested)
                {
                    return Task.CompletedTask;
                }

                try
                {
                    ownedPartitions[eventArgs.PartitionId] = default(ProcessEventArgs);
                    Console.WriteLine($"Initialized partition: { eventArgs.PartitionId }");
                }
                catch (Exception ex)
                {
                    // For real-world scenarios, you should take action appropriate to your application.  For our example, we'll just log
                    // the exception to the console.

                    Console.WriteLine();
                    Console.WriteLine($"An error was observed while initializing partition: { eventArgs.PartitionId }.  Message: { ex.Message }");
                    Console.WriteLine();
                }

                return Task.CompletedTask;
            }

            // The handler for partition close will stop tracking the partition and checkpoint if an event was processed for it.

            async Task partitionClosingHandler(PartitionClosingEventArgs eventArgs)
            {
                if (eventArgs.CancellationToken.IsCancellationRequested)
                {
                    return;
                }

                try
                {
                    if (ownedPartitions.TryRemove(eventArgs.PartitionId, out ProcessEventArgs lastProcessEventArgs))
                    {
                        await lastProcessEventArgs.UpdateCheckpointAsync();
                    }

                    Console.WriteLine($"Closing partition: { eventArgs.PartitionId }");
                }
                catch (Exception ex)
                {
                    // For real-world scenarios, you should take action appropriate to your application.  For our example, we'll just log
                    // the exception to the console.

                    Console.WriteLine();
                    Console.WriteLine($"An error was observed while closing partition: { eventArgs.PartitionId }.  Message: { ex.Message }");
                    Console.WriteLine();
                }
            }

            // When an event is received, update the partition if tracked.  In the case that the value changes in the
            // time that it was checked, consider the other event fresher and do not force an update.

            Task processEventHandler(ProcessEventArgs eventArgs)
            {
                if (eventArgs.CancellationToken.IsCancellationRequested)
                {
                    return Task.CompletedTask;
                }

                try
                {
                    ownedPartitions[eventArgs.Partition.PartitionId] = eventArgs;

                    ++eventsProcessed;
                    Console.WriteLine($"Event Received: { Encoding.UTF8.GetString(eventArgs.Data.EventBody.ToBytes().ToArray()) }");
                }
                catch (Exception ex)
                {
                    // For real-world scenarios, you should take action appropriate to your application.  For our example, we'll just log
                    // the exception to the console.

                    Console.WriteLine();
                    Console.WriteLine($"An error was observed while processing events.  Message: { ex.Message }");
                    Console.WriteLine();
                }

                return Task.CompletedTask;
            };

            // For this example, exceptions will just be logged to the console.

            Task processErrorHandler(ProcessErrorEventArgs eventArgs)
            {
                if (eventArgs.CancellationToken.IsCancellationRequested)
                {
                    return Task.CompletedTask;
                }

                Console.WriteLine("===============================");
                Console.WriteLine($"The error handler was invoked during the operation: { eventArgs.Operation ?? "Unknown" }, for Exception: { eventArgs.Exception.Message }");
                Console.WriteLine("===============================");
                Console.WriteLine();

                return Task.CompletedTask;
            }

            processor.PartitionInitializingAsync += partitionInitializingHandler;
            processor.PartitionClosingAsync += partitionClosingHandler;
            processor.ProcessEventAsync += processEventHandler;
            processor.ProcessErrorAsync += processErrorHandler;

            try
            {
                // To begin, we'll publish a batch of events for our processor to receive. Because we are not specifying any routing hints,
                // the Event Hubs service will automatically route these to partitions.  We'll split the events into a couple of batches to
                // increase the chance they'll be spread around.

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
                    }
                }

                // In order to begin processing, an explicit call must be made to the processor.  This will instruct the processor to begin
                // processing in the background, invoking your handlers when they are needed.

                eventsProcessed = 0;
                await processor.StartProcessingAsync();

                // Because processing takes place in the background, we'll continue to wait until all of our events were
                // read and handled before stopping.   To ensure that we don't wait indefinitely should an unrecoverable
                // error be encountered, we'll also add a timed cancellation.

                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(TimeSpan.FromSeconds(60));

                while ((!cancellationSource.IsCancellationRequested) && (eventsProcessed <= expectedEvents.Count))
                {
                    await Task.Delay(TimeSpan.FromMilliseconds(250));
                }

                // Once we arrive at this point, either cancellation was requested or we have processed all of our events.  In
                // both cases, we'll want to shut down the processor.

                await processor.StopProcessingAsync();
            }
            finally
            {
                // It is encouraged that you unregister your handlers when you have finished
                // using the Event Processor to ensure proper cleanup.  This is especially
                // important when using lambda expressions or handlers in any form that may
                // contain closure scopes or hold other references.

                processor.PartitionInitializingAsync -= partitionInitializingHandler;
                processor.PartitionClosingAsync -= partitionClosingHandler;
                processor.ProcessEventAsync -= processEventHandler;
                processor.ProcessErrorAsync -= processErrorHandler;
            }

            // The Event Processor client has been stopped and is not explicitly disposable; there
            // is nothing further that we need to do for cleanup.

            Console.WriteLine();
        }
    }
}
