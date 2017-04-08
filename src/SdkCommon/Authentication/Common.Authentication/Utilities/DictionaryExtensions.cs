// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
