// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Reflection;
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
    ///   When defining Start/Stop tasks, it is highly recommended that the
    ///   the StopEvent.Id must be exactly StartEvent.Id + 1.
    /// </remarks>
    [EventSource(Name = EventSourceName)]
    internal class ServiceBusEventSource : EventSource
    {
        /// <summary>The name to use for the event source.</summary>
        private const string EventSourceName = "Azure-Messaging-ServiceBus";

        /// <summary>
        ///   Provides a singleton instance of the event source for callers to
        ///   use for logging.
        /// </summary>
        public static ServiceBusEventSource Log { get; } = new ServiceBusEventSource(EventSourceName);

        /// <summary>
        ///   Prevents an instance of the <see cref="ServiceBusEventSource"/> class from being
        ///   created outside the scope of the <see cref="Log" /> instance, as well as setting up the
        ///   integration with AzureEventSourceListener.
        /// </summary>
        private ServiceBusEventSource(string eventSourceName) : base(eventSourceName, EventSourceSettings.Default, AzureEventSourceListener.TraitName, AzureEventSourceListener.TraitValue)
        {
        }

        // Parameterless constructor for mocking
        internal ServiceBusEventSource() { }

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

        internal const int AddRuleStartEvent = 68;
        internal const int AddRuleCompleteEvent = 69;
        internal const int AddRuleExceptionEvent = 70;

        internal const int RemoveRuleStartEvent = 71;
        internal const int RemoveRuleCompleteEvent = 72;
        internal const int RemoveRuleExceptionEvent = 73;

        internal const int GetRuleStartEvent = 74;
        internal const int GetRuleCompleteEvent = 75;
        internal const int GetRuleExceptionEvent = 76;

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

        internal const int PluginStartEvent = 96;
        internal const int PluginCompleteEvent = 97;
        internal const int PluginExceptionEvent = 98;

        internal const int MaxMessagesExceedsPrefetchEvent = 99;
        internal const int SendLinkClosedEvent = 100;
        internal const int ManagementLinkClosedEvent = 101;

        internal const int ProcessorMessageHandlerStartEvent = 102;
        internal const int ProcessorMessageHandlerCompleteEvent = 103;
        internal const int ProcessorMessageHandlerExceptionEvent = 104;

        internal const int RequestAuthorizationStartEvent = 105;
        internal const int RequestAuthorizationCompleteEvent = 106;
        internal const int RequestAuthorizationExceptionEvent = 107;

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

        [Event(ReceiveMessageCompleteEvent, Level = EventLevel.Informational, Message = "{0}: ReceiveBatchAsync done. Received '{1}' messages")]
        public virtual void ReceiveMessageComplete(
            string identifier,
            int messageCount)
        {
            if (IsEnabled())
            {
                WriteEvent(ReceiveMessageCompleteEvent, identifier, messageCount);
            }
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

        [Event(ReceiveDeferredMessageStartEvent, Level = EventLevel.Informational, Message = "{0}: ReceiveDeferredMessageAsync start. MessageCount = {1}, SequenceNumbers = {2}")]
        public void ReceiveDeferredMessageStartCore(string identifier, int messageCount, string sequenceNumbers)
        {
            WriteEvent(ReceiveDeferredMessageStartEvent, identifier, messageCount, sequenceNumbers);
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
        #endregion

        #region Peeking
        [Event(PeekMessageStartEvent, Level = EventLevel.Informational, Message = "{0}: MessagePeekAsync start. SequenceNumber = {1}, MessageCount = {2}")]
        public virtual void PeekMessageStart(string identifier, long? sequenceNumber, int messageCount)
        {
            if (IsEnabled())
            {
                WriteEvent(PeekMessageStartEvent, identifier, sequenceNumber, messageCount);
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
        [Event(CompleteMessageStartEvent, Level = EventLevel.Informational, Message = "{0}: CompleteAsync start. MessageCount = {1}, LockTokens = {2}")]
        public virtual void CompleteMessageStart(string identifier, int messageCount, string lockTokens)
        {
            if (IsEnabled())
            {
                WriteEvent(CompleteMessageStartEvent, identifier, messageCount, lockTokens);
            }
        }

        [Event(CompleteMessageCompleteEvent, Level = EventLevel.Informational, Message = "{0}: CompleteAsync done.")]
        public virtual void CompleteMessageComplete(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(CompleteMessageCompleteEvent, identifier);
            }
        }

        [Event(CompleteMessageExceptionEvent, Level = EventLevel.Error, Message = "{0}: CompleteAsync Exception: {1}.")]
        public virtual void CompleteMessageException(string identifier, string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(CompleteMessageExceptionEvent, identifier, exception);
            }
        }

        [Event(DeferMessageStartEvent, Level = EventLevel.Informational, Message = "{0}: DeferAsync start. MessageCount = {1}, LockToken = {2}")]
        public virtual void DeferMessageStart(string identifier, int messageCount, string lockToken)
        {
            if (IsEnabled())
            {
                WriteEvent(DeferMessageStartEvent, identifier, messageCount, lockToken);
            }
        }

        [Event(DeferMessageCompleteEvent, Level = EventLevel.Informational, Message = "{0}: DeferAsync done.")]
        public virtual void DeferMessageComplete(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(DeferMessageCompleteEvent, identifier);
            }
        }

        [Event(DeferMessageExceptionEvent, Level = EventLevel.Error, Message = "{0}: DeferAsync Exception: {1}.")]
        public virtual void DeferMessageException(string identifier, string exception)
        {
            WriteEvent(DeferMessageExceptionEvent, identifier, exception);
        }

        [Event(AbandonMessageStartEvent, Level = EventLevel.Informational, Message = "{0}: AbandonAsync start. MessageCount = {1}, LockToken = {2}")]
        public virtual void AbandonMessageStart(string identifier, int messageCount, string lockToken)
        {
            if (IsEnabled())
            {
                WriteEvent(AbandonMessageStartEvent, identifier, messageCount, lockToken);
            }
        }

        [Event(AbandonMessageCompleteEvent, Level = EventLevel.Informational, Message = "{0}: AbandonAsync done.")]
        public virtual void AbandonMessageComplete(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(AbandonMessageCompleteEvent, identifier);
            }
        }

        [Event(AbandonMessageExceptionEvent, Level = EventLevel.Error, Message = "{0}: AbandonAsync Exception: {1}.")]
        public virtual void AbandonMessageException(string identifier, string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(AbandonMessageExceptionEvent, identifier, exception);
            }
        }

        [Event(DeadLetterMessageStartEvent, Level = EventLevel.Informational, Message = "{0}: DeadLetterAsync start. MessageCount = {1}, LockToken = {2}")]
        public virtual void DeadLetterMessageStart(string identifier, int messageCount, string lockToken)
        {
            if (IsEnabled())
            {
                WriteEvent(DeadLetterMessageStartEvent, identifier, messageCount, lockToken);
            }
        }

        [Event(DeadLetterMessageCompleteEvent, Level = EventLevel.Informational, Message = "{0}: DeadLetterAsync done.")]
        public virtual void DeadLetterMessageComplete(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(DeadLetterMessageCompleteEvent, identifier);
            }
        }

        [Event(DeadLetterMessageExceptionEvent, Level = EventLevel.Error, Message = "{0}: DeadLetterAsync Exception: {1}.")]
        public virtual void DeadLetterMessageException(string identifier, string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(DeadLetterMessageExceptionEvent, identifier, exception);
            }
        }
        #endregion

        #region Lock renewal
        [Event(RenewMessageLockStartEvent, Level = EventLevel.Informational, Message = "{0}: RenewLockAsync start. MessageCount = {1}, LockToken = {2}")]
        public virtual void RenewMessageLockStart(string identifier, int messageCount, string lockToken)
        {
            if (IsEnabled())
            {
                WriteEvent(RenewMessageLockStartEvent, identifier, messageCount, lockToken);
            }
        }

        [Event(RenewMessageLockCompleteEvent, Level = EventLevel.Informational, Message = "{0}: RenewLockAsync done.")]
        public virtual void RenewMessageLockComplete(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(RenewMessageLockCompleteEvent, identifier);
            }
        }

        [Event(RenewMessageLockExceptionEvent, Level = EventLevel.Error, Message = "{0}: RenewLockAsync Exception: {1}.")]
        public virtual void RenewMessageLockException(string identifier, string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(RenewMessageLockExceptionEvent, identifier, exception);
            }
        }

        [Event(RenewSessionLockStartEvent, Level = EventLevel.Informational, Message = "{0}: RenewSessionLockAsync start. SessionId = {1}")]
        public virtual void RenewSessionLockStart(string identifier, string sessionId)
        {
            if (IsEnabled())
            {
                WriteEvent(RenewSessionLockStartEvent, identifier, sessionId);
            }
        }

        [Event(RenewSessionLockCompleteEvent, Level = EventLevel.Informational, Message = "{0}: RenewSessionLockAsync done.")]
        public virtual void RenewSessionLockComplete(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(RenewSessionLockCompleteEvent, identifier);
            }
        }

        [Event(RenewSessionLockExceptionEvent, Level = EventLevel.Error, Message = "{0}: RenewSessionLockAsync Exception: {1}.")]
        public virtual void RenewSessionLockException(string identifier, string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(RenewSessionLockExceptionEvent, identifier, exception);
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

        [Event(GetSessionStateCompleteEvent, Level = EventLevel.Informational, Message = "{0}: Session GetStateAsync done.")]
        public virtual void GetSessionStateComplete(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(GetSessionStateCompleteEvent, identifier);
            }
        }

        [Event(GetSessionStateExceptionEvent, Level = EventLevel.Error, Message = "{0}: Session GetStateAsync Exception: {1}.")]
        public virtual void GetSessionStateException(string identifier, string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(GetSessionStateExceptionEvent, identifier, exception);
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

        [Event(SetSessionStateCompleteEvent, Level = EventLevel.Informational, Message = "{0}: Session SetStateAsync done.")]
        public virtual void SetSessionStateComplete(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(SetSessionStateCompleteEvent, identifier);
            }
        }

        [Event(SetSessionStateExceptionEvent, Level = EventLevel.Error, Message = "{0}: Session SetStateAsync Exception: {1}.")]
        public virtual void SetSessionStateException(string identifier, string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(SetSessionStateExceptionEvent, identifier, exception);
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

        [Event(ProcessorRenewMessageLockStartEvent, Level = EventLevel.Informational, Message = "{0}: Processor RenewMessageLock start. MessageCount = {1}, LockToken = {2}")]
        public virtual void ProcessorRenewMessageLockStart(string identifier, int messageCount, string lockToken)
        {
            if (IsEnabled())
            {
                WriteEvent(ProcessorRenewMessageLockStartEvent, identifier, messageCount, lockToken);
            }
        }

        [Event(ProcessorRenewMessageLockCompleteEvent, Level = EventLevel.Informational, Message = "{0}: Processor RenewMessageLock complete.")]
        public virtual void ProcessorRenewMessageLockComplete(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(ProcessorRenewMessageLockCompleteEvent, identifier);
            }
        }

        [Event(ProcessorRenewMessageLockExceptionEvent, Level = EventLevel.Error, Message = "{0}: Processor RenewMessageLock Exception: {1}.")]
        public virtual void ProcessorRenewMessageLockException(string identifier, string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(ProcessorRenewMessageLockExceptionEvent, identifier, exception);
            }
        }

        [Event(ProcessorRenewSessionLockStartEvent, Level = EventLevel.Informational, Message = "{0}: Processor RenewSessionLock start. SessionId = {1}")]
        public virtual void ProcessorRenewSessionLockStart(string identifier, string sessionId)
        {
            if (IsEnabled())
            {
                WriteEvent(ProcessorRenewSessionLockStartEvent, identifier, sessionId);
            }
        }

        [Event(ProcessorRenewSessionLockCompleteEvent, Level = EventLevel.Informational, Message = "{0}: Processor RenewSessionLock complete.")]
        public virtual void ProcessorRenewSessionLockComplete(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(ProcessorRenewSessionLockCompleteEvent, identifier);
            }
        }

        [Event(ProcessorRenewSessionLockExceptionEvent, Level = EventLevel.Error, Message = "{0}: Processor RenewSessionLock Exception: {1}.")]
        public virtual void ProcessorRenewSessionLockException(string identifier, string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(ProcessorRenewSessionLockExceptionEvent, identifier, exception);
            }
        }

        [Event(ProcessorErrorHandlerThrewExceptionEvent, Level = EventLevel.Error, Message = "ExceptionReceivedHandler threw exception. Exception:{0}")]
        public void ProcessorErrorHandlerThrewException(string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(ProcessorErrorHandlerThrewExceptionEvent, exception);
            }
        }

        [Event(ProcessorMessageHandlerStartEvent, Level = EventLevel.Informational, Message = "{0}: User message handler start: Message: SequenceNumber: {1}")]
        public void ProcessorMessageHandlerStart(string identifier, long sequenceNumber)
        {
            if (IsEnabled())
            {
                WriteEvent(ProcessorMessageHandlerStartEvent, identifier, sequenceNumber);
            }
        }

        [Event(ProcessorMessageHandlerCompleteEvent, Level = EventLevel.Informational, Message = "{0}: User message handler complete: Message: SequenceNumber: {1}")]
        public void ProcessorMessageHandlerComplete(string identifier, long sequenceNumber)
        {
            if (IsEnabled())
            {
                WriteEvent(ProcessorMessageHandlerCompleteEvent, identifier, sequenceNumber);
            }
        }

        [Event(ProcessorMessageHandlerExceptionEvent, Level = EventLevel.Error, Message = "{0}: User message handler complete: Message: SequenceNumber: {1}, Exception: {2}")]
        public void ProcessorMessageHandlerException(string identifier, long sequenceNumber, string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(ProcessorMessageHandlerExceptionEvent, identifier, sequenceNumber, exception);
            }
        }

        #endregion region

        #region Rule management
        [Event(AddRuleStartEvent, Level = EventLevel.Informational, Message = "{0}: Add rule start. RuleName = {1}")]
        public virtual void AddRuleStart(string identifiers, string ruleName)
        {
            if (IsEnabled())
            {
                WriteEvent(AddRuleStartEvent, identifiers, ruleName);
            }
        }

        [Event(AddRuleCompleteEvent, Level = EventLevel.Informational, Message = "{0}: Add rule done.")]
        public virtual void AddRuleComplete(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(AddRuleCompleteEvent, identifier);
            }
        }

        [Event(AddRuleExceptionEvent, Level = EventLevel.Error, Message = "{0}: Add rule Exception: {1}.")]
        public virtual void AddRuleException(string identifier, string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(AddRuleExceptionEvent, identifier, exception);
            }
        }

        [Event(RemoveRuleStartEvent, Level = EventLevel.Informational, Message = "{0}: Remove rule start. RuleName = {1}")]
        public virtual void RemoveRuleStart(string identifiers, string ruleName)
        {
            if (IsEnabled())
            {
                WriteEvent(RemoveRuleStartEvent, identifiers, ruleName);
            }
        }

        [Event(RemoveRuleCompleteEvent, Level = EventLevel.Informational, Message = "{0}: Remove rule done.")]
        public virtual void RemoveRuleComplete(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(RemoveRuleCompleteEvent, identifier);
            }
        }

        [Event(RemoveRuleExceptionEvent, Level = EventLevel.Error, Message = "{0}: Remove rule Exception: {1}.")]
        public virtual void RemoveRuleException(string identifier, string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(RemoveRuleExceptionEvent, identifier, exception);
            }
        }

        [Event(GetRuleStartEvent, Level = EventLevel.Informational, Message = "{0}: Get rule start.")]
        public virtual void GetRuleStart(string identifiers)
        {
            if (IsEnabled())
            {
                WriteEvent(GetRuleStartEvent, identifiers);
            }
        }

        [Event(GetRuleCompleteEvent, Level = EventLevel.Informational, Message = "{0}: Get rule done.")]
        public virtual void GetRuleComplete(string identifier)
        {
            if (IsEnabled())
            {
                WriteEvent(GetRuleCompleteEvent, identifier);
            }
        }

        [Event(GetRuleExceptionEvent, Level = EventLevel.Error, Message = "{0}: Get rule Exception: {1}.")]
        public virtual void GetRuleException(string identifier, string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(GetRuleExceptionEvent, identifier, exception);
            }
        }
        #endregion

        #region Link lifecycle
        [Event(LinkStateLostEvent, Level = EventLevel.Error, Message = "Link state lost. Throwing LockLostException for identifier: {0}, receiveLinkName: {1}, receiveLinkState: {2}, isSessionReceiver: {3}, exception: {4}.")]
        public virtual void LinkStateLost(string identifier, string receiveLinkName, string receiveLinkState, bool isSessionReceiver, string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(LinkStateLostEvent, identifier, receiveLinkName, receiveLinkState, isSessionReceiver, exception);
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

        [Event(CreateSendLinkExceptionEvent, Level = EventLevel.Error, Message = "An exception occurred while creating send link for Identifier: {0}. Error Message: '{1}'")]
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

        [Event(CreateReceiveLinkExceptionEvent, Level = EventLevel.Error, Message = "An exception occurred while creating receive link for Identifier: {0}. Error Message: '{1}'")]
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

        [Event(CreateManagementLinkExceptionEvent, Level = EventLevel.Error, Message = "An exception occurred while creating management link for Identifier: {0}. Error Message: '{1}'")]
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
            WriteEvent(TransactionDeclaredEvent, transactionId, amqpTransactionId);
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
            WriteEvent(TransactionDischargedEvent, transactionId, amqpTransactionId, rollback);
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

        #region plugins
        [Event(PluginStartEvent, Level = EventLevel.Verbose, Message = "User plugin {0} called on message {1}")]
        public void PluginCallStarted(string pluginName, string messageId)
        {
            if (IsEnabled())
            {
                WriteEvent(PluginStartEvent, pluginName, messageId);
            }
        }

        [Event(PluginCompleteEvent, Level = EventLevel.Verbose, Message = "User plugin {0} completed on message {1}")]
        public void PluginCallCompleted(string pluginName, string messageId)
        {
            if (IsEnabled())
            {
                WriteEvent(PluginCompleteEvent, pluginName, messageId);
            }
        }

        [Event(PluginExceptionEvent, Level = EventLevel.Error, Message = "Exception during {0} plugin execution. MessageId: {1}, Exception {2}")]
        public void PluginCallException(string pluginName, string messageId, string exception)
        {
            if (IsEnabled())
            {
                WriteEvent(PluginExceptionEvent, pluginName, messageId, exception);
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
        #endregion
    }
}
