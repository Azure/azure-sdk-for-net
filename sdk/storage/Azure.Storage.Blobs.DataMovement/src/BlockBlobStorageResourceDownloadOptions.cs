// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs.Models;
using System;

namespace Azure.Storage.Blobs.DataMovement
{
    /// <summary>
    /// Optional parameters for uploading to a Blob.
    /// </summary>
    public class BlockBlobStorageResourceDownloadOptions
    {
        /// <summary>
        /// Optional <see cref="BlobRequestConditions"/> to add conditions on
        /// downloading this blob.
        /// </summary>
        public BlobRequestConditions Conditions { get; set; }

        /// <summary>
        /// Options for transfer validation settings on this operation.
        /// When transfer validation options are set in the client, setting this parameter
        /// acts as an override.
        /// Set <see cref="DownloadTransferValidationOptions.AutoValidateChecksum"/> to false if you
        /// would like to skip SDK checksum validation and validate the checksum found
        /// in the <see cref="Response"/> object yourself.
        /// Range must be provided explicitly, stating a range withing Azure
        /// Storage size limits for requesting a transactional hash. See the
        /// <a href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-blob">
        /// REST documentation</a> for range limitation details.
        /// </summary>
        public DownloadTransferValidationOptions TransferValidationOptions { get; set; }
    }
}
