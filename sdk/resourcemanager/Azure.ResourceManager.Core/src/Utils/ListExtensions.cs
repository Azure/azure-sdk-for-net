// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.ResourceManager.Core
{
    internal static class ListExtensions
    {
        /// <summary>
        /// Trims the first n elements from a list, and returns the altered list.
        /// </summary>
        /// <typeparam name="T"> The type of element in the list.</typeparam>
        /// <param name="list"> The list to trim.</param>
        /// <param name="numberToTrim"> The number of elements to remove from the front of the list.</param>
        /// <returns> The altered input list.</returns>
        internal static List<T> Trim<T>(this List<T> list, int numberToTrim)
        {
            if (list is null)
                throw new ArgumentNullException(nameof(list));
            if (numberToTrim < 0 || numberToTrim > list.Count)
                throw new ArgumentOutOfRangeException(nameof(numberToTrim));
            list.RemoveRange(0, numberToTrim);
            return list;
        }
    }
}
