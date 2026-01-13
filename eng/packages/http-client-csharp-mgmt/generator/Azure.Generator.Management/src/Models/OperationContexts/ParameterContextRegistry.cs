// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Azure.Generator.Management.Models
{
    internal class ParameterContextRegistry : IReadOnlyDictionary<string, ParameterContextMapping>
    {
        private readonly IReadOnlyDictionary<string, ParameterContextMapping> _parameters;
        public ParameterContextRegistry(IReadOnlyList<ParameterContextMapping> parameters)
        {
            _parameters = parameters.ToDictionary(p => p.ParameterName);
        }

        public ParameterContextMapping this[string key] => _parameters[key];

        public IEnumerable<string> Keys => _parameters.Keys;

        public IEnumerable<ParameterContextMapping> Values => _parameters.Values;

        public int Count => _parameters.Count;

        public bool ContainsKey(string key)
        {
            return _parameters.ContainsKey(key);
        }

        public IEnumerator<KeyValuePair<string, ParameterContextMapping>> GetEnumerator()
        {
            return _parameters.GetEnumerator();
        }

        public bool TryGetValue(string key, [MaybeNullWhen(false)] out ParameterContextMapping value)
        {
            return _parameters.TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
