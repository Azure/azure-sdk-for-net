// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Storage
{
    /// <summary>
    /// Hashes Storage content.
    /// </summary>
    internal static class ContentHasher
    {
        internal class GetHashResult
        {
            private GetHashResult(StorageChecksumAlgorithm algorithm, ReadOnlyMemory<byte> checksum)
            {
                Algorithm = algorithm;
                Checksum = checksum;
            }

            public static GetHashResult FromStorageCrc64(ReadOnlyMemory<byte> checksum)
                => new GetHashResult(StorageChecksumAlgorithm.StorageCrc64, checksum);

            public static GetHashResult FromMD5(ReadOnlyMemory<byte> checksum)
                => new GetHashResult(StorageChecksumAlgorithm.MD5, checksum);

            public static GetHashResult Empty { get; } = new GetHashResult(StorageChecksumAlgorithm.None, default);

            public StorageChecksumAlgorithm Algorithm { get; }
            public ReadOnlyMemory<byte> Checksum { get; }

            public ReadOnlyMemory<byte> MD5 => Algorithm == StorageChecksumAlgorithm.MD5 ? Checksum : default;
            public ReadOnlyMemory<byte> StorageCrc64 => Algorithm == StorageChecksumAlgorithm.StorageCrc64 ? Checksum : default;

            public byte[] MD5AsArray => MD5.IsEmpty ? null : MD5.ToArray();
            public byte[] StorageCrc64AsArray => StorageCrc64.IsEmpty ? null : StorageCrc64.ToArray();
        }

        internal static int GetHashSizeInBytes(StorageChecksumAlgorithm algorithm)
            => algorithm.ResolveAuto() switch
            {
                StorageChecksumAlgorithm.None => 0,
                StorageChecksumAlgorithm.MD5 => Constants.MD5SizeInBytes,
                StorageChecksumAlgorithm.StorageCrc64 => Constants.StorageCrc64SizeInBytes,
                _ => throw Errors.InvalidArgument(nameof(algorithm))
            };

        internal static UploadTransferValidationOptions ToUploadTransferValidationOptions(this GetHashResult hashResult)
        {
            if (hashResult == null)
            {
                return new UploadTransferValidationOptions
                {
                    ChecksumAlgorithm = StorageChecksumAlgorithm.None
                };
            }
            return new UploadTransferValidationOptions
            {
                ChecksumAlgorithm = hashResult.Algorithm,
                PrecalculatedChecksum = hashResult.Checksum,
            };
        }

        /// <summary>
        /// Asserts the content of the given stream match the response content hash.
        /// </summary>
        /// <param name="content">Content to hash.</param>
        /// <param name="algorithm">Hash algorithm identifier.</param>
        /// <param name="response">Response containing a response hash.</param>
        /// <param name="async">Whether to perform the operation asynchronously.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <exception cref="ArgumentException">
        /// Throws if <paramref name="algorithm"/> is invalid.
        /// </exception>
        /// <exception cref="InvalidDataException">
        /// Throws if the hashes do not match.
        /// </exception>
        public static async Task AssertResponseHashMatchInternal(
            Stream content,
            StorageChecksumAlgorithm algorithm,
            Response response,
            bool async,
            CancellationToken cancellationToken)
        {
            GetHashResult computedHash = await GetHashInternal(content, algorithm, async, cancellationToken)
                .ConfigureAwait(false);
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
        public static void AssertResponseHashMatch(byte[] content, int offset, int count, StorageChecksumAlgorithm algorithm, Response response)
        {
            GetHashResult computedHash = GetHash(BinaryData.FromBytes(new ReadOnlyMemory<byte>(content, offset, count)), algorithm);
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
        private static void AssertResponseHashMatch(GetHashResult computedHash, StorageChecksumAlgorithm algorithm, Response response)
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
                case StorageChecksumAlgorithm.MD5:
                    if (!computedHash.MD5.Span.SequenceEqual(
                        response.Headers.TryGetValue("Content-MD5", out byte[] md5) ? md5 : default))
                    {
                        throw Errors.HashMismatch("Content-MD5");
                    }
                    break;
                case StorageChecksumAlgorithm.StorageCrc64:
                    if (!computedHash.StorageCrc64.Span.SequenceEqual(
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
        /// <param name="async">Whether to perform operation asynchronously.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>
        /// Object containing the requested hash on its algorithm's respective property. If
        /// <paramref name="options"/> are default or specified as "None", then the returned result is default.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Throws if <paramref name="options"/> exists and <see cref="UploadTransferValidationOptions.ChecksumAlgorithm"/>
        /// is invalid.
        /// </exception>
        public static async Task<GetHashResult> GetHashOrDefaultInternal(
            Stream content,
            UploadTransferValidationOptions options,
            bool async,
            CancellationToken cancellationToken)
        {
            if (GetHashOrDefaultTryFromOptions(options, out GetHashResult result))
            {
                return result;
            }
            return await GetHashInternal(content, options.ChecksumAlgorithm, async, cancellationToken).ConfigureAwait(false);
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
        /// Throws if <paramref name="options"/> exists and <see cref="UploadTransferValidationOptions.ChecksumAlgorithm"/>
        /// is invalid.
        /// </exception>
        public static GetHashResult GetHashOrDefault(BinaryData content, UploadTransferValidationOptions options)
        {
            if (GetHashOrDefaultTryFromOptions(options, out GetHashResult result))
            {
                return result;
            }
            return GetHash(content, options.ChecksumAlgorithm);
        }

        /// <summary>
        /// Attempts to get the appropriate response for
        /// <see cref="GetHashOrDefault(BinaryData, UploadTransferValidationOptions)"/>
        /// or
        /// <see cref="GetHashOrDefault(BinaryData, UploadTransferValidationOptions)"/>
        /// without calculating.
        /// </summary>
        /// <param name="options">
        /// Validation options for getting result.
        /// </param>
        /// <param name="result">
        /// Appropriate checksum result, if successful.
        /// </param>
        /// <returns>
        /// True if successful. False if caller must calculate the result for themselves.
        /// </returns>
        private static bool GetHashOrDefaultTryFromOptions(UploadTransferValidationOptions options, out GetHashResult result)
        {
            if (options == default || options.ChecksumAlgorithm == StorageChecksumAlgorithm.None)
            {
                result = default;
                return true;
            }

            if (!options.PrecalculatedChecksum.IsEmpty)
            {
                result = options.ChecksumAlgorithm.ResolveAuto() switch
                {
                    StorageChecksumAlgorithm.StorageCrc64 => GetHashResult.FromStorageCrc64(options.PrecalculatedChecksum),
                    StorageChecksumAlgorithm.MD5 => GetHashResult.FromMD5(options.PrecalculatedChecksum),
                    _ => throw Errors.InvalidArgument(nameof(options.ChecksumAlgorithm))
                };
                return true;
            }

            result = default;
            return false;
        }

        /// <summary>
        /// Computes the requested hash, if desired.
        /// </summary>
        /// <param name="content">Content to hash.</param>
        /// <param name="algorithmIdentifier">Algorithm to compute the hash with.</param>
        /// <param name="async"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Object containing the requested hash, or no hash, on its algorithm's respective property.</returns>
        /// <exception cref="ArgumentException">
        /// Throws if <paramref name="algorithmIdentifier"/> is invalid.
        /// </exception>
        public static async Task<GetHashResult> GetHashInternal(
            Stream content,
            StorageChecksumAlgorithm algorithmIdentifier,
            bool async,
            CancellationToken cancellationToken)
        {
            return algorithmIdentifier.ResolveAuto() switch
            {
                StorageChecksumAlgorithm.StorageCrc64 => GetHashResult.FromStorageCrc64(await ComputeHashInternal(
                    content,
                    new NonCryptographicHashAlgorithmHasher(StorageCrc64HashAlgorithm.Create()),
                    async,
                    cancellationToken)
                    .ConfigureAwait(false)),
#pragma warning disable CA5351 // Do Not Use Broken Cryptographic Algorithms; MD5 being used for content integrity check, not encryption
                StorageChecksumAlgorithm.MD5 => GetHashResult.FromMD5(await ComputeHashInternal(
                    content,
                    new HashAlgorithmHasher(MD5.Create()),
                    async,
                    cancellationToken)
                    .ConfigureAwait(false)),
#pragma warning restore CA5351 // Do Not Use Broken Cryptographic Algorithms
                _ => throw Errors.InvalidArgument(nameof(algorithmIdentifier))
            };
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
        public static GetHashResult GetHash(BinaryData content, StorageChecksumAlgorithm algorithmIdentifier)
        {
            byte[] computeCrc(StorageCrc64HashAlgorithm nonCryptographicHashAlgorithm)
            {
                nonCryptographicHashAlgorithm.Append(content.ToMemory().Span);
                return nonCryptographicHashAlgorithm.GetCurrentHash();
            }

            return algorithmIdentifier.ResolveAuto() switch
            {
                StorageChecksumAlgorithm.StorageCrc64 => GetHashResult.FromStorageCrc64(
                    computeCrc(StorageCrc64HashAlgorithm.Create())),
#pragma warning disable CA5351 // Do Not Use Broken Cryptographic Algorithms; MD5 being used for content integrity check, not encryption
                StorageChecksumAlgorithm.MD5 => GetHashResult.FromMD5(
                    // this is not in place but MD5 doesn't give a Span API in net standard
                    MD5.Create().ComputeHash(content.ToArray())),
#pragma warning restore CA5351 // Do Not Use Broken Cryptographic Algorithms
                _ => throw Errors.InvalidArgument(nameof(algorithmIdentifier))
            };
        }

        public delegate int GetFinalStreamHash(Span<byte> destination);

        public static (Stream Stream, GetFinalStreamHash GetCurrentStreamHash, int HashSize, IDisposable Disposable) SetupChecksumCalculatingReadStream(
            Stream stream, StorageChecksumAlgorithm algorithmIdentifier)
        {
            IHasher hasher = GetHasher(algorithmIdentifier);
            return (
                ChecksumCalculatingStream.GetReadStream(stream, hasher.AppendHash),
                hasher.GetFinalHash,
                hasher.HashSizeInBytes,
                hasher
            );
        }

        private static IHasher GetHasher(StorageChecksumAlgorithm algorithmIdentifier)
            => algorithmIdentifier.ResolveAuto() switch
            {
                StorageChecksumAlgorithm.StorageCrc64 => new NonCryptographicHashAlgorithmHasher(StorageCrc64HashAlgorithm.Create()),
#pragma warning disable CA5351 // Do Not Use Broken Cryptographic Algorithms; MD5 being used for content integrity check, not encryption
                StorageChecksumAlgorithm.MD5 => new HashAlgorithmHasher(MD5.Create()),
#pragma warning restore CA5351 // Do Not Use Broken Cryptographic Algorithms
                _ => throw Errors.InvalidArgument(nameof(algorithmIdentifier))
            };

        /// <summary>
        /// Compute hash on a stream and reset stream to original position.
        /// </summary>
        /// <param name="content">Seekable stream to compute on.</param>
        /// <param name="hasher">IHasher to compute with.</param>
        /// <param name="async"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private static async Task<byte[]> ComputeHashInternal(
            Stream content,
            IHasher hasher,
            bool async,
            CancellationToken cancellationToken)
        {
            long startPosition = content.Position;
            byte[] hash = await hasher.ComputeHashInternal(content, async, cancellationToken).ConfigureAwait(false);
            content.Position = startPosition;
            return hash;
        }

        public static IHasher GetHasherFromAlgorithmId(StorageChecksumAlgorithm algorithm)
        {
            return algorithm.ResolveAuto() switch
            {
                StorageChecksumAlgorithm.None => null,
                StorageChecksumAlgorithm.MD5 => new HashAlgorithmHasher(MD5.Create()),
                StorageChecksumAlgorithm.StorageCrc64
                    => new NonCryptographicHashAlgorithmHasher(StorageCrc64HashAlgorithm.Create()),
                _ => throw Errors.InvalidArgument(nameof(algorithm))
            };
        }

        public static (ReadOnlyMemory<byte> Checksum, StorageChecksumAlgorithm Algorithm) GetResponseChecksumOrDefault(Response response)
        {
            if (response.Headers.TryGetValue("x-ms-content-crc64", out byte[] crc))
            {
                return (crc, StorageChecksumAlgorithm.StorageCrc64);
            }
            if (response.Headers.TryGetValue("Content-MD5", out byte[] md5))
            {
                return (md5, StorageChecksumAlgorithm.MD5);
            }

            return (ReadOnlyMemory<byte>.Empty, StorageChecksumAlgorithm.None);
        }
    }
}
