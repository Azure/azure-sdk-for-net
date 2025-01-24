// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs.Models;

namespace Azure.Storage.DataMovement.Blobs
{
    /// <summary>
    /// Optional parameters specific to Block Blobs using
    /// <see cref="BlockBlobStorageResource"/>.
    /// </summary>
    public class BlockBlobStorageResourceOptions : BlobStorageResourceOptions
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public BlockBlobStorageResourceOptions()
        {
        }

        internal BlockBlobStorageResourceOptions(BlobStorageResourceOptions other) : base(other)
        {
        }

        internal BlockBlobStorageResourceOptions(BlobDestinationCheckpointDetails checkpointDetails) : base(checkpointDetails)
        {
        }

        /// <summary>
        /// Optional. See <see cref="BlobRequestConditions"/>.
        /// Access conditions on the copying of data from this source storage resource blob.
        ///
        /// Applies to copy and download transfers.
        /// </summary>
        public BlobRequestConditions SourceConditions { get; set; }

        /// <summary>
        /// Optional <see cref="BlobRequestConditions"/>.
        /// Access conditions on the copying of data to this blob.
        ///
        /// Applies to copy and upload transfers.
        /// </summary>
        public BlobRequestConditions DestinationConditions { get; set; }
    }
}
