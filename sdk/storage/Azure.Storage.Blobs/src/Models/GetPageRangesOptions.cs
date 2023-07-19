// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Optional parameters for PageBlobClient.GetPageRanges().
    /// </summary>
    public class GetPageRangesOptions
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
        /// Optional <see cref="PageBlobRequestConditions"/> to add
        /// conditions on getting page ranges for the this blob.
        /// </summary>
        public PageBlobRequestConditions Conditions { get; set; }
    }
}
