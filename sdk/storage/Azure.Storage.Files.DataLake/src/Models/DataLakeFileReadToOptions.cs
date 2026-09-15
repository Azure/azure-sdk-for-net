// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Options for reading a file to a destination.
    /// </summary>
    public class DataLakeFileReadToOptions
    {
        /// <summary>
        /// Request conditions for downloading.
        /// </summary>
        public DataLakeRequestConditions Conditions { get; set; }

        ///// <summary>
        ///// Progress handler for tracking download progress.
        ///// </summary>
        // public IProgress<long> ProgressHandler { get; set; }

        /// <summary>
        /// Transfer options for managing individual read requests.
        /// </summary>
        public StorageTransferOptions TransferOptions { get; set; }

        /// <summary>
        /// Optional override settings for this client's <see cref="DataLakeClientOptions.TransferValidation"/> settings.
        /// </summary>
        public DownloadTransferValidationOptions TransferValidation { get; set; }

        /// <summary>
        /// Determines whether locality-aware routing is used for the parallel range
        /// requests issued by the read. When enabled, the file's layout is fetched on
        /// demand and cached (with automatic background refresh), and each range
        /// download is routed to the optimal endpoint for the chunk being read. This is
        /// a performance optimization only - the bytes returned are identical to a
        /// non-locality-aware download.
        /// </summary>
        public LayoutAwareRouting LayoutAwareRouting { get; set; } = LayoutAwareRouting.Auto;
    }
}
