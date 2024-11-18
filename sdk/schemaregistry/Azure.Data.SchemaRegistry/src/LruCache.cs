// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;

#nullable enable

namespace Azure.Data.SchemaRegistry
{
    /// <summary>
    /// A simple LRU cache implementation using a doubly linked list and dictionary.
    /// </summary>
    /// <typeparam name="TKey">The type of key.</typeparam>
    /// <typeparam name="TValue">The type of value.</typeparam>
    internal class LruCache<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
        where TKey : notnull
    {
        private readonly int _capacity;
        private readonly LinkedList<KeyValuePair<TKey, TValue?>> _linkedList;
        private readonly Dictionary<TKey, (LinkedListNode<KeyValuePair<TKey, TValue?>> Node, int Length)> _map;
        private readonly object _syncLock;

        /// <summary>
        /// Gets the number of key/value pairs contained in the <see cref="LruCache{TKey, TValue}"/>.
        /// </summary>
        public int Count => _linkedList.Count;

        /// <summary>
        /// Gets the total length of all values currently stored in the <see cref="LruCache{TKey, TValue}"/>.
        /// </summary>
        public int TotalLength { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LruCache{TKey, TValue}"/> class.
        /// </summary>
        /// <param name="capacity"></param>
        public LruCache(int capacity)
        {
            _capacity = capacity;
            _linkedList = new LinkedList<KeyValuePair<TKey, TValue?>>();
            _map = new Dictionary<TKey, (LinkedListNode<KeyValuePair<TKey, TValue?>>, int)>();
            _syncLock = new object();
        }

        /// <summary>
        /// Gets the value associated with the specified key.
        /// </summary>
        /// <param name="key">The key of the value to get.</param>
        /// <param name="value">When this method returns, contains the value associated with
        /// the specified key, if the key is found; otherwise, the default value for the type of
        /// the type of the <paramref name="value"/> parameter.</param>
        /// <returns><c>true</c> if the <see cref="LruCache{TKey, TValue}"/> contains an element
        /// with the specified key; otherwise, <c>false</c>.</returns>
        public bool TryGet(TKey key, out TValue? value)
        {
            lock (_syncLock)
            {
                if (_map.TryGetValue(key, out var mapValue))
                {
                    var node = mapValue.Node;
                    value = node.Value.Value;
                    _linkedList.Remove(node);
                    _linkedList.AddFirst(node);
                    return true;
                }

                value = default(TValue);
                return false;
            }
        }

        /// <summary>
        /// Adds a key/value pair to the <see cref="LruCache{TKey, TValue}"/> if the key doesn't already exist, or updates a key/value
        /// pair in the <see cref="LruCache{TKey, TValue}"/> if the key does already exist.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val"></param>
        /// <param name="length"></param>
        public void AddOrUpdate(TKey key, TValue? val, int length)
        {
            lock (_syncLock)
            {
                if (_map.TryGetValue(key, out var existingValue))
                {
                    // remove node - we will re-add a new node for this key at the head of the list, as the value may be different
                    _linkedList.Remove(existingValue.Node);
                    TotalLength -= _map[key].Length;
                }

                // add new node
                var node = new LinkedListNode<KeyValuePair<TKey, TValue?>>(new KeyValuePair<TKey, TValue?>(key, val));
                _linkedList.AddFirst(node);
                _map[key] = (node, length);
                TotalLength += length;

                if (_map.Count > _capacity)
                {
                    // remove least recently used node
                    LinkedListNode<KeyValuePair<TKey, TValue?>> last = _linkedList.Last!;
                    _linkedList.RemoveLast();
                    var toRemove = _map[last.Value.Key];
                    _map.Remove(last.Value.Key);
                    TotalLength -= toRemove.Length;
                }
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="LruCache{TKey, TValue}"/>.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => _linkedList.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
