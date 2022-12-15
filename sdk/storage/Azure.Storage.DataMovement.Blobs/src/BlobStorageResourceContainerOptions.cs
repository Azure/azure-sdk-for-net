// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Storage.DataMovement;
using Azure.Storage.Blobs.Models;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement.Blobs
{
    /// <summary>
    /// Options bag for <see cref="BlobDirectoryStorageResourceContainer"/> and
    /// <see cref="BlobStorageResourceContainer"/>.
    /// </summary>
    public class BlobStorageResourceContainerOptions
    {
        /// <summary>
        /// Optional. The <see cref="BlobTraits"/> for when calling the
        /// <see cref="BlobDirectoryStorageResourceContainer.GetStorageResourcesAsync(System.Threading.CancellationToken)"/>.
        /// </summary>
        public BlobTraits Traits { get; set; }

        /// <summary>
        /// Optional. The <see cref="BlobStates"/> for when calling the
        /// <see cref="BlobDirectoryStorageResourceContainer.GetStorageResourcesAsync(System.Threading.CancellationToken)"/>.
        /// </summary>
        public BlobStates States { get; set; }

        /// <summary>
        /// Optional. Defines the copy operation to take.
        /// See <see cref="TransferCopyMethod"/>. Defaults to <see cref="TransferCopyMethod.SyncCopy"/>.
        ///
        /// Only applies when calling <see cref="BlockBlobStorageResource.CopyBlockFromUriAsync(StorageResource, HttpRange, bool, long, StorageResourceCopyFromUriOptions, System.Threading.CancellationToken)"/>.
        /// </summary>
        public TransferCopyMethod CopyMethod { get; set; }
    }
}
