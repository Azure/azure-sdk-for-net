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
        public static BlobEventStoreEventSource Log { get; } = new BlobEventStoreEventSource(EventSourceName);

        /// <summary>
        ///   Prevents an instance of the <see cref="BlobEventStoreEventSource" /> class from being created
        ///   outside the scope of this library.  Exposed for testing purposes only.
        /// </summary>
        ///
        protected BlobEventStoreEventSource()
        {
        }

        /// <summary>
        ///   Prevents an instance of the <see cref="BlobEventStoreEventSource" /> class from being created
        ///   outside the scope of this library.  Exposed for testing purposes only.
        /// </summary>
        ///
        /// <param name="eventSourceName">The name to assign to the event source.</param>
        ///
        private BlobEventStoreEventSource(string eventSourceName) : base(eventSourceName, EventSourceSettings.Default, AzureEventSourceListener.TraitName, AzureEventSourceListener.TraitValue)
        {
        }

        /// <summary>
        ///   Indicates that a <see cref="BlobsCheckpointStore" /> was created.
        /// </summary>
        ///
        /// <param name="typeName">The type name for the checkpoint store.</param>
        /// <param name="accountName">The Storage account name corresponding to the associated container client.</param>
        /// <param name="containerName">The name of the associated container client.</param>
        ///
        [Event(20, Level = EventLevel.Verbose, Message = "{0} created. AccountName: '{1}'; ContainerName: '{2}'.")]
        public virtual void BlobsCheckpointStoreCreated(string typeName,
                                                        string accountName,
                                                        string containerName)
        {
            if (IsEnabled())
            {
                WriteEvent(20, typeName, accountName ?? string.Empty, containerName ?? string.Empty);
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
        [Event(21, Level = EventLevel.Informational, Message = "Starting to list ownership for FullyQualifiedNamespace: '{0}'; EventHubName: '{1}'; ConsumerGroup: '{2}'.")]
        public virtual void ListOwnershipStart(string fullyQualifiedNamespace,
                                               string eventHubName,
                                               string consumerGroup)
        {
            if (IsEnabled())
            {
                WriteEvent(21, fullyQualifiedNamespace ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty);
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
        [Event(22, Level = EventLevel.Informational, Message = "Completed listing ownership for FullyQualifiedNamespace: '{0}'; EventHubName: '{1}'; ConsumerGroup: '{2}'.  There were {3} ownership entries were found.")]
        public virtual void ListOwnershipComplete(string fullyQualifiedNamespace,
                                                  string eventHubName,
                                                  string consumerGroup,
                                                  int ownershipCount)
        {
            if (IsEnabled())
            {
                WriteEvent(22, fullyQualifiedNamespace ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty, ownershipCount);
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
        [Event(23, Level = EventLevel.Error, Message = "An exception occurred when listing ownership for FullyQualifiedNamespace: '{0}'; EventHubName: '{1}'; ConsumerGroup: '{2}'; ErrorMessage: '{3}'.")]
        public virtual void ListOwnershipError(string fullyQualifiedNamespace,
                                               string eventHubName,
                                               string consumerGroup,
                                               string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(23, fullyQualifiedNamespace ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an attempt to claim a partition ownership has started.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition being claimed.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership is associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the ownership is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership is associated with.</param>
        /// <param name="ownerIdentifier">The identifier of the processor that attempted to claim the ownership for.</param>
        ///
        [Event(24, Level = EventLevel.Informational, Message = "Starting to claim ownership of partition: `{0}` of FullyQualifiedNamespace: '{1}'; EventHubName: '{2}'; ConsumerGroup: '{3}' for the owner '{4}'.")]
        public virtual void ClaimOwnershipStart(string partitionId,
                                                string fullyQualifiedNamespace,
                                                string eventHubName,
                                                string consumerGroup,
                                                string ownerIdentifier)
        {
            if (IsEnabled())
            {
                WriteEvent(24, partitionId ?? string.Empty, fullyQualifiedNamespace ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty, ownerIdentifier ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an attempt to retrieve claim partition ownership has completed.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition being claimed.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership is associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the ownership is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership is associated with.</param>
        /// <param name="ownerIdentifier">The identifier of the processor that attempted to claim the ownership for.</param>
        ///
        [Event(25, Level = EventLevel.Informational, Message = "Completed the attempt to claim ownership of partition: `{0}` of FullyQualifiedNamespace: '{1}'; EventHubName: '{2}'; ConsumerGroup: '{3}' for the owner '{4}'.")]
        public virtual void ClaimOwnershipComplete(string partitionId,
                                                   string fullyQualifiedNamespace,
                                                   string eventHubName,
                                                   string consumerGroup,
                                                   string ownerIdentifier)
        {
            if (IsEnabled())
            {
                WriteEvent(25, partitionId ?? string.Empty, fullyQualifiedNamespace ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty, ownerIdentifier ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an exception was encountered while attempting to retrieve claim partition ownership.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition being claimed.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership is associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the ownership is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership is associated with.</param>
        /// <param name="ownerIdentifier">The identifier of the processor that attempted to claim the ownership for.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(26, Level = EventLevel.Error, Message = "An exception occurred when claiming ownership of partition: `{0}` of FullyQualifiedNamespace: '{1}'; EventHubName: '{2}'; ConsumerGroup: '{3}' for the owner '{4}'.  ErrorMessage: '{5}'.")]
        public virtual void ClaimOwnershipError(string partitionId,
                                                string fullyQualifiedNamespace,
                                                string eventHubName,
                                                string consumerGroup,
                                                string ownerIdentifier,
                                                string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(26, partitionId ?? string.Empty, fullyQualifiedNamespace ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty, ownerIdentifier ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that ownership was unable to be claimed.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition being claimed.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership is associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the ownership is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership is associated with.</param>
        /// <param name="ownerIdentifier">The identifier of the processor that attempted to claim the ownership for.</param>
        /// <param name="message">The message for the failure.</param>
        ///
        [Event(27, Level = EventLevel.Informational, Message = "Unable to claim ownership of partition: `{0}` of FullyQualifiedNamespace: '{1}'; EventHubName: '{2}'; ConsumerGroup: '{3}' for the owner '{4}'.  Message: '{5}'.")]
        public virtual void OwnershipNotClaimable(string partitionId,
                                                  string fullyQualifiedNamespace,
                                                  string eventHubName,
                                                  string consumerGroup,
                                                  string ownerIdentifier,
                                                  string message)
        {
            if (IsEnabled())
            {
                WriteEvent(27, partitionId ?? string.Empty, fullyQualifiedNamespace ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty, ownerIdentifier ?? string.Empty, message ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that ownership was successfully claimed.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition being claimed.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the ownership is associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the ownership is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership is associated with.</param>
        /// <param name="ownerIdentifier">The identifier of the processor that attempted to claim the ownership for.</param>
        ///
        [Event(28, Level = EventLevel.Informational, Message = "Successfully claimed ownership of partition: `{0}` of FullyQualifiedNamespace: '{1}'; EventHubName: '{2}'; ConsumerGroup: '{3}' for the owner '{4}'.")]
        public virtual void OwnershipClaimed(string partitionId,
                                             string fullyQualifiedNamespace,
                                             string eventHubName,
                                             string consumerGroup,
                                             string ownerIdentifier)
        {
            if (IsEnabled())
            {
                WriteEvent(28, partitionId ?? string.Empty, fullyQualifiedNamespace ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty, ownerIdentifier ?? string.Empty);
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
        [Event(29, Level = EventLevel.Informational, Message = "Starting to list checkpoints for FullyQualifiedNamespace: '{0}'; EventHubName: '{1}'; ConsumerGroup: '{2}'.")]
        public virtual void ListCheckpointsStart(string fullyQualifiedNamespace,
                                                 string eventHubName,
                                                 string consumerGroup)
        {
            if (IsEnabled())
            {
                WriteEvent(29, fullyQualifiedNamespace ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty);
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
        [Event(30, Level = EventLevel.Informational, Message = "Completed listing checkpoints for FullyQualifiedNamespace: '{0}'; EventHubName: '{1}'; ConsumerGroup: '{2}'.  There were '{3}' checkpoints found.")]
        public virtual void ListCheckpointsComplete(string fullyQualifiedNamespace,
                                                    string eventHubName,
                                                    string consumerGroup,
                                                    int checkpointCount)
        {
            if (IsEnabled())
            {
                WriteEvent(30, fullyQualifiedNamespace ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty, checkpointCount);
            }
        }

        /// <summary>
        ///   Indicates that an unhandled exception was encountered while retrieving a list of checkpoints.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the checkpoints are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the checkpoints are associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the ownership are associated with.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(31, Level = EventLevel.Error, Message = "An exception occurred when listing checkpoints for FullyQualifiedNamespace: '{0}'; EventHubName: '{1}'; ConsumerGroup: '{2}'; ErrorMessage: '{3}'.")]
        public virtual void ListCheckpointsError(string fullyQualifiedNamespace,
                                                 string eventHubName,
                                                 string consumerGroup,
                                                 string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(31, fullyQualifiedNamespace ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an attempt to create/update a checkpoint has started.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition being checkpointed.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the checkpoint is associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the checkpoint is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the checkpoint is associated with.</param>
        ///
        [Event(32, Level = EventLevel.Informational, Message = "Starting to create/update a checkpoint for partition: `{0}` of FullyQualifiedNamespace: '{1}'; EventHubName: '{2}'; ConsumerGroup: '{3}'.")]
        public virtual void UpdateCheckpointStart(string partitionId,
                                                  string fullyQualifiedNamespace,
                                                  string eventHubName,
                                                  string consumerGroup)
        {
            if (IsEnabled())
            {
                WriteEvent(32, partitionId ?? string.Empty, fullyQualifiedNamespace ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an attempt to update a checkpoint has completed.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition being checkpointed.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the checkpoint is associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the checkpoint is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the checkpoint is associated with.</param>
        ///
        [Event(33, Level = EventLevel.Informational, Message = "Completed the attempt to create/update a checkpoint for partition: `{0}` of FullyQualifiedNamespace: '{1}'; EventHubName: '{2}'; ConsumerGroup: '{3}'.")]
        public virtual void  UpdateCheckpointComplete(string partitionId,
                                                      string fullyQualifiedNamespace,
                                                      string eventHubName,
                                                      string consumerGroup)
        {
            if (IsEnabled())
            {
                WriteEvent(33, partitionId ?? string.Empty, fullyQualifiedNamespace ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an unhandled exception was encountered while updating a checkpoint.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition being checkpointed.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the checkpoint is associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the checkpoint is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the checkpoint is associated with.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(34, Level = EventLevel.Error, Message = "An exception occurred when creating/updating a checkpoint for  partition: `{0}` of FullyQualifiedNamespace: '{1}'; EventHubName: '{2}'; ConsumerGroup: '{3}'.  ErrorMessage: '{4}'.")]
        public virtual void  UpdateCheckpointError(string partitionId,
                                                   string fullyQualifiedNamespace,
                                                   string eventHubName,
                                                   string consumerGroup,
                                                   string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(34, partitionId ?? string.Empty, fullyQualifiedNamespace ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty, errorMessage ?? string.Empty);
            }
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
        [Event(35, Level = EventLevel.Warning, Message = "An invalid checkpoint was found for partition: '{0}' of FullyQualifiedNamespace: '{1}'; EventHubName: '{2}'; ConsumerGroup: '{3}'.  This checkpoint is not valid and will be ignored.")]
        public virtual void InvalidCheckpointFound(string partitionId,
                                                   string fullyQualifiedNamespace,
                                                   string eventHubName,
                                                   string consumerGroup)
        {
            if (IsEnabled())
            {
                WriteEvent(35, partitionId ?? string.Empty, fullyQualifiedNamespace ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty);
            }
        }
    }
}
