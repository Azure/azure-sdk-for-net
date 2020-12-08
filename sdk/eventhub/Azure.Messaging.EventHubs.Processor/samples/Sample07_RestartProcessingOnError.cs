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
    ///   An example of stopping and restarting the Event Processor client when a specific error is encountered.
    /// </summary>
    ///
    public class Sample07_RestartProcessingOnError : IEventHubsBlobCheckpointSample
    {
        /// <summary>
        ///   The name of the sample.
        /// </summary>
        ///
        public string Name => nameof(Sample07_RestartProcessingOnError);

        /// <summary>
        ///   A short description of the sample.
        /// </summary>
        ///
        public string Description => "An example of stopping and restarting the Event Processor client when a specific error is encountered.";

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
               new EventData(Encoding.UTF8.GetBytes("Third Event, Third Batch"))
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

            // Create a simple handler for event processing.

            int eventIndex = 0;

            Task processEventHandler(ProcessEventArgs eventArgs)
            {
                if (eventArgs.CancellationToken.IsCancellationRequested)
                {
                    return Task.CompletedTask;
                }

                try
                {
                    ++eventIndex;
                    Console.WriteLine($"Event Received: { Encoding.UTF8.GetString(eventArgs.Data.EventBody.ToBytes().ToArray()) }");
                }
                catch (Exception ex)
                {
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
            // For this example, arbitrarily choose to restart processing when an Event Hubs service exception is encountered and simply
            // log other exceptions to the console.
            //
            // It is important to note that this selection is for demonstration purposes only; it does not constitute the recommended course
            // of action for service errors.  Because the right approach for handling errors can vary greatly between different types of
            // application, you will need to determine the error handling strategy that best suits your scenario.

            async Task processErrorHandler(ProcessErrorEventArgs eventArgs)
            {
                // As with the process event handler, the event arguments contain a cancellation token used by the Event Processor client to signal
                // that the operation should be canceled.  The handler should respect cancellation as it is able in order to ensure that the Event
                // Processor client is able to perform its operations efficiently.
                //
                // The process error handler is not awaited by the Event Processor client and is, instead, executed in a fire-and-forget manner.  This
                // means that you may safely interact with the Event Processor client, such as requesting that it stop processing.

                if (eventArgs.CancellationToken.IsCancellationRequested)
                {
                    return;
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

                // We will not pass the cancellation token from the event arguments here, as it will be
                // signaled when we request that the processor stop.

                if (eventArgs.Exception is EventHubsException)
                {
                    Console.WriteLine("Detected an service error.  Restarting the processor...");

                    await processor.StopProcessingAsync();
                    await processor.StartProcessingAsync();

                    Console.WriteLine("Processor has been restarted....");
                    Console.WriteLine();
                }
            }

            processor.ProcessEventAsync += processEventHandler;
            processor.ProcessErrorAsync += processErrorHandler;

            try
            {
                Console.WriteLine("Starting the Event Processor client...");

                eventIndex = 0;
                await processor.StartProcessingAsync();

                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

                // Unfortunately, because the handler is invoked when exceptions are encountered in the Event Processor client and not for the code
                // developers write in the event handlers, there is no reliable way to force an exception.  As a result, it is unlikely that you will
                // be able to observe the error handler in action by just running the Event Processor.
                //
                // Instead, we will wait a short bit to allow processing to take place and then artificially trigger the event handler for illustration
                // purposes.

                await Task.Delay(TimeSpan.FromMilliseconds(250));

                Console.WriteLine("Triggering the error handler...");

                ProcessErrorEventArgs eventArgs = new ProcessErrorEventArgs("fake", "artificial invoke", new EventHubsException(true, eventHubName), cancellationSource.Token);
                await processErrorHandler(eventArgs);

                while ((!cancellationSource.IsCancellationRequested) && (eventIndex <= expectedEvents.Count))
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
    }
}
