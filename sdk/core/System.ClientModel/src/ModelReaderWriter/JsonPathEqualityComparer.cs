// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

namespace System.ClientModel.Primitives;

internal static class JsonPathEqualityComparer
{
    public static bool Equals(byte[] x, byte[] y)
        => Equals(x.AsSpan(), y.AsSpan());

    public static bool Equals(ReadOnlySpan<byte> x, byte[] y)
        => Equals(x, y.AsSpan());

    public static bool Equals(ReadOnlySpan<byte> x, ReadOnlySpan<byte> y)
        => Equals(new JsonPathReader(x), new JsonPathReader(y));

    public static bool Equals(JsonPathReader x, JsonPathReader y)
    {
        while (x.Read() && y.Read())
        {
            if (!x.Current.ValueSpan.SequenceEqual(y.Current.ValueSpan))
                return false;
        }
        return !x.Read() && !y.Read();
    }

    public static int GetHashCode([DisallowNull] byte[] obj) => GetHashCode(obj.AsSpan());

    public static int GetHashCode([DisallowNull] ReadOnlySpan<byte> obj) => GetHashCode(new JsonPathReader(obj));

    public static int GetHashCode([DisallowNull] JsonPathReader obj)
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
}
