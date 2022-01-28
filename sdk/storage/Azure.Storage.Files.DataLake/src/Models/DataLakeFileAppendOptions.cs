// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Optional parameters for appending data to a file with
    /// <see cref="DataLakeFileClient.AppendAsync(Stream, long, DataLakeFileAppendOptions, CancellationToken)"/>.
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
        /// Optional <see cref="UploadTransactionalHashingOptions"/> for using transactional
        /// hashing on uploads.
        /// </summary>
        public UploadTransactionalHashingOptions TransactionalHashingOptions { get; set; }
    }
}
