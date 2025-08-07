// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs.Models;

namespace Azure.Storage.DataMovement.Blobs
{
    /// <summary>
    /// Options parameters when using a <see cref="BlobStorageResourceContainer"/>.
    /// </summary>
    public class BlobStorageResourceContainerOptions
    {
        private BlobType? _blobType = default;
        internal bool _isBlobTypeSet = false;

        /// <summary>
        /// Optional. The <see cref="Storage.Blobs.Models.BlobType"/> that will be used when uploading blobs to the destination.
        ///
        /// Defaults to preserving the blob type if the source is also a blob. If the source is not a blob, will default to Block Blob. If explicitly set to null, the source blob type will not be preserved, and be transferred as a Block Blob.
        /// </summary>
        public BlobType? BlobType
        {
            get => _blobType;
            set
            {
                _blobType = value;
                _isBlobTypeSet = true;
            }
        }

        /// <summary>
        /// Optional. The directory prefix within the Blob Storage Container to use in the transfer.
        /// </summary>
        public string BlobPrefix { get; set; }

        /// <summary>
        /// Optional. Additional options applied to each resource in the container.
        /// </summary>
        public BlobStorageResourceOptions BlobOptions { get; set; }
    }
}
