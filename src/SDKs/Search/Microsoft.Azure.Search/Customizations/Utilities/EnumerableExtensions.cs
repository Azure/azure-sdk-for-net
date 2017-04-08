// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace System.Collections.Generic
{
    using System.Linq;

    internal static class EnumerableExtensions
    {
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
