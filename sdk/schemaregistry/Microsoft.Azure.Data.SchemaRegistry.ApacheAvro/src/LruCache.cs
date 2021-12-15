// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Microsoft.Azure.Data.SchemaRegistry.ApacheAvro
{
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
                    _linkedList.AddLast(node);
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
                    // move node to the head of the list
                    _linkedList.Remove(existingNode);
                    _linkedList.AddLast(existingNode);
                }
                else
                {
                    // add new node
                    var node = new LinkedListNode<KeyValuePair<K, V>>(new KeyValuePair<K, V>(key, val));
                    _linkedList.AddLast(node);
                    _map[key] = node;
                }

                if (_map.Count >= _capacity)
                {
                    // remove least recently used node
                    LinkedListNode<KeyValuePair<K, V>> first = _linkedList.First;
                    _linkedList.RemoveFirst();
                    _map.Remove(first.Value.Key);
                }
            }
        }
    }
}