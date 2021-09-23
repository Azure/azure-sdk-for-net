// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using Azure.Core;

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

        public static void AssertResponseHashMatch(Stream content, TransactionalHashAlgorithm algorithm, Response response)
        {
            GetHashResult computedHash = GetHash(content, algorithm);
            AssertResponseHashMatch(computedHash, algorithm, response);
        }

        public static void AssertResponseHashMatch(byte[] content, int offset, int count, TransactionalHashAlgorithm algorithm, Response response)
        {
            GetHashResult computedHash = GetHash(content, offset, count, algorithm);
            AssertResponseHashMatch(computedHash, algorithm, response);
        }

        private static void AssertResponseHashMatch(GetHashResult computedHash, TransactionalHashAlgorithm algorithm, Response response)
        {
            switch (algorithm)
            {
                case TransactionalHashAlgorithm.MD5:
                    if (!Enumerable.SequenceEqual(
                        computedHash.MD5,
                        response.Headers.TryGetValue("Content-MD5", out byte[] md5) ? md5 : default))
                    {
                        throw Errors.HashMismatch("Content-MD5");
                    }
                    break;
                case TransactionalHashAlgorithm.StorageCrc64:
                    if (!Enumerable.SequenceEqual(
                        computedHash.StorageCrc64,
                        response.Headers.TryGetValue("x-ms-content-crc64", out byte[] crc) ? crc : default))
                    {
                        throw Errors.HashMismatch("x-ms-content-crc64");
                    }
                    break;
                default:
                    throw new ArgumentException($"Could not verify payload with the specified transactional hash algorithm {algorithm}.");
            }
        }

        /// <summary>
        /// Computes the requested hash for an upload operation, if desired.
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
                TransactionalHashAlgorithm.StorageCrc64 => new GetHashResult()
                {
                    StorageCrc64 = ComputeHash(content, new NonCryptographicHashAlgorithmHasher(StorageCrc64NonCryptographicHashAlgorithm.Create()))
                },
#pragma warning disable CA5351 // Do Not Use Broken Cryptographic Algorithms; MD5 being used for content integrity check, not encryption
                TransactionalHashAlgorithm.MD5 => new GetHashResult() { MD5 = ComputeHash(content, new HashAlgorithmHasher(MD5.Create())) },
#pragma warning restore CA5351 // Do Not Use Broken Cryptographic Algorithms
                _ => new GetHashResult()
            };
        }

        /// <summary>
        /// Computes the requested hash, if desired.
        /// </summary>
        /// <param name="content">Content to hash.</param>
        /// <param name="offset">Starting offset of content array to compute with.</param>
        /// <param name="count">Numbert of bytes after offset to compute with.</param>
        /// <param name="algorithmIdentifier">Algorithm to compute the hash with.</param>
        /// <returns>Object containing the requested hash, or no hash, on its algorithm's respective property.</returns>
        public static GetHashResult GetHash(byte[] content, int offset, int count, TransactionalHashAlgorithm algorithmIdentifier)
        {
            byte[] computeHash(StorageCrc64NonCryptographicHashAlgorithm nonCryptographicHashAlgorithm)
            {
                nonCryptographicHashAlgorithm.Append(new ReadOnlySpan<byte>(content, offset, count));
                return nonCryptographicHashAlgorithm.GetCurrentHash();
            }

            return algorithmIdentifier switch
            {
                TransactionalHashAlgorithm.StorageCrc64 => new GetHashResult()
                {
                    StorageCrc64 = computeHash(StorageCrc64NonCryptographicHashAlgorithm.Create())
                },
#pragma warning disable CA5351 // Do Not Use Broken Cryptographic Algorithms; MD5 being used for content integrity check, not encryption
                TransactionalHashAlgorithm.MD5 => new GetHashResult() { MD5 = MD5.Create().ComputeHash(content, offset, count) },
#pragma warning restore CA5351 // Do Not Use Broken Cryptographic Algorithms
                _ => new GetHashResult()
            };
        }

        /// <summary>
        /// Compute hash on a stream and reset stream to original position.
        /// </summary>
        /// <param name="content">Seekable stream to compute on.</param>
        /// <param name="hasher">IHasher to compute with.</param>
        /// <returns></returns>
        private static byte[] ComputeHash(Stream content, IHasher hasher)
        {
            long startPosition = content.Position;
            byte[] hash = hasher.ComputeHash(content);
            content.Position = startPosition;
            return hash;
        }
    }
}
