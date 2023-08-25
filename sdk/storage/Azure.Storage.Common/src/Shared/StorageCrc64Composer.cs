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
        public static Memory<byte> Compose(params (byte[] Crc64, long OriginalDataLength)[] partitions)
        {
            return Compose(partitions.AsEnumerable());
        }

        public static Memory<byte> Compose(IEnumerable<(byte[] Crc64, long OriginalDataLength)> partitions)
        {
            ulong result = Compose(partitions.Select(tup => (BitConverter.ToUInt64(tup.Crc64, 0), tup.OriginalDataLength)));
            return new Memory<byte>(BitConverter.GetBytes(result));
        }

        public static ulong Compose(IEnumerable<(ulong Crc64, long OriginalDataLength)> partitions)
        {
            ulong composedCrc = 0;
            long composedDataLength = 0;
            foreach (var tup in partitions)
            {
                composedCrc = StorageCrc64Calculator.Concatenate(
                    uInitialCrcAB: 0,
                    uInitialCrcA: 0,
                    uFinalCrcA: composedCrc,
                    uSizeA: (ulong) composedDataLength,
                    uInitialCrcB: 0,
                    uFinalCrcB: tup.Crc64,
                    uSizeB: (ulong)tup.OriginalDataLength);
                composedDataLength += tup.OriginalDataLength;
            }
            return composedCrc;
        }
    }
}
