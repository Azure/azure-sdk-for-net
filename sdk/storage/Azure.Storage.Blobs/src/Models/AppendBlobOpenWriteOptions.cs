// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Optional parameters for Append Blob Open Write.
    /// </summary>
    public class AppendBlobOpenWriteOptions
    {
        /// <summary>
        /// The size of the buffer to use.  Default is 4 MB.
        /// Beginning with x-ms-version 2022-11-02, the max buffer size is 100 MB.
        /// For previous versions, the max buffer size is 4 MB.
        /// See <see cref="AppendBlobClient.AppendBlobMaxAppendBlockBytes"/>.
        /// </summary>
        public long? BufferSize { get; set; }

        /// <summary>
        /// Access conditions used to open the write stream.
        /// </summary>
        public AppendBlobRequestConditions OpenConditions { get; set; }

        /// <summary>
        /// Optional <see cref="IProgress{Long}"/> to provide
        /// progress updates about data transfers.
        /// </summary>
        public IProgress<long> ProgressHandler { get; set; }

        /// <summary>
        /// Optional override settings for this client's <see cref="BlobClientOptions.TransferValidation"/> settings.
        /// </summary>
        public UploadTransferValidationOptions TransferValidation { get; set; }
    }
}
