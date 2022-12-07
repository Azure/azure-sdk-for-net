// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.DataMovement.Blobs
{
    /// <summary>
    /// Optional parameters for uploading to a
    /// PageBlobStorageResource.
    /// </summary>
    public class PageBlobStorageResourceUploadOptions
    {
        /// <summary>
        /// Optional. See <see cref="PageBlobRequestConditions"/> to add
        /// conditions on the upload of this page blob.
        /// </summary>
        public PageBlobRequestConditions Conditions { get; set; }

        /// <summary>
        /// Optional. See <see cref="UploadTransferValidationOptions"/> for using transactional
        /// hashing on uploads.
        /// </summary>
        public UploadTransferValidationOptions TransferValidationOptions { get; set; }
    }
}
