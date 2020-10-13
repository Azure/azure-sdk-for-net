// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.Tracing;
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
    internal class EventHubsEventSource : EventSource
    {
        /// <summary>The name to use for the event source.</summary>
        private const string EventSourceName = "Azure-Messaging-EventHubs";

        /// <summary>
        ///   Provides a singleton instance of the event source for callers to
        ///   use for logging.
        /// </summary>
        ///
        public static EventHubsEventSource Log { get; } = new EventHubsEventSource(EventSourceName);

        /// <summary>
        ///   Prevents an instance of the <see cref="EventHubsEventSource"/> class from being created
        ///   outside the scope of the <see cref="Log" /> instance.
        /// </summary>
        ///
        protected EventHubsEventSource()
        {
        }

        /// <summary>
        ///   Prevents an instance of the <see cref="EventHubsEventSource"/> class from being created
        ///   outside the scope of the <see cref="Log" /> instance.
        /// </summary>
        ///
        /// <param name="eventSourceName">The name to assign to the event source.</param>
        ///
        private EventHubsEventSource(string eventSourceName) : base(eventSourceName, EventSourceSettings.Default, AzureEventSourceListener.TraitName, AzureEventSourceListener.TraitValue)
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
        /// <param name="eventPosition">The description of the <see cref="EventPosition" /> used as the starting point for processing.</param>
        ///
        [Event(39, Level = EventLevel.Verbose, Message = "Completed starting to process partition '{0}' using processor instance with identifier '{1}' for Event Hub: {2} and Consumer Group: {3}.  Starting at position: {4}.")]
        public virtual void EventProcessorPartitionProcessingStartComplete(string partitionId,
                                                                           string identifier,
                                                                           string eventHubName,
                                                                           string consumerGroup,
                                                                           string eventPosition)
        {
            if (IsEnabled())
            {
                WriteEvent(39, partitionId ?? string.Empty, identifier ?? string.Empty, eventHubName ?? string.Empty, consumerGroup ?? string.Empty, eventPosition ?? string.Empty);
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
    }
}
