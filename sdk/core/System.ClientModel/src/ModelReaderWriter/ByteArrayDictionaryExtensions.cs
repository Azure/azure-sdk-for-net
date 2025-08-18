// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

namespace System.ClientModel.Primitives;

[Experimental("SCM0001")]
internal static class ByteArrayDictionaryExtensions
{
    public static bool TryGetValue(this Dictionary<byte[], JsonPatch.EncodedValue> dictionary, ReadOnlySpan<byte> key, out JsonPatch.EncodedValue value)
    {
        //TODO: consider the loop hole if anyone uses a byte[] as a key it won't get normalized
        Span<byte> normalizedKey = stackalloc byte[key.Length];
        JsonPathComparer.Default.Normalize(key, ref normalizedKey, out int bytesWritten);
        normalizedKey = normalizedKey.Slice(0, bytesWritten);
#if NET9_0_OR_GREATER
        return dictionary.GetAlternateLookup<ReadOnlySpan<byte>>().TryGetValue(normalizedKey, out value);
#else
        return dictionary.TryGetValue(normalizedKey.ToArray(), out value);
#endif
    }

    public static bool ContainsKey(this Dictionary<byte[], JsonPatch.EncodedValue> dictionary, ReadOnlySpan<byte> key)
    {
        Span<byte> normalizedKey = stackalloc byte[key.Length];
        JsonPathComparer.Default.Normalize(key, ref normalizedKey, out int bytesWritten);
        normalizedKey = normalizedKey.Slice(0, bytesWritten);
#if NET9_0_OR_GREATER
        return dictionary.GetAlternateLookup<ReadOnlySpan<byte>>().ContainsKey(normalizedKey);
#else
        return dictionary.ContainsKey(normalizedKey.ToArray());
#endif
    }

    public static void Set(this Dictionary<byte[], JsonPatch.EncodedValue> dictionary, ReadOnlySpan<byte> key, JsonPatch.EncodedValue value)
    {
        Span<byte> normalizedKey = stackalloc byte[key.Length];
        JsonPathComparer.Default.Normalize(key, ref normalizedKey, out int bytesWritten);
        normalizedKey = normalizedKey.Slice(0, bytesWritten);
#if NET9_0_OR_GREATER
        dictionary.GetAlternateLookup<ReadOnlySpan<byte>>()[normalizedKey] = value;
#else
        dictionary[normalizedKey.ToArray()] = value;
#endif
    }
}
