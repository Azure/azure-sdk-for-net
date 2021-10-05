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
        /// Construct new instance of options targeting a file path.
        /// </summary>
        /// <param name="path">Path to write to.</param>
        public BlobDownloadToOptions(string path)
        {
            Path = path;
        }

        /// <summary>
        /// Construct new instance of options targeting a write-enabled stream.
        /// </summary>
        /// <param name="targetStream"><see cref="Stream"/> to write to.</param>
        public BlobDownloadToOptions(Stream targetStream)
        {
            Stream = targetStream;
        }

        /// <summary>
        /// Path to read to.
        /// </summary>
        internal string Path { get; }

        /// <summary>
        /// Stream to read to.
        /// </summary>
        internal Stream Stream { get; }

        /// <summary>
        /// Request conditions for downloading.
        /// </summary>
        public BlobRequestConditions Conditions { get; set; }

        ///// <summary>
        ///// Progress handler for tracking download progress.
        ///// </summary>
        // public IProgress<long> ProgressHandler { get; set; }

        /// <summary>
        /// Transfer options for managing individual read requests.
        /// </summary>
        public StorageTransferOptions TransferOptions { get; set; }

        /// <summary>
        /// Transactional hashing options for data integrity checks.
        /// </summary>
        public DownloadTransactionalHashingOptions TransactionalHashingOptions { get; set; }
    }
}
