﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Primitives;

namespace Microsoft.Azure.WebJobs.EventHubs.Processor
{
    internal class EventProcessorHostPartition : EventProcessorPartition
    {
        private PartitionContext _partitionContext;

        public EventProcessorHostPartition()
        {
        }

        public EventProcessorHostPartition(string partitionId)
        {
            PartitionId = partitionId;
        }

        public PartitionContext PartitionContext => _partitionContext ??= new EventProcessorHostPartitionContext(this);

        public string Owner => ProcessorHost.Identifier;
        public string EventHubPath => ProcessorHost.EventHubName;
        public CheckpointInfo? Checkpoint { get; set; }

        public LastEnqueuedEventProperties LastEnqueuedEventProperties
        {
            get
            {
                if (ReadLastEnqueuedEventPropertiesFunc == null) return default;

                try
                {
                    return ReadLastEnqueuedEventPropertiesFunc.Invoke(PartitionId);
                }
                catch (EventHubsException e) when (e.Reason == EventHubsException.FailureReason.ClientClosed)
                {
                    // If the connection is closed, just return default value. This could be called before our connection is established (e.g. the context is passed to OnPartitionIntializingAsync, but the
                    // connection for that partion has not been made yet, so the above call will fail).
                    return default;
                }
            }
        }
        public IEventProcessor EventProcessor { get; set; }
        public EventProcessorHost ProcessorHost { get; set; }
        public Func<string, LastEnqueuedEventProperties> ReadLastEnqueuedEventPropertiesFunc { get; set; }

        public async Task CheckpointAsync(EventData checkpointEvent)
        {
            await ProcessorHost.CheckpointAsync(PartitionId, checkpointEvent).ConfigureAwait(false);
            Checkpoint = new CheckpointInfo(checkpointEvent.Offset, checkpointEvent.SequenceNumber);
        }

        private class EventProcessorHostPartitionContext : PartitionContext
        {
            private readonly EventProcessorHostPartition _hostPartition;

            public EventProcessorHostPartitionContext(EventProcessorHostPartition hostPartition) : base(hostPartition.PartitionId)
            {
                _hostPartition = hostPartition;
            }

            public override LastEnqueuedEventProperties ReadLastEnqueuedEventProperties() => _hostPartition.LastEnqueuedEventProperties;
        }
    }
}
