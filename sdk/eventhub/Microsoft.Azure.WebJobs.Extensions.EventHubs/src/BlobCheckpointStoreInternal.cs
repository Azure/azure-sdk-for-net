// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Logging;

namespace Azure.Messaging.EventHubs.Primitives
{
    internal partial class BlobCheckpointStoreInternal
    {
        private readonly string _functionId;
        private readonly ILogger _logger;
        private BlobContainerClient _client;

        /// <summary>
        /// The mocking constructor.
        /// </summary>
        protected BlobCheckpointStoreInternal()
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="BlobCheckpointStoreInternal" /> class.
        /// </summary>
        ///
        /// <param name="blobContainerClient">The client used to interact with the Azure Blob Storage service.</param>
        /// <param name="functionId">The function id for diagnostic messages.</param>
        /// <param name="logger">The logger to use for diagnostic messages.</param>
        ///
        public BlobCheckpointStoreInternal(BlobContainerClient blobContainerClient,
            string functionId,
            ILogger logger): this(blobContainerClient, initializeWithLegacyCheckpoints: true)
        {
            _functionId = functionId;
            _logger = logger;
            _client = blobContainerClient;
        }

        /// <summary>
        ///   Indicates that invalid checkpoint data was found during an attempt to retrieve a list of checkpoints.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition the data is associated with.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the data is associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the data is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the data is associated with.</param>
        ///
        partial void InvalidCheckpointFound(string partitionId, string fullyQualifiedNamespace, string eventHubName, string consumerGroup)
        {
            _logger.LogWarning(
                "Function '{functionId}': An invalid checkpoint was found for partition: '{partitionId}' of FullyQualifiedNamespace: '{fullyQualifiedNamespace}'; EventHubName: '{eventHubName}'; ConsumerGroup: '{consumerGroup}'.  This checkpoint is not valid and will be ignored.",
                _functionId, partitionId, fullyQualifiedNamespace, eventHubName, consumerGroup);
        }

        /// <summary>
        ///   Indicates that an unhandled exception was encountered while retrieving a list of checkpoints.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the checkpoints are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the checkpoints are associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership are associated with.</param>
        /// <param name="partitionId">The identifier of the partition for which the checkpoint was being queried.</param>
        /// <param name="exception">The exception that occurred.</param>
        ///
        partial void GetCheckpointError(string fullyQualifiedNamespace, string eventHubName, string consumerGroup, string partitionId, Exception exception)
        {
            _logger.LogWarning(exception,
                "Function '{functionId}': An exception occurred when retrieving a checkpoint for FullyQualifiedNamespace: '{fullyQualifiedNamespace}'; EventHubName: '{eventHubName}'; ConsumerGroup: '{consumerGroup}'; PartitionId: '{partitionId}'.",
                _functionId, fullyQualifiedNamespace, eventHubName, consumerGroup, partitionId);
        }

        /// <summary>
        /// Attempts to create a storage container if one doesn't exists.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        public async Task CreateIfNotExistsAsync(CancellationToken cancellationToken)
        {
            await _client.CreateIfNotExistsAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
        }
    }
}