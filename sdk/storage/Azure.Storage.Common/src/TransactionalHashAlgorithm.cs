// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage
{
    /// <summary>
    /// Hash algorithm to use for verifying REST contents for an upload or download.
    /// </summary>
    public enum TransactionalHashAlgorithm
    {
        /// <summary>
        /// No selected algorithm.
        /// </summary>
        None = 0,

        /// <summary>
        /// Azure Storage custom 64 bit CRC algorithm.
        /// </summary>
        StorageCrc64 = 1,

        /// <summary>
        /// Standard MD5 hash algorithm.
        /// </summary>
        MD5 = 2
    }
}
