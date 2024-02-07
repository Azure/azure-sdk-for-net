// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Processor;

namespace Azure.Messaging.EventHubs.Primitives
{
    /// <summary>
    ///   Provides a base for creating an event processor with custom processing logic which consumes events across all partitions
    ///   of a given Event Hub for a specific consumer group.  The processor is capable of collaborating with other instances for
    ///   the same Event Hub and consumer group pairing to share work by using a common storage platform to communicate.  Fault tolerance
    ///   is also built-in, allowing the processor to be resilient in the face of errors.
    /// </summary>
    ///
    /// <typeparam name="TPartition">The context of the partition for which an operation is being performed.</typeparam>
    ///
    /// <remarks>
    ///   To enable coordination for sharing of partitions between <see cref="PluggableCheckpointStoreEventProcessor{TPartition}"/> instances, they will assert exclusive
    ///   read access to partitions for the consumer group.  No other readers should be active in the consumer group other than processors intending to collaborate.
    ///   Non-exclusive readers will be denied access; exclusive readers, including processors using a different storage locations, will interfere with the processor's
    ///   operation and performance.
    ///
    ///   The <see cref="PluggableCheckpointStoreEventProcessor{TPartition}" /> is safe to cache and use for the lifetime of an application, and that is best practice when the application
    ///   processes events regularly or semi-regularly.  The processor holds responsibility for efficient resource management, working to keep resource usage low during
    ///   periods of inactivity and manage health during periods of higher use.  Calling either the <see cref="EventProcessor{TPartition}.StopProcessingAsync" /> or <see cref="EventProcessor{TPartition}.StopProcessing" />
    ///   method when processing is complete or as the application is shutting down will ensure that network resources and other unmanaged objects are properly cleaned up.
    /// </remarks>
    ///
    /// <seealso href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventhub/Azure.Messaging.EventHubs/samples">Event Hubs samples and discussion</seealso>
    /// <seealso href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples">Event Hubs event processor samples and discussion</seealso>
    ///
    public abstract class PluggableCheckpointStoreEventProcessor<TPartition> : EventProcessor<TPartition> where TPartition : EventProcessorPartition, new()
    {
        /// <summary>The provider of checkpoint and ownership data for the processor.</summary>
        private readonly CheckpointStore _checkpointStore;

        /// <summary>
        ///   Initializes a new instance of the <see cref="PluggableCheckpointStoreEventProcessor{TPartition}"/> class.
        /// </summary>
        ///
        /// <param name="checkpointStore">Responsible for creation of checkpoints and for ownership claim.  Processor instances sharing this storage will attempt to coordinate and share work.</param>
        /// <param name="eventBatchMaximumCount">The desired number of events to include in a batch to be processed.  This size is the maximum count in a batch; the actual count may be smaller, depending on whether events are available in the Event Hub.</param>
        /// <param name="consumerGroup">The name of the consumer group this processor is associated with.  The processor will assert exclusive read access to partitions for this group.</param>
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the Event Hub name and the shared key properties are contained in this connection string.</param>
        /// <param name="options">The set of options to use for the processor.</param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Event Hubs namespace, it will likely not contain the name of the desired Event Hub,
        ///   which is needed.  In this case, the name can be added manually by adding ";EntityPath=[[ EVENT HUB NAME ]]" to the end of the
        ///   connection string.  For example, ";EntityPath=telemetry-hub".
        ///
        ///   If you have defined a shared access policy directly on the Event Hub itself, then copying the connection string from that
        ///   Event Hub will result in a connection string that contains the name.
        /// </remarks>
        ///
        /// <exception cref="ArgumentOutOfRangeException">Occurs when the requested <paramref name="eventBatchMaximumCount"/> is less than 1.</exception>
        ///
        /// <seealso href="https://docs.microsoft.com/azure/event-hubs/event-hubs-get-connection-string">How to get an Event Hubs connection string</seealso>
        ///
        protected PluggableCheckpointStoreEventProcessor(CheckpointStore checkpointStore,
                                                         int eventBatchMaximumCount,
                                                         string consumerGroup,
                                                         string connectionString,
                                                         EventProcessorOptions options = default) : base(eventBatchMaximumCount, consumerGroup, connectionString, options)
        {
            Argument.AssertNotNull(checkpointStore, nameof(checkpointStore));
            _checkpointStore = checkpointStore;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="PluggableCheckpointStoreEventProcessor{TPartition}"/> class.
        /// </summary>
        ///
        /// <param name="checkpointStore">The provider of checkpoint and ownership data for the processor.  Processor instances sharing this storage will attempt to coordinate and share work.</param>
        /// <param name="eventBatchMaximumCount">The desired number of events to include in a batch to be processed.  This size is the maximum count in a batch; the actual count may be smaller, depending on whether events are available in the Event Hub.</param>
        /// <param name="consumerGroup">The name of the consumer group this processor is associated with.  The processor will assert exclusive read access to partitions for this group.</param>
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the shared key properties are contained in this connection string, but not the Event Hub name.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the processor with.</param>
        /// <param name="options">The set of options to use for the processor.</param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Event Hub itself, it will contain the name of the desired Event Hub,
        ///   and can be used directly without passing the <paramref name="eventHubName" />.  The name of the Event Hub should be
        ///   passed only once, either as part of the connection string or separately.
        /// </remarks>
        ///
        /// <exception cref="ArgumentOutOfRangeException">Occurs when the requested <paramref name="eventBatchMaximumCount"/> is less than 1.</exception>
        ///
        /// <seealso href="https://docs.microsoft.com/azure/event-hubs/event-hubs-get-connection-string">How to get an Event Hubs connection string</seealso>
        ///
        protected PluggableCheckpointStoreEventProcessor(CheckpointStore checkpointStore,
                                                         int eventBatchMaximumCount,
                                                         string consumerGroup,
                                                         string connectionString,
                                                         string eventHubName,
                                                         EventProcessorOptions options = default) : base(eventBatchMaximumCount, consumerGroup, connectionString, eventHubName, options)
        {
            Argument.AssertNotNull(checkpointStore, nameof(checkpointStore));
            _checkpointStore = checkpointStore;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="PluggableCheckpointStoreEventProcessor{TPartition}"/> class.
        /// </summary>
        ///
        /// <param name="checkpointStore">The provider of checkpoint and ownership data for the processor.  Processor instances sharing this storage will attempt to coordinate and share work.</param>
        /// <param name="eventBatchMaximumCount">The desired number of events to include in a batch to be processed.  This size is the maximum count in a batch; the actual count may be smaller, depending on whether events are available in the Event Hub.</param>
        /// <param name="consumerGroup">The name of the consumer group this processor is associated with.  The processor will assert exclusive read access to partitions for this group.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the processor with.</param>
        /// <param name="credential">The shared access key credential to use for authorization.  Access controls may be specified by the Event Hubs namespace or the requested Event Hub, depending on Azure configuration.</param>
        /// <param name="options">The set of options to use for the processor.</param>
        ///
        /// <exception cref="ArgumentOutOfRangeException">Occurs when the requested <paramref name="eventBatchMaximumCount"/> is less than 1.</exception>
        ///
        protected PluggableCheckpointStoreEventProcessor(CheckpointStore checkpointStore,
                                                         int eventBatchMaximumCount,
                                                         string consumerGroup,
                                                         string fullyQualifiedNamespace,
                                                         string eventHubName,
                                                         AzureNamedKeyCredential credential,
                                                         EventProcessorOptions options = default) : base(eventBatchMaximumCount, consumerGroup, fullyQualifiedNamespace, eventHubName, credential, options)
        {
            Argument.AssertNotNull(checkpointStore, nameof(checkpointStore));
            _checkpointStore = checkpointStore;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="PluggableCheckpointStoreEventProcessor{TPartition}"/> class.
        /// </summary>
        ///
        /// <param name="checkpointStore">The provider of checkpoint and ownership data for the processor.  Processor instances sharing this storage will attempt to coordinate and share work.</param>
        /// <param name="eventBatchMaximumCount">The desired number of events to include in a batch to be processed.  This size is the maximum count in a batch; the actual count may be smaller, depending on whether events are available in the Event Hub.</param>
        /// <param name="consumerGroup">The name of the consumer group this processor is associated with.  The processor will assert exclusive read access to partitions for this group.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the processor with.</param>
        /// <param name="credential">The shared signature credential to use for authorization.  Access controls may be specified by the Event Hubs namespace or the requested Event Hub, depending on Azure configuration.</param>
        /// <param name="options">The set of options to use for the processor.</param>
        ///
        /// <exception cref="ArgumentOutOfRangeException">Occurs when the requested <paramref name="eventBatchMaximumCount"/> is less than 1.</exception>
        ///
        protected PluggableCheckpointStoreEventProcessor(CheckpointStore checkpointStore,
                                                         int eventBatchMaximumCount,
                                                         string consumerGroup,
                                                         string fullyQualifiedNamespace,
                                                         string eventHubName,
                                                         AzureSasCredential credential,
                                                         EventProcessorOptions options = default) : base(eventBatchMaximumCount, consumerGroup, fullyQualifiedNamespace, eventHubName, credential, options)
        {
            Argument.AssertNotNull(checkpointStore, nameof(checkpointStore));
            _checkpointStore = checkpointStore;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="PluggableCheckpointStoreEventProcessor{TPartition}"/> class.
        /// </summary>
        ///
        /// <param name="checkpointStore">The provider of checkpoint and ownership data for the processor.  Processor instances sharing this storage will attempt to coordinate and share work.</param>
        /// <param name="eventBatchMaximumCount">The desired number of events to include in a batch to be processed.  This size is the maximum count in a batch; the actual count may be smaller, depending on whether events are available in the Event Hub.</param>
        /// <param name="consumerGroup">The name of the consumer group this processor is associated with.  The processor will assert exclusive read access to partitions for this group.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub to associate the processor with.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Event Hubs namespace or the requested Event Hub, depending on Azure configuration.</param>
        /// <param name="options">The set of options to use for the processor.</param>
        ///
        /// <exception cref="ArgumentOutOfRangeException">Occurs when the requested <paramref name="eventBatchMaximumCount"/> is less than 1.</exception>
        ///
        protected PluggableCheckpointStoreEventProcessor(CheckpointStore checkpointStore,
                                                         int eventBatchMaximumCount,
                                                         string consumerGroup,
                                                         string fullyQualifiedNamespace,
                                                         string eventHubName,
                                                         TokenCredential credential,
                                                         EventProcessorOptions options = default) : base(eventBatchMaximumCount, consumerGroup, fullyQualifiedNamespace, eventHubName, credential, options)
        {
            Argument.AssertNotNull(checkpointStore, nameof(checkpointStore));
            _checkpointStore = checkpointStore;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="PluggableCheckpointStoreEventProcessor{TPartition}"/> class.
        /// </summary>
        ///
        protected PluggableCheckpointStoreEventProcessor()
        {
        }

        /// <summary>
        ///   Returns a checkpoint for the Event Hub, consumer group, and identifier of the partition associated with the
        ///   event processor instance, so that processing for a given partition can be properly initialized.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition for which to retrieve the checkpoint.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the processing.  This is most likely to occur when the processor is shutting down.</param>
        ///
        /// <returns>The checkpoint for the processor to take into account when initializing partition.</returns>
        ///
        /// <remarks>
        ///   Should a partition not have a corresponding checkpoint, the <see cref="EventProcessorOptions.DefaultStartingPosition" /> will
        ///   be used to initialize the partition for processing.
        ///
        ///   In the event that a custom starting point is desired for a single partition, or each partition should start at a unique place,
        ///   it is recommended that this method express that intent by returning checkpoints for those partitions with the desired custom
        ///   starting location set.
        /// </remarks>
        ///
        protected override Task<EventProcessorCheckpoint> GetCheckpointAsync(string partitionId,
                                                                             CancellationToken cancellationToken) =>
            _checkpointStore.GetCheckpointAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, partitionId, cancellationToken);

        /// <summary>
        ///   Creates or updates a checkpoint for a specific partition, identifying a position in the partition's event stream
        ///   that an event processor should begin reading from.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition the checkpoint is for.</param>
        /// <param name="offset">The offset to associate with the checkpoint, intended as informational metadata. This will only be used for positioning if there is no value provided for <paramref name="sequenceNumber"/>.</param>
        /// <param name="sequenceNumber">The sequence number to associate with the checkpoint, indicating that a processor should begin reading from the next event in the stream.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> instance to signal a request to cancel the operation.</param>
        ///
        protected override Task UpdateCheckpointAsync(string partitionId,
                                                      long offset,
                                                      long? sequenceNumber,
                                                      CancellationToken cancellationToken) =>
            _checkpointStore.UpdateCheckpointAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, partitionId, offset, sequenceNumber, cancellationToken);

        /// <summary>
        ///   Creates or updates a checkpoint for a specific partition, identifying a position in the partition's event stream
        ///   that an event processor should begin reading from.
        /// </summary>
        /// <param name="partitionId">The identifier of the partition the checkpoint is for.</param>
        /// <param name="startingPosition">The starting position to associate with the checkpoint, indicating that a processor should begin reading from the next event in the stream.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> instance to signal a request to cancel the operation</param>
        /// <returns></returns>
        protected override Task UpdateCheckpointAsync(string partitionId,
                                                      CheckpointPosition startingPosition,
                                                      CancellationToken cancellationToken) =>
            _checkpointStore.UpdateCheckpointAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, partitionId, Identifier, startingPosition, cancellationToken);

        /// <summary>
        ///   Requests a list of the ownership assignments for partitions between each of the cooperating event processor
        ///   instances for a given Event Hub and consumer group pairing.  This method is used during load balancing to allow
        ///   the processor to discover other active collaborators and to make decisions about how to best balance work
        ///   between them.
        /// </summary>
        ///
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the processing.  This is most likely to occur when the processor is shutting down.</param>
        ///
        /// <returns>The set of ownership data to take into account when making load balancing decisions.</returns>
        ///
        protected override Task<IEnumerable<EventProcessorPartitionOwnership>> ListOwnershipAsync(CancellationToken cancellationToken) =>
            _checkpointStore.ListOwnershipAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, cancellationToken);

        /// <summary>
        ///   Attempts to claim ownership of the specified partitions for processing.  This operation is used by
        ///   load balancing to enable distributing the responsibility for processing partitions for an
        ///   Event Hub and consumer group pairing amongst the active event processors.
        /// </summary>
        ///
        /// <param name="desiredOwnership">The set of partition ownership desired by the event processor instance; this is the set of partitions that it will attempt to request responsibility for processing.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the processing.  This is most likely to occur when the processor is shutting down.</param>
        ///
        /// <returns>The set of ownership records for the partitions that were successfully claimed; this is expected to be the <paramref name="desiredOwnership"/> or a subset of those partitions.</returns>
        ///
        protected override Task<IEnumerable<EventProcessorPartitionOwnership>> ClaimOwnershipAsync(IEnumerable<EventProcessorPartitionOwnership> desiredOwnership,
                                                                                                   CancellationToken cancellationToken) =>
            _checkpointStore.ClaimOwnershipAsync(desiredOwnership, cancellationToken);
    }
}
