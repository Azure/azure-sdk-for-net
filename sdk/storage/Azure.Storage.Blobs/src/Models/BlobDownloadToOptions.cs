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
        /// Determines whether locality-aware routing is used for the parallel range
        /// requests issued by the download. When enabled, the blob's layout is fetched
        /// on demand and cached (with automatic background refresh), and each range
        /// download is routed to the optimal endpoint for the chunk being read. This is
        /// a performance optimization only - the bytes returned are identical to a
        /// non-locality-aware download.
        /// </summary>
        public LayoutAwareRouting LayoutAwareRouting { get; set; } = LayoutAwareRouting.Auto;
    }
}
