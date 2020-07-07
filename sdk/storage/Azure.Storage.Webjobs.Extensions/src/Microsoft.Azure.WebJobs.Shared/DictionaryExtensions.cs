// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace System.Collections.Generic
{
    internal static class DictionaryExtensions
    {
        public static T GetValueOrDefault<T>(this IDictionary<string, object> dictionary, string key)
        {
            object value;
            if (dictionary != null && dictionary.TryGetValue(key, out value))
            {
                return (T)value;
            }
            return default(T);
        }
    }
}
