// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Runtime.CompilerServices;

namespace System.ClientModel.Primitives;

internal class SpanDictionary<TValue> : IEnumerable<KeyValuePair<byte[], TValue>>
{
    internal struct Entry
    {
        public byte[] Key;
        public TValue Value;
        public int HashCode;
        public int Next;
    }

    private int[] _buckets;
    private Entry[] _entries;
    private int _count;

    public SpanDictionary(int capacity = 0)
    {
        _buckets = new int[capacity];
        ArrayFill(_buckets, -1);
        _entries = new Entry[capacity];
        _count = 0;
    }

    public bool TryGetValue(ReadOnlySpan<byte> key, out TValue value)
    {
        if (Find(key, out int entryIndex))
        {
            value = _entries[entryIndex].Value;
            return true;
        }

        value = default!;
        return false;
    }

    private bool Find(ReadOnlySpan<byte> key, out int entryIndex)
    {
        if (_count == 0)
        {
            entryIndex = -1;
            return false;
        }

        var hashCode = JsonPathEqualityComparer.GetHashCode(key);
        var bucketIndex = GetBucket((uint)hashCode);

        for (int i = _buckets[bucketIndex]; i >= 0; i = _entries[i].Next)
        {
            if (_entries[i].HashCode == hashCode && JsonPathEqualityComparer.Equals(key, _entries[i].Key))
            {
                entryIndex = i;
                return true;
            }
        }

        entryIndex = -1;
        return false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private int GetBucket(uint hashCode)
    {
        return (int)(hashCode % (uint)_buckets.Length);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int GetBucketForSize(int hashCode, int size)
    {
        return (int)((uint)hashCode % (uint)size);
    }

    public int Count => _count;

    public bool ContainsKey(ReadOnlySpan<byte> key)
    {
        return TryGetValue(key, out _);
    }

    public TValue this[ReadOnlySpan<byte> key]
    {
        get
        {
            if (TryGetValue(key, out TValue value))
            {
                return value;
            }
            throw new KeyNotFoundException("The specified key was not found in the dictionary.");
        }
        set
        {
            if (Find(key, out int entryIndex))
            {
                _entries[entryIndex].Value = value;
                return;
            }
            else
            {
                Insert(key.ToArray(), value);
            }
        }
    }

    public TValue this[byte[] key]
    {
        get
        {
            if (TryGetValue(key, out TValue value))
            {
                return value;
            }
            throw new KeyNotFoundException("The specified key was not found in the dictionary.");
        }
        set
        {
            if (Find(key, out int entryIndex))
            {
                _entries[entryIndex].Value = value;
                return;
            }
            else
            {
                Insert(key, value);
            }
        }
    }

    public void Add(ReadOnlySpan<byte> key, TValue value)
    {
        if (Find(key, out _))
        {
            throw new ArgumentException("An item with the same key has already been added.", nameof(key));
        }

        Insert(key.ToArray(), value);
    }

    public void Add(byte[] key, TValue value)
    {
        if (Find(key, out _))
        {
            throw new ArgumentException("An item with the same key has already been added.", nameof(key));
        }

        Insert(key, value);
    }

    private void Insert(byte[] key, TValue value)
    {
        if (_count >= _entries.Length)
        {
            Resize();
        }

        var hashCode = JsonPathEqualityComparer.GetHashCode(key);
        var bucketIndex = GetBucket((uint)hashCode);

        _entries[_count] = new Entry
        {
            Key = key,
            Value = value,
            HashCode = hashCode,
            Next = _buckets[bucketIndex]
        };
        _buckets[bucketIndex] = _count;
        _count++;
    }

    private void Resize()
    {
        int newSize = _count == 0 ? 3 : _count * 2;
        Array.Resize(ref _entries, newSize);
        _buckets = new int[newSize];
        ArrayFill(_buckets, -1);

        for (int i = 0; i < _count; i++)
        {
            int bucket = GetBucketForSize(_entries[i].HashCode, newSize);
            _entries[i].Next = _buckets[bucket];
            _buckets[bucket] = i;
        }
    }

    private static void ArrayFill<T>(T[] array, T value)
    {
#if NET6_0_OR_GREATER
        Array.Fill(array, value);
#else
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = value;
        }
#endif
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable<KeyValuePair<byte[], TValue>>)this).GetEnumerator();
    }

    IEnumerator<KeyValuePair<byte[], TValue>> IEnumerable<KeyValuePair<byte[], TValue>>.GetEnumerator()
    {
        foreach (var entry in _entries)
        {
            if (entry.Key is not null)
            {
                yield return new KeyValuePair<byte[], TValue>(entry.Key, entry.Value);
            }
        }
    }
}
