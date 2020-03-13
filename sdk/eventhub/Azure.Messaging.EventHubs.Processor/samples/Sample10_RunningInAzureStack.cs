// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Processor.Samples.Infrastructure;
using Azure.Messaging.EventHubs.Producer;
using Azure.Storage.Blobs;

namespace Azure.Messaging.EventHubs.Processor.Samples
{
    /// <summary>
    ///   An example of running the Event Processor in the Azure Stack platform.
    /// </summary>
    ///
    public class Sample10_RunningInAzureStack : IEventHubsBlobCheckpointSample
    {
        /// <summary>
        ///   The name of the sample.
        /// </summary>
        ///
        public string Name => nameof(Sample10_RunningInAzureStack);

        /// <summary>
        ///   A short description of the sample.
        /// </summary>
        ///
        public string Description => "An example of running the Event Processor in the Azure Stack platform.";

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
            // The latest Azure Storage API supported with Azure Stack Hub version 2002 is not compatible with the one that the Azure
            // Storage SDK officially supports.  For this reason, the Event Processor Client, which makes use of the Azure Storage
            // Blobs SDK, cannot be used with Azure Stack resources by default.  This sample illustrates how to work around this issue
            // by using a pipeline policy to force the Azure Storage SDK to downgrade its version.
            //
            // In order to do this, create a Blob Client Options instance and add a Downgrade Version Policy to it.  These options
            // will be passed to the Blob Container Client used by the processor.  The implementation of the policy is provided at
            // the end of this sample.

            string consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;

            BlobClientOptions storageClientOptions = new BlobClientOptions();
            storageClientOptions.AddPolicy(new DowngradeVersionPolicy(), HttpPipelinePosition.PerCall);

            BlobContainerClient storageClient = new BlobContainerClient(blobStorageConnectionString, blobContainerName, storageClientOptions);
            EventProcessorClient processor = new EventProcessorClient(storageClient, consumerGroup, eventHubsConnectionString, eventHubName);

            // For this example, we'll create a simple event handler that writes to the
            // console each time it was invoked.

            int eventsProcessed = 0;

            Task processEventHandler(ProcessEventArgs eventArgs)
            {
                if (eventArgs.CancellationToken.IsCancellationRequested)
                {
                    return Task.CompletedTask;
                }

                if (eventArgs.HasEvent)
                {
                    ++eventsProcessed;
                    Console.WriteLine($"Event Received: { Encoding.UTF8.GetString(eventArgs.Data.Body.ToArray()) }");
                }

                return Task.CompletedTask;
            }

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
                // To begin, we'll publish a batch of events for our processor to receive. Because we are not specifying any routing hints,
                // the Event Hubs service will automatically route it to a single partition.

                var expectedEvents = new List<EventData>()
                {
                   new EventData(Encoding.UTF8.GetBytes("First Event, Single Batch")),
                   new EventData(Encoding.UTF8.GetBytes("Second Event, Single Batch")),
                   new EventData(Encoding.UTF8.GetBytes("Third Event, Single Batch"))
                };

                await using (var producer = new EventHubProducerClient(eventHubsConnectionString, eventHubName))
                {
                    using EventDataBatch eventBatch = await producer.CreateBatchAsync();

                    for (int index = 0; index < expectedEvents.Count; ++index)
                    {
                        eventBatch.TryAdd(expectedEvents[index]);
                    }

                    await producer.SendAsync(eventBatch);
                }

                Console.WriteLine("Starting the Event Processor client...");
                Console.WriteLine();

                await processor.StartProcessingAsync();

                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(TimeSpan.FromSeconds(90));

                while ((!cancellationSource.IsCancellationRequested) && (eventsProcessed < expectedEvents.Count))
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
        ///   A pipeline policy to be applied to a Blob Container Client.  This policy will be applied to every
        ///   request sent by the client, making it possible to specify the Azure Storage version they will target.
        /// </summary>
        ///
        private class DowngradeVersionPolicy : HttpPipelineSynchronousPolicy
        {
            /// <summary>
            ///   The Azure Storage version we want to downgrade to.
            /// </summary>
            ///
            /// <remarks>
            ///   2017-11-09 is the latest version available in Azure Stack 2002.  Older available versions could
            ///   always be specified as long as all operations used by the Event Processor Client are supported.
            /// </remarks>
            ///
            private string Version => @"2017-11-09";

            /// <summary>
            ///   A method that will be called before a request is sent to the Azure Storage service.  Here we are
            ///   overriding this method and injecting the version we want to downgrade to into the request headers.
            /// </summary>
            ///
            /// <param name="message">The message to be sent to the Azure Storage service.</param>
            ///
            public override void OnSendingRequest(HttpMessage message)
            {
                base.OnSendingRequest(message);
                message.Request.Headers.SetValue("x-ms-version", Version);
            }
        }
    }
}
