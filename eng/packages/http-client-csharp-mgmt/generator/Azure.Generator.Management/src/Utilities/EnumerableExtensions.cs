// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Generator.Management.Utilities
{
    internal static class EnumerableExtensions
    {
        public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T?> source) where T : notnull
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            return source.Where(item => item is not null)!;
        }
    }
}
