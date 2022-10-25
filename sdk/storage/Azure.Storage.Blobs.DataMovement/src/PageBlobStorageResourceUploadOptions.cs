// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Blobs.DataMovement
{
    /// <summary>
    /// Optional parameters for uploading pages.
    /// </summary>
    public class PageBlobStorageResourceUploadOptions
    {
        /// <summary>
        /// Optional <see cref="PageBlobRequestConditions"/> to add
        /// conditions on the upload of this Append Blob.
        /// </summary>
        public PageBlobRequestConditions Conditions { get; set; }

        /// <summary>
        /// Optional <see cref="UploadTransferValidationOptions"/> for using transactional
        /// hashing on uploads.
        /// </summary>
        public UploadTransferValidationOptions TransferValidationOptions { get; set; }
    }
}
