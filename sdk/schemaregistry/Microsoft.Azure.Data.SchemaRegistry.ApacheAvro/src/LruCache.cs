// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Microsoft.Azure.Data.SchemaRegistry.ApacheAvro
{
    /// <summary>
    /// A simple LRU cache implementation using a doubly linked list and dictionary.
    /// </summary>
    /// <typeparam name="K">The type of key</typeparam>
    /// <typeparam name="V">The type of value</typeparam>
    internal class LruCache<K,V>
    {
        private readonly int _capacity;
        private readonly LinkedList<KeyValuePair<K, V>> _linkedList;
        private readonly Dictionary<K, LinkedListNode<KeyValuePair<K, V>>> _map;
        private readonly object _syncLock;

        public LruCache(int capacity)
        {
            _capacity = capacity;
            _linkedList = new LinkedList<KeyValuePair<K, V>>();
            _map = new Dictionary<K, LinkedListNode<KeyValuePair<K, V>>>();
            _syncLock = new object();
        }

        public bool TryGet(K key, out V value)
        {
            lock (_syncLock)
            {
                if (_map.TryGetValue(key, out var node))
                {
                    value = node.Value.Value;
                    _linkedList.Remove(node);
                    _linkedList.AddFirst(node);
                    return true;
                }

                value = default(V);
                return false;
            }
        }

        public void AddOrUpdate(K key, V val)
        {
            lock (_syncLock)
            {
                if (_map.TryGetValue(key, out var existingNode))
                {
                    // remove node - we will re-add a new node for this key at the head of the list, as the value may be different
                    _linkedList.Remove(existingNode);
                }

                // add new node
                var node = new LinkedListNode<KeyValuePair<K, V>>(new KeyValuePair<K, V>(key, val));
                _linkedList.AddFirst(node);
                _map[key] = node;

                if (_map.Count > _capacity)
                {
                    // remove least recently used node
                    LinkedListNode<KeyValuePair<K, V>> last = _linkedList.Last;
                    _linkedList.RemoveLast();
                    _map.Remove(last.Value.Key);
                }
            }
        }
    }
}