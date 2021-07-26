// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Security.Cryptography;
using Azure.Storage.Models;

namespace Azure.Storage
{
    /// <summary>
    /// Hashes Storage content.
    /// </summary>
    internal class ContentHasher
    {
        internal class GetHashResult
        {
            public byte[] MD5 { get; set;  }
            public byte[] StorageCrc64 { get; set; }
        }

        /// <summary>
        /// Computes the requested hash, if desired.
        /// </summary>
        /// <param name="content">Content to hash.</param>
        /// <param name="algorithmIdentifier">Algorithm to compute the hash with.</param>
        /// <returns>Object containing the requested hash on its algorithm's respective property.</returns>
        public static GetHashResult GetHash(Stream content, TransactionalHashAlgorithm algorithmIdentifier)
        {
            return algorithmIdentifier switch
            {
                TransactionalHashAlgorithm.StorageCrc64 => throw new NotImplementedException(), // new GetHashResult() { StorageCrc64 = ComputeHash(content, ) },
#pragma warning disable CA5351 // Do Not Use Broken Cryptographic Algorithms; MD5 being used for content integrity check, not encryption
                TransactionalHashAlgorithm.MD5 => new GetHashResult() { MD5 = ComputeHash(content, MD5.Create()) },
#pragma warning restore CA5351 // Do Not Use Broken Cryptographic Algorithms
                _ => new GetHashResult()
            };
        }

        private static byte[] ComputeHash(Stream content, HashAlgorithm hashAlgorithm)
        {
            long startPosition = content.Position;
            byte[] hash = hashAlgorithm.ComputeHash(content);
            content.Position = startPosition;
            return hash;
        }
    }
}
