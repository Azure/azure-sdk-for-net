// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO.Hashing;

namespace Azure.Storage
{
    /// <summary>
    /// Azure Storage CRC-64 implementation.
    /// </summary>
    public class StorageCrc64HashAlgorithm : NonCryptographicHashAlgorithm
    {
        private ulong _uCRC;
        private const int _hashSizeBytes = 8;

        private StorageCrc64HashAlgorithm(ulong uCrc)
            : base(_hashSizeBytes)
        {
            _uCRC = uCrc;
        }

        /// <summary>
        /// Creates a new instance of <see cref="StorageCrc64HashAlgorithm"/>.
        /// </summary>
        /// <returns></returns>
        public static StorageCrc64HashAlgorithm Create()
        {
            return new StorageCrc64HashAlgorithm(0UL);
        }

        /// <inheritdoc/>
        public override void Reset()
        {
            _uCRC = 0;
        }

        /// <inheritdoc/>
        public override void Append(ReadOnlySpan<byte> source)
        {
            _uCRC = StorageCrc64Calculator.ComputeSlicedSafe(source, _uCRC);
        }

        /// <inheritdoc/>
        protected override void GetCurrentHashCore(Span<byte> destination)
            => BitConverter.GetBytes(_uCRC).CopyTo(destination);
    }
}
