// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Optional paratmers for downloading a blob.
    /// </summary>
    public class BlobBaseDownloadOptions
    {
        /// <summary>
        /// Optional byte range of the blob to be downloaded. If not provided,
        /// download the entire blob.
        /// </summary>
        public HttpRange Range { get; set; }

        /// <summary>
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
        /// downloading this blob.
        /// </summary>
        public BlobRequestConditions Conditions { get; set; }

        /// <summary>
        /// Optional settings for downloading with transactional hashing for
        /// the requested content.
        /// </summary>
        public DownloadTransactionalHashingOptions HashingOptions { get; set; }
    }
}
