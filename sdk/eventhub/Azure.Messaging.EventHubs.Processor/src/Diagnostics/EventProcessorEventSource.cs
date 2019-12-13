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
        public static EventProcessorEventSource Log { get; } = new EventProcessorEventSource();

        internal EventProcessorEventSource() { }

        [Event(1, Level = EventLevel.Informational, Message = "Starting a new event processor instance with identifier '{0}'.")]
        public virtual void EventProcessorStart(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(1, identifier);
            }
        }

        [Event(2, Level = EventLevel.Informational, Message = "Starting load balancer.")]
        public void StartLoadBalacing()
        {
            if (IsEnabled())
            {
                WriteEvent(2);
            }
        }

        [Event(3, Level = EventLevel.Informational, Message = "Storage manager returned '{0}' ownership records.")]
        public virtual void CompleteOwnershipRecordsCount(int count)
        {
            if (IsEnabled())
            {
                WriteEvent(3, count);
            }
        }

        [Event(4, Level = EventLevel.Error, Message = "An exception occurred while retrieving ownership records. (FullyQualifiedNamespace: '{0}'; EventHubName: '{1}'; ConsumerGroup: '{2}'; ErrorMessage: '{3}')")]
        public virtual void ListOwnershipAsyncError(string fullyQualifiedNamespace, string eventHubName, string consumerGroup, string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(4, fullyQualifiedNamespace, eventHubName, consumerGroup, errorMessage ?? string.Empty);
            }
        }

        [Event(5, Level = EventLevel.Informational, Message = "Number of active ownership records '{0}'.")]
        public virtual void ActiveOwnershipRecordsCount(int count)
        {
            if (IsEnabled())
            {
                WriteEvent(5, count);
            }
        }

        [Event(6, Level = EventLevel.Error, Message = "An exception occurred while retrieving a list of partition ids. (FullyQualifiedNamespace: '{0}'; EventHubName: '{1}'; ConsumerGroup: '{2}'; ErrorMessage: '{3}')")]
        public virtual void GetPartitionIdsAsyncError(string fullyQualifiedNamespace, string eventHubName, string consumerGroup, string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(6, fullyQualifiedNamespace, eventHubName, consumerGroup, errorMessage ?? string.Empty);
            }
        }

        [Event(7, Level = EventLevel.Informational, Message = "Expected minimum partitions per event processor '{0}'.")]
        public void MinimumPartitionsPerEventProcessor(int count)
        {
            if (IsEnabled())
            {
                WriteEvent(7, count);
            }
        }

        [Event(8, Level = EventLevel.Informational, Message = "Unclaimed partitions: '{0}'.")]
        public virtual void UnclaimedPartitions(string[] unclaimedPartitions)
        {
            if (IsEnabled())
            {
                WriteEvent(8, unclaimedPartitions.ToString());
            }
        }

        [Event(9, Level = EventLevel.Informational, Message = "Attempting to claim ownership of partition '{0}'.")]
        public virtual void ClaimOwnership(string partitionId)
        {
            if (IsEnabled())
            {
                WriteEvent(9, partitionId);
            }
        }

        [Event(10, Level = EventLevel.Error, Message = "Failed to claim ownership of partition '{0}'. (ErrorMessage: '{1}')")]
        public virtual void ClaimOwnershipError(string partitionId, string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(10, partitionId, errorMessage ?? string.Empty);
            }
        }

        [Event(11, Level = EventLevel.Informational, Message = "Load is unbalanced and this event processor should own more partitions. (Identifier: '{0}')")]
        public void ShouldOwnMorePartitions(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(11, identifier);
            }
        }

        [Event(12, Level = EventLevel.Informational, Message = "No unclaimed partitions, stealing from another event processor.")]
        public void StealPartitions()
        {
            if (IsEnabled())
            {
                WriteEvent(12);
            }
        }

        [Event(13, Level = EventLevel.Informational, Message = "Attempting to renew ownership.")]
        public virtual void RenewOwnership()
        {
            if (IsEnabled())
            {
                WriteEvent(13);
            }
        }

        [Event(14, Level = EventLevel.Error, Message = "Failed to renew ownership. (ErrorMessage: '{0}')")]
        public virtual void RenewOwnershipError(string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(14, errorMessage ?? string.Empty);
            }
        }

        [Event(15, Level = EventLevel.Informational, Message = "Creating and start running a new partition processing task for partition id '{0}'")]
        public virtual void StartPartitionProcessing(string partitionId)
        {
            if (IsEnabled())
            {
                WriteEvent(15, partitionId);
            }
        }

        [Event(16, Level = EventLevel.Error, Message = "Failed to Create and start running a new partition processing task for partition '{0}'. (ErrorMessage: '{1}')")]
        public virtual void StartPartitionProcessingError(string partitionId, string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(16, partitionId, errorMessage ?? string.Empty);
            }
        }

        [Event(17, Level = EventLevel.Verbose, Message = "Stopping partition process for partition id '{0}' with reason '{1}'")]
        public void StopPartitionProcessing(string partitionId, ProcessingStoppedReason reason)
        {
            if (IsEnabled())
            {
                WriteEvent(17, partitionId, reason);
            }
        }

        [Event(18, Level = EventLevel.Error, Message = "An exception occurred while stopping partition process for partition id '{0}' with reason '{1}'. (Error Message: '{2}')")]
        public void StopPartitionProcessingError(string identifier, ProcessingStoppedReason reason, string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(18, identifier, reason, errorMessage ?? string.Empty);
            }
        }

        [Event(19, Level = EventLevel.Verbose, Message = "Stopped partition process for partition id '{0}' with reason '{1}'")]
        public void StoppedPartitionProcessing(string partitionId, ProcessingStoppedReason reason)
        {
            if (IsEnabled())
            {
                WriteEvent(19, partitionId, reason);
            }
        }

        [Event(20, Level = EventLevel.Verbose, Message = "Stopping an event processor instance. (Identifier '{0}')")]
        public void EventProcessorStop(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(20, identifier);
            }
        }

        [Event(21, Level = EventLevel.Error, Message = "An exception occurred while stopping an event processor with identifier '{0}'. (Error Message: '{1}'")]
        public void EventProcessorStopError(string identifier, string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(21, identifier, errorMessage ?? string.Empty);
            }
        }

        [Event(22, Level = EventLevel.Verbose, Message = "Event processor stopped. (Identifier '{0}')")]
        public void EventProcessorStopCompleted(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(22, identifier);
            }
        }
    }
}
