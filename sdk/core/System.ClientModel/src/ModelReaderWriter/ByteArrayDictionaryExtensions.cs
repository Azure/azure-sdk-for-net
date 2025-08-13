// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

namespace System.ClientModel.Primitives;

[Experimental("SCM0001")]
internal static class ByteArrayDictionaryExtensions
{
    public static bool TryGetValue(this Dictionary<byte[], AdditionalProperties.EncodedValue> dictionary, ReadOnlySpan<byte> key, out AdditionalProperties.EncodedValue value)
    {
#if NET9_0_OR_GREATER
        return dictionary.GetAlternateLookup<ReadOnlySpan<byte>>().TryGetValue(key, out value);
#else
        return dictionary.TryGetValue(key.ToArray(), out value);
#endif
    }

    public static bool ContainsKey(this Dictionary<byte[], AdditionalProperties.EncodedValue> dictionary, ReadOnlySpan<byte> key)
    {
#if NET9_0_OR_GREATER
        return dictionary.GetAlternateLookup<ReadOnlySpan<byte>>().ContainsKey(key);
#else
        return dictionary.ContainsKey(key.ToArray());
#endif
    }

    public static void Set(this Dictionary<byte[], AdditionalProperties.EncodedValue> dictionary, ReadOnlySpan<byte> key, AdditionalProperties.EncodedValue value)
    {
#if NET9_0_OR_GREATER
        dictionary.GetAlternateLookup<ReadOnlySpan<byte>>()[key] = value;
#else
        dictionary[key.ToArray()] = value;
#endif
    }
}
