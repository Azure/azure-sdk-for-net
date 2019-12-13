// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.Tracing;

namespace Azure.Messaging.EventHubs.Processor.Diagnostics
{


    /// <summary>
    /// EventSource for Azure-Messaging-EventHubs-Processor-BlobEventStore traces.
    ///
    /// When defining Start/Stop tasks, the StopEvent.Id must be exactly StartEvent.Id + 1.
    ///
    /// Do not explicity include the Guid here, since EventSource has a mechanism to automatically
    /// map to an EventSource Guid based on the Name (Azure-Messaging-EventHubs-Processor-BlobEventStore).
    /// </summary>
    [EventSource(Name = "Azure-Messaging-EventHubs-Processor-BlobEventStore")]
    internal class BlobEventStoreEventSource : EventSource
    {
        public static BlobEventStoreEventSource Log { get; } = new BlobEventStoreEventSource();

        internal BlobEventStoreEventSource() { }

        [Event(1, Level = EventLevel.Informational, Message = "BlobsCheckpointStore created. AccountName:{0}; ContainerName:{1}")]
        public virtual void BlobsCheckpointStoreCreated(string accoountName, string name)
        {
            if (IsEnabled())
            {
                WriteEvent(1, accoountName, name);
            }
        }

        [Event(2, Level = EventLevel.Informational, Message = "ListOwnershipAsync started. FullyQualifiedNamespace:{0} EventHubName:{1} ConsumerGroup:{2}")]
        public virtual void ListOwnershipAsyncStart(string fullyQualifiedNamespace, string eventHubName, string consumerGroup)
        {
            if (IsEnabled())
            {
                WriteEvent(2, fullyQualifiedNamespace, eventHubName, consumerGroup);
            }
        }

        [Event(3, Level = EventLevel.Informational, Message = "ListOwnershipAsync completed. FullyQualifiedNamespace:{0} EventHubName:{1} ConsumerGroup:{2} OwnershipCount:{3}")]
        public virtual void ListOwnershipAsyncComplete(string fullyQualifiedNamespace, string eventHubName, string consumerGroup, int ownershipCount)
        {
            if (IsEnabled())
            {
                WriteEvent(3, fullyQualifiedNamespace, eventHubName, consumerGroup, ownershipCount);
            }
        }

        [Event(4, Level = EventLevel.Error, Message = "ListOwnershipAsync error. FullyQualifiedNamespace:{0} EventHubName:{1} ConsumerGroup:{2} ErrorMessage:{3}")]
        public virtual void ListOwnershipAsyncError(string fullyQualifiedNamespace, string eventHubName, string consumerGroup, string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(4, fullyQualifiedNamespace, eventHubName, consumerGroup, errorMessage);
            }
        }

        [Event(5, Level = EventLevel.Informational, Message = "ClaimOwnershipAsync ownership is not claimable. PartitionId:{0} OwnerIdentifier:{1} {2}")]
        public virtual void OwnershipNotClaimable(string partitionId, string ownerIdentifier, string errorMessage = null)
        {
            if (IsEnabled())
            {
                WriteEvent(5, partitionId, ownerIdentifier, errorMessage ?? string.Empty);
            }
        }

        [Event(6, Level = EventLevel.Informational, Message = "ClaimOwnershipAsync Ownership claimaed. PartitionId:{0} OwnerIdentifier:{1}")]
        public virtual void OwnershipClaimed(string partitionId, string ownerIdentifier)
        {
            if (IsEnabled())
            {
                WriteEvent(6, partitionId, ownerIdentifier);
            }
        }

        [Event(7, Level = EventLevel.Informational, Message = "ListCheckpointsAsync Started. FullyQualifiedNamespace:{0} EventHubName:{1} ConsumerGroup:{2}")]
        public virtual void ListCheckpointsAsyncStart(string fullyQualifiedNamespace, string eventHubName, string consumerGroup)
        {
            if (IsEnabled())
            {
                WriteEvent(7, fullyQualifiedNamespace, eventHubName, consumerGroup);
            }
        }

        [Event(8, Level = EventLevel.Informational, Message = "ListCheckpointsAsync Completed. FullyQualifiedNamespace:{0} EventHubName:{1} ConsumerGroup:{2} CheckpointCount:{3}")]
        public virtual void ListCheckpointsAsyncComplete(string fullyQualifiedNamespace, string eventHubName, string consumerGroup, int checkPointCount)
        {
            if (IsEnabled())
            {
                WriteEvent(8, fullyQualifiedNamespace, eventHubName, consumerGroup, checkPointCount);
            }
        }

        [Event(9, Level = EventLevel.Informational, Message = "UpdateCheckpointAsync updated checkpoint. PartitionId:{0}")]
        public virtual void CheckpointUpdated(string partitionId)
        {
            if (IsEnabled())
            {
                WriteEvent(9, partitionId);
            }
        }

        [Event(10, Level = EventLevel.Error, Message = "UpdateCheckpointAsync checkpoint could not be updated. PartitionId:{0} ErrorMessage:{1}")]
        public virtual void CheckpointUpdateError(string partitionId, string errorMessage = null)
        {
            if (IsEnabled())
            {
                WriteEvent(10, partitionId, errorMessage ?? string.Empty);
            }
        }
    }
}