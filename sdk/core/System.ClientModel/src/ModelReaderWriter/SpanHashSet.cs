// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.CompilerServices;

namespace System.ClientModel.Primitives;

internal class SpanHashSet
{
    internal struct Entry
    {
        public byte[] Key;
        public int HashCode;
        public int Next;
    }

    private int[] _buckets;
    private Entry[] _entries;
    private int _count;

    public SpanHashSet(int capacity = 0)
    {
        _buckets = new int[capacity];
        ArrayFill(_buckets, -1);
        _entries = new Entry[capacity];
        _count = 0;
    }

    public bool Contains(ReadOnlySpan<byte> key)
    {
        return Find(key);
    }

    private bool Find(ReadOnlySpan<byte> key)
    {
        if (_count == 0)
        {
            return false;
        }

        var hashCode = JsonPathEqualityComparer.GetHashCode(key);
        var bucketIndex = GetBucket((uint)hashCode);

        for (int i = _buckets[bucketIndex]; i >= 0; i = _entries[i].Next)
        {
            if (_entries[i].HashCode == hashCode && JsonPathEqualityComparer.Equals(key, _entries[i].Key))
            {
                return true;
            }
        }

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

    public void Add(ReadOnlySpan<byte> key)
    {
        if (Find(key))
        {
            return;
        }

        Insert(key.ToArray());
    }

    public void Add(byte[] key)
    {
        if (Find(key))
        {
            return;
        }

        Insert(key);
    }

    private void Insert(byte[] key)
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
}
