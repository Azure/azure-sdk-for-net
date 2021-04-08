// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Models
{
    /// <summary>
    /// Specifies the algorithm to be used for calculating a transactional hash on blob data.
    /// </summary>
    public enum TransactionalHashAlgorithm
    {
        /// <summary>
        /// No selected algorithm. This will cause an exception
        /// if transactional hashing is opted into.
        /// </summary>
        None = 0,

        /// <summary>
        /// CRC-64 checksum with Azure Storage polynomial.
        /// This is the preferred option.
        /// </summary>
        StorageCrc64 = 1,

        /// <summary>
        /// MD5 checksum.
        /// </summary>
        MD5 = 2
    }
}
