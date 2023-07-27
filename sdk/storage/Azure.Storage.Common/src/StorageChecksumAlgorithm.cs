// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage
{
    /// <summary>
    /// Algorithm for generating a checksum to be used for verifying REST contents on a transfer.
    /// </summary>
    public enum StorageChecksumAlgorithm
    {
        /// <summary>
        /// Recommended. Allow the library to choose an algorithm. Different library versions may
        /// make different choices.
        /// </summary>
        Auto = 0,

        /// <summary>
        /// No selected algorithm. Do not calculate or request checksums.
        /// </summary>
        None = 1,

        /// <summary>
        /// Standard MD5 hash algorithm.
        /// </summary>
        MD5 = 2,

        /// <summary>
        /// Azure Storage custom 64 bit CRC.
        /// </summary>
        StorageCrc64 = 3,
    }
}
