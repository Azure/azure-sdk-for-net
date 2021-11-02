// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Azure.Communication.JobRouter.Models
{
    public partial class LabelCollection : IEnumerable<KeyValuePair<string, object>>
    {
        private Dictionary<string, object> _data;

        public LabelCollection()
        {
            _data = new Dictionary<string, object>();
        }

        public LabelCollection(IDictionary<string, object> values)
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
                result._data.Add(item.Key, item.Value);

            return result;
        }

        private static void ValidateValue(object value)
        {
            if (value == null)
                return;
            if (value.GetType().IsPrimitive)
                return;
            if (value is string)
                return;

            throw new ArgumentException($"Unsupported type {value.GetType()}");
        }

        public object this[string key]
        {
            get => _data[key];
            set
            {
                ValidateValue(value);
                _data[key] = value;
            }
        }

        public int Count => _data.Count;

        public void Add(string key, object value)
        {
            ValidateValue(value);
            _data.Add(key, value);
        }

        public void Clear()
        {
            _data.Clear();
        }

        public bool ContainsKey(string key) => _data.ContainsKey(key);

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator() => _data.GetEnumerator();

        public bool Remove(string key) => _data.Remove(key);

        IEnumerator IEnumerable.GetEnumerator() => _data.GetEnumerator();

        public ICollection<string> Keys => _data.Keys;

        public ICollection<object> Values => _data.Values;
    }
}
