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
    ///   An example of ensuring that the handler for processing events is invoked on a fixed interval when no events are available.
    /// </summary>
    ///
    public class Sample08_EventProcessingHeartbeat : IEventHubsBlobCheckpointSample
    {
        /// <summary>
        ///   The name of the sample.
        /// </summary>
        ///
        public string Name => nameof(Sample08_EventProcessingHeartbeat);

        /// <summary>
        ///   A short description of the sample.
        /// </summary>
        ///
        public string Description => "An example of ensuring that the handler for processing events is invoked on a fixed interval when no events are available.";

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
            // In this example, our Event Processor client will be configured to use a maximum wait time which is considered when the processor is reading events.
            // When events are available, the Event Processor client will pass them to the ProcessEvent handler to be processed.  When no events are available in any
            // partition for longer than the specified maximum wait interval, the processor will invoke the ProcessEvent handler with a set of arguments that do not
            // include an event.  This allows your handler code to receive control and perform actions such as sending a heartbeat, emitting telemetry, or another
            // operation specific to your application needs.
            //
            // For our processor, we'll specify a small maximum wait time value as part of the options.

            EventProcessorClientOptions clientOptions = new EventProcessorClientOptions
            {
                MaximumWaitTime = TimeSpan.FromMilliseconds(150)
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
                    // The "HasEvent" property of the arguments will be set if an event was available from the
                    // Event Hubs service.  If so, the argument properties for the event is populated and checkpoints
                    // may be created.
                    //
                    // If the "HasEvent" property is unset, the event will be empty and checkpoints may not be created.

                    if (eventArgs.HasEvent)
                    {
                        Console.WriteLine($"Event Received: { Encoding.UTF8.GetString(eventArgs.Data.EventBody.ToBytes().ToArray()) }");
                    }

                    // Simulate sending a heartbeat using a simple helper that writes a status to the
                    // console.

                    await SendHeartbeatAsync();
                    ++eventIndex;
                }
                catch (Exception ex)
                {
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
        ///   A helper method to simulate sending a heartbeat for health monitoring
        ///   during event processing.
        /// </summary>
        ///
        private async Task SendHeartbeatAsync()
        {
            Console.WriteLine("Sending heartbeat (simulated)...");
            await Task.Delay(50);
        }
    }
}
