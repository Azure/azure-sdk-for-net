// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager
{
    /// <summary>
    /// helper class
    /// </summary>
    internal static class SharedExtensions
    {
        /// <summary>
        /// Collects the segments in a resource identifier into a string
        /// </summary>
        /// <param name="resourceId">the resource identifier</param>
        /// <returns></returns>
        public static string SubstringAfterProviderNamespace(this ResourceIdentifier resourceId)
        {
            const string providersKey = "/providers/";
            var rawId = resourceId.ToString();
            var indexOfProviders = rawId.LastIndexOf(providersKey, StringComparison.InvariantCultureIgnoreCase);
            if (indexOfProviders < 0)
                return string.Empty;
            var whateverRemains = rawId.Substring(indexOfProviders + providersKey.Length);
            var firstSlashIndex = whateverRemains.IndexOf('/');
            if (firstSlashIndex < 0)
                return string.Empty;
            return whateverRemains.Substring(firstSlashIndex + 1);
        }

        /// <summary>
        /// An extension method for supporting replacing one dictionary content with another one.
        /// This is used to support resource tags.
        /// </summary>
        /// <param name="dest"> The destination dictionary in which the content will be replaced. </param>
        /// <param name="src"> The source dictionary from which the content is copied from. </param>
        /// <returns> The destination dictionary that has been altered. </returns>
        public static IDictionary<string, string> ReplaceWith(this IDictionary<string, string> dest, IDictionary<string, string> src)
        {
            dest.Clear();
            foreach (var kv in src)
            {
                dest.Add(kv);
            }

            return dest;
        }

        public static async Task<TSource?> FirstOrDefaultAsync<TSource>(
            this AsyncPageable<TSource> source,
            Func<TSource, bool> predicate,
            CancellationToken token = default)
            where TSource : notnull
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
