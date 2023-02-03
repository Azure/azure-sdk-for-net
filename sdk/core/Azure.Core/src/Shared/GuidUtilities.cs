// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers.Binary;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Azure.Core.Shared;

/// <summary>
/// The purpose of this class is to provide an allocation free way to parse and write Guids on .NET Standard 2.0, taking into account
/// endianness.
/// </summary>
internal static class GuidUtilities
{
    private const int GuidSizeInBytes = 16;

    public static Guid ParseGuidBytes(ReadOnlyMemory<byte> bytes)
    {
        if (bytes.Length != GuidSizeInBytes)
        {
            throw new ArgumentException("The length of the supplied bytes must be 16.", nameof(bytes));
        }

        ReadOnlySpan<byte> bytesSpan = bytes.Span;
        if (BitConverter.IsLittleEndian)
        {
            return MemoryMarshal.Read<Guid>(bytesSpan);
        }

        // copied from https://github.com/dotnet/runtime/blob/9129083c2fc6ef32479168f0555875b54aee4dfb/src/libraries/System.Private.CoreLib/src/System/Guid.cs#L49
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
    }

    public static void WriteGuidBytes(Guid guid, byte[] buffer)
    {
        if (buffer.Length != GuidSizeInBytes)
        {
            throw new ArgumentException("The length of the supplied buffer must be 16.", nameof(buffer));
        }

        // Copied from https://github.com/dotnet/runtime/blob/9129083c2fc6ef32479168f0555875b54aee4dfb/src/libraries/System.Private.CoreLib/src/System/Guid.cs#L836

        if (BitConverter.IsLittleEndian)
        {
            MemoryMarshal.Write(buffer, ref guid);
            return;
        }

        GuidData data = Unsafe.As<Guid, GuidData>(ref guid);

        Span<byte> bytesSpan = buffer.AsSpan();
        buffer[15] = data.K; // hoist bounds checks
        BinaryPrimitives.WriteInt32LittleEndian(buffer, data.A);
        BinaryPrimitives.WriteInt16LittleEndian(bytesSpan.Slice(4), data.B);
        BinaryPrimitives.WriteInt16LittleEndian(bytesSpan.Slice(6), data.C);
        buffer[8] = data.D;
        buffer[9] = data.E;
        buffer[10] = data.F;
        buffer[11] = data.G;
        buffer[12] = data.H;
        buffer[13] = data.I;
        buffer[14] = data.J;
    }

    private readonly struct GuidData
    {
        public readonly int A;   // Do not rename (binary serialization)
        public readonly short B; // Do not rename (binary serialization)
        public readonly short C; // Do not rename (binary serialization)
        public readonly byte D;  // Do not rename (binary serialization)
        public readonly byte E;  // Do not rename (binary serialization)
        public readonly byte F;  // Do not rename (binary serialization)
        public readonly byte G;  // Do not rename (binary serialization)
        public readonly byte H;  // Do not rename (binary serialization)
        public readonly byte I;  // Do not rename (binary serialization)
        public readonly byte J;  // Do not rename (binary serialization)
        public readonly byte K;  // Do not rename (binary serialization)

        public GuidData(int a, short b, short c, byte d, byte e, byte f, byte g, byte h, byte i, byte j, byte k)
        {
            A = a;
            B = b;
            C = c;
            D = d;
            E = e;
            F = f;
            G = g;
            H = h;
            I = i;
            J = j;
            K = k;
        }
    }
}
