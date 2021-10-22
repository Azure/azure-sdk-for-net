// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Security.Cryptography;

namespace Azure.Storage
{
    /// <summary>
    /// HashAlgorithm wrapper for IHasher interface
    /// </summary>
    internal class HashAlgorithmHasher : IHasher
    {
        private readonly HashAlgorithm _hashAlgorithm;

        public HashAlgorithmHasher(HashAlgorithm hashAlgorithm)
        {
            _hashAlgorithm = hashAlgorithm;
        }

        public byte[] ComputeHash(Stream stream) => _hashAlgorithm.ComputeHash(stream);
    }
}
