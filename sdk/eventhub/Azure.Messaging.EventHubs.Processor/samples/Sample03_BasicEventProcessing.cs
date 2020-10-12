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
    ///   An introduction to the Event Processor client, illustrating how to perform basic event processing.
    /// </summary>
    ///
    public class Sample03_BasicEventProcessing : IEventHubsBlobCheckpointSample
    {
        /// <summary>
        ///   The name of the sample.
        /// </summary>
        ///
        public string Name => nameof(Sample03_BasicEventProcessing);

        /// <summary>
        ///   A short description of the sample.
        /// </summary>
        ///
        public string Description => "An introduction to the Event Processor client, illustrating how to perform basic event processing.";

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

            // With our events having been published, we'll create an Event Hub Processor to read them.

            string consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;
            BlobContainerClient storageClient = new BlobContainerClient(blobStorageConnectionString, blobContainerName);
            EventProcessorClient processor = new EventProcessorClient(storageClient, consumerGroup, eventHubsConnectionString, eventHubName);

            // When creating a handler for processing events, it is important to note that you are responsible for ensuring that exception handling
            // takes place within your handler code.  Should an exception go unhandled, the processor will allow it to bubble and will not attempt
            // to route it through the exception handler.

            int eventIndex = 0;

            Task processEventHandler(ProcessEventArgs eventArgs)
            {
                // The event arguments contain a cancellation token that the Event Processor client uses to signal
                // your handler that processing should stop when possible.  This is most commonly used in the
                // case that the event processor is stopping or has otherwise encountered an unrecoverable problem.
                //
                // Each of the handlers should respect cancellation as they are able in order to ensure that the
                // Event Processor client is able to perform its operations efficiently.
                //
                // In the case of the process event handler, the Event Processor client must await the result in
                // order to ensure that the ordering of events within a partition is maintained.  This makes respecting
                // the cancellation token important.
                //
                // Also of note, because the Event Processor client must await this handler, you are unable to safely
                // perform operations on the client, such as stopping or starting.  Doing so is likely to result in a
                // deadlock unless it is carefully queued as a background task.

                if (eventArgs.CancellationToken.IsCancellationRequested)
                {
                    return Task.CompletedTask;
                }

                try
                {
                    // For our example, we'll just track that the event was received and write its data to the
                    // console.
                    //
                    // Because there is no long-running or I/O operation, inspecting the cancellation
                    // token again does not make sense in this scenario.  However, in real-world processing, it is
                    // highly recommended that you do so as you are able.   It is also recommended that the cancellation
                    // token be passed to any asynchronous operations that are awaited in this handler.

                    ++eventIndex;
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

                // Because our example handler is running synchronously, we'll manually return a completed
                // task.

                return Task.CompletedTask;
            };

            // The error handler is invoked when there is an exception observed within the Event Processor client; it is not invoked for
            // exceptions in your handler code.  The Event Processor client will make every effort to recover from exceptions and continue
            // processing.  Should an exception that cannot be recovered from is encountered, the processor will forfeit ownership of all partitions
            // that it was processing so that work may redistributed.
            //
            // The exceptions surfaced to this handler may be fatal or non-fatal; because the processor may not be able to accurately predict
            // whether an exception was fatal or whether its state was corrupted, this handler has responsibility for making the determination as to
            // whether processing should be terminated or restarted.  The handler may do so by calling Stop on the processor instance and then, if desired,
            // calling Start on the processor.
            //
            // It is recommended that, for production scenarios, the decision be made by considering observations made by this error handler, the
            // handler invoked when initializing processing for a partition, and the handler invoked when processing for a partition is stopped.  Many
            // developers will also include data from their monitoring platforms in this decision as well.
            //
            // As with event processing, should an exception occur in your code for this handler, processor will allow it to bubble and will not attempt
            // further action.
            //
            // For this example, exceptions will just be logged to the console.

            Task processErrorHandler(ProcessErrorEventArgs eventArgs)
            {
                // As with the process event handler, the event arguments contain a cancellation token used by the Event Processor client to signal
                // that the operation should be canceled.  The handler should respect cancellation as it is able in order to ensure that the Event
                // Processor client is able to perform its operations efficiently.
                //
                // The process error handler is not awaited by the Event Processor client and is, instead, executed in a fire-and-forget manner.  This
                // means that you may safely interact with the Event Processor client, such as requesting that it stop processing.

                if (eventArgs.CancellationToken.IsCancellationRequested)
                {
                    return Task.CompletedTask;
                }

                // Because there is no long-running or I/O operation, inspecting the cancellation token again does not make sense in this scenario.
                // However, in real-world processing, it is recommended that you do so as you are able without compromising your ability to capture
                // and troubleshooting information.
                //
                // It is also recommended that the cancellation token be passed to any asynchronous operations that are awaited in this handler.

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
