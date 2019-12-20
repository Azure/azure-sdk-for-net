// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Processor.Samples.Infrastructure;
using Azure.Storage.Blobs;

namespace Azure.Messaging.EventHubs.Processor.Samples
{
    /// <summary>
    ///   An introduction to the Event Processor client, illustrating how to create the client and perform basic
    ///   start and stop requests.
    /// </summary>
    ///
    public class Sample01_HelloWorld : IEventHubsBlobCheckpointSample
    {
        /// <summary>
        ///   The name of the sample.
        /// </summary>
        ///
        public string Name => nameof(Sample01_HelloWorld);

        /// <summary>
        ///   A short description of the sample.
        /// </summary>
        ///
        public string Description => "An introduction to the Event Processor client, illustrating how to create the client and perform basic operations.";

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
            // An Event Processor client is associated with a specific Event Hub and consumer group.  The consumer group is
            // a label that identifies one or more consumers as a set.  Often, consumer groups are named after the responsibility
            // of the consumer in an application, such as "Telemetry" or "OrderProcessing".  When an Event Hub is created, a default
            // consumer group is created with it, called "$Default."
            //
            // Each processor has a unique view of the events in the partitions of an Event Hub, meaning that events are available to all
            // processors and are not removed from the partition when a processor reads them.  This allows for one or more of the different
            // Event Hub clients to read and process events from the partition at different speeds and beginning with different events without
            // interfering with one another.
            //
            // An Event Processor client works cooperatively with other Event Processors configured for the same Event Hub and consumer group.  The
            // processors will dynamically detect one another and distribute the responsibility for partitions among themselves to share work.  Should
            // new processor instances appear or others be removed, the work will be automatically redistributed among those processors which are active.
            //
            // In this example, our processor will work as a single instance and will make use of the default consumer group for the
            // associated Event Hub.
            //
            // Our processor will an Azure Storage Blobs container client to use as a durable store for managing state and coordinating with other
            // processors.

            string consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;
            BlobContainerClient storageClient = new BlobContainerClient(blobStorageConnectionString, blobContainerName);
            EventProcessorClient processor = new EventProcessorClient(storageClient, consumerGroup, eventHubsConnectionString, eventHubName);

            // When the processor is first created, it is not actively performing any processing work.  In order to process events, we'll first need to register
            // handlers for the "ProcessEventAsync" and "ProcessErrorAsync" events.
            //
            // These handlers are what allows your code to be invoked when an event is available for processing or when an error is encountered.  They must
            // be provided; without them, the processor will not be able to start.
            //
            // In this example, we'll simply register empty handlers.

            Task processEventHandler(ProcessEventArgs eventArgs) => Task.CompletedTask;
            Task processErrorHandler(ProcessErrorEventArgs eventArgs) => Task.CompletedTask;

            processor.ProcessEventAsync += processEventHandler;
            processor.ProcessErrorAsync += processErrorHandler;

            try
            {
                // In order to begin processing, an explicit call must be made to the processor.  This will instruct the processor to begin
                // processing in the background, invoking your handlers when they are needed.

                await processor.StartProcessingAsync();

                // It is important to note that the start call will return as soon as processing has begun; it will not block and
                // wait for processing to complete.  Should you want to perform other tasks while processing takes place, you are free to do so.
                // If, instead, you would just like to allow processing to take place, you are responsible for blocking or otherwise ensuring
                // that the host process does not complete.
                //
                // In this example, we'll illustrate by waiting for a short delay, during which time processing is occurring.

                await Task.Delay(TimeSpan.FromSeconds(2));

                // When you wish to end processing, an explicit request must be made to do so.  When that request completes, all
                // processing has been confirmed to have stopped.

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
