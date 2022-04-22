// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.IO;

namespace Azure.Storage
{
    /// <summary>
    /// HashAlgorithm wrapper for IHasher interface.
    /// </summary>
    internal class NonCryptographicHashAlgorithmHasher : IHasher
    {
        private const int _streamBufferSize = 4 * Constants.MB;

        private readonly StorageCrc64NonCryptographicHashAlgorithm _nonCryptpgraphicHashAlgorithm;

        public NonCryptographicHashAlgorithmHasher(StorageCrc64NonCryptographicHashAlgorithm nonCryptographicHashAlgorithm)
        {
            _nonCryptpgraphicHashAlgorithm = nonCryptographicHashAlgorithm;
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

                _nonCryptpgraphicHashAlgorithm.Append(new ReadOnlySpan<byte>(buffer, 0, read));
            }

            ArrayPool<byte>.Shared.Return(buffer);

            return _nonCryptpgraphicHashAlgorithm.GetCurrentHash();
        }
    }
}
