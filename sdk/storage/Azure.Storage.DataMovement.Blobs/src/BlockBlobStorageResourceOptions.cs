﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Storage.DataMovement;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement.Blobs
{
    /// <summary>
    /// Optional parameters for
    /// <see cref="BlockBlobStorageResource"/>.
    /// </summary>
    public class BlockBlobStorageResourceOptions
    {
        /// <summary>
        /// When calling <see cref="BlockBlobStorageResource.CopyBlockFromUriAsync(StorageResource, HttpRange, bool, long, StorageResourceCopyFromUriOptions, System.Threading.CancellationToken)"/>.
        /// </summary>
        public BlockBlobStorageResourceServiceCopyOptions CopyOptions { get; set; }

        /// <summary>
        /// When calling <see cref="BlockBlobStorageResource.WriteFromStreamAsync(System.IO.Stream, long, bool, long, long, StorageResourceWriteToOffsetOptions, System.Threading.CancellationToken)"/>,
        /// and <see cref="BlockBlobStorageResource.CompleteTransferAsync(System.Threading.CancellationToken)"/>.
        /// These options will apply to the blob service requests to complete uploading to the block blob.
        /// </summary>
        public BlockBlobStorageResourceUploadOptions UploadOptions { get; set; }

        /// <summary>
        /// When calling for <see cref="BlockBlobStorageResource.ReadStreamAsync(long, long?, System.Threading.CancellationToken)"/>
        ///
        /// these options will apply to the blob service requests.
        /// </summary>
        public BlobStorageResourceDownloadOptions DownloadOptions { get; set; }
    }
}
