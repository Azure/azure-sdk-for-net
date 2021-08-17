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
        public TransactionalHashAlgorithm Algorithm { get; set; }

        /// <summary>
        /// Indicates that while the transactional hash should still be
        /// requested on download, it should NOT be validated by this call.
        /// Instead, the caller is responsible for validating the hash on the
        /// returned <see cref="Response{T}"/>. If unsure, leave this to
        /// default of false.
        /// </summary>
        public bool DeferValidation { get; set; }
    }
}
