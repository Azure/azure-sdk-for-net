// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

//using System.Collections;
//using System.Collections.Generic;
//using System.Diagnostics.CodeAnalysis;

//namespace Azure.Core.Serialization
//{
//#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

//    public struct MergePatchDictionary<T> : IDictionary<string, T>
//    {
//        private readonly Dictionary<string, Changed<T>> _dictionary;

//        public MergePatchDictionary(ChangeListElement changes)
//        {
//            _dictionary = new Dictionary<string, Changed<T>>();
//        }

//        /// <summary>
//        /// Deserialization constructor.
//        /// </summary>
//        /// <param name="changes"></param>
//        /// <param name="dictionary"></param>
//        public MergePatchDictionary(ChangeListElement changes, Dictionary<string, Changed<T>> dictionary) : this(changes)
//        {
//            _dictionary = dictionary;
//        }

//        public T this[string key]
//        {
//            get => _dictionary[key].Value;
//            set
//            {
//                _dictionary[key] = value;
//            }
//        }

//        ICollection<string> IDictionary<string, T>.Keys => _dictionary.Keys;

//        ICollection<T> IDictionary<string, T>.Values => _dictionary.Values;

//        int ICollection<KeyValuePair<string, T>>.Count => _dictionary.Count;

//        bool ICollection<KeyValuePair<string, T>>.IsReadOnly => false;

//        public void Add(string key, T value)
//        {
//            _dictionary.Add(key, value);
//        }

//        void ICollection<KeyValuePair<string, T>>.Add(KeyValuePair<string, T> item)
//        {
//            (_dictionary as ICollection<KeyValuePair<string, Changed<T>>>).Add(item.Value);
//        }

//        void ICollection<KeyValuePair<string, T>>.Clear()
//        {
//            ICollection<KeyValuePair<string, T>> collection = _dictionary;
//            foreach (KeyValuePair<string, T> item in collection)
//            {
//                //_changes.Remove(item.Key);
//            }

//            collection.Clear();
//        }

//        bool ICollection<KeyValuePair<string, T>>.Contains(KeyValuePair<string, T> item) =>
//            (_dictionary as ICollection<KeyValuePair<string, T>>).Contains(item);

//        bool IDictionary<string, T>.ContainsKey(string key)
//            => _dictionary.ContainsKey(key);

//        void ICollection<KeyValuePair<string, T>>.CopyTo(KeyValuePair<string, T>[] array, int arrayIndex)
//            => (_dictionary as ICollection<KeyValuePair<string, T>>).CopyTo(array, arrayIndex);

//        IEnumerator<KeyValuePair<string, T>> IEnumerable<KeyValuePair<string, T>>.GetEnumerator()
//            => (_dictionary as IEnumerable<KeyValuePair<string, T>>).GetEnumerator();

//        IEnumerator IEnumerable.GetEnumerator() => (_dictionary as IEnumerable).GetEnumerator();

//        bool IDictionary<string, T>.Remove(string key)
//        {
//            return _dictionary.Remove(key);
//        }

//        bool ICollection<KeyValuePair<string, T>>.Remove(KeyValuePair<string, T> item)
//        {
//            return (_dictionary as ICollection<KeyValuePair<string, T>>).Remove(item);
//        }

//#if NET5_0_OR_GREATER
//        public bool TryGetValue(string key, [MaybeNullWhen(false)] out T value)
//#else
//        public bool TryGetValue(string key, out T value)
//#endif
//        {
//            if (_dictionary.TryGetValue(key, out Changed<T>? changedValue))
//            {
//                value = changedValue.Value;
//                return true;
//            }

//            value = default(T);
//            return false;
//        }
//    }
//#pragma warning restore CS1591
//}
