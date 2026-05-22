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

        /// <summary>
        /// When set to true, enables locality-aware routing for the parallel range
        /// requests issued by the download. The blob's layout is fetched on demand
        /// and cached (with automatic background refresh), and each range download
        /// is routed to the optimal endpoint for the chunk being read. This is a
        /// performance optimization only - the bytes returned are identical to a
        /// non-locality-aware download. Default is false.
        /// </summary>
        public bool EnableDataLocality { get; set; }
    }
}
