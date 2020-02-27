// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.Tracing;
using Azure.Core.Diagnostics;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Producer;

namespace Azure.Messaging.EventHubs.Diagnostics
{
    /// <summary>
    ///   Serves as an ETW event source for logging of information about
    ///   Event Hubs client.
    /// </summary>
    ///
    /// <remarks>
    ///   When defining Start/Stop tasks, it is highly recommended that the
    ///   the StopEvent.Id must be exactly StartEvent.Id + 1.
    /// </remarks>
    ///
    [EventSource(Name = EventSourceName)]
    internal sealed class EventHubsEventSource : EventSource
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
        private EventHubsEventSource() : base(EventSourceName, EventSourceSettings.Default, AzureEventSourceListener.TraitName, AzureEventSourceListener.TraitValue)
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
        public void EventHubClientCreateStart(string eventHubsNamespace,
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
        public void EventHubClientCreateComplete(string eventHubsNamespace,
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
        /// <param name="eventHash">The hash of the event or set of events being published.</param>
        ///
        [Event(3, Level = EventLevel.Informational, Message = "Publishing events for Event Hub: {0} (Partition Id/Key: '{1}', Event Hash: '{2}').")]
        public void EventPublishStart(string eventHubName,
                                      string partitionIdOrKey,
                                      string eventHash)
        {
            if (IsEnabled())
            {
                WriteEvent(3, eventHubName ?? string.Empty, partitionIdOrKey ?? string.Empty, eventHash ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that the publishing of events has completed.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub being published to.</param>
        /// <param name="partitionIdOrKey">The identifier of a partition or the partition hash key used for publishing; identifier or key.</param>
        /// <param name="eventHash">The hash of the event or set of events being published.</param>
        ///
        [Event(4, Level = EventLevel.Informational, Message = "Completed publishing events for Event Hub: {0} (Partition Id/Key: '{1}', Event Hash: '{2}').")]
        public void EventPublishComplete(string eventHubName,
                                         string partitionIdOrKey,
                                         string eventHash)
        {
            if (IsEnabled())
            {
                WriteEvent(4, eventHubName ?? string.Empty, partitionIdOrKey ?? string.Empty, eventHash ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an exception was encountered while publishing events.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub being published to.</param>
        /// <param name="partitionIdOrKey">The identifier of a partition or the partition hash key used for publishing; identifier or key.</param>
        /// <param name="eventHash">The hash of the event or set of events being published.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(5, Level = EventLevel.Error, Message = "An exception occurred while publishing events for Event Hub: {0} (Partition Id/Key: '{1}', Event Hash: '{2}'). Error Message: '{3}'")]
        public void EventPublishError(string eventHubName,
                                      string partitionIdOrKey,
                                      string eventHash,
                                      string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(5, eventHubName ?? string.Empty, partitionIdOrKey ?? string.Empty, eventHash ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that the receiving of events has started.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub being received from.</param>
        /// <param name="consumerGroup">The consumer group associated with the receive operation.</param>
        /// <param name="partitionId">The identifier of the partition events are being received from.</param>
        ///
        [Event(6, Level = EventLevel.Informational, Message = "Receiving events for Event Hub: {0} (Consumer Group: '{1}', Partition Id: '{2}').")]
        public void EventReceiveStart(string eventHubName,
                                      string consumerGroup,
                                      string partitionId)
        {
            if (IsEnabled())
            {
                WriteEvent(6, eventHubName ?? string.Empty, consumerGroup ?? string.Empty, partitionId ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that the receiving of events has completed.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub being received from.</param>
        /// <param name="partitionId">The identifier of the partition events are being received from.</param>
        /// <param name="consumerGroup">The consumer group associated with the receive operation.</param>
        /// <param name="eventCount">The number of events that were received in the batch.</param>
        ///
        [Event(7, Level = EventLevel.Informational, Message = "Completed receiving events for Event Hub: {0} (Consumer Group: '{1}', Partition Id: '{2}').  Event Count: '{3}'")]
        public void EventReceiveComplete(string eventHubName,
                                         string consumerGroup,
                                         string partitionId,
                                         int eventCount)
        {
            if (IsEnabled())
            {
                WriteEvent(7, eventHubName ?? string.Empty, consumerGroup ?? string.Empty, partitionId ?? string.Empty, eventCount);
            }
        }

        /// <summary>
        ///   Indicates that an exception was encountered while receiving events.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub being received from.</param>
        /// <param name="partitionId">The identifier of the partition events are being received from.</param>
        /// <param name="consumerGroup">The consumer group associated with the receive operation.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(8, Level = EventLevel.Error, Message = "An exception occurred while receiving events for Event Hub: {0} (Consumer Group: '{1}', Partition Id: '{2}'). Error Message: '{3}'")]
        public void EventReceiveError(string eventHubName,
                                      string consumerGroup,
                                      string partitionId,
                                      string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(8, eventHubName ?? string.Empty, consumerGroup ?? string.Empty, partitionId ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that a client is closing, which may correspond to an <see cref="EventHubConnection" />,
        ///   <see cref="EventHubProducerClient" />, <see cref="EventHubConsumerClient" />, or <c>EventProcessorClient</c>.
        /// </summary>
        ///
        /// <param name="clientType">The type of client being closed.</param>
        /// <param name="eventHubName">The name of the Event Hub associated with the client.</param>
        /// <param name="clientId">An identifier to associate with the client.</param>
        ///
        [Event(9, Level = EventLevel.Verbose, Message = "Closing an {0} (EventHub '{1}'; Identifier '{2}').")]
        public void ClientCloseStart(Type clientType,
                                     string eventHubName,
                                     string clientId)
        {
            if (IsEnabled())
            {
                WriteEvent(9, clientType.Name, eventHubName ?? string.Empty, clientId ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that a client has been closed, which may correspond to an <see cref="EventHubConnection" />,
        ///   <see cref="EventHubProducerClient" />, <see cref="EventHubConsumerClient" />, or <c>EventProcessorClient</c>.
        /// </summary>
        ///
        /// <param name="clientType">The type of client being closed.</param>
        /// <param name="eventHubName">The name of the Event Hub associated with the client.</param>
        /// <param name="clientId">An identifier to associate with the client.</param>
        ///
        [Event(10, Level = EventLevel.Verbose, Message = "An {0} has been closed (EventHub '{1}'; Identifier '{2}').")]
        public void ClientCloseComplete(Type clientType,
                                        string eventHubName,
                                        string clientId)
        {
            if (IsEnabled())
            {
                WriteEvent(10, clientType.Name, eventHubName ?? string.Empty, clientId ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an exception was encountered while closing an <see cref="EventHubConnection" />,
        ///   <see cref="EventHubProducerClient" />, <see cref="EventHubConsumerClient" />, or <c>EventProcessorClient</c>.
        /// </summary>
        ///
        /// <param name="clientType">The type of client being closed.</param>
        /// <param name="eventHubName">The name of the Event Hub associated with the client.</param>
        /// <param name="clientId">An identifier to associate with the client.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(11, Level = EventLevel.Error, Message = "An exception occurred while closing an {0} (EventHub '{1}'; Identifier '{2}'). Error Message: '{3}'")]
        public void ClientCloseError(Type clientType,
                                     string eventHubName,
                                     string clientId,
                                     string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(11, clientType.Name, eventHubName ?? string.Empty, clientId ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that retrieval of the Event Hub properties has started.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub that properties are being retrieved for.</param>
        ///
        [Event(12, Level = EventLevel.Informational, Message = "Retrieving properties for Event Hub: {0} (Partition Id: '{1}').")]
        public void GetPropertiesStart(string eventHubName)
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
        public void GetPropertiesComplete(string eventHubName)
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
        [Event(14, Level = EventLevel.Error, Message = "An exception occurred while retrieving properties for Event Hub: {0}. Error Message: '{2}'")]
        public void GetPropertiesError(string eventHubName,
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
        public void GetPartitionPropertiesStart(string eventHubName,
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
        public void GetPartitionPropertiesComplete(string eventHubName,
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
        public void GetPartitionPropertiesError(string eventHubName,
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
        public void PublishPartitionEventsToChannelStart(string eventHubName,
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
        public void PublishPartitionEventsToChannelComplete(string eventHubName,
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
        public void PublishPartitionEventsToChannelError(string eventHubName,
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
        public void ReadEventsFromPartitionStart(string eventHubName,
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
        public void ReadEventsFromPartitionComplete(string eventHubName,
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
        public void ReadEventsFromPartitionError(string eventHubName,
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
        public void ReadAllEventsStart(string eventHubName)
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
        public void ReadAllEventsComplete(string eventHubName)
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
        public void ReadAllEventsError(string eventHubName,
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
        public void AmqpLinkAuthorizationRefreshStart(string eventHubName,
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
        public void AmqpLinkAuthorizationRefreshComplete(string eventHubName,
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
        public void AmqpLinkAuthorizationRefreshError(string eventHubName,
                                                      string endpoint,
                                                      string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(29, eventHubName ?? string.Empty, endpoint ?? string.Empty, errorMessage ?? string.Empty);
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
