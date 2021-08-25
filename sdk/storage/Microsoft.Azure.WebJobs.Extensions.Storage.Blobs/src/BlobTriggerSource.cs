// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebJobs
{
    /// <summary>
    /// Provides blob trigger kinds to detect changes.
    /// </summary>
    public enum BlobTriggerSource
    {
        /// <summary>
        /// Polling works as a hybrid between inspecting logs and running periodic container scans. Blobs are scanned in groups of 10,000 at a time with a continuation token used between intervals.
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/storage-analytics-log-format">Storage Analytics logs</see>
        /// </summary>
        LogsAndContainerScan,
        /// <summary>
        /// Polling is relied on EventGrid.
        /// <see href="https://docs.microsoft.com/en-us/azure/event-grid/event-schema-blob-storage">Azure Blob Storage as an Event Grid source</see>
        /// </summary>
        EventGrid
    }
}
