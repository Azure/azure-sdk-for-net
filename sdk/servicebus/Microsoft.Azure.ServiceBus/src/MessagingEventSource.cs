// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Tracing;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Azure.Amqp;
    using Amqp;
    using Primitives;

    [EventSource(Name = "Microsoft-Azure-ServiceBus")]
    internal sealed class MessagingEventSource : EventSource
    {
        public static MessagingEventSource Log { get; } = new MessagingEventSource();

        [Event(1, Level = EventLevel.Informational, Message = "Creating QueueClient (Namespace '{0}'; Queue '{1}'; ReceiveMode '{2}').")]
        public void QueueClientCreateStart(string namespaceName, string queueName, string receiveMode)
        {
            if (IsEnabled())
            {
                WriteEvent(1, namespaceName ?? string.Empty, queueName, receiveMode);
            }
        }

        [Event(2, Level = EventLevel.Informational, Message = "QueueClient (Namespace '{0}'; Queue '{1}'; ClientId: '{2}' created).")]
        public void QueueClientCreateStop(string namespaceName, string queueName, string clientId)
        {
            if (IsEnabled())
            {
                WriteEvent(2, namespaceName, queueName, clientId);
            }
        }

        [Event(3, Level = EventLevel.Informational, Message = "Creating TopicClient (Namespace '{0}'; Topic '{1}').")]
        public void TopicClientCreateStart(string namespaceName, string topicName)
        {
            if (IsEnabled())
            {
                WriteEvent(3, namespaceName ?? string.Empty, topicName);
            }
        }

        [Event(4, Level = EventLevel.Informational, Message = "TopicClient (Namespace '{0}'; Topic '{1}'; ClientId: '{2}' created).")]
        public void TopicClientCreateStop(string namespaceName, string topicName, string clientId)
        {
            if (IsEnabled())
            {
                WriteEvent(4, namespaceName, topicName, clientId);
            }
        }

        [Event(5, Level = EventLevel.Informational, Message = "Creating SubscriptionClient (Namespace '{0}'; Topic '{1}'; Subscription '{2}'; ReceiveMode '{3}').")]
        public void SubscriptionClientCreateStart(string namespaceName, string topicName, string subscriptionName, string receiveMode)
        {
            if (IsEnabled())
            {
                WriteEvent(5, namespaceName, topicName ?? string.Empty, subscriptionName, receiveMode);
            }
        }

        [Event(6, Level = EventLevel.Informational, Message = "SubscriptionClient (Namespace '{0}'; Topic '{1}'; Subscription '{2}'; ClientId: '{3}' created).")]
        public void SubscriptionClientCreateStop(string namespaceName, string topicName, string subscriptionName, string clientId)
        {
            if (IsEnabled())
            {
                WriteEvent(6, namespaceName, topicName, subscriptionName, clientId);
            }
        }

        [Event(7, Level = EventLevel.Informational, Message = "{0}: SendAsync start. MessageCount = {1}")]
        public void MessageSendStart(string clientId, int messageCount)
        {
            if (IsEnabled())
            {
                WriteEvent(7, clientId, messageCount);
            }
        }

        [Event(8, Level = EventLevel.Informational, Message = "{0}: SendAsync done.")]
        public void MessageSendStop(string clientId)
        {
            if (IsEnabled())
            {
                WriteEvent(8, clientId);
            }
        }

        [NonEvent]
        public void MessageSendException(string clientId, Exception exception)
        {
            if (IsEnabled())
            {
                MessageSendException(clientId, exception.ToString());
            }
        }

        [Event(9, Level = EventLevel.Error, Message = "{0}: SendAsync Exception: {1}.")]
        private void MessageSendException(string clientId, string exception)
        {
            WriteEvent(9, clientId, exception);
        }

        [Event(10, Level = EventLevel.Informational, Message = "{0}: ReceiveAsync start. MessageCount = {1}")]
        public void MessageReceiveStart(string clientId, int messageCount)
        {
            if (IsEnabled())
            {
                WriteEvent(10, clientId, messageCount);
            }
        }

        [Event(11, Level = EventLevel.Informational, Message = "{0}: ReceiveAsync done. Received '{1}' messages")]
        public void MessageReceiveStop(string clientId, int messageCount)
        {
            if (IsEnabled())
            {
                WriteEvent(11, clientId, messageCount);
            }
        }

        [NonEvent]
        public void MessageReceiveException(string clientId, Exception exception)
        {
            if (IsEnabled())
            {
                MessageReceiveException(clientId, exception.ToString());
            }
        }

        [Event(12, Level = EventLevel.Error, Message = "{0}: ReceiveAsync Exception: {1}.")]
        private void MessageReceiveException(string clientId, string exception)
        {
            WriteEvent(12, clientId, exception);
        }

        [NonEvent]
        public void MessageCompleteStart(string clientId, int messageCount, IEnumerable<string> lockTokens)
        {
            if (IsEnabled())
            {
                var formattedLockTokens = StringUtility.GetFormattedLockTokens(lockTokens);
                MessageCompleteStart(clientId, messageCount, formattedLockTokens);
            }
        }

        [Event(13, Level = EventLevel.Informational, Message = "{0}: CompleteAsync start. MessageCount = {1}, LockTokens = {2}")]
        private void MessageCompleteStart(string clientId, int messageCount, string lockTokens)
        {
            WriteEvent(13, clientId, messageCount, lockTokens);
        }

        [Event(14, Level = EventLevel.Informational, Message = "{0}: CompleteAsync done.")]
        public void MessageCompleteStop(string clientId)
        {
            if (IsEnabled())
            {
                WriteEvent(14, clientId);
            }
        }

        [NonEvent]
        public void MessageCompleteException(string clientId, Exception exception)
        {
            if (IsEnabled())
            {
                MessageCompleteException(clientId, exception.ToString());
            }
        }

        [Event(15, Level = EventLevel.Error, Message = "{0}: CompleteAsync Exception: {1}.")]
        private void MessageCompleteException(string clientId, string exception)
        {
            WriteEvent(15, clientId, exception);
        }

        [Event(16, Level = EventLevel.Informational, Message = "{0}: AbandonAsync start. MessageCount = {1}, LockToken = {2}")]
        public void MessageAbandonStart(string clientId, int messageCount, string lockToken)
        {
            if (IsEnabled())
            {
                WriteEvent(16, clientId, messageCount, lockToken);
            }
        }

        [Event(17, Level = EventLevel.Informational, Message = "{0}: AbandonAsync done.")]
        public void MessageAbandonStop(string clientId)
        {
            if (IsEnabled())
            {
                WriteEvent(17, clientId);
            }
        }

        [NonEvent]
        public void MessageAbandonException(string clientId, Exception exception)
        {
            if (IsEnabled())
            {
                MessageAbandonException(clientId, exception.ToString());
            }
        }

        [Event(18, Level = EventLevel.Error, Message = "{0}: AbandonAsync Exception: {1}.")]
        private void MessageAbandonException(string clientId, string exception)
        {
            WriteEvent(18, clientId, exception);
        }

        [Event(19, Level = EventLevel.Informational, Message = "{0}: DeferAsync start. MessageCount = {1}, LockToken = {2}")]
        public void MessageDeferStart(string clientId, int messageCount, string lockToken)
        {
            if (IsEnabled())
            {
                WriteEvent(19, clientId, messageCount, lockToken);
            }
        }

        [Event(20, Level = EventLevel.Informational, Message = "{0}: DeferAsync done.")]
        public void MessageDeferStop(string clientId)
        {
            if (IsEnabled())
            {
                WriteEvent(20, clientId);
            }
        }

        [NonEvent]
        public void MessageDeferException(string clientId, Exception exception)
        {
            if (IsEnabled())
            {
                MessageDeferException(clientId, exception.ToString());
            }
        }

        [Event(21, Level = EventLevel.Error, Message = "{0}: DeferAsync Exception: {1}.")]
        private void MessageDeferException(string clientId, string exception)
        {
                WriteEvent(21, clientId, exception);
        }

        [Event(22, Level = EventLevel.Informational, Message = "{0}: DeadLetterAsync start. MessageCount = {1}, LockToken = {2}")]
        public void MessageDeadLetterStart(string clientId, int messageCount, string lockToken)
        {
            if (IsEnabled())
            {
                WriteEvent(22, clientId, messageCount, lockToken);
            }
        }

        [Event(23, Level = EventLevel.Informational, Message = "{0}: DeadLetterAsync done.")]
        public void MessageDeadLetterStop(string clientId)
        {
            if (IsEnabled())
            {
                WriteEvent(23, clientId);
            }
        }

        [NonEvent]
        public void MessageDeadLetterException(string clientId, Exception exception)
        {
            if (IsEnabled())
            {
                MessageDeadLetterException(clientId, exception.ToString());
            }
        }

        [Event(24, Level = EventLevel.Error, Message = "{0}: DeadLetterAsync Exception: {1}.")]
        private void MessageDeadLetterException(string clientId, string exception)
        {
            WriteEvent(24, clientId, exception);
        }

        [Event(25, Level = EventLevel.Informational, Message = "{0}: RenewLockAsync start. MessageCount = {1}, LockToken = {2}")]
        public void MessageRenewLockStart(string clientId, int messageCount, string lockToken)
        {
            if (IsEnabled())
            {
                WriteEvent(25, clientId, messageCount, lockToken);
            }
        }

        [Event(26, Level = EventLevel.Informational, Message = "{0}: RenewLockAsync done.")]
        public void MessageRenewLockStop(string clientId)
        {
            if (IsEnabled())
            {
                WriteEvent(26, clientId);
            }
        }

        [NonEvent]
        public void MessageRenewLockException(string clientId, Exception exception)
        {
            if (IsEnabled())
            {
                MessageRenewLockException(clientId, exception.ToString());
            }
        }

        [Event(27, Level = EventLevel.Error, Message = "{0}: RenewLockAsync Exception: {1}.")]
        private void MessageRenewLockException(string clientId, string exception)
        {
            WriteEvent(27, clientId, exception);
        }

        [NonEvent]
        public void MessageReceiveDeferredMessageStart(string clientId, int messageCount, IEnumerable<long> sequenceNumbers)
        {
            if (IsEnabled())
            {
                var formattedSequenceNumbers = StringUtility.GetFormattedSequenceNumbers(sequenceNumbers);
                MessageReceiveDeferredMessageStart(clientId, messageCount, formattedSequenceNumbers);
            }
        }

        [Event(28, Level = EventLevel.Informational, Message = "{0}: ReceiveDeferredMessageAsync start. MessageCount = {1}, LockTokens = {2}")]
        private void MessageReceiveDeferredMessageStart(string clientId, int messageCount, string sequenceNumbers)
        {
            WriteEvent(28, clientId, messageCount, sequenceNumbers);
        }

        [Event(29, Level = EventLevel.Informational, Message = "{0}: ReceiveDeferredMessageAsync done. Received '{1}' messages")]
        public void MessageReceiveDeferredMessageStop(string clientId, int messageCount)
        {
            if (IsEnabled())
            {
                WriteEvent(29, clientId, messageCount);
            }
        }

        [NonEvent]
        public void MessageReceiveDeferredMessageException(string clientId, Exception exception)
        {
            if (IsEnabled())
            {
                MessageReceiveDeferredMessageException(clientId, exception.ToString());
            }
        }

        [Event(30, Level = EventLevel.Error, Message = "{0}: ReceiveDeferredMessageAsync Exception: {1}.")]
        private void MessageReceiveDeferredMessageException(string clientId, string exception)
        {
            WriteEvent(30, clientId, exception);
        }

        // Unused - 31;32;33

        [NonEvent]
        public void AmqpSendLinkCreateStart(string clientId, MessagingEntityType? entityType, string entityPath)
        {
            if (IsEnabled())
            {
                AmqpSendLinkCreateStart(clientId, entityType?.ToString() ?? string.Empty, entityPath);
            }
        }

        [Event(34, Level = EventLevel.Informational, Message = "{0}: AmqpSendLinkCreate started. EntityType: {1}, EntityPath: {2}")]
        private void AmqpSendLinkCreateStart(string clientId, string entityType, string entityPath)
        {
            WriteEvent(34, clientId, entityType, entityPath);
        }

        [Event(35, Level = EventLevel.Informational, Message = "{0}: AmqpSendLinkCreate done.")]
        public void AmqpSendLinkCreateStop(string clientId)
        {
            if (IsEnabled())
            {
                WriteEvent(35, clientId);
            }
        }

        [NonEvent]
        public void AmqpReceiveLinkCreateStart(string clientId, bool isRequestResponseLink, MessagingEntityType? entityType, string entityPath)
        {
            if (IsEnabled())
            {
                AmqpReceiveLinkCreateStart(clientId, isRequestResponseLink.ToString(), entityType?.ToString() ?? string.Empty, entityPath);
            }
        }

        [Event(36, Level = EventLevel.Informational, Message = "{0}: AmqpReceiveLinkCreate started. IsRequestResponseLink: {1},  EntityType: {1}, EntityPath: {2}")]
        private void AmqpReceiveLinkCreateStart(string clientId, string isRequestResponseLink, string entityType, string entityPath)
        {
            WriteEvent(36, clientId, isRequestResponseLink, entityType, entityPath);
        }

        [Event(37, Level = EventLevel.Informational, Message = "{0}: AmqpReceiveLinkCreate done.")]
        public void AmqpReceiveLinkCreateStop(string clientId)
        {
            if (IsEnabled())
            {
                WriteEvent(37, clientId);
            }
        }

        [Event(38, Level = EventLevel.Verbose, Message = "AmqpGetOrCreateConnection started.")]
        public void AmqpGetOrCreateConnectionStart()
        {
            if (IsEnabled())
            {
                WriteEvent(38);
            }
        }

        [Event(39, Level = EventLevel.Verbose, Message = "AmqpGetOrCreateConnection done. EntityPath: {0}, ConnectionInfo: {1}, ConnectionState: {2}")]
        public void AmqpGetOrCreateConnectionStop(string entityPath, string connectionInfo, string connectionState)
        {
            if (IsEnabled())
            {
                WriteEvent(39, entityPath, connectionInfo, connectionState);
            }
        }

        [NonEvent]
        public void AmqpSendAuthenticationTokenStart(Uri address, string audience, string resource, string[] claims)
        {
            if (IsEnabled())
            {
                AmqpSendAuthenticationTokenStart(address.ToString(), audience, resource, claims.ToString());
            }
        }

        [Event(40, Level = EventLevel.Verbose, Message = "AmqpSendAuthenticanToken started. Address: {0}, Audience: {1}, Resource: {2}, Claims: {3}")]
        private void AmqpSendAuthenticationTokenStart(string address, string audience, string resource, string claims)
        {
            WriteEvent(40, address, audience, resource, claims);
        }

        [Event(41, Level = EventLevel.Verbose, Message = "AmqpSendAuthenticanToken done.")]
        public void AmqpSendAuthenticationTokenStop()
        {
            if (IsEnabled())
            {
                WriteEvent(41);
            }
        }

        [Event(42, Level = EventLevel.Informational, Message = "{0}: MessagePeekAsync start. SequenceNumber = {1}, MessageCount = {2}")]
        public void MessagePeekStart(string clientId, long sequenceNumber, int messageCount)
        {
            if (IsEnabled())
            {
                WriteEvent(42, clientId, sequenceNumber, messageCount);
            }
        }

        [Event(43, Level = EventLevel.Informational, Message = "{0}: MessagePeekAsync done. Peeked '{1}' messages")]
        public void MessagePeekStop(string clientId, int messageCount)
        {
            if (IsEnabled())
            {
                WriteEvent(43, clientId, messageCount);
            }
        }

        [NonEvent]
        public void MessagePeekException(string clientId, Exception exception)
        {
            if (IsEnabled())
            {
                MessagePeekException(clientId, exception.ToString());
            }
        }

        [Event(44, Level = EventLevel.Error, Message = "{0}: MessagePeekAsync Exception: {1}.")]
        private void MessagePeekException(string clientId, string exception)
        {
            WriteEvent(44, clientId, exception);
        }

        [Event(45, Level = EventLevel.Informational, Message = "Creating MessageSender (Namespace '{0}'; Entity '{1}').")]
        public void MessageSenderCreateStart(string namespaceName, string entityName)
        {
            if (IsEnabled())
            {
                WriteEvent(45, namespaceName, entityName);
            }
        }

        [Event(46, Level = EventLevel.Informational, Message = "MessageSender (Namespace '{0}'; Entity '{1}'; ClientId '{2}' created).")]
        public void MessageSenderCreateStop(string namespaceName, string entityName, string clientId)
        {
            if (IsEnabled())
            {
                WriteEvent(46, namespaceName, entityName, clientId);
            }
        }

        [Event(47, Level = EventLevel.Informational, Message = "Creating MessageReceiver (Namespace '{0}'; Entity '{1}'; ReceiveMode '{2}').")]
        public void MessageReceiverCreateStart(string namespaceName, string entityName, string receiveMode)
        {
            if (IsEnabled())
            {
                WriteEvent(47, namespaceName, entityName, receiveMode);
            }
        }

        [Event(48, Level = EventLevel.Informational, Message = "MessageReceiver (Namespace '{0}'; Entity '{1}'; ClientId '{2}' created).")]
        public void MessageReceiverCreateStop(string namespaceName, string entityName, string clientId)
        {
            if (IsEnabled())
            {
                WriteEvent(48, namespaceName, entityName, clientId);
            }
        }

        [NonEvent]
        public void ScheduleMessageStart(string clientId, DateTimeOffset scheduleEnqueueTimeUtc)
        {
            if (IsEnabled())
            {
                ScheduleMessageStart(clientId, scheduleEnqueueTimeUtc.ToString());
            }
        }

        [Event(49, Level = EventLevel.Informational, Message = "{0}: ScheduleMessageAsync start. ScheduleTimeUtc = {1}")]
        private void ScheduleMessageStart(string clientId, string scheduleEnqueueTimeUtc)
        {
            if (IsEnabled())
            {
                WriteEvent(49, clientId, scheduleEnqueueTimeUtc);
            }
        }

        [Event(50, Level = EventLevel.Informational, Message = "{0}: ScheduleMessageAsync done.")]
        public void ScheduleMessageStop(string clientId)
        {
            if (IsEnabled())
            {
                WriteEvent(50, clientId);
            }
        }

        [NonEvent]
        public void ScheduleMessageException(string clientId, Exception exception)
        {
            if (IsEnabled())
            {
                ScheduleMessageException(clientId, exception.ToString());
            }
        }

        [Event(51, Level = EventLevel.Error, Message = "{0}: ScheduleMessageAsync Exception: {1}.")]
        private void ScheduleMessageException(string clientId, string exception)
        {
            WriteEvent(51, clientId, exception);
        }

        [Event(52, Level = EventLevel.Informational, Message = "{0}: CancelScheduledMessageAsync start. SequenceNumber = {1}")]
        public void CancelScheduledMessageStart(string clientId, long sequenceNumber)
        {
            if (IsEnabled())
            {
                WriteEvent(52, clientId, sequenceNumber);
            }
        }

        [Event(53, Level = EventLevel.Informational, Message = "{0}: CancelScheduledMessageAsync done.")]
        public void CancelScheduledMessageStop(string clientId)
        {
            if (IsEnabled())
            {
                WriteEvent(53, clientId);
            }
        }

        [NonEvent]
        public void CancelScheduledMessageException(string clientId, Exception exception)
        {
            if (IsEnabled())
            {
                CancelScheduledMessageException(clientId, exception.ToString());
            }
        }

        [Event(54, Level = EventLevel.Error, Message = "{0}: CancelScheduledMessageAsync Exception: {1}.")]
        private void CancelScheduledMessageException(string clientId, string exception)
        {
            WriteEvent(54, clientId, exception);
        }

        [Event(55, Level = EventLevel.Informational, Message = "{0}: AddRuleAsync start. RuleName = {1}")]
        public void AddRuleStart(string clientId, string ruleName)
        {
            if (IsEnabled())
            {
                WriteEvent(55, clientId, ruleName);
            }
        }

        [Event(56, Level = EventLevel.Informational, Message = "{0}: AddRuleAsync done.")]
        public void AddRuleStop(string clientId)
        {
            if (IsEnabled())
            {
                WriteEvent(56, clientId);
            }
        }

        [NonEvent]
        public void AddRuleException(string clientId, Exception exception)
        {
            if (IsEnabled())
            {
                AddRuleException(clientId, exception.ToString());
            }
        }

        [Event(57, Level = EventLevel.Error, Message = "{0}: AddRuleAsync Exception: {1}.")]
        private void AddRuleException(string clientId, string exception)
        {
            WriteEvent(57, clientId, exception);
        }

        [Event(58, Level = EventLevel.Informational, Message = "{0}: RemoveRuleAsync start. RuleName = {1}")]
        public void RemoveRuleStart(string clientId, string ruleName)
        {
            if (IsEnabled())
            {
                WriteEvent(58, clientId, ruleName);
            }
        }

        [Event(59, Level = EventLevel.Informational, Message = "{0}: RemoveRuleAsync done.")]
        public void RemoveRuleStop(string clientId)
        {
            if (IsEnabled())
            {
                WriteEvent(59, clientId);
            }
        }

        [NonEvent]
        public void RemoveRuleException(string clientId, Exception exception)
        {
            if (IsEnabled())
            {
                RemoveRuleException(clientId, exception.ToString());
            }
        }

        [Event(60, Level = EventLevel.Error, Message = "{0}: RemoveRuleAsync Exception: {1}.")]
        private void RemoveRuleException(string clientId, string exception)
        {
            WriteEvent(60, clientId, exception);
        }

        [NonEvent]
        public void RegisterOnMessageHandlerStart(string clientId, MessageHandlerOptions registerHandlerOptions)
        {
            if (IsEnabled())
            {
                RegisterOnMessageHandlerStart(clientId, registerHandlerOptions.AutoComplete, registerHandlerOptions.AutoRenewLock, registerHandlerOptions.MaxConcurrentCalls, (long)registerHandlerOptions.MaxAutoRenewDuration.TotalSeconds);
            }
        }

        [Event(61, Level = EventLevel.Informational, Message = "{0}: Register OnMessageHandler start: OnMessage Options: AutoComplete: {1}, AutoRenewLock: {2}, MaxConcurrentCalls: {3}, AutoRenewTimeout: {4}")]
        private void RegisterOnMessageHandlerStart(string clientId, bool autoComplete, bool autorenewLock, int maxConcurrentCalls, long autorenewTimeoutInSeconds)
        {
            WriteEvent(61, clientId, autoComplete, autorenewLock, maxConcurrentCalls, autorenewTimeoutInSeconds);
        }

        [Event(62, Level = EventLevel.Informational, Message = "{0}: Register OnMessageHandler done.")]
        public void RegisterOnMessageHandlerStop(string clientId)
        {
            if (IsEnabled())
            {
                WriteEvent(62, clientId);
            }
        }

        [NonEvent]
        public void RegisterOnMessageHandlerException(string clientId, Exception exception)
        {
            if (IsEnabled())
            {
                RegisterOnMessageHandlerException(clientId, exception.ToString());
            }
        }

        [Event(63, Level = EventLevel.Error, Message = "{0}: Register OnMessageHandler Exception: {1}")]
        private void RegisterOnMessageHandlerException(string clientId, string exception)
        {
            WriteEvent(63, clientId, exception);
        }

        [NonEvent]
        public void MessageReceiverPumpTaskStart(string clientId, Message message, int currentSemaphoreCount)
        {
            if (IsEnabled())
            {
                MessageReceiverPumpTaskStart(clientId, message?.SystemProperties.SequenceNumber ?? -1, currentSemaphoreCount);
            }
        }

        [Event(66, Level = EventLevel.Informational, Message = "{0}: MessageReceiverPump PumpTask Started: Message: SequenceNumber: {1}, Available Semaphore Count: {2}")]
        private void MessageReceiverPumpTaskStart(string clientId, long sequenceNumber, int currentSemaphoreCount)
        {
            WriteEvent(66, clientId, sequenceNumber, currentSemaphoreCount);
        }

        [Event(67, Level = EventLevel.Informational, Message = "{0}: MessageReceiverPump PumpTask done: Available Semaphore Count: {1}")]
        public void MessageReceiverPumpTaskStop(string clientId, int currentSemaphoreCount)
        {
            if (IsEnabled())
            {
                WriteEvent(67, clientId, currentSemaphoreCount);
            }
        }

        [NonEvent]
        public void MessageReceivePumpTaskException(string clientId, string sessionId, Exception exception)
        {
            if (IsEnabled())
            {
                MessageReceivePumpTaskException(clientId, sessionId, exception.ToString());
            }
        }

        [Event(68, Level = EventLevel.Error, Message = "{0}: MessageReceiverPump PumpTask Exception: SessionId: {1}, Exception: {2}")]
        private void MessageReceivePumpTaskException(string clientId, string sessionId, string exception)
        {
            WriteEvent(68, clientId, sessionId, exception);
        }

        [NonEvent]
        public void MessageReceiverPumpDispatchTaskStart(string clientId, Message message)
        {
            if (IsEnabled())
            {
                MessageReceiverPumpDispatchTaskStart(clientId, message?.SystemProperties.SequenceNumber ?? -1);
            }
        }

        [Event(69, Level = EventLevel.Informational, Message = "{0}: MessageReceiverPump DispatchTask start: Message: SequenceNumber: {1}")]
        private void MessageReceiverPumpDispatchTaskStart(string clientId, long sequenceNumber)
        {
            WriteEvent(69, clientId, sequenceNumber);
        }

        [NonEvent]
        public void MessageReceiverPumpDispatchTaskStop(string clientId, Message message, int currentSemaphoreCount)
        {
            if (IsEnabled())
            {
                MessageReceiverPumpDispatchTaskStop(clientId, message?.SystemProperties.SequenceNumber ?? -1, currentSemaphoreCount);
            }
        }

        [Event(70, Level = EventLevel.Informational, Message = "{0}: MessageReceiverPump DispatchTask done: Message: SequenceNumber: {1}, Current Semaphore Count: {2}")]
        private void MessageReceiverPumpDispatchTaskStop(string clientId, long sequenceNumber, int currentSemaphoreCount)
        {
            WriteEvent(70, clientId, sequenceNumber, currentSemaphoreCount);
        }

        [NonEvent]
        public void MessageReceiverPumpUserCallbackStart(string clientId, Message message)
        {
            if (IsEnabled())
            {
                MessageReceiverPumpUserCallbackStart(clientId, message?.SystemProperties.SequenceNumber ?? -1);
            }
        }

        [Event(71, Level = EventLevel.Informational, Message = "{0}: MessageReceiverPump UserCallback start: Message: SequenceNumber: {1}")]
        private void MessageReceiverPumpUserCallbackStart(string clientId, long sequenceNumber)
        {
            WriteEvent(71, clientId, sequenceNumber);
        }

        [NonEvent]
        public void MessageReceiverPumpUserCallbackStop(string clientId, Message message)
        {
            if (IsEnabled())
            {
                MessageReceiverPumpUserCallbackStop(clientId, message?.SystemProperties.SequenceNumber ?? -1);
            }
        }

        [Event(72, Level = EventLevel.Informational, Message = "{0}: MessageReceiverPump UserCallback done: Message: SequenceNumber: {1}")]
        private void MessageReceiverPumpUserCallbackStop(string clientId, long sequenceNumber)
        {
            WriteEvent(72, clientId, sequenceNumber);
        }

        [NonEvent]
        public void MessageReceiverPumpUserCallbackException(string clientId, Message message, Exception exception)
        {
            if (IsEnabled())
            {
                MessageReceiverPumpUserCallbackException(clientId, message?.SystemProperties.SequenceNumber ?? -1, exception.ToString());
            }
        }

        [Event(73, Level = EventLevel.Error, Message = "{0}: MessageReceiverPump UserCallback Exception: Message: SequenceNumber: {1}, Exception: {2}")]
        private void MessageReceiverPumpUserCallbackException(string clientId, long sequenceNumber, string exception)
        {
            WriteEvent(73, clientId, sequenceNumber, exception);
        }

        [NonEvent]
        public void MessageReceiverPumpRenewMessageStart(string clientId, Message message, TimeSpan renewAfterTimeSpan)
        {
            if (IsEnabled())
            {
                MessageReceiverPumpRenewMessageStart(clientId, message?.SystemProperties.SequenceNumber ?? -1, (long)renewAfterTimeSpan.TotalSeconds);
            }
        }

        [Event(74, Level = EventLevel.Informational, Message = "{0}: MessageReceiverPump RenewMessage start: Message: SequenceNumber: {1}, RenewAfterTimeInSeconds: {2}")]
        private void MessageReceiverPumpRenewMessageStart(string clientId, long sequenceNumber, long renewAfterTimeSpanInSeconds)
        {
            WriteEvent(74, clientId, sequenceNumber, renewAfterTimeSpanInSeconds);
        }

        [NonEvent]
        public void MessageReceiverPumpRenewMessageStop(string clientId, Message message)
        {
            if (IsEnabled())
            {
                MessageReceiverPumpRenewMessageStop(clientId, message?.SystemProperties.SequenceNumber ?? -1);
            }
        }

        [Event(75, Level = EventLevel.Informational, Message = "{0}: MessageReceiverPump RenewMessage done: Message: SequenceNumber: {1}")]
        private void MessageReceiverPumpRenewMessageStop(string clientId, long sequenceNumber)
        {
            WriteEvent(75, clientId, sequenceNumber);
        }

        [NonEvent]
        public void MessageReceiverPumpRenewMessageException(string clientId, Message message, Exception exception)
        {
            if (IsEnabled())
            {
                MessageReceiverPumpRenewMessageException(clientId, message?.SystemProperties.SequenceNumber ?? -1, exception.ToString());
            }
        }

        [Event(76, Level = EventLevel.Error, Message = "{0}: MessageReceiverPump RenewMessage Exception: Message: SequenceNumber: {1}, Exception: {2}")]
        private void MessageReceiverPumpRenewMessageException(string clientId, long sequenceNumber, string exception)
        {
            WriteEvent(76, clientId, sequenceNumber, exception);
        }

        [NonEvent]
        public void RunOperationExceptionEncountered(Exception exception)
        {
            if (IsEnabled())
            {
                RunOperationExceptionEncountered(exception.ToString());
            }
        }

        [Event(77, Level = EventLevel.Warning, Message = "RunOperation encountered an exception and will retry. Exception: {0}")]
        private void RunOperationExceptionEncountered(string exception)
        {
            WriteEvent(77, exception);
        }

        [NonEvent]
        public void RegisterOnSessionHandlerStart(string clientId, SessionHandlerOptions sessionHandlerOptions)
        {
            if (IsEnabled())
            {
                RegisterOnSessionHandlerStart(clientId, sessionHandlerOptions.AutoComplete, sessionHandlerOptions.MaxConcurrentSessions, (long)sessionHandlerOptions.MessageWaitTimeout.TotalSeconds, (long)sessionHandlerOptions.MaxAutoRenewDuration.TotalSeconds);
            }
        }

        [Event(78, Level = EventLevel.Informational, Message = "{0}: Register OnSessionHandler start: RegisterSessionHandler Options: AutoComplete: {1}, MaxConcurrentSessions: {2}, MessageWaitTimeout: {3}, AutoRenewTimeout: {4}")]
        private void RegisterOnSessionHandlerStart(string clientId, bool autoComplete, int maxConcurrentSessions, long messageWaitTimeoutInSeconds, long autorenewTimeoutInSeconds)
        {
            WriteEvent(78, clientId, autoComplete, maxConcurrentSessions, messageWaitTimeoutInSeconds, autorenewTimeoutInSeconds);
        }

        [Event(79, Level = EventLevel.Informational, Message = "{0}: Register OnSessionHandler done.")]
        public void RegisterOnSessionHandlerStop(string clientId)
        {
            if (IsEnabled())
            {
                WriteEvent(79, clientId);
            }
        }

        [NonEvent]
        public void RegisterOnSessionHandlerException(string clientId, Exception exception)
        {
            if (IsEnabled())
            {
                RegisterOnSessionHandlerException(clientId, exception.ToString());
            }
        }

        [Event(80, Level = EventLevel.Error, Message = "{0}: Register OnSessionHandler Exception: {1}")]
        private void RegisterOnSessionHandlerException(string clientId, string exception)
        {
            WriteEvent(80, clientId, exception);
        }

        [NonEvent]
        public void SessionReceivePumpSessionReceiveException(string clientId, Exception exception)
        {
            if (IsEnabled())
            {
                SessionReceivePumpSessionReceiveException(clientId, exception.ToString());
            }
        }

        [Event(81, Level = EventLevel.Error, Message = "{0}: Exception while Receving a session: SessionId: {1}")]
        private void SessionReceivePumpSessionReceiveException(string clientId, string exception)
        {
            WriteEvent(81, clientId, exception);
        }

        [Event(82, Level = EventLevel.Informational, Message = "{0}: Session has no more messages: SessionId: {1}")]
        public void SessionReceivePumpSessionEmpty(string clientId, string sessionId)
        {
            if (IsEnabled())
            {
                WriteEvent(82, clientId, sessionId);
            }
        }

        [Event(83, Level = EventLevel.Informational, Message = "{0}: Session closed: SessionId: {1}")]
        public void SessionReceivePumpSessionClosed(string clientId, string sessionId)
        {
            if (IsEnabled())
            {
                WriteEvent(83, clientId, sessionId);
            }
        }

        [NonEvent]
        public void SessionReceivePumpSessionCloseException(string clientId, string sessionId, Exception exception)
        {
            if (IsEnabled())
            {
                SessionReceivePumpSessionCloseException(clientId, sessionId, exception.ToString());
            }
        }

        [Event(84, Level = EventLevel.Error, Message = "{0}: Exception while closing session: SessionId: {1}, Exception: {2}")]
        private void SessionReceivePumpSessionCloseException(string clientId, string sessionId, string exception)
        {
            WriteEvent(84, clientId, sessionId, exception);
        }

        [NonEvent]
        public void SessionReceivePumpSessionRenewLockStart(string clientId, string sessionId, TimeSpan renewAfterTimeSpan)
        {
            if (IsEnabled())
            {
                SessionReceivePumpSessionRenewLockStart(clientId, sessionId, (long)renewAfterTimeSpan.TotalSeconds);
            }
        }

        [Event(85, Level = EventLevel.Informational, Message = "{0}: SessionRenewLock start. SessionId: {1}, RenewAfterTimeInSeconds: {2}")]
        private void SessionReceivePumpSessionRenewLockStart(string clientId, string sessionId, long totalSeconds)
        {
            WriteEvent(85, clientId, sessionId, totalSeconds);
        }

        [Event(86, Level = EventLevel.Informational, Message = "{0}: RenewSession done: SessionId: {1}")]
        public void SessionReceivePumpSessionRenewLockStop(string clientId, string sessionId)
        {
            if (IsEnabled())
            {
                WriteEvent(86, clientId, sessionId);
            }
        }

        [NonEvent]
        public void SessionReceivePumpSessionRenewLockException(string clientId, string sessionId, Exception exception)
        {
            if (IsEnabled())
            {
                SessionReceivePumpSessionRenewLockException(clientId, sessionId, exception.ToString());
            }
        }

        [Event(87, Level = EventLevel.Error, Message = "{0}: Exception while renewing session lock: SessionId: {1}, Exception: {2}")]
        private void SessionReceivePumpSessionRenewLockException(string clientId, string sessionId, string exception)
        {
            WriteEvent(87, clientId, sessionId, exception);
        }

        [NonEvent]
        public void AmqpSessionClientAcceptMessageSessionStart(string clientId, string entityPath, ReceiveMode receiveMode, int prefetchCount, string sessionId)
        {
            if (IsEnabled())
            {
                AmqpSessionClientAcceptMessageSessionStart(clientId, entityPath, receiveMode.ToString(), prefetchCount, sessionId ?? string.Empty);
            }
        }

        [Event(88, Level = EventLevel.Informational, Message = "{0}: AcceptMessageSession start: EntityPath: {1}, ReceiveMode: {2}, PrefetchCount: {3}, SessionId: {4}")]
        private void AmqpSessionClientAcceptMessageSessionStart(string clientId, string entityPath, string receiveMode, int prefetchCount, string sessionId)
        {
            WriteEvent(88, clientId, entityPath, receiveMode, prefetchCount, sessionId);
        }

        [Event(89, Level = EventLevel.Informational, Message = "{0}: AcceptMessageSession done: EntityPath: {1}, SessionId: {2}")]
        public void AmqpSessionClientAcceptMessageSessionStop(string clientId, string entityPath, string sessionId)
        {
            if (IsEnabled())
            {
                WriteEvent(89, clientId, entityPath, sessionId);
            }
        }

        [NonEvent]
        public void AmqpSessionClientAcceptMessageSessionException(string clientId, string entityPath, Exception exception)
        {
            if (IsEnabled())
            {
                AmqpSessionClientAcceptMessageSessionException(clientId, entityPath, exception.ToString());
            }
        }

        [Event(90, Level = EventLevel.Error, Message = "{0}: AcceptMessageSession Exception: EntityPath: {1}, Exception: {2}")]
        private void AmqpSessionClientAcceptMessageSessionException(string clientId, string entityPath, string exception)
        {
            WriteEvent(90, clientId, entityPath, exception);
        }

        [NonEvent]
        public void AmqpLinkCreationException(string entityPath, AmqpSession session, AmqpConnection connection, Exception exception)
        {
            if (IsEnabled())
            {
                AmqpLinkCreationException(entityPath, session.ToString(), session.State.ToString(), session.GetInnerException()?.ToString() ?? string.Empty, connection.ToString(), connection.State.ToString(), exception.ToString());
            }
        }

        [Event(91, Level = EventLevel.Error, Message = "AmqpLinkCreatorException Exception: EntityPath: {0}, SessionString: {1}, SessionState: {2}, TerminalException: {3}, ConnectionInfo: {4}, ConnectionState: {5}, Exception: {6}")]
        private void AmqpLinkCreationException(string entityPath, string session, string sessionState, string terminalException,  string connectionInfo, string connectionState, string exception)
        {
            WriteEvent(91, entityPath, session, sessionState, terminalException, connectionInfo, connectionState, exception);
        }

        [NonEvent]
        public void AmqpConnectionCreated(string hostName, AmqpConnection connection)
        {
            if (IsEnabled())
            {
                AmqpConnectionCreated(hostName, connection.ToString(), connection.State.ToString());
            }
        }

        [Event(92, Level = EventLevel.Verbose, Message = "AmqpConnectionCreated: HostName: {0}, ConnectionInfo: {1}, ConnectionState: {2}")]
        private void AmqpConnectionCreated(string hostName, string connectionInfo, string connectionState)
        {
            WriteEvent(92, hostName, connectionInfo, connectionState);
        }

        [NonEvent]
        public void AmqpConnectionClosed(AmqpConnection connection)
        {
            if (IsEnabled())
            {
                AmqpConnectionClosed(connection.RemoteEndpoint, connection.ToString(), connection.State.ToString());
            }
        }

        [Event(93, Level = EventLevel.Verbose, Message = "AmqpConnectionClosed: HostName: {0}, ConnectionInfo: {1}, ConnectionState: {2}")]
        public void AmqpConnectionClosed(string hostName, string connectionInfo, string connectionState)
        {
            WriteEvent(93, hostName, connectionInfo, connectionState);
        }

        [NonEvent]
        public void AmqpSessionCreationException(string entityPath, AmqpConnection connection, Exception exception)
        {
            if (IsEnabled())
            {
                AmqpSessionCreationException(entityPath, connection.ToString(), connection.State.ToString(), exception.ToString());
            }
        }

        [Event(94, Level = EventLevel.Error, Message = "AmqpSessionCreationException Exception: EntityPath: {0}, ConnectionInfo: {1}, ConnectionState: {2}, Exception: {3}")]
        private void AmqpSessionCreationException(string entityPath, string connectionInfo, string connectionState, string exception)
        {
            WriteEvent(94, entityPath, connectionInfo, connectionState, exception);
        }

        [Event(95, Level = EventLevel.Verbose, Message = "User plugin {0} called on message {1}")]
        public void PluginCallStarted(string pluginName, string messageId)
        {
            if (IsEnabled())
            {
                WriteEvent(95, pluginName, messageId);
            }
        }

        [Event(96, Level = EventLevel.Verbose, Message = "User plugin {0} completed on message {1}")]
        public void PluginCallCompleted(string pluginName, string messageId)
        {
            if (IsEnabled())
            {
                WriteEvent(96, pluginName, messageId);
            }
        }

        [NonEvent]
        public void PluginCallFailed(string pluginName, string messageId, Exception exception)
        {
            if (IsEnabled())
            {
                PluginCallFailed(pluginName, messageId, exception.ToString());
            }
        }

        [Event(97, Level = EventLevel.Error, Message = "Exception during {0} plugin execution. MessageId: {1}, Exception {2}")]
        private void PluginCallFailed(string pluginName, string messageId, string exception)
        {
            WriteEvent(97, pluginName, messageId, exception);
        }

        [NonEvent]
        public void ScheduleTaskFailed(Func<Task> task, Exception exception)
        {
            if (IsEnabled())
            {
                ScheduleTaskFailed(task.Target.GetType().FullName, task.GetMethodInfo().Name, exception.ToString());
            }
        }

        [Event(98, Level = EventLevel.Error, Message = "Exception during Schedule Task. FunctionTargetName: {0}, MethodInfoName: {1}, Exception:{2}")]
        private void ScheduleTaskFailed(string funcTargetName, string methodInfoName, string exception)
        {
            WriteEvent(98, funcTargetName, methodInfoName, exception);
        }

        [NonEvent]
        public void ExceptionReceivedHandlerThrewException(Exception exception)
        {
            if (IsEnabled())
            {
                ExceptionReceivedHandlerThrewException(exception.ToString());
            }
        }

        [Event(99, Level = EventLevel.Error, Message = "ExceptionReceivedHandler threw exception. Exception:{0}")]
        private void ExceptionReceivedHandlerThrewException(string exception)
        {
            WriteEvent(99, exception);
        }

        [NonEvent]
        public void LinkStateLost(string clientId, string receiveLinkName, AmqpObjectState receiveLinkState, bool isSessionReceiver, Exception exception)
        {
            if (IsEnabled())
            {
                LinkStateLost(clientId, receiveLinkName, receiveLinkState.ToString(), isSessionReceiver, exception.ToString());
            }
        }

        [Event(100, Level = EventLevel.Error, Message = "Link state lost. Throwing LockLostException for clientId: {0}, receiveLinkName: {1}, receiveLinkState: {2}, isSessionReceiver: {3}, exception: {4}.")]
        private void LinkStateLost(string clientId, string receiveLinkName, string receiveLinkState, bool isSessionReceiver, string exception)
        {
            WriteEvent(100, clientId, receiveLinkName, receiveLinkState, isSessionReceiver, exception);
        }

        [Event(101, Level = EventLevel.Informational, Message = "Updating client id. OldClientId: {0}, NewClientId: {1}")]
        public void UpdateClientId(string oldClientId, string newClientId)
        {
            if (IsEnabled())
            {
                WriteEvent(101, oldClientId, newClientId);
            }
        }

        [Event(102, Level = EventLevel.Informational, Message = "{0}: GetRulesException start.")]
        public void GetRulesStart(string clientId)
        {
            if (IsEnabled())
            {
                WriteEvent(102, clientId);
            }
        }

        [Event(103, Level = EventLevel.Informational, Message = "{0}: GetRulesException done.")]
        public void GetRulesStop(string clientId)
        {
            if (IsEnabled())
            {
                WriteEvent(103, clientId);
            }
        }

        [NonEvent]
        public void GetRulesException(string clientId, Exception exception)
        {
            if (IsEnabled())
            {
                GetRulesException(clientId, exception.ToString());
            }
        }

        [Event(104, Level = EventLevel.Error, Message = "{0}: GetRulesException Exception: {1}.")]
        private void GetRulesException(string clientId, string exception)
        {
            WriteEvent(104, clientId, exception);
        }

        [NonEvent]
        public void CreatingNewLink(string clientId, bool isSessionReceiver, string sessionId, bool isRequestResponseLink, Exception linkException)
        {
            if (IsEnabled())
            {
                CreatingNewLink(clientId, isSessionReceiver, sessionId ?? string.Empty, isRequestResponseLink, linkException?.ToString() ?? string.Empty);
            }
        }

        [Event(105, Level = EventLevel.Informational, Message = "Creating/Recreating New Link. ClientId: {0}, IsSessionReceiver: {1}, SessionId: {2}, IsRequestResponseLink: {3}, LinkError: {4}.")]
        private void CreatingNewLink(string clientId, bool isSessionReceiver, string sessionId, bool isRequestResponseLink, string linkError)
        {
            WriteEvent(105, clientId, isSessionReceiver, sessionId, isRequestResponseLink, linkError);
        }

        [NonEvent]
        public void SessionReceiverLinkClosed(string clientId, string sessionId, Exception linkException)
        {
            if (IsEnabled())
            {
                SessionReceiverLinkClosed(clientId, sessionId ?? string.Empty, linkException?.ToString() ?? string.Empty);
            }
        }

        [Event(106, Level = EventLevel.Error, Message = "SessionReceiver Link Closed. ClientId: {0}, SessionId: {1}, linkException: {2}.")]
        private void SessionReceiverLinkClosed(string clientId, string sessionId, string linkException)
        {
            WriteEvent(106, clientId, sessionId, linkException);
        }

        [NonEvent]
        public void AmqpSendAuthenticationTokenException(string clientId, Exception exception)
        {
            if (IsEnabled())
            {
                AmqpSendAuthenticationTokenException(clientId, exception.ToString());
            }
        }

        [Event(107, Level = EventLevel.Error, Message = "{0}: AmqpSendAuthenticationTokenException Exception: {1}.")]
        private void AmqpSendAuthenticationTokenException(string clientId, string exception)
        {
            WriteEvent(107, clientId, exception);
        }

        [NonEvent]
        public void AmqpTransactionInitializeException(string transactionId, Exception exception)
        {
            if (IsEnabled())
            {
                AmqpTransactionInitializeException(transactionId, exception.ToString()); 
            }
        }

        [Event(108, Level = EventLevel.Error, Message = "AmqpTransactionInitializeException for TransactionId: {0} Exception: {1}.")]
        private void AmqpTransactionInitializeException(string transactionId, string exception)
        {
            WriteEvent(108, transactionId, exception);
        }

        [NonEvent]
        public void AmqpTransactionDeclared(string localTransactionId, ArraySegment<byte> amqpTransactionId)
        {
            if (IsEnabled())
            {
                AmqpTransactionDeclared(localTransactionId, amqpTransactionId.GetAsciiString());
            }
        }

        [Event(109, Level = EventLevel.Informational, Message = "AmqpTransactionDeclared for LocalTransactionId: {0} AmqpTransactionId: {1}.")]
        private void AmqpTransactionDeclared(string transactionId, string amqpTransactionId)
        {
            WriteEvent(109, transactionId, amqpTransactionId);
        }

        [NonEvent]
        public void AmqpTransactionDischarged(string localTransactionId, ArraySegment<byte> amqpTransactionId, bool rollback)
        {
            if (IsEnabled())
            {
                AmqpTransactionDischarged(localTransactionId, amqpTransactionId.GetAsciiString(), rollback);
            }
        }

        [Event(110, Level = EventLevel.Informational, Message = "AmqpTransactionDischarged for LocalTransactionId: {0} AmqpTransactionId: {1} Rollback: {2}.")]
        private void AmqpTransactionDischarged(string transactionId, string amqpTransactionId, bool rollback)
        {
            WriteEvent(110, transactionId, amqpTransactionId, rollback);
        }

        [NonEvent]
        public void AmqpTransactionDischargeException(string transactionId, ArraySegment<byte> amqpTransactionId, Exception exception)
        {
            if (IsEnabled())
            {
                AmqpTransactionDischargeException(transactionId, amqpTransactionId.GetAsciiString(), exception.ToString());
            }
        }

        [Event(111, Level = EventLevel.Error, Message = "AmqpTransactionDischargeException for TransactionId: {0} AmqpTransactionId: {1} Exception: {2}.")]
        private void AmqpTransactionDischargeException(string transactionId, string amqpTransactionId, string exception)
        {
            WriteEvent(111, transactionId, amqpTransactionId, exception);
        }

        [NonEvent]
        public void AmqpCreateControllerException(string connectionManager, Exception exception)
        {
            if (IsEnabled())
            {
                AmqpCreateControllerException(connectionManager, exception.ToString());
            }
        }

        [Event(112, Level = EventLevel.Error, Message = "AmqpCreateControllerException for ConnectionManager: {0} Exception: {1}.")]
        private void AmqpCreateControllerException(string connectionManager, string exception)
        {
            WriteEvent(112, connectionManager, exception);
        }

        [Event(113, Level = EventLevel.Informational, Message = "{0}: Management operation '{1}' for '{2}' started.")]
        public void ManagementOperationStart(string clientId, string operationName, string details = "")
        {
            if (IsEnabled())
            {
                WriteEvent(113, clientId, operationName, details);
            }
        }

        [Event(114, Level = EventLevel.Informational, Message = "{0}: Management operation '{1}' for '{2}' finished.")]
        public void ManagementOperationEnd(string clientId, string operationName, string details = "")
        {
            if (IsEnabled())
            {
                WriteEvent(114, clientId, operationName, details);
            }
        }

        [NonEvent]
        public void ManagementOperationException(string clientId, string operationName, Exception exception)
        {
            if (IsEnabled())
            {
                ManagementOperationException(clientId, operationName, exception.ToString());
            }
        }

        [Event(115, Level = EventLevel.Error, Message = "{0}: Management operation '{1}' encountered exception: '{2}'.")]
        private void ManagementOperationException(string clientId, string operationName, string exception)
        {
            WriteEvent(115, clientId, operationName, exception);
        }

        [Event(116, Level = EventLevel.Informational, Message = "{0}: Management client created with operationTimeout:{1}, tokenProvider:{2}.")]
        public void ManagementClientCreated(string clientId, double operationTimeout, string tokenProvider)
        {
            if (IsEnabled())
            {
                WriteEvent(116, clientId, operationTimeout, tokenProvider);
            }
        }

        [Event(117, Level = EventLevel.Warning, Message = "[De]Serialization failed for object:{0}; Details:{1}")]
        public void ManagementSerializationException(string objectName, string details = "")
        {
            if (IsEnabled())
            {
                WriteEvent(117, objectName, details);
            }
        }
    }

    internal static class TraceHelper
    {
        public static string GetAsciiString(this ArraySegment<byte> arraySegment)
        {
            return arraySegment.Array == null ? string.Empty : Encoding.ASCII.GetString(arraySegment.Array, arraySegment.Offset, arraySegment.Count);
        }
    }
}
