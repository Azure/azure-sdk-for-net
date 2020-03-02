// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.Tracing;
using Azure.Messaging.ServiceBus.Core;

namespace Azure.Messaging.ServiceBus.Diagnostics
{
    /// <summary>
    ///   Serves as an ETW event source for logging of information about
    ///   Entitys client.
    /// </summary>
    ///
    /// <remarks>
    ///   When defining Start/Stop tasks, it is highly recommended that the
    ///   the StopEvent.Id must be exactly StartEvent.Id + 1.
    /// </remarks>
    ///
    [EventSource(Name = "Azure-Messaging-ServiceBus")]
    internal sealed class ServiceBusEventSource : EventSource
    {
        /// <summary>
        ///   Provides a singleton instance of the event source for callers to
        ///   use for logging.
        /// </summary>
        ///
        public static ServiceBusEventSource Log { get; } = new ServiceBusEventSource();

        /// <summary>
        ///   Prevents an instance of the <see cref="ServiceBusEventSource"/> class from being created
        ///   outside the scope of the <see cref="Log" /> instance.
        /// </summary>
        ///
        private ServiceBusEventSource()
        {
        }

        /// <summary>
        ///   Indicates that an <see cref="ServiceBusConnection" /> is being created.
        /// </summary>
        ///
        /// <param name="serviceBusNamespace">The Entitys namespace associated with the client.</param>
        /// <param name="entityName">The name of the Entity associated with the client.</param>
        ///
        [Event(1, Level = EventLevel.Verbose, Message = "Creating EventHubClient (Namespace '{0}'; EventHub '{1}').")]
        public void ServiceBusClientCreateStart(string serviceBusNamespace,
                                                string entityName)
        {
            if (IsEnabled())
            {
                WriteEvent(1, serviceBusNamespace ?? string.Empty, entityName ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="ServiceBusConnection" /> was created.
        /// </summary>
        ///
        /// <param name="eventHubsNamespace">The Entitys namespace associated with the client.</param>
        /// <param name="entityName">The name of the Entity associated with the client.</param>
        ///
        [Event(2, Level = EventLevel.Verbose, Message = "EventHubClient created (Namespace '{0}'; EventHub '{1}').")]
        public void ServiceBusClientCreateComplete(string eventHubsNamespace,
                                                 string entityName)
        {
            if (IsEnabled())
            {
                WriteEvent(2, eventHubsNamespace ?? string.Empty, entityName ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that the publishing of events has started.
        /// </summary>
        ///
        /// <param name="entityName">The name of the Entity being published to.</param>
        /// <param name="partitionIdOrKey">The identifier of a partition or the partition hash key used for publishing; identifier or key.</param>
        /// <param name="eventHash">The hash of the event or set of events being published.</param>
        ///
        [Event(3, Level = EventLevel.Informational, Message = "Publishing events for Entity: {0} (Partition Id/Key: '{1}', Event Hash: '{2}').")]
        public void MessageSendStart(string entityName,
                                      string partitionIdOrKey,
                                      string eventHash)
        {
            if (IsEnabled())
            {
                WriteEvent(3, entityName ?? string.Empty, partitionIdOrKey ?? string.Empty, eventHash ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that the publishing of events has completed.
        /// </summary>
        ///
        /// <param name="entityName">The name of the Entity being published to.</param>
        /// <param name="partitionIdOrKey">The identifier of a partition or the partition hash key used for publishing; identifier or key.</param>
        /// <param name="eventHash">The hash of the event or set of events being published.</param>
        ///
        [Event(4, Level = EventLevel.Informational, Message = "Completed publishing events for Entity: {0} (Partition Id/Key: '{1}', Event Hash: '{2}').")]
        public void MessageSendComplete(string entityName,
                                         string partitionIdOrKey,
                                         string eventHash)
        {
            if (IsEnabled())
            {
                WriteEvent(4, entityName ?? string.Empty, partitionIdOrKey ?? string.Empty, eventHash ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an exception was encountered while publishing events.
        /// </summary>
        ///
        /// <param name="entityName">The name of the Entity being published to.</param>
        /// <param name="partitionIdOrKey">The identifier of a partition or the partition hash key used for publishing; identifier or key.</param>
        /// <param name="eventHash">The hash of the event or set of events being published.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(5, Level = EventLevel.Error, Message = "An exception occurred while publishing events for Entity: {0} (Partition Id/Key: '{1}', Event Hash: '{2}'). Error Message: '{3}'")]
        public void MessageSendError(string entityName,
                                      string partitionIdOrKey,
                                      string eventHash,
                                      string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(5, entityName ?? string.Empty, partitionIdOrKey ?? string.Empty, eventHash ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that the receiving of events has started.
        /// </summary>
        ///
        /// <param name="entityName">The name of the Entity being received from.</param>
        ///
        [Event(6, Level = EventLevel.Informational, Message = "Receiving events for Entity: {0} (Consumer Group: '{1}', Partition Id: '{2}').")]
        public void MessageReceiveStart(string entityName)
        {
            if (IsEnabled())
            {
                WriteEvent(6, entityName ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that the receiving of events has completed.
        /// </summary>
        ///
        /// <param name="entityName">The name of the Entity being received from.</param>
        /// <param name="eventCount">The number of events that were received in the batch.</param>
        ///
        [Event(7, Level = EventLevel.Informational, Message = "Completed receiving events for Entity: {0} (Consumer Group: '{1}', Partition Id: '{2}').  Event Count: '{3}'")]
        public void MessageReceiveComplete(
            string entityName,
            int eventCount)
        {
            if (IsEnabled())
            {
                WriteEvent(7, entityName ?? string.Empty, eventCount);
            }
        }

        /// <summary>
        ///   Indicates that an exception was encountered while receiving events.
        /// </summary>
        ///
        /// <param name="entityName">The name of the Entity being received from.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(8, Level = EventLevel.Error, Message = "An exception occurred while receiving events for Entity: {0} (Consumer Group: '{1}', Partition Id: '{2}'). Error Message: '{3}'")]
        public void MessageReceiveError(
            string entityName,
            string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(8, entityName ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that a client is closing, which may correspond to an <see cref="ServiceBusConnection" />,
        ///   <see cref="ServiceBusSenderClient" />, <see cref="ServiceBusProcessorClient" />, or <c>EventProcessorClient</c>.
        /// </summary>
        ///
        /// <param name="clientType">The type of client being closed.</param>
        /// <param name="entityName">The name of the Entity associated with the client.</param>
        /// <param name="clientId">An identifier to associate with the client.</param>
        ///
        [Event(9, Level = EventLevel.Verbose, Message = "Closing an {0} (EventHub '{1}'; Identifier '{2}').")]
        public void ClientCloseStart(Type clientType,
                                     string entityName,
                                     string clientId)
        {
            if (IsEnabled())
            {
                WriteEvent(9, clientType.Name, entityName ?? string.Empty, clientId ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that a client has been closed, which may correspond to an <see cref="ServiceBusConnection" />,
        ///   <see cref="ServiceBusSenderClient" />, <see cref="ServiceBusProcessorClient" />, or <c>EventProcessorClient</c>.
        /// </summary>
        ///
        /// <param name="clientType">The type of client being closed.</param>
        /// <param name="entityName">The name of the Entity associated with the client.</param>
        /// <param name="clientId">An identifier to associate with the client.</param>
        ///
        [Event(10, Level = EventLevel.Verbose, Message = "An {0} has been closed (EventHub '{1}'; Identifier '{2}').")]
        public void ClientCloseComplete(Type clientType,
                                        string entityName,
                                        string clientId)
        {
            if (IsEnabled())
            {
                WriteEvent(10, clientType.Name, entityName ?? string.Empty, clientId ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an exception was encountered while closing an <see cref="ServiceBusConnection" />,
        ///   <see cref="ServiceBusSenderClient" />, <see cref="ServiceBusProcessorClient" />, or <c>EventProcessorClient</c>.
        /// </summary>
        ///
        /// <param name="clientType">The type of client being closed.</param>
        /// <param name="entityName">The name of the Entity associated with the client.</param>
        /// <param name="clientId">An identifier to associate with the client.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(11, Level = EventLevel.Error, Message = "An exception occurred while closing an {0} (EventHub '{1}'; Identifier '{2}'). Error Message: '{3}'")]
        public void ClientCloseError(Type clientType,
                                     string entityName,
                                     string clientId,
                                     string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(11, clientType.Name, entityName ?? string.Empty, clientId ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that retrieval of the Entity properties has started.
        /// </summary>
        ///
        /// <param name="entityName">The name of the Entity that properties are being retrieved for.</param>
        ///
        [Event(12, Level = EventLevel.Informational, Message = "Retrieving properties for Entity: {0} (Partition Id: '{1}').")]
        public void GetPropertiesStart(string entityName)
        {
            if (IsEnabled())
            {
                WriteEvent(12, entityName ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that retrieval of the Entity properties has completed.
        /// </summary>
        ///
        /// <param name="entityName">The name of the Entity that properties are being retrieved for.</param>
        ///
        [Event(13, Level = EventLevel.Informational, Message = "Completed retrieving properties for Entity: {0}.")]
        public void ScheduleMessageComplete(string entityName)
        {
            if (IsEnabled())
            {
                WriteEvent(13, entityName ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that retrieval of the Entity properties has completed.
        /// </summary>
        ///
        /// <param name="entityName">The name of the Entity that properties are being retrieved for.</param>
        ///
        [Event(13, Level = EventLevel.Informational, Message = "Completed retrieving properties for Entity: {0}.")]
        public void PeekMessagesComplete(string entityName)
        {
            if (IsEnabled())
            {
                WriteEvent(13, entityName ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that retrieval of the Entity properties has completed.
        /// </summary>
        ///
        /// <param name="entityName">The name of the Entity that properties are being retrieved for.</param>
        ///
        [Event(13, Level = EventLevel.Informational, Message = "Completed retrieving properties for Entity: {0}.")]
        public void CancelScheduledMessageComplete(string entityName)
        {
            if (IsEnabled())
            {
                WriteEvent(13, entityName ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an exception was encountered while retrieving Entity properties.
        /// </summary>
        ///
        /// <param name="entityName">The name of the Entity that properties are being retrieved for.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(14, Level = EventLevel.Error, Message = "An exception occurred while retrieving properties for Entity: {0}. Error Message: '{2}'")]
        public void ScheduleMessageError(string entityName,
                                       string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(14, entityName ?? string.Empty, errorMessage ?? string.Empty);
            }
        }


        /// <summary>
        ///   Indicates that an exception was encountered while retrieving Entity properties.
        /// </summary>
        ///
        /// <param name="entityName">The name of the Entity that properties are being retrieved for.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(14, Level = EventLevel.Error, Message = "An exception occurred while retrieving properties for Entity: {0}. Error Message: '{2}'")]
        public void CancelScheduledMessageError(string entityName,
                                       string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(14, entityName ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that retrieval of the Entity partition properties has started.
        /// </summary>
        ///
        /// <param name="entityName">The name of the Entity that properties are being retrieved for.</param>
        /// <param name="partitionId">The identifier of the partition that properties are being retrieved for.</param>
        ///
        [Event(15, Level = EventLevel.Informational, Message = "Retrieving properties for Entity: {0} (Partition Id: '{1}').")]
        public void GetPartitionPropertiesStart(string entityName,
                                                string partitionId)
        {
            if (IsEnabled())
            {
                WriteEvent(15, entityName ?? string.Empty, partitionId ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that retrieval of the Entity partition properties has completed.
        /// </summary>
        ///
        /// <param name="entityName">The name of the Entity that properties are being retrieved for.</param>
        /// <param name="partitionId">The identifier of the partition that properties are being retrieved for.</param>
        ///
        [Event(16, Level = EventLevel.Informational, Message = "Completed retrieving properties for Entity: {0} (Partition Id: '{1}').")]
        public void GetPartitionPropertiesComplete(string entityName,
                                                   string partitionId)
        {
            if (IsEnabled())
            {
                WriteEvent(16, entityName ?? string.Empty, partitionId ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an exception was encountered while retrieving Entity partition properties.
        /// </summary>
        ///
        /// <param name="entityName">The name of the Entity that properties are being retrieved for.</param>
        /// <param name="partitionId">The identifier of the partition that properties are being retrieved for.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(17, Level = EventLevel.Error, Message = "An exception occurred while retrieving properties for Entity: {0} (Partition Id: '{1}'). Error Message: '{2}'")]
        public void GetPartitionPropertiesError(string entityName,
                                                string partitionId,
                                                string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(17, entityName ?? string.Empty, partitionId ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that reading events from an Entity partition has started.
        /// </summary>
        ///
        /// <param name="entityName">The name of the Entity that events are being read from.</param>
        /// <param name="partitionId">The identifier of the partition that properties are being read from.</param>
        ///
        [Event(18, Level = EventLevel.Informational, Message = "Beginning to publish events to a background channel for Entity: {0} (Partition Id: '{1}').")]
        public void PublishPartitionEventsToChannelStart(string entityName,
                                                         string partitionId)
        {
            if (IsEnabled())
            {
                WriteEvent(18, entityName ?? string.Empty, partitionId ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that reading events from an Entity partition has completed.
        /// </summary>
        ///
        /// <param name="entityName">The name of the Entity that events are being read from.</param>
        /// <param name="partitionId">The identifier of the partition that properties are being read from.</param>
        ///
        [Event(19, Level = EventLevel.Informational, Message = "Completed publishing events to a background channel for Entity: {0} (Partition Id: '{1}').")]
        public void PublishPartitionEventsToChannelComplete(string entityName,
                                                            string partitionId)
        {
            if (IsEnabled())
            {
                WriteEvent(19, entityName ?? string.Empty, partitionId ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an exception was encountered while reading events from an Entity partition.
        /// </summary>
        ///
        /// <param name="entityName">The name of the Entity that events are being read from.</param>
        /// <param name="partitionId">The identifier of the partition that properties are being read from.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(20, Level = EventLevel.Error, Message = "An exception occurred while publishing events to a background channel for Entity: {0} (Partition Id: '{1}'). Error Message: '{2}'")]
        public void PublishPartitionEventsToChannelError(string entityName,
                                                         string partitionId,
                                                         string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(20, entityName ?? string.Empty, partitionId ?? string.Empty, errorMessage ?? string.Empty);
            }
        }
        /// <summary>
        ///   Indicates that reading events from an Entity partition has started.
        /// </summary>
        ///
        /// <param name="entityName">The name of the Entity that events are being read from.</param>
        /// <param name="partitionId">The identifier of the partition that properties are being read from.</param>
        ///
        [Event(21, Level = EventLevel.Informational, Message = "Beginning to read events for Entity: {0} (Partition Id: '{1}').")]
        public void ReadEventsFromPartitionStart(string entityName,
                                                 string partitionId)
        {
            if (IsEnabled())
            {
                WriteEvent(21, entityName ?? string.Empty, partitionId ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that reading events from an Entity partition has completed.
        /// </summary>
        ///
        /// <param name="entityName">The name of the Entity that events are being read from.</param>
        /// <param name="partitionId">The identifier of the partition that properties are being read from.</param>
        ///
        [Event(22, Level = EventLevel.Informational, Message = "Completed reading events for Entity: {0} (Partition Id: '{1}').")]
        public void ReadEventsFromPartitionComplete(string entityName,
                                                    string partitionId)
        {
            if (IsEnabled())
            {
                WriteEvent(22, entityName ?? string.Empty, partitionId ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an exception was encountered while reading events from an Entity partition.
        /// </summary>
        ///
        /// <param name="entityName">The name of the Entity that events are being read from.</param>
        /// <param name="partitionId">The identifier of the partition that properties are being read from.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(23, Level = EventLevel.Error, Message = "An exception occurred while reading events for Entity: {0} (Partition Id: '{1}'). Error Message: '{2}'")]
        public void ReadEventsFromPartitionError(string entityName,
                                                 string partitionId,
                                                 string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(23, entityName ?? string.Empty, partitionId ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that reading events from all partitions of the Entity has started.
        /// </summary>
        ///
        /// <param name="entityName">The name of the Entity that events are being read from.</param>
        ///
        [Event(24, Level = EventLevel.Informational, Message = "Beginning to read events for all partitions of Entity: {0}.")]
        public void ReadAllEventsStart(string entityName)
        {
            if (IsEnabled())
            {
                WriteEvent(24, entityName ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that reading events from all partitions of the Entity has completed.
        /// </summary>
        ///
        /// <param name="entityName">The name of the Entity that events are being read from.</param>
        ///
        [Event(25, Level = EventLevel.Informational, Message = "Completed reading events for all partitions of Entity: {0}.")]
        public void ReadAllEventsComplete(string entityName)
        {
            if (IsEnabled())
            {
                WriteEvent(25, entityName ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an exception was encountered while reading events from all partitions of the Entity.
        /// </summary>
        ///
        /// <param name="entityName">The name of the Entity that events are being read from.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(26, Level = EventLevel.Error, Message = "An exception occurred while reading events for all partitions of Entity: {0}. Error Message: '{1}'")]
        public void ReadAllEventsError(string entityName,
                                       string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(26, entityName ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that refreshing authorization for an AMQP link has started.
        /// </summary>
        ///
        /// <param name="entityName">The name of the Entity that the link is associated with.</param>
        /// <param name="endpoint">The service endpoint that the link is bound to for communication.</param>
        ///
        [Event(27, Level = EventLevel.Informational, Message = "Beginning refresh of AMQP link authorization for Entity: {0} (Service Endpoint: '{1}').")]
        public void AmqpLinkAuthorizationRefreshStart(string entityName,
                                                      string endpoint)
        {
            if (IsEnabled())
            {
                WriteEvent(27, entityName ?? string.Empty, endpoint ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that refreshing authorization for an AMQP link has completed.
        /// </summary>
        ///
        /// <param name="entityName">The name of the Entity that the link is associated with.</param>
        /// <param name="endpoint">The service endpoint that the link is bound to for communication.</param>
        ///
        [Event(28, Level = EventLevel.Informational, Message = "Completed refresh of AMQP link authorization for Entity: {0} (Service Endpoint: '{1}').")]
        public void AmqpLinkAuthorizationRefreshComplete(string entityName,
                                                         string endpoint)
        {
            if (IsEnabled())
            {
                WriteEvent(28, entityName ?? string.Empty, endpoint ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an exception was encountered while refreshing authorization for an AMQP link has started.
        /// </summary>
        ///
        /// <param name="entityName">The name of the Entity that the link is associated with.</param>
        /// <param name="endpoint">The service endpoint that the link is bound to for communication.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(29, Level = EventLevel.Error, Message = "An exception occurred while refreshing AMQP link authorization for Entity: {0} (Service Endpoint: '{1}'). Error Message: '{2}'")]
        public void AmqpLinkAuthorizationRefreshError(string entityName,
                                                      string endpoint,
                                                      string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(29, entityName ?? string.Empty, endpoint ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an exception was encountered in an unexpected code path, not directly associated with
        ///   an Entitys operation.
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
