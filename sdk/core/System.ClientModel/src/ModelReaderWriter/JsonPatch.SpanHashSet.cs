// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Primitives;

public partial struct JsonPatch
{
    private class SpanHashSet
    {
        private HashSet<byte[]> _inner;

        public SpanHashSet()
        {
            _inner = new(JsonPathComparer.Default);
        }

        public bool Contains(ReadOnlySpan<byte> item)
        {
            Span<byte> normalizedItem = stackalloc byte[item.Length];
            JsonPathComparer.Default.Normalize(item, normalizedItem, out int bytesWritten);
            normalizedItem = normalizedItem.Slice(0, bytesWritten);
#if NET9_0_OR_GREATER
            return _inner.GetAlternateLookup<ReadOnlySpan<byte>>().Contains(normalizedItem);
#else
            return _inner.Contains(normalizedItem.ToArray());
#endif
        }

        public bool Add(ReadOnlySpan<byte> item)
        {
            Span<byte> normalizedItem = stackalloc byte[item.Length];
            JsonPathComparer.Default.Normalize(item, normalizedItem, out int bytesWritten);
            normalizedItem = normalizedItem.Slice(0, bytesWritten);
#if NET9_0_OR_GREATER
            return _inner.GetAlternateLookup<ReadOnlySpan<byte>>().Add(normalizedItem);
#else
            return _inner.Add(normalizedItem.ToArray());
#endif
        }
    }
}
