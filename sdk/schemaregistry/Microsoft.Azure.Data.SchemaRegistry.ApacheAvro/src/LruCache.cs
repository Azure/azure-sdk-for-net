// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Azure.Data.SchemaRegistry.ApacheAvro
{
    /// <summary>
    /// A simple LRU cache implementation using a doubly linked list and dictionary.
    /// </summary>
    /// <typeparam name="TKey">The type of key</typeparam>
    /// <typeparam name="TValue">The type of value</typeparam>
    internal class LruCache<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        private readonly int _capacity;
        private readonly LinkedList<KeyValuePair<TKey, TValue>> _linkedList;
        private readonly Dictionary<TKey, (LinkedListNode<KeyValuePair<TKey, TValue>> Node, int Length)> _map;
        private readonly object _syncLock;

        internal int Count => _linkedList.Count;

        internal int TotalLength { get; private set; }

        public LruCache(int capacity)
        {
            _capacity = capacity;
            _linkedList = new LinkedList<KeyValuePair<TKey, TValue>>();
            _map = new Dictionary<TKey, (LinkedListNode<KeyValuePair<TKey, TValue>>, int)>();
            _syncLock = new object();
        }

        public bool TryGet(TKey key, out TValue value)
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

        public void AddOrUpdate(TKey key, TValue val, int length)
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
                var node = new LinkedListNode<KeyValuePair<TKey, TValue>>(new KeyValuePair<TKey, TValue>(key, val));
                _linkedList.AddFirst(node);
                _map[key] = (node, length);
                TotalLength += length;

                if (_map.Count > _capacity)
                {
                    // remove least recently used node
                    LinkedListNode<KeyValuePair<TKey, TValue>> last = _linkedList.Last;
                    _linkedList.RemoveLast();
                    var toRemove = _map[last.Value.Key];
                    _map.Remove(last.Value.Key);
                    TotalLength -= toRemove.Length;
                }
            }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => _linkedList.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}