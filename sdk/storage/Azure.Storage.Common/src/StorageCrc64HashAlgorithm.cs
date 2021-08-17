// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography;

namespace Azure.Storage
{
    /// <summary>
    /// Azure Storage CRC-64 implementation.
    /// </summary>
    public class StorageCrc64HashAlgorithm : HashAlgorithm
    {
        private ulong _uCRC;

        private StorageCrc64HashAlgorithm(ulong uCrc)
        {
            _uCRC = uCrc;
        }

        /// <summary>
        /// Creates a new instance of <see cref="StorageCrc64HashAlgorithm"/>.
        /// </summary>
        /// <returns></returns>
        public static new StorageCrc64HashAlgorithm Create()
        {
            return new StorageCrc64HashAlgorithm(0);
        }

        /// <inheritdoc/>
        public override void Initialize()
        {
            _uCRC = 0;
        }

        /// <inheritdoc/>
        protected override void HashCore(byte[] array, int ibStart, int cbSize)
        {
            if (ibStart != 0)
            {
                throw new NotImplementedException("non-zero offset for Crc64Wrapper update not supported");
            }
            if (cbSize > 0)
            {
                _uCRC = StorageCrc64Calculator.ComputeSlicedSafe(array, cbSize, _uCRC);
            }
        }

        /// <inheritdoc/>
        protected override byte[] HashFinal()
            => BitConverter.GetBytes(_uCRC);
        }
}
