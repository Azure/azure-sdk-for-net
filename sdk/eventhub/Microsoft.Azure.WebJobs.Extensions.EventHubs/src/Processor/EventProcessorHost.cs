// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Primitives;
using Azure.Messaging.EventHubs.Processor;

namespace Microsoft.Azure.WebJobs.EventHubs.Processor
{
    internal class EventProcessorHost : EventProcessor<EventProcessorHostPartition>
    {
        private readonly Action<ExceptionReceivedEventArgs> _exceptionHandler;
        private IEventProcessorFactory _processorFactory;
        private BlobCheckpointStoreInternal _checkpointStore;

        private ConcurrentDictionary<string, CheckpointInfo> _lastReadCheckpoint = new();

        /// <summary>
        /// Mocking constructor
        /// </summary>
        protected EventProcessorHost()
        {
        }

        public EventProcessorHost(string consumerGroup,
            string connectionString,
            string eventHubName,
            EventProcessorOptions options,
            int eventBatchMaximumCount,
            Action<ExceptionReceivedEventArgs> exceptionHandler) : base(eventBatchMaximumCount, consumerGroup, connectionString, eventHubName, options)
        {
            _exceptionHandler = exceptionHandler;
        }

        public EventProcessorHost(string consumerGroup,
            string fullyQualifiedNamespace,
            TokenCredential credential,
            string eventHubName,
            EventProcessorOptions options,
            int eventBatchMaximumCount,
            Action<ExceptionReceivedEventArgs> exceptionHandler) : base(eventBatchMaximumCount, consumerGroup, fullyQualifiedNamespace, eventHubName, credential, options)
        {
            _exceptionHandler = exceptionHandler;
        }

        protected override async Task<IEnumerable<EventProcessorPartitionOwnership>> ClaimOwnershipAsync(IEnumerable<EventProcessorPartitionOwnership> desiredOwnership, CancellationToken cancellationToken)
        {
            return await _checkpointStore.ClaimOwnershipAsync(desiredOwnership, cancellationToken).ConfigureAwait(false);
        }

        protected override async Task<IEnumerable<EventProcessorPartitionOwnership>> ListOwnershipAsync(CancellationToken cancellationToken)
        {
            return await _checkpointStore.ListOwnershipAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, cancellationToken).ConfigureAwait(false);
        }

        protected override async Task<EventProcessorCheckpoint> GetCheckpointAsync(string partitionId, CancellationToken cancellationToken)
        {
            var checkpoint = await _checkpointStore.GetCheckpointAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, partitionId, cancellationToken).ConfigureAwait(false);

            if (checkpoint is BlobCheckpointStoreInternal.BlobStorageCheckpoint blobCheckpoint && blobCheckpoint is not null)
            {
                _lastReadCheckpoint[partitionId] = new CheckpointInfo(blobCheckpoint.Offset ?? -1, blobCheckpoint.SequenceNumber ?? -1,
                    blobCheckpoint.LastModified);
            }

            return checkpoint;
        }

        internal virtual async Task CheckpointAsync(string partitionId, EventData checkpointEvent, CancellationToken cancellationToken = default)
        {
            await _checkpointStore.UpdateCheckpointAsync(
                FullyQualifiedNamespace,
                EventHubName,
                ConsumerGroup,
                partitionId,
                Identifier,
                CheckpointPosition.FromEvent(checkpointEvent),
                cancellationToken).ConfigureAwait(false);
        }

        internal virtual CheckpointInfo? GetLastReadCheckpoint(string partitionId) => _lastReadCheckpoint.TryGetValue(partitionId, out var checkpointInfo) ? checkpointInfo : null;

        protected override Task OnProcessingErrorAsync(Exception exception, EventProcessorHostPartition partition, string operationDescription, CancellationToken cancellationToken)
        {
            if (partition != null)
            {
                return partition.EventProcessor.ProcessErrorAsync(partition, exception);
            }

            try
            {
                _exceptionHandler(new ExceptionReceivedEventArgs(Identifier, operationDescription, null, exception));
            }
            catch
            {
                // ignore
            }

            return Task.CompletedTask;
        }

        protected override Task OnProcessingEventBatchAsync(IEnumerable<EventData> events, EventProcessorHostPartition partition, CancellationToken cancellationToken)
        {
            if (events == null || !events.Any())
            {
                return Task.CompletedTask;
            }

            return partition.EventProcessor.ProcessEventsAsync(partition, events);
        }

        protected override async Task OnInitializingPartitionAsync(EventProcessorHostPartition partition, CancellationToken cancellationToken)
        {
            partition.ProcessorHost = this;
            partition.EventProcessor = _processorFactory.CreatePartitionProcessor();

            // Since we are re-initializing this partition, any cached information we have about the partition will be incorrect.
            // Clear it out now, if there is any, we'll refresh it in GetCheckpointAsync, which EventProcessor will call before starting to pump messages.
            partition.Checkpoint = null;
            await partition.EventProcessor.OpenAsync(partition).ConfigureAwait(false);

            // No ReadLastEnqueuedEventProperties information is available at this moment set the ReadLastEnqueuedEventPropertiesFunc last
            // to avoid an exception in OpenAsync
            partition.ReadLastEnqueuedEventPropertiesFunc = ReadLastEnqueuedEventProperties;
        }

        protected override Task OnPartitionProcessingStoppedAsync(EventProcessorHostPartition partition, ProcessingStoppedReason reason, CancellationToken cancellationToken)
        {
            _lastReadCheckpoint.TryRemove(partition.PartitionId, out _);
            return partition.EventProcessor.CloseAsync(partition, reason);
        }

        public async Task StartProcessingAsync(
            IEventProcessorFactory processorFactory,
            BlobCheckpointStoreInternal checkpointStore,
            CancellationToken cancellationToken)
        {
            _processorFactory = processorFactory;
            _checkpointStore = checkpointStore;
            await StartProcessingAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}