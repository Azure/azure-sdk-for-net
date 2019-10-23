// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.CheckpointStore.Blobs.Samples.Infrastructure;

namespace Azure.Messaging.EventHubs.CheckpointStore.Blobs.Samples
{
    /// <summary>
    ///   An introduction to Event Hubs checkpoint storage using blobs, illustrating how to create an event
    ///   processor and configure it for using blob storage for checkpoints.
    /// </summary>
    ///
    public class Sample01_HelloWorld : IEventHubsBlobCheckpointSample
    {
        /// <summary>
        ///   The name of the sample.
        /// </summary>
        ///
        public string Name { get; } = nameof(Sample01_HelloWorld);

        /// <summary>
        ///   A short description of the sample.
        /// </summary>
        ///
        public string Description { get; } = "An introduction to processing events using Azure blob storage for persisting checkpoints.";

        /// <summary>
        ///   Runs the sample using the specified Event Hubs and Azure storage connection information.
        /// </summary>
        ///
        /// <param name="eventHubsConnectionString">The connection string for the Event Hubs namespace that the sample should target.</param>
        /// <param name="eventHubName">The name of the Event Hub, sometimes known as its path, that the sample should run against.</param>
        /// <param name="blobStorageConnectionString">The connection string for the storage account where checkpoints should be persisted.</param>
        /// <param name="blobContainerName">The name of the blob storage container where checkpoints should be persisted.</param>
        ///
        public async Task RunAsync(string eventHubsConnectionString,
                                   string eventHubName,
                                   string blobStorageConnectionString,
                                   string blobContainerName)
        {
            // TODO: Create sample content

            await Task.Delay(500);
            Console.WriteLine("Connected to Event Hubs and storage");
            Console.WriteLine();
        }
    }
}
