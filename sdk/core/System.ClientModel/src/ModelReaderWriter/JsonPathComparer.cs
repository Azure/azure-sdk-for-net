// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Primitives;

internal class JsonPathComparer : IEqualityComparer<byte[]>
#if NET9_0_OR_GREATER
    , IAlternateEqualityComparer<ReadOnlySpan<byte>, byte[]>
#endif
{
    internal static readonly JsonPathComparer Default = new();

    public bool Equals(byte[]? x, byte[]? y)
    {
        if (ReferenceEquals(x, y))
            return true;
        if (x is null || y is null)
            return false;
        return x.AsSpan().SequenceEqual(y.AsSpan());
    }

    public int GetHashCode(byte[] obj)
        => GetHashCode(obj.AsSpan());

    public bool Equals(ReadOnlySpan<byte> alternate, byte[] other)
    {
        if (other is null)
            return false;

        return alternate.SequenceEqual(other.AsSpan());
    }

    public int GetHashCode(ReadOnlySpan<byte> alternate)
    {
#if NET8_0_OR_GREATER
            var hash = new HashCode();
            hash.AddBytes(alternate);
            return hash.ToHashCode();
#else
        unchecked
        {
            int hash = 17;
            for (int i = 0; i < alternate.Length; i++)
            {
                hash = hash * 31 + alternate[i];
            }
            return hash;
        }
#endif
    }

    public byte[] Create(ReadOnlySpan<byte> alternate)
        => alternate.ToArray();

    public void Normalize(ReadOnlySpan<byte> jsonPath, ref Span<byte> buffer, out int bytesWritten)
    {
        ReadOnlySpan<byte> localPath = jsonPath;
        bytesWritten = 0;
        int length = jsonPath.Length;
        int block = 0;
        bool inBracket = false;
        bool needEscapedDot = false;
        for (int i = 0; i < length; i++)
        {
            byte current = jsonPath[i];
            if (current == (byte)'[' && i + 1 < length && (jsonPath[i + 1] == (byte)'\'' || jsonPath[i + 1] == (byte)'"'))
            {
                localPath.Slice(0, block).CopyTo(buffer.Slice(bytesWritten));
                localPath = localPath.Slice(block + 2);
                bytesWritten += block;
                block = 0;
                buffer[bytesWritten++] = (byte)'.';
                i++;
                inBracket = true;
            }
            else if (current == (byte)']' && i - 1 >= 0 && (jsonPath[i - 1] == (byte)'\'' || jsonPath[i - 1] == (byte)'"'))
            {
                block--;
                localPath.Slice(0, block).CopyTo(buffer.Slice(bytesWritten));
                localPath = localPath.Slice(block + 2);
                bytesWritten += block;
                block = 0;
                if (needEscapedDot)
                {
                    buffer[bytesWritten++] = (byte)'\'';
                    buffer[bytesWritten++] = (byte)']';
                    needEscapedDot = false;
                }
                inBracket = false;
            }
            else if (current == (byte)'.' && inBracket)
            {
                // need to keep the ['(.+)'] format
                buffer[bytesWritten - 1] = (byte)'[';
                buffer[bytesWritten++] = (byte)'\'';
                needEscapedDot = true;
                block++;
            }
            else
            {
                block++;
            }
        }

        if (block > 0)
        {
            localPath.Slice(0, block).CopyTo(buffer.Slice(bytesWritten));
            bytesWritten += block;
        }
    }

    public int GetNormalizedHashCode(ReadOnlySpan<byte> jsonPath)
    {
        Span<byte> buffer = stackalloc byte[jsonPath.Length];
        Normalize(jsonPath, ref buffer, out int bytesWritten);
        buffer = buffer.Slice(0, bytesWritten);
#if NET8_0_OR_GREATER
        var hash = new HashCode();
        hash.AddBytes(buffer);
        return hash.ToHashCode();
#else
        unchecked
        {
            int hash = 17;
            for (int i = 0; i < buffer.Length; i++)
            {
                hash = hash * 31 + buffer[i];
            }
            return hash;
        }
#endif
    }

    public bool NormalizedEquals(ReadOnlySpan<byte> x, ReadOnlySpan<byte> y)
    {
        // fast path if they are already nomrlaized
        if (x.SequenceEqual(y))
            return true;

        Span<byte> bufferX = stackalloc byte[x.Length];
        Span<byte> bufferY = stackalloc byte[y.Length];
        Normalize(x, ref bufferX, out int bytesWrittenX);
        Normalize(y, ref bufferY, out int bytesWrittenY);
        if (bytesWrittenX != bytesWrittenY)
            return false;
        return bufferX.Slice(0, bytesWrittenX).SequenceEqual(bufferY.Slice(0, bytesWrittenY));
    }
}
