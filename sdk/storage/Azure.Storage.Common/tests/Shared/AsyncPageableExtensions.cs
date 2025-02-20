// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Storage.Tests
{
    internal static class AsyncPageableExtensions
    {
        public static AsyncPageable<T> AsAsyncPageable<T>(this IEnumerable<T> items, int pageLimit = int.MaxValue)
        {
            List<Page<T>> pages = new(items.AsPages(pageLimit)); // FromPages wants an IReadOnlyList
            return AsyncPageable<T>.FromPages(pages);
        }

        public static IEnumerable<Page<T>> AsPages<T>(this IEnumerable<T> items, int pageLimit = int.MaxValue)
        {
            List<T> current = new();
            foreach (T item in items)
            {
                current.Add(item);
                if (current.Count == pageLimit)
                {
                    yield return Page<T>.FromValues(current, null, null);
                    current = new();
                }
            }
            if (current.Count > 0)
            {
                yield return Page<T>.FromValues(current, null, null);
            }
        }
    }
}
