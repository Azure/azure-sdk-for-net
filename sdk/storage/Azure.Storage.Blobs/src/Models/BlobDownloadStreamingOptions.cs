// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Optional parameters for DownloadStreaming().
    /// </summary>
    public class BlobDownloadStreamingOptions
    {
        /// <summary>
        /// Optional range of the blob to download.
        /// </summary>
        public HttpRange Range { get; set; }

        /// <summary>
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
        /// downloading this blob.
        /// </summary>
        public BlobRequestConditions Conditions { get; set; }

        /// <summary>
        /// When set to true and specified together with the <see cref="Range"/>
        /// the service returns the MD5 hash for the range, as long as the
        /// range is less than or equal to 4 MB in size.  If this value is
        /// specified without <see cref="Range"/> or set to true when the
        /// range exceeds 4 MB in size, a <see cref="RequestFailedException"/>
        /// is thrown.
        /// </summary>
        public bool RangeGetContentHash { get; set; }

        /// <summary>
        /// Optional <see cref="IProgress{Long}"/> to provide
        /// progress updates about data transfers.
        /// </summary>
        public IProgress<long> ProgressHandler { get; set; }

        /// <summary>
        /// Geo-redundant (GRS) and Geo-zone-redundant (GZRS) storage accounts only.
        /// Allows client to override replication lock for read operations.
        /// </summary>
        public bool? IgnoreStrongConsistencyLock { get; set; }
    }
}
