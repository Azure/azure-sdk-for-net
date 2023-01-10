// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Core
{
    /// <summary>
    /// A property bag which is optimized for storage of a small number of items.
    /// If the item count is less than 2, there are no allocations. Any additional items are stored in an array which will grow as needed.
    /// </summary>
    internal class ArrayBackedPropertyBag<TKey, TValue> where TKey : IEquatable<TKey>
    {
        private int _totalCount;
        private int _arrayCount;
        private (TKey Key, TValue Value)[]? _array;
        private TKey? _key1, _key2;
        private TValue? _value1, _value2;

        /// <summary>
        /// Adds a value to the property bag.
        /// </summary>
        /// <param name="key">The key of the value to add.</param>
        /// <param name="value">The value to add.</param>
        public void Add(TKey key, TValue value)
        {
            Argument.AssertNotNull(key, nameof(key));

            bool duplicateKeyDetected = false;
            switch (_totalCount)
            {
                case 0:
                    _key1 = key;
                    _value1 = value;
                    break;

                case 1:
                    if (EqualityComparer<TKey>.Default.Equals(key, _key1!))
                    {
                        duplicateKeyDetected = true;
                        _value1 = value;
                        break;
                    }
                    _key2 = key;
                    _value2 = value;
                    break;

                default:
                    if (EqualityComparer<TKey>.Default.Equals(key, _key1!))
                    {
                        duplicateKeyDetected = true;
                        _value1 = value;
                        break;
                    }
                    if (EqualityComparer<TKey>.Default.Equals(key, _key2!))
                    {
                        duplicateKeyDetected = true;
                        _value2 = value;
                        break;
                    }
                    _array ??= new (TKey Key, TValue Value)[8];
                    if (_arrayCount >= _array.Length)
                    {
                        // The array must be re-sized
                        (TKey Key, TValue Value)[] newItems = new (TKey Key, TValue Value)[_array.Length * 2];
                        Array.Copy(_array, newItems, _array.Length);
                        _array = newItems;
                    }
                    _array[_arrayCount] = new(key, value);
                    _arrayCount++;
                    break;
            }
            if (!duplicateKeyDetected)
            {
                _totalCount++;
            }
        }

        /// <summary>
        /// Gets a value from the property bag.
        /// </summary>
        /// <param name="key">The key of the item to get.</param>
        /// <param name="value">The out parameter that will store the value, if found.</param>
        /// <returns><c>true</c> if found, else <c>false</c>.</returns>
        public bool TryGetValue(TKey key, out TValue? value)
        {
            Argument.AssertNotNull(key, nameof(key));

            switch (_totalCount)
            {
                case 0:
                    value = default;
                    return false;

                case 1:
                    if (EqualityComparer<TKey>.Default.Equals(key, _key1!))
                    {
                        value = _value1;
                        return true;
                    }

                    value = default;
                    return false;

                default:
                    if (EqualityComparer<TKey>.Default.Equals(key, _key1!))
                    {
                        value = _value1;
                        return true;
                    }

                    if (EqualityComparer<TKey>.Default.Equals(key, _key2!))
                    {
                        value = _value2;
                        return true;
                    }

                    if (_array == null)
                    {
                        value = default;
                        return false;
                    }

                    // search the array in reverse to favor the last item added in the case of duplicate keys.
                    for (int i = _arrayCount - 1; i >= 0; i--)
                    {
                        if (EqualityComparer<TKey>.Default.Equals(key, _array[i].Key))
                        {
                            value = _array[i].Value;
                            return true;
                        }
                    }

                    value = default;
                    return false;
            }
        }
    }
}
