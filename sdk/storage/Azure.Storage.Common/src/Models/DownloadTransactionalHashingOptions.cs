// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Models
{
    /// <summary>
    /// Transactional hash options for upload methods.
    /// </summary>
    public class DownloadTransactionalHashingOptions
    {
        /// <summary>
        /// Algorithm for the SDK to request a checksum with and verify
        /// downloaded content against.
        /// </summary>
        public TransactionalHashAlgorithm Algorithm { get; set; }
    }
}
