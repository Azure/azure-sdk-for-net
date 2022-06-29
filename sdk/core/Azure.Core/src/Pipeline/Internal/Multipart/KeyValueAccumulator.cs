// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Copied from https://github.com/aspnet/AspNetCore/tree/master/src/Http/WebUtilities/src

using System;
using System.Collections.Generic;

#pragma warning disable IDE0008 // Use explicit type
#pragma warning disable IDE0018 // Inline declaration
#pragma warning disable IDE0034 // default can be simplified

namespace Azure.Core
{
    internal struct KeyValueAccumulator
    {
        private Dictionary<string, string[]?> _accumulator;
        private Dictionary<string, List<string>> _expandingAccumulator;

        public void Append(string key, string value)
        {
            if (_accumulator == null)
            {
                _accumulator = new Dictionary<string, string[]?>(StringComparer.OrdinalIgnoreCase);
            }

            string[]? values;
            if (_accumulator.TryGetValue(key, out values))
            {
                if (values?.Length == 0)
                {
                    // Marker entry for this key to indicate entry already in expanding list dictionary
                    _expandingAccumulator[key].Add(value);
                }
                else if (values?.Length == 1)
                {
                    // Second value for this key
                    _accumulator[key] = new string[] { values[0], value };
                }
                else if (values != null)
                {
                    // Third value for this key
                    // Add zero count entry and move to data to expanding list dictionary
                    _accumulator[key] = null;

                    if (_expandingAccumulator == null)
                    {
                        _expandingAccumulator = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);
                    }

                    // Already 3 entries so use starting allocated as 8; then use List's expansion mechanism for more
                    var list = new List<string>(8);

                    list.Add(values[0]);
                    list.Add(values[1]);
                    list.Add(value);

                    _expandingAccumulator[key] = list;
                }
            }
            else
            {
                // First value for this key
                _accumulator[key] = new[] { value };
            }

            ValueCount++;
        }

        public bool HasValues => ValueCount > 0;

        public int KeyCount => _accumulator?.Count ?? 0;

        public int ValueCount { get; private set; }

        public Dictionary<string, string []?> GetResults()
        {
            if (_expandingAccumulator != null)
            {
                // Coalesce count 3+ multi-value entries into _accumulator dictionary
                foreach (var entry in _expandingAccumulator)
                {
                    _accumulator[entry.Key] = entry.Value.ToArray();
                }
            }

            return _accumulator ?? new Dictionary<string, string[]?>(0, StringComparer.OrdinalIgnoreCase);
        }
    }
}
