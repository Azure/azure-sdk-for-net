// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.Tracing;
using Azure.Core.Diagnostics;

namespace Azure.Search.Documents
{
    [EventSource(Name = EventSourceName)]
    internal sealed class AzureSearchDocumentsEventSource : AzureEventSource
    {
        private const string EventSourceName = "Azure-Search-Documents";

        internal const int BatchActionCountUpdatedEvent = 1;
        internal const int BatchSubmittedEvent = 2;
        internal const int RetryQueueResizedEvent = 3;
        internal const int PendingQueueResizedEvent = 4;
        internal const int SearchIndexingBufferedSenderDisposedWithPendingActionsEvent = 5;
        internal const int DocumentsPublishedEvent = 6;
        internal const int ActionNotificationEventHandlerExceptionThrownEvent = 7;
        internal const int BatchActionPayloadTooLargeEvent = 8;

        private AzureSearchDocumentsEventSource() :
            base(EventSourceName)
        { }

        public static AzureSearchDocumentsEventSource Instance { get; } = new AzureSearchDocumentsEventSource();

        [Event(PendingQueueResizedEvent, Level = EventLevel.Verbose, Message = "{0}: pending queue size = {2} for {1}.")]
        public void PendingQueueResized(string senderType, string endPoint, int queueSize)
        {
            WriteEvent(PendingQueueResizedEvent, senderType, endPoint, queueSize);
        }

        [Event(RetryQueueResizedEvent, Level = EventLevel.Verbose, Message = "{0}: retry queue size = {2} for {1}.")]
        public void RetryQueueResized(string senderType, string endPoint, int queueSize)
        {
            WriteEvent(RetryQueueResizedEvent, senderType, endPoint, queueSize);
        }

        [Event(BatchSubmittedEvent, Level = EventLevel.Informational, Message = "{0}: submitted batch of size {2} for {1}.")]
        public void BatchSubmitted(string senderType, string endPoint, int batchSize)
        {
            WriteEvent(BatchSubmittedEvent, senderType, endPoint, batchSize);
        }

        [Event(BatchActionCountUpdatedEvent, Level = EventLevel.Warning, Message = "{0}: updated the starting batch action count from {2} to {3} for {1}.")]
        public void BatchActionCountUpdated(string senderType, string endPoint, int oldBatchCount, int newBatchCount)
        {
            WriteEvent(BatchActionCountUpdatedEvent, senderType, endPoint, oldBatchCount, newBatchCount);
        }

        [Event(SearchIndexingBufferedSenderDisposedWithPendingActionsEvent, Level = EventLevel.Error, Message = "{0}: {2} unsent indexing actions for {1}.")]
        public void SearchIndexingBufferedSenderDisposedWithPendingActions(string senderType, string endPoint, int indexingActionsCount)
        {
            WriteEvent(SearchIndexingBufferedSenderDisposedWithPendingActionsEvent, senderType, endPoint, indexingActionsCount);
        }

        [Event(DocumentsPublishedEvent, Level = EventLevel.Verbose, Message = "{0}: publishing documents for {1}. Flush = {2}")]
        public void PublishingDocuments(string senderType, string endPoint, bool flush)
        {
            WriteEvent(DocumentsPublishedEvent, senderType, endPoint, flush);
        }

        [Event(ActionNotificationEventHandlerExceptionThrownEvent, Level = EventLevel.Error, Message = "{0}: exception thrown for {1}. Action = {2}. Exception: {3}")]
        public void ActionNotificationEventHandlerExceptionThrown(string senderType, string endPoint, string action, string exceptionText)
        {
            WriteEvent(ActionNotificationEventHandlerExceptionThrownEvent, senderType, endPoint, action, exceptionText);
        }

        [Event(BatchActionPayloadTooLargeEvent, Level = EventLevel.Warning, Message = "{0}: batch action count {2} is too large for {1}.")]
        public void BatchActionPayloadTooLarge(string componentType, string endPoint, int batchActionCount)
        {
            WriteEvent(BatchActionPayloadTooLargeEvent, componentType, endPoint, batchActionCount);
        }

        [NonEvent]
        public void ActionNotificationEventHandlerExceptionThrown(string senderType, string endPoint, string action, Exception e)
        {
            ActionNotificationEventHandlerExceptionThrown(senderType, endPoint, action, e.ToString());
        }
    }
}
