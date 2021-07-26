// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Models
{
    /// <summary>
    /// Hashing options for validating upload content.
    /// </summary>
    public class DownloadTransactionalHashingOptions
    {
        /// <summary>
        /// Hashing algorithm to use for the transaction.
        /// </summary>
        public TransactionalHashAlgorithm Algorithm { get; set; }
    }
}
