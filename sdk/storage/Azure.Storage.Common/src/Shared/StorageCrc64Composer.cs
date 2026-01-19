// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Storage
{
    /// <summary>
    /// Helper code for composing crc64 values together.
    /// </summary>
    internal static class StorageCrc64Composer
    {
        public static byte[] Compose(params (byte[] Crc64, long OriginalDataLength)[] partitions)
            => Compose(partitions.AsEnumerable());

        public static byte[] Compose(IEnumerable<(byte[] Crc64, long OriginalDataLength)> partitions)
        {
            ulong result = Compose(partitions.Select(tup => (BitConverter.ToUInt64(tup.Crc64, 0), tup.OriginalDataLength)));
            return BitConverter.GetBytes(result);
        }

        public static byte[] Compose(params (ReadOnlyMemory<byte> Crc64, long OriginalDataLength)[] partitions)
            => Compose(partitions.AsEnumerable());

        public static byte[] Compose(IEnumerable<(ReadOnlyMemory<byte> Crc64, long OriginalDataLength)> partitions)
        {
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER
            ulong result = Compose(partitions.Select(tup => (BitConverter.ToUInt64(tup.Crc64.Span), tup.OriginalDataLength)));
#else
            ulong result = Compose(partitions.Select(tup => (System.BitConverter.ToUInt64(tup.Crc64.ToArray(), 0), tup.OriginalDataLength)));
#endif
            return BitConverter.GetBytes(result);
        }

        public static byte[] Compose(
            ReadOnlySpan<byte> leftCrc64, long leftOriginalDataLength,
            ReadOnlySpan<byte> rightCrc64, long rightOriginalDataLength)
        {
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER
            ulong result = Compose(
                (BitConverter.ToUInt64(leftCrc64), leftOriginalDataLength),
                (BitConverter.ToUInt64(rightCrc64), rightOriginalDataLength));
#else
            ulong result = Compose(
                (BitConverter.ToUInt64(leftCrc64.ToArray(), 0), leftOriginalDataLength),
                (BitConverter.ToUInt64(rightCrc64.ToArray(), 0), rightOriginalDataLength));
#endif
            return BitConverter.GetBytes(result);
        }

        public static ulong Compose(params (ulong Crc64, long OriginalDataLength)[] partitions)
            => Compose(partitions.AsEnumerable());

        public static ulong Compose(IEnumerable<(ulong Crc64, long OriginalDataLength)> partitions)
        {
            ulong composedCrc = 0;
            long composedDataLength = 0;
            foreach ((ulong crc64, long originalDataLength) in partitions)
            {
                composedCrc = StorageCrc64Calculator.Concatenate(
                    uInitialCrcAB: 0,
                    uInitialCrcA: 0,
                    uFinalCrcA: composedCrc,
                    uSizeA: (ulong) composedDataLength,
                    uInitialCrcB: 0,
                    uFinalCrcB: crc64,
                    uSizeB: (ulong)originalDataLength);
                composedDataLength += originalDataLength;
            }
            return composedCrc;
        }
    }
}
