// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage
{
    /// <summary>
    /// Hashing options for validating upload content.
    /// </summary>
    public class DownloadTransactionalHashingOptions
    {
        /// <summary>
        /// Hashing algorithm to use for the transaction.
        /// </summary>
        public TransactionalHashAlgorithm Algorithm { get; set; } = TransactionalHashAlgorithm.StorageCrc64;

        /// <summary>
        /// Defaults to true. Indicates whether the SDK should validate the content
        /// body against the content hash before returning contents to the caller.
        /// If set to false, caller is responsible for extracting the hash out
        /// of the <see cref="Response{T}"/> and validating the hash themselves.
        /// </summary>
        public bool Validate { get; set; } = true;
    }
}
