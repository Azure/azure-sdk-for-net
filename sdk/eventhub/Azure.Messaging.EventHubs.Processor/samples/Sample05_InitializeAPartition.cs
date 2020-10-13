// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Processor.Samples.Infrastructure;
using Azure.Storage.Blobs;

namespace Azure.Messaging.EventHubs.Processor.Samples
{
    /// <summary>
    ///   An introduction to the Event Processor client, illustrating how to participate in initialization for a partition.
    /// </summary>
    ///
    public class Sample05_InitializeAPartition : IEventHubsBlobCheckpointSample
    {
        /// <summary>
        ///   The name of the sample.
        /// </summary>
        ///
        public string Name => nameof(Sample05_InitializeAPartition);

        /// <summary>
        ///   A short description of the sample.
        /// </summary>
        ///
        public string Description => "An introduction to the Event Processor client, illustrating how to participate in initialization for a partition.";

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
            // When the Event Processor client begins processing, it will take ownership over a set of Event Hub partitions to process.  For each
            // partition that the processor claims, the first step in processing is to initialize the partition.  In order to allow developers to
            // track partitions owned by the processor and to participate in the initialization, a "PartitionInitializing" event is available on
            // the processor.
            //
            // When a partition is initialized, one of the decisions made is where in the partition's event stream to begin processing.  In the case
            // where a checkpoint exists for a partition, processing will begin at the next available event after the checkpoint.  When no checkpoint
            // is found for a partition, a default location is used.
            //
            // One of the common reasons that you may choose to participate in initialization is to influence where to begin processing when a checkpoint
            // is not found, overriding the default.  To achieve this, you'll set the associated property on the event arguments within the event handler.

            string consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;
            BlobContainerClient storageClient = new BlobContainerClient(blobStorageConnectionString, blobContainerName);
            EventProcessorClient processor = new EventProcessorClient(storageClient, consumerGroup, eventHubsConnectionString, eventHubName);

            // The handler for partition initialization will set the default position for all partitions, asking to begin reading at the latest
            // point in the stream.

            Task partitionInitializingHandler(PartitionInitializingEventArgs eventArgs)
            {
                if (eventArgs.CancellationToken.IsCancellationRequested)
                {
                    return Task.CompletedTask;
                }

                try
                {
                    eventArgs.DefaultStartingPosition = EventPosition.Latest;
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

            // For this example, events will just be logged to the console.

            Task processEventHandler(ProcessEventArgs eventArgs)
            {
                if (eventArgs.CancellationToken.IsCancellationRequested)
                {
                    return Task.CompletedTask;
                }

                try
                {
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
            processor.ProcessEventAsync += processEventHandler;
            processor.ProcessErrorAsync += processErrorHandler;

            try
            {
                // In order to begin processing, an explicit call must be made to the processor.  This will instruct the processor to begin
                // processing in the background, invoking your handlers when they are needed.

                await processor.StartProcessingAsync();

                // Because processing takes place in the background, we'll wait for a small period of time and then trigger
                // cancellation.

                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

                while (!cancellationSource.IsCancellationRequested)
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
                processor.ProcessEventAsync -= processEventHandler;
                processor.ProcessErrorAsync -= processErrorHandler;
            }

            // The Event Processor client has been stopped and is not explicitly disposable; there
            // is nothing further that we need to do for cleanup.

            Console.WriteLine();
        }
    }
}
