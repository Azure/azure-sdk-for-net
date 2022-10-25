// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Blobs.DataMovement
{
    /// <summary>
    /// Options for the <see cref="PageBlobStorageResource"/>
    /// </summary>
    public class PageBlobStorageResourceOptions
    {
        /// <summary>
        /// When calling <see cref="PageBlobStorageResource.CopyFromUriAsync(Uri)"/>
        /// </summary>
        public PageBlobStorageResourceServiceCopyOptions CopyOptions { get; set; }

        /// <summary>
        /// When calling <see cref="PageBlobStorageResource.WriteFromStreamAsync(System.IO.Stream, System.Threading.CancellationToken)"/>,
        /// <see cref="PageBlobStorageResource.WriteStreamToOffsetAsync(long, long, System.IO.Stream, Storage.DataMovement.Models.ConsumePartialReadableStreamOptions, System.Threading.CancellationToken)"/>,
        /// and <see cref="PageBlobStorageResource.CompleteTransferAsync(System.Threading.CancellationToken)"/>.
        /// These options will apply to the blob service requests to complete uploading to the block blob.
        /// </summary>
        public PageBlobStorageResourceUploadOptions UploadOptions { get; set; }

        /// <summary>
        /// When calling for <see cref="PageBlobStorageResource.WriteStreamToOffsetAsync(long, long, System.IO.Stream, Storage.DataMovement.Models.ConsumePartialReadableStreamOptions, System.Threading.CancellationToken)"/>
        ///
        /// these options will apply to the blob service requests.
        /// </summary>
        public BlobStorageResourceDownloadOptions DownloadOptions { get; set; }
    }
}
