// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Blobs.DataMovement
{
    /// <summary>
    /// Options for <see cref="AppendBlobStorageResource"/>
    /// </summary>
    public class AppendBlobStorageResourceOptions
    {
        /// <summary>
        /// When calling <see cref="AppendBlobStorageResource.CopyFromUriAsync(Uri)"/>
        /// </summary>
        public AppendBlobStorageResourceServiceCopyOptions CopyOptions { get; set; }

        /// <summary>
        /// When calling <see cref="AppendBlobStorageResource.WriteFromStreamAsync(System.IO.Stream, System.Threading.CancellationToken)"/>,
        /// <see cref="AppendBlobStorageResource.WriteStreamToOffsetAsync(long, long, System.IO.Stream, Storage.DataMovement.Models.ConsumePartialReadableStreamOptions, System.Threading.CancellationToken)"/>,
        /// and <see cref="AppendBlobStorageResource.CompleteTransferAsync(System.Threading.CancellationToken)"/>.
        /// These options will apply to the blob service requests to complete uploading to the block blob.
        /// </summary>
        public AppendBlobStorageResourceUploadOptions UploadOptions { get; set; }

        /// <summary>
        /// When calling for <see cref="AppendBlobStorageResource.WriteStreamToOffsetAsync(long, long, System.IO.Stream, Storage.DataMovement.Models.ConsumePartialReadableStreamOptions, System.Threading.CancellationToken)"/>
        ///
        /// these options will apply to the blob service requests.
        /// </summary>
        public BlobStorageResourceDownloadOptions DownloadOptions { get; set; }
    }
}
