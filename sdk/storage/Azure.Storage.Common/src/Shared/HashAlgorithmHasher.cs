// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Storage
{
    /// <summary>
    /// HashAlgorithm wrapper for IHasher interface
    /// </summary>
    internal class HashAlgorithmHasher : IHasher
    {
        private readonly HashAlgorithm _hashAlgorithm;

        public int HashSizeInBytes => BitsToBytes(_hashAlgorithm.HashSize);

        public HashAlgorithmHasher(HashAlgorithm hashAlgorithm)
        {
            _hashAlgorithm = hashAlgorithm;
        }

        public async Task<byte[]> ComputeHashInternal(
            Stream stream,
            bool async,
            CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(stream, nameof(stream));

#if NET5_0_OR_GREATER
            return async
                ? await _hashAlgorithm.ComputeHashAsync(stream, cancellationToken)
                    .ConfigureAwait(false)
                : _hashAlgorithm.ComputeHash(stream);
#else
            await ChecksumCalculatingStream.GetReadStream(stream, AppendHash)
                .CopyToInternal(Stream.Null, async, cancellationToken)
                .ConfigureAwait(false);

            var checksum = new byte[HashSizeInBytes];
            GetFinalHash(checksum);
            return checksum;
#endif
        }

        public void AppendHash(ReadOnlySpan<byte> content)
        {
            _hashAlgorithm.TransformBlock(content.ToArray(), 0, content.Length, null, 0);
        }

        public int GetFinalHash(Span<byte> hashDestination)
        {
            _hashAlgorithm.TransformFinalBlock(new byte[0], 0, 0);
            _hashAlgorithm.Hash.CopyTo(hashDestination);
            return _hashAlgorithm.Hash.Length;
        }

        public void Dispose()
        {
            _hashAlgorithm.Dispose();
        }

        private static int BitsToBytes(int bits) => bits >> 3;
    }
}
