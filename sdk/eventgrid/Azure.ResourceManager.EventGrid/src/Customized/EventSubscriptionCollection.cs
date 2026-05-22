// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Azure;
using Azure.Core;

namespace Azure.ResourceManager.EventGrid
{
    // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/59358
    // (Mgmt CodeGen scope-binding regression: the legacy EventSubscriptionCollection
    // emitted scope-less GetAll(filter, top, ct) by binding all five route segments
    // from the collection's scope Id at construction time. The new MPG generator
    // emits GetAll(rg, ns, type, name, subscriptionId, filter, top, ct) without that
    // binding. Restore the back-compat shape here by parsing the scope Id segments;
    // the collection is only constructed via ArmClient.GetEventSubscriptions(scope)
    // on a resource scope, so the route can always be derived from Id.)
    public partial class EventSubscriptionCollection : IEnumerable<EventSubscriptionResource>, IAsyncEnumerable<EventSubscriptionResource>
    {
        /// <summary> List all event subscriptions in the scope this collection was created against. </summary>
        /// <param name="filter"> OData filter expression. </param>
        /// <param name="top"> Number of results per page (1-100, default 20). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<EventSubscriptionResource> GetAllAsync(string filter = default, int? top = default, CancellationToken cancellationToken = default)
        {
            (string resourceGroupName, string providerNamespace, string resourceTypeName, string resourceName, Guid subscriptionId) = ParseScope(Id);
            return GetAllAsync(resourceGroupName, providerNamespace, resourceTypeName, resourceName, subscriptionId, filter, top, cancellationToken);
        }

        /// <summary> List all event subscriptions in the scope this collection was created against. </summary>
        /// <param name="filter"> OData filter expression. </param>
        /// <param name="top"> Number of results per page (1-100, default 20). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<EventSubscriptionResource> GetAll(string filter = default, int? top = default, CancellationToken cancellationToken = default)
        {
            (string resourceGroupName, string providerNamespace, string resourceTypeName, string resourceName, Guid subscriptionId) = ParseScope(Id);
            return GetAll(resourceGroupName, providerNamespace, resourceTypeName, resourceName, subscriptionId, filter, top, cancellationToken);
        }

        IEnumerator<EventSubscriptionResource> IEnumerable<EventSubscriptionResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<EventSubscriptionResource> IAsyncEnumerable<EventSubscriptionResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }

        private static (string ResourceGroupName, string ProviderNamespace, string ResourceTypeName, string ResourceName, Guid SubscriptionId) ParseScope(ResourceIdentifier scope)
        {
            if (scope == null)
            {
                throw new InvalidOperationException("EventSubscriptionCollection has no scope identifier.");
            }
            if (string.IsNullOrEmpty(scope.SubscriptionId))
            {
                throw new InvalidOperationException($"EventSubscriptionCollection scope '{scope}' is not within a subscription; the back-compat GetAll(filter, top, ct) overload requires a resource scope. Use the scope-specific extensions for tenant/subscription/resource-group-scoped listings.");
            }
            if (string.IsNullOrEmpty(scope.ResourceGroupName))
            {
                throw new InvalidOperationException($"EventSubscriptionCollection scope '{scope}' is not within a resource group; the back-compat GetAll(filter, top, ct) overload requires a resource scope. Use the scope-specific extensions for tenant/subscription/resource-group-scoped listings.");
            }
            string providerNamespace = scope.ResourceType.Namespace;
            string resourceTypeName = scope.ResourceType.GetLastType();
            if (string.IsNullOrEmpty(providerNamespace) || string.IsNullOrEmpty(resourceTypeName) || string.IsNullOrEmpty(scope.Name))
            {
                throw new InvalidOperationException($"EventSubscriptionCollection scope '{scope}' is not within a provider resource; the back-compat GetAll(filter, top, ct) overload requires a resource scope. Use the scope-specific extensions for tenant/subscription/resource-group-scoped listings.");
            }
            return (scope.ResourceGroupName, providerNamespace, resourceTypeName, scope.Name, Guid.Parse(scope.SubscriptionId));
        }
    }
}
