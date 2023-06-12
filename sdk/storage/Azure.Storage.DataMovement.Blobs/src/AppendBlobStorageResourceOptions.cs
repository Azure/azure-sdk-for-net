// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs.Models;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement.Blobs
{
    /// <summary>
    /// Optional parameters specific to Append Blobs using
    /// <see cref="AppendBlobStorageResource"/>.
    /// </summary>
    public class AppendBlobStorageResourceOptions : BlobStorageResourceOptions
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public AppendBlobStorageResourceOptions()
        {
        }

        internal AppendBlobStorageResourceOptions(BlobStorageResourceOptions other) : base(other)
        {
        }

        /// <summary>
        /// Optional. See <see cref="BlobRequestConditions"/>.
        /// Access conditions on the copying of data from this source storage resource blob.
        ///
        /// Applies to copy and download transfers.
        /// </summary>
        public AppendBlobRequestConditions SourceConditions { get; set; }

        /// <summary>
        /// Optional <see cref="BlobRequestConditions"/>.
        /// Access conditions on the copying of data to this blob.
        ///
        /// Applies to copy and upload transfers.
        /// </summary>
        public AppendBlobRequestConditions DestinationConditions { get; set; }

        /// <summary>
        /// Optional. If the destination blob should be sealed.
        ///
        /// Applies to copy transfers when <see cref="BlobStorageResourceOptions.CopyMethod"/> is set to <see cref="TransferCopyMethod.AsyncCopy"/>.
        /// </summary>
        public bool? ShouldSealDestination { get; set; }
    }
}
