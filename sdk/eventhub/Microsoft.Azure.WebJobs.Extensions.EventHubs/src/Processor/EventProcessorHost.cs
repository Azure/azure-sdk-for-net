// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Primitives;
using Azure.Messaging.EventHubs.Processor;
using Azure.Storage.Blobs;

namespace Microsoft.Azure.WebJobs.EventHubs.Processor
{
    internal class EventProcessorHost
    {
        public string EventHubName { get; }
        public string ConsumerGroupName { get; }
        public string EventHubConnectionString { get; }
        public string StorageConnectionString { get; }
        private string LeaseContainerName { get; }
        private Processor CurrentProcessor { get; set; }
        private Action<ExceptionReceivedEventArgs> ExceptionHandler { get; }

        public EventProcessorHost(string eventHubName, string consumerGroupName, string eventHubConnectionString, string storageConnectionString, string leaseContainerName, Action<ExceptionReceivedEventArgs> exceptionHandler)
        {
            EventHubName = eventHubName;
            ConsumerGroupName = consumerGroupName;
            EventHubConnectionString = eventHubConnectionString;
            StorageConnectionString = storageConnectionString;
            LeaseContainerName = leaseContainerName;
            ExceptionHandler = exceptionHandler;
        }

        public async Task RegisterEventProcessorFactoryAsync(IEventProcessorFactory factory, int maxBatchSize, bool invokeProcessorAfterReceiveTimeout, EventProcessorOptions options)
        {
            if (CurrentProcessor != null)
            {
                throw new InvalidOperationException("Processor has already been started");
            }

            CurrentProcessor = new Processor(maxBatchSize,
                ConsumerGroupName,
                EventHubConnectionString,
                EventHubName,
                options,
                factory,
                invokeProcessorAfterReceiveTimeout,
                ExceptionHandler,
                new BlobContainerClient(StorageConnectionString, LeaseContainerName));
            await CurrentProcessor.StartProcessingAsync().ConfigureAwait(false);
        }

        public async Task UnregisterEventProcessorAsync()
        {
            if (CurrentProcessor == null)
            {
                throw new InvalidOperationException("Processor has not been started");
            }

            await CurrentProcessor.StopProcessingAsync().ConfigureAwait(false);
            CurrentProcessor = null;
        }

        internal class Partition : EventProcessorPartition
        {
            public IEventProcessor Processor { get; set; }
            public ProcessorPartitionContext Context { get; set; }
        }

        internal class Processor : EventProcessor<Partition>
        {
            private IEventProcessorFactory ProcessorFactory { get; }
            private bool InvokeProcessorAfterRecieveTimeout { get; }
            private Action<ExceptionReceivedEventArgs> ExceptionHandler { get; }
            private ConcurrentDictionary<string, LeaseInfo> LeaseInfos { get; }

            private BlobsCheckpointStore CheckpointStore { get; }

            public Processor(int eventBatchMaximumCount, string consumerGroup, string connectionString, string eventHubName, EventProcessorOptions options, IEventProcessorFactory processorFactory, bool invokeProcessorAfterRecieveTimeout, Action<ExceptionReceivedEventArgs> exceptionHandler, BlobContainerClient containerClient) : base(eventBatchMaximumCount, consumerGroup, connectionString, eventHubName, options)
            {
                ProcessorFactory = processorFactory;
                InvokeProcessorAfterRecieveTimeout = invokeProcessorAfterRecieveTimeout;
                ExceptionHandler = exceptionHandler;
                LeaseInfos = new ConcurrentDictionary<string, LeaseInfo>();
                CheckpointStore = new BlobsCheckpointStore(containerClient, RetryPolicy);
            }

            protected override async Task<IEnumerable<EventProcessorPartitionOwnership>> ClaimOwnershipAsync(IEnumerable<EventProcessorPartitionOwnership> desiredOwnership, CancellationToken cancellationToken)
            {
                return await CheckpointStore.ClaimOwnershipAsync(desiredOwnership, cancellationToken).ConfigureAwait(false);
            }

            protected override async Task<IEnumerable<EventProcessorCheckpoint>> ListCheckpointsAsync(CancellationToken cancellationToken)
            {
                return await CheckpointStore.ListCheckpointsAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, cancellationToken).ConfigureAwait(false);
            }

            protected override async Task<IEnumerable<EventProcessorPartitionOwnership>> ListOwnershipAsync(CancellationToken cancellationToken)
            {
                return await CheckpointStore.ListOwnershipAsync(FullyQualifiedNamespace, EventHubName, ConsumerGroup, cancellationToken).ConfigureAwait(false);
            }

            internal virtual async Task CheckpointAsync(string partitionId, EventData checkpointEvent, CancellationToken cancellationToken = default)
            {
                await CheckpointStore.UpdateCheckpointAsync(new EventProcessorCheckpoint()
                {
                    PartitionId = partitionId,
                    ConsumerGroup = ConsumerGroup,
                    EventHubName = EventHubName,
                    FullyQualifiedNamespace = FullyQualifiedNamespace
                }, checkpointEvent, cancellationToken).ConfigureAwait(false);
            }

            internal virtual LeaseInfo GetLeaseInfo(string partitionId)
            {
                if (LeaseInfos.TryGetValue(partitionId, out LeaseInfo lease)) {
                    return lease;
                }

                return null;
            }

            protected override Task OnProcessingErrorAsync(Exception exception, Partition partition, string operationDescription, CancellationToken cancellationToken)
            {
                if (partition != null)
                {
                    return partition.Processor.ProcessErrorAsync(partition.Context, exception);
                }

                try
                {
                    ExceptionHandler(new ExceptionReceivedEventArgs(Identifier, operationDescription, null, exception));
                }
                catch (Exception)
                {
                    // Best effort logging.
                }

                return Task.CompletedTask;
            }

            protected override Task OnProcessingEventBatchAsync(IEnumerable<EventData> events, Partition partition, CancellationToken cancellationToken)
            {
                if ((events == null || !events.Any()) && !InvokeProcessorAfterRecieveTimeout)
                {
                    return Task.CompletedTask;
                }

                return partition.Processor.ProcessEventsAsync(partition.Context, events);
            }

            protected override Task OnInitializingPartitionAsync(Partition partition, CancellationToken cancellationToken)
            {
                partition.Processor = ProcessorFactory.CreateEventProcessor();
                partition.Context = new ProcessorPartitionContext(partition.PartitionId, this, ReadLastEnqueuedEventProperties);

                // Since we are re-initializing this partition, any cached information we have about the parititon will be incorrect.
                // Clear it out now, if there is any, we'll refresh it in ListCheckpointsAsync, which EventProcessor will call before starting to pump messages.
                LeaseInfos.TryRemove(partition.PartitionId, out _);
                return partition.Processor.OpenAsync(partition.Context);
            }

            protected override Task OnPartitionProcessingStoppedAsync(Partition partition, ProcessingStoppedReason reason, CancellationToken cancellationToken)
            {
                return partition.Processor.CloseAsync(partition.Context, reason);
            }
        }
    }
}
