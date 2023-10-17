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

    public static bool TryParseGuidBytes(ReadOnlySpan<byte> bytes, out Guid guid)
    {
        if (bytes.Length != GuidSizeInBytes)
        {
            guid = default;
            return false;
        }

        if (BitConverter.IsLittleEndian)
        {
            guid = MemoryMarshal.Read<Guid>(bytes);
            return true;
        }

        // copied from https://github.com/dotnet/runtime/blob/9129083c2fc6ef32479168f0555875b54aee4dfb/src/libraries/System.Private.CoreLib/src/System/Guid.cs#L49
        // slower path for BigEndian:
        byte k = bytes[15];  // hoist bounds checks
        int a = BinaryPrimitives.ReadInt32LittleEndian(bytes);
        short b = BinaryPrimitives.ReadInt16LittleEndian(bytes.Slice(4));
        short c = BinaryPrimitives.ReadInt16LittleEndian(bytes.Slice(6));
        byte d = bytes[8];
        byte e = bytes[9];
        byte f = bytes[10];
        byte g = bytes[11];
        byte h = bytes[12];
        byte i = bytes[13];
        byte j = bytes[14];

        guid = new Guid(a, b, c, d, e, f, g, h, i, j, k);
        return true;
    }

    public static void WriteGuidToBuffer(Guid guid, Span<byte> buffer)
    {
        AssertBufferSize(buffer);

        // Based on https://github.com/dotnet/runtime/blob/9129083c2fc6ef32479168f0555875b54aee4dfb/src/libraries/System.Private.CoreLib/src/System/Guid.cs#L836

        if (BitConverter.IsLittleEndian)
        {
            MemoryMarshal.Write(buffer, ref guid);
            return;
        }

        GuidData data = Unsafe.As<Guid, GuidData>(ref guid);

        buffer[15] = data.K; // hoist bounds checks
        BinaryPrimitives.WriteInt32LittleEndian(buffer, data.A);
        BinaryPrimitives.WriteInt16LittleEndian(buffer.Slice(4), data.B);
        BinaryPrimitives.WriteInt16LittleEndian(buffer.Slice(6), data.C);
        buffer[8] = data.D;
        buffer[9] = data.E;
        buffer[10] = data.F;
        buffer[11] = data.G;
        buffer[12] = data.H;
        buffer[13] = data.I;
        buffer[14] = data.J;
    }

    private static void AssertBufferSize(Span<byte> buffer)
    {
        if (buffer.Length != GuidSizeInBytes)
        {
            throw new ArgumentException($"The length of the supplied buffer must be {GuidSizeInBytes}.", nameof(buffer));
        }
    }

    // This struct has the fields layed out to be GUID-like in order to read the GUID fields
    // to efficiently write them into memory without having to deal with endianness
    // Do not rename or reorder the fields.
    private readonly struct GuidData
    {
        public readonly int A;
        public readonly short B;
        public readonly short C;
        public readonly byte D;
        public readonly byte E;
        public readonly byte F;
        public readonly byte G;
        public readonly byte H;
        public readonly byte I;
        public readonly byte J;
        public readonly byte K;

        // Creates a new GUID like struct initialized to the value represented by the
        // arguments.  The bytes are specified like this to avoid endianness issues.
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
