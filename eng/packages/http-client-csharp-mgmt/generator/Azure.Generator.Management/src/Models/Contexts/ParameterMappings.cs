// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Azure.Generator.Management.Models
{
    internal class ParameterMappings : IReadOnlyDictionary<string, ParameterMapping>
    {
        private readonly IReadOnlyDictionary<string, ParameterMapping> _parameters;
        public ParameterMappings(IReadOnlyList<ParameterMapping> parameters)
        {
            _parameters = parameters.ToDictionary(p => p.ParameterName);
        }

        public ParameterMapping this[string key] => _parameters[key];

        public IEnumerable<string> Keys => _parameters.Keys;

        public IEnumerable<ParameterMapping> Values => _parameters.Values;

        public int Count => _parameters.Count;

        public bool ContainsKey(string key)
        {
            return _parameters.ContainsKey(key);
        }

        public IEnumerator<KeyValuePair<string, ParameterMapping>> GetEnumerator()
        {
            return _parameters.GetEnumerator();
        }

        public bool TryGetValue(string key, [MaybeNullWhen(false)] out ParameterMapping value)
        {
            return _parameters.TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
