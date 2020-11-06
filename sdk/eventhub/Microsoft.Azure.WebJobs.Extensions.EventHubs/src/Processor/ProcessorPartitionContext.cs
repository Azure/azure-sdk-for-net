// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Consumer;

namespace Microsoft.Azure.WebJobs.EventHubs.Processor
{
    internal class ProcessorPartitionContext : PartitionContext
    {
        public string Owner { get => Processor.Identifier; }
        public string EventHubPath { get => Processor.EventHubName; }
        public LeaseInfo Lease { get => Processor.GetLeaseInfo(PartitionId); }
        public LastEnqueuedEventProperties? LastEnqueuedEventProperties
        {
            get
            {
                try
                {
                    return ReadLastEnqueuedEventPropertiesFunc(PartitionId);
                }
                catch (EventHubsException e) when (e.Reason == EventHubsException.FailureReason.ClientClosed)
                {
                    // If the connection is closed, just return default value. This could be called before our connection is established (e.g. the context is passed to OnPartitionIntializingAsync, but the
                    // connection for that partion has not been made yet, so the above call will fail).
                    return default;
                }
            }
        }
        private EventProcessorHost.Processor Processor { get; }
        private Func<string, LastEnqueuedEventProperties> ReadLastEnqueuedEventPropertiesFunc { get;  }
        internal EventData CheckpointEvent { get; set; }

        public ProcessorPartitionContext(string partitionId, EventProcessorHost.Processor processor, Func<string, LastEnqueuedEventProperties> readLastEnqueuedEventPropertiesFunc) : base(partitionId)
        {
            Processor = processor;
            ReadLastEnqueuedEventPropertiesFunc = readLastEnqueuedEventPropertiesFunc;
        }

        public async Task CheckpointAsync()
        {
            await Processor.CheckpointAsync(PartitionId, CheckpointEvent).ConfigureAwait(false);
        }

        public override LastEnqueuedEventProperties ReadLastEnqueuedEventProperties()
        {
            return ReadLastEnqueuedEventPropertiesFunc(PartitionId);
        }
    }
}
