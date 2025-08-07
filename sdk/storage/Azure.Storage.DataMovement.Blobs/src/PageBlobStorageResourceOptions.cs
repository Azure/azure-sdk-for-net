// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs.Models;

namespace Azure.Storage.DataMovement.Blobs
{
    /// <summary>
    /// Optional parameters specific to Page Blobs using
    /// <see cref="PageBlobStorageResource"/>.
    /// </summary>
    public class PageBlobStorageResourceOptions : BlobStorageResourceOptions
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public PageBlobStorageResourceOptions()
        {
        }

        internal PageBlobStorageResourceOptions(BlobStorageResourceOptions other) : base(other)
        {
        }

        internal PageBlobStorageResourceOptions(BlobDestinationCheckpointDetails checkpointDetails) : base(checkpointDetails)
        {
        }

        /// <summary>
        /// Optional. User-controlled value that you can use to track requests.
        /// The value of the SequenceNumber must be between
        /// 0 and 2^63 - 1.  The default value is 0.
        ///
        /// Applies to copy and upload transfers.
        /// </summary>
        public long? SequenceNumber { get; set; }

        /// <summary>
        /// Optional. See <see cref="BlobRequestConditions"/>.
        /// Access conditions on the copying of data from this source storage resource blob.
        ///
        /// Applies to copy and download transfers.
        /// </summary>
        public PageBlobRequestConditions SourceConditions { get; set; }

        /// <summary>
        /// Optional <see cref="BlobRequestConditions"/>.
        /// Access conditions on the copying of data to this blob.
        ///
        /// Applies to copy and upload transfers.
        /// </summary>
        public PageBlobRequestConditions DestinationConditions { get; set; }
    }
}
