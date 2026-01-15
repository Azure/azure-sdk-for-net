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
        {
            return true;
        }
        if (x is null || y is null)
        {
            return false;
        }
        return x.AsSpan().SequenceEqual(y.AsSpan());
    }

    public int GetHashCode(byte[] obj)
        => GetHashCode(obj.AsSpan());

    public bool Equals(ReadOnlySpan<byte> alternate, byte[] other)
    {
        if (other is null)
        {
            return false;
        }

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

    /// <summary>
    /// There are multiple ways to represent a JSON path. This method normalizes the JSON path to a canonical form that can be used for comparison.
    /// As an example $.x is the same as $['x'] and also the same as $["x"]. This method will convert all of these to $.x.
    /// In the event that the property name contains a dot that single property will use ['x.y'] format to represent the property name with a dot in it.
    /// </summary>
    /// <param name="jsonPath">The json path to convert.</param>
    /// <param name="buffer">Buffer to write the normalized path into.</param>
    /// <param name="bytesWritten">The number of bytes written into <paramref name="buffer"/>.</param>
    public void Normalize(ReadOnlySpan<byte> jsonPath, Span<byte> buffer, out int bytesWritten)
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
            else if (current == (byte)'.' && inBracket && !needEscapedDot)
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
        Normalize(jsonPath, buffer, out int bytesWritten);
        buffer = buffer.Slice(0, bytesWritten);
        return GetHashCode(buffer);
    }

    public bool NormalizedEquals(ReadOnlySpan<byte> x, ReadOnlySpan<byte> y)
    {
        // fast path if they are already nomrlaized
        if (x.SequenceEqual(y))
        {
            return true;
        }

        Span<byte> bufferX = stackalloc byte[x.Length];
        Span<byte> bufferY = stackalloc byte[y.Length];
        Normalize(x, bufferX, out int bytesWrittenX);
        Normalize(y, bufferY, out int bytesWrittenY);
        if (bytesWrittenX != bytesWrittenY)
        {
            return false;
        }
        return bufferX.Slice(0, bytesWrittenX).SequenceEqual(bufferY.Slice(0, bytesWrittenY));
    }
}
