// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Storage.Blobs.Models;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.Blobs.DataMovement
{
    /// <summary>
    /// Options bag for <see cref="BlobDirectoryStorageResourceContainer"/>
    /// </summary>
    public class BlobDirectoryStorageResourceContainerOptions
    {
        /// <summary>
        /// Optional. The <see cref="BlobTraits"/> for when calling the
        /// <see cref="BlobDirectoryStorageResourceContainer.GetStorageResources(System.Threading.CancellationToken)"/>.
        /// </summary>
        public BlobTraits Traits { get; set; }

        /// <summary>
        /// Optional. The <see cref="BlobStates"/> for when calling the
        /// <see cref="BlobDirectoryStorageResourceContainer.GetStorageResources(System.Threading.CancellationToken)"/>.
        /// </summary>
        public BlobStates States { get; set; }

        /// <summary>
        /// When calling <see cref="BlockBlobStorageResource.CopyBlockFromUriAsync(System.Uri, HttpRange, StorageResourceCopyFromUriOptions, System.Threading.CancellationToken)"/>
        /// </summary>
        public BlockBlobStorageResourceServiceCopyOptions CopyOptions { get; set; }

        /// <summary>
        /// When calling <see cref="BlockBlobStorageResource.WriteFromStreamAsync(System.IO.Stream, System.Threading.CancellationToken)"/>,
        /// <see cref="BlockBlobStorageResource.WriteStreamToOffsetAsync(long, long, System.IO.Stream, Storage.DataMovement.Models.StorageResourceWriteToOffsetOptions, System.Threading.CancellationToken)"/>,
        /// and <see cref="BlockBlobStorageResource.CompleteTransferAsync(System.Threading.CancellationToken)"/>.
        /// These options will apply to the blob service requests to complete uploading to the block blob.
        /// </summary>
        public BlockBlobStorageResourceUploadOptions UploadOptions { get; set; }

        /// <summary>
        /// When calling for <see cref="BlockBlobStorageResource.WriteStreamToOffsetAsync(long, long, System.IO.Stream, Storage.DataMovement.Models.StorageResourceWriteToOffsetOptions, System.Threading.CancellationToken)"/>
        ///
        /// these options will apply to the blob service requests.
        /// </summary>
        public BlobStorageResourceDownloadOptions DownloadOptions { get; set; }
    }
}
