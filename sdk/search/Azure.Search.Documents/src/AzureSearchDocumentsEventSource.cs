// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.Tracing;
using System.Globalization;
using System.Text;
using Azure.Core.Diagnostics;

namespace Azure.Search.Documents
{
    [EventSource(Name = EventSourceName)]
    internal sealed class AzureSearchDocumentsEventSource : EventSource
    {
        private const string EventSourceName = "Azure-Search-Documents";

        internal const int BatchActionCountUpdatedEvent = 1;
        internal const int BatchSubmittedEvent = 2;
        internal const int RetryQueueResizedEvent = 3;
        internal const int PendingQueueResizedEvent = 4;
        internal const int PublisherDisposedWithPendingActionsEvent = 5;
        internal const int DocumentsPublishedEvent = 6;
        internal const int ActionNotificationEventHandlerExceptionThrownEvent = 7;

        private AzureSearchDocumentsEventSource() :
            base(EventSourceName, EventSourceSettings.Default, AzureEventSourceListener.TraitName, AzureEventSourceListener.TraitValue)
        { }

        public static AzureSearchDocumentsEventSource Instance { get; } = new AzureSearchDocumentsEventSource();

        [Event(PendingQueueResizedEvent, Level = EventLevel.Verbose, Message = "{0}: pending queue size = {1}.")]
        public void PendingQueueResized(string publisherType, int queueSize)
        {
            WriteEvent(PendingQueueResizedEvent, publisherType, queueSize);
        }

        [Event(RetryQueueResizedEvent, Level = EventLevel.Verbose, Message = "{0}: retry queue size = {1}.")]
        public void RetryQueueResized(string publisherType, int queueSize)
        {
            WriteEvent(RetryQueueResizedEvent, publisherType, queueSize);
        }

        [Event(BatchSubmittedEvent, Level = EventLevel.Informational, Message = "{0} at {1} has submitted batch of size {2}.")]
        public void BatchSubmitted(string publisherType, string endPoint, int batchSize)
        {
            WriteEvent(BatchSubmittedEvent, publisherType, endPoint, batchSize);
        }

        [Event(BatchActionCountUpdatedEvent, Level = EventLevel.Warning, Message = "{0} at {1} has updated the starting batch action count from {2} to {3}.")]
        public void BatchActionCountUpdated(string publisherType, string endPoint, int oldBatchCount, int newBatchCount)
        {
            WriteEvent(BatchActionCountUpdatedEvent, publisherType, endPoint, oldBatchCount, newBatchCount);
        }

        [Event(PublisherDisposedWithPendingActionsEvent, Level = EventLevel.Error, Message = "{0}: {1} unsent indexing actions at {2}.")]
        public void PublisherDisposedWithPendingActions(string componentType, string endPoint, int indexingActionsCount)
        {
            WriteEvent(PublisherDisposedWithPendingActionsEvent, componentType, indexingActionsCount, endPoint);
        }

        [Event(DocumentsPublishedEvent, Level = EventLevel.Verbose, Message = "{0}: publishing documents. Flush = {2}")]
        public void PublishingDocuments(string publisherType, bool flush)
        {
            WriteEvent(DocumentsPublishedEvent, publisherType, flush);
        }

        [Event(ActionNotificationEventHandlerExceptionThrownEvent, Level = EventLevel.Error, Message = "{0}: exception thrown at {1}. Action = {2}. Exception: {3}")]
        public void ActionNotificationEventHandlerExceptionThrown(string componentType, string endPoint, string action, string e)
        {
            WriteEvent(ActionNotificationEventHandlerExceptionThrownEvent, componentType, endPoint, action, e);
        }

        [NonEvent]
        public void ActionNotificationEventHandlerExceptionThrown(string componentType, string endPoint, string action, Exception e)
        {
            if (IsEnabled(EventLevel.Error, EventKeywords.All))
            {
                ActionNotificationEventHandlerExceptionThrown(componentType, endPoint, action, FormatException(e));
            }
        }

        [NonEvent]
        private static string FormatException(Exception ex)
        {
            StringBuilder sb = new();
            bool nest = false;

            do
            {
                if (nest)
                {
                    // Format how Exception.ToString() would.
                    sb.AppendLine()
                      .Append(" ---> ");
                }

                sb.Append(ex.GetType().FullName)
                  .Append(" (0x")
                  .Append(ex.HResult.ToString("x", CultureInfo.InvariantCulture))
                  .Append("): ")
                  .Append(ex.Message);

                ex = ex.InnerException;
                nest = true;
            }
            while (ex != null);

            return sb.ToString();
        }
    }
}
