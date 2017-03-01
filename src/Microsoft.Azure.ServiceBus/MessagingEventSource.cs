// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Tracing;

    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.OrderingRules",
        "SA1202:ElementsMustBeOrderedByAccess",
        Justification = "Following this rule here will mix up the EventIds and make it confusing")]
    [EventSource(Name = "Microsoft-Azure-ServiceBus")]
    public sealed class MessagingEventSource : EventSource
    {
        public static MessagingEventSource Log { get; } = new MessagingEventSource();

        [Event(1, Level = EventLevel.Informational, Message = "Creating QueueClient (Namespace '{0}'; Queue '{1}'; ReceiveMode '{2}').")]
        public void QueueClientCreateStart(string namespaceName, string queuename, string receiveMode)
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(1, namespaceName, queuename, receiveMode);
            }
        }

        [Event(2, Level = EventLevel.Informational, Message = "QueueClient (Namespace '{0}'; Queue '{1}'; ClientId: '{2}' created).")]
        public void QueueClientCreateStop(string namespaceName, string queuename, string clientId)
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(2, namespaceName, queuename, clientId);
            }
        }

        [Event(3, Level = EventLevel.Informational, Message = "Creating TopicClient (Namespace '{0}'; Topic '{1}').")]
        public void TopicClientCreateStart(string namespaceName, string topicName)
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(3, namespaceName, topicName);
            }
        }

        [Event(4, Level = EventLevel.Informational, Message = "TopicClient (Namespace '{0}'; Topic '{1}'; ClientId: '{2}' created).")]
        public void TopicClientCreateStop(string namespaceName, string topicName, string clientId)
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(4, namespaceName, topicName, clientId);
            }
        }

        [Event(5, Level = EventLevel.Informational, Message = "Creating SubscriptionClient (Namespace '{0}'; Topic '{1}'; Subscription '{2}'; ReceiveMode '{3}').")]
        public void SubscriptionClientCreateStart(string namespaceName, string topicName, string subscriptionName, string receiveMode)
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(5, namespaceName, topicName, subscriptionName, receiveMode);
            }
        }

        [Event(6, Level = EventLevel.Informational, Message = "SubscriptionClient (Namespace '{0}'; Topic '{1}'; Subscription '{2}'; ClientId: '{3}' created).")]
        public void SubscriptionClientCreateStop(string namespaceName, string topicName, string subscriptionName, string clientId)
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(6, namespaceName, topicName, subscriptionName, clientId);
            }
        }

        [Event(7, Level = EventLevel.Informational, Message = "{0}: SendAsync start. MessageCount = {1}")]
        public void MessageSendStart(string clientId, int messageCount)
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(7, clientId, messageCount);
            }
        }

        [Event(8, Level = EventLevel.Informational, Message = "{0}: SendAsync done.")]
        public void MessageSendStop(string clientId)
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(8, clientId);
            }
        }

        [NonEvent]
        public void MessageSendException(string clientId, Exception exception)
        {
            if (this.IsEnabled())
            {
                this.MessageSendException(clientId, exception.ToString());
            }
        }

        [Event(9, Level = EventLevel.Error, Message = "{0}: SendAsync Exception: {1}.")]
        void MessageSendException(string clientId, string exception)
        {
            this.WriteEvent(9, clientId, exception);
        }

        [Event(10, Level = EventLevel.Informational, Message = "{0}: ReceiveAsync start. MessageCount = {1}")]
        public void MessageReceiveStart(string clientId, int messageCount)
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(10, clientId, messageCount);
            }
        }

        [Event(11, Level = EventLevel.Informational, Message = "{0}: ReceiveAsync done. Received '{1}' messages")]
        public void MessageReceiveStop(string clientId, int messageCount)
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(11, clientId, messageCount);
            }
        }

        [NonEvent]
        public void MessageReceiveException(string clientId, Exception exception)
        {
            if (this.IsEnabled())
            {
                this.MessageReceiveException(clientId, exception.ToString());
            }
        }

        [Event(12, Level = EventLevel.Error, Message = "{0}: ReceiveAsync Exception: {1}.")]
        void MessageReceiveException(string clientId, string exception)
        {
            this.WriteEvent(12, clientId, exception);
        }

        [NonEvent]
        public void MessageCompleteStart(string clientId, int messageCount, IEnumerable<Guid> lockTokens)
        {
            if (this.IsEnabled())
            {
                string formattedLockTokens = StringUtility.GetFormattedLockTokens(lockTokens);
                this.MessageCompleteStart(clientId, messageCount, formattedLockTokens);
            }
        }

        [Event(13, Level = EventLevel.Informational, Message = "{0}: CompleteAsync start. MessageCount = {1}, LockTokens = {2}")]
        void MessageCompleteStart(string clientId, int messageCount, string lockTokens)
        {
            this.WriteEvent(13, clientId, messageCount, lockTokens);
        }

        [Event(14, Level = EventLevel.Informational, Message = "{0}: CompleteAsync done.")]
        public void MessageCompleteStop(string clientId)
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(14, clientId);
            }
        }

        [NonEvent]
        public void MessageCompleteException(string clientId, Exception exception)
        {
            if (this.IsEnabled())
            {
                this.MessageCompleteException(clientId, exception.ToString());
            }
        }

        [Event(15, Level = EventLevel.Error, Message = "{0}: CompleteAsync Exception: {1}.")]
        void MessageCompleteException(string clientId, string exception)
        {
            this.WriteEvent(15, clientId, exception);
        }

        [NonEvent]
        public void MessageAbandonStart(string clientId, int messageCount, IEnumerable<Guid> lockTokens)
        {
            if (this.IsEnabled())
            {
                string formattedLockTokens = StringUtility.GetFormattedLockTokens(lockTokens);
                this.MessageAbandonStart(clientId, messageCount, formattedLockTokens);
            }
        }

        [Event(16, Level = EventLevel.Informational, Message = "{0}: AbandonAsync start. MessageCount = {1}, LockTokens = {2}")]
        void MessageAbandonStart(string clientId, int messageCount, string lockTokens)
        {
            this.WriteEvent(16, clientId, messageCount, lockTokens);
        }

        [Event(17, Level = EventLevel.Informational, Message = "{0}: AbandonAsync done.")]
        public void MessageAbandonStop(string clientId)
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(17, clientId);
            }
        }

        [NonEvent]
        public void MessageAbandonException(string clientId, Exception exception)
        {
            if (this.IsEnabled())
            {
                this.MessageAbandonException(clientId, exception.ToString());
            }
        }

        [Event(18, Level = EventLevel.Error, Message = "{0}: AbandonAsync Exception: {1}.")]
        void MessageAbandonException(string clientId, string exception)
        {
            this.WriteEvent(18, clientId, exception);
        }

        [NonEvent]
        public void MessageDeferStart(string clientId, int messageCount, IEnumerable<Guid> lockTokens)
        {
            if (this.IsEnabled())
            {
                string formattedLockTokens = StringUtility.GetFormattedLockTokens(lockTokens);
                this.MessageDeferStart(clientId, messageCount, formattedLockTokens);
            }
        }

        [Event(19, Level = EventLevel.Informational, Message = "{0}: DeferAsync start. MessageCount = {1}, LockTokens = {2}")]
        void MessageDeferStart(string clientId, int messageCount, string lockTokens)
        {
            this.WriteEvent(19, clientId, messageCount, lockTokens);
        }

        [Event(20, Level = EventLevel.Informational, Message = "{0}: DeferAsync done.")]
        public void MessageDeferStop(string clientId)
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(20, clientId);
            }
        }

        [NonEvent]
        public void MessageDeferException(string clientId, Exception exception)
        {
            if (this.IsEnabled())
            {
                this.MessageDeferException(clientId, exception.ToString());
            }
        }

        [Event(21, Level = EventLevel.Error, Message = "{0}: DeferAsync Exception: {1}.")]
        void MessageDeferException(string clientId, string exception)
        {
            this.WriteEvent(21, clientId, exception);
        }

        [NonEvent]
        public void MessageDeadLetterStart(string clientId, int messageCount, IEnumerable<Guid> lockTokens)
        {
            if (this.IsEnabled())
            {
                string formattedLockTokens = StringUtility.GetFormattedLockTokens(lockTokens);
                this.MessageDeadLetterStart(clientId, messageCount, formattedLockTokens);
            }
        }

        [Event(22, Level = EventLevel.Informational, Message = "{0}: DeadLetterAsync start. MessageCount = {1}, LockTokens = {2}")]
        void MessageDeadLetterStart(string clientId, int messageCount, string lockTokens)
        {
            this.WriteEvent(22, clientId, messageCount, lockTokens);
        }

        [Event(23, Level = EventLevel.Informational, Message = "{0}: DeadLetterAsync done.")]
        public void MessageDeadLetterStop(string clientId)
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(23, clientId);
            }
        }

        [NonEvent]
        public void MessageDeadLetterException(string clientId, Exception exception)
        {
            if (this.IsEnabled())
            {
                this.MessageDeadLetterException(clientId, exception.ToString());
            }
        }

        [Event(24, Level = EventLevel.Error, Message = "{0}: DeadLetterAsync Exception: {1}.")]
        void MessageDeadLetterException(string clientId, string exception)
        {
            this.WriteEvent(24, clientId, exception);
        }

        [NonEvent]
        public void MessageRenewLockStart(string clientId, int messageCount, IEnumerable<Guid> lockTokens)
        {
            if (this.IsEnabled())
            {
                string formattedLockTokens = StringUtility.GetFormattedLockTokens(lockTokens);
                this.MessageRenewLockStart(clientId, messageCount, formattedLockTokens);
            }
        }

        [Event(25, Level = EventLevel.Informational, Message = "{0}: RenewLockAsync start. MessageCount = {1}, LockTokens = {2}")]
        void MessageRenewLockStart(string clientId, int messageCount, string lockTokens)
        {
            this.WriteEvent(25, clientId, messageCount, lockTokens);
        }

        [Event(26, Level = EventLevel.Informational, Message = "{0}: RenewLockAsync done.")]
        public void MessageRenewLockStop(string clientId)
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(26, clientId);
            }
        }

        [NonEvent]
        public void MessageRenewLockException(string clientId, Exception exception)
        {
            if (this.IsEnabled())
            {
                this.MessageRenewLockException(clientId, exception.ToString());
            }
        }

        [Event(27, Level = EventLevel.Error, Message = "{0}: RenewLockAsync Exception: {1}.")]
        void MessageRenewLockException(string clientId, string exception)
        {
            this.WriteEvent(27, clientId, exception);
        }

        [NonEvent]
        public void MessageReceiveBySequenceNumberStart(string clientId, int messageCount, IEnumerable<long> sequenceNumbers)
        {
            if (this.IsEnabled())
            {
                string formattedsequenceNumbers = StringUtility.GetFormattedSequenceNumbers(sequenceNumbers);
                this.MessageReceiveBySequenceNumberStart(clientId, messageCount, formattedsequenceNumbers);
            }
        }

        [Event(28, Level = EventLevel.Informational, Message = "{0}: ReceiveBySequenceNumberAsync start. MessageCount = {1}, LockTokens = {2}")]
        void MessageReceiveBySequenceNumberStart(string clientId, int messageCount, string sequenceNumbers)
        {
            this.WriteEvent(28, clientId, messageCount, sequenceNumbers);
        }

        [Event(29, Level = EventLevel.Informational, Message = "{0}: ReceiveBySequenceNumberAsync done. Received '{1}' messages")]
        public void MessageReceiveBySequenceNumberStop(string clientId, int messageCount)
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(29, clientId, messageCount);
            }
        }

        [NonEvent]
        public void MessageReceiveBySequenceNumberException(string clientId, Exception exception)
        {
            if (this.IsEnabled())
            {
                this.MessageReceiveBySequenceNumberException(clientId, exception.ToString());
            }
        }

        [Event(30, Level = EventLevel.Error, Message = "{0}: ReceiveBySequenceNumberAsync Exception: {1}.")]
        void MessageReceiveBySequenceNumberException(string clientId, string exception)
        {
            this.WriteEvent(30, clientId, exception);
        }

        [Event(31, Level = EventLevel.Informational, Message = "{0}: AcceptMessageSessionAsync start. SessionId = {1}")]
        public void AcceptMessageSessionStart(string clientId, string sessionId)
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(31, clientId, sessionId);
            }
        }

        [Event(32, Level = EventLevel.Informational, Message = "{0}: AcceptMessageSessionAsync done.")]
        public void AcceptMessageSessionStop(string clientId)
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(32, clientId);
            }
        }

        [NonEvent]
        public void AcceptMessageSessionException(string clientId, Exception exception)
        {
            if (this.IsEnabled())
            {
                this.AcceptMessageSessionException(clientId, exception.ToString());
            }
        }

        [Event(33, Level = EventLevel.Error, Message = "{0}: AcceptMessageSessionAsync Exception: {1}.")]
        void AcceptMessageSessionException(string clientId, string exception)
        {
            this.WriteEvent(33, clientId, exception);
        }

        [NonEvent]
        public void AmqpSendLinkCreateStart(string clientId, MessagingEntityType entityType, string entityPath)
        {
            if (this.IsEnabled())
            {
                this.AmqpSendLinkCreateStart(clientId, entityType.ToString(), entityPath);
            }
        }

        [Event(34, Level = EventLevel.Informational, Message = "{0}: AmqpSendLinkCreate started. EntityType: {1}, EntityPath: {2}")]
        void AmqpSendLinkCreateStart(string clientId, string entityType, string entityPath)
        {
            this.WriteEvent(34, clientId, entityType, entityPath);
        }

        [Event(35, Level = EventLevel.Informational, Message = "{0}: AmqpSendLinkCreate done.")]
        public void AmqpSendLinkCreateStop(string clientId)
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(35, clientId);
            }
        }

        [NonEvent]
        public void AmqpReceiveLinkCreateStart(string clientId, bool isRequestResponseLink, MessagingEntityType entityType, string entityPath)
        {
            if (this.IsEnabled())
            {
                this.AmqpReceiveLinkCreateStart(clientId, isRequestResponseLink.ToString(), entityType.ToString(), entityPath);
            }
        }

        [Event(36, Level = EventLevel.Informational, Message = "{0}: AmqpReceiveLinkCreate started. IsRequestResponseLink: {1},  EntityType: {1}, EntityPath: {2}")]
        void AmqpReceiveLinkCreateStart(string clientId, string isRequestResponseLink, string entityType, string entityPath)
        {
            this.WriteEvent(36, clientId, isRequestResponseLink, entityType, entityPath);
        }

        [Event(37, Level = EventLevel.Informational, Message = "{0}: AmqpReceiveLinkCreate done.")]
        public void AmqpReceiveLinkCreateStop(string clientId)
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(37, clientId);
            }
        }

        [Event(38, Level = EventLevel.Verbose, Message = "AmqpGetOrCreateConnection started.")]
        public void AmqpGetOrCreateConnectionStart()
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(38);
            }
        }

        [Event(39, Level = EventLevel.Verbose, Message = "AmqpGetOrCreateConnection done.")]
        public void AmqpGetOrCreateConnectionStop()
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(39);
            }
        }

        [NonEvent]
        public void AmqpSendAuthenticanTokenStart(Uri address, string audience, string resource, string[] claims)
        {
            if (this.IsEnabled())
            {
                this.AmqpSendAuthenticanTokenStart(address.ToString(), audience, resource, claims.ToString());
            }
        }

        [Event(40, Level = EventLevel.Verbose, Message = "AmqpSendAuthenticanToken started. Address: {0}, Audience: {1}, Resource: {2}, Claims: {3}")]
        void AmqpSendAuthenticanTokenStart(string address, string audience, string resource, string claims)
        {
            this.WriteEvent(40, address, audience, resource, claims);
        }

        [Event(41, Level = EventLevel.Verbose, Message = "AmqpSendAuthenticanToken done.")]
        public void AmqpSendAuthenticanTokenStop()
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(41);
            }
        }

        [Event(42, Level = EventLevel.Informational, Message = "{0}: MessagePeekAsync start. SequenceNumber = {1}, MessageCount = {2}")]
        public void MessagePeekStart(string clientId, long sequenceNumber, int messageCount)
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(42, clientId, sequenceNumber, messageCount);
            }
        }

        [Event(43, Level = EventLevel.Informational, Message = "{0}: MessagePeekAsync done. Peeked '{1}' messages")]
        public void MessagePeekStop(string clientId, int messageCount)
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(43, clientId, messageCount);
            }
        }

        [NonEvent]
        public void MessagePeekException(string clientId, Exception exception)
        {
            if (this.IsEnabled())
            {
                this.MessagePeekException(clientId, exception.ToString());
            }
        }

        [Event(44, Level = EventLevel.Error, Message = "{0}: MessagePeekAsync Exception: {1}.")]
        void MessagePeekException(string clientId, string exception)
        {
            this.WriteEvent(44, clientId, exception);
        }

        [NonEvent]
        public void ScheduleMessageStart(string clientId, DateTimeOffset scheduleEnqueueTimeUtc)
        {
            if (this.IsEnabled())
            {
                this.ScheduleMessageException(clientId, scheduleEnqueueTimeUtc.ToString());
            }
        }

        [Event(49, Level = EventLevel.Informational, Message = "{0}: ScheduleMessageAsync start. ScheduleTimeUtc = {1}")]
        public void ScheduleMessageStart(string clientId, string scheduleEnqueueTimeUtc)
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(49, clientId, scheduleEnqueueTimeUtc);
            }
        }

        [Event(50, Level = EventLevel.Informational, Message = "{0}: ScheduleMessageAsync done.")]
        public void ScheduleMessageStop(string clientId)
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(50, clientId);
            }
        }

        [NonEvent]
        public void ScheduleMessageException(string clientId, Exception exception)
        {
            if (this.IsEnabled())
            {
                this.ScheduleMessageException(clientId, exception.ToString());
            }
        }

        [Event(51, Level = EventLevel.Error, Message = "{0}: ScheduleMessageAsync Exception: {1}.")]
        void ScheduleMessageException(string clientId, string exception)
        {
            this.WriteEvent(51, clientId, exception);
        }

        [Event(52, Level = EventLevel.Informational, Message = "{0}: CancelScheduledMessageAsync start. SequenceNumber = {1}")]
        public void CancelScheduledMessageStart(string clientId, long sequenceNumber)
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(52, clientId, sequenceNumber);
            }
        }

        [Event(53, Level = EventLevel.Informational, Message = "{0}: CancelScheduledMessageAsync done.")]
        public void CancelScheduledMessageStop(string clientId)
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(53, clientId);
            }
        }

        [NonEvent]
        public void CancelScheduledMessageException(string clientId, Exception exception)
        {
            if (this.IsEnabled())
            {
                this.CancelScheduledMessageException(clientId, exception.ToString());
            }
        }

        [Event(54, Level = EventLevel.Error, Message = "{0}: CancelScheduledMessageAsync Exception: {1}.")]
        void CancelScheduledMessageException(string clientId, string exception)
        {
            this.WriteEvent(54, clientId, exception);
        }

        [Event(55, Level = EventLevel.Informational, Message = "{0}: AddRuleAsync start. RuleName = {1}")]
        public void AddRuleStart(string clientId, string ruleName)
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(55, clientId, ruleName);
            }
        }

        [Event(56, Level = EventLevel.Informational, Message = "{0}: AddRuleAsync done.")]
        public void AddRuleStop(string clientId)
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(56, clientId);
            }
        }

        [NonEvent]
        public void AddRuleException(string clientId, Exception exception)
        {
            if (this.IsEnabled())
            {
                this.AddRuleException(clientId, exception.ToString());
            }
        }

        [Event(57, Level = EventLevel.Error, Message = "{0}: AddRuleAsync Exception: {1}.")]
        void AddRuleException(string clientId, string exception)
        {
            this.WriteEvent(57, clientId, exception);
        }

        [Event(58, Level = EventLevel.Informational, Message = "{0}: RemoveRuleAsync start. RuleName = {1}")]
        public void RemoveRuleStart(string clientId, string ruleName)
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(58, clientId, ruleName);
            }
        }

        [Event(59, Level = EventLevel.Informational, Message = "{0}: RemoveRuleAsync done.")]
        public void RemoveRuleStop(string clientId)
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(59, clientId);
            }
        }

        [NonEvent]
        public void RemoveRuleException(string clientId, Exception exception)
        {
            if (this.IsEnabled())
            {
                this.RemoveRuleException(clientId, exception.ToString());
            }
        }

        [Event(60, Level = EventLevel.Error, Message = "{0}: RemoveRuleAsync Exception: {1}.")]
        void RemoveRuleException(string clientId, string exception)
        {
            this.WriteEvent(60, clientId, exception);
        }

        [NonEvent]
        public void RegisterOnMessageHandlerStart(string clientId, OnMessageOptions onMessageOptions)
        {
            if (this.IsEnabled())
            {
                this.RegisterOnMessageHandlerStart(clientId, onMessageOptions.AutoComplete, onMessageOptions.AutoRenewLock, onMessageOptions.MaxConcurrentCalls, (long)onMessageOptions.AutoRenewTimeout.TotalSeconds);
            }
        }

        [Event(61, Level = EventLevel.Informational, Message = "{0}: Register OnMessageHandler start: OnMessage Options: AutoComplete: {1}, AutoRenewLock: {2}, MaxConcurrentCalls: {3}, AutoRenewTimeout: {4}")]
        void RegisterOnMessageHandlerStart(string clientId, bool autoComplete, bool autorenewLock, int maxConcurrentCalls, long autorenewTimeoutInSeconds)
        {
            this.WriteEvent(61, clientId, autoComplete, autorenewLock, maxConcurrentCalls, autorenewTimeoutInSeconds);
        }

        [Event(62, Level = EventLevel.Informational, Message = "{0}: Register OnMessageHandler done.")]
        public void RegisterOnMessageHandlerStop(string clientId)
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(62, clientId);
            }
        }

        [NonEvent]
        public void RegisterOnMessageHandlerException(string clientId, Exception exception)
        {
            if (this.IsEnabled())
            {
                this.RegisterOnMessageHandlerException(clientId, exception.ToString());
            }
        }

        [Event(63, Level = EventLevel.Error, Message = "{0}: Register OnMessageHandler Exception: {1}")]
        void RegisterOnMessageHandlerException(string clientId, string exception)
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(63, clientId, exception);
            }
        }

        [NonEvent]
        public void MessageReceiverPumpInitialMessageReceived(string clientId, BrokeredMessage message)
        {
            if (this.IsEnabled())
            {
                this.MessageReceiverPumpInitialMessageReceived(clientId, message.SequenceNumber);
            }
        }

        [Event(64, Level = EventLevel.Informational, Message = "{0}: MessageReceiverPump Received Initial Message: SequenceNumber: {1}")]
        void MessageReceiverPumpInitialMessageReceived(string clientId, long sequenceNumber)
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(64, clientId, sequenceNumber);
            }
        }

        [NonEvent]
        public void MessageReceiverPumpInitialMessageReceiveException(string clientId, int retryCount, Exception exception)
        {
            if (this.IsEnabled())
            {
                this.MessageReceiverPumpInitialMessageReceiveException(clientId, retryCount, exception.ToString());
            }
        }

        [Event(65, Level = EventLevel.Error, Message = "{0}: MessageReceiverPump Receive Initial Message Exception: RetryCount: {1}, Exception: {2}")]
        void MessageReceiverPumpInitialMessageReceiveException(string clientId, int retryCount, string exception)
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(65, clientId, retryCount, exception);
            }
        }

        [NonEvent]
        public void MessageReceiverPumpTaskStart(string clientId, BrokeredMessage message, int currentSemaphoreCount)
        {
            if (this.IsEnabled())
            {
                this.MessageReceiverPumpTaskStart(clientId, message?.SequenceNumber ?? -1, currentSemaphoreCount);
            }
        }

        [Event(66, Level = EventLevel.Informational, Message = "{0}: MessageReceiverPump PumpTask Started: Message: SequenceNumber: {1}, Available Semaphore Count: {2}")]
        void MessageReceiverPumpTaskStart(string clientId, long sequenceNumber, int currentSemaphoreCount)
        {
            this.WriteEvent(66, clientId, sequenceNumber, currentSemaphoreCount);
        }

        [Event(67, Level = EventLevel.Informational, Message = "{0}: MessageReceiverPump PumpTask done: Available Semaphore Count: {1}")]
        public void MessageReceiverPumpTaskStop(string clientId, int currentSemaphoreCount)
        {
            this.WriteEvent(67, clientId, currentSemaphoreCount);
        }

        [NonEvent]
        public void MessageReceivePumpTaskException(string clientId, Exception exception)
        {
            if (this.IsEnabled())
            {
                this.MessageReceivePumpTaskException(clientId, exception.ToString());
            }
        }

        [Event(68, Level = EventLevel.Error, Message = "{0}: MessageReceiverPump PumpTask Exception: Exception: {1}")]
        void MessageReceivePumpTaskException(string clientId, string exception)
        {
            this.WriteEvent(68, clientId, exception);
        }

        [NonEvent]
        public void MessageReceiverPumpDispatchTaskStart(string clientId, BrokeredMessage message)
        {
            if (this.IsEnabled())
            {
                this.MessageReceiverPumpDispatchTaskStart(clientId, message?.SequenceNumber ?? -1);
            }
        }

        [Event(69, Level = EventLevel.Informational, Message = "{0}: MessageReceiverPump DispatchTask start: Message: SequenceNumber: {1}")]
        void MessageReceiverPumpDispatchTaskStart(string clientId, long sequenceNumber)
        {
            this.WriteEvent(69, clientId, sequenceNumber);
        }

        [NonEvent]
        public void MessageReceiverPumpDispatchTaskStop(string clientId, BrokeredMessage message, int currentSemaphoreCount)
        {
            if (this.IsEnabled())
            {
                this.MessageReceiverPumpDispatchTaskStop(clientId, message?.SequenceNumber ?? -1, currentSemaphoreCount);
            }
        }

        [Event(70, Level = EventLevel.Informational, Message = "{0}: MessageReceiverPump DispatchTask done: Message: SequenceNumber: {1}, Current Semaphore Count: {2}")]
        void MessageReceiverPumpDispatchTaskStop(string clientId, long sequenceNumber, int currentSemaphoreCount)
        {
            this.WriteEvent(70, clientId, sequenceNumber, currentSemaphoreCount);
        }

        [NonEvent]
        public void MessageReceiverPumpUserCallbackStart(string clientId, BrokeredMessage message)
        {
            if (this.IsEnabled())
            {
                this.MessageReceiverPumpUserCallbackStart(clientId, message?.SequenceNumber ?? -1);
            }
        }

        [Event(71, Level = EventLevel.Informational, Message = "{0}: MessageReceiverPump UserCallback start: Message: SequenceNumber: {1}")]
        void MessageReceiverPumpUserCallbackStart(string clientId, long sequenceNumber)
        {
            this.WriteEvent(71, clientId, sequenceNumber);
        }

        [NonEvent]
        public void MessageReceiverPumpUserCallbackStop(string clientId, BrokeredMessage message)
        {
            if (this.IsEnabled())
            {
                this.MessageReceiverPumpUserCallbackStop(clientId, message?.SequenceNumber ?? -1);
            }
        }

        [Event(72, Level = EventLevel.Informational, Message = "{0}: MessageReceiverPump UserCallback done: Message: SequenceNumber: {1}")]
        void MessageReceiverPumpUserCallbackStop(string clientId, long sequenceNumber)
        {
            this.WriteEvent(72, clientId, sequenceNumber);
        }

        [NonEvent]
        public void MessageReceiverPumpUserCallbackException(string clientId, BrokeredMessage message, Exception exception)
        {
            if (this.IsEnabled())
            {
                this.MessageReceiverPumpUserCallbackException(clientId, message?.SequenceNumber ?? -1, exception.ToString());
            }
        }

        [Event(73, Level = EventLevel.Error, Message = "{0}: MessageReceiverPump UserCallback Exception: Message: SequenceNumber: {1}, Exception: {2}")]
        void MessageReceiverPumpUserCallbackException(string clientId, long sequenceNumber, string exception)
        {
            this.WriteEvent(73, clientId, sequenceNumber, exception);
        }

        [NonEvent]
        public void MessageReceiverPumpRenewMessageStart(string clientId, BrokeredMessage message, TimeSpan renewAfterTimeSpan)
        {
            if (this.IsEnabled())
            {
                this.MessageReceiverPumpRenewMessageStart(clientId, message?.SequenceNumber ?? -1, (long)renewAfterTimeSpan.TotalSeconds);
            }
        }

        [Event(74, Level = EventLevel.Informational, Message = "{0}: MessageReceiverPump RenewMessage start: Message: SequenceNumber: {1}, RenewAfterTimeInSeconds: {2}")]
        void MessageReceiverPumpRenewMessageStart(string clientId, long sequenceNumber, long renewAfterTimeSpanInSeconds)
        {
            this.WriteEvent(74, clientId, sequenceNumber, renewAfterTimeSpanInSeconds);
        }

        [NonEvent]
        public void MessageReceiverPumpRenewMessageStop(string clientId, BrokeredMessage message)
        {
            if (this.IsEnabled())
            {
                this.MessageReceiverPumpRenewMessageStop(clientId, message?.SequenceNumber ?? -1);
            }
        }

        [Event(75, Level = EventLevel.Informational, Message = "{0}: MessageReceiverPump RenewMessage done: Message: SequenceNumber: {1}")]
        void MessageReceiverPumpRenewMessageStop(string clientId, long sequenceNumber)
        {
            this.WriteEvent(75, clientId, sequenceNumber);
        }

        [NonEvent]
        public void MessageReceiverPumpRenewMessageException(string clientId, BrokeredMessage message, Exception exception)
        {
            if (this.IsEnabled())
            {
                this.MessageReceiverPumpRenewMessageException(clientId, message?.SequenceNumber ?? -1, exception.ToString());
            }
        }

        [Event(76, Level = EventLevel.Error, Message = "{0}: MessageReceiverPump RenewMessage Exception: Message: SequenceNumber: {1}, Exception: {2}")]
        void MessageReceiverPumpRenewMessageException(string clientId, long sequenceNumber, string exception)
        {
            this.WriteEvent(76, clientId, sequenceNumber, exception);
        }
    }
}