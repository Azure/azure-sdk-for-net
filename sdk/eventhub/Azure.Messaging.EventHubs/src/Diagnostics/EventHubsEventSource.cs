// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;
using Azure.Core.Diagnostics;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Primitives;
using Azure.Messaging.EventHubs.Producer;

namespace Azure.Messaging.EventHubs.Diagnostics
{
    /// <summary>
    ///   Serves as an ETW event source for logging of information about the
    ///   Event Hubs client types.
    /// </summary>
    ///
    /// <remarks>
    ///   When defining Start/Stop tasks, it is highly recommended that the
    ///   the StopEvent.Id must be exactly StartEvent.Id + 1.
    /// </remarks>
    ///
    [EventSource(Name = EventSourceName)]
    internal class EventHubsEventSource : AzureEventSource
    {
        /// <summary>The name to use for the event source.</summary>
        private const string EventSourceName = "Azure-Messaging-EventHubs";

        /// <summary>
        ///   Provides a singleton instance of the event source for callers to
        ///   use for logging.
        /// </summary>
        ///
        public static EventHubsEventSource Log { get; } = new EventHubsEventSource();

        /// <summary>
        ///   Prevents an instance of the <see cref="EventHubsEventSource"/> class from being created
        ///   outside the scope of the <see cref="Log" /> instance.
        /// </summary>
        ///
        protected EventHubsEventSource() : base(EventSourceName)
        {
        }

        /// <summary>
        ///   Indicates that an <see cref="EventHubConnection" /> is being created.
        /// </summary>
        ///
        /// <param name="eventHubsNamespace">The Event Hubs namespace associated with the client.</param>
        /// <param name="eventHubName">The name of the Event Hub associated with the client.</param>
        ///
        [Event(1, Level = EventLevel.Verbose, Message = "Creating EventHubClient (Namespace '{0}'; EventHub '{1}').")]
        public virtual void EventHubClientCreateStart(string eventHubsNamespace,
                                                      string eventHubName)
        {
            if (IsEnabled())
            {
                WriteEvent(1, eventHubsNamespace ?? string.Empty, eventHubName ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventHubConnection" /> was created.
        /// </summary>
        ///
        /// <param name="eventHubsNamespace">The Event Hubs namespace associated with the client.</param>
        /// <param name="eventHubName">The name of the Event Hub associated with the client.</param>
        ///
        [Event(2, Level = EventLevel.Verbose, Message = "EventHubClient created (Namespace '{0}'; EventHub '{1}').")]
        public virtual void EventHubClientCreateComplete(string eventHubsNamespace,
                                                         string eventHubName)
        {
            if (IsEnabled())
            {
                WriteEvent(2, eventHubsNamespace ?? string.Empty, eventHubName ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that the publishing of events has started.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub being published to.</param>
        /// <param name="partitionIdOrKey">The identifier of a partition or the partition hash key used for publishing; identifier or key.</param>
        /// <param name="operationId">An artificial identifier for the publishing operation.</param>
        ///
        [Event(3, Level = EventLevel.Informational, Message = "Publishing events for Event Hub: {0} (Partition Id/Key: '{1}'), Operation Id: '{2}'.")]
        public virtual void EventPublishStart(string eventHubName,
                                              string partitionIdOrKey,
                                              string operationId)
        {
            if (IsEnabled())
            {
                WriteEvent(3, eventHubName ?? string.Empty, partitionIdOrKey ?? string.Empty, operationId ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that the publishing of events has completed.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub being published to.</param>
        /// <param name="partitionIdOrKey">The identifier of a partition or the partition hash key used for publishing; identifier or key.</param>
        /// <param name="operationId">An artificial identifier for the publishing operation.</param>
        /// <param name="retryCount">The number of retries that were used for service communication.</param>
        ///
        [Event(4, Level = EventLevel.Informational, Message = "Completed publishing events for Event Hub: {0} (Partition Id/Key: '{1}'), Operation Id: '{2}'.  Service Retry Count: {3}.")]
        public virtual void EventPublishComplete(string eventHubName,
                                                 string partitionIdOrKey,
                                                 string operationId,
                                                 int retryCount)
        {
            if (IsEnabled())
            {
                WriteEvent(4, eventHubName ?? string.Empty, partitionIdOrKey ?? string.Empty, operationId ?? string.Empty, retryCount);
            }
        }

        /// <summary>
        ///   Indicates that an exception was encountered while publishing events.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub being published to.</param>
        /// <param name="partitionIdOrKey">The identifier of a partition or the partition hash key used for publishing; identifier or key.</param>
        /// <param name="operationId">An artificial identifier for the publishing operation.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(5, Level = EventLevel.Error, Message = "An exception occurred while publishing events for Event Hub: {0} (Partition Id/Key: '{1}'), Operation Id: '{2}'. Error Message: '{3}'")]
        public virtual void EventPublishError(string eventHubName,
                                              string partitionIdOrKey,
                                              string operationId,
                                              string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(5, eventHubName ?? string.Empty, partitionIdOrKey ?? string.Empty, operationId ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that the receiving of events has started.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub being received from.</param>
        /// <param name="consumerGroup">The consumer group associated with the receive operation.</param>
        /// <param name="partitionId">The identifier of the partition events are being received from.</param>
        /// <param name="operationId">An artificial identifier for the publishing operation.</param>
        ///
        [Event(6, Level = EventLevel.Informational, Message = "Receiving events for Event Hub: {0} (Consumer Group: '{1}', Partition Id: '{2}'); Operation Id: '{3}'.")]
        public virtual void EventReceiveStart(string eventHubName,
                                              string consumerGroup,
                                              string partitionId,
                                              string operationId)
        {
            if (IsEnabled())
            {
                WriteEvent(6, eventHubName ?? string.Empty, consumerGroup ?? string.Empty, partitionId ?? string.Empty, operationId ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that the receiving of events has completed.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub being received from.</param>
        /// <param name="partitionId">The identifier of the partition events are being received from.</param>
        /// <param name="consumerGroup">The consumer group associated with the receive operation.</param>
        /// <param name="operationId">An artificial identifier for the publishing operation.</param>
        /// <param name="retryCount">The number of retries that were used for service communication.</param>
        /// <param name="eventCount">The number of events that were received in the batch.</param>
        ///
        [Event(7, Level = EventLevel.Informational, Message = "Completed receiving events for Event Hub: {0} (Consumer Group: '{1}', Partition Id: '{2}'); Operation Id: '{3}'.  Service Retry Count: {4}; Event Count: {5}")]
        public virtual void EventReceiveComplete(string eventHubName,
                                                 string consumerGroup,
                                                 string partitionId,
                                                 string operationId,
                                                 int retryCount,
                                                 int eventCount)
        {
            if (IsEnabled())
            {
                WriteEvent(7, eventHubName ?? string.Empty, consumerGroup ?? string.Empty, partitionId ?? string.Empty, operationId ?? string.Empty, retryCount, eventCount);
            }
        }

        /// <summary>
        ///   Indicates that an exception was encountered while receiving events.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub being received from.</param>
        /// <param name="partitionId">The identifier of the partition events are being received from.</param>
        /// <param name="consumerGroup">The consumer group associated with the receive operation.</param>
        /// <param name="operationId">An artificial identifier for the publishing operation.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(8, Level = EventLevel.Error, Message = "An exception occurred while receiving events for Event Hub: {0} (Consumer Group: '{1}', Partition Id: '{2}'); Operation Id: '{3}'. Error Message: '{4}'")]
        public virtual void EventReceiveError(string eventHubName,
                                              string consumerGroup,
                                              string partitionId,
                                              string operationId,
                                              string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(8, eventHubName ?? string.Empty, consumerGroup ?? string.Empty, partitionId ?? string.Empty, operationId ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that a client is closing, which may correspond to an <see cref="EventHubConnection" />,
        ///   <see cref="EventHubProducerClient" />, <see cref="EventHubConsumerClient" />, or <c>EventProcessorClient</c>.
        /// </summary>
        ///
        /// <param name="clientTypeName">The name of the type of client being closed.</param>
        /// <param name="eventHubName">The name of the Event Hub associated with the client.</param>
        /// <param name="clientId">An identifier to associate with the client.</param>
        ///
        [Event(9, Level = EventLevel.Verbose, Message = "Closing an {0} (EventHub '{1}'; Identifier '{2}').")]
        public virtual void ClientCloseStart(string clientTypeName,
                                             string eventHubName,
                                             string clientId)
        {
            if (IsEnabled())
            {
                WriteEvent(9, clientTypeName ?? string.Empty, eventHubName ?? string.Empty, clientId ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that a client has been closed, which may correspond to an <see cref="EventHubConnection" />,
        ///   <see cref="EventHubProducerClient" />, <see cref="EventHubConsumerClient" />, or <c>EventProcessorClient</c>.
        /// </summary>
        ///
        /// <param name="clientTypeName">The name of the type of client being closed.</param>
        /// <param name="eventHubName">The name of the Event Hub associated with the client.</param>
        /// <param name="clientId">An identifier to associate with the client.</param>
        ///
        [Event(10, Level = EventLevel.Verbose, Message = "An {0} has been closed (EventHub '{1}'; Identifier '{2}').")]
        public virtual void ClientCloseComplete(string clientTypeName,
                                                string eventHubName,
                                                string clientId)
        {
            if (IsEnabled())
            {
                WriteEvent(10, clientTypeName ?? string.Empty, eventHubName ?? string.Empty, clientId ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an exception was encountered while closing an <see cref="EventHubConnection" />,
        ///   <see cref="EventHubProducerClient" />, <see cref="EventHubConsumerClient" />, or <c>EventProcessorClient</c>.
        /// </summary>
        ///
        /// <param name="clientTypeName">The name of the type of client being closed.</param>
        /// <param name="eventHubName">The name of the Event Hub associated with the client.</param>
        /// <param name="clientId">An identifier to associate with the client.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(11, Level = EventLevel.Error, Message = "An exception occurred while closing an {0} (EventHub '{1}'; Identifier '{2}'). Error Message: '{3}'")]
        public virtual void ClientCloseError(string clientTypeName,
                                             string eventHubName,
                                             string clientId,
                                             string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(11, clientTypeName ?? string.Empty, eventHubName ?? string.Empty, clientId ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that retrieval of the Event Hub properties has started.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub that properties are being retrieved for.</param>
        ///
        [Event(12, Level = EventLevel.Informational, Message = "Retrieving properties for Event Hub: {0}.")]
        public virtual void GetPropertiesStart(string eventHubName)
        {
            if (IsEnabled())
            {
                WriteEvent(12, eventHubName ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that retrieval of the Event Hub properties has completed.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub that properties are being retrieved for.</param>
        ///
        [Event(13, Level = EventLevel.Informational, Message = "Completed retrieving properties for Event Hub: {0}.")]
        public virtual void GetPropertiesComplete(string eventHubName)
        {
            if (IsEnabled())
            {
                WriteEvent(13, eventHubName ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an exception was encountered while retrieving Event Hub properties.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub that properties are being retrieved for.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(14, Level = EventLevel.Error, Message = "An exception occurred while retrieving properties for Event Hub: {0}. Error Message: '{1}'")]
        public virtual void GetPropertiesError(string eventHubName,
                                               string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(14, eventHubName ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that retrieval of the Event Hub partition properties has started.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub that properties are being retrieved for.</param>
        /// <param name="partitionId">The identifier of the partition that properties are being retrieved for.</param>
        ///
        [Event(15, Level = EventLevel.Informational, Message = "Retrieving properties for Event Hub: {0} (Partition Id: '{1}').")]
        public virtual void GetPartitionPropertiesStart(string eventHubName,
                                                        string partitionId)
        {
            if (IsEnabled())
            {
                WriteEvent(15, eventHubName ?? string.Empty, partitionId ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that retrieval of the Event Hub partition properties has completed.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub that properties are being retrieved for.</param>
        /// <param name="partitionId">The identifier of the partition that properties are being retrieved for.</param>
        ///
        [Event(16, Level = EventLevel.Informational, Message = "Completed retrieving properties for Event Hub: {0} (Partition Id: '{1}').")]
        public virtual void GetPartitionPropertiesComplete(string eventHubName,
                                                           string partitionId)
        {
            if (IsEnabled())
            {
                WriteEvent(16, eventHubName ?? string.Empty, partitionId ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an exception was encountered while retrieving Event Hub partition properties.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub that properties are being retrieved for.</param>
        /// <param name="partitionId">The identifier of the partition that properties are being retrieved for.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(17, Level = EventLevel.Error, Message = "An exception occurred while retrieving properties for Event Hub: {0} (Partition Id: '{1}'). Error Message: '{2}'")]
        public virtual void GetPartitionPropertiesError(string eventHubName,
                                                        string partitionId,
                                                        string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(17, eventHubName ?? string.Empty, partitionId ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that reading events from an Event Hub partition has started.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub that events are being read from.</param>
        /// <param name="partitionId">The identifier of the partition that properties are being read from.</param>
        ///
        [Event(18, Level = EventLevel.Informational, Message = "Beginning to publish events to a background channel for Event Hub: {0} (Partition Id: '{1}').")]
        public virtual void PublishPartitionEventsToChannelStart(string eventHubName,
                                                                 string partitionId)
        {
            if (IsEnabled())
            {
                WriteEvent(18, eventHubName ?? string.Empty, partitionId ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that reading events from an Event Hub partition has completed.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub that events are being read from.</param>
        /// <param name="partitionId">The identifier of the partition that properties are being read from.</param>
        ///
        [Event(19, Level = EventLevel.Informational, Message = "Completed publishing events to a background channel for Event Hub: {0} (Partition Id: '{1}').")]
        public virtual void PublishPartitionEventsToChannelComplete(string eventHubName,
                                                                    string partitionId)
        {
            if (IsEnabled())
            {
                WriteEvent(19, eventHubName ?? string.Empty, partitionId ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an exception was encountered while reading events from an Event Hub partition.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub that events are being read from.</param>
        /// <param name="partitionId">The identifier of the partition that properties are being read from.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(20, Level = EventLevel.Error, Message = "An exception occurred while publishing events to a background channel for Event Hub: {0} (Partition Id: '{1}'). Error Message: '{2}'")]
        public virtual void PublishPartitionEventsToChannelError(string eventHubName,
                                                                 string partitionId,
                                                                 string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(20, eventHubName ?? string.Empty, partitionId ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that reading events from an Event Hub partition has started.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub that events are being read from.</param>
        /// <param name="partitionId">The identifier of the partition that properties are being read from.</param>
        ///
        [Event(21, Level = EventLevel.Informational, Message = "Beginning to read events for Event Hub: {0} (Partition Id: '{1}').")]
        public virtual void ReadEventsFromPartitionStart(string eventHubName,
                                                         string partitionId)
        {
            if (IsEnabled())
            {
                WriteEvent(21, eventHubName ?? string.Empty, partitionId ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that reading events from an Event Hub partition has completed.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub that events are being read from.</param>
        /// <param name="partitionId">The identifier of the partition that properties are being read from.</param>
        ///
        [Event(22, Level = EventLevel.Informational, Message = "Completed reading events for Event Hub: {0} (Partition Id: '{1}').")]
        public virtual void ReadEventsFromPartitionComplete(string eventHubName,
                                                            string partitionId)
        {
            if (IsEnabled())
            {
                WriteEvent(22, eventHubName ?? string.Empty, partitionId ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an exception was encountered while reading events from an Event Hub partition.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub that events are being read from.</param>
        /// <param name="partitionId">The identifier of the partition that properties are being read from.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(23, Level = EventLevel.Error, Message = "An exception occurred while reading events for Event Hub: {0} (Partition Id: '{1}'). Error Message: '{2}'")]
        public virtual void ReadEventsFromPartitionError(string eventHubName,
                                                         string partitionId,
                                                         string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(23, eventHubName ?? string.Empty, partitionId ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that reading events from all partitions of the Event Hub has started.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub that events are being read from.</param>
        ///
        [Event(24, Level = EventLevel.Informational, Message = "Beginning to read events for all partitions of Event Hub: {0}.")]
        public virtual void ReadAllEventsStart(string eventHubName)
        {
            if (IsEnabled())
            {
                WriteEvent(24, eventHubName ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that reading events from all partitions of the Event Hub has completed.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub that events are being read from.</param>
        ///
        [Event(25, Level = EventLevel.Informational, Message = "Completed reading events for all partitions of Event Hub: {0}.")]
        public virtual void ReadAllEventsComplete(string eventHubName)
        {
            if (IsEnabled())
            {
                WriteEvent(25, eventHubName ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an exception was encountered while reading events from all partitions of the Event Hub.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub that events are being read from.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(26, Level = EventLevel.Error, Message = "An exception occurred while reading events for all partitions of Event Hub: {0}. Error Message: '{1}'")]
        public virtual void ReadAllEventsError(string eventHubName,
                                               string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(26, eventHubName ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that refreshing authorization for an AMQP link has started.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub that the link is associated with.</param>
        /// <param name="endpoint">The service endpoint that the link is bound to for communication.</param>
        ///
        [Event(27, Level = EventLevel.Informational, Message = "Beginning refresh of AMQP link authorization for Event Hub: {0} (Service Endpoint: '{1}').")]
        public virtual void AmqpLinkAuthorizationRefreshStart(string eventHubName,
                                                              string endpoint)
        {
            if (IsEnabled())
            {
                WriteEvent(27, eventHubName ?? string.Empty, endpoint ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that refreshing authorization for an AMQP link has completed.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub that the link is associated with.</param>
        /// <param name="endpoint">The service endpoint that the link is bound to for communication.</param>
        ///
        [Event(28, Level = EventLevel.Informational, Message = "Completed refresh of AMQP link authorization for Event Hub: {0} (Service Endpoint: '{1}').")]
        public virtual void AmqpLinkAuthorizationRefreshComplete(string eventHubName,
                                                                 string endpoint)
        {
            if (IsEnabled())
            {
                WriteEvent(28, eventHubName ?? string.Empty, endpoint ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an exception was encountered while refreshing authorization for an AMQP link has started.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub that the link is associated with.</param>
        /// <param name="endpoint">The service endpoint that the link is bound to for communication.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(29, Level = EventLevel.Error, Message = "An exception occurred while refreshing AMQP link authorization for Event Hub: {0} (Service Endpoint: '{1}'). Error Message: '{2}'")]
        public virtual void AmqpLinkAuthorizationRefreshError(string eventHubName,
                                                              string endpoint,
                                                              string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(29, eventHubName ?? string.Empty, endpoint ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventProcessor{TPartition}" /> instance is about to begin processing events.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the event processor.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        /// <param name="consumerGroup">The name of the consumer group that the processor is associated with.</param>
        ///
        [Event(30, Level = EventLevel.Informational, Message = "Starting a new event processor instance with identifier '{0}' for Event Hub: {1} and Consumer Group: {2}.")]
        public virtual void EventProcessorStart(string identifier,
                                                string eventHubName,
                                                string consumerGroup)
        {
            if (IsEnabled())
            {
                WriteEvent(30, identifier ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventProcessor{TPartition}" /> instance is about to begin processing events.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the event processor.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        /// <param name="consumerGroup">The name of the consumer group that the processor is associated with.</param>
        ///
        [Event(31, Level = EventLevel.Informational, Message = "The new event processor instance with identifier '{0}' for Event Hub: {1} and Consumer Group: {2} has completed starting.")]
        public virtual void EventProcessorStartComplete(string identifier,
                                                        string eventHubName,
                                                        string consumerGroup)
        {
            if (IsEnabled())
            {
                WriteEvent(31, identifier ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventProcessor{TPartition}" /> instance has encountered an exception while starting to process events.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the event processor.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        /// <param name="consumerGroup">The name of the consumer group that the processor is associated with.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(32, Level = EventLevel.Error, Message = "An exception occurred while starting a new event processor instance with identifier '{0}' for Event Hub: {1} and Consumer Group: {2}.  Error Message: '{3}'")]
        public virtual void EventProcessorStartError(string identifier,
                                                     string eventHubName,
                                                     string consumerGroup,
                                                     string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(32, identifier ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventProcessor{TPartition}" /> instance is beginning to stop processing events.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the event processor.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        /// <param name="consumerGroup">The name of the consumer group that the processor is associated with.</param>
        ///
        [Event(33, Level = EventLevel.Informational, Message = "The event processor instance with identifier '{0}' for Event Hub: {1} and Consumer Group: {2} is beginning to shut down.")]
        public virtual void EventProcessorStop(string identifier,
                                               string eventHubName,
                                               string consumerGroup)
        {
            if (IsEnabled())
            {
                WriteEvent(33, identifier ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventProcessor{TPartition}" /> instance has been stopped and is no longer processing events.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the event processor.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        /// <param name="consumerGroup">The name of the consumer group that the processor is associated with.</param>
        ///
        [Event(34, Level = EventLevel.Informational, Message = "The event processor instance with identifier '{0}' for Event Hub: {1} and Consumer Group: {2} has completed shutting down.")]
        public virtual void EventProcessorStopComplete(string identifier,
                                                       string eventHubName,
                                                       string consumerGroup)
        {
            if (IsEnabled())
            {
                WriteEvent(34, identifier ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventProcessor{TPartition}" /> instance has encountered an exception while stopping.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the event processor.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        /// <param name="consumerGroup">The name of the consumer group that the processor is associated with.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(35, Level = EventLevel.Error, Message = "An exception occurred while stopping the event processor instance with identifier '{0}' for Event Hub: {1} and Consumer Group: {2}.  Error Message: '{3}'")]
        public virtual void EventProcessorStopError(string identifier,
                                                    string eventHubName,
                                                    string consumerGroup,
                                                    string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(35, identifier ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventProcessor{TPartition}" /> instance has encountered an error during processing or load balancing.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the event processor.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        /// <param name="consumerGroup">The name of the consumer group that the processor is associated with.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(36, Level = EventLevel.Error, Message = "An exception occurred during partition processing or load balancing for processor instance with identifier '{0}' for Event Hub: {1} and Consumer Group: {2}.  Error Message: '{3}'")]
        public virtual void EventProcessorTaskError(string identifier,
                                                    string eventHubName,
                                                    string consumerGroup,
                                                    string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(36, identifier ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventProcessor{TPartition}" /> instance has taken ownership of a partition and is beginning to process it.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition whose processing is starting.</param>
        /// <param name="identifier">A unique name used to identify the event processor.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        /// <param name="consumerGroup">The name of the consumer group that the processor is associated with.</param>
        ///
        [Event(37, Level = EventLevel.Verbose, Message = "Starting to process partition '{0}' using processor instance with identifier '{1}' for Event Hub: {2} and Consumer Group: {3}.")]
        public virtual void EventProcessorPartitionProcessingStart(string partitionId,
                                                                   string identifier,
                                                                   string eventHubName,
                                                                   string consumerGroup)
        {
            if (IsEnabled())
            {
                WriteEvent(37, partitionId ?? string.Empty, identifier ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventProcessor{TPartition}" /> instance has experienced an exception while starting processing for a partition.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition whose processing is starting.</param>
        /// <param name="identifier">A unique name used to identify the event processor.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        /// <param name="consumerGroup">The name of the consumer group that the processor is associated with.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(38, Level = EventLevel.Error, Message = "An exception occurred while starting to process partition '{0}' using processor instance with identifier '{1}' for Event Hub: {2} and Consumer Group: {3}.  Error Message: '{4}'")]
        public virtual void EventProcessorPartitionProcessingStartError(string partitionId,
                                                                        string identifier,
                                                                        string eventHubName,
                                                                        string consumerGroup,
                                                                        string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(38, partitionId ?? string.Empty, identifier ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventProcessor{TPartition}" /> instance has taken ownership of a partition and is actively processing it.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition whose processing is starting.</param>
        /// <param name="identifier">A unique name used to identify the event processor.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        /// <param name="consumerGroup">The name of the consumer group that the processor is associated with.</param>
        ///
        [Event(39, Level = EventLevel.Verbose, Message = "Completed starting to process partition '{0}' using processor instance with identifier '{1}' for Event Hub: {2} and Consumer Group: {3}.")]
        public virtual void EventProcessorPartitionProcessingStartComplete(string partitionId,
                                                                           string identifier,
                                                                           string eventHubName,
                                                                           string consumerGroup)
        {
            if (IsEnabled())
            {
                WriteEvent(39, partitionId ?? string.Empty, identifier ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventProcessor{TPartition}" /> instance has lost ownership of a partition and is beginning to stop processing it.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition whose processing is stopping.</param>
        /// <param name="identifier">A unique name used to identify the event processor.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        /// <param name="consumerGroup">The name of the consumer group that the processor is associated with.</param>
        ///
        [Event(40, Level = EventLevel.Verbose, Message = "Stopping processing for partition '{0}' by processor instance with identifier '{1}' for Event Hub: {2} and Consumer Group: {3}.")]
        public virtual void EventProcessorPartitionProcessingStop(string partitionId,
                                                                  string identifier,
                                                                  string eventHubName,
                                                                  string consumerGroup)
        {
            if (IsEnabled())
            {
                WriteEvent(40, partitionId ?? string.Empty, identifier ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventProcessor{TPartition}" /> instance has experienced an exception while stopping processing for a partition.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition whose processing is stopping.</param>
        /// <param name="identifier">A unique name used to identify the event processor.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        /// <param name="consumerGroup">The name of the consumer group that the processor is associated with.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(41, Level = EventLevel.Error, Message = "An exception occurred while stopping processing for partition '{0}' by processor instance with identifier '{1}' for Event Hub: {2} and Consumer Group: {3}.  Error Message: '{4}'")]
        public virtual void EventProcessorPartitionProcessingStopError(string partitionId,
                                                                       string identifier,
                                                                       string eventHubName,
                                                                       string consumerGroup,
                                                                       string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(41, partitionId ?? string.Empty, identifier ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventProcessor{TPartition}" /> instance has finished stopping processing for a partition, and it is now no longer running.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition whose processing is stopping.</param>
        /// <param name="identifier">A unique name used to identify the event processor.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        /// <param name="consumerGroup">The name of the consumer group that the processor is associated with.</param>
        ///
        [Event(42, Level = EventLevel.Verbose, Message = "Completed stopping processing for partition '{0}' by processor instance with identifier '{1}' for Event Hub: {2} and Consumer Group: {3}.")]
        public virtual void EventProcessorPartitionProcessingStopComplete(string partitionId,
                                                                          string identifier,
                                                                          string eventHubName,
                                                                          string consumerGroup)
        {
            if (IsEnabled())
            {
                WriteEvent(42, partitionId ?? string.Empty, identifier ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventProcessor{TPartition}" /> instance has experienced an exception while processing events for a partition.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition whose processing is taking place.</param>
        /// <param name="identifier">A unique name used to identify the event processor.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        /// <param name="consumerGroup">The name of the consumer group that the processor is associated with.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(43, Level = EventLevel.Error, Message = "An exception occurred while processing events for partition '{0}' by processor instance with identifier '{1}' for Event Hub: {2} and Consumer Group: {3}.  Error Message: '{4}'")]
        public virtual void EventProcessorPartitionProcessingError(string partitionId,
                                                                   string identifier,
                                                                   string eventHubName,
                                                                   string consumerGroup,
                                                                   string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(43, partitionId ?? string.Empty, identifier ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventProcessor{TPartition}" /> instance has experienced an exception while performing load balancing.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the event processor.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        /// <param name="consumerGroup">The name of the consumer group that the processor is associated with.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(44, Level = EventLevel.Error, Message = "An exception occurred while performing load balancing for the processor instance with identifier '{0}' for Event Hub: {1} and Consumer Group: {2}.  Error Message: '{3}'")]
        public virtual void EventProcessorLoadBalancingError(string identifier,
                                                             string eventHubName,
                                                             string consumerGroup,
                                                             string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(44, identifier ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventProcessor{TPartition}" /> instance has experienced an exception while attempting to claim ownership of a partition.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the event processor.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        /// <param name="consumerGroup">The name of the consumer group that the processor is associated with.</param>
        /// <param name="partitionId">The identifier of the partition for which the attempt to claim ownership failed.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(45, Level = EventLevel.Error, Message = "An exception occurred while attempting to claim partition ownership for the processor instance with identifier '{0}' for Event Hub: {1}, Consumer Group: {2}, and partition: {3}.  Error Message: '{4}'")]
        public virtual void EventProcessorClaimOwnershipError(string identifier,
                                                              string eventHubName,
                                                              string consumerGroup,
                                                              string partitionId,
                                                              string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(45, identifier ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty, partitionId ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that the idempotent publishing of events has started.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub being published to.</param>
        /// <param name="partitionId">The identifier of a partition used for idempotent publishing.</param>
        ///
        [Event(46, Level = EventLevel.Informational, Message = "Impotently publishing events for Event Hub: {0} (Partition Id: '{1}').")]
        public virtual void IdempotentPublishStart(string eventHubName,
                                                   string partitionId)
        {
            if (IsEnabled())
            {
                WriteEvent(46, eventHubName ?? string.Empty, partitionId ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that the idempotent publishing of events has acquired the synchronization primitive.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub being published to.</param>
        /// <param name="partitionId">The identifier of a partition used for idempotent publishing.</param>
        ///
        [Event(47, Level = EventLevel.Verbose, Message = "Impotently publishing for Event Hub: {0} (Partition Id: '{1}') has acquired the partition synchronization primitive.")]
        public virtual void IdempotentSynchronizationAcquire(string eventHubName,
                                                             string partitionId)
        {
            if (IsEnabled())
            {
                WriteEvent(47, eventHubName ?? string.Empty, partitionId ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that the idempotent publishing of events has released the synchronization primitive.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub being published to.</param>
        /// <param name="partitionId">The identifier of a partition used for idempotent publishing.</param>
        ///
        [Event(48, Level = EventLevel.Verbose, Message = "Impotently publishing for Event Hub: {0} (Partition Id: '{1}') has released the partition synchronization primitive.")]
        public virtual void IdempotentSynchronizationRelease(string eventHubName,
                                                             string partitionId)
        {
            if (IsEnabled())
            {
                WriteEvent(48, eventHubName ?? string.Empty, partitionId ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that the idempotent publishing of events has released the synchronization primitive.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub being published to.</param>
        /// <param name="partitionId">The identifier of a partition used for idempotent publishing.</param>
        /// <param name="startSequenceNumber">The starting sequence number used for publishing.</param>
        /// <param name="endSequenceNumber">The ending sequence number of partition state used for publishing.</param>
        ///
        [Event(49, Level = EventLevel.Verbose, Message = "Impotently publishing for Event Hub: {0} (Partition Id: '{1}') is publishing events with the sequence number range from '{2}` to '{3}'.")]
        public virtual void IdempotentSequencePublish(string eventHubName,
                                                      string partitionId,
                                                      long startSequenceNumber,
                                                      long endSequenceNumber)
        {
            if (IsEnabled())
            {
                WriteEvent(49, eventHubName ?? string.Empty, partitionId ?? string.Empty, startSequenceNumber, endSequenceNumber);
            }
        }

        /// <summary>
        ///   Indicates that the idempotent publishing of events has released the synchronization primitive.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub being published to.</param>
        /// <param name="partitionId">The identifier of a partition used for idempotent publishing.</param>
        /// <param name="oldSequenceNumber">The sequence number of partition state before the update.</param>
        /// <param name="newSequenceNumber">The sequence number of partition state after the update.</param>
        ///
        [Event(50, Level = EventLevel.Verbose, Message = "Impotently publishing for Event Hub: {0} (Partition Id: '{1}') has updated the tracked sequence number from '{2}` to '{3}'.")]
        public virtual void IdempotentSequenceUpdate(string eventHubName,
                                                     string partitionId,
                                                     long oldSequenceNumber,
                                                     long newSequenceNumber)
        {
            if (IsEnabled())
            {
                WriteEvent(50, eventHubName ?? string.Empty, partitionId ?? string.Empty, oldSequenceNumber, newSequenceNumber);
            }
        }

        /// <summary>
        ///   Indicates that the idempotent publishing of events has completed.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub being published to.</param>
        /// <param name="partitionId">The identifier of a partition used for idempotent publishing.</param>
        ///
        [Event(51, Level = EventLevel.Informational, Message = "Completed idempotent publishing events for Event Hub: {0} (Partition Id: '{1}').")]
        public virtual void IdempotentPublishComplete(string eventHubName,
                                                      string partitionId)
        {
            if (IsEnabled())
            {
                WriteEvent(51, eventHubName ?? string.Empty, partitionId ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an exception was encountered while idempotent publishing events.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub being published to.</param>
        /// <param name="partitionId">The identifier of a partition used for idempotent publishing.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(52, Level = EventLevel.Error, Message = "An exception occurred while idempotent publishing events for Event Hub: {0} (Partition Id: '{1}'). Error Message: '{2}'")]
        public virtual void IdempotentPublishError(string eventHubName,
                                                   string partitionId,
                                                   string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(52, eventHubName ?? string.Empty, partitionId ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that the idempotent publishing state for a partition has been initialized.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub being published to.</param>
        /// <param name="partitionId">The identifier of a partition used for idempotent publishing.</param>
        /// <param name="producerGroupId">The identifier of the producer group associated with the partition.</param>
        /// <param name="ownerLevel">The owner level associated with the partition.</param>
        /// <param name="lastPublishedSequence">The sequence number last published to the partition for the producer group.</param>
        ///
        [Event(53, Level = EventLevel.Informational, Message = "Initializing idempotent publishing state for Event Hub: {0} (Partition Id: '{1}'). Producer Group Id: '{2}', Owner Level: '{3}', Last Published Sequence: '{4}'.")]
        public virtual void IdempotentPublishInitializeState(string eventHubName,
                                                             string partitionId,
                                                             long producerGroupId,
                                                             short ownerLevel,
                                                             long lastPublishedSequence)
        {
            if (IsEnabled())
            {
                WriteEvent(53, eventHubName ?? string.Empty, partitionId ?? string.Empty, producerGroupId, ownerLevel, lastPublishedSequence);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventProcessor{TPartition}" /> instance has closed the transport consumer in response
        ///   to a stop request and a receive operation was aborted.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition whose processing is stopping.</param>
        /// <param name="identifier">A unique name used to identify the event processor.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        /// <param name="consumerGroup">The name of the consumer group that the processor is associated with.</param>
        ///
        [Event(54, Level = EventLevel.Verbose, Message = "Event Processor successfully closed the transport consumer when stopping processing for partition '{0}' by processor instance with identifier '{1}' for Event Hub: {2} and Consumer Group: {3}.")]
        public virtual void EventProcessorPartitionProcessingStopConsumerClose(string partitionId,
                                                                               string identifier,
                                                                               string eventHubName,
                                                                               string consumerGroup)
        {
            if (IsEnabled())
            {
                WriteEvent(54, partitionId ?? string.Empty, identifier ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an AMQP object was closed by the <c>FaultTolerantAmqpObject&lt;T&gt;</c> instance that manages it.
        /// </summary>
        ///
        /// <param name="objectTypeName">The name of the AMQP object type being managed; normally this will be a type of AMQP link.</param>
        /// <param name="identifier">The identifier of the client associated with the AMQP object.</param>
        /// <param name="eventHubName">The name of the Event Hub that the AMQP object is associated with.</param>
        /// <param name="consumerGroup">The name of the consumer group that the AMQP object is associated with.</param>
        /// <param name="partitionId">The identifier of the partition that the AMQP object is associated with.</param>
        /// <param name="errorMessage">The message for any terminal exception that may have occurred.</param>
        ///
        [Event(55, Level = EventLevel.Verbose, Message = "An AMQP object of type '{0}' was closed by the fault tolerant manager for client: '{1}', Event Hub: {2}, Consumer Group: {3}, and partition: {4}.  Terminal error message: '{5}'")]
        public virtual void FaultTolerantAmqpObjectClose(string objectTypeName,
                                                         string identifier,
                                                         string eventHubName,
                                                         string consumerGroup,
                                                         string partitionId,
                                                         string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(55, objectTypeName ?? string.Empty, identifier ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty, partitionId ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that creating an AMQP connection has started.
        /// </summary>
        ///
        /// <param name="endpoint">The service endpoint that the connection is being opened for.</param>
        /// <param name="transportType">The type of transport being used for the connection</param>
        ///
        [Event(56, Level = EventLevel.Verbose, Message = "Beginning creation of an AMQP connection for endpoint: '{0}' using the transport: '{1}`.")]
        public virtual void AmqpConnectionCreateStart(string endpoint,
                                                      string transportType)
        {
            if (IsEnabled())
            {
                WriteEvent(56, endpoint ?? string.Empty, transportType ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that creating an AMQP connection has completed.
        /// </summary>
        ///
        /// <param name="endpoint">The service endpoint that the connection is being opened for.</param>
        /// <param name="transportType">The type of transport being used for the connection</param>
        ///
        [Event(57, Level = EventLevel.Verbose, Message = "Completed creation of an AMQP connection for '{0}' using the transport '{1}`.")]
        public virtual void AmqpConnectionCreateComplete(string endpoint,
                                                         string transportType)
        {
            if (IsEnabled())
            {
                WriteEvent(57, endpoint ?? string.Empty, transportType ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an exception was encountered while creating an AMQP connection.
        /// </summary>
        ///
        /// <param name="endpoint">The service endpoint that the connection is being opened for.</param>
        /// <param name="transportType">The type of transport being used for the connection</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(58, Level = EventLevel.Verbose, Message = "An exception occurred while creating an AMQP connection for '{0}' using the transport '{1}`. Error Message: '{2}'")]
        public virtual void AmqpConnectionCreateStartError(string endpoint,
                                                           string transportType,
                                                           string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(58, endpoint ?? string.Empty, transportType ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that creating an AMQP management link has started.
        /// </summary>
        ///
        /// <param name="eventHubName">The type of transport being used for the connection</param>
        ///
        [Event(59, Level = EventLevel.Verbose, Message = "Beginning creation of an AMQP management link for Event Hub: '{0}'.")]
        public virtual void AmqpManagementLinkCreateStart(string eventHubName)
        {
            if (IsEnabled())
            {
                WriteEvent(59, eventHubName ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that creating an AMQP management link has completed.
        /// </summary>
        ///
        /// <param name="eventHubName">The type of transport being used for the connection</param>
        ///
        [Event(60, Level = EventLevel.Verbose, Message = "Completed creation of an AMQP management link for Event Hub: '{0}'.")]
        public virtual void AmqpManagementLinkCreateComplete(string eventHubName)
        {
            if (IsEnabled())
            {
                WriteEvent(60, eventHubName ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an exception was encountered while creating an AMQP management link.
        /// </summary>
        ///
        /// <param name="eventHubName">The type of transport being used for the connection</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(61, Level = EventLevel.Verbose, Message = "An exception occurred while creating an AMQP management link for Event Hub: '{0}'. Error Message: '{1}'")]
        public virtual void AmqpManagementLinkCreateError(string eventHubName,
                                                          string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(61, eventHubName ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that creating an AMQP consumer link has started.
        /// </summary>
        ///
        /// <param name="eventHubName">The type of transport being used for the connection</param>
        /// <param name="consumerGroup">The name of the consumer group that is associated with the link.</param>
        /// <param name="partitionId">The identifier of the Event Hub partition associated with the link.</param>
        /// <param name="ownerLevel">The owner level that is associated with the link.</param>
        /// <param name="eventPosition">The position in the event stream that the link is being opened for.</param>
        ///
        [Event(62, Level = EventLevel.Verbose, Message = "Beginning creation of an AMQP consumer link for Event Hub: '{0}', Consumer Group: '{1}', Partition: '{2}'. (Owner Level: '{3}', Event Position: '{4}')")]
        public virtual void AmqpConsumerLinkCreateStart(string eventHubName,
                                                        string consumerGroup,
                                                        string partitionId,
                                                        string ownerLevel,
                                                        string eventPosition)
        {
            if (IsEnabled())
            {
                WriteEvent(62, eventHubName ?? string.Empty, consumerGroup ?? string.Empty, partitionId ?? string.Empty, ownerLevel ?? string.Empty, eventPosition ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that creating an AMQP consumer link has completed.
        /// </summary>
        ///
        /// <param name="eventHubName">The type of transport being used for the connection</param>
        /// <param name="consumerGroup">The name of the consumer group that is associated with the link.</param>
        /// <param name="partitionId">The identifier of the Event Hub partition associated with the link.</param>
        /// <param name="ownerLevel">The owner level that is associated with the link.</param>
        /// <param name="eventPosition">The position in the event stream that the link is being opened for.</param>
        ///
        [Event(63, Level = EventLevel.Verbose, Message = "Completed creation of an AMQP consumer link for Event Hub: '{0}', Consumer Group: '{1}', Partition: '{2}'. (Owner Level: '{3}', Event Position: '{4}')")]
        public virtual void AmqpConsumerLinkCreateComplete(string eventHubName,
                                                           string consumerGroup,
                                                           string partitionId,
                                                           string ownerLevel,
                                                           string eventPosition)
        {
            if (IsEnabled())
            {
                WriteEvent(63, eventHubName ?? string.Empty, consumerGroup ?? string.Empty, partitionId ?? string.Empty, ownerLevel ?? string.Empty, eventPosition ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an exception was encountered while creating an AMQP consumer link.
        /// </summary>
        ///
        /// <param name="eventHubName">The type of transport being used for the connection</param>
        /// <param name="consumerGroup">The name of the consumer group that is associated with the link.</param>
        /// <param name="partitionId">The identifier of the Event Hub partition associated with the link.</param>
        /// <param name="ownerLevel">The owner level that is associated with the link.</param>
        /// <param name="eventPosition">The position in the event stream that the link is being opened for.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(64, Level = EventLevel.Verbose, Message = "An exception occurred while creating an AMQP consumer link for Event Hub: '{0}', Consumer Group: '{1}', Partition: '{2}'. (Owner Level: '{3}', Event Position: '{4}') Error Message: '{5}'")]
        public virtual void AmqpConsumerLinkCreateError(string eventHubName,
                                                        string consumerGroup,
                                                        string partitionId,
                                                        string ownerLevel,
                                                        string eventPosition,
                                                        string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(64, eventHubName ?? string.Empty, consumerGroup ?? string.Empty, partitionId ?? string.Empty, ownerLevel ?? string.Empty, eventPosition ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that creating an AMQP producer link has started.
        /// </summary>
        ///
        /// <param name="eventHubName">The type of transport being used for the connection</param>
        /// <param name="partitionId">The identifier of the Event Hub partition associated with the link.</param>
        /// <param name="featureSet">The set of active features that the link is being opened for.</param>
        ///
        [Event(65, Level = EventLevel.Verbose, Message = "Beginning creation of an AMQP producer link for Event Hub: '{0}', Partition: '{1}'. (Active Features: '{2}')")]
        public virtual void AmqpProducerLinkCreateStart(string eventHubName,
                                                        string partitionId,
                                                        string featureSet)
        {
            if (IsEnabled())
            {
                WriteEvent(65, eventHubName ?? string.Empty, partitionId ?? string.Empty, featureSet ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that creating an AMQP producer link has completed.
        /// </summary>
        ///
        /// <param name="eventHubName">The type of transport being used for the connection</param>
        /// <param name="partitionId">The identifier of the Event Hub partition associated with the link.</param>
        /// <param name="featureSet">The set of active features that the link is being opened for.</param>
        ///
        [Event(66, Level = EventLevel.Verbose, Message = "Completed creation of an AMQP producer link for Event Hub: '{0}', Partition: '{1}'. (Active Features: '{2}')")]
        public virtual void AmqpProducerLinkCreateComplete(string eventHubName,
                                                           string partitionId,
                                                           string featureSet)
        {
            if (IsEnabled())
            {
                WriteEvent(66, eventHubName ?? string.Empty, partitionId ?? string.Empty, featureSet ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an exception was encountered while creating an AMQP producer link.
        /// </summary>
        ///
        /// <param name="eventHubName">The type of transport being used for the connection</param>
        /// <param name="partitionId">The identifier of the Event Hub partition associated with the link.</param>
        /// <param name="featureSet">The set of active features that the link is being opened for.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(67, Level = EventLevel.Verbose, Message = "An exception occurred while creating an AMQP producer link for Event Hub: '{0}', Partition: '{1}'. (Active Features: '{2}') Error Message: '{3}'")]
        public virtual void AmqpProducerLinkCreateError(string eventHubName,
                                                        string partitionId,
                                                        string featureSet,
                                                        string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(67, eventHubName ?? string.Empty, partitionId ?? string.Empty, featureSet ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that a captured exception is being surfaced during creation an AMQP consumer link.
        /// </summary>
        ///
        /// <param name="eventHubName">The type of transport being used for the connection</param>
        /// <param name="consumerGroup">The name of the consumer group that is associated with the link.</param>
        /// <param name="partitionId">The identifier of the Event Hub partition associated with the link.</param>
        /// <param name="ownerLevel">The owner level that is associated with the link.</param>
        /// <param name="eventPosition">The position in the event stream that the link is being opened for.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(68, Level = EventLevel.Verbose, Message = "An exception captured by fault tolerant close is being surfaced during consumer link creation for Event Hub: '{0}', Consumer Group: '{1}', Partition: '{2}'. (Owner Level: '{3}', Event Position: '{4}') Error Message: '{5}'")]
        public virtual void AmqpConsumerLinkCreateCapturedErrorThrow(string eventHubName,
                                                                     string consumerGroup,
                                                                     string partitionId,
                                                                     string ownerLevel,
                                                                     string eventPosition,
                                                                     string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(68, eventHubName ?? string.Empty, consumerGroup ?? string.Empty, partitionId ?? string.Empty, ownerLevel ?? string.Empty, eventPosition ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an exception during closing of the exception is being captured to surface during the
        ///   next creation attempt.
        /// </summary>
        ///
        /// <param name="eventHubName">The type of transport being used for the connection</param>
        /// <param name="consumerGroup">The name of the consumer group that is associated with the link.</param>
        /// <param name="partitionId">The identifier of the Event Hub partition associated with the link.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(69, Level = EventLevel.Verbose, Message = "An exception during fault tolerant close is being captured to surface when the consumer link is next created for Event Hub: '{0}', Consumer Group: '{1}', Partition: '{2}'. Error Message: '{3}'")]
        public virtual void AmqpConsumerLinkFaultCapture(string eventHubName,
                                                         string consumerGroup,
                                                         string partitionId,
                                                         string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(69, eventHubName ?? string.Empty, consumerGroup ?? string.Empty, partitionId ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventHubBufferedProducerClient" /> instance is about to begin processing events.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the buffered producer.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        ///
        [Event(70, Level = EventLevel.Informational, Message = "Starting background processing for the buffered producer instance with identifier '{0}' for Event Hub: {1}..")]
        public virtual void BufferedProducerBackgroundProcessingStart(string identifier,
                                                                      string eventHubName)
        {
            if (IsEnabled())
            {
                WriteEvent(70, identifier ?? string.Empty, eventHubName ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventHubBufferedProducerClient" /> instance is about to begin processing events.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the buffered producer.</param>
        /// <param name="eventHubName">The name of the Event Hub that the producer is associated with.</param>
        ///
        [Event(71, Level = EventLevel.Informational, Message = "Background processing for the buffered producer instance with identifier '{0}' for Event Hub: {1} has completed starting.")]
        public virtual void BufferedProducerBackgroundProcessingStartComplete(string identifier,
                                                                              string eventHubName)
        {
            if (IsEnabled())
            {
                WriteEvent(71, identifier ?? string.Empty, eventHubName ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventHubBufferedProducerClient" /> instance has encountered an exception while starting to process events.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the buffered producer.</param>
        /// <param name="eventHubName">The name of the Event Hub that the producer is associated with.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(72, Level = EventLevel.Error, Message = "An exception occurred while starting background processing for the buffered producer instance with identifier '{0}' for Event Hub: {1}.  Error Message: '{3}'")]
        public virtual void BufferedProducerBackgroundProcessingStartError(string identifier,
                                                                           string eventHubName,
                                                                           string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(72, identifier ?? string.Empty, eventHubName ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventHubBufferedProducerClient" /> instance is beginning to stop processing events.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the buffered producer</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        ///
        [Event(73, Level = EventLevel.Informational, Message = "The buffered producer instance with identifier '{0}' for Event Hub: {1} is beginning to stop processing.")]
        public virtual void BufferedProducerBackgroundProcessingStop(string identifier,
                                                                     string eventHubName)
        {
            if (IsEnabled())
            {
                WriteEvent(73, identifier ?? string.Empty, eventHubName ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventHubBufferedProducerClient" /> instance has been stopped and is no longer processing events.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the buffered producer.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        ///
        [Event(74, Level = EventLevel.Informational, Message = "The buffered producer instance with identifier '{0}' for Event Hub: {1} has completed stopping processing.")]
        public virtual void BufferedProducerBackgroundProcessingStopComplete(string identifier,
                                                                             string eventHubName)
        {
            if (IsEnabled())
            {
                WriteEvent(74, identifier ?? string.Empty, eventHubName ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventHubBufferedProducerClient" /> instance has encountered an exception while stopping.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the buffered producer.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(75, Level = EventLevel.Error, Message = "An exception occurred while stopping processing for the buffered producer instance with identifier '{0}' for Event Hub: {1}.  Error Message: '{2}'")]
        public virtual void BufferedProducerBackgroundProcessingStopError(string identifier,
                                                                          string eventHubName,
                                                                          string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(75, identifier ?? string.Empty, eventHubName ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventHubBufferedProducerClient" /> instance has encountered an exception in its
        ///   background management task.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the buffered producer.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(76, Level = EventLevel.Error, Message = "An exception occurred in the management task for the buffered producer instance with identifier '{0}' for Event Hub: {1}.  The task will be restarted; this is normally non-fatal.  If happening consistently, it may indicate a problem with the health of the producer.  Error Message: '{2}'")]
        public virtual void BufferedProducerManagementTaskError(string identifier,
                                                                string eventHubName,
                                                                string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(76, identifier ?? string.Empty, eventHubName ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that the enqueue of events for publishing has started.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the buffered producer.</param>
        /// <param name="eventHubName">The name of the Event Hub being published to.</param>
        /// <param name="partitionIdOrKey">The identifier of a partition or the partition hash key used for publishing; identifier or key.</param>
        /// <param name="operationId">An artificial identifier for the publishing operation.</param>
        ///
        [Event(77, Level = EventLevel.Informational, Message = "Enqueuing events to be published buffered producer instance with identifier '{0}' to Event Hub: {1} (Partition Id/Key: '{2}'), Operation Id: '{3}'.")]
        public virtual void BufferedProducerEventEnqueueStart(string identifier,
                                                              string eventHubName,
                                                              string partitionIdOrKey,
                                                              string operationId)
        {
            if (IsEnabled())
            {
                WriteEvent(77, identifier ?? string.Empty, eventHubName ?? string.Empty, partitionIdOrKey ?? string.Empty, operationId ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that the enqueue of events for publishing has completed.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the buffered producer.</param>
        /// <param name="eventHubName">The name of the Event Hub being published to.</param>
        /// <param name="partitionIdOrKey">The identifier of a partition or the partition hash key requested when enqueuing the event; identifier or key.</param>
        /// <param name="operationId">An artificial identifier for the publishing operation.</param>
        ///
        [Event(78, Level = EventLevel.Informational, Message = "Completed enqueuing events to be published buffered producer instance with identifier '{0}' to Event Hub: {1} (Requested Partition Id/Key: '{2}'), Operation Id: '{3}'.")]
        public virtual void BufferedProducerEventEnqueueComplete(string identifier,
                                                                 string eventHubName,
                                                                 string partitionIdOrKey,
                                                                 string operationId)
        {
            if (IsEnabled())
            {
                WriteEvent(78, identifier ?? string.Empty, eventHubName ?? string.Empty, partitionIdOrKey ?? string.Empty, operationId ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an exception was encountered while enqueuing of events for publishing.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the buffered producer.</param>
        /// <param name="eventHubName">The name of the Event Hub being published to.</param>
        /// <param name="partitionIdOrKey">The identifier of a partition or the partition hash key requested when enqueuing the event; identifier or key.</param>
        /// <param name="operationId">An artificial identifier for the publishing operation.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(79, Level = EventLevel.Error, Message = "An exception occurred while enqueuing events to be published buffered producer instance with identifier '{0}' to Event Hub: {1} (Requested Partition Id/Key: '{2}'), Operation Id: '{3}'. Error Message: '{4}'")]
        public virtual void BufferedProducerEventEnqueueError(string identifier,
                                                              string eventHubName,
                                                              string partitionIdOrKey,
                                                              string operationId,
                                                              string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(79, identifier ?? string.Empty, eventHubName ?? string.Empty, partitionIdOrKey ?? string.Empty, operationId ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an event has been assigned a partition as part of enqueuing it to be published has completed.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the buffered producer.</param>
        /// <param name="eventHubName">The name of the Event Hub being published to.</param>
        /// <param name="requestedPartitionIdOrKey">The identifier of a partition or the partition hash key requested when enqueuing the event; identifier or key.</param>
        /// <param name="assignedPartitionId">The identifier of the partition to which the event was assigned.</param>
        /// <param name="operationId">An artificial identifier for the publishing operation.</param>
        /// <param name="totalBufferedEventCount">The total number of buffered events at the time the enqueue was observed.</param>
        ///
        [Event(80, Level = EventLevel.Verbose, Message = "An event being enqueued to be published buffered producer instance with identifier '{0}' to Event Hub: {1} (Requested Partition Id/Key: '{2}') for Operation Id: '{3}' has been enqueued for Partition Id: '{4}'.  Total Buffered Event Count: {5}.")]
        public virtual void BufferedProducerEventEnqueued(string identifier,
                                                          string eventHubName,
                                                          string requestedPartitionIdOrKey,
                                                          string assignedPartitionId,
                                                          string operationId,
                                                          int totalBufferedEventCount)
        {
            if (IsEnabled())
            {
                WriteEvent(80, identifier ?? string.Empty, eventHubName ?? string.Empty, requestedPartitionIdOrKey ?? string.Empty, operationId ?? string.Empty, assignedPartitionId ?? string.Empty, totalBufferedEventCount);
            }
        }

        /// <summary>
        ///   Indicates that the task responsible for publishing events has been started for the first time.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the buffered producer.</param>
        /// <param name="eventHubName">The name of the Event Hub being published to.</param>
        ///
        [Event(81, Level = EventLevel.Verbose, Message = "The event publishing task is being started for the buffered producer instance with identifier '{0}' to Event Hub: {1}.")]
        public virtual void BufferedProducerPublishingTaskInitialStart(string identifier,
                                                                       string eventHubName)
        {
            if (IsEnabled())
            {
                WriteEvent(81, identifier ?? string.Empty, eventHubName ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that the task responsible for publishing events has been started restarted after a problem.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the buffered producer.</param>
        /// <param name="eventHubName">The name of the Event Hub being published to.</param>
        ///
        [Event(82, Level = EventLevel.Verbose, Message = "The event publishing task is being restarted after it unexpectedly stopped for the buffered producer instance with identifier '{0}' to Event Hub: {1}.")]
        public virtual void BufferedProducerPublishingTaskRestart(string identifier,
                                                                  string eventHubName)
        {
            if (IsEnabled())
            {
                WriteEvent(82, identifier ?? string.Empty, eventHubName ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventHubBufferedProducerClient" /> instance has encountered an exception in its
        ///   background publishing task.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the buffered producer.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(83, Level = EventLevel.Error, Message = "An exception occurred in the publishing task for the buffered producer instance with identifier '{0}' for Event Hub: {1}.  The task will be restarted; this is normally non-fatal but does delay sending events.  If happening consistently, it may indicate a problem with the health of the producer.  Error Message: '{2}'")]
        public virtual void BufferedProducerPublishingTaskError(string identifier,
                                                                string eventHubName,
                                                                string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(83, identifier ?? string.Empty, eventHubName ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventHubBufferedProducerClient" /> instance has begun a management
        ///   cycle.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the buffered producer.</param>
        /// <param name="eventHubName">The name of the Event Hub that the buffered producer is associated with.</param>
        ///
        [Event(84, Level = EventLevel.Verbose, Message = "A background management cycle has started for the buffered producer instance with identifier '{0}' for Event Hub: {1}.")]
        public virtual void BufferedProducerManagementCycleStart(string identifier,
                                                                 string eventHubName)
        {
            if (IsEnabled())
            {
                WriteEvent(84, identifier ?? string.Empty, eventHubName ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventHubBufferedProducerClient" /> instance has begun a management
        ///   cycle.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the buffered producer.</param>
        /// <param name="eventHubName">The name of the Event Hub that the buffered producer is associated with.</param>
        /// <param name="totalPartitionCount">The total number of partitions at the end of the cycle.</param>
        /// <param name="durationSeconds">The total duration that the cycle took to complete, in seconds.</param>
        /// <param name="delaySeconds">The delay, in seconds, that will be observed before the next cycle starts.</param>
        ///
        [Event(85, Level = EventLevel.Verbose, Message = "A background management cycle has completed for the buffered producer instance with identifier '{0}' for Event Hub: {1}.  Total partition count: '{2}'.  Duration: '{3:0.00}' seconds.  Next cycle in '{4:0.00}' seconds.")]
        public virtual void BufferedProducerManagementCycleComplete(string identifier,
                                                                    string eventHubName,
                                                                    int totalPartitionCount,
                                                                    double durationSeconds,
                                                                    double delaySeconds)
        {
            if (IsEnabled())
            {
                WriteEvent(85, identifier ?? string.Empty, eventHubName ?? string.Empty, totalPartitionCount, durationSeconds, delaySeconds);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventHubBufferedProducerClient" /> instance publishing task
        ///   has reached maximum concurrency and is waiting for a task to complete.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the buffered producer.</param>
        /// <param name="eventHubName">The name of the Event Hub that the buffered producer is associated with.</param>
        /// <param name="totalActiveTasks">The total number active publishing tasks.</param>
        /// <param name="operationId">An artificial identifier for the await operation.</param>
        ///
        [Event(86, Level = EventLevel.Verbose, Message = "Publishing for the buffered producer instance with identifier '{0}' to Event Hub: {1} has reached the limit on concurrent operations and is waiting for a task to complete.  Active Tasks: '{2}'.  Operation Id: '{3}'")]
        public virtual void BufferedProducerPublishingAwaitStart(string identifier,
                                                                 string eventHubName,
                                                                 int totalActiveTasks,
                                                                 string operationId)
        {
            if (IsEnabled())
            {
                WriteEvent(86, identifier ?? string.Empty, eventHubName ?? string.Empty, totalActiveTasks, operationId ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventHubBufferedProducerClient" /> instance publishing task
        ///   has completed waiting for a task to complete.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the buffered producer.</param>
        /// <param name="eventHubName">The name of the Event Hub that the buffered producer is associated with.</param>
        /// <param name="totalActiveTasks">The total number active publishing tasks.</param>
        /// <param name="operationId">An artificial identifier for the await operation.</param>
        /// <param name="durationSeconds">The total duration that the cycle took to complete, in seconds.</param>
        ///
        [Event(87, Level = EventLevel.Verbose, Message = "Publishing for the buffered producer instance with identifier '{0}' for Event Hub: {1} has completed waiting for a task to complete.  Active Tasks: '{2}'.  Operation Id: '{3},' Duration: '{4:0.00}' seconds.")]
        public virtual void BufferedProducerPublishingAwaitComplete(string identifier,
                                                                    string eventHubName,
                                                                    int totalActiveTasks,
                                                                    string operationId,
                                                                    double durationSeconds)
        {
            if (IsEnabled())
            {
                WriteEvent(87, identifier ?? string.Empty, eventHubName ?? string.Empty, totalActiveTasks, operationId ?? string.Empty, durationSeconds);
            }
        }

        /// <summary>
        ///   Indicates that the publishing for a batch of events has started.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the buffered producer.</param>
        /// <param name="eventHubName">The name of the Event Hub being published to.</param>
        /// <param name="partitionId">The identifier of the partition being published to.</param>
        /// <param name="operationId">An artificial identifier for the publishing operation.</param>
        ///
        [Event(88, Level = EventLevel.Informational, Message = "Starting to publish a batch of events for buffered producer instance with identifier '{0}' to Event Hub: {1},  Partition Id: '{2}', Operation Id: '{3}'.")]
        public virtual void BufferedProducerEventBatchPublishStart(string identifier,
                                                                   string eventHubName,
                                                                   string partitionId,
                                                                   string operationId)
        {
            if (IsEnabled())
            {
                WriteEvent(88, identifier ?? string.Empty, eventHubName ?? string.Empty, partitionId ?? string.Empty, operationId ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that the publishing of a batch of events has completed.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the buffered producer.</param>
        /// <param name="eventHubName">The name of the Event Hub being published to.</param>
        /// <param name="partitionId">The identifier of the partition being published to.</param>
        /// <param name="operationId">An artificial identifier for the publishing operation.</param>
        /// <param name="eventCount">The number of events that was in the batch.</param>
        /// <param name="durationSeconds">The total duration that the cycle took to complete, in seconds.</param>
        ///
        [Event(89, Level = EventLevel.Informational, Message = "Completed publishing a batch of events for buffered producer instance with identifier '{0}' to Event Hub: {1},  Partition Id: '{2}', Operation Id: '{3}',  Events in the Batch: '{4}', Duration: '{5:0.00}' seconds..")]
        public virtual void BufferedProducerEventBatchPublishComplete(string identifier,
                                                                      string eventHubName,
                                                                      string partitionId,
                                                                      string operationId,
                                                                      int eventCount,
                                                                      double durationSeconds)
        {
            if (IsEnabled())
            {
                WriteEvent(89, identifier ?? string.Empty, eventHubName ?? string.Empty, partitionId ?? string.Empty, operationId ?? string.Empty, eventCount, durationSeconds);
            }
        }

        /// <summary>
        ///   Indicates that an exception was encountered while publishing a batch of events.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the buffered producer.</param>
        /// <param name="eventHubName">The name of the Event Hub being published to.</param>
        /// <param name="partitionId">The identifier of the partition being published to.</param>
        /// <param name="operationId">An artificial identifier for the publishing operation.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(90, Level = EventLevel.Error, Message = "An exception occurred while publishing a batch of events for buffered producer instance with identifier '{0}' to Event Hub: {1}, Partition Id: '{2}', Operation Id: '{3}'. Error Message: '{4}'")]
        public virtual void BufferedProducerEventBatchPublishError(string identifier,
                                                                   string eventHubName,
                                                                   string partitionId,
                                                                   string operationId,
                                                                   string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(90, identifier ?? string.Empty, eventHubName ?? string.Empty, partitionId ?? string.Empty, operationId ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an event has been added to a batch being built for publishing.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the buffered producer.</param>
        /// <param name="eventHubName">The name of the Event Hub being published to.</param>
        /// <param name="partitionId">The identifier of the partition being published to.</param>
        /// <param name="operationId">An artificial identifier for the publishing operation.</param>
        /// <param name="eventCount">The number of events that was in the batch.</param>
        /// <param name="durationSeconds">The duration that operation has been running, in seconds.</param>
        ///
        [Event(91, Level = EventLevel.Verbose, Message = "An event has been added to a batch being published for buffered producer instance with identifier '{0}' to Event Hub: {1}, Partition Id: '{2}', Operation Id: '{3}'.  Events in the Batch: '{4}'.  Current duration of batch building: {5:0.00} seconds.")]
        public virtual void BufferedProducerEventBatchPublishEventAdded(string identifier,
                                                                        string eventHubName,
                                                                        string partitionId,
                                                                        string operationId,
                                                                        int eventCount,
                                                                        double durationSeconds)
        {
            if (IsEnabled())
            {
                WriteEvent(91, identifier ?? string.Empty, eventHubName ?? string.Empty, partitionId ?? string.Empty, operationId ?? string.Empty, durationSeconds);
            }
        }

        /// <summary>
        ///   Indicates that no event was available for a batch being built for publishing.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the buffered producer.</param>
        /// <param name="eventHubName">The name of the Event Hub being published to.</param>
        /// <param name="partitionId">The identifier of the partition being published to.</param>
        /// <param name="operationId">An artificial identifier for the publishing operation.</param>
        /// <param name="delayDurationSeconds">The duration that reading will delay before looking for another event, in seconds.</param>
        /// <param name="totalDurationSeconds">The duration that operation has been running, in seconds.</param>
        ///
        [Event(92, Level = EventLevel.Verbose, Message = "No event was available to be read for the batch being published for buffered producer instance with identifier '{0}' to Event Hub: {1}, Partition Id: '{2}', Operation Id: '{3}'.  Delay before reading again: {4:0.00} seconds.  Current duration of batch building: {5:0.00} seconds.")]
        public virtual void BufferedProducerEventBatchPublishNoEventRead(string identifier,
                                                                         string eventHubName,
                                                                         string partitionId,
                                                                         string operationId,
                                                                         double delayDurationSeconds,
                                                                         double totalDurationSeconds)
        {
            if (IsEnabled())
            {
                WriteEvent(92, identifier ?? string.Empty, eventHubName ?? string.Empty, partitionId ?? string.Empty, operationId ?? string.Empty, delayDurationSeconds, totalDurationSeconds);
            }
        }

        /// <summary>
        ///   Indicates that no event handler was available for reporting the status of a batch being published.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the buffered producer.</param>
        /// <param name="eventHubName">The name of the Event Hub being published to.</param>
        /// <param name="partitionId">The identifier of the partition being published to.</param>
        /// <param name="handlerCallerName">The name of the method attempting to invoke the handler.</param>
        ///
        [Event(93, Level = EventLevel.Verbose, Message = "No event handler was available to be invoked for buffered producer instance with identifier '{0}' to Event Hub: {1}, Partition Id: '{2}', Calling method: '{3}'.")]
        public virtual void BufferedProducerNoPublishEventHandler(string identifier,
                                                                  string eventHubName,
                                                                  string partitionId,
                                                                  [CallerMemberName] string handlerCallerName = null)
        {
            if (IsEnabled())
            {
                WriteEvent(93, identifier ?? string.Empty, eventHubName ?? string.Empty, partitionId ?? string.Empty, handlerCallerName ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventHubBufferedProducerClient" /> instance is invoking the send
        ///   success handler.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the buffered producer.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        /// <param name="partitionId">The identifier of the partition that the handler was invoked for.</param>
        /// <param name="operationId">An artificial identifier for the publishing operation.</param>
        ///
        [Event(94, Level = EventLevel.Verbose, Message = "Starting to invoke the 'SendEventBatchSucceeded' handler of the buffered producer instance with identifier '{0}' for Event Hub: {1}, Partition Id: '{2}', Operation Id: '{3}'.")]
        public virtual void BufferedProducerOnSendSucceededStart(string identifier,
                                                                 string eventHubName,
                                                                 string partitionId,
                                                                 string operationId)
        {
            if (IsEnabled())
            {
                WriteEvent(94, identifier ?? string.Empty, eventHubName ?? string.Empty, partitionId ?? string.Empty, operationId ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventHubBufferedProducerClient" /> instance has encountered an exception in the
        ///   publishing success handler.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the buffered producer.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        /// <param name="partitionId">The identifier of the partition that the handler was invoked for.</param>
        /// <param name="operationId">An artificial identifier for the publishing operation.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(95, Level = EventLevel.Error, Message = "An exception occurred in the 'SendEventBatchSucceeded' handler of the buffered producer instance with identifier '{0}' for Event Hub: {1}, Partition Id: '{2}', Operation Id: '{3}'.  This is normally non-fatal, but indicates a problem in the handler code.  If happening consistently, it may indicate a problem with the health of the producer.  Error Message: '{4}'")]
        public virtual void BufferedProducerOnSendSucceededError(string identifier,
                                                                 string eventHubName,
                                                                 string partitionId,
                                                                 string operationId,
                                                                 string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(95, identifier ?? string.Empty, eventHubName ?? string.Empty, partitionId ?? string.Empty, operationId ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventHubBufferedProducerClient" /> instance is invoking the send
        ///   success handler.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the buffered producer.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        /// <param name="partitionId">The identifier of the partition that the handler was invoked for.</param>
        /// <param name="operationId">An artificial identifier for the publishing operation.</param>
        ///
        [Event(96, Level = EventLevel.Verbose, Message = "Completed invocation of the 'SendEventBatchSucceeded' handler of the buffered producer instance with identifier '{0}' for Event Hub: {1}, Partition Id: '{2}', Operation Id: '{3}'.")]
        public virtual void BufferedProducerOnSendSucceededComplete(string identifier,
                                                                    string eventHubName,
                                                                    string partitionId,
                                                                    string operationId)
        {
            if (IsEnabled())
            {
                WriteEvent(96, identifier ?? string.Empty, eventHubName ?? string.Empty, partitionId ?? string.Empty, operationId ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventHubBufferedProducerClient" /> instance is invoking the send
        ///   success handler.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the buffered producer.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        /// <param name="partitionId">The identifier of the partition that the handler was invoked for.</param>
        /// <param name="operationId">An artificial identifier for the publishing operation.</param>
        ///
        [Event(97, Level = EventLevel.Verbose, Message = "Starting to invoke the 'SendEventBatchFailed' handler of the buffered producer instance with identifier '{0}' for Event Hub: {1}, Partition Id: '{2}', Operation Id: '{3}'.")]
        public virtual void BufferedProducerOnSendFailedStart(string identifier,
                                                              string eventHubName,
                                                              string partitionId,
                                                              string operationId)
        {
            if (IsEnabled())
            {
                WriteEvent(97, identifier ?? string.Empty, eventHubName ?? string.Empty, partitionId ?? string.Empty, operationId ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventHubBufferedProducerClient" /> instance has encountered an exception in the
        ///   publishing success handler.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the buffered producer.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        /// <param name="partitionId">The identifier of the partition that the handler was invoked for.</param>
        /// <param name="operationId">An artificial identifier for the publishing operation.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(98, Level = EventLevel.Error, Message = "An exception occurred in the 'SendEventBatchFailed' handler of the buffered producer instance with identifier '{0}' for Event Hub: {1}, Partition Id: '{2}', Operation Id: '{3}'.  This is normally non-fatal, but indicates a problem in the handler code.  If happening consistently, it may indicate a problem with the health of the producer.  Error Message: '{4}'")]
        public virtual void BufferedProducerOnSendFailedError(string identifier,
                                                              string eventHubName,
                                                              string partitionId,
                                                              string operationId,
                                                              string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(98, identifier ?? string.Empty, eventHubName ?? string.Empty, partitionId ?? string.Empty, operationId ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventHubBufferedProducerClient" /> instance is invoking the send
        ///   success handler.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the buffered producer.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        /// <param name="partitionId">The identifier of the partition that the handler was invoked for.</param>
        /// <param name="operationId">An artificial identifier for the publishing operation.</param>
        ///
        [Event(99, Level = EventLevel.Verbose, Message = "Completed invocation of the 'SendEventBatchFailed' handler of the buffered producer instance with identifier '{0}' for Event Hub: {1}, Partition Id: '{2}', Operation Id: '{3}'.")]
        public virtual void BufferedProducerOnSendFailedComplete(string identifier,
                                                                 string eventHubName,
                                                                 string partitionId,
                                                                 string operationId)
        {
            if (IsEnabled())
            {
                WriteEvent(99, identifier ?? string.Empty, eventHubName ?? string.Empty, partitionId ?? string.Empty, operationId ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an exception was encountered in an unexpected code path, not directly associated with
        ///   an Event Hubs operation.
        /// </summary>
        ///
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(100, Level = EventLevel.Error, Message = "An unexpected exception was encountered. Error Message: '{0}'")]
        public void UnexpectedException(string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(100, errorMessage);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventProcessor{TPartition}" /> instance has begun a load balancing
        ///   cycle.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the event processor.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        /// <param name="totalPartitionCount">The total number of partitions at the beginning of the cycle.</param>
        /// <param name="ownedPartitionCount">The number of partitions owned at the beginning of the cycle.</param>
        ///
        [Event(101, Level = EventLevel.Verbose, Message = "A load balancing cycle has started for the processor instance with identifier '{0}' for Event Hub: {1}.  Total partition count: '{2}'.  Owned partition count: '{3}'. ")]
        public virtual void EventProcessorLoadBalancingCycleStart(string identifier,
                                                                  string eventHubName,
                                                                  int totalPartitionCount,
                                                                  int ownedPartitionCount)
        {
            if (IsEnabled())
            {
                WriteEvent(101, identifier ?? string.Empty, eventHubName ?? string.Empty, totalPartitionCount, ownedPartitionCount);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventProcessor{TPartition}" /> instance has completed a load balancing
        ///   cycle.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the event processor.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        /// <param name="totalPartitionCount">The total number of partitions at the end of the cycle.</param>
        /// <param name="ownedPartitionCount">The number of partitions owned at the end of the cycle.</param>
        /// <param name="durationSeconds">The total duration that load balancing took to complete, in seconds.</param>
        /// <param name="delaySeconds">The delay, in seconds, that will be observed before the next load balancing cycle starts.</param>
        ///
        [Event(102, Level = EventLevel.Verbose, Message = "A load balancing cycle has started for the processor instance with identifier '{0}' for Event Hub: {1}.  Total partition count: '{2}'.  Owned partition count: '{3}'.  Duration: '{4:0.00}' seconds.  Next cycle in '{5:0.00}' seconds.")]
        public virtual void EventProcessorLoadBalancingCycleComplete(string identifier,
                                                                     string eventHubName,
                                                                     int totalPartitionCount,
                                                                     int ownedPartitionCount,
                                                                     double durationSeconds,
                                                                     double delaySeconds)
        {
            if (IsEnabled())
            {
                WriteEvent(102, identifier ?? string.Empty, eventHubName ?? string.Empty, totalPartitionCount, ownedPartitionCount, durationSeconds, delaySeconds);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventProcessor{TPartition}" /> instance has a load balancing cycle that
        ///   ran slowly enough to be a concern.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the event processor.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        /// <param name="durationSeconds">The total duration that load balancing took to complete, in seconds.</param>
        /// <param name="loadBalancingIntervalSeconds">The interval, in seconds, that partition ownership is reserved for.</param>
        ///
        [Event(103, Level = EventLevel.Warning, Message = "A load balancing cycle has taken too long to complete for the processor instance with identifier '{0}' for Event Hub: {1}.  A slow cycle can cause stability issues with partition ownership.  Consider investigating storage latency and thread pool health.  Common causes are latency in storage operations and too many partitions owned.  You may also want to consider increasing the 'PartitionOwnershipExpirationInterval' in the processor options.  Cycle Duration: '{2:0.00}' seconds.  Partition Ownership Duration: '{3:0.00}' seconds.")]
        public virtual void EventProcessorLoadBalancingCycleSlowWarning(string identifier,
                                                                        string eventHubName,
                                                                        double durationSeconds,
                                                                        double loadBalancingIntervalSeconds)
        {
            if (IsEnabled())
            {
                WriteEvent(103, identifier ?? string.Empty, eventHubName ?? string.Empty, durationSeconds, loadBalancingIntervalSeconds);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventProcessor{TPartition}" /> instance has taken responsibility for a number of
        ///   partitions that may impact performance and normal operation.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the event processor.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        /// <param name="totalPartitionCount">The total number of partitions.</param>
        /// <param name="ownedPartitionCount">The number of partitions owned.</param>
        /// <param name="maximumAdvisedCount">The maximum number of partitions that are advised for this processor instance.</param>
        ///
        [Event(104, Level = EventLevel.Warning, Message = "The processor instance with identifier '{0}' for Event Hub: {1} owns a higher than recommended number of partitions for average workloads.  Owning too many partitions can cause slow performance and stability issues.  Consider monitoring performance and partition ownership stability to ensure that they meet expectations.  If not, adding processors to the group may help.  Total partition count: '{2}'.  Owned partition count: '{3}'.  Maximum recommended partitions owned: '{4}'.")]
        public virtual void EventProcessorHighPartitionOwnershipWarning(string identifier,
                                                                        string eventHubName,
                                                                        int totalPartitionCount,
                                                                        int ownedPartitionCount,
                                                                        int maximumAdvisedCount)
        {
            if (IsEnabled())
            {
                WriteEvent(104, identifier ?? string.Empty, eventHubName ?? string.Empty, totalPartitionCount, ownedPartitionCount, maximumAdvisedCount);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventProcessor{TPartition}" /> instance has taken ownership of a partition and is actively processing it.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition whose processing is starting.</param>
        /// <param name="identifier">A unique name used to identify the event processor.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        /// <param name="consumerGroup">The name of the consumer group that the processor is associated with.</param>
        /// <param name="startingPosition">The position in the event stream that reading will start from.</param>
        ///
        [Event(105, Level = EventLevel.Verbose, Message = "The processor instance with identifier '{1}' for Event Hub: {2} and Consumer Group: {3} is initializing partition '{0}' with starting position: [{4}]")]
        public virtual void EventProcessorPartitionProcessingEventPositionDetermined(string partitionId,
                                                                                     string identifier,
                                                                                     string eventHubName,
                                                                                     string consumerGroup,
                                                                                     string startingPosition)
        {
            if (IsEnabled())
            {
                WriteEvent(105, partitionId ?? string.Empty, identifier ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty, startingPosition ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventHubBufferedProducerClient" /> instance is invoking the background
        ///   publishing coordination task.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the buffered producer.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        /// <param name="operationId">An artificial identifier for the publishing operation.</param>
        ///
        [Event(106, Level = EventLevel.Informational, Message = "Starting the background publishing task for the buffered producer instance with identifier '{0}', Event Hub: {1}, Operation Id: '{2}'.")]
        public virtual void BufferedProducerPublishingManagementStart(string identifier,
                                                                      string eventHubName,
                                                                      string operationId)
        {
            if (IsEnabled())
            {
                WriteEvent(106, identifier ?? string.Empty, eventHubName ?? string.Empty, operationId ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventHubBufferedProducerClient" /> instance has encountered an exception in the
        ///   background publishing coordination task.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the buffered producer.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        /// <param name="operationId">An artificial identifier for the publishing operation.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(107, Level = EventLevel.Error, Message = "An exception occurred in the background publishing task of the buffered producer instance with identifier '{0}', Event Hub: {1}, Operation Id: '{2}'.  This is normally non-fatal, but indicates a problem in the handler code.  If happening consistently, it may indicate a problem with the health of the producer.  Error Message: '{3}'")]
        public virtual void BufferedProducerPublishingManagementError(string identifier,
                                                                      string eventHubName,
                                                                      string operationId,
                                                                      string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(107, identifier ?? string.Empty, eventHubName ?? string.Empty, operationId ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventHubBufferedProducerClient" /> instance is invoking the background
        ///   publishing coordination task.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the buffered producer.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        /// <param name="operationId">An artificial identifier for the publishing operation.</param>
        ///
        [Event(108, Level = EventLevel.Informational, Message = "Completed the background publishing task of the buffered producer instance with identifier '{0}', Event Hub: {1}, Operation Id: '{2}'.")]
        public virtual void BufferedProducerPublishingManagementComplete(string identifier,
                                                                         string eventHubName,
                                                                         string operationId)
        {
            if (IsEnabled())
            {
                WriteEvent(108, identifier ?? string.Empty, eventHubName ?? string.Empty, operationId ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventHubBufferedProducerClient" /> instance publishing task
        ///   is waiting for all active publishing to complete.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the buffered producer.</param>
        /// <param name="eventHubName">The name of the Event Hub that the buffered producer is associated with.</param>
        /// <param name="totalActiveTasks">The total number active publishing tasks.</param>
        /// <param name="operationId">An artificial identifier for the await operation.</param>
        ///
        [Event(109, Level = EventLevel.Verbose, Message = "Publishing for the buffered producer instance with identifier '{0}' to Event Hub: {1} is stopping and awaiting for all active publishing to complete.  Active Tasks: '{2}'.  Operation Id: '{3}'")]
        public virtual void BufferedProducerPublishingAwaitAllStart(string identifier,
                                                                    string eventHubName,
                                                                    int totalActiveTasks,
                                                                    string operationId)
        {
            if (IsEnabled())
            {
                WriteEvent(109, identifier ?? string.Empty, eventHubName ?? string.Empty, totalActiveTasks, operationId ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventHubBufferedProducerClient" /> instance publishing task
        ///   is done waiting for all active publishing to complete.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the buffered producer.</param>
        /// <param name="eventHubName">The name of the Event Hub that the buffered producer is associated with.</param>
        /// <param name="totalActiveTasks">The total number active publishing tasks.</param>
        /// <param name="operationId">An artificial identifier for the await operation.</param>
        /// <param name="durationSeconds">The total duration that the cycle took to complete, in seconds.</param>
        ///
        [Event(110, Level = EventLevel.Verbose, Message = "Publishing for the buffered producer instance with identifier '{0}' for Event Hub: {1} i stopping and has completed waiting all active publishing to complete.  Active Tasks: '{2}'.  Operation Id: '{3},' Duration: '{4:0.00}' seconds.")]
        public virtual void BufferedProducerPublishingAwaitAllComplete(string identifier,
                                                                       string eventHubName,
                                                                       int totalActiveTasks,
                                                                       string operationId,
                                                                       double durationSeconds)
        {
            if (IsEnabled())
            {
                WriteEvent(110, identifier ?? string.Empty, eventHubName ?? string.Empty, totalActiveTasks, operationId ?? string.Empty, durationSeconds);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventHubBufferedProducerClient" /> instance is starting to perform
        ///   a Flush operation.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the buffered producer.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        /// <param name="operationId">An artificial identifier for the publishing operation.</param>
        ///
        [Event(111, Level = EventLevel.Informational, Message = "Starting to flush events for the buffered producer instance with identifier '{0}', Event Hub: {1}, Operation Id: '{2}'.")]
        public virtual void BufferedProducerFlushStart(string identifier,
                                                       string eventHubName,
                                                       string operationId)
        {
            if (IsEnabled())
            {
                WriteEvent(111, identifier ?? string.Empty, eventHubName ?? string.Empty, operationId ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventHubBufferedProducerClient" /> instance has encountered an exception in an
        ///   active Flush Operation
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the buffered producer.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        /// <param name="operationId">An artificial identifier for the publishing operation.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(112, Level = EventLevel.Error, Message = "An exception occurred while flushing events for the buffered producer instance with identifier '{0}', Event Hub: {1}, Operation Id: '{2}'.  Error Message: '{3}'")]
        public virtual void BufferedProducerFlushError(string identifier,
                                                       string eventHubName,
                                                       string operationId,
                                                       string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(112, identifier ?? string.Empty, eventHubName ?? string.Empty, operationId ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventHubBufferedProducerClient" /> instance has completed an active
        ///   a Flush operation.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the buffered producer.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        /// <param name="operationId">An artificial identifier for the publishing operation.</param>
        ///
        [Event(113, Level = EventLevel.Informational, Message = "Completed flushing events for the buffered producer instance with identifier '{0}', Event Hub: {1}, Operation Id: '{2}'.")]
        public virtual void BufferedProducerFlushComplete(string identifier,
                                                          string eventHubName,
                                                          string operationId)
        {
            if (IsEnabled())
            {
                WriteEvent(113, identifier ?? string.Empty, eventHubName ?? string.Empty, operationId ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventHubBufferedProducerClient" /> instance is starting to perform
        ///   a Clear operation.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the buffered producer.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        /// <param name="operationId">An artificial identifier for the publishing operation.</param>
        ///
        [Event(114, Level = EventLevel.Informational, Message = "Starting to clear events for the buffered producer instance with identifier '{0}', Event Hub: {1}, Operation Id: '{2}'.")]
        public virtual void BufferedProducerClearStart(string identifier,
                                                       string eventHubName,
                                                       string operationId)
        {
            if (IsEnabled())
            {
                WriteEvent(114, identifier ?? string.Empty, eventHubName ?? string.Empty, operationId ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventHubBufferedProducerClient" /> instance has encountered an exception in an
        ///   active Clear operation.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the buffered producer.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        /// <param name="operationId">An artificial identifier for the publishing operation.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(115, Level = EventLevel.Error, Message = "An exception occurred while clearing events for the buffered producer instance with identifier '{0}', Event Hub: {1}, Operation Id: '{2}'.  Error Message: '{3}'")]
        public virtual void BufferedProducerClearError(string identifier,
                                                       string eventHubName,
                                                       string operationId,
                                                       string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(115, identifier ?? string.Empty, eventHubName ?? string.Empty, operationId ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventHubBufferedProducerClient" /> instance has completed an active
        ///   a Clear operation.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the buffered producer.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        /// <param name="operationId">An artificial identifier for the publishing operation.</param>
        ///
        [Event(116, Level = EventLevel.Informational, Message = "Completed clearing events for the buffered producer instance with identifier '{0}', Event Hub: {1}, Operation Id: '{2}'.")]
        public virtual void BufferedProducerClearComplete(string identifier,
                                                          string eventHubName,
                                                          string operationId)
        {
            if (IsEnabled())
            {
                WriteEvent(116, identifier ?? string.Empty, eventHubName ?? string.Empty, operationId ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventHubBufferedProducerClient" /> instance is starting to drain a partition of events.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the buffered producer.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        /// <param name="partitionId">The identifier of the partition being drained.</param>
        /// <param name="operationId">An artificial identifier for the publishing operation.</param>
        ///
        [Event(117, Level = EventLevel.Informational, Message = "Starting to draining events for the buffered producer instance with identifier '{0}', Event Hub: {1}, Partition: '{2}', Operation Id: '{3}'.")]
        public virtual void BufferedProducerDrainStart(string identifier,
                                                       string eventHubName,
                                                       string partitionId,
                                                       string operationId)
        {
            if (IsEnabled())
            {
                WriteEvent(117, identifier ?? string.Empty, eventHubName ?? string.Empty, partitionId ?? string.Empty, operationId ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventHubBufferedProducerClient" /> instance has encountered an exception while draining
        ///   a partition of events.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the buffered producer.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        /// <param name="partitionId">The identifier of the partition being drained.</param>
        /// <param name="operationId">An artificial identifier for the publishing operation.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(118, Level = EventLevel.Error, Message = "An exception occurred while draining events for the buffered producer instance with identifier '{0}', Event Hub: {1}, Partition: '{2}', Operation Id: '{3}'.  Error Message: '{4}'")]
        public virtual void BufferedProducerDrainError(string identifier,
                                                       string eventHubName,
                                                       string partitionId,
                                                       string operationId,
                                                       string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(118, identifier ?? string.Empty, eventHubName ?? string.Empty, partitionId ?? string.Empty, operationId ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventHubBufferedProducerClient" /> instance has completed draining a partition of events.
        /// </summary>
        ///
        /// <param name="identifier">A unique name used to identify the buffered producer.</param>
        /// <param name="eventHubName">The name of the Event Hub that the processor is associated with.</param>
        /// <param name="partitionId">The identifier of the partition being drained.</param>
        /// <param name="operationId">An artificial identifier for the publishing operation.</param>
        ///
        [Event(119, Level = EventLevel.Informational, Message = "Completed draining events for the buffered producer instance with identifier '{0}', Event Hub: {1}, Partition: '{2}', Operation Id: '{3}'.")]
        public virtual void BufferedProducerDrainComplete(string identifier,
                                                          string eventHubName,
                                                          string partitionId,
                                                          string operationId)
        {
            if (IsEnabled())
            {
                WriteEvent(119, identifier ?? string.Empty, eventHubName ?? string.Empty, partitionId ?? string.Empty, operationId ?? string.Empty);
            }
        }
    }
}
