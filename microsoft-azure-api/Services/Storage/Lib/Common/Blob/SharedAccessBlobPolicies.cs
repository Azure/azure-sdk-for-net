//-----------------------------------------------------------------------
// <copyright file="SharedAccessBlobPolicies.cs" company="Microsoft">
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
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Blob
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents the collection of shared access policies defined for a container.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Microsoft.Naming",
        "CA1710:IdentifiersShouldHaveCorrectSuffix",
        Justification = "Public APIs should not expose base collection types.")]
    public sealed class SharedAccessBlobPolicies : IDictionary<string, SharedAccessBlobPolicy>
    {
        private Dictionary<string, SharedAccessBlobPolicy> policies =
            new Dictionary<string, SharedAccessBlobPolicy>();

        /// <summary>
        /// Adds the specified key and <see cref="SharedAccessBlobPolicy"/> value to the collection of shared access policies.
        /// </summary>
        /// <param name="key">The key of the <see cref="SharedAccessBlobPolicy"/> value to add.</param>
        /// <param name="value">The <see cref="SharedAccessBlobPolicy"/> value to add the collection of shared access policies.</param>
        public void Add(string key, SharedAccessBlobPolicy value)
        {
            this.policies.Add(key, value);
        }

        /// <summary>
        /// Determines whether the collection of shared access policies contains the specified key.
        /// </summary>
        /// <param name="key">The key to locate in the collection of shared access policies.</param>
        /// <returns><code>true</code> if the collection of shared access policies contains an element with the specified key; otherwise, <code>false</code>.</returns>
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
            get
            {
                return this.policies.Keys;
            }
        }

        /// <summary>
        /// Removes the value with the specified key from the shared access policies collection.
        /// </summary>
        /// <param name="key">The key of the <see cref="SharedAccessBlobPolicy"/> item to remove.</param>
        /// <returns><code>true</code> if the element is successfully found and removed; otherwise, <code>false</code>. This method returns <code>false</code> if the key is not found.</returns>
        public bool Remove(string key)
        {
            return this.policies.Remove(key);
        }

        /// <summary>
        /// Gets the <see cref="SharedAccessBlobPolicy"/> item associated with the specified key. 
        /// </summary>
        /// <param name="key">The key of the value to get.</param>
        /// <param name="value">The <see cref="SharedAccessBlobPolicy"/> item to get.</param>
        /// <returns>The <see cref="SharedAccessBlobPolicy"/> item associated with the specified key, if the key is found; otherwise, the default value for the <see cref="SharedAccessBlobPolicy"/> type.</returns>
        public bool TryGetValue(string key, out SharedAccessBlobPolicy value)
        {
            return this.policies.TryGetValue(key, out value);
        }

        /// <summary>
        /// Gets a collection containing the values in the shared access policies collection.
        /// </summary>
        /// <value>A collection of <see cref="SharedAccessBlobPolicy"/> items in the shared access policies collection.</value>
        public ICollection<SharedAccessBlobPolicy> Values
        {
            get
            {
                return this.policies.Values;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="SharedAccessBlobPolicy"/> item associated with the specified key.
        /// </summary>
        /// <param name="key">The key of the <see cref="SharedAccessBlobPolicy"/> value to get or set.</param>
        /// <returns>The <see cref="SharedAccessBlobPolicy"/> item associated with the specified key, or <code>null</code> if key is not in the shared access policies collection.</returns>
        public SharedAccessBlobPolicy this[string key]
        {
            get
            {
                return this.policies[key];
            }

            set
            {
                this.policies[key] = value;
            }
        }

        /// <summary>
        /// Adds the specified key/<see cref="SharedAccessBlobPolicy"/> value, stored in a <see cref="KeyValuePair{TKey,TValue}"/>, to the collection of shared access policies.
        /// </summary>
        /// <param name="item">The <see cref="KeyValuePair{TKey,TValue}"/> object, containing a key/<see cref="SharedAccessBlobPolicy"/> value pair, to add to the shared access policies collection.</param>
        public void Add(KeyValuePair<string, SharedAccessBlobPolicy> item)
        {
            this.Add(item.Key, item.Value);
        }

        /// <summary>
        /// Removes all keys and <see cref="SharedAccessBlobPolicy"/> values from the shared access collection.
        /// </summary>
        public void Clear()
        {
            this.policies.Clear();
        }

        /// <summary>
        /// Determines whether the collection of shared access policies contains the key and <see cref="SharedAccessBlobPolicy"/> value in the specified <see cref="KeyValuePair{TKey,TValue}"/> object.
        /// </summary>
        /// <param name="item">A <see cref="KeyValuePair{TKey,TValue}"/> object containing the key and <see cref="SharedAccessBlobPolicy"/> value to search for.</param>
        /// <returns><code>true</code> if the shared access policies collection contains the specified key/value; otherwise, <code>false</code>.</returns>
        public bool Contains(KeyValuePair<string, SharedAccessBlobPolicy> item)
        {
            SharedAccessBlobPolicy storedItem;
            if (this.TryGetValue(item.Key, out storedItem))
            {
                if (string.Equals(
                    SharedAccessBlobPolicy.PermissionsToString(item.Value.Permissions),
                    SharedAccessBlobPolicy.PermissionsToString(storedItem.Permissions),
                    StringComparison.Ordinal))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Copies each key/<see cref="SharedAccessBlobPolicy"/> value pair in the shared access policies collection to a compatible one-dimensional array, starting at the specified index of the target array.
        /// </summary>
        /// <param name="array">The one-dimensional array of <see cref="SharedAccessBlobPolicy"/> objects that is the destination of the elements copied from the shared access policies collection.</param>
        /// <param name="arrayIndex">The zero-based index in <paramref name="array"/> at which copying begins.</param>
        public void CopyTo(KeyValuePair<string, SharedAccessBlobPolicy>[] array, int arrayIndex)
        {
            foreach (KeyValuePair<string, SharedAccessBlobPolicy> item in this.policies)
            {
                array[arrayIndex++] = item;
            }
        }

        /// <summary>
        /// Gets the number of key/<see cref="SharedAccessBlobPolicy"/> value pairs contained in the shared access policies collection.
        /// </summary>
        /// <value>The number of key/<see cref="SharedAccessBlobPolicy"/> value pairs contained in the shared access policies collection.</value>
        public int Count
        {
            get
            {
                return this.policies.Count;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the collection of shared access policies is read-only. 
        /// </summary>
        /// <value><code>true</code> if the collection of shared access policies is read-only; otherwise, <code>false</code>.</value>
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Removes the <see cref="SharedAccessBlobPolicy"/> value, specified in the <see cref="KeyValuePair{TKey,TValue}"/> object, from the shared access policies collection.
        /// </summary>
        /// <param name="item">The <see cref="KeyValuePair{TKey,TValue}"/> object, containing a key and <see cref="SharedAccessBlobPolicy"/> value, to remove from the shared access policies collection.</param>
        /// <returns><code>true</code> if the item was successfully removed; otherwise, <code>false</code>.</returns>
        public bool Remove(KeyValuePair<string, SharedAccessBlobPolicy> item)
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
        public IEnumerator<KeyValuePair<string, SharedAccessBlobPolicy>> GetEnumerator()
        {
            return this.policies.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection of shared access policies.
        /// </summary>
        /// <returns>An <see cref="IEnumerator"/> object that can be used to iterate through the collection of shared access policies.</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            System.Collections.IEnumerable enumerable = this.policies;
            return enumerable.GetEnumerator();
        }
    }
}