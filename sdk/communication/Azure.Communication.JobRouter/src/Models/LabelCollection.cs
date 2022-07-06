// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// Dictionary like data structure which supports only string values as keys and primitive types as values.
    /// </summary>
    public partial class LabelCollection : IEnumerable<KeyValuePair<string, LabelValue>>
    {
        private Dictionary<string, LabelValue> _data;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public LabelCollection()
        {
            _data = new Dictionary<string, LabelValue>();
        }

        /// <summary>
        /// Returns a new LabelCollection with another dictionary.
        /// </summary>
        /// <param name="values"></param>
        public LabelCollection(IDictionary<string, LabelValue> values)
            : this()
        {
            foreach (var item in values)
                Add(item.Key, item.Value);
        }

        internal static LabelCollection BuildFromRawValues(IDictionary<string, object> values)
        {
            var result = new LabelCollection();

            if (values == null)
            {
                return result;
            }

            foreach (var item in values)
                result._data.Add(item.Key, new LabelValue(item.Value));

            return result;
        }

        private static void ValidateValue(LabelValue value)
        {
            if (value == null)
                return;
            if (value.Value.GetType().IsPrimitive)
                return;
            if (value.Value is string)
                return;

            throw new ArgumentException($"Unsupported type {value.Value.GetType()}");
        }

        /// <summary>
        /// Get or set key-value.
        /// </summary>
        /// <param name="key"></param>
        public LabelValue this[string key]
        {
            get => _data[key];
            set
            {
                ValidateValue(value);
                _data[key] = value;
            }
        }

        /// <summary>
        /// Gets the number of key/value pairs contained in <see cref="LabelCollection"/>.
        /// </summary>
        public int Count => _data.Count;

        /// <summary>
        /// Adds the specified key and value to the label collection.
        /// </summary>
        /// <param name="key">The key of the element to add.</param>
        /// <param name="value">The value of the element to add.</param>
        public void Add(string key, LabelValue value)
        {
            ValidateValue(value);
            _data.Add(key, value);
        }

        /// <summary>
        /// Removes all keys and values from the label collection.
        /// </summary>
        public void Clear()
        {
            _data.Clear();
        }

        /// <summary>
        /// Determines whether the <see cref="LabelCollection" /> contains the specified key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool ContainsKey(string key) => _data.ContainsKey(key);

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="LabelCollection"/>.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<KeyValuePair<string, LabelValue>> GetEnumerator() => _data.GetEnumerator();

        /// <summary>
        /// Removes the value with the specified key from the <see cref="LabelCollection"/>.
        /// </summary>
        /// <param name="key">The key of the element to remove.</param>
        /// <returns></returns>
        public bool Remove(string key) => _data.Remove(key);

        IEnumerator IEnumerable.GetEnumerator() => _data.GetEnumerator();

        /// <summary>
        /// Gets a collection containing the keys in the <see cref="LabelCollection"/>.
        /// </summary>
        public ICollection<string> Keys => _data.Keys;

        /// <summary>
        /// Gets a collection containing the values in the <see cref="LabelCollection"/>.
        /// </summary>
        public ICollection<LabelValue> Values => _data.Values;
    }
}
