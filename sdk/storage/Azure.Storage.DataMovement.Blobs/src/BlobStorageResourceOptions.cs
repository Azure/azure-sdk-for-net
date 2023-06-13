// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs.Models;
using Azure.Storage.DataMovement.Models;
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
            CopyMethod = other?.CopyMethod ?? TransferCopyMethod.None;
            Metadata = other?.Metadata;
            Tags = other?.Tags;
            HttpHeaders = other?.HttpHeaders;
            AccessTier = other?.AccessTier;
            RehydratePriority = other?.RehydratePriority;
            DestinationImmutabilityPolicy = other?.DestinationImmutabilityPolicy;
            LegalHold = other?.LegalHold;
            CopySourceTagsMode = other?.CopySourceTagsMode;
            CopySourceBlobProperties = other?.CopySourceBlobProperties;
            UploadTransferValidationOptions = other?.UploadTransferValidationOptions;
            DownloadTransferValidationOptions = other?.DownloadTransferValidationOptions;
        }

        /// <summary>
        /// Optional. See <see cref="TransferCopyMethod"/>.
        /// Defines the copy operation to use. Defaults to <see cref="TransferCopyMethod.SyncCopy"/>.
        ///
        /// Applies to copy transfers.
        /// </summary>
        public TransferCopyMethod CopyMethod { get; set; }

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
        /// Applies to upload transfers and copy transfers when <see cref="CopyMethod"/>
        /// is set to <see cref="TransferCopyMethod.SyncCopy"/>.
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
        /// Optional. See <see cref="Storage.Blobs.Models.RehydratePriority"/>.
        /// Indicates the priority with which to rehydrate an archived blob.
        ///
        /// Applies to copy transfers when <see cref="CopyMethod"/> is set to <see cref="TransferCopyMethod.AsyncCopy"/>.
        /// </summary>
        public RehydratePriority? RehydratePriority { get; set; }

        /// <summary>
        /// Optional. See <see cref="BlobImmutabilityPolicy"/>.
        ///
        /// Applies to upload transfers and copy transfers when <see cref="CopyMethod"/>
        /// is set to <see cref="TransferCopyMethod.AsyncCopy"/>.
        /// </summary>
        public BlobImmutabilityPolicy DestinationImmutabilityPolicy { get; set; }

        /// <summary>
        /// Optional. Indicates if a legal hold should be placed on the blob.
        ///
        /// Applies to upload and copy transfers.
        /// </summary>
        public bool? LegalHold { get; set; }

        /// <summary>
        /// Optional.
        /// If <see cref="BlobCopySourceTagsMode.Replace"/>, the tags on the destination blob will be set to <see cref="Tags"/>.
        /// If <see cref="BlobCopySourceTagsMode.Copy"/>, the tags on the source blob will be copied to the destination blob.
        /// Default is to replace.
        ///
        /// Applies to copy transfers.
        /// </summary>
        public BlobCopySourceTagsMode? CopySourceTagsMode { get; set; }

        /// <summary>
        /// Optional. The copy source blob properties behavior. If true, the properties
        /// of the source blob will be copied to the new blob. Default is true.
        ///
        /// Applies to copy transfers when <see cref="CopyMethod"/> is set to <see cref="TransferCopyMethod.SyncCopy"/>.
        /// </summary>
        public bool? CopySourceBlobProperties { get; set; }

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
