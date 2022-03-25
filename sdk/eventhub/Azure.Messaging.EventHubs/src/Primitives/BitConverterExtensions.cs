// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Azure.Messaging.EventHubs.Primitives
{
    /// <summary>
    /// BitConverter extensions used to provide a compatibility shim for BitConverter methods that are missing in .NET Standard 2.0.
    /// </summary>
    internal static class BitConverterExtensions
    {
        /// <summary>
        /// Converts a read-only byte span into a 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A read-only span containing the bytes to convert.</param>
        /// <returns>A 32-bit unsigned integer representing the converted bytes.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The length of <paramref name="value"/> is less than 4.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint ToUInt32(ReadOnlySpan<byte> value)
        {
            if (value.Length < sizeof(uint))
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }

            return Unsafe.ReadUnaligned<uint>(ref MemoryMarshal.GetReference(value));
        }
    }
}
