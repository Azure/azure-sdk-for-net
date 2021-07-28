// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// helper class
    /// </summary>
    internal static class SharedExtensions
    {
        /// <summary>
        /// Add a provider resource to an existing resource id.
        /// </summary>
        /// <param name="identifier"> The id to append to. </param>
        /// <param name="providerNamespace"> The provider namespace of the added resource. </param>
        /// <param name="resourceType"> The simple type of the added resource, without slashes (/),
        /// for example, 'virtualMachines'. </param>
        /// <param name="resourceName"> The name of the resource.</param>
        /// <returns> The combined resource id. </returns>
        public static ResourceIdentifier AppendProviderResource(this ResourceIdentifier identifier, string providerNamespace, string resourceType, string resourceName)
        {
            ValidateProviderResourceParameters(providerNamespace, resourceType, resourceName);
            return new ResourceIdentifier(identifier, providerNamespace, resourceType, resourceName);
        }

        /// <summary>
        /// Add a provider resource to an existing resource id.
        /// </summary>
        /// <param name="identifier"> The id to append to. </param>
        /// <param name="childResourceType"> The simple type of the child resource, without slashes (/),
        /// for example, 'subnets'. </param>
        /// <param name="childResourceName"> The name of the resource. </param>
        /// <returns> The combined resource id. </returns>
        public static ResourceIdentifier AppendChildResource(this ResourceIdentifier identifier, string childResourceType, string childResourceName)
        {
            ValidateChildResourceParameters(childResourceType, childResourceName);
            return new ResourceIdentifier(identifier, childResourceType, childResourceName);
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
                dest.Add(kv.Key, kv.Value);
            }

            return dest;
        }

        public static List<T> Trim<T>(this List<T> list, int numberToTrim)
        {
            if (list is null)
                throw new ArgumentNullException(nameof(list));
            if (numberToTrim < 0 || numberToTrim > list.Count)
                throw new ArgumentOutOfRangeException(nameof(numberToTrim));
            list.RemoveRange(0, numberToTrim);
            return list;
        }

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

        private static void ValidateProviderResourceParameters(string providerNamespace, string resourceType, string resourceName)
        {
            ValidatePathSegment(providerNamespace, nameof(providerNamespace));
            ValidatePathSegment(resourceType, nameof(resourceType));
            ValidatePathSegment(resourceName, nameof(resourceName));
        }

        private static void ValidateChildResourceParameters(string childResourceType, string childResourceName)
        {
            ValidatePathSegment(childResourceType, nameof(childResourceType));
            ValidatePathSegment(childResourceName, nameof(childResourceName));
        }

        private static void ValidatePathSegment(string segment, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(segment))
                throw new ArgumentNullException(parameterName);
            if (segment.Contains("/"))
                throw new ArgumentOutOfRangeException(parameterName, $"{parameterName} must be a single path segment");
        }
    }
}
