﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;

namespace Azure.Messaging.EventHubs.Processor.Samples.Infrastructure
{
    /// <summary>
    ///   Designates a class as a sample and provides a well-known means
    ///   of executing the sample.
    /// </summary>
    ///
    public interface IEventHubsBlobCheckpointSample
    {
        /// <summary>
        ///   The name of the sample.
        /// </summary>
        ///
        string Name { get; }

        /// <summary>
        ///   A short description of the associated sample.
        /// </summary>
        ///
        string Description { get; }

        /// <summary>
        ///   Allows for executing the sample.
        /// </summary>
        ///
        /// <param name="eventHubsConnectionString">The connection string for the Event Hubs namespace that the sample should target.</param>
        /// <param name="eventHubName">The name of the Event Hub, sometimes known as its path, that the sample should run against.</param>
        /// <param name="blobStorageConnectionString">The connection string for the storage account where checkpoints and state should be persisted.</param>
        /// <param name="blobContainerName">The name of the blob storage container where checkpoints should be persisted.</param>
        ///
        Task RunAsync(string eventHubsConnectionString,
                      string eventHubName,
                      string blobStorageConnectionString,
                      string blobContainerName);
    }
}
