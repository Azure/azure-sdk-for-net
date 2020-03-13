// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using Azure.Messaging.ServiceBus.Core;
using Azure.Messaging.ServiceBus.Primitives;
using Microsoft.Azure.Amqp;

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

        [Event(1, Level = EventLevel.Informational, Message = "{0}: SendAsync start. MessageCount = {1}")]
        public void SendMessageStart(string identifier, int messageCount)
        {
            if (IsEnabled())
            {
                WriteEvent(1, identifier, messageCount);
            }
        }

        [Event(2, Level = EventLevel.Informational, Message = "{0}: SendAsync done.")]
        public void SendMessageComplete(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(2, identifier);
            }
        }

        [Event(3, Level = EventLevel.Error, Message = "{0}: SendAsync Exception: {1}.")]
        public void SendMessageException(string identifier, Exception exception)
        {
            if (IsEnabled())
            {
                WriteEvent(3, identifier, exception.ToString());
            }
        }

        [Event(4, Level = EventLevel.Informational, Message = "{0}: CreateBatchAsync start.")]
        public void CreateMessageBatchStart(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(4, identifier);
            }
        }

        [Event(5, Level = EventLevel.Informational, Message = "{0}: CreateBatchAsync done.")]
        public void CreateMessageBatchComplete(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(5, identifier);
            }
        }

        [Event(6, Level = EventLevel.Error, Message = "{0}: CreateBatchAsync Exception: {1}.")]
        public void CreateMessageBatchException(string identifier, Exception exception)
        {
            if (IsEnabled())
            {
                WriteEvent(6, identifier, exception.ToString());
            }
        }
        [Event(7, Level = EventLevel.Informational, Message = "{0}: ReceiveBatchAsync start. MessageCount = {1}")]
        public void ReceiveMessageStart(string identifier, int messageCount)
        {
            if (IsEnabled())
            {
                WriteEvent(7, identifier, messageCount);
            }
        }

        [Event(8, Level = EventLevel.Informational, Message = "{0}: ReceiveBatchAsync done. Received '{1}' messages")]
        public void ReceiveMessageComplete(string identifier, int messageCount)
        {
            if (IsEnabled())
            {
                WriteEvent(8, identifier, messageCount);
            }
        }

        [Event(9, Level = EventLevel.Error, Message = "{0}: ReceiveBatchAsync Exception: {1}.")]
        public void ReceiveMessageException(string clientId, Exception exception)
        {
            if (IsEnabled())
            {
                WriteEvent(9, clientId, exception.ToString());
            }
        }

        [Event(10, Level = EventLevel.Informational, Message = "{0}: ScheduleMessageAsync start. ScheduleTimeUtc = {1}")]
        public void ScheduleMessageStart(string identifier, DateTimeOffset scheduledEnqueueTime)
        {
            if (IsEnabled())
            {
                WriteEvent(10, identifier, scheduledEnqueueTime.ToString());
            }
        }

        [Event(11, Level = EventLevel.Informational, Message = "{0}: ScheduleMessageAsync done.")]
        public void ScheduleMessageComplete(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(11, identifier);
            }
        }

        [Event(12, Level = EventLevel.Error, Message = "{0}: ScheduleMessageAsync Exception: {1}.")]
        public void ScheduleMessageException(string identifier, Exception exception)
        {
            if (IsEnabled())
            {
                WriteEvent(12, identifier, exception.ToString());
            }
        }

        [Event(13, Level = EventLevel.Informational, Message = "{0}: CancelScheduledMessageAsync start. SequenceNumber = {1}")]
        public void CancelScheduledMessageStart(string identifier, long sequenceNumber)
        {
            if (IsEnabled())
            {
                WriteEvent(13, identifier, sequenceNumber);
            }
        }

        [Event(14, Level = EventLevel.Informational, Message = "{0}: CancelScheduledMessageAsync done.")]
        public void CancelScheduledMessageComplete(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(14, identifier);
            }
        }

        [Event(15, Level = EventLevel.Error, Message = "{0}: CancelScheduledMessageAsync Exception: {1}.")]
        public void CancelScheduledMessageException(string identifier, Exception exception)
        {
            if (IsEnabled())
            {
                WriteEvent(15, identifier, exception.ToString());
            }
        }

        [Event(16, Level = EventLevel.Informational, Message = "{0}: CompleteAsync start. MessageCount = {1}, LockTokens = {2}")]
        public void CompleteMessageStart(string identifier, int messageCount, IList<string> lockTokens)
        {
            if (IsEnabled())
            {
                var formattedLockTokens = StringUtility.GetFormattedLockTokens(lockTokens);
                WriteEvent(16, identifier, messageCount, formattedLockTokens);
            }
        }

        [Event(17, Level = EventLevel.Informational, Message = "{0}: CompleteAsync done.")]
        public void CompleteMessageComplete(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(17, identifier);
            }
        }

        [Event(18, Level = EventLevel.Error, Message = "{0}: CompleteAsync Exception: {1}.")]
        public void CompleteMessageException(string identifier, Exception exception)
        {
            if (IsEnabled())
            {
                WriteEvent(18, identifier, exception.ToString());
            }
        }

        [Event(19, Level = EventLevel.Informational, Message = "{0}: DeferAsync start. MessageCount = {1}, LockToken = {2}")]
        public void DeferMessageStart(string identifier, int messageCount, string lockToken)
        {
            if (IsEnabled())
            {
                WriteEvent(19, identifier, messageCount, lockToken);
            }
        }

        [Event(20, Level = EventLevel.Informational, Message = "{0}: DeferAsync done.")]
        public void DeferMessageComplete(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(20, identifier);
            }
        }

        [Event(21, Level = EventLevel.Error, Message = "{0}: DeferAsync Exception: {1}.")]
        public void DeferMessageException(string identifier, Exception exception)
        {
            WriteEvent(21, identifier, exception.ToString());
        }

        [Event(22, Level = EventLevel.Informational, Message = "{0}: AbandonAsync start. MessageCount = {1}, LockToken = {2}")]
        public void AbandonMessageStart(string identifier, int messageCount, string lockToken)
        {
            if (IsEnabled())
            {
                WriteEvent(22, identifier, messageCount, lockToken);
            }
        }

        [Event(23, Level = EventLevel.Informational, Message = "{0}: AbandonAsync done.")]
        public void AbandonMessageComplete(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(17, identifier);
            }
        }

        [Event(24, Level = EventLevel.Error, Message = "{0}: AbandonAsync Exception: {1}.")]
        public void AbandonMessageException(string identifier, Exception exception)
        {
            if (IsEnabled())
            {
                WriteEvent(24, identifier, exception.ToString());
            }
        }

        [Event(25, Level = EventLevel.Informational, Message = "{0}: DeadLetterAsync start. MessageCount = {1}, LockToken = {2}")]
        public void DeadLetterMessageStart(string identifier, int messageCount, string lockToken)
        {
            if (IsEnabled())
            {
                WriteEvent(25, identifier, messageCount, lockToken);
            }
        }

        [Event(26, Level = EventLevel.Informational, Message = "{0}: DeadLetterAsync done.")]
        public void DeadLetterMessageComplete(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(26, identifier);
            }
        }

        [Event(27, Level = EventLevel.Error, Message = "{0}: DeadLetterAsync Exception: {1}.")]
        public void DeadLetterMessageException(string identifier, Exception exception)
        {
            if (IsEnabled())
            {
                WriteEvent(27, identifier, exception.ToString());
            }
        }

        [Event(28, Level = EventLevel.Informational, Message = "{0}: MessagePeekAsync start. SequenceNumber = {1}, MessageCount = {2}")]
        public void PeekMessageStart(string identifier, long? sequenceNumber, int messageCount)
        {
            if (IsEnabled())
            {
                WriteEvent(28, identifier, sequenceNumber, messageCount);
            }
        }

        [Event(29, Level = EventLevel.Informational, Message = "{0}: MessagePeekAsync done. Peeked '{1}' messages")]
        public void PeekMessageComplete(string identifier, int messageCount)
        {
            if (IsEnabled())
            {
                WriteEvent(29, identifier, messageCount);
            }
        }

        [Event(30, Level = EventLevel.Error, Message = "{0}: MessagePeekAsync Exception: {1}.")]
        public void PeekMessageException(string identifier, Exception exception)
        {
            if (IsEnabled())
            {
                WriteEvent(30, identifier, exception.ToString());
            }
        }

        [Event(31, Level = EventLevel.Informational, Message = "{0}: RenewLockAsync start. MessageCount = {1}, LockToken = {2}")]
        public void RenewMessageLockStart(string identifier, int messageCount, string lockToken)
        {
            if (IsEnabled())
            {
                WriteEvent(31, identifier, messageCount, lockToken);
            }
        }

        [Event(32, Level = EventLevel.Informational, Message = "{0}: RenewLockAsync done.")]
        public void RenewMessageLockComplete(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(32, identifier);
            }
        }

        [Event(33, Level = EventLevel.Error, Message = "{0}: RenewLockAsync Exception: {1}.")]
        public void RenewMessageLockException(string identifier, Exception exception)
        {
            if (IsEnabled())
            {
                WriteEvent(33, identifier, exception.ToString());
            }
        }

        [Event(34, Level = EventLevel.Informational, Message = "{0}: ReceiveDeferredMessageAsync start. MessageCount = {1}, LockTokens = {2}")]
        public void ReceiveDeferredMessageStart(string identifier, int messageCount, IEnumerable<long> sequenceNumbers)
        {
            if (IsEnabled())
            {
                var formattedSequenceNumbers = StringUtility.GetFormattedSequenceNumbers(sequenceNumbers);
                WriteEvent(34, identifier, messageCount, formattedSequenceNumbers);
            }
        }

        [Event(35, Level = EventLevel.Informational, Message = "{0}: ReceiveDeferredMessageAsync done. Received '{1}' messages")]
        public void ReceiveDeferredMessageStop(string identifier, int messageCount)
        {
            if (IsEnabled())
            {
                WriteEvent(35, identifier, messageCount);
            }
        }

        [Event(36, Level = EventLevel.Error, Message = "{0}: ReceiveDeferredMessageAsync Exception: {1}.")]
        public void ReceiveDeferredMessageException(string identifier, Exception exception)
        {
            if (IsEnabled())
            {
                WriteEvent(36, identifier, exception, ToString());
            }
        }

        [Event(37, Level = EventLevel.Error, Message = "Link state lost. Throwing LockLostException for identifier: {0}, receiveLinkName: {1}, receiveLinkState: {2}, isSessionReceiver: {3}, exception: {4}.")]
        public void LinkStateLost(string identifier, string receiveLinkName, AmqpObjectState receiveLinkState, bool isSessionReceiver, Exception exception)
        {
            if (IsEnabled())
            {
                WriteEvent(37, identifier, receiveLinkName, receiveLinkState.ToString(), isSessionReceiver, exception.ToString());
            }
        }

        [Event(38, Level = EventLevel.Error, Message = "SessionReceiver Link Closed. identifier: {0}, SessionId: {1}, linkException: {2}.")]
        public void SessionReceiverLinkClosed(string identifier, string sessionId, Exception linkException)
        {
            if (IsEnabled())
            {
                WriteEvent(38, identifier, sessionId, linkException.ToString());
            }
        }

        /// <summary>
        ///   Indicates that refreshing authorization for an AMQP link has started.
        /// </summary>
        ///
        /// <param name="identifier">The name of the Entity that the link is associated with.</param>
        /// <param name="endpoint">The service endpoint that the link is bound to for communication.</param>
        ///
        [Event(39, Level = EventLevel.Informational, Message = "Beginning refresh of AMQP link authorization for Identifier: {0} (Service Endpoint: '{1}').")]
        public void AmqpLinkAuthorizationRefreshStart(string identifier,
                                                      string endpoint)
        {
            if (IsEnabled())
            {
                WriteEvent(39, identifier ?? string.Empty, endpoint ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that refreshing authorization for an AMQP link has completed.
        /// </summary>
        ///
        /// <param name="identifier">The name of the Entity that the link is associated with.</param>
        /// <param name="endpoint">The service endpoint that the link is bound to for communication.</param>
        ///
        [Event(40, Level = EventLevel.Informational, Message = "Completed refresh of AMQP link authorization for Identifier: {0} (Service Endpoint: '{1}').")]
        public void AmqpLinkAuthorizationRefreshComplete(string identifier,
                                                         string endpoint)
        {
            if (IsEnabled())
            {
                WriteEvent(40, identifier ?? string.Empty, endpoint ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an exception was encountered while refreshing authorization for an AMQP link has started.
        /// </summary>
        ///
        /// <param name="identifier">The name of the Entity that the link is associated with.</param>
        /// <param name="endpoint">The service endpoint that the link is bound to for communication.</param>
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(41, Level = EventLevel.Error, Message = "An exception occurred while refreshing AMQP link authorization for Identifier: {0} (Service Endpoint: '{1}'). Error Message: '{2}'")]
        public void AmqpLinkAuthorizationRefreshError(string identifier,
                                                      string endpoint,
                                                      string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(41, identifier ?? string.Empty, endpoint ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an exception was encountered in an unexpected code path, not directly associated with
        ///   an Entitys operation.
        /// </summary>
        ///
        /// <param name="errorMessage">The message for the exception that occurred.</param>
        ///
        [Event(42, Level = EventLevel.Error, Message = "An unexpected exception was encountered. Error Message: '{0}'")]
        public void UnexpectedException(string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(42, errorMessage);
            }
        }

        [Event(43, Level = EventLevel.Warning, Message = "RunOperation encountered an exception and will retry. Exception: {0}")]
        public void RunOperationExceptionEncountered(Exception exception)
        {
            if (IsEnabled())
            {
                WriteEvent(43, exception.ToString());
            }
        }

        /// <summary>
        ///   Indicates that a client is closing, which may correspond to an <see cref="ServiceBusConnection" />,
        ///   <see cref="ServiceBusSender" />, <see cref="ServiceBusProcessor" />, or <see cref="ServiceBusReceiver"/>.
        /// </summary>
        ///
        /// <param name="clientType">The type of client being closed.</param>
        /// <param name="identifier">An identifier to associate with the client.</param>
        ///
        [Event(44, Level = EventLevel.Verbose, Message = "Closing an {0} (Identifier '{1}').")]
        public void ClientCloseStart(Type clientType,
                                     string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(44, clientType.Name, identifier ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that a client has been closed, which may correspond to an <see cref="ServiceBusConnection" />,
        ///   <see cref="ServiceBusSender" />, <see cref="ServiceBusProcessor" />, or <c>EventProcessorClient</c>.
        /// </summary>
        ///
        /// <param name="clientType">The type of client being closed.</param>
        /// <param name="identifier">An identifier to associate with the client.</param>
        ///
        [Event(45, Level = EventLevel.Verbose, Message = "An {0} has been closed (Identifier '{1}').")]
        public void ClientCloseComplete(Type clientType,
                                        string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(45, clientType.Name, identifier ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an exception was encountered while closing an <see cref="ServiceBusConnection" />,
        ///   <see cref="ServiceBusSender" />, <see cref="ServiceBusProcessor" />, or <c>EventProcessorClient</c>.
        /// </summary>
        ///
        /// <param name="clientType">The type of client being closed.</param>
        /// <param name="identifier">An identifier to associate with the client.</param>
        /// <param name="exception">The message for the exception that occurred.</param>
        ///
        [Event(46, Level = EventLevel.Error, Message = "An exception occurred while closing an {0} (Identifier '{2}'). Error Message: '{3}'")]
        public void ClientCloseException(Type clientType,
                                     string identifier,
                                     Exception exception)
        {
            if (IsEnabled())
            {
                WriteEvent(46, clientType.Name, identifier, exception.ToString());
            }
        }

        [Event(47, Level = EventLevel.Informational, Message = "{0}: RenewSessionLockAsync start. SessionId = {1}")]
        public void RenewSessionLockStart(string identifier, string sessionId)
        {
            if (IsEnabled())
            {
                WriteEvent(47, identifier, sessionId);
            }
        }

        [Event(48, Level = EventLevel.Informational, Message = "{0}: RenewSessionLockAsync done.")]
        public void RenewSessionLockComplete(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(48, identifier);
            }
        }

        [Event(49, Level = EventLevel.Error, Message = "{0}: RenewSessionLockAsync Exception: {1}.")]
        public void RenewSessionLockException(string identifier, Exception exception)
        {
            if (IsEnabled())
            {
                WriteEvent(49, identifier, exception.ToString());
            }
        }

        [Event(50, Level = EventLevel.Informational, Message = "{0}: StartProcessingAsync start.")]
        public void StartProcessingStart(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(50, identifier);
            }
        }

        [Event(51, Level = EventLevel.Informational, Message = "{0}: StartProcessingAsync done.")]
        public void StartProcessingComplete(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(51, identifier);
            }
        }

        [Event(52, Level = EventLevel.Error, Message = "{0}: StartProcessingAsync Exception: {1}.")]
        public void StartProcessingException(string identifier, Exception exception)
        {
            if (IsEnabled())
            {
                WriteEvent(52, identifier, exception.ToString());
            }
        }

        [Event(53, Level = EventLevel.Informational, Message = "{0}: StopProcessingAsync start.")]
        public void StopProcessingStart(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(53, identifier);
            }
        }

        [Event(54, Level = EventLevel.Informational, Message = "{0}: StopProcessingAsync done.")]
        public void StopProcessingComplete(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(54, identifier);
            }
        }

        [Event(55, Level = EventLevel.Error, Message = "{0}: StopProcessingAsync Exception: {1}.")]
        public void StopProcessingException(string identifier, Exception exception)
        {
            if (IsEnabled())
            {
                WriteEvent(55, identifier, exception.ToString());
            }
        }

    }
}
