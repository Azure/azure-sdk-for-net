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

using System.Collections;
using System.Collections.Generic;

namespace Microsoft.WindowsAzure.Common.Internals
{
    public class LazyDictionary<TKey, TValue> : IDictionary<TKey, TValue>, ILazyCollection
    {
        private IDictionary<TKey, TValue> _internalDictionary;
        private IDictionary<TKey, TValue> InternalDictionary
        {
            get
            {
                if (_internalDictionary == null)
                {
                    _internalDictionary = new Dictionary<TKey, TValue>();
                }

                return _internalDictionary;
            }

            set
            {
                _internalDictionary = value;
            }
        }

        public bool IsInitialized
        {
            get { return _internalDictionary != null; }
        }

        public LazyDictionary()
        {
            // Default constructor is lazy so it doesn't initialize the dictionary
        }

        public LazyDictionary(IDictionary<TKey, TValue> dictionary)
        {
            InternalDictionary = new Dictionary<TKey, TValue>(dictionary);
        }

        public LazyDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
        {
            InternalDictionary = new Dictionary<TKey, TValue>(dictionary, comparer);
        }

        public LazyDictionary(IEqualityComparer<TKey> comparer)
        {
            InternalDictionary = new Dictionary<TKey, TValue>(comparer);
        }

        public LazyDictionary(int capacity)
        {
            InternalDictionary = new Dictionary<TKey, TValue>(capacity);
        }

        public LazyDictionary(int capacity, IEqualityComparer<TKey> comparer)
        {
            InternalDictionary = new Dictionary<TKey, TValue>(capacity, comparer);
        }

        public void Add(TKey key, TValue value)
        {
            InternalDictionary.Add(key, value);
        }

        public bool ContainsKey(TKey key)
        {
            return InternalDictionary.ContainsKey(key);
        }

        public ICollection<TKey> Keys
        {
            get { return InternalDictionary.Keys; }
        }

        public bool Remove(TKey key)
        {
            return InternalDictionary.Remove(key);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            return InternalDictionary.TryGetValue(key, out value);
        }

        public ICollection<TValue> Values
        {
            get { return InternalDictionary.Values; }
        }

        public TValue this[TKey key]
        {
            get { return InternalDictionary[key]; }
            set { InternalDictionary[key] = value; }
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            InternalDictionary.Add(item);
        }

        public void Clear()
        {
            InternalDictionary.Clear();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return InternalDictionary.Contains(item);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            InternalDictionary.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return InternalDictionary.Count; }
        }

        public bool IsReadOnly
        {
            get { return InternalDictionary.IsReadOnly; }
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return InternalDictionary.Remove(item);
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return InternalDictionary.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return InternalDictionary.GetEnumerator();
        }
    }
}
