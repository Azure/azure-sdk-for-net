// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.Tracing;
using Azure.Messaging.EventHubs.Diagnostics;

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
    internal class EventProcessorClientEventSource : OptimizationsBaseEventSource
    {
        /// <summary>The name to use for the event source.</summary>
        private const string EventSourceName = "Azure-Messaging-EventHubs-Processor-EventProcessorClient";

        /// <summary>
        ///   Provides a singleton instance of the event source for callers to
        ///   use for logging.
        /// </summary>
        ///
        public static EventProcessorClientEventSource Log { get; } = new EventProcessorClientEventSource();

        /// <summary>
        ///   Prevents an instance of the <see cref="EventProcessorClientEventSource" /> class from being created
        ///   outside the scope of this library.  Exposed for testing purposes only.
        /// </summary>
        ///
        protected EventProcessorClientEventSource() : base(EventSourceName)
        {
        }

        /// <summary>
        ///   Indicates that an <see cref="EventProcessorClient" /> has begin processing a batch of events for a partition.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition whose processing is taking place.</param>
        /// <param name="identifier">A unique name used to identify the event processor.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        /// <param name="consumerGroup">The name of the consumer group that the processor is associated with.</param>
        /// <param name="operationId">An identifier for the processing operation, allowing its activities to be correlated.</param>
        ///
        [Event(20, Level = EventLevel.Verbose, Message = "Starting to process a batch of events for partition '{0}' by processor instance with identifier '{1}' for Event Hub: {2} and Consumer Group: {3}.  Operation Id: '{4}'")]
        public virtual void EventBatchProcessingStart(string partitionId,
                                                      string identifier,
                                                      string eventHubName,
                                                      string consumerGroup,
                                                      string operationId)
        {
            if (IsEnabled())
            {
                WriteEvent(20, partitionId ?? string.Empty, identifier ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty, operationId ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventProcessorClient" /> instance has experienced an exception while processing a batch of events.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition whose processing is taking place.</param>
        /// <param name="identifier">A unique name used to identify the event processor.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        /// <param name="consumerGroup">The name of the consumer group that the processor is associated with.</param>
        /// <param name="operationId">An identifier for the processing operation, allowing its activities to be correlated.</param>
        ///
        [Event(21, Level = EventLevel.Verbose, Message = "Completed processing a batch of events for partition '{0}' by processor instance with identifier '{1}' for Event Hub: {2} and Consumer Group: {3}.  Operation Id: '{4}'")]
        public virtual void EventBatchProcessingComplete(string partitionId,
                                                         string identifier,
                                                         string eventHubName,
                                                         string consumerGroup,
                                                         string operationId)
        {
            if (IsEnabled())
            {
                WriteEvent(21, partitionId ?? string.Empty, identifier ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty, operationId ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventProcessorClient" /> has completed processing for a batch of events.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition whose processing is taking place.</param>
        /// <param name="identifier">A unique name used to identify the event processor.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        /// <param name="consumerGroup">The name of the consumer group that the processor is associated with.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        /// <param name="operationId">An identifier for the processing operation, allowing its activities to be correlated.</param>
        ///
        [Event(22, Level = EventLevel.Error, Message = "An exception occurred while processing events for partition '{0}' by processor instance with identifier '{1}' for Event Hub: {2} and Consumer Group: {3}.  Error Message: '{4}'; Operation Id: '{5}'")]
        public virtual void EventBatchProcessingError(string partitionId,
                                                      string identifier,
                                                      string eventHubName,
                                                      string consumerGroup,
                                                      string errorMessage,
                                                      string operationId)
        {
            if (IsEnabled())
            {
                WriteEvent(22, partitionId ?? string.Empty, identifier ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty, errorMessage ?? string.Empty, operationId ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that process of updating the checkpoint in the chosen storage service has started.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition whose processing is taking place.</param>
        /// <param name="identifier">A unique name used to identify the event processor.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        /// <param name="consumerGroup">The name of the consumer group that the processor is associated with.</param>
        /// <param name="sequenceNumber">The sequence number associated with the checkpoint being written.</param>
        /// <param name="offset">The offset associated with the checkpoint being written.</param>
        ///
        [Event(23, Level = EventLevel.Verbose, Message = "Starting to perform a checkpoint update for partition '{0}' by processor instance with identifier '{1}' for Event Hub: {2} and Consumer Group: {3} Sequence Number: {4} Offset {5}.")]
        public virtual void UpdateCheckpointStart(string partitionId,
                                                  string identifier,
                                                  string eventHubName,
                                                  string consumerGroup,
                                                  string sequenceNumber,
                                                  string offset)
        {
            if (IsEnabled())
            {
                WriteEvent(23, partitionId ?? string.Empty, identifier ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty, sequenceNumber ?? string.Empty, offset ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that process of updating the checkpoint in the chosen storage service has completed.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition whose processing is taking place.</param>
        /// <param name="identifier">A unique name used to identify the event processor.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        /// <param name="consumerGroup">The name of the consumer group that the processor is associated with.</param>
        /// <param name="sequenceNumber">The sequence number associated with the checkpoint being written.</param>
        /// <param name="offset">The offset associated with the checkpoint being written.</param>
        ///
        [Event(24, Level = EventLevel.Verbose, Message = "Completed performing a checkpoint update for partition '{0}' by processor instance with identifier '{1}' for Event Hub: {2} and Consumer Group: {3} Sequence Number: {4} Offset: {5}.")]
        public virtual void UpdateCheckpointComplete(string partitionId,
                                                     string identifier,
                                                     string eventHubName,
                                                     string consumerGroup,
                                                     string sequenceNumber,
                                                     string offset)
        {
            if (IsEnabled())
            {
                WriteEvent(24, partitionId ?? string.Empty, identifier ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty, sequenceNumber ?? string.Empty, offset ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that the process of updating the checkpoint in the chosen storage service has experienced an exception.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition whose processing is taking place.</param>
        /// <param name="identifier">A unique name used to identify the event processor.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        /// <param name="consumerGroup">The name of the consumer group that the processor is associated with.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        /// <param name="sequenceNumber">The sequence number associated with the checkpoint being written.</param>
        /// <param name="offset">The offset associated with the checkpoint being written.</param>
        ///
        [Event(25, Level = EventLevel.Error, Message = "An exception occurred while attempting to perform a checkpoint update for partition '{0}' by processor instance with identifier '{1}' for Event Hub: {2} and Consumer Group: {3}.  Error Message: '{4}. Sequence Number: {5} Offset: {6}'")]
        public virtual void UpdateCheckpointError(string partitionId,
                                                  string identifier,
                                                  string eventHubName,
                                                  string consumerGroup,
                                                  string errorMessage,
                                                  string sequenceNumber,
                                                  string offset)
        {
            if (IsEnabled())
            {
                WriteEvent(25, partitionId ?? string.Empty, identifier ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty, errorMessage ?? string.Empty, sequenceNumber ?? string.Empty, offset ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that the process of cleaning up after startup validation has experienced an exception.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the event processor.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        /// <param name="consumerGroup">The name of the consumer group that the processor is associated with.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(26, Level = EventLevel.Error, Message = "An exception occurred while attempting to perform cleanup after validating the processor configuration and permissions during startup for processor instance with identifier '{1}' for Event Hub: {2} and Consumer Group: {3}.  Error Message: '{4}'")]
        public virtual void ValidationCleanupError(string identifier,
                                                   string eventHubName,
                                                   string consumerGroup,
                                                   string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(26, identifier ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventProcessorClient" /> has begin processing a batch of events for a partition.
        /// </summary>
        ///
        /// <param name="sequenceNumber">The sequence number of the event being passed to the handler for processing.</param>
        /// <param name="partitionId">The identifier of the Event Hub partition whose processing is taking place.</param>
        /// <param name="identifier">A unique name used to identify the event processor.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        /// <param name="consumerGroup">The name of the consumer group that the processor is associated with.</param>
        /// <param name="operationId">An identifier for the processing operation, allowing its activities to be correlated.</param>
        ///
        [Event(27, Level = EventLevel.Verbose, Message = "Invoking the event processing handler for sequence number '{0}'.  Partition '{1}'; Processor Identifier '{2}'; Event Hub: {3}; Consumer Group: {4}; Operation Id: '{5}'")]
        public virtual void EventBatchProcessingHandlerCall(string sequenceNumber,
                                                            string partitionId,
                                                            string identifier,
                                                            string eventHubName,
                                                            string consumerGroup,
                                                            string operationId)
        {
            if (IsEnabled())
            {
                WriteEvent(27, sequenceNumber ?? string.Empty, partitionId ?? string.Empty, identifier ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty, operationId ?? string.Empty);
            }
        }
    }
}
