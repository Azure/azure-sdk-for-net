// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Optional parameters for DownloadContent().
    /// </summary>
    public class BlobDownloadContentOptions
    {
        /// <summary>
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
        /// downloading this blob.
        /// </summary>
        public BlobRequestConditions Conditions { get; set; }

        /// <summary>
        /// Optional <see cref="IProgress{Long}"/> to provide
        /// progress updates about data transfers.
        /// </summary>
        public IProgress<long> ProgressHandler { get; set; }

        /// <summary>
        /// Optional range of the blob to download.
        /// </summary>
        public HttpRange Range { get; set; }

        /// <summary>
        /// Geo-redundant (GRS) and Geo-zone-redundant (GZRS) storage accounts only.
        /// Allows client to override replication lock for read operations.
        /// </summary>
        public bool? IgnoreStrongConsistencyLock { get; set; }
    }
}
