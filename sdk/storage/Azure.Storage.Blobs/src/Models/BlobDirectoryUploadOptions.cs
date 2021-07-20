// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Metadata = System.Collections.Generic.IDictionary<string, string>;
using Tags = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Optional parameters for uploading to a Blob directory.
    /// </summary>
    public class BlobDirectoryUploadOptions
    {
        /// <summary>
        /// Optional Blob Type to Upload. Defaults to upload Block Blobs.
        /// </summary>
        /// TODO: uncomment or replace when uploading page and append blobs
        /// public BlobType blobType { get; set; }

        /// <summary>
        /// Optional standard HTTP header properties that can be set for the
        /// each blob that is uploaded.
        ///
        /// TODO: remove and replace with onl ythe headers that can apply
        /// to all blows iwthin the directory
        /// </summary>
        public BlobHttpHeaders HttpHeaders { get; set; }

        /// <summary>
        /// Optional custom metadata to set for each blob uploaded.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be readonly
        public Metadata Metadata { get; set; }
#pragma warning restore CA2227 // Collection properties should be readonly

        /// <summary>
        /// Options tags to set for each blob uploaded.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be readonly
        public Tags Tags { get; set; }
#pragma warning restore CA2227 // Collection properties should be readonly

        /// <summary>
        /// Optional <see cref="IProgress{Long}"/> to provide
        /// progress updates about data transfers.
        /// TODO: replace long value with appropriate model similar to BlobUploadDirectoryResponse
        /// </summary>
        public IProgress<long> ProgressHandler { get; set; }

        /// <summary>
        /// Optional <see cref="AccessTier"/> to set on each blob uploaded.
        /// </summary>
        public AccessTier? AccessTier { get; set; }

        /// <summary>
        /// Optional <see cref="StorageTransferOptions"/> to configure
        /// parallel transfer behavior.
        /// </summary>
        public StorageTransferOptions TransferOptions { get; set; }
    }
}
