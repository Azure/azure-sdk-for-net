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
        if (ReferenceEquals(x, y)) return true;
        if (x is null || y is null) return false;
        return Equals(new JsonPathReader(x), new JsonPathReader(y));
    }

    public int GetHashCode(byte[] obj)
        => GetHashCode(new JsonPathReader(obj));

    public byte[] Create(ReadOnlySpan<byte> alternate)
    => alternate.ToArray();

    public bool Equals(ReadOnlySpan<byte> alternate, byte[] other)
        => Equals(new JsonPathReader(alternate), new JsonPathReader(other));

    public int GetHashCode(ReadOnlySpan<byte> alternate)
         => GetHashCode(new JsonPathReader(alternate));

    public static int GetHashCode(JsonPathReader obj)
    {
#if NET8_0_OR_GREATER
        var hash = new HashCode();
        while (obj.Read())
        {
            if (!obj.Current.ValueSpan.IsEmpty)
                hash.AddBytes(obj.Current.ValueSpan);
        }
        return hash.ToHashCode();
#else
        unchecked
        {
            int hash = 17;
            while (obj.Read())
            {
                var span = obj.Current.ValueSpan;
                if (!span.IsEmpty)
                {
                    for (int i = 0; i < span.Length; i++)
                    {
                        hash = hash * 31 + span[i];
                    }
                }
            }
            return hash;
        }
#endif
    }

    public static bool Equals(JsonPathReader x, JsonPathReader y)
    {
        while (x.Read() && y.Read())
        {
            if (!x.Current.ValueSpan.SequenceEqual(y.Current.ValueSpan))
                return false;
        }
        return !x.Read() && !y.Read();
    }
}
