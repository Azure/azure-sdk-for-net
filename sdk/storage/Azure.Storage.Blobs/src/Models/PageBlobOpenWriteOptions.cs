// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Optional parameters for Page Blob Open Write.
    /// </summary>
    public class PageBlobOpenWriteOptions
    {
        /// <summary>
        /// The size of the buffer to use.  Default is 4 MB,
        /// max is 4 MB.  Must be a increment of 512.  See <see cref="PageBlobClient.PageBlobMaxUploadPagesBytes"/>.
        /// </summary>
        public long? BufferSize { get; set; }

        /// <summary>
        /// Access conditions used to open the write stream.
        /// </summary>
        public PageBlobRequestConditions OpenConditions { get; set; }

        /// <summary>
        /// Optional <see cref="IProgress{Long}"/> to provide
        /// progress updates about data transfers.
        /// </summary>
        public IProgress<long> ProgressHandler { get; set; }

        /// <summary>
        /// Required if overwrite is set to true, or the underlying
        /// Page Blob is being created for the first time.
        /// Specifies the size of the new Page Blob.
        /// </summary>
        public long? Size { get; set; }

        /// <summary>
        /// Optional override settings for this client's <see cref="BlobClientOptions.TransferValidation"/> settings.
        /// </summary>
        public UploadTransferValidationOptions TransferValidation { get; set; }
    }
}
