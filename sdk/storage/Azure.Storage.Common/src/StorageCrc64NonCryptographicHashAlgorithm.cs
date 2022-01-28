// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage
{
    /// <summary>
    /// Azure Storage CRC-64 implementation.
    /// </summary>
    public class StorageCrc64NonCryptographicHashAlgorithm
    {
        private ulong _uCRC;

        private StorageCrc64NonCryptographicHashAlgorithm(ulong uCrc)
        {
            _uCRC = uCrc;
        }

        /// <summary>
        /// Creates a new instance of <see cref="StorageCrc64NonCryptographicHashAlgorithm"/>.
        /// </summary>
        /// <returns></returns>
        public static StorageCrc64NonCryptographicHashAlgorithm Create()
        {
            return new StorageCrc64NonCryptographicHashAlgorithm(0UL);
        }

        /// <summary>
        /// Resets CRC computation.
        /// </summary>
        // Future implementation of abstract class NonCryptographicHashAlgorithm.
        public void Reset()
        {
            _uCRC = 0;
        }

        /// <summary>
        /// Appends the given data to CRC computation.
        /// </summary>
        /// <param name="source">Data to compute on.</param>
        // Future implementation of abstract class NonCryptographicHashAlgorithm.
        public void Append(ReadOnlySpan<byte> source)
        {
            _uCRC = StorageCrc64Calculator.ComputeSlicedSafe(source, _uCRC);
        }

        /// <summary>
        /// Gets current CRC computation.
        /// </summary>
        /// <param name="destination">Span to write the current CRC to.</param>
        // Future implementation of abstract class NonCryptographicHashAlgorithm.
        protected void GetCurrentHashCore(Span<byte> destination)
            => BitConverter.GetBytes(_uCRC).CopyTo(destination);

        /// <summary>
        /// Gets the current computed hash value without modifying accumulated state.
        /// </summary>
        /// <returns>Byte array of the current hash.</returns>
        // Clone of non-virtual method in future parent class NonCryptographicHashAlgorithm.
        public byte[] GetCurrentHash()
        {
            var result = new byte[8];
            GetCurrentHashCore(new Span<byte>(result));
            return result;
        }
    }
}
