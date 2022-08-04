// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Optional parameters for appending data to a file with DataLakeFileClient.Append() and .AppendAsync().
    /// </summary>
    public class DataLakeFileAppendOptions
    {
        /// <summary>
        /// Optional lease ID for accessing this blob.
        /// </summary>
        public string LeaseId { get; set; }

        /// <summary>
        /// Optional <see cref="IProgress{Long}"/> to provide
        /// progress updates about data transfers.
        /// </summary>
        public IProgress<long> ProgressHandler { get; set; }

        /// <summary>
        /// This hash is used to verify the integrity of the request content during transport. When this header is specified,
        /// the storage service compares the hash of the content that has arrived with this header value. If the two hashes do not match,
        /// the operation will fail with error code 400 (Bad Request). Note that this MD5 hash is not stored with the file. This header is
        /// associated with the request content, and not with the stored content of the file itself.
        /// </summary>
        public byte[] ContentHash { get; set; }

        /// <summary>
        /// Optional <see cref="UploadTransferValidationOptions"/> for using transactional
        /// checksum validation on append.
        /// </summary>
        public UploadTransferValidationOptions TransferValidationOptions { get; set; }

        /// <summary>
        /// Optional.  If true, the file will be flushed after the append.
        /// </summary>
        public bool? Flush { get; set; }
    }
}
