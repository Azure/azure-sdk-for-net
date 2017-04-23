// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Rest.ClientRuntime.Azure.TestFramework
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public static class ExtMethods
    {
        /// <summary>
        /// Allow to get value for key (either title case or lowercase)
        /// This allows users to set the connection string without worrying about case sensitivity of the keys in the key-value pairs within
        /// connection string
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public static string GetValueUsingCaseInsensitiveKey(this Dictionary<string, string> dictionary, string keyName)
        {
            string valueForKey;
            if (dictionary.TryGetValue(keyName, out valueForKey))
            {
                return valueForKey;
            }
            else if (dictionary.TryGetValue(keyName.ToLower(), out valueForKey))
            {
                return valueForKey;
            }

            return valueForKey;
        }

        /// <summary>
        /// Searches dictionary with key as provided as well as key.ToLower()
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public static bool ContainsCaseInsensitiveKey(this Dictionary<string, string> dictionary, string keyName)
        {
            if (dictionary.ContainsKey(keyName))
            {
                return true;
            }
            if (dictionary.ContainsKey(keyName.ToLower()))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Updates the dictionary first by searching for key as provided then does a second pass for key.ToLower()
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="keyName"></param>
        /// <param name="value"></param>
        public static void UpdateDictionary(this Dictionary<string, string> dictionary, string keyName, string value)
        {
            if (dictionary.ContainsKey(keyName))
            {
                dictionary[keyName] = value;
            }
            else if (dictionary.ContainsKey(keyName.ToLower()))
            {
                dictionary[keyName.ToLower()] = value;
            }
        }

        /// <summary>
        /// Allows you to clear only values or key/value both
        /// </summary>
        /// <param name="dictionary">Dictionary<string,string> that to be cleared</param>
        /// <param name="clearValuesOnly">True: Clears only values, False: Clear keys and values</param>
        public static void Clear(this Dictionary<string, string> dictionary, bool clearValuesOnly)
        {
            //TODO: can be implemented for generic dictionary, but currently there is no requirement, else the overload
            //will be reflected for the entire solution for any kind of Dictionary, so currently only scoping to Dictionary<string,string>
            if (clearValuesOnly)
            {
                foreach (string key in dictionary.Keys.ToList<string>())
                {
                    dictionary[key] = string.Empty;
                }
            }
            else
            {
                dictionary.Clear();
            }
        }

        /// <summary>
        /// Creates comma seperated string of all EnvironmentNames enum values
        /// </summary>
        /// <param name="env"></param>
        /// <returns></returns>
        public static string ListValues(this EnvironmentNames env)
        {
            List<string> enumValues = (from ev in typeof(EnvironmentNames).GetMembers(BindingFlags.Public | BindingFlags.Static) select ev.Name).ToList();
            return string.Join(",", enumValues.Select((item) => item));
        }

        /// <summary>
        /// Checks if IEnumerable is null or empty
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static bool IsAny<T>(this IEnumerable<T> collection)
        {
            return (collection != null && collection.Any());
        }
    }
}
