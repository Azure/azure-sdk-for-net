// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Common.Authentication.Utilities
{
    public static class DictionaryExtensions
    {
        public static TValue GetProperty<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey property)
        {
            if (dictionary.ContainsKey(property))
            {
                return dictionary[property];
            }

            return default(TValue);
        }

        public static string[] GetPropertyAsArray<TKey>(this Dictionary<TKey, string> dictionary, TKey property)
        {
            if (dictionary.ContainsKey(property))
            {
                return dictionary[property].Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            }

            return new string[0];
        }

        public static void SetProperty<TKey>(this Dictionary<TKey, string> dictionary, TKey property, params string[] values)
        {
            if (values == null || values.Length == 0)
            {
                if (dictionary.ContainsKey(property))
                {
                    dictionary.Remove(property);
                }
            }
            else
            {
                dictionary[property] = string.Join(",", values);
            }
        }

        public static void SetOrAppendProperty<TKey>(this Dictionary<TKey, string> dictionary, TKey property, params string[] values)
        {
            string oldValueString = "";
            if (dictionary.ContainsKey(property))
            {
                oldValueString = dictionary[property];
            }
            var oldValues = oldValueString.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var newValues = oldValues.Union(values, StringComparer.CurrentCultureIgnoreCase).Where(s => !string.IsNullOrEmpty(s)).ToArray();
            if (newValues.Any())
            {
                dictionary[property] = string.Join(",", newValues);
            }
        }

        public static bool IsPropertySet<TKey>(this Dictionary<TKey, string> dictionary, TKey property)
        {
            return dictionary.ContainsKey(property) && !string.IsNullOrEmpty(dictionary[property]);
        }
    }
}
