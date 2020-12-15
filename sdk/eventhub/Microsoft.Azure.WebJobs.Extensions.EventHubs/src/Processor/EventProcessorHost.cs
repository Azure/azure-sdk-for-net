// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
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
        private readonly bool _invokeProcessorAfterReceiveTimeout;
        private readonly Action<ExceptionReceivedEventArgs> _exceptionHandler;
        private IEventProcessorFactory _processorFactory;
        private BlobsCheckpointStore _checkpointStore;

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
            bool invokeProcessorAfterReceiveTimeout,
            Action<ExceptionReceivedEventArgs> exceptionHandler) : base(eventBatchMaximumCount, consumerGroup, connectionString, eventHubName, options)
        {
            _invokeProcessorAfterReceiveTimeout = invokeProcessorAfterReceiveTimeout;
            _exceptionHandler = exceptionHandler;
        }

        public EventProcessorHost(string consumerGroup,
            string fullyQualifiedNamespace,
            TokenCredential credential,
            string eventHubName,
            EventProcessorOptions options,
            int eventBatchMaximumCount,
            bool invokeProcessorAfterReceiveTimeout,
            Action<ExceptionReceivedEventArgs> exceptionHandler) : base(eventBatchMaximumCount, consumerGroup, fullyQualifiedNamespace, eventHubName, credential, options)
        {
            _invokeProcessorAfterReceiveTimeout = invokeProcessorAfterReceiveTimeout;
            _exceptionHandler = exceptionHandler;
        }

        protected override async Task<IEnumerable<EventProcessorPartitionOwnership>> ClaimOwnershipAsync(IEnumerable<EventProcessorPartitionOwnership> desiredOwnership, CancellationToken cancellationToken)
        {
            return await _checkpointStore.ClaimOwnershipAsync(desiredOwnership, cancellationToken).ConfigureAwait(false);
        }

        protected override async Task<IEnumerable<EventProcessorCheckpoint>> ListCheckpointsAsync(CancellationToken cancellationToken)
        {
            return await _checkpointStore.ListCheckpointsAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, cancellationToken).ConfigureAwait(false);
        }

        protected override async Task<IEnumerable<EventProcessorPartitionOwnership>> ListOwnershipAsync(CancellationToken cancellationToken)
        {
            return await _checkpointStore.ListOwnershipAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, cancellationToken).ConfigureAwait(false);
        }

        internal virtual async Task CheckpointAsync(string partitionId, EventData checkpointEvent, CancellationToken cancellationToken = default)
        {
            await _checkpointStore.UpdateCheckpointAsync(new EventProcessorCheckpoint()
            {
                PartitionId = partitionId,
                ConsumerGroup = ConsumerGroup,
                EventHubName = EventHubName,
                FullyQualifiedNamespace = FullyQualifiedNamespace
            }, checkpointEvent, cancellationToken).ConfigureAwait(false);
        }

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
            if ((events == null || !events.Any()) && !_invokeProcessorAfterReceiveTimeout)
            {
                return Task.CompletedTask;
            }

            return partition.EventProcessor.ProcessEventsAsync(partition, events);
        }

        protected override Task OnInitializingPartitionAsync(EventProcessorHostPartition partition, CancellationToken cancellationToken)
        {
            partition.ProcessorHost = this;
            partition.EventProcessor = _processorFactory.CreateEventProcessor();
            partition.ReadLastEnqueuedEventPropertiesFunc = ReadLastEnqueuedEventProperties;

            // Since we are re-initializing this partition, any cached information we have about the partition will be incorrect.
            // Clear it out now, if there is any, we'll refresh it in ListCheckpointsAsync, which EventProcessor will call before starting to pump messages.
            partition.Checkpoint = null;
            return partition.EventProcessor.OpenAsync(partition);
        }

        protected override Task OnPartitionProcessingStoppedAsync(EventProcessorHostPartition partition, ProcessingStoppedReason reason, CancellationToken cancellationToken)
        {
            return partition.EventProcessor.CloseAsync(partition, reason);
        }

        public async Task StartProcessingAsync(
            IEventProcessorFactory processorFactory,
            BlobsCheckpointStore checkpointStore,
            CancellationToken cancellationToken)
        {
            _processorFactory = processorFactory;
            _checkpointStore = checkpointStore;
            await StartProcessingAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}