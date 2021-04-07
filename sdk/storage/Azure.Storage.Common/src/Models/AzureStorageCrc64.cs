// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography;

namespace Azure.Storage.Models
{
    /// <summary>
    /// <see cref="HashAlgorithm"/> for Azure Storage CRC-64 with custom polynomial.
    /// </summary>
    public class AzureStorageCrc64 : HashAlgorithm
    {
        private ulong _crc;

        /// <inheritdoc/>
        public override int HashSize => 64;

        /// <inheritdoc/>
        public override void Initialize()
        {
            _crc = 0;
        }

        /// <inheritdoc/>
        protected override void HashCore(byte[] array, int ibStart, int cbSize)
        {
            if (ibStart != 0)
            {
                throw new NotImplementedException($"Non-zero offset for {nameof(AzureStorageCrc64)} not supported");
            }
            if (cbSize > 0)
            {
                _crc = AzureStorageCrc64Implementation.ComputeSlicedSafe(array, cbSize, _crc);
            }
        }

        /// <inheritdoc/>
        protected override byte[] HashFinal()
        {
            return BitConverter.GetBytes(_crc);
        }
    }
}
