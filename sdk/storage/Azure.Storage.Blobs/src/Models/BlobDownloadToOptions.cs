// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Options for reading a blob to a destination.
    /// </summary>
    public class BlobDownloadToOptions
    {
        /// <summary>
        /// Request conditions for downloading.
        /// </summary>
        public BlobRequestConditions Conditions { get; set; }

        /// <summary>
        /// Progress handler for tracking download progress.
        /// </summary>
        public IProgress<long> ProgressHandler { get; set; }

        /// <summary>
        /// Transfer options for managing individual read requests.
        /// </summary>
        public StorageTransferOptions TransferOptions { get; set; }

        /// <summary>
        /// Optional override settings for this client's <see cref="BlobClientOptions.TransferValidation"/> settings.
        /// This operation does not allow <see cref="DownloadTransferValidationOptions.AutoValidateChecksum"/>
        /// to be set false.
        /// </summary>
        public DownloadTransferValidationOptions TransferValidation { get; set; }
    }
}
