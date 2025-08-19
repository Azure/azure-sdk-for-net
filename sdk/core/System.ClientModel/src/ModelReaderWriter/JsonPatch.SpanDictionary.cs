// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Primitives;

public partial struct JsonPatch
{
    /// <summary>
    /// This class ensures that no one can access the underlying dictionary without normalizing the keys.
    /// If the private field <see cref="JsonPatch._properties"/> was a Dictionary&lt;byte[], EncodedValue&gt; directly
    /// then someone could mistakenly use the dictionary methods that take byte[] for keys and would skip normalization.
    /// Its a private nested class because it is not intended for general purpose use its specialized for the needs of JsonPatch only.
    /// </summary>
    private class SpanDictionary
    {
        private readonly Dictionary<byte[], EncodedValue> _inner;

        public SpanDictionary()
        {
            _inner = new(JsonPathComparer.Default);
        }

        public int Count => _inner.Count;

        public bool TryGetValue(ReadOnlySpan<byte> key, out EncodedValue value)
        {
            Span<byte> normalizedKey = stackalloc byte[key.Length];
            JsonPathComparer.Default.Normalize(key, ref normalizedKey, out int bytesWritten);
            normalizedKey = normalizedKey.Slice(0, bytesWritten);
#if NET9_0_OR_GREATER
            return _inner.GetAlternateLookup<ReadOnlySpan<byte>>().TryGetValue(normalizedKey, out value);
#else
        return _inner.TryGetValue(normalizedKey.ToArray(), out value);
#endif
        }

        public bool ContainsKey(ReadOnlySpan<byte> key)
        {
            Span<byte> normalizedKey = stackalloc byte[key.Length];
            JsonPathComparer.Default.Normalize(key, ref normalizedKey, out int bytesWritten);
            normalizedKey = normalizedKey.Slice(0, bytesWritten);
#if NET9_0_OR_GREATER
            return _inner.GetAlternateLookup<ReadOnlySpan<byte>>().ContainsKey(normalizedKey);
#else
        return _inner.ContainsKey(normalizedKey.ToArray());
#endif
        }

        public void Set(ReadOnlySpan<byte> key, EncodedValue value)
        {
            Span<byte> normalizedKey = stackalloc byte[key.Length];
            JsonPathComparer.Default.Normalize(key, ref normalizedKey, out int bytesWritten);
            normalizedKey = normalizedKey.Slice(0, bytesWritten);
#if NET9_0_OR_GREATER
            _inner.GetAlternateLookup<ReadOnlySpan<byte>>()[normalizedKey] = value;
#else
        _inner[normalizedKey.ToArray()] = value;
#endif
        }

        public Dictionary<byte[], EncodedValue>.Enumerator GetEnumerator()
            => _inner.GetEnumerator();
    }
}
