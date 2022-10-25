// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Blobs.DataMovement
{
    /// <summary>
    /// Options for the <see cref="BlockBlobStorageResource"/>
    /// </summary>
    public class BlockBlobStorageResourceOptions
    {
        /// <summary>
        /// When calling <see cref="BlockBlobStorageResource.CopyFromUriAsync(Uri)"/>
        /// </summary>
        public BlockBlobStorageResourceServiceCopyOptions CopyOptions { get; set; }

        /// <summary>
        /// When calling <see cref="BlockBlobStorageResource.WriteFromStreamAsync(System.IO.Stream, System.Threading.CancellationToken)"/>,
        /// <see cref="BlockBlobStorageResource.WriteStreamToOffsetAsync(long, long, System.IO.Stream, Storage.DataMovement.Models.ConsumePartialReadableStreamOptions, System.Threading.CancellationToken)"/>,
        /// and <see cref="BlockBlobStorageResource.CompleteTransferAsync(System.Threading.CancellationToken)"/>.
        /// These options will apply to the blob service requests to complete uploading to the block blob.
        /// </summary>
        public BlockBlobStorageResourceUploadOptions UploadOptions { get; set; }

        /// <summary>
        /// When calling for <see cref="BlockBlobStorageResource.WriteStreamToOffsetAsync(long, long, System.IO.Stream, Storage.DataMovement.Models.ConsumePartialReadableStreamOptions, System.Threading.CancellationToken)"/>
        ///
        /// these options will apply to the blob service requests.
        /// </summary>
        public BlobStorageResourceDownloadOptions DownloadOptions { get; set; }
    }
}
