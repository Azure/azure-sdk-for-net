// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Metadata = System.Collections.Generic.IDictionary<string, string>;
using Tags = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Optional parameters for uploading to a Blob.
    /// </summary>
    public class BlobUploadOptions
    {
        /// <summary>
        /// Optional standard HTTP header properties that can be set for the
        /// new append blob.
        /// </summary>
        public BlobHttpHeaders HttpHeaders { get; set; }

        /// <summary>
        /// Optional custom metadata to set for this append blob.
        /// For a sample code to set the metadata, see <see href="https://github.com/Azure/azure-sdk-for-net/blob/47ea075bca473fe6e9928ff9893fbaa8a552f3a5/sdk/storage/Azure.Storage.Blobs/samples/Sample03_Migrations.cs#L630">this </see>article.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be readonly
        public Metadata Metadata { get; set; }
#pragma warning restore CA2227 // Collection properties should be readonly

        /// <summary>
        /// Options tags to set for this block blob.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be readonly
        public Tags Tags { get; set; }
#pragma warning restore CA2227 // Collection properties should be readonly

        /// <summary>
        /// Optional <see cref="BlobRequestConditions"/> to add
        /// conditions on the upload of this Block Blob.
        /// </summary>
        public BlobRequestConditions Conditions { get; set; }

        /// <summary>
        /// Optional <see cref="IProgress{Long}"/> to provide
        /// progress updates about data transfers.
        /// </summary>
        public IProgress<long> ProgressHandler { get; set; }

        /// <summary>
        /// Optional <see cref="AccessTier"/> to set on the
        /// Block Blob.
        /// </summary>
        public AccessTier? AccessTier { get; set; }

        /// <summary>
        /// Optional <see cref="StorageTransferOptions"/> to configure
        /// parallel transfer behavior.
        /// </summary>
        public StorageTransferOptions TransferOptions { get; set; }

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
        /// Optional override settings for this client's <see cref="BlobClientOptions.TransferValidation"/> settings.
        /// This operation does not allow <see cref="UploadTransferValidationOptions.PrecalculatedChecksum"/>
        /// to be set.
        /// </summary>
        public UploadTransferValidationOptions TransferValidation { get; set; }
    }
}
