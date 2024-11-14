// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers.Binary;

namespace Azure.Storage;

internal static class ChecksumExtensions
{
    public static void WriteCrc64(this ulong crc, Span<byte> dest)
        => BinaryPrimitives.WriteUInt64LittleEndian(dest, crc);

    public static bool TryWriteCrc64(this ulong crc, Span<byte> dest)
        => BinaryPrimitives.TryWriteUInt64LittleEndian(dest, crc);

    public static ulong ReadCrc64(this ReadOnlySpan<byte> crc)
        => BinaryPrimitives.ReadUInt64LittleEndian(crc);

    public static bool TryReadCrc64(this ReadOnlySpan<byte> crc, out ulong value)
        => BinaryPrimitives.TryReadUInt64LittleEndian(crc, out value);
}
