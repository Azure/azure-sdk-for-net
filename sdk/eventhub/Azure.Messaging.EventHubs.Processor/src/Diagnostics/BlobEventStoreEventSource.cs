// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.Tracing;
using Azure.Core.Diagnostics;

namespace Azure.Messaging.EventHubs.Processor.Diagnostics
{
    /// <summary>
    ///   EventSource for Azure-Messaging-EventHubs-Processor-BlobEventStore traces.
    /// </summary>
    ///
    /// <remarks>
    ///   When defining Start/Stop tasks, the StopEvent.Id must be exactly StartEvent.Id + 1.
    ///
    ///   Do not explicitly include the Guid here, since EventSource has a mechanism to automatically
    ///   map to an EventSource Guid based on the Name (Azure-Messaging-EventHubs-Processor-BlobEventStore).
    /// </remarks>
    ///
    [EventSource(Name = EventSourceName)]
    internal class BlobEventStoreEventSource : EventSource
    {
        /// <summary>The name to use for the event source.</summary>
        private const string EventSourceName = "Azure-Messaging-EventHubs-Processor-BlobEventStore";

        /// <summary>
        ///   Provides a singleton instance of the event source for callers to
        ///   use for logging.
        /// </summary>
        ///
        public static BlobEventStoreEventSource Log { get; } = new BlobEventStoreEventSource();

        /// <summary>
        ///   Prevents an instance of the <see cref="BlobEventStoreEventSource"/> class from being created
        ///   outside the scope of this library.  Exposed for testing purposes only.
        /// </summary>
        ///
        internal BlobEventStoreEventSource()  : base(EventSourceName, EventSourceSettings.Default, AzureEventSourceListener.TraitName, AzureEventSourceListener.TraitValue)
        {
        }

        /// <summary>
        ///   Indicates that a <see cref="BlobsCheckpointStore" /> was created.
        /// </summary>
        ///
        /// <param name="accountName">The Storage account name corresponding to the associated container client.</param>
        /// <param name="name">The name of the associated container client.</param>
        ///
        [Event(1, Level = EventLevel.Informational, Message = "BlobsCheckpointStore created. AccountName: '{0}'; ContainerName: '{1}'.")]
        public virtual void BlobsCheckpointStoreCreated(string accountName,
                                                        string name)
        {
            if (IsEnabled())
            {
                WriteEvent(1, accountName ?? string.Empty, name ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an attempt to retrieve a list of ownership has started.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the ownership are associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership are associated with.</param>
        ///
        [Event(2, Level = EventLevel.Informational, Message = "ListOwnershipAsync started. FullyQualifiedNamespace: '{0}'; EventHubName: '{1}'; ConsumerGroup: '{2}'.")]
        public virtual void ListOwnershipAsyncStart(string fullyQualifiedNamespace,
                                                    string eventHubName,
                                                    string consumerGroup)
        {
            if (IsEnabled())
            {
                WriteEvent(2, fullyQualifiedNamespace ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an attempt to retrieve a list of ownership has completed.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the ownership are associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership are associated with.</param>
        /// <param name="ownershipCount">The amount of ownership received from the storage service.</param>
        ///
        [Event(3, Level = EventLevel.Informational, Message = "ListOwnershipAsync completed. FullyQualifiedNamespace: '{0}'; EventHubName: '{1}'; ConsumerGroup: '{2}'; OwnershipCount: '{3}'.")]
        public virtual void ListOwnershipAsyncComplete(string fullyQualifiedNamespace,
                                                       string eventHubName,
                                                       string consumerGroup,
                                                       int ownershipCount)
        {
            if (IsEnabled())
            {
                WriteEvent(3, fullyQualifiedNamespace ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty, ownershipCount);
            }
        }

        /// <summary>
        ///   Indicates that an unhandled exception was encountered while retrieving a list of ownership.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the ownership are associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership are associated with.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(4, Level = EventLevel.Error, Message = "ListOwnershipAsync error. FullyQualifiedNamespace: '{0}'; EventHubName: '{1}'; ConsumerGroup: '{2}'; ErrorMessage: '{3}'.")]
        public virtual void ListOwnershipAsyncError(string fullyQualifiedNamespace,
                                                    string eventHubName,
                                                    string consumerGroup,
                                                    string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(4, fullyQualifiedNamespace ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that the ownership of a partition could not be claimed.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition whose ownership could not be claimed.</param>
        /// <param name="ownerIdentifier">The identifier of the processor that attempted to claim the ownership.</param>
        /// <param name="errorMessage">An error message containing a better explanation of why the claim attempt has failed.</param>
        ///
        [Event(5, Level = EventLevel.Informational, Message = "ClaimOwnershipAsync ownership is not claimable. PartitionId: '{0}'; OwnerIdentifier: '{1}'. {2}")]
        public virtual void OwnershipNotClaimable(string partitionId,
                                                  string ownerIdentifier,
                                                  string errorMessage = null)
        {
            if (IsEnabled())
            {
                WriteEvent(5, partitionId ?? string.Empty, ownerIdentifier ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that the ownership of a partition has been claimed.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition whose ownership has been claimed.</param>
        /// <param name="ownerIdentifier">The identifier of the processor that claimed the ownership.</param>
        ///
        [Event(6, Level = EventLevel.Informational, Message = "ClaimOwnershipAsync ownership claimed. PartitionId: '{0}'; OwnerIdentifier: '{1}'.")]
        public virtual void OwnershipClaimed(string partitionId,
                                             string ownerIdentifier)
        {
            if (IsEnabled())
            {
                WriteEvent(6, partitionId ?? string.Empty, ownerIdentifier ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an attempt to retrieve a list of checkpoints has started.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the checkpoints are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the checkpoints are associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the checkpoints are associated with.</param>
        ///
        [Event(7, Level = EventLevel.Informational, Message = "ListCheckpointsAsync started. FullyQualifiedNamespace: '{0}'; EventHubName: '{1}'; ConsumerGroup: '{2}'.")]
        public virtual void ListCheckpointsAsyncStart(string fullyQualifiedNamespace,
                                                      string eventHubName,
                                                      string consumerGroup)
        {
            if (IsEnabled())
            {
                WriteEvent(7, fullyQualifiedNamespace ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an attempt to retrieve a list of checkpoints has completed.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the checkpoints are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the checkpoints are associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the checkpoints are associated with.</param>
        /// <param name="checkpointCount">The amount of checkpoints received from the storage service.</param>
        ///
        [Event(8, Level = EventLevel.Informational, Message = "ListCheckpointsAsync completed. FullyQualifiedNamespace: '{0}'; EventHubName: '{1}'; ConsumerGroup: '{2}'; CheckpointCount: '{3}'.")]
        public virtual void ListCheckpointsAsyncComplete(string fullyQualifiedNamespace,
                                                         string eventHubName,
                                                         string consumerGroup,
                                                         int checkpointCount)
        {
            if (IsEnabled())
            {
                WriteEvent(8, fullyQualifiedNamespace ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty, checkpointCount);
            }
        }

        /// <summary>
        ///   Indicates that a partition being processed had its checkpoint updated.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition whose checkpoint has been updated.</param>
        ///
        [Event(9, Level = EventLevel.Informational, Message = "UpdateCheckpointAsync updated checkpoint. PartitionId: '{0}'.")]
        public virtual void CheckpointUpdated(string partitionId)
        {
            if (IsEnabled())
            {
                WriteEvent(9, partitionId ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an unhandled exception was encountered while updating a checkpoint.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition whose checkpoint update failed.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(10, Level = EventLevel.Error, Message = "UpdateCheckpointAsync checkpoint could not be updated. PartitionId: '{0}'; ErrorMessage: '{1}'.")]
        public virtual void CheckpointUpdateError(string partitionId,
                                                  string errorMessage = null)
        {
            if (IsEnabled())
            {
                WriteEvent(10, partitionId ?? string.Empty, errorMessage ?? string.Empty);
            }
        }
    }
}
