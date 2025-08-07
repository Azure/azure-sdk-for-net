// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Optional parameters for PageRangeClient.GetPageRangesDiff().
    /// </summary>
    public class GetPageRangesDiffOptions
    {
        /// <summary>
        /// Optionally specifies the range of bytes over which to list ranges,
        /// inclusively. If omitted, then all ranges for the blob are returned.
        /// </summary>
        public HttpRange? Range { get; set; }

        /// <summary>
        /// Optionally specifies the blob snapshot to retrieve page ranges
        /// information from. For more information on working with blob snapshots,
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/creating-a-snapshot-of-a-blob">
        /// Create a snapshot of a blob</see>.
        /// </summary>
        public string Snapshot { get; set; }

        /// <summary>
        /// Specifies that the response will contain only pages that were
        /// changed between target blob and previous snapshot.  Changed pages
        /// include both updated and cleared pages. The target blob may be a
        /// snapshot, as long as the snapshot specified by
        /// <see cref="PreviousSnapshot"/> is the older of the two.
        /// For more information on working with blob snapshots,
        /// <see href="https://docs.microsoft.com/rest/api/storageservices/creating-a-snapshot-of-a-blob">
        /// Create a snapshot of a blob</see>.
        /// </summary>
        public string PreviousSnapshot { get; set; }

        /// <summary>
        /// Optional <see cref="PageBlobRequestConditions"/> to add
        /// conditions on getting page ranges for the this blob.
        /// </summary>
        public PageBlobRequestConditions Conditions { get; set; }
    }
}
