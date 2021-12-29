// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Storage.Blobs.Specialized;
using Metadata = System.Collections.Generic.IDictionary<string, string>;
using Tags = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.DataMovement.Blobs.Models
{
    /// <summary>
    /// Optional parameters for Start Copy from URL.
    ///
    /// TODO: Reassess which options can be applied from the original BlobCopyFromUriOptions
    /// </summary>
    public class BlobDirectoryCopyFromUriOptions
    {
        /// <summary>
        /// Optional custom metadata to set for this append blob.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be readonly
        public Metadata Metadata { get; set; }
#pragma warning restore CA2227 // Collection properties should be readonly

        /// <summary>
        /// Options tags to set for this append blob.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be readonly
        public Tags Tags { get; set; }
#pragma warning restore CA2227 // Collection properties should be readonly

        /// <summary>
        /// Optional <see cref="BlobDirectoryRequestConditions"/> to add
        /// conditions on the copying of data from this source blob.
        /// </summary>
        public BlobDirectoryRequestConditions SourceConditions { get; set; }

        /// <summary>
        /// Optional <see cref="BlobDirectoryRequestConditions"/> to add conditions on
        /// the copying of data to this blob.
        /// </summary>
        public BlobDirectoryRequestConditions DestinationConditions { get; set; }

        /// <summary>
        /// If the destination blob should be sealed.
        /// Only applicable for Append Blobs.
        ///
        /// This parameter is not valid for synchronous copies.
        /// </summary>
        public bool? ShouldSealDestination { get; set; }

        /// <summary>
        /// Optional.  Indicates if a legal hold should be placed on the blob.
        /// Note that is parameter is only applicable to a blob within a container that
        /// has immutable storage with versioning enabled.
        /// </summary>
        public bool? LegalHold { get; set; }
    }
}
