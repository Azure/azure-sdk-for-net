// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Processor.Samples.Infrastructure;
using Azure.Storage.Blobs;

namespace Azure.Messaging.EventHubs.Processor.Samples
{
    /// <summary>
    ///   An introduction to the Event Processor client, exploring additional options for creating the
    ///   processor.
    /// </summary>
    ///
    public class Sample02_ProcessorWithCustomOptions : IEventHubsBlobCheckpointSample
    {
        /// <summary>
        ///   The name of the sample.
        /// </summary>
        ///
        public string Name => nameof(Sample02_ProcessorWithCustomOptions);

        /// <summary>
        ///   A short description of the sample.
        /// </summary>
        ///
        public string Description => "An introduction to the Event Processor client, exploring additional options for creating the processor.";

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
            // The Event Processor client offers additional options on creation, allowing you to control different aspects of its behavior
            // should your scenario have needs that differ from the common defaults.  If you choose not to provide these options, the default behaviors
            // suitable to most scenarios are used.
            //
            // The processor allows you to customize how it interacts with the Event Hubs service, such as by influencing how it connects
            // to the service by specifying the transport that communication should use and whether a proxy should be used for network communications.  Please
            // note that a proxy is only supported when using WebSockets as a transport; it isn't compatible with raw TCP or other transport channels.
            //
            // This sample will customize the transport for the connection, using WebSockets and will adjust some of the retry-related values for
            // illustration.

            string consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;
            BlobContainerClient storageClient = new BlobContainerClient(blobStorageConnectionString, blobContainerName);

            var processorOptions = new EventProcessorClientOptions
            {
                ConnectionOptions = new EventHubConnectionOptions
                {
                    TransportType = EventHubsTransportType.AmqpWebSockets,
                    Proxy = (IWebProxy)null
                },

                RetryOptions = new EventHubsRetryOptions
                {
                    MaximumRetries = 5,
                    TryTimeout = TimeSpan.FromMinutes(1)
                }
            };

            EventProcessorClient processor = new EventProcessorClient(storageClient, consumerGroup, eventHubsConnectionString, eventHubName, processorOptions);

            // Once the client has been created, it may be used normally.  For completeness, we'll
            // mirror the minimal skeleton from our first sample, starting and stopping the processor
            // without performing any processing.

            Task processEventHandler(ProcessEventArgs eventArgs) => Task.CompletedTask;
            Task processErrorHandler(ProcessErrorEventArgs eventArgs) => Task.CompletedTask;

            processor.ProcessEventAsync += processEventHandler;
            processor.ProcessErrorAsync += processErrorHandler;

            try
            {
                await processor.StartProcessingAsync();
                await Task.Delay(TimeSpan.FromSeconds(1));
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
