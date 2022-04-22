// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.WebPubSub.Common
{
    /// <summary>
    /// Dictionary that wraps access to the ConnectionStates dictionary but
    /// returns stringifed JSON instead of BinaryData.  This only exists to
    /// avoid breaking customers using the old States properties.
    /// </summary>
    internal class StringifiedDictionary : IReadOnlyDictionary<string, object>
    {
        /// <summary>
        /// The original dictionary to wrap.
        /// </summary>
        private readonly IReadOnlyDictionary<string, BinaryData> _original;

        /// <summary>
        /// Creates a new instance of the RawJsonWrappingDictionary class.
        /// </summary>
        /// <param name="original">The original dictionary to wrap.</param>
        public StringifiedDictionary(IReadOnlyDictionary<string, BinaryData> original) =>
            _original = original;

        /// <inheritdoc/>
        public int Count => _original.Count;

        /// <inheritdoc/>
        public object this[string key] => _original[key].ToString();

        /// <inheritdoc/>
        public IEnumerable<string> Keys => _original.Keys;

        /// <inheritdoc/>
        public IEnumerable<object> Values => _original.Values.Select(v => v.ToString());

        /// <inheritdoc/>
        public IEnumerator<KeyValuePair<string, object>> GetEnumerator() =>
            _original.Select(p => new KeyValuePair<string, object>(p.Key, p.Value.ToString())).GetEnumerator();

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <inheritdoc/>
        public bool ContainsKey(string key) => _original.ContainsKey(key);

        /// <inheritdoc/>
        public bool TryGetValue(string key, out object value)
        {
            if (_original.TryGetValue(key, out BinaryData data))
            {
                value = data.ToString();
                return true;
            }
            else
            {
                value = default;
                return false;
            }
        }
    }
}
