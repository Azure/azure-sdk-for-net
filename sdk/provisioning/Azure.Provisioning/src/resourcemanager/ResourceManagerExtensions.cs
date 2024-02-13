// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Provisioning.ResourceManager
{
    /// <summary>
    /// Extension methods for <see cref="IConstruct"/>.
    /// </summary>
    public static class ResourceManagerExtensions
    {
        /// <summary>
        /// Adds a resource group to the construct.
        /// </summary>
        /// <param name="construct">The construct.</param>
        /// <returns>The see <see cref="ResourceGroup"/>.</returns>
        /// <exception cref="InvalidOperationException">If the construct already has a <see cref="ResourceGroup"/>.</exception>
        public static ResourceGroup AddResourceGroup(this IConstruct construct)
        {
            if (construct.ResourceGroup is not null)
            {
                throw new InvalidOperationException("ResourceGroup already exists on the construct");
            }

            return new ResourceGroup(construct, "rg");
        }

        /// <summary>
        /// Gets or adds a resource group to the construct.
        /// </summary>
        /// <param name="construct">The construct.</param>
        /// <returns>The see <see cref="ResourceGroup"/>.</returns>
        public static ResourceGroup GetOrAddResourceGroup(this IConstruct construct)
        {
            return construct.ResourceGroup ?? construct.GetSingleResource<ResourceGroup>() ?? construct.AddResourceGroup();
        }

        /// <summary>
        /// Gets or adds a subscription to the construct.
        /// </summary>
        /// <param name="construct">The construct</param>
        /// <param name="subscriptionId">The id of the subscription.</param>
        /// <returns>The see <see cref="Subscription"/>.</returns>
        public static Subscription GetOrCreateSubscription(this IConstruct construct, Guid? subscriptionId = null)
        {
            return construct.Subscription ?? construct.GetSingleResource<Subscription>() ?? new Subscription(construct, subscriptionId);
        }
    }
}
