// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;

namespace Azure.Storage
{
    /// <summary>
    /// Interface to wrap either a HashAlgorithm or a NonCryptographicHashAlgorithm
    /// to provide a common interface for hashing a stream.
    /// </summary>
    internal interface IHasher
    {
        /// <summary>
        /// Hashes the contents of the stream.
        /// </summary>
        /// <param name="stream">Content</param>
        byte[] ComputeHash(Stream stream);
    }
}
