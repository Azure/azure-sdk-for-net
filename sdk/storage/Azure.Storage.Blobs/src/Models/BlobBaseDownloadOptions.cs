// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Models;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Optional paratmers for downloading some range of a blob.
    /// </summary>
    public class BlobBaseDownloadOptions
    {
        /// <summary>
        /// If provided, only download the bytes of the blob in the specified
        /// range.  If not provided, download the entire blob.
        /// </summary>
        public HttpRange Range { get; set; }

        /// <summary>
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
        /// downloading this blob.
        /// </summary>
        public BlobRequestConditions Conditions { get; set; }

        /// <summary>
        /// Optional transactional hashing options.
        /// </summary>
        public DownloadTransactionalHashingOptions TransactionalHashingOptions { get; set; }

        /// <summary>
        /// Operation name for internal diagnostic scope use.
        /// </summary>
        internal string OperationName { get; set; }
    }
}
