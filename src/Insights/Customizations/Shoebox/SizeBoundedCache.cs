//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System.Collections.Generic;

namespace Microsoft.Azure.Insights
{
    // TODO: Add locking (thread safety)
    internal class SizeBoundedCache<TKey, TValue>
    {
        private Dictionary<TKey, LinkedListNode<KeyValuePair<TKey, TValue>>> dictionary;
        private LinkedList<KeyValuePair<TKey, TValue>> list;

        public int MaxSize { get; set; }

        public SizeBoundedCache(int maxSize = 1000)
        {
            this.dictionary = new Dictionary<TKey, LinkedListNode<KeyValuePair<TKey, TValue>>>();
            this.list = new LinkedList<KeyValuePair<TKey, TValue>>();
            this.MaxSize = maxSize;
        }

        // Index accessor
        public TValue this[TKey key]
        {
            get
            {
                // Return default (null) if not in cache
                if (!dictionary.ContainsKey(key))
                {
                    return default(TValue);
                }

                // Move accessed node to top of list (newest)
                LinkedListNode<KeyValuePair<TKey, TValue>> node = dictionary[key];
                //TODO: Lock
                list.Remove(node);
                list.AddFirst(node);

                // Return value
                return node.Value.Value;
            }
            set
            {
                LinkedListNode<KeyValuePair<TKey, TValue>> node = new LinkedListNode<KeyValuePair<TKey, TValue>>(new KeyValuePair<TKey, TValue>(key, value));

                // Maintain only the latest version of an item
                // TODO: Lock
                if (this.dictionary.ContainsKey(key))
                {
                    list.Remove(dictionary[key]);
                }

                // Array accessor will add or replace in dictionary, add to list first to avoid access mismatch
                list.AddFirst(node);
                dictionary[key] = node;

                // Maintain max size
                this.Trim();
            }
        }

        // Removes the oldest item from the dictionary and list
        private void RemoveOldest()
        {
            //LinkedListNode<KeyValuePair<TKey, TValue>> val;

            // TODO: Lock
            //while (!dictionary.TryRemove(list.Last.Value.Key, out val))
            //{ }
            dictionary.Remove(list.Last.Value.Key);
            
            list.RemoveLast();
        }

        // Deletes the oldest items until only MaxSize items remain
        private void Trim()
        {
            while (dictionary.Count > MaxSize)
            {
                this.RemoveOldest();
            }
        }
    }
}
