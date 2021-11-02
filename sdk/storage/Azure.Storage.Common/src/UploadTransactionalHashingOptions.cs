// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage
{
    /// <summary>
    /// Hashing options for validating upload content.
    /// </summary>
    public class UploadTransactionalHashingOptions
    {
        /// <summary>
        /// Hashing algorithm to use for the transaction.
        /// </summary>
        public TransactionalHashAlgorithm Algorithm { get; set; }

        /// <summary>
        /// Optional. Upload APIs that send the given data all in one request
        /// can use this hash instead of calculating their own. This is not
        /// accepted by methods that split data into parts for upload.
        /// </summary>
        public byte[] PrecalculatedHash { get; set; }
    }
}
