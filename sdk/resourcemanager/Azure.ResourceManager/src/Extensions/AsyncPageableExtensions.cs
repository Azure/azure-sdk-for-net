// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Core.Extensions
{
    internal static class AsyncPageableExtensions
    {
        public static async Task<TSource> FirstOrDefaultAsync<TSource>(
            this AsyncPageable<TSource> source,
            Func<TSource, bool> predicate,
            CancellationToken token = default)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            token.ThrowIfCancellationRequested();

            await foreach (var item in source.ConfigureAwait(false))
            {
                token.ThrowIfCancellationRequested();

                if (predicate(item))
                {
                    return item;
                }
            }

            return default;
        }
    }
}
