// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.DataMovement.Blobs.Models
{
    /// <summary>
    /// Blob Sync Copy Options.
    ///
    /// Allow users to set the options for a sync copy. A sync
    /// copy performs a download of the blob to a temporary local
    /// space and then uploads that blob. This is an alternative
    /// to the regular.
    /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/copy-blob">Copy Blob</see>,
    /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/copy-blob-from-url">Put Blob From Url</see>,
    /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/put-block-from-url">Put Block From Url</see> and
    /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/put-block-list">Put Block List</see>.
    /// </summary>
    public class BlobSyncCopyOptions
    {
        /// <summary>
        /// Optional Blob Upload Options to set.
        /// </summary>
        public BlobUploadOptions BlobUploadOptions { get; set; }

        /// <summary>
        /// Optional sets Transfer Options for the download
        ///
        /// TODO: is this necessary or should we follow the transfer options set in
        /// the BlobUploadOptions?
        /// </summary>
        public StorageTransferOptions DownloadTransferOptions { get; set; }

        /// <summary>
        /// Optional Buffer Size for the download.
        ///
        /// TODO: default will probably 4MB, not sure if that's big enough or small enough
        /// </summary>
        public long? MaximumBufferSize { get; set; }
    }
}
