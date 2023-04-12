// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.IO.Hashing;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage
{
    /// <summary>
    /// HashAlgorithm wrapper for IHasher interface
    /// </summary>
    internal class HashAlgorithmHasher : IHasher
    {
        private readonly HashAlgorithm _hashAlgorithm;

        public int HashSize => _hashAlgorithm.HashSize;

        public HashAlgorithmHasher(HashAlgorithm hashAlgorithm)
        {
            _hashAlgorithm = hashAlgorithm;
        }

        public byte[] ComputeHash(Stream stream) => _hashAlgorithm.ComputeHash(stream);

        public void AppendHash(ReadOnlySpan<byte> content)
        {
            _hashAlgorithm.TransformBlock(content.ToArray(), 0, content.Length, null, 0);
        }

        public int GetFinalHash(Span<byte> hashDestination)
        {
            byte[] hash = _hashAlgorithm.TransformFinalBlock(new byte[0], 0, 0);
            hash.CopyTo(hashDestination);
            return hash.Length;
        }

        public void Dispose()
        {
            _hashAlgorithm.Dispose();
        }
    }
}
