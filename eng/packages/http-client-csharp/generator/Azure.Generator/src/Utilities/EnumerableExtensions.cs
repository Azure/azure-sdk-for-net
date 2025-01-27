// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Generator.Utilities
{
    internal static class EnumerableExtensions
    {
        public static IEnumerable<T> AsIEnumerable<T>(this T item)
        {
            yield return item;
        }
    }
}
