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
        return new JsonPathReader(x).Equals(new JsonPathReader(y));
    }

    public int GetHashCode(byte[] obj)
        => new JsonPathReader(obj).GetHashCode();

    public byte[] Create(ReadOnlySpan<byte> alternate)
        => alternate.ToArray();

    public bool Equals(ReadOnlySpan<byte> alternate, byte[] other)
        => new JsonPathReader(alternate).Equals(new JsonPathReader(other));

    public int GetHashCode(ReadOnlySpan<byte> alternate)
    {
        JsonPathReader reader = new(alternate);
        return reader.GetHashCode();
    }
}
