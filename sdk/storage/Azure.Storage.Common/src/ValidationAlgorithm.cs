// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage
{
    /// <summary>
    /// Algorithm for generating a checksum to be used for verifying REST contents on a transfer.
    /// </summary>
    public enum ValidationAlgorithm
    {
        /// <summary>
        /// Recommended. Allow the SDK to choose for me.
        /// </summary>
        Auto = 0,

        /// <summary>
        /// No selected algorithm.
        /// </summary>
        None = 1,

        /// <summary>
        /// Azure Storage custom 64 bit CRC.
        /// </summary>
        StorageCrc64 = 2,

        /// <summary>
        /// Standard MD5 hash algorithm.
        /// </summary>
        MD5 = 3
    }
}
