// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Linq;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;

namespace Microsoft.Rest.Azure
{
    public static class SubscriptionClientExtensions
    {
        /// <summary>
        /// Get the client for managing subscriptions in the given context.
        /// </summary>
        /// <param name="context">The Azure context for the client to target.</param>
        /// <returns>The client for managing subscriptions in the given context</returns>
        private static ISubscriptionClient GetSubscriptionClient(this IAzureContext context)
        {
            return SubscriptionClient.CreateClient(context);
        }

        /// <summary>
        /// Get the operations for discovering subscriptions available in the given context.
        /// </summary>
        /// <param name="context">The context to target.</param>
        /// <returns>The operations for discovering subscriptions in the current context.</returns>
        public static ISubscriptionsOperations GetSubscriptionOperations(this IAzureContext context)
        {
            return context.GetSubscriptionClient().Subscriptions;
        }

        /// <summary>
        /// Get the operations for discovering tenants available in the given context.
        /// </summary>
        /// <param name="context">The context to target.</param>
        /// <returns>The operations for discovering tenants in the given context.</returns>
        public static ITenantsOperations GetTenantOperations(this IAzureContext context)
        {
            return context.GetSubscriptionClient().Tenants;
        }

        /// <summary>
        /// Set the subscription for the context using the provided subscription filter predicate.
        /// </summary>
        /// <param name="context">The context to use for clients.</param>
        /// <param name="subscriptionFilter">The subscription filter predicate to use to select a subscription.</param>
        /// <returns>True if a subscription met the filter criteria, or false if no subscriptions met it.</returns>
        public static void SetSubscription(this IAzureContext context, Func<Subscription, bool> subscriptionFilter)
        {
            var subscriptions = context.GetSubscriptionOperations();
            var selection = subscriptions.List().First(subscriptionFilter);
            context.SubscriptionId = selection.SubscriptionId;
            context.TenantId = selection.TenantId;
        }

        /// <summary>
        /// Set the subscription for the context using the provided subscription name or id.
        /// </summary>
        /// <param name="context">The context to use for clients.</param>
        /// <param name="subscription">The subscription name or id in azure for the subscription to be selected.</param>
        /// <returns>True if the subscription was successfully set, or false if no found subscriptiosn matched the given name.</returns>
        public static void SetSubscription(this IAzureContext context, string subscription)
        {
            Guid id;
            Func<Subscription, bool> filter =
                (s) => s.DisplayName.Equals(subscription, StringComparison.OrdinalIgnoreCase);
            if (Guid.TryParse(subscription, out id))
            {
                filter = (s) => s.SubscriptionId.Equals(subscription, StringComparison.OrdinalIgnoreCase);
            }
        }
    }
}
