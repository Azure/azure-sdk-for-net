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
        /// <param name="options">Hash options.</param>
        /// <returns>Object containing the requested hash, or no hash, on its algorithm's respective property.</returns>
        public static GetHashResult GetHash(Stream content, UploadTransactionalHashingOptions options)
        {
            if (options == default)
            {
                return new GetHashResult();
            }

            if (options.PrecalculatedHash != default)
            {
                return options.Algorithm switch
                {
                    TransactionalHashAlgorithm.StorageCrc64 => new GetHashResult() { StorageCrc64 = options.PrecalculatedHash },
                    TransactionalHashAlgorithm.MD5 => new GetHashResult() { MD5 = options.PrecalculatedHash },
                    _ => throw new ArgumentException(
                        $"{nameof(UploadTransactionalHashingOptions)} instance provided {nameof(UploadTransactionalHashingOptions.PrecalculatedHash)} without specifying a {nameof(TransactionalHashAlgorithm)}.")
                };
            }

            return GetHash(content, options.Algorithm);
        }

        /// <summary>
        /// Computes the requested hash, if desired.
        /// </summary>
        /// <param name="content">Content to hash.</param>
        /// <param name="algorithmIdentifier">Algorithm to compute the hash with.</param>
        /// <returns>Object containing the requested hash, or no hash, on its algorithm's respective property.</returns>
        public static GetHashResult GetHash(Stream content, TransactionalHashAlgorithm algorithmIdentifier)
        {
            return algorithmIdentifier switch
            {
                TransactionalHashAlgorithm.StorageCrc64 => new GetHashResult() { StorageCrc64 = ComputeHash(content, AzureStorageCrc64.Create()) },
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
