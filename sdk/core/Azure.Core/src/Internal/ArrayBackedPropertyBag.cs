// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
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
        private Kvp[] _rest;
        private int _count;

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
        }

        public int Count => _count;

        public bool IsEmpty => _count == 0;

        public void GetAt(int index, out TKey key, out TValue value)
        {
            if (index >= _count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            (key, value) = index switch
            {
                0 => _first,
                1 => _second,
                _ => _rest[index - 2]
            };
        }

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        {
            var index = GetIndex(key);
            if (index < 0)
            {
                value = default;
                return false;
            }
            else
            {
                value = GetAt(index);
                return true;
            }
        }

        public bool TryAdd(TKey key, TValue value, out TValue? existingValue)
        {
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
            var index = GetIndex(key);
            if (index < 0)
                AddInternal(key, value);
            else
                SetAt(index, new Kvp(key, value));
        }

        public bool TryDelete(TKey key)
        {
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
                    if (IsFirst(key))
                    {
                        _first = _second;
                        _second = _rest[0];
                        _count--;
                        Array.Copy(_rest, 1, _rest, 0, _count - 2);
                        _rest[_count - 2] = default;
                        return true;
                    }

                    if (IsSecond(key))
                    {
                        _second = _rest[0];
                        _count--;
                        Array.Copy(_rest, 1, _rest, 0, _count - 2);
                        _rest[_count - 2] = default;
                        return true;
                    }

                    for (var i = 0; i < _count - 2; i++)
                    {
                        if (IsRest(i, key))
                        {
                            _count--;
                            Array.Copy(_rest, i + 1, _rest, i, _count - 2 - i);
                            _rest[_count - 2] = default;
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
        private bool IsRest(int index, TKey key) => _rest[index].Key.Equals(key);

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
                _rest[index - 2] = value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private TValue GetAt(int index) => index switch
        {
            0 => _first.Value,
            1 => _second.Value,
            _ => _rest[index - 2].Value
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

            int max = _count - 2;
            for (var i = 0; i < max; i++)
            {
                if (_rest[i].Key.Equals(key))
                    return i + 2;
            }
            return -1;
        }

        internal void Dispose()
        {
            if (_rest != null)
            {
                ArrayPool<Kvp>.Shared.Return(_rest, true);
            }
        }
    }
}
