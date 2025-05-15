// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.Tracing;
using Azure.Core.Diagnostics;

namespace Azure.Storage.DataMovement
{
    internal class DataMovementEventSource : AzureEventSource
    {
        private const string EventSourceName = "Azure-Storage-DataMovement";

        private const int TransferQueuedEvent = 1;
        private const int TransferCompletedEvent = 2;
        private const int JobPartStatusEvent = 3;
        private const int EnumerationCompleteEvent = 4;
        private const int ResumeTransferEvent = 5;
        private const int ResumeEnumerationCompleteEvent = 6;

        private DataMovementEventSource() : base(EventSourceName) { }

        public static DataMovementEventSource Singleton { get; } = new DataMovementEventSource();

        [Event(TransferQueuedEvent, Level = EventLevel.Informational, Message = "Transfer [{0}] Transfer queued: {1} -> {2}")]
        public void TransferQueued(string transferId, string source, string destination)
        {
            WriteEvent(TransferQueuedEvent, transferId, source, destination);
        }

        [NonEvent]
        public void TransferQueued(string transferId, StorageResource source, StorageResource destination)
        {
            if (IsEnabled(EventLevel.Informational, EventKeywords.None))
            {
                TransferQueued(transferId, source.Uri.AbsoluteUri, destination.Uri.AbsoluteUri);
            }
        }

        [Event(TransferCompletedEvent, Level = EventLevel.Informational, Message = "Transfer [{0}] Transfer completed: HasFailed={1}, HasKsipped={2}")]
        public void TransferCompleted(string transferId, bool hasFailed, bool hasSkipped)
        {
            WriteEvent(TransferCompletedEvent, transferId, hasFailed, hasSkipped);
        }

        [NonEvent]
        public void TransferCompleted(string transferId, TransferStatus status)
        {
            if (IsEnabled(EventLevel.Informational, EventKeywords.None))
            {
                TransferCompleted(transferId, status.HasFailedItems, status.HasSkippedItems);
            }
        }

        [Event(JobPartStatusEvent, Level = EventLevel.Verbose, Message = "Transfer [{0}:{1}] Status={2}, Failed={3}, Skipped={4}")]
        public void JobPartStatus(string transferId, int jobPart, string jobPartStatus, bool failed, bool skipped)
        {
            WriteEvent(JobPartStatusEvent, transferId, jobPart, jobPartStatus, failed, skipped);
        }

        [NonEvent]
        public void JobPartStatus(string transferId, int jobPart, TransferStatus status)
        {
            if (IsEnabled(EventLevel.Verbose, EventKeywords.None))
            {
                JobPartStatus(transferId, jobPart, status.State.ToString(), status.HasFailedItems, status.HasSkippedItems);
            }
        }

        [Event(EnumerationCompleteEvent, Level = EventLevel.Informational, Message = "Transfer [{0}] Enumeration complete: JobPartCount={1}")]
        public void EnumerationComplete(string transferId, int jobPartCount)
        {
            WriteEvent(EnumerationCompleteEvent, transferId, jobPartCount);
        }

        [Event(ResumeTransferEvent, Level = EventLevel.Informational, Message = "Resume transfer [{0}] Transfer queued: {1} -> {2}")]
        public void ResumeTransfer(string transferId, string source, string destination)
        {
            WriteEvent(ResumeTransferEvent, transferId, source, destination);
        }

        [NonEvent]
        public void ResumeTransfer(string transferId, StorageResource source, StorageResource destination)
        {
            if (IsEnabled(EventLevel.Informational, EventKeywords.None))
            {
                ResumeTransfer(transferId, source.Uri.AbsoluteUri, destination.Uri.AbsoluteUri);
            }
        }

        [Event(ResumeEnumerationCompleteEvent, Level = EventLevel.Informational, Message = "Resume transfer [{0}] Resumed saved job parts: JobPartCount={1}")]
        public void ResumeEnumerationComplete(string transferId, int jobPartCount)
        {
            WriteEvent(ResumeEnumerationCompleteEvent, transferId, jobPartCount);
        }
    }
}
