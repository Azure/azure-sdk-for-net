// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.Tracing;

namespace Azure.Messaging.EventHubs.Diagnostics
{
    /// <summary>
    ///   Serves as an ETW event source for logging of information about
    ///   Event Hubs client
    /// </summary>
    ///
    /// <remarks>
    ///   When defining Start/Stop tasks, it is highly recommended that the
    ///   the StopEvent.Id must be exactly StartEvent.Id + 1.
    /// </remarks>
    ///
    [EventSource(Name = "Azure-Messaging-EventHubs")]
    internal sealed class EventHubsEventSource : EventSource
    {
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
        private EventHubsEventSource()
        {
        }

        /// <summary>
        ///   Indicates that an <see cref="EventHubClient" /> is being created.
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
                WriteEvent(1, eventHubsNamespace ?? String.Empty, eventHubName ?? String.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an <see cref="EventHubClient" /> was created.
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
                WriteEvent(2, eventHubsNamespace ?? String.Empty, eventHubName ?? String.Empty);
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
                WriteEvent(3, eventHubName ?? String.Empty, partitionIdOrKey ?? String.Empty, eventHash ?? String.Empty);
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
                WriteEvent(4, eventHubName ?? String.Empty, partitionIdOrKey ?? String.Empty, eventHash ?? String.Empty);
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
                WriteEvent(5, eventHubName ?? String.Empty, partitionIdOrKey ?? String.Empty, eventHash ?? String.Empty, errorMessage ?? String.Empty);
            }
        }

        /// <summary>
        ///   Indicates that the receiving of events has started.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub being received from.</param>
        /// <param name="partitionId">The identifier of the partition events are being received from.</param>
        ///
        [Event(6, Level = EventLevel.Informational, Message = "Receiving events for Event Hub: {0} (Partition Id: '{1}').")]
        public void EventReceiveStart(string eventHubName,
                                      string partitionId)
        {
            if (IsEnabled())
            {
                WriteEvent(6, eventHubName ?? String.Empty, partitionId ?? String.Empty);
            }
        }

        /// <summary>
        ///   Indicates that the receiving of events has completed.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub being received from.</param>
        /// <param name="partitionId">The identifier of the partition events are being received from.</param>
        /// <param name="eventCount">The number of events that were received in the batch.</param>
        ///
        [Event(7, Level = EventLevel.Informational, Message = "Completed receiving events for Event Hub: {0} (Partition Id: '{1}', Event Count: '{2}').")]
        public void EventReceiveComplete(string eventHubName,
                                         string partitionId,
                                         int eventCount)
        {
            if (IsEnabled())
            {
                WriteEvent(7, eventHubName ?? String.Empty, partitionId ?? String.Empty, eventCount);
            }
        }

        /// <summary>
        ///   Indicates that an exception was encountered while receiving events.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub being received from.</param>
        /// <param name="partitionId">The identifier of the partition events are being received from.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(8, Level = EventLevel.Error, Message = "An exception occurred while receiving events for Event Hub: {0} (Partition Id: '{1}'). Error Message: '{2}'")]
        public void EventReceiveError(string eventHubName,
                                      string partitionId,
                                      string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(8, eventHubName ?? String.Empty, partitionId ?? String.Empty, errorMessage ?? String.Empty);
            }
        }

        /// <summary>
        ///   Indicates that a client is closing, which may corespond to an <see cref="EventHubClient" />,
        ///   <see cref="EventHubProducer" />, or <see cref="EventHubConsumer" />.
        /// </summary>
        ///
        /// <param name="clientType">The type of client being closed.</param>
        /// <param name="eventHubName">The name of the Event Hub associated with the client.</param>
        /// <param name="clientId">An identifier to associate with the client.</param>
        ///
        [Event(9, Level = EventLevel.Verbose, Message = "Closing a {0} client (EventHub '{1}'; Identifier '{2}').")]
        public void ClientCloseStart(Type clientType,
                                     string eventHubName,
                                     string clientId)
        {
            if (IsEnabled())
            {
                WriteEvent(9, clientType.Name, eventHubName ?? String.Empty, clientId ?? String.Empty);
            }
        }

        /// <summary>
        ///   Indicates that a client has been closed, which may corespond to an <see cref="EventHubClient" />,
        ///   <see cref="EventHubProducer" />, or <see cref="EventHubConsumer" />.
        /// </summary>
        ///
        /// <param name="clientType">The type of client being closed.</param>
        /// <param name="eventHubName">The name of the Event Hub associated with the client.</param>
        /// <param name="clientId">An identifier to associate with the client.</param>
        ///
        [Event(10, Level = EventLevel.Verbose, Message = "A {0} client has been closed (EventHub '{1}'; Identifier '{2}').")]
        public void ClientCloseComplete(Type clientType,
                                        string eventHubName,
                                        string clientId)
        {
            if (IsEnabled())
            {
                WriteEvent(10, clientType.Name, eventHubName ?? String.Empty, clientId ?? String.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an exception was encountered while closing an <see cref="EventHubClient" />.
        /// </summary>
        ///
        /// <param name="clientType">The type of client being closed.</param>
        /// <param name="eventHubName">The name of the Event Hub associated with the client.</param>
        /// <param name="clientId">An identifier to associate with the client.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(11, Level = EventLevel.Error, Message = "An exception occurred while closing a {0} client (EventHub '{1}'; Identifier '{2}'). Error Message: '{3}'")]
        public void ClientCloseError(Type clientType,
                                     string eventHubName,
                                     string clientId,
                                     string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(11, clientType.Name, eventHubName ?? String.Empty, clientId ?? String.Empty, errorMessage ?? String.Empty);
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
                WriteEvent(12, eventHubName ?? String.Empty);
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
                WriteEvent(13, eventHubName ?? String.Empty);
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
                WriteEvent(14, eventHubName ?? String.Empty, errorMessage ?? String.Empty);
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
                WriteEvent(15, eventHubName ?? String.Empty, partitionId ?? String.Empty);
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
                WriteEvent(16, eventHubName ?? String.Empty, partitionId ?? String.Empty);
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
                WriteEvent(17, eventHubName ?? String.Empty, partitionId ?? String.Empty, errorMessage ?? String.Empty);
            }
        }

        /// <summary>
        ///   Indicates that subscribing to an Event Hub partition has started.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub that properties are being retrieved for.</param>
        /// <param name="partitionId">The identifier of the partition that properties are being retrieved for.</param>
        ///
        [Event(18, Level = EventLevel.Informational, Message = "Subscribing to Event Hub: {0} (Partition Id: '{1}').")]
        public void SubscribeToPartitionStart(string eventHubName,
                                              string partitionId)
        {
            if (IsEnabled())
            {
                WriteEvent(18, eventHubName ?? String.Empty, partitionId ?? String.Empty);
            }
        }

        /// <summary>
        ///   Indicates that subscribing to an Event Hub partition has completed.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub that properties are being retrieved for.</param>
        /// <param name="partitionId">The identifier of the partition that properties are being retrieved for.</param>
        ///
        [Event(19, Level = EventLevel.Informational, Message = "Completed subscribing to Event Hub: {0} (Partition Id: '{1}').")]
        public void SubscribeToPartitionComplete(string eventHubName,
                                                 string partitionId)
        {
            if (IsEnabled())
            {
                WriteEvent(19, eventHubName ?? String.Empty, partitionId ?? String.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an exception was encountered while subscribing to an Event Hub partition.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub that properties are being retrieved for.</param>
        /// <param name="partitionId">The identifier of the partition that properties are being retrieved for.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(20, Level = EventLevel.Error, Message = "An exception occurred while subscribing to Event Hub: {0} (Partition Id: '{1}'). Error Message: '{2}'")]
        public void SubscribeToPartitionError(string eventHubName,
                                              string partitionId,
                                              string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(20, eventHubName ?? String.Empty, partitionId ?? String.Empty, errorMessage ?? String.Empty);
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
