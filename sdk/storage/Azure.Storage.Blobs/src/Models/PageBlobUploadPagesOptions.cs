// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Optional parameters for uploading pages.
    /// </summary>
    public class PageBlobUploadPagesOptions
    {
        /// <summary>
        /// Optional <see cref="PageBlobRequestConditions"/> to add
        /// conditions on the upload of this Page Blob.
        /// </summary>
        public PageBlobRequestConditions Conditions { get; set; }

        /// <summary>
        /// Optional <see cref="IProgress{Long}"/> to provide
        /// progress updates about data transfers.
        /// </summary>
        public IProgress<long> ProgressHandler { get; set; }

        /// <summary>
        /// Optional override settings for this client's <see cref="BlobClientOptions.TransferValidation"/> settings.
        /// </summary>
        public UploadTransferValidationOptions TransferValidation { get; set; }

        /// <summary>
        /// Optional. Sets the priority of this request, from 0 through 7.
        /// If not set, or if the value is outside that range, the service uses 3.
        /// </summary>
        public int? RequestPriority { get; set; }
    }
}
