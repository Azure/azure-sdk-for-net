// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.Tracing;

namespace Azure.Messaging.EventHubs.Processor.Diagnostics
{
    /// <summary>
    ///   Serves as an ETW event source for logging of information about
    ///   Event Processor client.
    /// </summary>
    ///
    /// <remarks>
    ///   When defining Start/Stop tasks, it is highly recommended that the
    ///   the StopEvent.Id must be exactly StartEvent.Id + 1.
    /// </remarks>
    ///
    [EventSource(Name = "Azure-Messaging-EventHubs-Processor-EventProcessorClient")]
    internal class EventProcessorEventSource : EventSource
    {
        /// <summary>
        ///   Provides a singleton instance of the event source for callers to
        ///   use for logging.
        /// </summary>
        ///
        public static EventProcessorEventSource Log { get; } = new EventProcessorEventSource();

        internal EventProcessorEventSource() { }

        /// <summary>
        ///   Signals the <see cref="EventProcessorClient" /> to begin processing events.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the event processor.</param>
        ///
        [Event(1, Level = EventLevel.Informational, Message = "Starting a new event processor instance with identifier '{0}'.")]
        public virtual void EventProcessorStart(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(1, identifier);
            }
        }

        /// <summary>
        ///   Indicates that the load balancing has started.
        /// </summary>
        [Event(2, Level = EventLevel.Informational, Message = "Starting load balancer.")]
        public void StartLoadBalacing()
        {
            if (IsEnabled())
            {
                WriteEvent(2);
            }
        }

        /// <summary>
        ///   Indicates the total number of ownership records returned by storage manager.
        /// </summary>
        ///
        /// <param name="count">Total number of ownership records returned by storage manager.</param>
        ///
        [Event(3, Level = EventLevel.Informational, Message = "Storage manager returned '{0}' ownership records.")]
        public virtual void CompleteOwnershipRecordsCount(int count)
        {
            if (IsEnabled())
            {
                WriteEvent(3, count);
            }
        }

        /// <summary>
        ///   Indicates that an exception was encountered while retrieving ownership records.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace that the processor is associated with.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is connected to, specific to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group this event processor is associated with.  Events will be read only in the context of this group.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(4, Level = EventLevel.Error, Message = "An exception occurred while retrieving ownership records. (FullyQualifiedNamespace: '{0}'; EventHubName: '{1}'; ConsumerGroup: '{2}'; ErrorMessage: '{3}')")]
        public virtual void ListOwnershipAsyncError(string fullyQualifiedNamespace, string eventHubName, string consumerGroup, string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(4, fullyQualifiedNamespace, eventHubName, consumerGroup, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates total number of active ownership records.
        /// </summary>
        ///
        /// <param name="count">Total number of active ownership records.</param>
        ///
        [Event(5, Level = EventLevel.Informational, Message = "Number of active ownership records '{0}'.")]
        public virtual void ActiveOwnershipRecordsCount(int count)
        {
            if (IsEnabled())
            {
                WriteEvent(5, count);
            }
        }

        /// <summary>
        ///   Indicates that an exception was encountered while retrieving a list of partition ids.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace that the processor is associated with.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is connected to, specific to the Event Hubs namespace that contains it.</param>
        /// <param name="consumerGroup">The name of the consumer group this event processor is associated with.  Events will be read only in the context of this group.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(6, Level = EventLevel.Error, Message = "An exception occurred while retrieving a list of partition ids. (FullyQualifiedNamespace: '{0}'; EventHubName: '{1}'; ConsumerGroup: '{2}'; ErrorMessage: '{3}')")]
        public virtual void GetPartitionIdsAsyncError(string fullyQualifiedNamespace, string eventHubName, string consumerGroup, string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(6, fullyQualifiedNamespace, eventHubName, consumerGroup, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates the minimum amount of partitions every event processor needs to own when the distribution is balanced.
        /// </summary>
        ///
        /// <param name="count"> Minimum partitions per event processor.</param>
        ///
        [Event(7, Level = EventLevel.Informational, Message = "Expected minimum partitions per event processor '{0}'.")]
        public void MinimumPartitionsPerEventProcessor(int count)
        {
            if (IsEnabled())
            {
                WriteEvent(7, count);
            }
        }

        /// <summary>
        ///   Indicates the list of unclaimed partitions.
        /// </summary>
        ///
        /// <param name="unclaimedPartitions">List of unclaimed partitions.</param>
        ///
        [Event(8, Level = EventLevel.Informational, Message = "Unclaimed partitions: '{0}'.")]
        public virtual void UnclaimedPartitions(string[] unclaimedPartitions)
        {
            if (IsEnabled())
            {
                WriteEvent(8, unclaimedPartitions.ToString());
            }
        }

        /// <summary>
        ///   Indicates that an attempt to claim ownership for a specific partition has started.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition whose processing is starting.</param>
        ///
        [Event(9, Level = EventLevel.Informational, Message = "Attempting to claim ownership of partition '{0}'.")]
        public virtual void ClaimOwnership(string partitionId)
        {
            if (IsEnabled())
            {
                WriteEvent(9, partitionId);
            }
        }

        /// <summary>
        ///   Indicates that an exception was encountered while claiming ownership for a specific partition.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(10, Level = EventLevel.Error, Message = "Failed to claim ownership of partition '{0}'. (ErrorMessage: '{1}')")]
        public virtual void ClaimOwnershipError(string partitionId, string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(10, partitionId, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that the load is unbalanced and this event processor should own more partitions.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the event processor.</param>
        ///
        [Event(11, Level = EventLevel.Informational, Message = "Load is unbalanced and this event processor should own more partitions. (Identifier: '{0}')")]
        public void ShouldOwnMorePartitions(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(11, identifier);
            }
        }

        /// <summary>
        ///   Indicates that stealable partitions were found, so randomly picking one of them to claim.
        /// </summary>
        [Event(12, Level = EventLevel.Informational, Message = "No unclaimed partitions, stealing from another event processor.")]
        public void StealPartitions()
        {
            if (IsEnabled())
            {
                WriteEvent(12);
            }
        }

        /// <summary>
        ///   Indicates that an attempt to renew ownership has started, so they don't expire.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the event processor.</param>
        ///
        [Event(13, Level = EventLevel.Informational, Message = "Attempting to renew ownership. (Identifier: '{0}')")]
        public virtual void RenewOwnership(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(13, identifier);
            }
        }

        /// <summary>
        ///   Indicates that an exception was encountered while renewing ownership.
        /// </summary>
        ///
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(14, Level = EventLevel.Error, Message = "Failed to renew ownership. (ErrorMessage: '{0}')")]
        public virtual void RenewOwnershipError(string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(14, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Creates and starts running a new partition processing task.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition whose processing is starting.</param>
        ///
        [Event(15, Level = EventLevel.Informational, Message = "Creating and start running a new partition processing task for partition id '{0}'")]
        public virtual void StartPartitionProcessing(string partitionId)
        {
            if (IsEnabled())
            {
                WriteEvent(15, partitionId);
            }
        }

        /// <summary>
        ///   Indicates that an exception was encountered while running a new partition processing task.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(16, Level = EventLevel.Error, Message = "Failed to Create and start running a new partition processing task for partition '{0}'. (ErrorMessage: '{1}')")]
        public virtual void StartPartitionProcessingError(string partitionId, string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(16, partitionId, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that the partition processing task is stopping.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition whose processing is being stopped.</param>
        /// <param name="reason">The reason why the processing for the specified partition is being stopped.</param>
        ///
        [Event(17, Level = EventLevel.Verbose, Message = "Stopping partition processing task for partition id '{0}' with reason '{1}'")]
        public void StopPartitionProcessing(string partitionId, ProcessingStoppedReason reason)
        {
            if (IsEnabled())
            {
                WriteEvent(17, partitionId, reason);
            }
        }

        /// <summary>
        ///   Indicates that an exception was encountered while stopping a partition processing task.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition.</param>
        /// <param name="reason">The reason why the processing for the specified partition is being stopped.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        [Event(18, Level = EventLevel.Error, Message = "An exception occurred while stopping a partition processing task for partition id '{0}' with reason '{1}'. (Error Message: '{2}')")]
        public void StopPartitionProcessingError(string partitionId, ProcessingStoppedReason reason, string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(18, partitionId, reason, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that the partition processing task has been stopped.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition whose processing is being stopped.</param>
        /// <param name="reason">The reason why the processing for the specified partition is being stopped.</param>
        ///
        [Event(19, Level = EventLevel.Verbose, Message = "Stopped partition processing task for partition id '{0}' with reason '{1}'")]
        public void StoppedPartitionProcessing(string partitionId, ProcessingStoppedReason reason)
        {
            if (IsEnabled())
            {
                WriteEvent(19, partitionId, reason);
            }
        }

        /// <summary>
        ///   Signals the <see cref="EventProcessorClient" /> to stop processing events.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the event processor.</param>
        ///
        [Event(20, Level = EventLevel.Verbose, Message = "Stop processing events. (Identifier '{0}')")]
        public void EventProcessorStop(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(20, identifier);
            }
        }

        /// <summary>
        ///   Indicates that an exception was encountered while stop processing events.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the event processor.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        [Event(21, Level = EventLevel.Error, Message = "An exception occurred while stop processing events with identifier '{0}'. (Error Message: '{1}'")]
        public void EventProcessorStopError(string identifier, string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(21, identifier, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that processing of events has stop.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the event processor.</param>
        ///
        [Event(22, Level = EventLevel.Verbose, Message = "Stopped processing events. (Identifier '{0}')")]
        public void EventProcessorStopCompleted(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(22, identifier);
            }
        }
    }
}
