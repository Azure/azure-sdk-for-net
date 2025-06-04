// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Azure.Core.Diagnostics;
using Azure.Messaging.ServiceBus.Amqp;
using Azure.Messaging.ServiceBus.Primitives;
using Microsoft.Azure.Amqp;

namespace Azure.Messaging.ServiceBus.Diagnostics
{
    /// <summary>
    ///   Serves as an ETW event source for logging of information about
    ///   Entity's client.
    /// </summary>
    ///
    /// <remarks>
    ///   When defining Start/Complete tasks, it is highly recommended that the
    ///   the CompleteEvent.Id must be exactly StartEvent.Id + 1.
    /// </remarks>
    [EventSource(Name = EventSourceName)]
    internal class ServiceBusEventSource : AzureEventSource
    {
        /// <summary>The name to use for the event source.</summary>
        private const string EventSourceName = "Azure-Messaging-ServiceBus";

        /// <summary>
        ///   Provides a singleton instance of the event source for callers to
        ///   use for logging.
        /// </summary>
        public static ServiceBusEventSource Log { get; } = new ServiceBusEventSource();

        /// <summary>
        ///   Prevents an instance of the <see cref="ServiceBusEventSource"/> class from being
        ///   created outside the scope of the <see cref="Log" /> instance, as well as setting up the
        ///   integration with AzureEventSourceListener.
        /// </summary>
        protected ServiceBusEventSource() : base(EventSourceName)
        {
        }

        #region event constants
        // event constants should not be changed
        internal const int SendMessageStartEvent = 1;
        internal const int SendMessageCompleteEvent = 2;
        internal const int SendMessageExceptionEvent = 3;

        internal const int CreateMessageBatchStartEvent = 4;
        internal const int CreateMessageBatchCompleteEvent = 5;
        internal const int CreateMessageBatchExceptionEvent = 6;

        internal const int ReceiveMessageStartEvent = 7;
        internal const int ReceiveMessageCompleteEvent = 8;
        internal const int ReceiveMessageExceptionEvent = 9;

        internal const int ScheduleMessageStartEvent = 10;
        internal const int ScheduleMessageCompleteEvent = 11;
        internal const int ScheduleMessageExceptionEvent = 12;

        internal const int CancelScheduledMessageStartEvent = 13;
        internal const int CancelScheduledMessageCompleteEvent = 14;
        internal const int CancelScheduledMessageExceptionEvent = 15;

        internal const int CompleteMessageStartEvent = 16;
        internal const int CompleteMessageCompleteEvent = 17;
        internal const int CompleteMessageExceptionEvent = 18;

        internal const int DeferMessageStartEvent = 19;
        internal const int DeferMessageCompleteEvent = 20;
        internal const int DeferMessageExceptionEvent = 21;

        internal const int AbandonMessageStartEvent = 22;
        internal const int AbandonMessageCompleteEvent = 23;
        internal const int AbandonMessageExceptionEvent = 24;

        internal const int DeadLetterMessageStartEvent = 25;
        internal const int DeadLetterMessageCompleteEvent = 26;
        internal const int DeadLetterMessageExceptionEvent = 27;

        internal const int PeekMessageStartEvent = 28;
        internal const int PeekMessageCompleteEvent = 29;
        internal const int PeekMessageExceptionEvent = 30;

        internal const int RenewMessageLockStartEvent = 31;
        internal const int RenewMessageLockCompleteEvent = 32;
        internal const int RenewMessageLockExceptionEvent = 33;

        internal const int ReceiveDeferredMessageStartEvent = 34;
        internal const int ReceiveDeferredMessageCompleteEvent = 35;
        internal const int ReceiveDeferredMessageExceptionEvent = 36;

        internal const int LinkStateLostEvent = 37;
        internal const int ReceiveLinkClosedEvent = 38;
        internal const int AmqpLinkRefreshStartEvent = 39;
        internal const int AmqpLinkRefreshCompleteEvent = 40;
        internal const int AmqpLinkRefreshExceptionEvent = 41;

        internal const int ManagementSerializedExceptionEvent = 42;
        internal const int RunOperationExceptionEvent = 43;

        internal const int ClientCloseStartEvent = 44;
        internal const int ClientCloseCompleteEvent = 45;
        internal const int ClientCloseExceptionEvent = 46;

        internal const int RenewSessionLockStartEvent = 47;
        internal const int RenewSessionLockCompleteEvent = 48;
        internal const int RenewSessionLockExceptionEvent = 49;

        internal const int StartProcessingStartEvent = 50;
        internal const int StartProcessingCompleteEvent = 51;
        internal const int StartProcessingExceptionEvent = 52;

        internal const int StopProcessingStartEvent = 53;
        internal const int StopProcessingCompleteEvent = 54;
        internal const int StopProcessingExceptionEvent = 55;

        internal const int ProcessorRenewMessageLockStartEvent = 56;
        internal const int ProcessorRenewMessageLockCompleteEvent = 57;
        internal const int ProcessorRenewMessageLockExceptionEvent = 58;

        internal const int ProcessorRenewSessionLockStartEvent = 59;
        internal const int ProcessorRenewSessionLockCompleteEvent = 60;
        internal const int ProcessorRenewSessionLockExceptionEvent = 61;

        internal const int GetSessionStateStartEvent = 62;
        internal const int GetSessionStateCompleteEvent = 63;
        internal const int GetSessionStateExceptionEvent = 64;

        internal const int SetSessionStateStartEvent = 65;
        internal const int SetSessionStateCompleteEvent = 66;
        internal const int SetSessionStateExceptionEvent = 67;

        internal const int CreateRuleStartEvent = 68;
        internal const int CreateRuleCompleteEvent = 69;
        internal const int CreateRuleExceptionEvent = 70;

        internal const int DeleteRuleStartEvent = 71;
        internal const int DeleteRuleCompleteEvent = 72;
        internal const int DeleteRuleExceptionEvent = 73;

        internal const int GetRulesStartEvent = 74;
        internal const int GetRulesCompleteEvent = 75;
        internal const int GetRulesExceptionEvent = 76;

        internal const int ClientCreateStartEvent = 77;
        internal const int ClientCreateCompleteEvent = 78;
        internal const int ClientCreateExceptionEvent = 79;

        internal const int CreateSendLinkStartEvent = 80;
        internal const int CreateSendLinkCompleteEvent = 81;
        internal const int CreateSendLinkExceptionEvent = 82;

        internal const int CreateReceiveLinkStartEvent = 83;
        internal const int CreateReceiveLinkCompleteEvent = 84;
        internal const int CreateReceiveLinkExceptionEvent = 85;

        internal const int CreateManagementLinkStartEvent = 86;
        internal const int CreateManagementLinkCompleteEvent = 87;
        internal const int CreateManagementLinkExceptionEvent = 88;

        internal const int TransactionInitializationExceptionEvent = 89;
        internal const int TransactionDeclaredEvent = 90;
        internal const int TransactionDischargedEvent = 91;
        internal const int TransactionDischargedExceptionEvent = 92;
        internal const int CreateControllerExceptionEvent = 93;

        internal const int ProcessorErrorHandlerThrewExceptionEvent = 94;
        internal const int ScheduleTaskFailedEvent = 95;

        internal const int MaxMessagesExceedsPrefetchEvent = 99;
        internal const int SendLinkClosedEvent = 100;
        internal const int ManagementLinkClosedEvent = 101;

        internal const int ProcessorMessageHandlerStartEvent = 102;
        internal const int ProcessorMessageHandlerCompleteEvent = 103;
        internal const int ProcessorMessageHandlerExceptionEvent = 104;

        internal const int RequestAuthorizationStartEvent = 105;
        internal const int RequestAuthorizationCompleteEvent = 106;
        internal const int RequestAuthorizationExceptionEvent = 107;

        internal const int ProcessorClientClosedExceptionEvent = 108;
        internal const int ProcessorAcceptSessionTimeoutEvent = 109;
        internal const int ProcessorStoppingReceiveCanceledEvent = 110;
        internal const int ProcessorStoppingAcceptSessionCanceledEvent = 111;

        internal const int PartitionKeyValueOverwritten = 112;

        internal const int ProcessorStoppingCancellationWarningEvent = 113;

        internal const int RunOperationExceptionVerboseEvent = 114;
        internal const int ReceiveMessageCanceledEvent = 115;

        internal const int DeleteMessagesStartEvent = 116;
        internal const int DeleteMessagesCompleteEvent = 117;
        internal const int DeleteMessagesExceptionEvent = 118;
        internal const int PurgeMessagesStartEvent = 119;
        internal const int PurgeMessagesCompleteEvent = 120;
        internal const int PurgeMessagesExceptionEvent = 121;

        internal const int ReceiverAcceptSessionTimeoutEvent = 122;
        internal const int ReceiverAcceptSessionCanceledEvent = 123;

        internal const int DrainLinkStartEvent = 124;
        internal const int DrainLinkCompleteEvent = 125;
        internal const int DrainLinkExceptionEvent = 126;
        internal const int CloseLinkStartEvent = 127;
        internal const int CloseLinkCompleteEvent = 128;

        #endregion
        // add new event numbers here incrementing from previous

        #region Sending
        [Event(SendMessageStartEvent, Level = EventLevel.Informational, Message = "{0}: SendAsync start. MessageCount = {1}")]
        public virtual void SendMessageStart(string identifier, int messageCount)
        {
            if (IsEnabled())
            {
                WriteEvent(SendMessageStartEvent, identifier, messageCount);
            }
        }

        [Event(SendMessageCompleteEvent, Level = EventLevel.Informational, Message = "{0}: SendAsync done.")]
        public virtual void SendMessageComplete(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(SendMessageCompleteEvent, identifier);
            }
        }

        [Event(SendMessageExceptionEvent, Level = EventLevel.Error, Message = "{0}: SendAsync Exception: {1}.")]
        public virtual void SendMessageException(string identifier, string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(SendMessageExceptionEvent, identifier, exception);
            }
        }

        [Event(CreateMessageBatchStartEvent, Level = EventLevel.Informational, Message = "{0}: CreateBatchAsync start.")]
        public virtual void CreateMessageBatchStart(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(CreateMessageBatchStartEvent, identifier);
            }
        }

        [Event(CreateMessageBatchCompleteEvent, Level = EventLevel.Informational, Message = "{0}: CreateBatchAsync done.")]
        public virtual void CreateMessageBatchComplete(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(CreateMessageBatchCompleteEvent, identifier);
            }
        }

        [Event(CreateMessageBatchExceptionEvent, Level = EventLevel.Error, Message = "{0}: CreateBatchAsync Exception: {1}.")]
        public virtual void CreateMessageBatchException(string identifier, string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(CreateMessageBatchExceptionEvent, identifier, exception);
            }
        }
        #endregion

        #region Receiving

        [Event(ReceiveMessageStartEvent, Level = EventLevel.Informational, Message = "{0}: ReceiveBatchAsync start. MessageCount = {1}")]
        public virtual void ReceiveMessageStart(string identifier, int messageCount)
        {
            if (IsEnabled())
            {
                WriteEvent(ReceiveMessageStartEvent, identifier, messageCount);
            }
        }

        [NonEvent]
        public virtual void ReceiveMessageComplete(
            string identifier,
            IReadOnlyList<ServiceBusReceivedMessage> messages)
        {
            if (IsEnabled())
            {
                ReceiveMessageCompleteCore(identifier, messages.Count, StringUtility.GetFormattedLockTokens(messages.Select(m => m.LockTokenGuid)));
            }
        }

        [Event(ReceiveMessageCompleteEvent, Level = EventLevel.Informational, Message = "{0}: ReceiveBatchAsync done. Received '{1}' messages. LockTokens = {2}")]
        private void ReceiveMessageCompleteCore(
            string identifier,
            int messageCount,
            string lockTokens)
        {
            WriteEvent(ReceiveMessageCompleteEvent, identifier, messageCount, lockTokens);
        }

        [Event(ReceiveMessageExceptionEvent, Level = EventLevel.Error, Message = "{0}: ReceiveBatchAsync Exception: {1}.")]
        public virtual void ReceiveMessageException(
            string clientId,
            string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(ReceiveMessageExceptionEvent, clientId, exception);
            }
        }

        [Event(ReceiveMessageCanceledEvent, Level = EventLevel.Verbose, Message = "A receive operation was cancelled. (Identifier '{0}'). Error Message: '{1}'")]
        public void ReceiveMessageCanceled(string identifier, string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(ReceiveMessageCanceledEvent, identifier, exception);
            }
        }

        [NonEvent]
        public virtual void ReceiveDeferredMessageStart(string identifier, long[] sequenceNumbers)
        {
            if (IsEnabled())
            {
                var formattedSequenceNumbers = StringUtility.GetFormattedSequenceNumbers(sequenceNumbers);
                ReceiveDeferredMessageStartCore(identifier, sequenceNumbers.Length, formattedSequenceNumbers);
            }
        }

        [Event(ReceiveDeferredMessageStartEvent, Level = EventLevel.Informational, Message = "{0}: ReceiveDeferredMessageAsync start. MessageCount = {1}, SequenceNumbers = {2}")]
        private void ReceiveDeferredMessageStartCore(string identifier, int messageCount, string sequenceNumbers)
        {
            WriteEvent(ReceiveDeferredMessageStartEvent, identifier, messageCount, sequenceNumbers);
        }

        [Event(ReceiveDeferredMessageCompleteEvent, Level = EventLevel.Informational, Message = "{0}: ReceiveDeferredMessageAsync done. Received '{1}' messages")]
        public virtual void ReceiveDeferredMessageComplete(string identifier, int messageCount)
        {
            if (IsEnabled())
            {
                WriteEvent(ReceiveDeferredMessageCompleteEvent, identifier, messageCount);
            }
        }

        [Event(ReceiveDeferredMessageExceptionEvent, Level = EventLevel.Error, Message = "{0}: ReceiveDeferredMessageAsync Exception: {1}.")]
        public virtual void ReceiveDeferredMessageException(string identifier, string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(ReceiveDeferredMessageExceptionEvent, identifier, exception);
            }
        }

        [Event(ReceiverAcceptSessionCanceledEvent, Level = EventLevel.Verbose, Message = "An accept session operation for a receiver was canceled. (Namespace '{0}', Entity path '{1}'). Error Message: '{2}'")]
        public void ReceiverAcceptSessionCanceled(string fullyQualifiedNamespace, string entityPath, string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(ReceiverAcceptSessionCanceledEvent, fullyQualifiedNamespace, entityPath, exception);
            }
        }

        [Event(ReceiverAcceptSessionTimeoutEvent, Level = EventLevel.Verbose, Message = "The receiver accept session call timed out. (Namespace '{0}', Entity path '{1}'). Error Message: '{2}'")]
        public virtual void ReceiverAcceptSessionTimeout(
            string fullyQualifiedNamespace,
            string entityPath,
            string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(ReceiverAcceptSessionTimeoutEvent, fullyQualifiedNamespace, entityPath, exception);
            }
        }
        #endregion

        #region Peeking
        [Event(PeekMessageStartEvent, Level = EventLevel.Informational, Message = "{0}: MessagePeekAsync start. SequenceNumber = {1}, MessageCount = {2}")]
        public virtual void PeekMessageStart(string identifier, long? sequenceNumber, int messageCount)
        {
            if (IsEnabled())
            {
                PeekMessageStartCore(PeekMessageStartEvent, identifier, sequenceNumber, messageCount);
            }
        }

        [NonEvent]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = EventSourceSuppressMessage)]
        private unsafe void PeekMessageStartCore(int eventId, string identifier, long? sequenceNumber, int messageCount)
        {
            fixed (char* identifierPtr = identifier)
            {
                var eventPayload = stackalloc EventData[3];

                eventPayload[0].Size = (identifier.Length + 1) * sizeof(char);
                eventPayload[0].DataPointer = (IntPtr)identifierPtr;

                eventPayload[1].Size = Unsafe.SizeOf<long?>();
                eventPayload[1].DataPointer = (IntPtr)Unsafe.AsPointer(ref sequenceNumber);

                eventPayload[2].Size = Unsafe.SizeOf<int>();
                eventPayload[2].DataPointer = (IntPtr)Unsafe.AsPointer(ref messageCount);

                WriteEventCore(eventId, 3, eventPayload);
            }
        }

        [Event(PeekMessageCompleteEvent, Level = EventLevel.Informational, Message = "{0}: MessagePeekAsync done. Peeked '{1}' messages")]
        public virtual void PeekMessageComplete(string identifier, int messageCount)
        {
            if (IsEnabled())
            {
                WriteEvent(PeekMessageCompleteEvent, identifier, messageCount);
            }
        }

        [Event(PeekMessageExceptionEvent, Level = EventLevel.Error, Message = "{0}: MessagePeekAsync Exception: {1}.")]
        public virtual void PeekMessageException(string identifier, string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(PeekMessageExceptionEvent, identifier, exception);
            }
        }
        #endregion

        #region Scheduling
        [Event(ScheduleMessageStartEvent, Level = EventLevel.Informational, Message = "{0}: ScheduleMessageAsync start. MessageCount = {1}, ScheduleTimeUtc = {2}")]
        public virtual void ScheduleMessagesStart(string identifier, int messageCount, string scheduledEnqueueTime)
        {
            if (IsEnabled())
            {
                WriteEvent(ScheduleMessageStartEvent, identifier, messageCount, scheduledEnqueueTime);
            }
        }

        [Event(ScheduleMessageCompleteEvent, Level = EventLevel.Informational, Message = "{0}: ScheduleMessageAsync done.")]
        public virtual void ScheduleMessagesComplete(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(ScheduleMessageCompleteEvent, identifier);
            }
        }

        [Event(ScheduleMessageExceptionEvent, Level = EventLevel.Error, Message = "{0}: ScheduleMessageAsync Exception: {1}.")]
        public virtual void ScheduleMessagesException(string identifier, string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(ScheduleMessageExceptionEvent, identifier, exception);
            }
        }

        [NonEvent]
        public virtual void CancelScheduledMessagesStart(string identifier, long[] sequenceNumbers)
        {
            if (IsEnabled())
            {
                var formattedSequenceNumbers = StringUtility.GetFormattedSequenceNumbers(sequenceNumbers);
                CancelScheduledMessagesStartCore(identifier, sequenceNumbers.Length, formattedSequenceNumbers);
            }
        }

        [Event(CancelScheduledMessageStartEvent, Level = EventLevel.Informational, Message = "{0}: CancelScheduledMessageAsync start. MessageCount = {1}, SequenceNumbers = {2}")]
        public virtual void CancelScheduledMessagesStartCore(string identifier, int messageCount, string sequenceNumbers)
        {
            if (IsEnabled())
            {
                WriteEvent(CancelScheduledMessageStartEvent, identifier, messageCount, sequenceNumbers);
            }
        }

        [Event(CancelScheduledMessageCompleteEvent, Level = EventLevel.Informational, Message = "{0}: CancelScheduledMessageAsync done.")]
        public virtual void CancelScheduledMessagesComplete(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(CancelScheduledMessageCompleteEvent, identifier);
            }
        }

        [Event(CancelScheduledMessageExceptionEvent, Level = EventLevel.Error, Message = "{0}: CancelScheduledMessageAsync Exception: {1}.")]
        public virtual void CancelScheduledMessagesException(string identifier, string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(CancelScheduledMessageExceptionEvent, identifier, exception);
            }
        }
        #endregion

        #region Settlement

        [NonEvent]
        public virtual void CompleteMessageStart(string identifier, int messageCount, Guid lockToken)
        {
            if (IsEnabled())
            {
                CompleteMessageStartCore(identifier, messageCount, lockToken.ToString());
            }
        }

        [Event(CompleteMessageStartEvent, Level = EventLevel.Informational, Message = "{0}: CompleteAsync start. MessageCount = {1}, LockToken = {2}")]
        private void CompleteMessageStartCore(string identifier, int messageCount, string lockTokens)
        {
            WriteEvent(CompleteMessageStartEvent, identifier, messageCount, lockTokens);
        }

        [NonEvent]
        public virtual void CompleteMessageComplete(string identifier, Guid lockToken)
        {
            if (IsEnabled())
            {
                CompleteMessageCompleteCore(identifier, lockToken.ToString());
            }
        }

        [Event(CompleteMessageCompleteEvent, Level = EventLevel.Informational, Message = "{0}: CompleteAsync done. LockToken = {1}")]
        private void CompleteMessageCompleteCore(string identifier, string lockToken)
        {
            WriteEvent(CompleteMessageCompleteEvent, identifier, lockToken);
        }

        [NonEvent]
        public virtual void CompleteMessageException(string identifier, string exception, Guid lockToken)
        {
            if (IsEnabled())
            {
                CompleteMessageExceptionCore(identifier, exception, lockToken.ToString());
            }
        }

        [Event(CompleteMessageExceptionEvent, Level = EventLevel.Error, Message = "{0}: CompleteAsync Exception: {1}. LockToken = {2}")]
        private void CompleteMessageExceptionCore(string identifier, string exception, string lockToken)
        {
            WriteEvent(CompleteMessageExceptionEvent, identifier, exception, lockToken);
        }

        [NonEvent]
        public virtual void DeferMessageStart(string identifier, int messageCount, Guid lockToken)
        {
            if (IsEnabled())
            {
                DeferMessageStartCore(identifier, messageCount, lockToken.ToString());
            }
        }

        [Event(DeferMessageStartEvent, Level = EventLevel.Informational, Message = "{0}: DeferAsync start. MessageCount = {1}, LockToken = {2}")]
        private void DeferMessageStartCore(string identifier, int messageCount, string lockToken)
        {
            WriteEvent(DeferMessageStartEvent, identifier, messageCount, lockToken);
        }

        [NonEvent]
        public virtual void DeferMessageComplete(string identifier, Guid lockToken)
        {
            if (IsEnabled())
            {
                DeferMessageCompleteCore(identifier, lockToken.ToString());
            }
        }

        [Event(DeferMessageCompleteEvent, Level = EventLevel.Informational, Message = "{0}: DeferAsync done. LockToken = {1}")]
        private void DeferMessageCompleteCore(string identifier, string lockToken)
        {
            WriteEvent(DeferMessageCompleteEvent, identifier, lockToken);
        }

        [NonEvent]
        public virtual void DeferMessageException(string identifier, string exception, Guid lockToken)
        {
            if (IsEnabled())
            {
                DeferMessageExceptionCore(identifier, exception, lockToken.ToString());
            }
        }

        [Event(DeferMessageExceptionEvent, Level = EventLevel.Error, Message = "{0}: DeferAsync Exception: {1}. LockToken = {2}")]
        private void DeferMessageExceptionCore(string identifier, string exception, string lockToken)
        {
            WriteEvent(DeferMessageExceptionEvent, identifier, exception, lockToken);
        }

        [NonEvent]
        public virtual void AbandonMessageStart(string identifier, int messageCount, Guid lockToken)
        {
            if (IsEnabled())
            {
                AbandonMessageStartCore(identifier, messageCount, lockToken.ToString());
            }
        }

        [Event(AbandonMessageStartEvent, Level = EventLevel.Informational, Message = "{0}: AbandonAsync start. MessageCount = {1}, LockToken = {2}")]
        private void AbandonMessageStartCore(string identifier, int messageCount, string lockToken)
        {
            WriteEvent(AbandonMessageStartEvent, identifier, messageCount, lockToken);
        }

        [NonEvent]
        public virtual void AbandonMessageComplete(string identifier, Guid lockToken)
        {
            if (IsEnabled())
            {
                AbandonMessageCompleteCore(identifier, lockToken.ToString());
            }
        }

        [Event(AbandonMessageCompleteEvent, Level = EventLevel.Informational, Message = "{0}: AbandonAsync done. LockToken = {1}")]
        private void AbandonMessageCompleteCore(string identifier, string lockToken)
        {
            WriteEvent(AbandonMessageCompleteEvent, identifier, lockToken);
        }

        [NonEvent]
        public virtual void AbandonMessageException(string identifier, string exception, Guid lockToken)
        {
            if (IsEnabled())
            {
                AbandonMessageExceptionCore(identifier, exception, lockToken.ToString());
            }
        }

        [Event(AbandonMessageExceptionEvent, Level = EventLevel.Error, Message = "{0}: AbandonAsync Exception: {1}. LockToken = {2}")]
        private void AbandonMessageExceptionCore(string identifier, string exception, string lockToken)
        {
            WriteEvent(AbandonMessageExceptionEvent, identifier, exception, lockToken);
        }

        [NonEvent]
        public virtual void DeadLetterMessageStart(string identifier, int messageCount, Guid lockToken)
        {
            if (IsEnabled())
            {
                DeadLetterMessageStartCore(identifier, messageCount, lockToken.ToString());
            }
        }

        [Event(DeadLetterMessageStartEvent, Level = EventLevel.Informational, Message = "{0}: DeadLetterAsync start. MessageCount = {1}, LockToken = {2}")]
        private void DeadLetterMessageStartCore(string identifier, int messageCount, string lockToken)
        {
            WriteEvent(DeadLetterMessageStartEvent, identifier, messageCount, lockToken);
        }

        [NonEvent]
        public virtual void DeadLetterMessageComplete(string identifier, Guid lockToken)
        {
            if (IsEnabled())
            {
                DeadLetterMessageCompleteCore(identifier, lockToken.ToString());
            }
        }

        [Event(DeadLetterMessageCompleteEvent, Level = EventLevel.Informational, Message = "{0}: DeadLetterAsync done. LockToken = {1}")]
        private void DeadLetterMessageCompleteCore(string identifier, string lockToken)
        {
            WriteEvent(DeadLetterMessageCompleteEvent, identifier, lockToken);
        }

        [NonEvent]
        public virtual void DeadLetterMessageException(string identifier, string exception, Guid lockToken)
        {
            if (IsEnabled())
            {
                DeadLetterMessageExceptionCore(identifier, exception, lockToken.ToString());
            }
        }

        [Event(DeadLetterMessageExceptionEvent, Level = EventLevel.Error, Message = "{0}: DeadLetterAsync Exception: {1}. LockToken = {2}")]
        private void DeadLetterMessageExceptionCore(string identifier, string exception, string lockToken)
        {
            WriteEvent(DeadLetterMessageExceptionEvent, identifier, exception, lockToken);
        }
        #endregion

        #region Batch delete

        [NonEvent]
        public virtual void DeleteMessagesStart(string identifier, int maxMessages, DateTimeOffset enqueuedTimeUtcOlderThan)
        {
            if (IsEnabled())
            {
                DeleteMessagesStartCore(identifier, maxMessages, enqueuedTimeUtcOlderThan.ToString());
            }
        }

        [Event(DeleteMessagesStartEvent, Level = EventLevel.Informational, Message = "{0}: DeleteMessagesAsync start. MaxMessages = {1}, EnqueuedTimeUtcOlderThan = {2}")]
        private void DeleteMessagesStartCore(string identifier, int messageCount, string enqueuedTimeUtcOlderThan)
        {
            WriteEvent(DeleteMessagesStartEvent, identifier, messageCount, enqueuedTimeUtcOlderThan);
        }

        [NonEvent]
        public virtual void DeleteMessagesComplete(string identifier, int messagesDeleted)
        {
            if (IsEnabled())
            {
                DeleteMessagesCompleteCore(identifier, messagesDeleted);
            }
        }

        [Event(DeleteMessagesCompleteEvent, Level = EventLevel.Informational, Message = "{0}: DeleteMessagesAsync done. Deleted '{1}' message(s).")]
        private void DeleteMessagesCompleteCore(string identifier, int messagesDeleted)
        {
            WriteEvent(DeleteMessagesCompleteEvent, identifier, messagesDeleted);
        }

        [NonEvent]
        public virtual void DeleteMessagesException(string identifier, string exception)
        {
            if (IsEnabled())
            {
                DeleteMessagesExceptionCore(identifier, exception);
            }
        }

        [Event(DeleteMessagesExceptionEvent, Level = EventLevel.Error, Message = "{0}: DeleteMessagesAsync Exception: {1}.")]
        private void DeleteMessagesExceptionCore(string identifier, string exception)
        {
            WriteEvent(DeleteMessagesExceptionEvent, identifier, exception);
        }

        [NonEvent]
        public virtual void PurgeMessagesStart(string identifier, DateTimeOffset enqueuedTimeUtcOlderThan)
        {
            if (IsEnabled())
            {
                PurgeMessagesStartCore(identifier, enqueuedTimeUtcOlderThan.ToString());
            }
        }

        [Event(PurgeMessagesStartEvent, Level = EventLevel.Informational, Message = "{0}: PurgeMessagesAsync start. EnqueuedTimeUtcOlderThan = {1}")]
        private void PurgeMessagesStartCore(string identifier, string enqueuedTimeUtcOlderThan)
        {
            WriteEvent(PurgeMessagesStartEvent, identifier, enqueuedTimeUtcOlderThan);
        }

        [NonEvent]
        public virtual void PurgeMessagesComplete(string identifier, int messagesPurged)
        {
            if (IsEnabled())
            {
                PurgeMessagesCompleteCore(identifier, messagesPurged);
            }
        }

        [Event(PurgeMessagesCompleteEvent, Level = EventLevel.Informational, Message = "{0}: PurgeMessagesAsync done. Purged '{1}' message(s).")]
        private void PurgeMessagesCompleteCore(string identifier, int messagesPurged)
        {
            WriteEvent(PurgeMessagesCompleteEvent, identifier, messagesPurged);
        }

        [NonEvent]
        public virtual void PurgeMessagesException(string identifier, string exception)
        {
            if (IsEnabled())
            {
                PurgeMessagesExceptionCore(identifier, exception);
            }
        }

        [Event(PurgeMessagesExceptionEvent, Level = EventLevel.Error, Message = "{0}: PurgeMessagesAsync Exception: {1}.")]
        private void PurgeMessagesExceptionCore(string identifier, string exception)
        {
            WriteEvent(PurgeMessagesExceptionEvent, identifier, exception);
        }

        #endregion

        #region Lock renewal

        [NonEvent]
        public virtual void RenewMessageLockStart(string identifier, int messageCount, Guid lockToken)
        {
            if (IsEnabled())
            {
                RenewMessageLockStartCore(identifier, messageCount, lockToken.ToString());
            }
        }

        [Event(RenewMessageLockStartEvent, Level = EventLevel.Informational, Message = "{0}: RenewLockAsync start. MessageCount = {1}, LockToken = {2}")]
        private void RenewMessageLockStartCore(string identifier, int messageCount, string lockToken)
        {
            WriteEvent(RenewMessageLockStartEvent, identifier, messageCount, lockToken);
        }

        [NonEvent]
        public virtual void RenewMessageLockComplete(string identifier, Guid lockToken)
        {
            if (IsEnabled())
            {
                RenewMessageLockCompleteCore(identifier, lockToken.ToString());
            }
        }

        [Event(RenewMessageLockCompleteEvent, Level = EventLevel.Informational, Message = "{0}: RenewLockAsync done. LockToken = {1}")]
        private void RenewMessageLockCompleteCore(string identifier, string lockToken)
        {
            if (IsEnabled())
            {
                WriteEvent(RenewMessageLockCompleteEvent, identifier, lockToken);
            }
        }

        [NonEvent]
        public virtual void RenewMessageLockException(string identifier, string exception, Guid lockToken)
        {
            if (IsEnabled())
            {
                RenewMessageLockExceptionCore(identifier, exception, lockToken.ToString());
            }
        }

        [Event(RenewMessageLockExceptionEvent, Level = EventLevel.Error, Message = "{0}: RenewLockAsync Exception: {1}. LockToken = {2}")]
        private void RenewMessageLockExceptionCore(string identifier, string exception, string lockToken)
        {
            WriteEvent(RenewMessageLockExceptionEvent, identifier, exception, lockToken);
        }

        [Event(RenewSessionLockStartEvent, Level = EventLevel.Informational, Message = "{0}: RenewSessionLockAsync start. SessionId = {1}")]
        public virtual void RenewSessionLockStart(string identifier, string sessionId)
        {
            if (IsEnabled())
            {
                WriteEvent(RenewSessionLockStartEvent, identifier, sessionId);
            }
        }

        [Event(RenewSessionLockCompleteEvent, Level = EventLevel.Informational, Message = "{0}: RenewSessionLockAsync done. SessionId = {1}")]
        public virtual void RenewSessionLockComplete(string identifier, string sessionId)
        {
            if (IsEnabled())
            {
                WriteEvent(RenewSessionLockCompleteEvent, identifier, sessionId);
            }
        }

        [Event(RenewSessionLockExceptionEvent, Level = EventLevel.Error, Message = "{0}: RenewSessionLockAsync Exception: {1}. SessionId = {2}")]
        public virtual void RenewSessionLockException(string identifier, string exception, string sessionId)
        {
            if (IsEnabled())
            {
                WriteEvent(RenewSessionLockExceptionEvent, identifier, exception, sessionId);
            }
        }
        #endregion

        #region Get/Set session state

        [Event(GetSessionStateStartEvent, Level = EventLevel.Informational, Message = "{0}: Session GetStateAsync start. SessionId = {1}")]
        public virtual void GetSessionStateStart(string identifiers, string sessionId)
        {
            if (IsEnabled())
            {
                WriteEvent(GetSessionStateStartEvent, identifiers, sessionId);
            }
        }

        [Event(GetSessionStateCompleteEvent, Level = EventLevel.Informational, Message = "{0}: Session GetStateAsync done. SessionId = {1}")]
        public virtual void GetSessionStateComplete(string identifier, string sessionId)
        {
            if (IsEnabled())
            {
                WriteEvent(GetSessionStateCompleteEvent, identifier, sessionId);
            }
        }

        [Event(GetSessionStateExceptionEvent, Level = EventLevel.Error, Message = "{0}: Session GetStateAsync Exception: {1}. SessionId = {2}")]
        public virtual void GetSessionStateException(string identifier, string exception, string sessionId)
        {
            if (IsEnabled())
            {
                WriteEvent(GetSessionStateExceptionEvent, identifier, exception, sessionId);
            }
        }

        [Event(SetSessionStateStartEvent, Level = EventLevel.Informational, Message = "{0}: Session SetStateAsync start. SessionId = {1}")]
        public virtual void SetSessionStateStart(string identifiers, string sessionId)
        {
            if (IsEnabled())
            {
                WriteEvent(SetSessionStateStartEvent, identifiers, sessionId);
            }
        }

        [Event(SetSessionStateCompleteEvent, Level = EventLevel.Informational, Message = "{0}: Session SetStateAsync done. SessionId = {1}")]
        public virtual void SetSessionStateComplete(string identifier, string sessionId)
        {
            if (IsEnabled())
            {
                WriteEvent(SetSessionStateCompleteEvent, identifier, sessionId);
            }
        }

        [Event(SetSessionStateExceptionEvent, Level = EventLevel.Error, Message = "{0}: Session SetStateAsync Exception: {1}. SessionId = {2}")]
        public virtual void SetSessionStateException(string identifier, string exception, string sessionId)
        {
            if (IsEnabled())
            {
                WriteEvent(SetSessionStateExceptionEvent, identifier, exception, sessionId);
            }
        }
        #endregion

        #region Processor

        [Event(StartProcessingStartEvent, Level = EventLevel.Informational, Message = "{0}: StartProcessingAsync start.")]
        public virtual void StartProcessingStart(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(StartProcessingStartEvent, identifier);
            }
        }

        [Event(StartProcessingCompleteEvent, Level = EventLevel.Informational, Message = "{0}: StartProcessingAsync done.")]
        public virtual void StartProcessingComplete(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(StartProcessingCompleteEvent, identifier);
            }
        }

        [Event(StartProcessingExceptionEvent, Level = EventLevel.Error, Message = "{0}: StartProcessingAsync Exception: {1}.")]
        public virtual void StartProcessingException(string identifier, string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(StartProcessingExceptionEvent, identifier, exception);
            }
        }

        [Event(StopProcessingStartEvent, Level = EventLevel.Informational, Message = "{0}: StopProcessingAsync start.")]
        public virtual void StopProcessingStart(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(StopProcessingStartEvent, identifier);
            }
        }

        [Event(StopProcessingCompleteEvent, Level = EventLevel.Informational, Message = "{0}: StopProcessingAsync done.")]
        public virtual void StopProcessingComplete(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(StopProcessingCompleteEvent, identifier);
            }
        }

        [Event(StopProcessingExceptionEvent, Level = EventLevel.Error, Message = "{0}: StopProcessingAsync Exception: {1}.")]
        public virtual void StopProcessingException(string identifier, string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(StopProcessingExceptionEvent, identifier, exception);
            }
        }

        [Event(ProcessorStoppingCancellationWarningEvent, Level = EventLevel.Warning, Message = "{0}: StopProcessingAsync Cancellation of the Processor cancellation token triggered an Exception: {1}.")]
        public virtual void ProcessorStoppingCancellationWarning(string identifier, string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(ProcessorStoppingCancellationWarningEvent, identifier, exception);
            }
        }

        [NonEvent]
        public virtual void ProcessorRenewMessageLockStart(string identifier, int messageCount, Guid lockToken)
        {
            if (IsEnabled())
            {
                ProcessorRenewMessageLockStartCore(identifier, messageCount, lockToken.ToString());
            }
        }

        [Event(ProcessorRenewMessageLockStartEvent, Level = EventLevel.Informational, Message = "{0}: Processor RenewMessageLock start. MessageCount = {1}, LockToken = {2}")]
        private void ProcessorRenewMessageLockStartCore(string identifier, int messageCount, string lockToken)
        {
            WriteEvent(ProcessorRenewMessageLockStartEvent, identifier, messageCount, lockToken);
        }

        [NonEvent]
        public virtual void ProcessorRenewMessageLockComplete(string identifier, Guid lockToken)
        {
            if (IsEnabled())
            {
                ProcessorRenewMessageLockCompleteCore(identifier, lockToken.ToString());
            }
        }

        [Event(ProcessorRenewMessageLockCompleteEvent, Level = EventLevel.Informational, Message = "{0}: Processor RenewMessageLock complete. LockToken = {1}")]
        private void ProcessorRenewMessageLockCompleteCore(string identifier, string lockToken)
        {
            WriteEvent(ProcessorRenewMessageLockCompleteEvent, identifier, lockToken);
        }

        [NonEvent]
        public virtual void ProcessorRenewMessageLockException(string identifier, string exception, Guid lockToken)
        {
            if (IsEnabled())
            {
                ProcessorRenewMessageLockExceptionCore(identifier, exception, lockToken.ToString());
            }
        }

        [Event(ProcessorRenewMessageLockExceptionEvent, Level = EventLevel.Error, Message = "{0}: Processor RenewMessageLock Exception: {1}. LockToken = {2}")]
        private void ProcessorRenewMessageLockExceptionCore(string identifier, string exception, string lockToken)
        {
            WriteEvent(ProcessorRenewMessageLockExceptionEvent, identifier, exception, lockToken);
        }

        [Event(ProcessorRenewSessionLockStartEvent, Level = EventLevel.Informational, Message = "{0}: Processor RenewSessionLock start. SessionId = {1}")]
        public virtual void ProcessorRenewSessionLockStart(string identifier, string sessionId)
        {
            if (IsEnabled())
            {
                WriteEvent(ProcessorRenewSessionLockStartEvent, identifier, sessionId);
            }
        }

        [Event(ProcessorRenewSessionLockCompleteEvent, Level = EventLevel.Informational, Message = "{0}: Processor RenewSessionLock complete. SessionId = {1}")]
        public virtual void ProcessorRenewSessionLockComplete(string identifier, string sessionId)
        {
            if (IsEnabled())
            {
                WriteEvent(ProcessorRenewSessionLockCompleteEvent, identifier, sessionId);
            }
        }

        [Event(ProcessorRenewSessionLockExceptionEvent, Level = EventLevel.Error, Message = "{0}: Processor RenewSessionLock Exception: {1}. SessionId = {2}")]
        public virtual void ProcessorRenewSessionLockException(string identifier, string exception, string sessionId)
        {
            if (IsEnabled())
            {
                WriteEvent(ProcessorRenewSessionLockExceptionEvent, identifier, exception, sessionId);
            }
        }

        [Event(ProcessorErrorHandlerThrewExceptionEvent, Level = EventLevel.Error, Message = "{1}: ExceptionReceivedHandler threw exception. Exception:{0}")]
        public void ProcessorErrorHandlerThrewException(string exception, string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(ProcessorErrorHandlerThrewExceptionEvent, exception, identifier);
            }
        }

        [NonEvent]
        public void ProcessorMessageHandlerStart(string identifier, long sequenceNumber, Guid lockToken)
        {
            if (IsEnabled())
            {
                ProcessorMessageHandlerStartCore(identifier, sequenceNumber, lockToken.ToString());
            }
        }

        [Event(ProcessorMessageHandlerStartEvent, Level = EventLevel.Informational, Message = "{0}: User message handler start: Message: SequenceNumber: {1}, LockToken: {2}")]
        private void ProcessorMessageHandlerStartCore(string identifier, long sequenceNumber, string lockToken)
        {
            WriteEvent(ProcessorMessageHandlerStartEvent, identifier, sequenceNumber, lockToken);
        }

        [NonEvent]
        public void ProcessorMessageHandlerComplete(string identifier, long sequenceNumber, Guid lockToken)
        {
            if (IsEnabled())
            {
                ProcessorMessageHandlerCompleteCore(identifier, sequenceNumber, lockToken.ToString());
            }
        }

        [Event(ProcessorMessageHandlerCompleteEvent, Level = EventLevel.Informational, Message = "{0}: User message handler complete: Message: SequenceNumber: {1}, LockToken: {2}")]
        private void ProcessorMessageHandlerCompleteCore(string identifier, long sequenceNumber, string lockToken)
        {
            WriteEvent(ProcessorMessageHandlerCompleteEvent, identifier, sequenceNumber, lockToken);
        }

        [NonEvent]
        public void ProcessorMessageHandlerException(string identifier, long sequenceNumber, string exception, Guid lockToken)
        {
            if (IsEnabled())
            {
                ProcessorMessageHandlerExceptionCore(identifier, sequenceNumber, exception, lockToken.ToString());
            }
        }

        [Event(ProcessorMessageHandlerExceptionEvent, Level = EventLevel.Error, Message = "{0}: User message handler complete: Message: SequenceNumber: {1}, Exception: {2}, LockToken: {3}")]
        private void ProcessorMessageHandlerExceptionCore(string identifier, long sequenceNumber, string exception, string lockToken)
        {
            ProcessorMessageHandlerExceptionCore(ProcessorMessageHandlerExceptionEvent, identifier, sequenceNumber, exception, lockToken);
        }

        [NonEvent]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = EventSourceSuppressMessage)]
        private unsafe void ProcessorMessageHandlerExceptionCore(int eventId, string identifier, long sequenceNumber, string exception, string lockToken)
        {
            fixed (char* identifierPtr = identifier)
            fixed (char* exceptionPtr = exception)
            fixed (char* lockTokenPtr = lockToken)
            {
                var eventPayload = stackalloc EventData[4];

                eventPayload[0].Size = (identifier.Length + 1) * sizeof(char);
                eventPayload[0].DataPointer = (IntPtr)identifierPtr;

                eventPayload[1].Size = Unsafe.SizeOf<long>();
                eventPayload[1].DataPointer = (IntPtr)Unsafe.AsPointer(ref sequenceNumber);

                eventPayload[2].Size = (exception.Length + 1) * sizeof(char);
                eventPayload[2].DataPointer = (IntPtr)exceptionPtr;

                eventPayload[3].Size = (lockToken.Length + 1) * sizeof(char);
                eventPayload[3].DataPointer = (IntPtr)lockTokenPtr;

                WriteEventCore(eventId, 4, eventPayload);
            }
        }

        [Event(ProcessorClientClosedExceptionEvent, Level = EventLevel.Error, Message = "{0}: The Service Bus client associated with the processor was closed by the host application.  The processor cannot continue and is shutting down.")]
        public void ProcessorClientClosedException(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(ProcessorClientClosedExceptionEvent, identifier);
            }
        }

        [Event(ProcessorStoppingReceiveCanceledEvent, Level = EventLevel.Verbose, Message = "A receive operation was cancelled while stopping the processor or scaling down concurrency. (Identifier '{0}'). Error Message: '{1}'")]
        public void ProcessorStoppingReceiveCanceled(string identifier, string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(ProcessorStoppingReceiveCanceledEvent, identifier, exception);
            }
        }

        [Event(ProcessorStoppingAcceptSessionCanceledEvent, Level = EventLevel.Verbose, Message = "An accept session operation was cancelled while stopping the processor or scaling down concurrency. (Namespace '{0}', Entity path '{1}'). Error Message: '{2}'")]
        public void ProcessorStoppingAcceptSessionCanceled(string fullyQualifiedNamespace, string entityPath, string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(ProcessorStoppingAcceptSessionCanceledEvent, fullyQualifiedNamespace, entityPath, exception);
            }
        }

        [Event(ProcessorAcceptSessionTimeoutEvent, Level = EventLevel.Verbose, Message = "The processor accept session call timed out. It will be tried again. (Namespace '{0}', Entity path '{1}'). Error Message: '{2}'")]
        public virtual void ProcessorAcceptSessionTimeout(
            string fullyQualifiedNamespace,
            string entityPath,
            string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(ProcessorAcceptSessionTimeoutEvent, fullyQualifiedNamespace, entityPath, exception);
            }
        }

        #endregion region

        #region Rule management
        [Event(CreateRuleStartEvent, Level = EventLevel.Informational, Message = "{0}: CreateRule start. RuleName = {1}")]
        public virtual void CreateRuleStart(string identifiers, string ruleName)
        {
            if (IsEnabled())
            {
                WriteEvent(CreateRuleStartEvent, identifiers, ruleName);
            }
        }

        [Event(CreateRuleCompleteEvent, Level = EventLevel.Informational, Message = "{0}: CreateRule done. RuleName = {1}")]
        public virtual void CreateRuleComplete(string identifier, string ruleName)
        {
            if (IsEnabled())
            {
                WriteEvent(CreateRuleCompleteEvent, identifier, ruleName);
            }
        }

        [Event(CreateRuleExceptionEvent, Level = EventLevel.Error, Message = "{0}: CreateRule Exception: {1}. RuleName = {2}")]
        public virtual void CreateRuleException(string identifier, string exception, string ruleName)
        {
            if (IsEnabled())
            {
                WriteEvent(CreateRuleExceptionEvent, identifier, exception, ruleName);
            }
        }

        [Event(DeleteRuleStartEvent, Level = EventLevel.Informational, Message = "{0}: Delete rule start. RuleName = {1}")]
        public virtual void DeleteRuleStart(string identifiers, string ruleName)
        {
            if (IsEnabled())
            {
                WriteEvent(DeleteRuleStartEvent, identifiers, ruleName);
            }
        }

        [Event(DeleteRuleCompleteEvent, Level = EventLevel.Informational, Message = "{0}: Delete rule done. RuleName = {1}")]
        public virtual void DeleteRuleComplete(string identifier, string ruleName)
        {
            if (IsEnabled())
            {
                WriteEvent(DeleteRuleCompleteEvent, identifier, ruleName);
            }
        }

        [Event(DeleteRuleExceptionEvent, Level = EventLevel.Error, Message = "{0}: Delete rule Exception: {1}. RuleName = {2}")]
        public virtual void DeleteRuleException(string identifier, string exception, string ruleName)
        {
            if (IsEnabled())
            {
                WriteEvent(DeleteRuleExceptionEvent, identifier, exception, ruleName);
            }
        }

        [Event(GetRulesStartEvent, Level = EventLevel.Informational, Message = "{0}: GetRules start.")]
        public virtual void GetRulesStart(string identifiers)
        {
            if (IsEnabled())
            {
                WriteEvent(GetRulesStartEvent, identifiers);
            }
        }

        [Event(GetRulesCompleteEvent, Level = EventLevel.Informational, Message = "{0}: GetRules done.")]
        public virtual void GetRulesComplete(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(GetRulesCompleteEvent, identifier);
            }
        }

        [Event(GetRulesExceptionEvent, Level = EventLevel.Error, Message = "{0}: GetRules Exception: {1}.")]
        public virtual void GetRulesException(string identifier, string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(GetRulesExceptionEvent, identifier, exception);
            }
        }
        #endregion

        #region Link lifecycle
        [Event(LinkStateLostEvent, Level = EventLevel.Error, Message = "Link state lost. Throwing LockLostException for identifier: {0}, receiveLinkName: {1}, receiveLinkState: {2}, isSessionReceiver: {3}, exception: {4}.")]
        public virtual void LinkStateLost(string identifier, string receiveLinkName, string receiveLinkState, bool isSessionReceiver, string exception)
        {
            if (IsEnabled())
            {
                LinkStateLostCore(LinkStateLostEvent, identifier, receiveLinkName, receiveLinkState, isSessionReceiver, exception);
            }
        }

        [NonEvent]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = EventSourceSuppressMessage)]
        private unsafe void LinkStateLostCore(int eventId, string identifier, string receiveLinkName, string receiveLinkState, bool isSessionReceiver, string exception)
        {
            fixed (char* identifierPtr = identifier)
            fixed (char* receiveLinkNamePtr = receiveLinkName)
            fixed (char* receiveLinkStatePtr = receiveLinkState)
            fixed (char* exceptionPtr = exception)
            {
                var eventPayload = stackalloc EventData[5];

                eventPayload[0].Size = (identifier.Length + 1) * sizeof(char);
                eventPayload[0].DataPointer = (IntPtr)identifierPtr;

                eventPayload[1].Size = (receiveLinkName.Length + 1) * sizeof(char);
                eventPayload[1].DataPointer = (IntPtr)receiveLinkNamePtr;

                eventPayload[2].Size = (receiveLinkState.Length + 1) * sizeof(char);
                eventPayload[2].DataPointer = (IntPtr)receiveLinkStatePtr;

                // bool maps to "win:Boolean", a 4-byte boolean
                var isSessionReceiverInt = isSessionReceiver ? 1 : 0;
                eventPayload[3].Size = Unsafe.SizeOf<int>();
                eventPayload[3].DataPointer = (IntPtr)Unsafe.AsPointer(ref isSessionReceiverInt);

                eventPayload[4].Size = (exception.Length + 1) * sizeof(char);
                eventPayload[4].DataPointer = (IntPtr)exceptionPtr;

                WriteEventCore(eventId, 5, eventPayload);
            }
        }

        [NonEvent]
        public virtual void ReceiveLinkClosed(
            string identifier,
            string sessionId,
            object receiver)
        {
            if (IsEnabled())
            {
                var link = (ReceivingAmqpLink)receiver;
                if (link != null)
                {
                    Exception exception = link.GetInnerException();
                    ReceiveLinkClosedCore(
                        identifier,
                        sessionId,
                        exception?.ToString());
                }
            }
        }

        [Event(ReceiveLinkClosedEvent, Level = EventLevel.Informational, Message = "Receive Link Closed. Identifier: {0}, SessionId: {1}, linkException: {2}.")]
        public virtual void ReceiveLinkClosedCore(string identifier, string sessionId, string linkException)
        {
            if (IsEnabled())
            {
                WriteEvent(ReceiveLinkClosedEvent, identifier, sessionId, linkException);
            }
        }

        /// <summary>
        ///   Indicates that refreshing authorization for an AMQP link has started.
        /// </summary>
        ///
        /// <param name="identifier">The name of the Entity that the link is associated with.</param>
        /// <param name="endpoint">The service endpoint that the link is bound to for communication.</param>
        ///
        [Event(AmqpLinkRefreshStartEvent, Level = EventLevel.Informational, Message = "Beginning refresh of AMQP link authorization for Identifier: {0} (Service Endpoint: '{1}').")]
        public virtual void AmqpLinkAuthorizationRefreshStart(
            string identifier,
            string endpoint)
        {
            if (IsEnabled())
            {
                WriteEvent(AmqpLinkRefreshStartEvent, identifier ?? string.Empty, endpoint ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that refreshing authorization for an AMQP link has completed.
        /// </summary>
        ///
        /// <param name="identifier">The name of the Entity that the link is associated with.</param>
        /// <param name="endpoint">The service endpoint that the link is bound to for communication.</param>
        ///
        [Event(AmqpLinkRefreshCompleteEvent, Level = EventLevel.Informational, Message = "Completed refresh of AMQP link authorization for Identifier: {0} (Service Endpoint: '{1}').")]
        public virtual void AmqpLinkAuthorizationRefreshComplete(
            string identifier,
            string endpoint)
        {
            if (IsEnabled())
            {
                WriteEvent(AmqpLinkRefreshCompleteEvent, identifier ?? string.Empty, endpoint ?? string.Empty);
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
        [Event(AmqpLinkRefreshExceptionEvent, Level = EventLevel.Error, Message = "An exception occurred while refreshing AMQP link authorization for Identifier: {0} (Service Endpoint: '{1}'). Error Message: '{2}'")]
        public virtual void AmqpLinkAuthorizationRefreshError(
            string identifier,
            string endpoint,
            string errorMessage)
        {
            if (IsEnabled())
            {
                WriteEvent(AmqpLinkRefreshExceptionEvent, identifier ?? string.Empty, endpoint ?? string.Empty, errorMessage ?? string.Empty);
            }
        }

        [Event(CreateSendLinkStartEvent, Level = EventLevel.Informational, Message = "Creating send link for Identifier: {0}.")]
        public virtual void CreateSendLinkStart(
            string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(CreateSendLinkStartEvent, identifier);
            }
        }

        [Event(CreateSendLinkCompleteEvent, Level = EventLevel.Informational, Message = "Send link created for Identifier: {0}.")]
        public virtual void CreateSendLinkComplete(
            string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(CreateSendLinkCompleteEvent, identifier);
            }
        }

        [Event(CreateSendLinkExceptionEvent, Level = EventLevel.Verbose, Message = "An exception occurred while creating send link for Identifier: {0}. Error Message: '{1}'")]
        public virtual void CreateSendLinkException(
            string identifier,
            string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(CreateSendLinkExceptionEvent, identifier, exception);
            }
        }

        [NonEvent]
        public virtual void SendLinkClosed(
            string identifier,
            object sender)
        {
            if (IsEnabled())
            {
                var link = (SendingAmqpLink)sender;
                if (link != null)
                {
                    Exception exception = link.GetInnerException();
                    SendLinkClosedCore(
                        identifier,
                        exception?.ToString());
                }
            }
        }

        [Event(SendLinkClosedEvent, Level = EventLevel.Informational, Message = "Send Link Closed. Identifier: {0}, linkException: {1}.")]
        public virtual void SendLinkClosedCore(
            string identifier,
            string linkException)
        {
            if (IsEnabled())
            {
                WriteEvent(SendLinkClosedEvent, identifier, linkException);
            }
        }

        [Event(CreateReceiveLinkStartEvent, Level = EventLevel.Informational, Message = "Creating receive link for Identifier: {0}.")]
        public virtual void CreateReceiveLinkStart(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(CreateReceiveLinkStartEvent, identifier);
            }
        }

        [Event(CreateReceiveLinkCompleteEvent, Level = EventLevel.Informational, Message = "Receive link created for Identifier: {0}. Session Id: {1}")]
        public virtual void CreateReceiveLinkComplete(string identifier, string sessionId)
        {
            if (IsEnabled())
            {
                WriteEvent(CreateReceiveLinkCompleteEvent, identifier, sessionId);
            }
        }

        [Event(CreateReceiveLinkExceptionEvent, Level = EventLevel.Verbose, Message = "An exception occurred while creating receive link for Identifier: {0}. Error Message: '{1}'")]
        public virtual void CreateReceiveLinkException(string identifier, string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(CreateReceiveLinkExceptionEvent, identifier, exception);
            }
        }

        [Event(CreateManagementLinkStartEvent, Level = EventLevel.Informational, Message = "Creating management link for Identifier: {0}.")]
        public virtual void CreateManagementLinkStart(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(CreateManagementLinkStartEvent, identifier);
            }
        }

        [Event(CreateManagementLinkCompleteEvent, Level = EventLevel.Informational, Message = "Management link created for Identifier: {0}.")]
        public virtual void CreateManagementLinkComplete(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(CreateManagementLinkCompleteEvent, identifier);
            }
        }

        [Event(CreateManagementLinkExceptionEvent, Level = EventLevel.Verbose, Message = "An exception occurred while creating management link for Identifier: {0}. Error Message: '{1}'")]
        public virtual void CreateManagementLinkException(string identifier, string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(CreateManagementLinkExceptionEvent, identifier, exception);
            }
        }

        [NonEvent]
        public virtual void ManagementLinkClosed(
            string identifier,
            object managementLink)
        {
            if (IsEnabled())
            {
                var link = (RequestResponseAmqpLink)managementLink;
                if (link != null)
                {
                    Exception exception = link.GetInnerException();
                    ManagementLinkClosedCore(
                        identifier,
                        exception?.ToString());
                }
            }
        }

        [Event(ManagementLinkClosedEvent, Level = EventLevel.Informational, Message = "Management Link Closed. Identifier: {0}, linkException: {1}.")]
        public virtual void ManagementLinkClosedCore(
            string identifier,
            string linkException)
        {
            if (IsEnabled())
            {
                WriteEvent(ManagementLinkClosedEvent, identifier, linkException);
            }
        }

        [Event(RequestAuthorizationStartEvent, Level = EventLevel.Verbose, Message = "{0}: Requesting authorization to {1}")]
        public virtual void RequestAuthorizationStart(string identifier, string endpoint)
        {
            if (IsEnabled())
            {
                WriteEvent(RequestAuthorizationStartEvent, identifier, endpoint);
            }
        }

        [Event(RequestAuthorizationCompleteEvent, Level = EventLevel.Verbose, Message = "{0}: Authorization to {1} complete. Expiration time: {2}")]
        public virtual void RequestAuthorizationComplete(string identifier, string endpoint, string expiration)
        {
            if (IsEnabled())
            {
                WriteEvent(RequestAuthorizationCompleteEvent, identifier, endpoint, expiration);
            }
        }

        [Event(RequestAuthorizationExceptionEvent, Level = EventLevel.Verbose, Message = "{0}: An exception occured while requesting authorization to {1}. Exception: {2}.")]
        public virtual void RequestAuthorizationException(string identifier, string endpoint, string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(RequestAuthorizationExceptionEvent, identifier, endpoint, exception);
            }
        }

        [Event(DrainLinkStartEvent, Level = EventLevel.Verbose, Message = "{0}: Starting drain operation.")]
        public void DrainLinkStart(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(DrainLinkStartEvent, identifier ?? string.Empty);
            }
        }

        [Event(DrainLinkCompleteEvent, Level = EventLevel.Verbose, Message = "{0}: Drain operation completed.")]
        public void DrainLinkComplete(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(DrainLinkCompleteEvent, identifier ?? string.Empty);
            }
        }

        [Event(DrainLinkExceptionEvent, Level = EventLevel.Error, Message = "{0}: Drain operation failed with exception: {1}")]
        public void DrainLinkException(string identifier, string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(DrainLinkExceptionEvent, identifier ?? string.Empty, exception);
            }
        }

        [Event(CloseLinkStartEvent, Level = EventLevel.Verbose, Message = "{0}: Starting closure of AMQP link.")]
        public void CloseLinkStart(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(CloseLinkStartEvent, identifier ?? string.Empty);
            }
        }

        [Event(CloseLinkCompleteEvent, Level = EventLevel.Verbose, Message = "{0}: Closing AMQP link completed.")]
        public void CloseLinkComplete(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(CloseLinkCompleteEvent, identifier ?? string.Empty);
            }
        }
        #endregion

        #region Retries

        [Event(RunOperationExceptionEvent, Level = EventLevel.Warning, Message = "RunOperation encountered an exception and will retry. Exception: {0}")]
        public virtual void RunOperationExceptionEncountered(string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(RunOperationExceptionEvent, exception);
            }
        }

        [Event(RunOperationExceptionVerboseEvent, Level = EventLevel.Verbose, Message = "RunOperation encountered an exception and will retry. Exception: {0}")]
        public virtual void RunOperationExceptionEncounteredVerbose(string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(RunOperationExceptionVerboseEvent, exception);
            }
        }
        #endregion

        #region Client lifecycle

        /// <summary>
        ///   Indicates that a client is being created, which may correspond to
        ///   a <see cref="ServiceBusClient" />, <see cref="ServiceBusSender" />,
        ///   or <see cref="ServiceBusReceiver"/>.
        /// </summary>
        ///
        /// <param name="clientType">The type of client being created.</param>
        /// <param name="fullyQualifiedNamespace">The namespace for the client.</param>
        /// <param name="entityName">The entity name for the client.</param>
        [NonEvent]
        public virtual void ClientCreateStart(
            Type clientType,
            string fullyQualifiedNamespace,
            string entityName = default)
        {
            if (IsEnabled())
            {
                ClientCreateStartCore(clientType.Name, fullyQualifiedNamespace, entityName ?? string.Empty);
            }
        }

        [Event(ClientCreateStartEvent, Level = EventLevel.Verbose, Message = "Creating a {0} (Namespace: '{1}', Entity name: '{2}'")]
        public virtual void ClientCreateStartCore(
            string clientType,
            string fullyQualifiedNamespace,
            string entityName = default)
        {
            if (IsEnabled())
            {
                WriteEvent(ClientCreateStartEvent, clientType, fullyQualifiedNamespace, entityName);
            }
        }

        /// <summary>
        ///   Indicates that a client has been created, which may correspond to a
        ///   <see cref="ServiceBusClient" />, <see cref="ServiceBusSender" />, or
        ///   <see cref="ServiceBusReceiver"/>.
        /// </summary>
        ///
        /// <param name="clientType">The type of client being closed.</param>
        /// <param name="identifier">An identifier to associate with the client.</param>
        ///
        [NonEvent]
        public virtual void ClientCreateComplete(
            Type clientType,
            string identifier)
        {
            if (IsEnabled())
            {
                ClientCreateCompleteCore(clientType.Name, identifier ?? string.Empty);
            }
        }

        [Event(ClientCreateCompleteEvent, Level = EventLevel.Verbose, Message = "A {0} has been created (Identifier '{1}').")]
        public virtual void ClientCreateCompleteCore(
            string clientType,
            string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(ClientCreateCompleteEvent, clientType, identifier ?? string.Empty);
            }
        }

        /// <summary>
        ///   Indicates that an exception was encountered while creating
        ///   <see cref="ServiceBusClient" />, <see cref="ServiceBusSender" />, or
        ///   <see cref="ServiceBusReceiver"/>.
        /// </summary>
        ///
        /// <param name="clientType">The type of client being closed.</param>
        /// <param name="fullyQualifiedNamespace">The namespace for the client.</param>
        /// <param name="entityPath">The entity path for the client.</param>
        /// <param name="exception">The message for the exception that occurred.</param>
        ///
        [NonEvent]
        public virtual void ClientCreateException(
            Type clientType,
            string fullyQualifiedNamespace,
            string entityPath,
            Exception exception)
        {
            if (IsEnabled())
            {
                ClientCreateExceptionCore(clientType.Name, fullyQualifiedNamespace, entityPath, exception.ToString());
            }
        }

        [Event(ClientCreateExceptionEvent, Level = EventLevel.Error, Message = "An exception occurred while creating a {0} (Namespace '{1}', Entity path '{2}'). Error Message: '{3}'")]
        public virtual void ClientCreateExceptionCore(
            string clientType,
            string fullyQualifiedNamespace,
            string entityPath,
            string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(ClientCreateExceptionEvent, clientType, fullyQualifiedNamespace, entityPath, exception);
            }
        }

        /// <summary>
        ///   Indicates that a client is closing, which may correspond to
        ///   a <see cref="ServiceBusClient" />, <see cref="ServiceBusSender" />,
        ///   <see cref="ServiceBusReceiver"/>, or a <see cref="ServiceBusProcessor"/>.
        /// </summary>
        ///
        /// <param name="clientType">The type of client being closed.</param>
        /// <param name="identifier">An identifier to associate with the client.</param>
        ///
        [NonEvent]
        public virtual void ClientCloseStart(
            Type clientType,
            string identifier)
        {
            if (IsEnabled())
            {
                ClientCloseStartCore(clientType.Name, identifier ?? string.Empty);
            }
        }

        [Event(ClientCloseStartEvent, Level = EventLevel.Verbose, Message = "Closing a {0} (Identifier '{1}').")]
        public virtual void ClientCloseStartCore(
            string clientType,
            string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(ClientCloseStartEvent, clientType, identifier);
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
        [NonEvent]
        public virtual void ClientCloseComplete(
            Type clientType,
            string identifier)
        {
            if (IsEnabled())
            {
                ClientCloseCompleteCore(clientType.Name, identifier ?? string.Empty);
            }
        }

        [Event(ClientCloseCompleteEvent, Level = EventLevel.Verbose, Message = "A {0} has been closed (Identifier '{1}').")]
        public virtual void ClientCloseCompleteCore(
            string clientType,
            string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(ClientCloseCompleteEvent, clientType, identifier);
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
        [NonEvent]
        public virtual void ClientCloseException(
            Type clientType,
            string identifier,
            Exception exception)
        {
            if (IsEnabled())
            {
                ClientCloseExceptionCore(clientType.Name, identifier ?? string.Empty, exception.ToString());
            }
        }

        [Event(ClientCloseExceptionEvent, Level = EventLevel.Error, Message = "An exception occurred while closing a {0} (Identifier '{1}'). Error Message: '{2}'")]
        public virtual void ClientCloseExceptionCore(
            string clientType,
            string identifier,
            string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(ClientCloseExceptionEvent, clientType, identifier, exception);
            }
        }
        #endregion

        #region transactions
        [Event(TransactionInitializationExceptionEvent, Level = EventLevel.Error, Message = "AmqpTransactionInitializeException for TransactionId: {0} Exception: {1}.")]
        public void TransactionInitializeException(string transactionId, string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(TransactionInitializationExceptionEvent, transactionId, exception);
            }
        }

        [NonEvent]
        public void TransactionDeclared(string localTransactionId, ArraySegment<byte> amqpTransactionId)
        {
            if (IsEnabled())
            {
                TransactionDeclared(localTransactionId, amqpTransactionId.GetAsciiString());
            }
        }

        [Event(TransactionDeclaredEvent, Level = EventLevel.Informational, Message = "AmqpTransactionDeclared for LocalTransactionId: {0} AmqpTransactionId: {1}.")]
        public void TransactionDeclared(string transactionId, string amqpTransactionId)
        {
            if (IsEnabled())
            {
                WriteEvent(TransactionDeclaredEvent, transactionId, amqpTransactionId);
            }
        }

        [NonEvent]
        public void TransactionDischarged(string localTransactionId, ArraySegment<byte> amqpTransactionId, bool rollback)
        {
            if (IsEnabled())
            {
                TransactionDischarged(localTransactionId, amqpTransactionId.GetAsciiString(), rollback);
            }
        }

        [Event(TransactionDischargedEvent, Level = EventLevel.Informational, Message = "AmqpTransactionDischarged for LocalTransactionId: {0} AmqpTransactionId: {1} Rollback: {2}.")]
        public void TransactionDischarged(string transactionId, string amqpTransactionId, bool rollback)
        {
            if (IsEnabled())
            {
                TransactionDischargedCore(TransactionDischargedEvent, transactionId, amqpTransactionId, rollback);
            }
        }

        [NonEvent]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = EventSourceSuppressMessage)]
        private unsafe void TransactionDischargedCore(int eventId, string transactionId, string amqpTransactionId, bool rollback)
        {
            fixed (char* transactionIdPtr = transactionId)
            fixed (char* amqpTransactionIdPtr = amqpTransactionId)
            {
                var eventPayload = stackalloc EventData[3];

                eventPayload[0].Size = (transactionId.Length + 1) * sizeof(char);
                eventPayload[0].DataPointer = (IntPtr)transactionIdPtr;

                eventPayload[1].Size = (amqpTransactionId.Length + 1) * sizeof(char);
                eventPayload[1].DataPointer = (IntPtr)amqpTransactionIdPtr;

                // bool maps to "win:Boolean", a 4-byte boolean
                var rollbackInt = rollback ? 1 : 0;
                eventPayload[2].Size = Unsafe.SizeOf<int>();
                eventPayload[2].DataPointer = (IntPtr)Unsafe.AsPointer(ref rollbackInt);

                WriteEventCore(eventId, 3, eventPayload);
            }
        }

        [NonEvent]
        public void TransactionDischargeException(string transactionId, ArraySegment<byte> amqpTransactionId, Exception exception)
        {
            if (IsEnabled())
            {
                TransactionDischargeException(transactionId, amqpTransactionId.GetAsciiString(), exception.ToString());
            }
        }

        [Event(TransactionDischargedExceptionEvent, Level = EventLevel.Error, Message = "AmqpTransactionDischargeException for TransactionId: {0} AmqpTransactionId: {1} Exception: {2}.")]
        public void TransactionDischargeException(string transactionId, string amqpTransactionId, string exception)
        {
            WriteEvent(TransactionDischargedExceptionEvent, transactionId, amqpTransactionId, exception);
        }

        [Event(CreateControllerExceptionEvent, Level = EventLevel.Error, Message = "AmqpCreateControllerException for ConnectionManager: {0} Exception: {1}.")]
        public void CreateControllerException(string connectionManager, string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(CreateControllerExceptionEvent, connectionManager, exception);
            }
        }
        #endregion

        #region misc
        [NonEvent]
        public void ScheduleTaskFailed(Func<Task> task, Exception exception)
        {
            if (IsEnabled())
            {
                ScheduleTaskFailed(task.Target.GetType().FullName, task.GetMethodInfo().Name, exception.ToString());
            }
        }

        [Event(ScheduleTaskFailedEvent, Level = EventLevel.Error, Message = "Exception during Schedule Task. FunctionTargetName: {0}, MethodInfoName: {1}, Exception:{2}")]
        public void ScheduleTaskFailed(string funcTargetName, string methodInfoName, string exception)
        {
            WriteEvent(ScheduleTaskFailedEvent, funcTargetName, methodInfoName, exception);
        }

        [Event(ManagementSerializedExceptionEvent, Level = EventLevel.Warning, Message = "[De]Serialization failed for object:{0}; Details:{1}")]
        public void ManagementSerializationException(string objectName, string details = "")
        {
            if (IsEnabled())
            {
                WriteEvent(ManagementSerializedExceptionEvent, objectName, details);
            }
        }

        [Event(MaxMessagesExceedsPrefetchEvent, Level = EventLevel.Warning, Message = "Prefetch count for receiver with Identifier {0} is less than the max messages requested. When using prefetch, it isn't possible to receive more than the prefetch count in any single Receive call: PrefetchCount: {1}; MaxMessages: {2}")]
        public virtual void MaxMessagesExceedsPrefetch(string identifier, int prefetchCount, int maxMessages)
        {
            if (IsEnabled())
            {
                WriteEvent(MaxMessagesExceedsPrefetchEvent, identifier, prefetchCount, maxMessages);
            }
        }

        [Event(PartitionKeyValueOverwritten, Level = EventLevel.Warning, Message = "The PartitionKey property with value '{0}' was overwritten with value '{1}' due to setting the SessionId on message with MessageId '{2}'")]
        public virtual void PartitionKeyOverwritten(string partitionKey, string sessionId, string messageId)
        {
            if (IsEnabled())
            {
                WriteEvent(PartitionKeyValueOverwritten,partitionKey, sessionId, messageId);
            }
        }
        #endregion

        /// <summary>
        /// Writes an event with two string arguments and one int argument into a stack allocated
        /// <see cref="EventSource.EventData"/> struct to avoid the parameter array allocation and boxing
        /// on the WriteEvent methods.
        /// </summary>
        /// <param name="eventId">The event identifier.</param>
        /// <param name="arg1">The first argument.</param>
        /// <param name="arg2">The second argument.</param>
        /// <param name="arg3">The third argument.</param>
        [NonEvent]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = EventSourceSuppressMessage)]
        private unsafe void WriteEvent(int eventId, string arg1, int arg2, string arg3)
        {
            fixed (char* arg1Ptr = arg1)
            fixed (char* arg3Ptr = arg3)
            {
                var eventPayload = stackalloc EventData[3];

                eventPayload[0].Size = (arg1.Length + 1) * sizeof(char);
                eventPayload[0].DataPointer = (IntPtr)arg1Ptr;

                eventPayload[1].Size = Unsafe.SizeOf<int>();
                eventPayload[1].DataPointer = (IntPtr)Unsafe.AsPointer(ref arg2);

                eventPayload[2].Size = (arg3.Length + 1) * sizeof(char);
                eventPayload[2].DataPointer = (IntPtr)arg3Ptr;

                WriteEventCore(eventId, 3, eventPayload);
            }
        }

        /// <summary>
        /// Writes an event with two string arguments and one long argument into a stack allocated
        /// <see cref="EventSource.EventData"/> struct to avoid the parameter array allocation and boxing
        /// on the WriteEvent methods.
        /// </summary>
        /// <param name="eventId">The event identifier.</param>
        /// <param name="arg1">The first argument.</param>
        /// <param name="arg2">The second argument.</param>
        /// <param name="arg3">The third argument.</param>
        [NonEvent]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = EventSourceSuppressMessage)]
        private unsafe void WriteEvent(int eventId, string arg1, long arg2, string arg3)
        {
            fixed (char* arg1Ptr = arg1)
            fixed (char* arg3Ptr = arg3)
            {
                var eventPayload = stackalloc EventData[3];

                eventPayload[0].Size = (arg1.Length + 1) * sizeof(char);
                eventPayload[0].DataPointer = (IntPtr)arg1Ptr;

                eventPayload[1].Size = Unsafe.SizeOf<long>();
                eventPayload[1].DataPointer = (IntPtr)Unsafe.AsPointer(ref arg2);

                eventPayload[2].Size = (arg3.Length + 1) * sizeof(char);
                eventPayload[2].DataPointer = (IntPtr)arg3Ptr;

                WriteEventCore(eventId, 3, eventPayload);
            }
        }

        /// <summary>
        /// Writes an event with four string arguments into a stack allocated <see cref="EventSource.EventData"/> struct to avoid
        /// the parameter array allocation on the WriteEvent methods.
        /// </summary>
        /// <param name="eventId">The event identifier.</param>
        /// <param name="arg1">The first argument.</param>
        /// <param name="arg2">The second argument.</param>
        /// <param name="arg3">The third argument.</param>
        /// <param name="arg4">The fourth argument.</param>
        [NonEvent]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = EventSourceSuppressMessage)]
        private unsafe void WriteEvent(int eventId, string arg1, string arg2, string arg3, string arg4)
        {
            fixed (char* arg1Ptr = arg1)
            fixed (char* arg2Ptr = arg2)
            fixed (char* arg3Ptr = arg3)
            fixed (char* arg4Ptr = arg4)
            {
                var eventPayload = stackalloc EventData[4];

                eventPayload[0].Size = (arg1.Length + 1) * sizeof(char);
                eventPayload[0].DataPointer = (IntPtr)arg1Ptr;

                eventPayload[1].Size = (arg2.Length + 1) * sizeof(char);
                eventPayload[1].DataPointer = (IntPtr)arg2Ptr;

                eventPayload[2].Size = (arg3.Length + 1) * sizeof(char);
                eventPayload[2].DataPointer = (IntPtr)arg3Ptr;

                eventPayload[3].Size = (arg4.Length + 1) * sizeof(char);
                eventPayload[3].DataPointer = (IntPtr)arg4Ptr;

                WriteEventCore(eventId, 4, eventPayload);
            }
        }
    }
}
