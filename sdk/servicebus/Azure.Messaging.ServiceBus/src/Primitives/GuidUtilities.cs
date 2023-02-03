// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers.Binary;
using System.Runtime.InteropServices;

namespace Azure.Messaging.ServiceBus.Primitives;

internal static class GuidUtilities
{
    /// <summary>
    /// The size, in bytes, to use for extracting the delivery tag bytes into <see cref="Guid"/>.
    /// </summary>
    private const int GuidSizeInBytes = 16;

    public static Guid ParseGuidBytes(ReadOnlyMemory<byte> bytes)
    {
        if (bytes.Length != GuidSizeInBytes)
        {
            ThrowArgumentException();
        }

        ReadOnlySpan<byte> bytesSpan = bytes.Span;
        if (BitConverter.IsLittleEndian)
        {
            return MemoryMarshal.Read<Guid>(bytesSpan);
        }

        // slower path for BigEndian:
        byte k = bytesSpan[15];  // hoist bounds checks
        int a = BinaryPrimitives.ReadInt32LittleEndian(bytesSpan);
        short b = BinaryPrimitives.ReadInt16LittleEndian(bytesSpan.Slice(4));
        short c = BinaryPrimitives.ReadInt16LittleEndian(bytesSpan.Slice(6));
        byte d = bytesSpan[8];
        byte e = bytesSpan[9];
        byte f = bytesSpan[10];
        byte g = bytesSpan[11];
        byte h = bytesSpan[12];
        byte i = bytesSpan[13];
        byte j = bytesSpan[14];

        return new Guid(a, b, c, d, e, f, g, h, i, j, k);

        static void ThrowArgumentException()
        {
            throw new ArgumentException("TBD", nameof(bytes));
        }
    }

    public static void WriteGuidBytes(Guid guid, byte[] buffer)
    {
        if (buffer.Length != GuidSizeInBytes)
        {
            ThrowArgumentException();
        }

        if (BitConverter.IsLittleEndian)
        {
            MemoryMarshal.Write(buffer, ref guid);
            return;
        }

        guid.ToByteArray().AsSpan().CopyTo(buffer);

        static void ThrowArgumentException()
        {
            throw new ArgumentException("TBD", nameof(buffer));
        }
    }
}
