// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.IO;
using System.IO.Hashing;
using System.Threading.Tasks;
using System.Threading;

namespace Azure.Storage
{
    /// <summary>
    /// HashAlgorithm wrapper for IHasher interface.
    /// </summary>
    internal class NonCryptographicHashAlgorithmHasher : IHasher
    {
        private const int _streamBufferSize = 4 * Constants.MB;

        private readonly NonCryptographicHashAlgorithm _nonCryptographicHashAlgorithm;

        public int HashSizeInBytes => _nonCryptographicHashAlgorithm.HashLengthInBytes;

        public NonCryptographicHashAlgorithmHasher(NonCryptographicHashAlgorithm nonCryptographicHashAlgorithm)
        {
            _nonCryptographicHashAlgorithm = nonCryptographicHashAlgorithm;
        }

        public async Task<byte[]> ComputeHashInternal(
            Stream stream,
            bool async,
            CancellationToken cancellationToken)
        {
            if (stream is null)
                throw new ArgumentNullException(nameof(stream));

            if (async)
            {
                await _nonCryptographicHashAlgorithm.AppendAsync(stream, cancellationToken)
                    .ConfigureAwait(false);
            }
            else
            {
                _nonCryptographicHashAlgorithm.Append(stream);
            }

            return _nonCryptographicHashAlgorithm.GetCurrentHash();
        }

        public void AppendHash(ReadOnlySpan<byte> content)
        {
            _nonCryptographicHashAlgorithm.Append(content);
        }

        public int GetFinalHash(Span<byte> hashDestination)
        {
            return _nonCryptographicHashAlgorithm.GetCurrentHash(hashDestination);
        }

        public void Dispose()
        {
            // NonCryptographicHashAlgorithm is not disposable
        }
    }
}
