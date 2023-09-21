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
            DestinationImmutabilityPolicy = other?.DestinationImmutabilityPolicy;
            LegalHold = other?.LegalHold;
            UploadTransferValidationOptions = other?.UploadTransferValidationOptions;
            DownloadTransferValidationOptions = other?.DownloadTransferValidationOptions;
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

        /// <summary>
        /// Optional. See <see cref="BlobImmutabilityPolicy"/>.
        ///
        /// Applies to upload transfers.
        /// </summary>
        public BlobImmutabilityPolicy DestinationImmutabilityPolicy { get; set; }

        /// <summary>
        /// Optional. Indicates if a legal hold should be placed on the blob.
        ///
        /// Applies to upload transfers.
        /// </summary>
        public bool? LegalHold { get; set; }

        /// <summary>
        /// Optional. Options for transfer validation settings on this operation.
        /// When transfer validation options are set in the client, setting this parameter
        /// acts as an override.
        /// This operation does not allow <see cref="UploadTransferValidationOptions.PrecalculatedChecksum"/>
        /// to be set.
        ///
        /// Applies to upload transfers.
        /// </summary>
        public UploadTransferValidationOptions UploadTransferValidationOptions { get; set; }

        /// <summary>
        /// Optional. Options for transfer validation settings on this operation.
        /// When transfer validation options are set in the client, setting this parameter
        /// acts as an override.
        /// Set <see cref="DownloadTransferValidationOptions.AutoValidateChecksum"/> to false if you
        /// would like to skip SDK checksum validation and validate the checksum found
        /// in the <see cref="Response"/> object yourself.
        /// Range must be provided explicitly, stating a range withing Azure
        /// Storage size limits for requesting a transactional hash. See the
        /// <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-blob">
        /// REST documentation</a> for range limitation details.
        ///
        /// Applies to download transfers.
        /// </summary>
        public DownloadTransferValidationOptions DownloadTransferValidationOptions { get; set; }
    }
}
