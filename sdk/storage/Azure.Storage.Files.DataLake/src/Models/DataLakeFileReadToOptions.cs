// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        /// When set to true, enables locality-aware routing for parallel file reads.
        /// A Get Blob Layout call will be made to obtain the file's data layout and route
        /// subsequent range requests to optimal endpoints. Default is false.
        /// </summary>
        public bool EnableDataLocality { get; set; }
    }
}
