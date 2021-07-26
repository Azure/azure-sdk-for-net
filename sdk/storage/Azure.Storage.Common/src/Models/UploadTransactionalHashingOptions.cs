// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Models
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
        /// Optional. For an upload API that ends up using a single REST call,
        /// a precalculated hash for the upload contents can be provided to skip
        /// recalculating. This hash will be ignored if the upload splits into
        /// multiple REST calls and new ones will be calculated.
        /// </summary>
        public byte[] PrecalculatedHash { get; set; }
    }
}
