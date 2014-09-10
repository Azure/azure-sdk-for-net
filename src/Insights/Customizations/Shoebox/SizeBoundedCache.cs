using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Insights
{
    // TODO: Add locking (thread safety)
    public class SizeBoundedCache<TKey, TValue>
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
            LinkedListNode<KeyValuePair<TKey, TValue>> val;

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
