// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs.Models;
using Metadata = System.Collections.Generic.IDictionary<string, string>;
using Tags = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.DataMovement.Blobs
{
    /// <summary>
    /// Optional parameters for all Blob Storage resource types.
    /// </summary>
    public class BlobStorageResourceOptions
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public BlobStorageResourceOptions()
        {
        }

        internal BlobStorageResourceOptions(BlobStorageResourceOptions other)
        {
            Metadata = other?.Metadata;
            Tags = other?.Tags;
            HttpHeaders = other?.HttpHeaders;
            AccessTier = other?.AccessTier;
        }

        /// <summary>
        /// Optional. Defines custom metadata to set on the destination blob.
        ///
        /// Applies to upload and copy transfers.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be readonly
        public Metadata Metadata { get; set; }
#pragma warning restore CA2227 // Collection properties should be readonly

        /// <summary>
        /// Optional. Defines tags to set on the destination blob.
        ///
        /// Applies to upload and copy transfers.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be readonly
        public Tags Tags { get; set; }
#pragma warning restore CA2227 // Collection properties should be readonly

        /// <summary>
        /// Optional. Standard HTTP header properties that can be set for the new blob.
        ///
        /// Applies to upload and copy transfers.
        /// </summary>
        public BlobHttpHeaders HttpHeaders { get; set; }

        /// <summary>
        /// Optional. See <see cref="Storage.Blobs.Models.AccessTier"/>.
        /// Indicates the access tier to be set on the destination blob.
        ///
        /// Applies to upload and copy transfers.
        /// </summary>
        public AccessTier? AccessTier { get; set; }
    }
}
