// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
    ///   An introduction to the Event Processor client, illustrating how to create simple checkpoints.
    /// </summary>
    ///
    public class Sample04_BasicCheckpointing : IEventHubsBlobCheckpointSample
    {
        /// <summary>
        ///   The name of the sample.
        /// </summary>
        ///
        public string Name => nameof(Sample04_BasicCheckpointing);

        /// <summary>
        ///   A short description of the sample.
        /// </summary>
        ///
        public string Description => "An introduction to the Event Processor client, illustrating how to create simple checkpoints.";

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
            // A checkpoint is the term used to describe a snapshot of the state of processing for a partition which has been persisted
            // to durable storage and which allows an Event Processor client to resume processing at a specific location in the partition's
            // event stream.  When a processor starts, it will seek out an existing checkpoint and, if found, use that as the place where it
            // begins reading events.  If no checkpoint is found, a default location is used.
            //
            // Checkpoints are intended as a means to allow an Event Processor client or cluster of processors for a consumer group to coordinate
            // on which events were processed, so that processors can dynamically start, stop, join the cluster, and leave the cluster without the
            // need to start processing at the beginning of a partition and revisit all of its events.
            //
            // A checkpoint is based on an event and represents the last event that should be considered as processed for the partition; should a processor
            // start with that checkpoint, the next available event would be used as the starting point.
            //
            // The creation of checkpoints comes at a cost, both in terms of processing performance/throughput and a potential monetary cost associated with
            // the underlying storage resource.  While it may seem desirable to create checkpoints for each event that is processed, that is typically considered
            // an anti-pattern for most scenarios.
            //
            // When deciding how frequently to checkpoint, you'll need to consider the trade-off between the costs of creating the checkpoint against the costs of
            // processing events.  For scenarios where processing events is very cheap, it is often a better approach to checkpoint once per some number of events or
            // once per time interval.  For scenarios where processing events is more expensive, it may be a better approach to checkpoint more frequently.
            //
            // In either case, it is important to understand that your processing must be tolerant of receiving the same event to be processed more than once; the
            // Event Hubs service, like most messaging platforms, guarantees at-least-once delivery.  Even were you to create a checkpoint for each event that you
            // process, it is entirely possible that you would receive that same event again from the service.

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

            // To begin, we'll publish a batch of events for our processor to receive. Because we are not specifying any routing hints,
            // the Event Hubs service will automatically route these to partitions.  We'll split the events into a couple of batches to
            // increase the chance they'll be spread around.

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

            // With our events having been published, we'll create an Event Hub Processor to read them.

            string consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;
            BlobContainerClient storageClient = new BlobContainerClient(blobStorageConnectionString, blobContainerName);
            EventProcessorClient processor = new EventProcessorClient(storageClient, consumerGroup, eventHubsConnectionString, eventHubName);

            // When your handler for processing events is invoked, the set of event arguments that it are passed allow the associated event to be
            // saved as a checkpoint for the processor.  For this example, our handler will create a checkpoint once per batch of events that we
            // sent.

            int eventIndex = 0;
            int eventsSinceLastCheckpoint = 0;

            async Task processEventHandler(ProcessEventArgs eventArgs)
            {
                if (eventArgs.CancellationToken.IsCancellationRequested)
                {
                    return;
                }

                try
                {
                    ++eventIndex;
                    ++eventsSinceLastCheckpoint;

                    if (eventsSinceLastCheckpoint >= eventsPerBatch)
                    {
                        // Updating the checkpoint will interact with the Azure Storage.  As a service call,
                        // this is done asynchronously and may be long-running.  You may want to influence its behavior,
                        // such as limiting the time that it may execute in order to ensure throughput for
                        // processing events.
                        //
                        // In our case, we'll limit the checkpoint operation to a second and request cancellation
                        // if it runs longer.

                        using CancellationTokenSource cancellationSource = new CancellationTokenSource(TimeSpan.FromSeconds(1));

                        try
                        {
                            await eventArgs.UpdateCheckpointAsync(cancellationSource.Token);
                            eventsSinceLastCheckpoint = 0;

                            Console.WriteLine("Created checkpoint");
                        }
                        catch (TaskCanceledException)
                        {
                            Console.WriteLine("Checkpoint creation took too long and was canceled.");
                        }

                        Console.WriteLine();
                    }

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

            processor.ProcessEventAsync += processEventHandler;
            processor.ProcessErrorAsync += processErrorHandler;

            try
            {
                // In order to begin processing, an explicit call must be made to the processor.  This will instruct the processor to begin
                // processing in the background, invoking your handlers when they are needed.

                eventIndex = 0;
                await processor.StartProcessingAsync();

                // Because processing takes place in the background, we'll continue to wait until all of our events were
                // read and handled before stopping.  To ensure that we don't wait indefinitely should an unrecoverable
                // error be encountered, we'll also add a timed cancellation.

                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(TimeSpan.FromSeconds(60));

                while ((!cancellationSource.IsCancellationRequested) && (eventIndex <= expectedEvents.Count))
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

                processor.ProcessEventAsync -= processEventHandler;
                processor.ProcessErrorAsync -= processErrorHandler;
            }

            // The Event Processor client has been stopped and is not explicitly disposable; there
            // is nothing further that we need to do for cleanup.

            Console.WriteLine();
        }
    }
}
