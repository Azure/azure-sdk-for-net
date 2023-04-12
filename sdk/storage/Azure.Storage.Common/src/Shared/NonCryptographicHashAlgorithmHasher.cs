// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.IO;
using System.IO.Hashing;

namespace Azure.Storage
{
    /// <summary>
    /// HashAlgorithm wrapper for IHasher interface.
    /// </summary>
    internal class NonCryptographicHashAlgorithmHasher : IHasher
    {
        private const int _streamBufferSize = 4 * Constants.MB;

        private readonly NonCryptographicHashAlgorithm _nonCryptographicHashAlgorithm;

        public int HashSize => _nonCryptographicHashAlgorithm.HashLengthInBytes;

        public NonCryptographicHashAlgorithmHasher(NonCryptographicHashAlgorithm nonCryptographicHashAlgorithm)
        {
            _nonCryptographicHashAlgorithm = nonCryptographicHashAlgorithm;
        }

        public byte[] ComputeHash(Stream stream)
        {
            if (stream is null)
                throw new ArgumentNullException(nameof(stream));

            byte[] buffer = ArrayPool<byte>.Shared.Rent(_streamBufferSize);

            while (true)
            {
                int read = stream.Read(buffer, 0, buffer.Length);

                if (read == 0)
                {
                    break;
                }

                _nonCryptographicHashAlgorithm.Append(new ReadOnlySpan<byte>(buffer, 0, read));
            }

            ArrayPool<byte>.Shared.Return(buffer);

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
