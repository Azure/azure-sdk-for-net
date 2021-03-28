// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.Tracing;
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

        private AzureSearchDocumentsEventSource() :
            base(EventSourceName, EventSourceSettings.Default, AzureEventSourceListener.TraitName, AzureEventSourceListener.TraitValue)
        { }

        public static AzureSearchDocumentsEventSource Instance { get; } = new AzureSearchDocumentsEventSource();

        [Event(PendingQueueResizedEvent, Level = EventLevel.Verbose, Message = "Indexing publisher pending queue size = {0}.")]
        public void PendingQueueResized(int queueSize)
        {
            if (IsEnabled(EventLevel.Verbose, EventKeywords.All))
            {
                WriteEvent(PendingQueueResizedEvent, queueSize);
            }
        }

        [Event(RetryQueueResizedEvent, Level = EventLevel.Verbose, Message = "Indexing publisher retry queue size = {0}.")]
        public void RetryQueueResized(int queueSize)
        {
            if (IsEnabled(EventLevel.Verbose, EventKeywords.All))
            {
                WriteEvent(RetryQueueResizedEvent, queueSize);
            }
        }

        [Event(BatchSubmittedEvent, Level = EventLevel.Informational, Message = "Indexing publisher has submitted batch of size {0}.")]
        public void BatchSubmitted(int batchSize)
        {
            if (IsEnabled(EventLevel.Informational, EventKeywords.All))
            {
                WriteEvent(BatchSubmittedEvent, batchSize);
            }
        }

        [Event(BatchActionCountUpdatedEvent, Level = EventLevel.Informational, Message = "Indexing publisher has updated the starting batch action count from {0} to {1}.")]
        public void BatchActionCountUpdated(int oldBatchCount, int newBatchCount)
        {
            if (IsEnabled(EventLevel.Informational, EventKeywords.All))
            {
                WriteEvent(BatchActionCountUpdatedEvent, oldBatchCount, newBatchCount);
            }
        }
    }
}
