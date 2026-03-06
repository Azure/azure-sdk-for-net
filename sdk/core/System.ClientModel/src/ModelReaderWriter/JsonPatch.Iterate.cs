// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace System.ClientModel.Primitives;

public partial struct JsonPatch
{
    /// <summary>
    /// Returns an enumerator that iterates over the elements of a JSON array at the specified path.
    /// </summary>
    /// <param name="jsonPath">The JSON path pointing at the array.</param>
    /// <returns>An <see cref="ArrayEnumerator"/> that yields each array element as <see cref="ReadOnlyMemory{T}"/> of bytes.</returns>
    /// <exception cref="KeyNotFoundException">If the <paramref name="jsonPath"/> was not found.</exception>
    /// <exception cref="InvalidOperationException">If the value at <paramref name="jsonPath"/> is not a JSON array.</exception>
    public ArrayEnumerator EnumerateArray(ReadOnlySpan<byte> jsonPath)
    {
        ReadOnlyMemory<byte> arrayBlob = ResolveArray(jsonPath);

        // Validate that the resolved value is a JSON array
        if (arrayBlob.IsEmpty)
        {
            ThrowKeyNotFoundException(jsonPath);
        }

        // ArrayEnumerator validates via Utf8JsonReader which correctly handles
        // leading whitespace in the raw JSON bytes.
        return new ArrayEnumerator(arrayBlob);
    }

    /// <summary>
    /// Resolves the fully-merged array bytes at the specified path by applying all mutations
    /// (removes, appends, replacements) from the properties dictionary to the seed bytes.
    /// </summary>
    private ReadOnlyMemory<byte> ResolveArray(ReadOnlySpan<byte> jsonPath)
    {
        bool hasProperties = _properties is not null;
        bool hasRawJson = !_rawJson.Value.IsEmpty;
        bool hasPropagators = _propagatorGetter is not null;

        // Case 1: Empty patch — nothing to resolve
        if (!hasProperties && !hasRawJson && !hasPropagators)
        {
            ThrowKeyNotFoundException(jsonPath);
        }

        // Case 2: Seed-only (no mutations, no propagators) — extract directly from raw bytes
        if (!hasProperties && !hasPropagators)
        {
            if (!hasRawJson)
            {
                ThrowKeyNotFoundException(jsonPath);
            }

            if (jsonPath.IsRoot())
            {
                return _rawJson.Value;
            }

            if (!_rawJson.Value.TryGetJson(jsonPath, out var result))
            {
                ThrowKeyNotFoundException(jsonPath);
            }

            return result;
        }

        // Case 3: Has properties and/or propagators — use TryGetEncodedValueInternal which
        // handles propagators (including append merge), GetCombinedArray for appends,
        // and seed resolution. Then post-process for sub-path removes/replacements.
        ReadOnlyMemory<byte> resolvedArray;
        if (TryGetEncodedValueInternal(jsonPath, out var ev))
        {
            if (ev.Kind == ValueKind.Removed)
            {
                ThrowKeyNotFoundException(jsonPath);
            }
            resolvedArray = ev.Value;
        }
        else if (jsonPath.IsRoot())
        {
            resolvedArray = _rawJson.Value;
        }
        else
        {
            return ThrowKeyNotFoundException(jsonPath);
        }

        if (hasProperties)
        {
            resolvedArray = ApplySubPathMutations(resolvedArray, jsonPath);
        }

        return resolvedArray;
    }

    /// <summary>
    /// Applies mutations (removes and replacements) for sub-paths of the array path
    /// from the properties dictionary.
    /// Appends are handled by TryGetEncodedValueInternal via GetCombinedArray.
    /// </summary>
    private ReadOnlyMemory<byte> ApplySubPathMutations(ReadOnlyMemory<byte> resolved, ReadOnlySpan<byte> jsonPath)
    {
        Span<byte> normalizedPrefix = stackalloc byte[jsonPath.Length];
        JsonPathComparer.Default.Normalize(jsonPath, normalizedPrefix, out int prefixLen);
        normalizedPrefix = normalizedPrefix.Slice(0, prefixLen);

        foreach (var kvp in _properties!)
        {
            ReadOnlySpan<byte> keySpan = kvp.Key;
            if (keySpan.Length <= normalizedPrefix.Length || !keySpan.StartsWith(normalizedPrefix))
            {
                continue;
            }

            // Build relative path: "$" + remaining portion after the prefix
            ReadOnlySpan<byte> remaining = keySpan.Slice(normalizedPrefix.Length);
            byte[] relativePath = new byte[1 + remaining.Length];
            relativePath[0] = (byte)'$';
            remaining.CopyTo(relativePath.AsSpan(1));

            if (kvp.Value.Kind.HasFlag(ValueKind.Removed))
            {
                resolved = resolved.Remove(relativePath);
            }
            else if (!kvp.Value.Kind.HasFlag(ValueKind.ArrayItemAppend) && !kvp.Value.Kind.HasFlag(ValueKind.ModelOwned))
            {
                resolved = resolved.Set(relativePath, GetEncodedBytes(kvp.Value));
            }
        }

        return resolved;
    }

    /// <summary>
    /// A ref struct enumerator that iterates over elements of a JSON array, yielding each element
    /// as a <see cref="ReadOnlyMemory{T}"/> of UTF-8 bytes.
    /// </summary>
    [Experimental("SCME0001")]
    public ref struct ArrayEnumerator
    {
        private readonly ReadOnlyMemory<byte> _arrayBlob;
        private Utf8JsonReader _reader;
        private ReadOnlyMemory<byte> _current;

        internal ArrayEnumerator(ReadOnlyMemory<byte> arrayBlob)
        {
            _arrayBlob = arrayBlob;
            _reader = new Utf8JsonReader(arrayBlob.Span);
            _current = ReadOnlyMemory<byte>.Empty;

            // Advance past the opening '[' of the array
            if (!_reader.Read() || _reader.TokenType != JsonTokenType.StartArray)
            {
                throw new InvalidOperationException("The value is not a valid JSON array.");
            }
        }

        /// <summary>
        /// Gets the current array element as raw UTF-8 JSON bytes.
        /// </summary>
        public readonly ReadOnlyMemory<byte> Current => _current;

        /// <summary>
        /// Advances the enumerator to the next element in the array.
        /// </summary>
        /// <returns><c>true</c> if there is another element; <c>false</c> if the end of the array has been reached.</returns>
        public bool MoveNext()
        {
            if (!_reader.Read())
            {
                return false;
            }

            // EndArray at the top level means we've exhausted the array
            if (_reader.TokenType == JsonTokenType.EndArray)
            {
                return false;
            }

            // Record the start position of the current element
            long start = _reader.TokenStartIndex;

            // Skip the entire value (handles objects, arrays, and primitives)
            _reader.Skip();

            long end = _reader.BytesConsumed;

            _current = _arrayBlob.Slice((int)start, (int)(end - start));
            return true;
        }

        /// <summary>
        /// Returns this enumerator instance, enabling <c>foreach</c> usage.
        /// </summary>
        public readonly ArrayEnumerator GetEnumerator() => this;
    }
}
