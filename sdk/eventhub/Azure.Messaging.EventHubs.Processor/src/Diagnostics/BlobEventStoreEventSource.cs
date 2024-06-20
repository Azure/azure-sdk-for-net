// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;
using Azure.Core.Diagnostics;
using Azure.Messaging.EventHubs.Primitives;

namespace Azure.Messaging.EventHubs.Processor.Diagnostics
{
    /// <summary>
    ///   EventSource for Azure-Messaging-EventHubs-Processor-BlobEventStore traces.
    /// </summary>
    ///
    /// <remarks>
    ///   When defining Start/Stop tasks, it is strongly recommended that the StopEvent.Id be
    ///   exactly StartEvent.Id + 1.
    ///
    ///   Do not explicitly include the Guid here, since EventSource has a mechanism to automatically
    ///   map to an EventSource Guid based on the Name (Azure-Messaging-EventHubs-Processor-BlobEventStore).
    /// </remarks>
    ///
    [EventSource(Name = EventSourceName)]
    internal class BlobEventStoreEventSource : AzureEventSource
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
        ///   Prevents an instance of the <see cref="BlobEventStoreEventSource" /> class from being created
        ///   outside the scope of this library.  Exposed for testing purposes only.
        /// </summary>
        ///
        protected BlobEventStoreEventSource() : base(EventSourceName)
        {
        }

        /// <summary>
        ///   Indicates that a <see cref="BlobCheckpointStoreInternal" /> was created.
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
        [Event(21, Level = EventLevel.Verbose, Message = "Starting to list ownership for FullyQualifiedNamespace: '{0}'; EventHubName: '{1}'; ConsumerGroup: '{2}'.")]
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
        [Event(22, Level = EventLevel.Verbose, Message = "Completed listing ownership for FullyQualifiedNamespace: '{0}'; EventHubName: '{1}'; ConsumerGroup: '{2}'.  There were {3} ownership entries were found.")]
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
        [Event(24, Level = EventLevel.Verbose, Message = "Starting to claim ownership of partition: `{0}` of FullyQualifiedNamespace: '{1}'; EventHubName: '{2}'; ConsumerGroup: '{3}' for the owner '{4}'.")]
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
        [Event(25, Level = EventLevel.Verbose, Message = "Completed the attempt to claim ownership of partition: `{0}` of FullyQualifiedNamespace: '{1}'; EventHubName: '{2}'; ConsumerGroup: '{3}' for the owner '{4}'.")]
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
        [Event(28, Level = EventLevel.Verbose, Message = "Successfully claimed ownership of partition: `{0}` of FullyQualifiedNamespace: '{1}'; EventHubName: '{2}'; ConsumerGroup: '{3}' for the owner '{4}'.")]
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
        ///   Indicates that an attempt to create/update a checkpoint has started.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the partition being checkpointed.</param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the checkpoint is associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the checkpoint is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the checkpoint is associated with.</param>
        /// <param name="clientIdentifier">The unique identifier of the client that authored this checkpoint.</param>
        /// <param name="sequenceNumber">The sequence number associated with this checkpoint.</param>
        /// <param name="replicationSegment">The replication segment associated with this checkpoint.</param>
        /// <param name="offset">The offset associated with this checkpoint.</param>
        ///
        [Event(32, Level = EventLevel.Verbose, Message = "Starting to create/update a checkpoint for partition: `{0}` of FullyQualifiedNamespace: '{1}'; EventHubName: '{2}'; ConsumerGroup: '{3}'; ClientIdentifier: '{4}'; at SequenceNumber: '{5}' ReplicationSegment: '{6}' Offset: '{7}'.")]
        public virtual void UpdateCheckpointStart(string partitionId,
                                                  string fullyQualifiedNamespace,
                                                  string eventHubName,
                                                  string consumerGroup,
                                                  string clientIdentifier,
                                                  string sequenceNumber,
                                                  string replicationSegment,
                                                  string offset)
        {
            if (IsEnabled())
            {
                WriteEvent(32, partitionId ?? string.Empty, fullyQualifiedNamespace ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty, clientIdentifier ?? string.Empty, sequenceNumber ?? string.Empty, replicationSegment ?? string.Empty, offset ?? string.Empty);
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
        /// <param name="clientIdentifier">The unique identifier of the client that authored this checkpoint.</param>
        /// <param name="sequenceNumber">The sequence number associated with this checkpoint.</param>
        /// <param name="replicationSegment">The replication segment associated with this checkpoint.</param>
        /// <param name="offset">The offset associated with this checkpoint.</param>
        ///
        [Event(33, Level = EventLevel.Verbose, Message = "Completed the attempt to create/update a checkpoint for partition: `{0}` of FullyQualifiedNamespace: '{1}'; EventHubName: '{2}'; ConsumerGroup: '{3}'; ClientIdentifier: '{4}'; at SequenceNumber: '{5}' ReplicationSegment: '{6}' Offset: '{7}'.")]
        public virtual void UpdateCheckpointComplete(string partitionId,
                                                     string fullyQualifiedNamespace,
                                                     string eventHubName,
                                                     string consumerGroup,
                                                     string clientIdentifier,
                                                     string sequenceNumber,
                                                     string replicationSegment,
                                                     string offset)
        {
            if (IsEnabled())
            {
                WriteEvent(33, partitionId ?? string.Empty, fullyQualifiedNamespace ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty, clientIdentifier ?? string.Empty, sequenceNumber ?? string.Empty, replicationSegment ?? string.Empty, offset ?? string.Empty);
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
        /// <param name="clientIdentifier">The unique identifier of the processor that authored this checkpoint.</param>
        /// <param name="sequenceNumber">The sequence number associated with this checkpoint.</param>
        /// <param name="replicationSegment">The replication segment associated with this checkpoint.</param>
        /// <param name="offset">The offset associated with this checkpoint.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(34, Level = EventLevel.Error, Message = "An exception occurred when creating/updating a checkpoint for  partition: `{0}` of FullyQualifiedNamespace: '{1}'; EventHubName: '{2}'; ConsumerGroup: '{3}'; ClientIdentifier: '{5}'; at SequenceNumber: '{6}' ReplicationSegment '{7}' Offset '{8}'.  ErrorMessage: '{4}'.")]
        public virtual void UpdateCheckpointError(string partitionId,
                                                  string fullyQualifiedNamespace,
                                                  string eventHubName,
                                                  string consumerGroup,
                                                  string clientIdentifier,
                                                  string errorMessage,
                                                  string sequenceNumber,
                                                  string replicationSegment,
                                                  string offset)
        {
            if (IsEnabled())
            {
                WriteEvent(34, partitionId ?? string.Empty, fullyQualifiedNamespace ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty, errorMessage ?? string.Empty, clientIdentifier ?? string.Empty, sequenceNumber ?? string.Empty, replicationSegment ?? string.Empty, offset ?? string.Empty);
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

        /// <summary>
        ///   Indicates that an attempt to retrieve a checkpoint has started.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the checkpoint are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the checkpoint is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the checkpoint is associated with.</param>
        /// <param name="partitionId">The partition id the specific checkpoint is associated with.</param>
        ///
        [Event(36, Level = EventLevel.Verbose, Message = "Starting to retrieve checkpoint for FullyQualifiedNamespace: '{0}'; EventHubName: '{1}'; ConsumerGroup: '{2}'; PartitionId: '{3}'.")]
        public virtual void GetCheckpointStart(string fullyQualifiedNamespace,
                                               string eventHubName,
                                               string consumerGroup,
                                               string partitionId)
        {
            if (IsEnabled())
            {
                WriteEvent(36, fullyQualifiedNamespace ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty, partitionId ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an attempt to retrieve a checkpoint has completed.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the checkpoint are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the checkpoint is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the checkpoint is associated with.</param>
        /// <param name="partitionId">The partition id the specific checkpoint is associated with.</param>
        /// <param name="clientIdentifier">The unique identifier of the Event Hubs client that wrote this checkpoint.</param>
        /// <param name="lastModified">The date and time the associated checkpoint was last modified.</param>
        ///
        [Event(37, Level = EventLevel.Verbose, Message = "Completed retrieving checkpoint for FullyQualifiedNamespace: '{0}'; EventHubName: '{1}'; ConsumerGroup: '{2}'; PartitionId: '{3}'; CheckpointAuthor: '{4}'; LastModified: '{5}'")]
        public virtual void GetCheckpointComplete(string fullyQualifiedNamespace,
                                                  string eventHubName,
                                                  string consumerGroup,
                                                  string partitionId,
                                                  string clientIdentifier,
                                                  DateTimeOffset lastModified)
        {
            if (IsEnabled())
            {
                WriteEvent(37, fullyQualifiedNamespace ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty, partitionId, clientIdentifier ?? string.Empty, lastModified);
            }
        }

        /// <summary>
        ///   Indicates that an unhandled exception was encountered while retrieving a checkpoint.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace the checkpoint are associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the specific Event Hub the checkpoint is associated with, relative to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group the checkpoint is associated with.</param>
        /// <param name="partitionId">The partition id the specific checkpoint is associated with.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(38, Level = EventLevel.Error, Message = "An exception occurred when retrieving checkpoint for FullyQualifiedNamespace: '{0}'; EventHubName: '{1}'; ConsumerGroup: '{2}'; PartitionId: '{3}'; ErrorMessage: '{4}'.")]
        public virtual void GetCheckpointError(string fullyQualifiedNamespace,
                                               string eventHubName,
                                               string consumerGroup,
                                               string partitionId,
                                               string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(38, fullyQualifiedNamespace ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty, partitionId ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Writes an event with three string arguments and a value type argument into a stack allocated
        ///   <see cref="EventSource.EventData"/> struct to avoid the parameter array allocation on the WriteEvent methods.
        /// </summary>
        ///
        /// <param name="eventId">The identifier of the event.</param>
        /// <param name="arg1">The first argument.</param>
        /// <param name="arg2">The second argument.</param>
        /// <param name="arg3">The third argument.</param>
        /// <param name="arg4">The fourth argument.</param>
        ///
        [NonEvent]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private unsafe void WriteEvent<TValue1>(int eventId,
                                                string arg1,
                                                string arg2,
                                                string arg3,
                                                TValue1 arg4)
            where TValue1 : struct
        {
            fixed (char* arg1Ptr = arg1)
            fixed (char* arg2Ptr = arg2)
            fixed (char* arg3Ptr = arg3)
            {
                var eventPayload = stackalloc EventData[4];

                eventPayload[0].Size = (arg1.Length + 1) * sizeof(char);
                eventPayload[0].DataPointer = (IntPtr)arg1Ptr;

                eventPayload[1].Size = (arg2.Length + 1) * sizeof(char);
                eventPayload[1].DataPointer = (IntPtr)arg2Ptr;

                eventPayload[2].Size = (arg3.Length + 1) * sizeof(char);
                eventPayload[2].DataPointer = (IntPtr)arg3Ptr;

                eventPayload[3].Size = Unsafe.SizeOf<TValue1>();
                eventPayload[3].DataPointer = (IntPtr)Unsafe.AsPointer(ref arg4);

                WriteEventCore(eventId, 4, eventPayload);
            }
        }

        /// <summary>
        ///   Writes an event with four string arguments into a stack allocated <see cref="EventSource.EventData"/> struct
        ///   to avoid the parameter array allocation on the WriteEvent methods.
        /// </summary>
        ///
        /// <param name="eventId">The identifier of the event.</param>
        /// <param name="arg1">The first argument.</param>
        /// <param name="arg2">The second argument.</param>
        /// <param name="arg3">The third argument.</param>
        /// <param name="arg4">The fourth argument.</param>
        ///
        [NonEvent]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private unsafe void WriteEvent(int eventId,
                                       string arg1,
                                       string arg2,
                                       string arg3,
                                       string arg4)
        {
            fixed (char* arg1Ptr = arg1)
            fixed (char* arg2Ptr = arg2)
            fixed (char* arg3Ptr = arg3)
            fixed (char* arg4Ptr = arg4)
            {
                var eventPayload = stackalloc EventData[4];

                eventPayload[0].Size = (arg1.Length + 1) * sizeof(char);
                eventPayload[0].DataPointer = (IntPtr)arg1Ptr;

                eventPayload[1].Size = (arg2.Length + 1) * sizeof(char);
                eventPayload[1].DataPointer = (IntPtr)arg2Ptr;

                eventPayload[2].Size = (arg3.Length + 1) * sizeof(char);
                eventPayload[2].DataPointer = (IntPtr)arg3Ptr;

                eventPayload[3].Size = (arg4.Length + 1) * sizeof(char);
                eventPayload[3].DataPointer = (IntPtr)arg4Ptr;

                WriteEventCore(eventId, 4, eventPayload);
            }
        }
        /// <summary>
        ///   Writes an event with five string arguments into a stack allocated
        ///   <see cref="EventSource.EventData"/> struct to avoid the parameter array allocation on the WriteEvent methods.
        /// </summary>
        ///
        /// <param name="eventId">The identifier of the event.</param>
        /// <param name="arg1">The first argument.</param>
        /// <param name="arg2">The second argument.</param>
        /// <param name="arg3">The third argument.</param>
        /// <param name="arg4">The fourth argument.</param>
        /// <param name="arg5">The fifth argument.</param>
        ///
        [NonEvent]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private unsafe void WriteEvent(int eventId,
                                       string arg1,
                                       string arg2,
                                       string arg3,
                                       string arg4,
                                       string arg5)
        {
            fixed (char* arg1Ptr = arg1)
            fixed (char* arg2Ptr = arg2)
            fixed (char* arg3Ptr = arg3)
            fixed (char* arg4Ptr = arg4)
            fixed (char* arg5Ptr = arg5)
            {
                var eventPayload = stackalloc EventData[5];

                eventPayload[0].Size = (arg1.Length + 1) * sizeof(char);
                eventPayload[0].DataPointer = (IntPtr)arg1Ptr;

                eventPayload[1].Size = (arg2.Length + 1) * sizeof(char);
                eventPayload[1].DataPointer = (IntPtr)arg2Ptr;

                eventPayload[2].Size = (arg3.Length + 1) * sizeof(char);
                eventPayload[2].DataPointer = (IntPtr)arg3Ptr;

                eventPayload[3].Size = (arg4.Length + 1) * sizeof(char);
                eventPayload[3].DataPointer = (IntPtr)arg4Ptr;

                eventPayload[4].Size = (arg5.Length + 1) * sizeof(char);
                eventPayload[4].DataPointer = (IntPtr)arg5Ptr;

                WriteEventCore(eventId, 5, eventPayload);
            }
        }

        /// <summary>
        ///   Writes an event with six string arguments into a stack allocated <see cref="EventSource.EventData"/> struct
        ///   to avoid the parameter array allocation on the WriteEvent methods.
        /// </summary>
        ///
        /// <param name="eventId">The identifier of the event.</param>
        /// <param name="arg1">The first argument.</param>
        /// <param name="arg2">The second argument.</param>
        /// <param name="arg3">The third argument.</param>
        /// <param name="arg4">The fourth argument.</param>
        /// <param name="arg5">The fifth argument.</param>
        /// <param name="arg6">The sixth argument.</param>
        ///
        [NonEvent]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private unsafe void WriteEvent(int eventId,
                                       string arg1,
                                       string arg2,
                                       string arg3,
                                       string arg4,
                                       string arg5,
                                       string arg6)
        {
            fixed (char* arg1Ptr = arg1)
            fixed (char* arg2Ptr = arg2)
            fixed (char* arg3Ptr = arg3)
            fixed (char* arg4Ptr = arg4)
            fixed (char* arg5Ptr = arg5)
            fixed (char* arg6Ptr = arg6)
            {
                var eventPayload = stackalloc EventData[6];

                eventPayload[0].Size = (arg1.Length + 1) * sizeof(char);
                eventPayload[0].DataPointer = (IntPtr)arg1Ptr;

                eventPayload[1].Size = (arg2.Length + 1) * sizeof(char);
                eventPayload[1].DataPointer = (IntPtr)arg2Ptr;

                eventPayload[2].Size = (arg3.Length + 1) * sizeof(char);
                eventPayload[2].DataPointer = (IntPtr)arg3Ptr;

                eventPayload[3].Size = (arg4.Length + 1) * sizeof(char);
                eventPayload[3].DataPointer = (IntPtr)arg4Ptr;

                eventPayload[4].Size = (arg5.Length + 1) * sizeof(char);
                eventPayload[4].DataPointer = (IntPtr)arg5Ptr;

                eventPayload[5].Size = (arg6.Length + 1) * sizeof(char);
                eventPayload[5].DataPointer = (IntPtr)arg6Ptr;

                WriteEventCore(eventId, 6, eventPayload);
            }
        }

        /// <summary>
        ///   Writes an event with five string arguments and a value type argument into a stack allocated
        ///   <see cref="EventSource.EventData"/> struct to avoid the parameter array allocation on the WriteEvent methods.
        /// </summary>
        ///
        /// <param name="eventId">The identifier of the event.</param>
        /// <param name="arg1">The first argument.</param>
        /// <param name="arg2">The second argument.</param>
        /// <param name="arg3">The third argument.</param>
        /// <param name="arg4">The fourth argument.</param>
        /// <param name="arg5">The fifth argument.</param>
        /// <param name="arg6">The sixth argument.</param>
        ///
        [NonEvent]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private unsafe void WriteEvent<TValue1>(int eventId,
                                                string arg1,
                                                string arg2,
                                                string arg3,
                                                string arg4,
                                                string arg5,
                                                TValue1 arg6)
            where TValue1 : struct
        {
            fixed (char* arg1Ptr = arg1)
            fixed (char* arg2Ptr = arg2)
            fixed (char* arg3Ptr = arg3)
            fixed (char* arg4Ptr = arg4)
            fixed (char* arg5Ptr = arg5)
            {
                var eventPayload = stackalloc EventData[6];

                eventPayload[0].Size = (arg1.Length + 1) * sizeof(char);
                eventPayload[0].DataPointer = (IntPtr)arg1Ptr;

                eventPayload[1].Size = (arg2.Length + 1) * sizeof(char);
                eventPayload[1].DataPointer = (IntPtr)arg2Ptr;

                eventPayload[2].Size = (arg3.Length + 1) * sizeof(char);
                eventPayload[2].DataPointer = (IntPtr)arg3Ptr;

                eventPayload[3].Size = (arg4.Length + 1) * sizeof(char);
                eventPayload[3].DataPointer = (IntPtr)arg4Ptr;

                eventPayload[4].Size = (arg5.Length + 1) * sizeof(char);
                eventPayload[4].DataPointer = (IntPtr)arg5Ptr;

                eventPayload[5].Size = Unsafe.SizeOf<TValue1>();
                eventPayload[5].DataPointer = (IntPtr)Unsafe.AsPointer(ref arg6);

                WriteEventCore(eventId, 6, eventPayload);
            }
        }

        /// <summary>
        ///   Writes an event with five string arguments and three value type arguments into a stack allocated
        ///   <see cref="EventSource.EventData"/> struct to avoid the parameter array allocation on the WriteEvent methods.
        /// </summary>
        ///
        /// <param name="eventId">The identifier of the event.</param>
        /// <param name="arg1">The first argument.</param>
        /// <param name="arg2">The second argument.</param>
        /// <param name="arg3">The third argument.</param>
        /// <param name="arg4">The fourth argument.</param>
        /// <param name="arg5">The fifth argument.</param>
        /// <param name="arg6">The sixth argument.</param>
        /// <param name="arg7">The seventh argument.</param>
        /// <param name="arg8">The eighth argument.</param>
        ///
        [NonEvent]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private unsafe void WriteEvent(int eventId,
                                       string arg1,
                                       string arg2,
                                       string arg3,
                                       string arg4,
                                       string arg5,
                                       string arg6,
                                       string arg7,
                                       string arg8)
        {
            fixed (char* arg1Ptr = arg1)
            fixed (char* arg2Ptr = arg2)
            fixed (char* arg3Ptr = arg3)
            fixed (char* arg4Ptr = arg4)
            fixed (char* arg5Ptr = arg5)
            fixed (char* arg6Ptr = arg6)
            fixed (char* arg7Ptr = arg7)
            fixed (char* arg8Ptr = arg8)
            {
                var eventPayload = stackalloc EventData[8];

                eventPayload[0].Size = (arg1.Length + 1) * sizeof(char);
                eventPayload[0].DataPointer = (IntPtr)arg1Ptr;

                eventPayload[1].Size = (arg2.Length + 1) * sizeof(char);
                eventPayload[1].DataPointer = (IntPtr)arg2Ptr;

                eventPayload[2].Size = (arg3.Length + 1) * sizeof(char);
                eventPayload[2].DataPointer = (IntPtr)arg3Ptr;

                eventPayload[3].Size = (arg4.Length + 1) * sizeof(char);
                eventPayload[3].DataPointer = (IntPtr)arg4Ptr;

                eventPayload[4].Size = (arg5.Length + 1) * sizeof(char);
                eventPayload[4].DataPointer = (IntPtr)arg5Ptr;

                eventPayload[5].Size = (arg6.Length + 1) * sizeof(char);
                eventPayload[5].DataPointer = (IntPtr)arg6Ptr;

                eventPayload[6].Size = (arg7.Length + 1) * sizeof(char);
                eventPayload[6].DataPointer = (IntPtr)arg7Ptr;

                eventPayload[7].Size = (arg8.Length + 1) * sizeof(char);
                eventPayload[7].DataPointer = (IntPtr)arg8Ptr;

                WriteEventCore(eventId, 8, eventPayload);
            }
        }

        /// <summary>
        ///   Writes an event with six string arguments and three value type arguments into a stack allocated
        ///   <see cref="EventSource.EventData"/> struct to avoid the parameter array allocation on the WriteEvent methods.
        /// </summary>
        ///
        /// <param name="eventId">The identifier of the event.</param>
        /// <param name="arg1">The first argument.</param>
        /// <param name="arg2">The second argument.</param>
        /// <param name="arg3">The third argument.</param>
        /// <param name="arg4">The fourth argument.</param>
        /// <param name="arg5">The fifth argument.</param>
        /// <param name="arg6">The sixth argument.</param>
        /// <param name="arg7">The seventh argument.</param>
        /// <param name="arg8">The eighth argument.</param>
        /// <param name="arg9">The ninth argument.</param>
        ///
        [NonEvent]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private unsafe void WriteEvent(int eventId,
                                       string arg1,
                                       string arg2,
                                       string arg3,
                                       string arg4,
                                       string arg5,
                                       string arg6,
                                       string arg7,
                                       string arg8,
                                       string arg9)
        {
            fixed (char* arg1Ptr = arg1)
            fixed (char* arg2Ptr = arg2)
            fixed (char* arg3Ptr = arg3)
            fixed (char* arg4Ptr = arg4)
            fixed (char* arg5Ptr = arg5)
            fixed (char* arg6Ptr = arg6)
            fixed (char* arg7Ptr = arg7)
            fixed (char* arg8Ptr = arg8)
            fixed (char* arg9Ptr = arg9)
            {
                var eventPayload = stackalloc EventData[9];

                eventPayload[0].Size = (arg1.Length + 1) * sizeof(char);
                eventPayload[0].DataPointer = (IntPtr)arg1Ptr;

                eventPayload[1].Size = (arg2.Length + 1) * sizeof(char);
                eventPayload[1].DataPointer = (IntPtr)arg2Ptr;

                eventPayload[2].Size = (arg3.Length + 1) * sizeof(char);
                eventPayload[2].DataPointer = (IntPtr)arg3Ptr;

                eventPayload[3].Size = (arg4.Length + 1) * sizeof(char);
                eventPayload[3].DataPointer = (IntPtr)arg4Ptr;

                eventPayload[4].Size = (arg5.Length + 1) * sizeof(char);
                eventPayload[4].DataPointer = (IntPtr)arg5Ptr;

                eventPayload[5].Size = (arg6.Length + 1) * sizeof(char);
                eventPayload[5].DataPointer = (IntPtr)arg6Ptr;

                eventPayload[6].Size = (arg7.Length + 1) * sizeof(char);
                eventPayload[6].DataPointer = (IntPtr)arg7Ptr;

                eventPayload[7].Size = (arg8.Length + 1) * sizeof(char);
                eventPayload[7].DataPointer = (IntPtr)arg8Ptr;

                eventPayload[8].Size = (arg9.Length + 1) * sizeof(char);
                eventPayload[8].DataPointer = (IntPtr)arg9Ptr;

                WriteEventCore(eventId, 9, eventPayload);
            }
        }
    }
}
