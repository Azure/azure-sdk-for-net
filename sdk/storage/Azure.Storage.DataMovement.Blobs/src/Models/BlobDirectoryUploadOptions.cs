// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using Azure.Storage.Blobs.Models;
using Metadata = System.Collections.Generic.IDictionary<string, string>;
using Tags = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.DataMovement.Blobs.Models
{
    /// <summary>
    /// Optional parameters for uploading to a Blob Virtual Directory.
    /// </summary>
    public class BlobDirectoryUploadOptions
    {
        /// <summary>
        /// Optional <see cref="AccessTier"/> to set on each blob uploaded.
        /// </summary>
        public AccessTier? AccessTier { get; set; }

        /// <summary>
        /// Optional <see cref="StorageTransferOptions"/> to configure
        /// parallel transfer behavior.
        /// </summary>
        public StorageTransferOptions TransferOptions { get; set; }

        /// <summary>
        /// Event Handler
        /// </summary>
        public BlobUploadDirectoryEventHandler EventHandler { get; set; }

        /// <summary>
        /// Progress Handler
        /// </summary>
        public IProgress<BlobUploadDirectoryProgress> ProgressHandler { get; set; }

        /// <summary>
        /// Optional <see cref="BlobImmutabilityPolicy"/> to set on the blob.
        /// Note that is parameter is only applicable to a blob within a container that
        /// has immutable storage with versioning enabled.
        /// </summary>
        public BlobImmutabilityPolicy ImmutabilityPolicy { get; set; }

        /// <summary>
        /// Optional.  Indicates if a legal hold should be placed on the blob.
        /// Note that is parameter is only applicable to a blob within a container that
        /// has immutable storage with versioning enabled.
        /// </summary>
        public bool? LegalHold { get; set; }

        /// <summary>
        /// Optional <see cref="UploadTransactionalHashingOptions"/> for using transactional
        /// hashing on uploads.
        /// </summary>
        public UploadTransactionalHashingOptions TransactionalHashingOptions { get; set; }
    }
}
