// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace System.ClientModel.SourceGeneration;

/// <summary>
/// Provides an immutable list implementation which implements sequence equality.
/// </summary>
#pragma warning disable SA1402 // File may only contain a single type
internal sealed class ImmutableEquatableArray<T> : IEquatable<ImmutableEquatableArray<T>>, IReadOnlyList<T>
#pragma warning restore SA1402 // File may only contain a single type
    where T : IEquatable<T>
{
    /// <summary>
    /// .
    /// </summary>
    public static ImmutableEquatableArray<T> Empty { get; } = new ImmutableEquatableArray<T>(Array.Empty<T>());

    private readonly T[] _values;

    /// <inheritdoc/>
    public T this[int index] => _values[index];
    /// <inheritdoc/>
    public int Count => _values.Length;

    /// <inheritdoc/>
    public ImmutableEquatableArray(IEnumerable<T> values)
        => _values = values.ToArray();

    /// <inheritdoc/>
    public bool Equals(ImmutableEquatableArray<T>? other)
        => other != null && ((ReadOnlySpan<T>)_values).SequenceEqual(other._values);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
        => obj is ImmutableEquatableArray<T> other && Equals(other);

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        int hash = 0;
        foreach (T value in _values)
        {
            hash = HashHelpers.Combine(hash, value is null ? 0 : value.GetHashCode());
        }

        return hash;
    }

    /// <inheritdoc/>
    public Enumerator GetEnumerator() => new Enumerator(_values);
    IEnumerator<T> IEnumerable<T>.GetEnumerator() => ((IEnumerable<T>)_values).GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => _values.GetEnumerator();

    /// <inheritdoc/>
    public struct Enumerator
    {
        private readonly T[] _values;
        private int _index;

        internal Enumerator(T[] values)
        {
            _values = values;
            _index = -1;
        }

        /// <inheritdoc/>
        public bool MoveNext()
        {
            int newIndex = _index + 1;

            if ((uint)newIndex < (uint)_values.Length)
            {
                _index = newIndex;
                return true;
            }

            return false;
        }

        /// <inheritdoc/>
        public readonly T Current => _values[_index];
    }
}

internal static class ImmutableEquatableArray
{
    public static ImmutableEquatableArray<T> ToImmutableEquatableArray<T>(this IEnumerable<T> values) where T : IEquatable<T>
        => new(values);
}
