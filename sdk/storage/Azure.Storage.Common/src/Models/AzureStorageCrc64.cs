// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography;

namespace Azure.Storage.Models
{
    /// <summary>
    /// Azure Storage CRC-64 implementation.
    /// </summary>
    public class AzureStorageCrc64 : HashAlgorithm
    {
        private ulong _uCRC;

        private AzureStorageCrc64(ulong uCrc)
        {
            _uCRC = uCrc;
        }

        /// <summary>
        /// Creates a new instance of <see cref="AzureStorageCrc64"/>.
        /// </summary>
        /// <returns></returns>
        public static new AzureStorageCrc64 Create()
        {
            return new AzureStorageCrc64(0);
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
                _uCRC = AzureStorageCrc64Calculator.ComputeSlicedSafe(array, cbSize, _uCRC);
            }
        }

        /// <inheritdoc/>
        protected override byte[] HashFinal()
            => BitConverter.GetBytes(_uCRC);
        }
}
