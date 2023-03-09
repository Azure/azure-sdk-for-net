// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Azure.Core
{
    /// <summary>
    /// A property bag which is optimized for storage of a small number of items.
    /// If the item count is less than 2, there are no allocations. Any additional items are stored in an array which will grow as needed.
    /// MUST be passed by ref only.
    /// </summary>
    internal struct ArrayBackedPropertyBag<TKey, TValue> where TKey : struct, IEquatable<TKey>
    {
        private Kvp _first;
        private Kvp _second;
        private Kvp[]? _rest;
        private int _count;
#if DEBUG
        private bool _disposed;
#endif
        private readonly struct Kvp
        {
            public readonly TKey Key;
            public readonly TValue Value;

            public Kvp(TKey key, TValue value)
            {
                Key = key;
                Value = value;
            }

            public void Deconstruct(out TKey key, out TValue value)
            {
                key = Key;
                value = Value;
            }

            public override string ToString() => $"[{Key}, {Value?.ToString() ?? "<null>"}]";
        }

        public int Count
        {
            get
            {
                CheckDisposed();
                return _count;
            }
        }

        public bool IsEmpty
        {
            get
            {
                CheckDisposed();
                return _count == 0;
            }
        }

        public void GetAt(int index, out TKey key, out TValue value)
        {
            CheckDisposed();
            (key, value) = index switch
            {
                0 => _first,
                1 => _second,
                _ => _rest![index - 2] // Must throw if _rest is null
            };
        }

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        {
            CheckDisposed();
            var index = GetIndex(key);
            if (index < 0)
            {
                value = default;
                return false;
            }

            value = GetAt(index);
            return true;
        }

        public bool TryAdd(TKey key, TValue value, out TValue? existingValue)
        {
            CheckDisposed();
            var index = GetIndex(key);
            if (index >= 0)
            {
                existingValue = GetAt(index);
                return false;
            }

            AddInternal(key, value);
            existingValue = default;
            return true;
        }

        public void Set(TKey key, TValue value)
        {
            CheckDisposed();
            var index = GetIndex(key);
            if (index < 0)
                AddInternal(key, value);
            else
                SetAt(index, new Kvp(key, value));
        }

        public bool TryRemove(TKey key)
        {
            CheckDisposed();
            switch (_count)
            {
                case 0:
                    return false;
                case 1:
                    if (IsFirst(key))
                    {
                        _first = default;
                        _count--;
                        return true;
                    }

                    return false;

                case 2:
                    if (IsFirst(key))
                    {
                        _first = _second;
                        _second = default;
                        _count--;
                        return true;
                    }

                    if (IsSecond(key))
                    {
                        _second = default;
                        _count--;
                        return true;
                    }

                    return false;
                default:
                    Kvp[] rest = _rest!; // _rest can't be null when _count >= 2
                    if (IsFirst(key))
                    {
                        _first = _second;
                        _second = rest[0];
                        _count--;
                        Array.Copy(rest, 1, rest, 0, _count - 2);
                        rest[_count - 2] = default;
                        return true;
                    }

                    if (IsSecond(key))
                    {
                        _second = rest[0];
                        _count--;
                        Array.Copy(rest, 1, rest, 0, _count - 2);
                        rest[_count - 2] = default;
                        return true;
                    }

                    for (var i = 0; i < _count - 2; i++)
                    {
                        if (rest[i].Key.Equals(key))
                        {
                            _count--;
                            Array.Copy(rest, i + 1, rest, i, _count - 2 - i);
                            rest[_count - 2] = default;
                            return true;
                        }
                    }

                    return false;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool IsFirst(TKey key) => _first.Key.Equals(key);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool IsSecond(TKey key) => _second.Key.Equals(key);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void AddInternal(TKey key, TValue value)
        {
            switch (_count)
            {
                case 0:
                    _first = new Kvp(key, value);
                    _count = 1;
                    return;
                case 1:
                    if (IsFirst(key))
                    {
                        _first = new Kvp(_first.Key, value);
                    }
                    else
                    {
                        _second = new Kvp(key, value);
                        _count = 2;
                    }

                    return;
                default:
                    if (_rest == null)
                    {
                        _rest = ArrayPool<Kvp>.Shared.Rent(8);
                        _rest[_count++ - 2] = new Kvp(key, value);
                        return;
                    }

                    if (_rest.Length <= _count)
                    {
                        var larger = ArrayPool<Kvp>.Shared.Rent(_rest.Length << 1);
                        _rest.CopyTo(larger, 0);
                        var old = _rest;
                        _rest = larger;
                        ArrayPool<Kvp>.Shared.Return(old, true);
                    }
                    _rest[_count++ - 2] = new Kvp(key, value);
                    return;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void SetAt(int index, Kvp value)
        {
            if (index == 0)
                _first = value;
            else if (index == 1)
                _second = value;
            else
                _rest![index - 2] = value; // _rest can't be null when _count >= 2
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private TValue GetAt(int index) => index switch
        {
            0 => _first.Value,
            1 => _second.Value,
            _ => _rest![index - 2].Value // _rest can't be null when _count >= 2
        };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private int GetIndex(TKey key)
        {
            if (_count == 0)
                return -1;
            if (_count > 0 && _first.Key.Equals(key))
                return 0;
            if (_count > 1 && _second.Key.Equals(key))
                return 1;

            Kvp[] rest = _rest!; // _rest can't be null when _count >= 2
            int max = _count - 2;
            for (var i = 0; i < max; i++)
            {
                if (rest[i].Key.Equals(key))
                    return i + 2;
            }
            return -1;
        }

        internal void Dispose()
        {
#if DEBUG
            if (_disposed)
            {
                return;
            }
            _disposed = true;
#endif
            _count = 0;
            _first = default;
            _second = default;
            if (_rest == default)
            {
                return;
            }

            var rest = _rest;
            _rest = default;
            ArrayPool<Kvp>.Shared.Return(rest, true);
        }

#pragma warning disable CA1822
        [Conditional("DEBUG")]
        private void CheckDisposed()
        {
#if DEBUG
            if (_disposed)
            {
                throw new ObjectDisposedException($"{nameof(ArrayBackedPropertyBag<TKey, TValue>)} instance is already disposed");
            }
#endif
        }
#pragma warning restore CA1822
    }
}
