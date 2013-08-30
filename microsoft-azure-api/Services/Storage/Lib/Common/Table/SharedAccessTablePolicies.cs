// -----------------------------------------------------------------------------------------
// <copyright file="SharedAccessTablePolicies.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Table
{
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Represents the collection of shared access policies defined for a table.
    /// </summary>
    [SuppressMessage(
        "Microsoft.Naming",
        "CA1710:IdentifiersShouldHaveCorrectSuffix",
        Justification = "Public APIs should not expose base collection types.")]
    public sealed class SharedAccessTablePolicies : IDictionary<string, SharedAccessTablePolicy>
    {
        private readonly Dictionary<string, SharedAccessTablePolicy> policies =
            new Dictionary<string, SharedAccessTablePolicy>();

        /// <summary>
        /// Adds the specified key and <see cref="SharedAccessTablePolicy"/> value to the collection of shared access policies.
        /// </summary>
        /// <param name="key">The key of the <see cref="SharedAccessTablePolicy"/> value to add.</param>
        /// <param name="value">The <see cref="SharedAccessTablePolicy"/> value to add to the collection of shared access policies.</param>
        public void Add(string key, SharedAccessTablePolicy value)
        {
            this.policies.Add(key, value);
        }

        /// <summary>
        /// Determines whether the collection of shared access policies contains the specified key.
        /// </summary>
        /// <param name="key">The key to locate in the collection of shared access policies.</param>
        /// <returns><c>true</c> if the collection of shared access policies contains an element with the specified key; otherwise, <c>false</c>.</returns>
        public bool ContainsKey(string key)
        {
            return this.policies.ContainsKey(key);
        }

        /// <summary>
        /// Gets a collection containing the keys in the shared access policies collection.
        /// </summary>
        /// <value>A collection containing the keys in the of shared access policies collection.</value>
        public ICollection<string> Keys
        {
            get { return this.policies.Keys; }
        }

        /// <summary>
        /// Removes the value with the specified key from the shared access policies collection.
        /// </summary>
        /// <param name="key">The key of the <see cref="SharedAccessTablePolicy"/> item to remove.</param>
        /// <returns><c>true</c> if the element is successfully found and removed; otherwise, <c>false</c>. This method returns <c>false</c> if the key is not found.</returns>
        public bool Remove(string key)
        {
            return this.policies.Remove(key);
        }

        /// <summary>
        /// Gets the <see cref="SharedAccessTablePolicy"/> item associated with the specified key. 
        /// </summary>
        /// <param name="key">The key of the value to get.</param>
        /// <param name="value">The <see cref="SharedAccessTablePolicy"/> item to get.</param>
        /// <returns>The <see cref="SharedAccessTablePolicy"/> item associated with the specified key, if the key is found; otherwise, the default value for the <see cref="SharedAccessTablePolicy"/> type.</returns>
        public bool TryGetValue(string key, out SharedAccessTablePolicy value)
        {
            return this.policies.TryGetValue(key, out value);
        }

        /// <summary>
        /// Gets a collection containing the values in the shared access policies collection.
        /// </summary>
        /// <value>A collection of <see cref="SharedAccessTablePolicy"/> items in the shared access policies collection.</value>
        public ICollection<SharedAccessTablePolicy> Values
        {
            get { return this.policies.Values; }
        }

        /// <summary>
        /// Gets or sets the <see cref="SharedAccessTablePolicy"/> item associated with the specified key.
        /// </summary>
        /// <param name="key">The key of the value to get or set.</param>
        /// <returns>The <see cref="SharedAccessTablePolicy"/> item associated with the specified key, or <c>null</c> if key is not in the shared access policies collection.</returns>
        public SharedAccessTablePolicy this[string key]
        {
            get { return this.policies[key]; }

            set { this.policies[key] = value; }
        }

        /// <summary>
        /// Adds the specified key/<see cref="SharedAccessTablePolicy"/> value, stored in a <see cref="KeyValuePair{TKey,TValue}"/>, to the collection of shared access policies.
        /// </summary>
        /// <param name="item">The <see cref="KeyValuePair{TKey,TValue}"/> object, containing a key/<see cref="SharedAccessTablePolicy"/> value pair, to add to the shared access policies collection.</param>
        public void Add(KeyValuePair<string, SharedAccessTablePolicy> item)
        {
            this.Add(item.Key, item.Value);
        }

        /// <summary>
        /// Removes all keys and <see cref="SharedAccessTablePolicy"/> values from the shared access collection.
        /// </summary>
        public void Clear()
        {
            this.policies.Clear();
        }

        /// <summary>
        /// Determines whether the collection of shared access policies contains the key and <see cref="SharedAccessTablePolicy"/> value in the specified <see cref="KeyValuePair{TKey,TValue}"/> object.
        /// </summary>
        /// <param name="item">A <see cref="KeyValuePair{TKey,TValue}"/> object containing the key and <see cref="SharedAccessTablePolicy"/> value to search for.</param>
        /// <returns><c>true</c> if the shared access policies collection contains the specified key/value; otherwise, <c>false</c>.</returns>
        public bool Contains(KeyValuePair<string, SharedAccessTablePolicy> item)
        {
            SharedAccessTablePolicy storedItem;
            if (this.TryGetValue(item.Key, out storedItem))
            {
                if (string.Equals(
                    SharedAccessTablePolicy.PermissionsToString(item.Value.Permissions),
                    SharedAccessTablePolicy.PermissionsToString(storedItem.Permissions),
                    StringComparison.Ordinal))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Copies each key/<see cref="SharedAccessTablePolicy"/> value pair in the shared access policies collection to a compatible one-dimensional array, starting at the specified index of the target array.
        /// </summary>
        /// <param name="array">The one-dimensional array of <see cref="SharedAccessTablePolicy"/> objects that is the destination of the elements copied from the shared access policies collection.</param>
        /// <param name="arrayIndex">The zero-based index in <paramref name="array"/> at which copying begins.</param>
        public void CopyTo(KeyValuePair<string, SharedAccessTablePolicy>[] array, int arrayIndex)
        {
            CommonUtility.AssertNotNull("array", array);

            foreach (KeyValuePair<string, SharedAccessTablePolicy> item in this.policies)
            {
                array[arrayIndex++] = item;
            }
        }

        /// <summary>
        /// Gets the number of key/<see cref="SharedAccessTablePolicy"/> value pairs contained in the shared access policies collection.
        /// </summary>
        /// <value>The number of key/<see cref="SharedAccessTablePolicy"/> value pairs contained in the shared access policies collection.</value>
        public int Count
        {
            get { return this.policies.Count; }
        }

        /// <summary>
        /// Gets a value indicating whether the collection of shared access policies is read-only. 
        /// </summary>
        /// <value><c>true</c> if the collection of shared access policies is read-only; otherwise, <c>false</c>.</value>
        public bool IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// Removes the <see cref="SharedAccessTablePolicy"/> value, specified in the <see cref="KeyValuePair{TKey,TValue}"/> object, from the shared access policies collection.
        /// </summary>
        /// <param name="item">The <see cref="KeyValuePair{TKey,TValue}"/> object, containing a key and <see cref="SharedAccessTablePolicy"/> value, to remove from the shared access policies collection.</param>
        /// <returns><c>true</c> if the item was successfully removed; otherwise, <c>false</c>.</returns>
        public bool Remove(KeyValuePair<string, SharedAccessTablePolicy> item)
        {
            if (this.Contains(item))
            {
                return this.Remove(item.Key);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection of shared access policies.
        /// </summary>
        /// <returns>An <see cref="IEnumerator{T}"/> of type <see cref="KeyValuePair{TKey,TValue}"/>.</returns>
        public IEnumerator<KeyValuePair<string, SharedAccessTablePolicy>> GetEnumerator()
        {
            return this.policies.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection of shared access policies.
        /// </summary>
        /// <returns>An <see cref="System.Collections.IEnumerator"/> object that can be used to iterate through the collection of shared access policies.</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            System.Collections.IEnumerable enumerable = this.policies;
            return enumerable.GetEnumerator();
        }
    }
}