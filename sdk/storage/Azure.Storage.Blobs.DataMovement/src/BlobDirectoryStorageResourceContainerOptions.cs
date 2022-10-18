// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Blobs.DataMovement
{
    /// <summary>
    /// Options bag for <see cref="BlobDirectoryStorageResourceContainer"/>
    /// </summary>
    public class BlobDirectoryStorageResourceContainerOptions
    {
        /// <summary>
        /// Optional. The <see cref="BlobTraits"/> for when calling the
        /// <see cref="BlobDirectoryStorageResourceContainer.ListStorageResources(System.Threading.CancellationToken)"/>.
        /// </summary>
        public BlobTraits Traits { get; internal set; }

        /// <summary>
        /// Optional. The <see cref="BlobStates"/> for when calling the
        /// <see cref="BlobDirectoryStorageResourceContainer.ListStorageResources(System.Threading.CancellationToken)"/>.
        /// </summary>
        public BlobStates States { get; internal set; }
    }
}
