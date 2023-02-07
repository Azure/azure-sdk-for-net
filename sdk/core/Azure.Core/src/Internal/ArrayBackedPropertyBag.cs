// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Buffers;
using System.Runtime.CompilerServices;

namespace Azure.Core
{
    /// <summary>
    /// A property bag which is optimized for storage of a small number of items.
    /// If the item count is less than 2, there are no allocations. Any additional items are stored in an array which will grow as needed.
    /// MUST be passed by ref only.
    /// </summary>
    internal struct ArrayBackedPropertyBag
    {
        private KVP _first;
        private KVP _second;
        private KVP[] _rest;
        private int _count;

        private readonly struct KVP
        {
            public readonly ulong Key;
            public readonly object Value;

            public KVP(ulong key, object value)
            {
                Key = key;
                Value = value;
            }
        }

        public bool IsEmpty => _count == 0;

        public bool TryGetValue(ulong key, out object? value)
        {
            var index = GetIndex(key);
            if (index < 0)
            {
                value = null;
                return false;
            }
            else
            {
                value = GetAt(index);
                return true;
            }
        }

        public void Set(ulong key, object value)
        {
            var index = GetIndex(key);
            if (index < 0)
                AddInternal(key, value);
            else
                SetAt(index, new KVP(key, value));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void AddInternal(ulong key, object value)
        {
            if (_count == 0)
            {
                _first = new KVP(key, value);
                _count = 1;
                return;
            }

            if (_count == 1)
            {
                if (_first.Key == key)
                {
                    _first = new KVP(_first.Key, value);
                }
                else
                {
                    _second = new KVP(key, value);
                    _count = 2;
                }
                return;
            }

            if (_rest == null)
            {
                _rest = ArrayPool<KVP>.Shared.Rent(8);
                _rest[_count++ - 2] = new KVP(key, value);
                return;
            }

            if (_rest.Length <= _count)
            {
                var larger = ArrayPool<KVP>.Shared.Rent(_rest.Length << 1);
                _rest.CopyTo(larger, 0);
                var old = _rest;
                _rest = larger;
                ArrayPool<KVP>.Shared.Return(old, true);
            }
            _rest[_count++ - 2] = new KVP(key, value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void SetAt(int index, KVP value)
        {
            if (index == 0)
                _first = value;
            else if (index == 1)
                _second = value;
            else
                _rest[index - 2] = value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private object GetAt(int index)
        {
            if (index == 0)
                return _first.Value;
            if (index == 1)
                return _second.Value;
            return _rest[index - 2].Value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private int GetIndex(ulong key)
        {
            if (_count == 0)
                return -1;
            if (_count > 0 && _first.Key == key)
                return 0;
            if (_count > 1 && _second.Key == key)
                return 1;

            int max = _count - 2;
            for (var i = 0; i < max; i++)
            {
                if (_rest[i].Key == key)
                    return i + 2;
            }
            return -1;
        }

        internal void Dispose()
        {
            if (_rest != null)
            {
                ArrayPool<KVP>.Shared.Return(_rest, true);
            }
        }
    }
}
