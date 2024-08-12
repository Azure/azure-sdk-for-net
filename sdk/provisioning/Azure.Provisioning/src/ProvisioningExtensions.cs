// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Provisioning
{
    /// <summary>
    /// Extension methods for <see cref="IConstruct"/>.
    /// </summary>
    public static class ProvisioningExtensions
    {
        /// <summary>
        /// Gets the single resource of type <typeparamref name="T"/> in the construct or its ancestors.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="Resource"/> to find.</typeparam>
        /// <param name="construct">The construct.</param>
        /// <returns>The <see cref="Resource"/> if found else null.</returns>
        public static T? GetSingleResource<T>(this IConstruct construct) where T : Resource
        {
            T? result = default;
            return GetSingleResourceUp(construct, result);
        }

        private static T? GetSingleResourceUp<T>(IConstruct? construct, T? result) where T : Resource
        {
            if (construct is null)
            {
                return result;
            }

            foreach (var child in construct.GetResources(false))
            {
                if (child is T t)
                {
                    if (result is not null)
                    {
                        throw new InvalidOperationException($"The construct has more than one {typeof(T).Name}. Please specify the {typeof(T).Name} to use.");
                    }
                    result = t;
                }
            }

            return GetSingleResourceUp(construct.Scope, result);
        }

        /// <summary>
        /// Gets the single resource of type <typeparamref name="T"/> in the construct or its childresources.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="Resource"/> to find.</typeparam>
        /// <param name="construct">The construct.</param>
        /// <returns>The <see cref="Resource"/> if found else null.</returns>
        public static T? GetSingleResourceInScope<T>(this IConstruct construct) where T : Resource
        {
            T? result = default;

            foreach (var child in construct.GetResources())
            {
                if (child is T t)
                {
                    if (result is not null)
                    {
                        throw new InvalidOperationException($"The construct has more than one {typeof(T).Name}. Please specify the {typeof(T).Name} to use.");
                    }
                    result = t;
                }
            }

            return result;
        }
    }
}
