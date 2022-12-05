// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Blobs.Models;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement.Blobs
{
    /// <summary>
    /// Optional parameters for upload for
    /// Append Block Storage Resource
    /// </summary>
    public class AppendBlobStorageResourceUploadOptions
    {
        /// <summary>
        /// Optional <see cref="AppendBlobRequestConditions"/> to add
        /// conditions on the upload of this Append Blob.
        /// </summary>
        public AppendBlobRequestConditions Conditions { get; set; }

        /// <summary>
        /// Optional <see cref="UploadTransferValidationOptions"/> for using additional
        /// transactional validation on block appending. Transactional checksums are
        /// discarded after use.
        ///
        /// AppendBlock accepts precalcualted checksums, but the method will calculate
        /// one if not provided.
        /// </summary>
        public UploadTransferValidationOptions TransferValidationOptions { get; set; }
    }
}
