// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Defines extension methods for IEnumerable that are used in the implementation of the Azure Cognitive Search
    /// .NET SDK.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Converts the elements of a collection to strings and concatenates them into a comma-separated list,
        /// or returns null for null or empty collections.
        /// </summary>
        /// <typeparam name="T">The type of elements that will be converted to strings.</typeparam>
        /// <param name="enumerable">The collection to turn into a comma-separated string.</param>
        /// <returns>A comma-separated string, or null if enumerable is null or empty.</returns>
        public static string ToCommaSeparatedString<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable == null || !enumerable.Any())
            {
                return null;
            }

            return String.Join(",", enumerable);
        }
    }
}
