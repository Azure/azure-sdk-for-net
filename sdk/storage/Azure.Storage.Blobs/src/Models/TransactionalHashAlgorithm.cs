// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Specifies the algorithm to be used for calculating a transactional hash on blob data.
    /// </summary>
    public enum TransactionalHashAlgorithm
    {
        /// <summary>
        /// CRC-64 checksum with custom Storage polynomial.
        /// </summary>
        StorageCrc64 = 0,

        /// <summary>
        /// MD5 checksum.
        /// </summary>
        MD5 = 1
    }
}
