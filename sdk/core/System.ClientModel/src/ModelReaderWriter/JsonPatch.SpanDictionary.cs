// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

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

        public int MaxKeyLength { get; private set; }

        public bool TryGetValue(ReadOnlySpan<byte> key, out EncodedValue value)
        {
            Span<byte> buffer = stackalloc byte[key.Length];
            ReadOnlySpan<byte> normalizedKey = GetNormalizedKey(key, buffer);
#if NET9_0_OR_GREATER
            return _inner.GetAlternateLookup<ReadOnlySpan<byte>>().TryGetValue(normalizedKey, out value);
#else
            return _inner.TryGetValue(normalizedKey.ToArray(), out value);
#endif
        }

        public void Set(ReadOnlySpan<byte> key, EncodedValue value)
        {
            Span<byte> buffer = stackalloc byte[key.Length];
            ReadOnlySpan<byte> normalizedKey = GetNormalizedKey(key, buffer);
            MaxKeyLength = Math.Max(MaxKeyLength, normalizedKey.Length);
#if NET9_0_OR_GREATER
            _inner.GetAlternateLookup<ReadOnlySpan<byte>>()[normalizedKey] = value;
#else
            _inner[normalizedKey.ToArray()] = value;
#endif
        }

        public Dictionary<byte[], EncodedValue>.Enumerator GetEnumerator()
            => _inner.GetEnumerator();

        public void TryUpdateValueKind(ReadOnlySpan<byte> key, ValueKind kind)
        {
            Span<byte> buffer = stackalloc byte[key.Length];
            ReadOnlySpan<byte> normalizedKey = GetNormalizedKey(key, buffer);
#if NET9_0_OR_GREATER
            var lookup = _inner.GetAlternateLookup<ReadOnlySpan<byte>>();
            ref EncodedValue encodedValue = ref CollectionsMarshal.GetValueRefOrNullRef(lookup, normalizedKey);
            if (!Unsafe.IsNullRef(ref encodedValue))
            {
                encodedValue.Kind = kind;
            }
#elif NET8_0
            ref EncodedValue encodedValue = ref CollectionsMarshal.GetValueRefOrNullRef(_inner, normalizedKey.ToArray());
            if (!Unsafe.IsNullRef(ref encodedValue))
            {
                encodedValue.Kind = kind;
            }
#else
            byte[] normalizedBytes = normalizedKey.ToArray();
            if (_inner.TryGetValue(normalizedBytes, out EncodedValue encodedValue))
            {
                encodedValue.Kind = kind;
                _inner[normalizedBytes] = encodedValue;
            }
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ReadOnlySpan<byte> GetNormalizedKey(ReadOnlySpan<byte> key, Span<byte> buffer)
        {
            JsonPathComparer.Default.Normalize(key, buffer, out int bytesWritten);
            return buffer.Slice(0, bytesWritten);
        }
    }
}
