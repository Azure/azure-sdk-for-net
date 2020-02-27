// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.Tracing;
using Azure.Core.Diagnostics;

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
    [EventSource(Name = EventSourceName)]
    internal class EventProcessorEventSource : EventSource
    {
        /// <summary>The name to use for the event source.</summary>
        private const string EventSourceName = "Azure-Messaging-EventHubs-Processor-EventProcessorClient";

        /// <summary>
        ///   Provides a singleton instance of the event source for callers to
        ///   use for logging.
        /// </summary>
        ///
        public static EventProcessorEventSource Log { get; } = new EventProcessorEventSource();

        /// <summary>
        ///   Prevents an instance of the <see cref="EventProcessorEventSource"/> class from being created
        ///   outside the scope of this library.  Exposed for testing purposes only.
        /// </summary>
        ///
        internal EventProcessorEventSource() : base(EventSourceName, EventSourceSettings.Default, AzureEventSourceListener.TraitName, AzureEventSourceListener.TraitValue)
        {
        }

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
                WriteEvent(1, identifier ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates the total number of ownership records returned by storage manager.
        /// </summary>
        ///
        /// <param name="count">Total number of ownership records returned by storage manager.</param>
        ///
        [Event(2, Level = EventLevel.Informational, Message = "Storage manager returned '{0}' ownership records.")]
        public virtual void CompleteOwnershipRecordsCount(int count)
        {
            if (IsEnabled())
            {
                WriteEvent(2, count);
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
        [Event(3, Level = EventLevel.Error, Message = "An exception occurred while retrieving ownership records. (FullyQualifiedNamespace: '{0}'; EventHubName: '{1}'; ConsumerGroup: '{2}'; ErrorMessage: '{3}')")]
        public virtual void ListOwnershipAsyncError(string fullyQualifiedNamespace,
                                                    string eventHubName,
                                                    string consumerGroup,
                                                    string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(3, fullyQualifiedNamespace ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates total number of active ownership records.
        /// </summary>
        ///
        /// <param name="count">Total number of active ownership records.</param>
        ///
        [Event(4, Level = EventLevel.Informational, Message = "Number of active ownership records '{0}'.")]
        public virtual void ActiveOwnershipRecordsCount(int count)
        {
            if (IsEnabled())
            {
                WriteEvent(4, count);
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
        [Event(5, Level = EventLevel.Error, Message = "An exception occurred while retrieving a list of partition ids. (FullyQualifiedNamespace: '{0}'; EventHubName: '{1}'; ConsumerGroup: '{2}'; ErrorMessage: '{3}')")]
        public virtual void GetPartitionIdsAsyncError(string fullyQualifiedNamespace,
                                                      string eventHubName,
                                                      string consumerGroup,
                                                      string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(5, fullyQualifiedNamespace ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Creates and starts running a new partition processing task.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition whose processing is starting.</param>
        ///
        [Event(6, Level = EventLevel.Informational, Message = "Creating and starting running a new partition processing task for partition id '{0}'.")]
        public virtual void StartPartitionProcessing(string partitionId)
        {
            if (IsEnabled())
            {
                WriteEvent(6, partitionId ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an exception was encountered while running a new partition processing task.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(7, Level = EventLevel.Error, Message = "Failed to create and start running a new partition processing task for partition '{0}'. (ErrorMessage: '{1}')")]
        public virtual void StartPartitionProcessingError(string partitionId,
                                                          string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(7, partitionId ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Created and started running a new partition processing task.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition whose processing is starting.</param>
        ///
        [Event(8, Level = EventLevel.Verbose, Message = "Created and started running a new partition processing task for partition id '{0}'.")]
        public virtual void StartPartitionProcessingComplete(string partitionId)
        {
            if (IsEnabled())
            {
                WriteEvent(8, partitionId ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that the partition processing task is stopping.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition whose processing is being stopped.</param>
        /// <param name="reason">The reason why the processing for the specified partition is being stopped.</param>
        ///
        [Event(9, Level = EventLevel.Informational, Message = "Stopping partition processing task for partition id '{0}' with reason '{1}'.")]
        public virtual void StopPartitionProcessingStart(string partitionId,
                                                         ProcessingStoppedReason reason)
        {
            if (IsEnabled())
            {
                WriteEvent(9, partitionId ?? string.Empty, reason);
            }
        }

        /// <summary>
        ///   Indicates that an exception was encountered while stopping a partition processing task.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(10, Level = EventLevel.Error, Message = "An exception occurred while stopping a partition processing task for partition id '{0}' with reason '{1}'. (Error Message: '{2}')")]
        public virtual void PartitionProcessingError(string partitionId,
                                                     string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(10, partitionId ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that the partition processing task has been stopped.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition whose processing has stopped.</param>
        /// <param name="reason">The reason why the processing for the specified partition has stopped.</param>
        ///
        [Event(11, Level = EventLevel.Verbose, Message = "Stopped partition processing task for partition id '{0}' with reason '{1}'.")]
        public virtual void StopPartitionProcessingComplete(string partitionId,
                                                            ProcessingStoppedReason reason)
        {
            if (IsEnabled())
            {
                WriteEvent(11, partitionId ?? string.Empty, reason);
            }
        }

        /// <summary>
        ///   Signals the <see cref="EventProcessorClient" /> to stop processing events.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the event processor.</param>
        ///
        [Event(12, Level = EventLevel.Informational, Message = "Stop processing events. (Identifier '{0}')")]
        public virtual void EventProcessorStopStart(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(12, identifier ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an exception was encountered while stop processing events.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the event processor.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(13, Level = EventLevel.Error, Message = "An exception occurred while balancing the load between processors. (Identifier '{0}'; Error Message: '{1}'")]
        public virtual void LoadBalancingTaskError(string identifier,
                                                   string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(13, identifier ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that processing of events has stopped.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the event processor.</param>
        ///
        [Event(14, Level = EventLevel.Verbose, Message = "Stopped processing events. (Identifier '{0}')")]
        public virtual void EventProcessorStopComplete(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(14, identifier ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that process of updating the checkpoint in the chosen storage service has started.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition.</param>
        ///
        [Event(15, Level = EventLevel.Informational, Message = "Process of updating checkpoint has started. (partitionId '{0}')")]
        public virtual void UpdateCheckpointStart(string partitionId)
        {
            if (IsEnabled())
            {
                WriteEvent(15, partitionId ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that process of updating the checkpoint in the chosen storage service has completed.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition.</param>
        ///
        [Event(16, Level = EventLevel.Verbose, Message = "Process of updating checkpoint has completed. (partitionId '{0}')")]
        public virtual void UpdateCheckpointComplete(string partitionId)
        {
            if (IsEnabled())
            {
                WriteEvent(16, partitionId ?? string.Empty);
            }
        }
    }
}
