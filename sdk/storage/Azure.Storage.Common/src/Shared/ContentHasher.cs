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
            public GetHashResult(byte[] md5 = default, byte[] storageCrc64 = default)
            {
                MD5 = md5;
                StorageCrc64 = storageCrc64;
            }

            public byte[] MD5 { get; }
            public byte[] StorageCrc64 { get; }
        }

        /// <summary>
        /// Asserts the content of the given stream match the response content hash.
        /// </summary>
        /// <param name="content">Content to hash.</param>
        /// <param name="algorithm">Hash algorithm identifier.</param>
        /// <param name="response">Response containing a response hash.</param>
        /// <exception cref="ArgumentException">
        /// Throws if <paramref name="algorithm"/> is invalid.
        /// </exception>
        /// <exception cref="InvalidDataException">
        /// Throws if the hashes do not match.
        /// </exception>
        public static void AssertResponseHashMatch(Stream content, ValidationAlgorithm algorithm, Response response)
        {
            GetHashResult computedHash = GetHash(content, algorithm);
            AssertResponseHashMatch(computedHash, algorithm, response);
        }

        /// <summary>
        /// Asserts the content of the given array match the response content hash.
        /// </summary>
        /// <param name="content">Content to hash.</param>
        /// <param name="offset">Offset to start reading content at.</param>
        /// <param name="count">Number of bytes to read starting from the offset.</param>
        /// <param name="algorithm">Hash algorithm identifier.</param>
        /// <param name="response">Response containing a response hash.</param>
        /// <exception cref="ArgumentException">
        /// Throws if <paramref name="algorithm"/> is invalid.
        /// </exception>
        /// <exception cref="InvalidDataException">
        /// Throws if the hashes do not match.
        /// </exception>
        public static void AssertResponseHashMatch(byte[] content, int offset, int count, ValidationAlgorithm algorithm, Response response)
        {
            GetHashResult computedHash = GetHash(content, offset, count, algorithm);
            AssertResponseHashMatch(computedHash, algorithm, response);
        }

        /// <summary>
        /// Asserts the computed hash matches the response content hash.
        /// </summary>
        /// <param name="computedHash">SDK computed hash.</param>
        /// <param name="algorithm">Hash algorithm identifier.</param>
        /// <param name="response">Response containing a response hash.</param>
        /// <exception cref="ArgumentException">
        /// Throws if <paramref name="algorithm"/> is invalid.
        /// </exception>
        /// <exception cref="InvalidDataException">
        /// Throws if the hashes do not match.
        /// </exception>
        private static void AssertResponseHashMatch(GetHashResult computedHash, ValidationAlgorithm algorithm, Response response)
        {
            if (computedHash == default)
            {
                throw Errors.ArgumentNull(nameof(computedHash));
            }
            if (response == default)
            {
                throw Errors.ArgumentNull(nameof(response));
            }

            switch (algorithm.ResolveAuto())
            {
                case ValidationAlgorithm.MD5:
                    if (!Enumerable.SequenceEqual(
                        computedHash.MD5,
                        response.Headers.TryGetValue("Content-MD5", out byte[] md5) ? md5 : default))
                    {
                        throw Errors.HashMismatch("Content-MD5");
                    }
                    break;
                case ValidationAlgorithm.StorageCrc64:
                    if (!Enumerable.SequenceEqual(
                        computedHash.StorageCrc64,
                        response.Headers.TryGetValue("x-ms-content-crc64", out byte[] crc) ? crc : default))
                    {
                        throw Errors.HashMismatch("x-ms-content-crc64");
                    }
                    break;
                default:
                    throw Errors.InvalidArgument(nameof(algorithm));
            }
        }

        /// <summary>
        /// Computes the requested hash for an upload operation, or default.
        /// </summary>
        /// <param name="content">Content to hash.</param>
        /// <param name="options">Hash options.</param>
        /// <returns>
        /// Object containing the requested hash on its algorithm's respective property. If
        /// <paramref name="options"/> are default or specified as "None", then the returned result is default.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Throws if <paramref name="options"/> exists and <see cref="UploadTransferValidationOptions.Algorithm"/>
        /// is invalid.
        /// </exception>
        public static GetHashResult GetHashOrDefault(Stream content, UploadTransferValidationOptions options)
        {
            if (options == default || options.Algorithm == ValidationAlgorithm.None)
            {
                return default;
            }

            if (options.PrecalculatedChecksum != default)
            {
                return options.Algorithm.ResolveAuto() switch
                {
                    ValidationAlgorithm.StorageCrc64 => new GetHashResult(storageCrc64: options.PrecalculatedChecksum),
                    ValidationAlgorithm.MD5 => new GetHashResult(md5: options.PrecalculatedChecksum),
                    _ => throw Errors.InvalidArgument(nameof(options.Algorithm))
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
        /// <exception cref="ArgumentException">
        /// Throws if <paramref name="algorithmIdentifier"/> is invalid.
        /// </exception>
        public static GetHashResult GetHash(Stream content, ValidationAlgorithm algorithmIdentifier)
        {
            return algorithmIdentifier.ResolveAuto() switch
            {
                ValidationAlgorithm.StorageCrc64 => new GetHashResult(
                    storageCrc64: ComputeHash(content, new NonCryptographicHashAlgorithmHasher(StorageCrc64HashAlgorithm.Create()))),
#pragma warning disable CA5351 // Do Not Use Broken Cryptographic Algorithms; MD5 being used for content integrity check, not encryption
                ValidationAlgorithm.MD5 => new GetHashResult(md5: ComputeHash(content, new HashAlgorithmHasher(MD5.Create()))),
#pragma warning restore CA5351 // Do Not Use Broken Cryptographic Algorithms
                _ => throw Errors.InvalidArgument(nameof(algorithmIdentifier))
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
        /// <exception cref="ArgumentException">
        /// Throws if <paramref name="algorithmIdentifier"/> is invalid.
        /// </exception>
        public static GetHashResult GetHash(byte[] content, int offset, int count, ValidationAlgorithm algorithmIdentifier)
        {
            byte[] computeHash(StorageCrc64HashAlgorithm nonCryptographicHashAlgorithm)
            {
                nonCryptographicHashAlgorithm.Append(new ReadOnlySpan<byte>(content, offset, count));
                return nonCryptographicHashAlgorithm.GetCurrentHash();
            }

            return algorithmIdentifier.ResolveAuto() switch
            {
                ValidationAlgorithm.StorageCrc64 => new GetHashResult(
                    storageCrc64: computeHash(StorageCrc64HashAlgorithm.Create())),
#pragma warning disable CA5351 // Do Not Use Broken Cryptographic Algorithms; MD5 being used for content integrity check, not encryption
                ValidationAlgorithm.MD5 => new GetHashResult(md5: MD5.Create().ComputeHash(content, offset, count)),
#pragma warning restore CA5351 // Do Not Use Broken Cryptographic Algorithms
                _ => throw Errors.InvalidArgument(nameof(algorithmIdentifier))
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
