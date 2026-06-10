// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Azure;
using Azure.Core;
using Azure.ResourceManager.EventGrid.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.EventGrid
{
    // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/59358
    // (Mgmt CodeGen scope-binding regression: the legacy EventSubscriptionCollection
    // emitted scope-less GetAll(filter, top, ct) by binding all five route segments
    // from the collection's scope Id at construction time. The new MPG generator
    // emits GetAll(rg, ns, type, name, subscriptionId, filter, top, ct) without that
    // binding. Restore the back-compat shape here by parsing the scope Id segments
    // and dispatching to the appropriate scope-specific listing.)
    public partial class EventSubscriptionCollection : IEnumerable<EventSubscriptionResource>, IAsyncEnumerable<EventSubscriptionResource>
    {
        /// <summary> List all event subscriptions in the scope this collection was created against. </summary>
        /// <param name="filter"> OData filter expression. </param>
        /// <param name="top"> Number of results per page (1-100, default 20). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual AsyncPageable<EventSubscriptionResource> GetAllAsync(string filter = default, int? top = default, CancellationToken cancellationToken = default)
        {
            ScopeKind kind = ClassifyScope(Id, out string resourceGroupName, out string providerNamespace, out string resourceTypeName, out string resourceName, out string parentResourceName, out Guid subscriptionId);
            switch (kind)
            {
                case ScopeKind.Subscription:
                    return Client.GetSubscriptionResource(SubscriptionResource.CreateResourceIdentifier(subscriptionId.ToString())).GetEventSubscriptionsAsync(filter, top, cancellationToken);
                case ScopeKind.ResourceGroup:
                    return Client.GetResourceGroupResource(ResourceGroupResource.CreateResourceIdentifier(subscriptionId.ToString(), resourceGroupName)).GetEventSubscriptionsAsync(filter, top, cancellationToken);
                case ScopeKind.DomainTopic:
                    return new AsyncPageableWrapper<EventGridSubscriptionData, EventSubscriptionResource>(
                        new EventSubscriptionsGetByDomainTopicAsyncCollectionResultOfT(
                            _eventSubscriptionsRestClient,
                            subscriptionId,
                            resourceGroupName,
                            parentResourceName,
                            resourceName,
                            filter,
                            top,
                            new RequestContext { CancellationToken = cancellationToken },
                            "EventSubscriptionCollection.GetAll"),
                        data => new EventSubscriptionResource(Client, data));
                default:
                    return GetAllAsync(resourceGroupName, providerNamespace, resourceTypeName, resourceName, subscriptionId, filter, top, cancellationToken);
            }
        }

        /// <summary> List all event subscriptions in the scope this collection was created against. </summary>
        /// <param name="filter"> OData filter expression. </param>
        /// <param name="top"> Number of results per page (1-100, default 20). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual Pageable<EventSubscriptionResource> GetAll(string filter = default, int? top = default, CancellationToken cancellationToken = default)
        {
            ScopeKind kind = ClassifyScope(Id, out string resourceGroupName, out string providerNamespace, out string resourceTypeName, out string resourceName, out string parentResourceName, out Guid subscriptionId);
            switch (kind)
            {
                case ScopeKind.Subscription:
                    return Client.GetSubscriptionResource(SubscriptionResource.CreateResourceIdentifier(subscriptionId.ToString())).GetEventSubscriptions(filter, top, cancellationToken);
                case ScopeKind.ResourceGroup:
                    return Client.GetResourceGroupResource(ResourceGroupResource.CreateResourceIdentifier(subscriptionId.ToString(), resourceGroupName)).GetEventSubscriptions(filter, top, cancellationToken);
                case ScopeKind.DomainTopic:
                    return new PageableWrapper<EventGridSubscriptionData, EventSubscriptionResource>(
                        new EventSubscriptionsGetByDomainTopicCollectionResultOfT(
                            _eventSubscriptionsRestClient,
                            subscriptionId,
                            resourceGroupName,
                            parentResourceName,
                            resourceName,
                            filter,
                            top,
                            new RequestContext { CancellationToken = cancellationToken },
                            "EventSubscriptionCollection.GetAll"),
                        data => new EventSubscriptionResource(Client, data));
                default:
                    return GetAll(resourceGroupName, providerNamespace, resourceTypeName, resourceName, subscriptionId, filter, top, cancellationToken);
            }
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

        private enum ScopeKind { Subscription, ResourceGroup, DomainTopic, Resource }

        private static ScopeKind ClassifyScope(ResourceIdentifier scope, out string resourceGroupName, out string providerNamespace, out string resourceTypeName, out string resourceName, out string parentResourceName, out Guid subscriptionId)
        {
            parentResourceName = null;
            if (scope == null)
            {
                throw new InvalidOperationException("EventSubscriptionCollection has no scope identifier.");
            }
            if (string.IsNullOrEmpty(scope.SubscriptionId))
            {
                throw new InvalidOperationException($"EventSubscriptionCollection scope '{scope}' is not within a subscription; the back-compat GetAll(filter, top, ct) overload requires at least a subscription scope.");
            }
            subscriptionId = Guid.Parse(scope.SubscriptionId);
            resourceGroupName = scope.ResourceGroupName;
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                providerNamespace = null;
                resourceTypeName = null;
                resourceName = null;
                return ScopeKind.Subscription;
            }
            providerNamespace = scope.ResourceType.Namespace;
            resourceTypeName = scope.ResourceType.GetLastType();
            resourceName = scope.Name;
            if (string.IsNullOrEmpty(providerNamespace) || string.IsNullOrEmpty(resourceTypeName) || string.IsNullOrEmpty(resourceName)
                || string.Equals(scope.ResourceType, ResourceGroupResource.ResourceType, StringComparison.OrdinalIgnoreCase))
            {
                providerNamespace = null;
                resourceTypeName = null;
                resourceName = null;
                return ScopeKind.ResourceGroup;
            }
            if (string.Equals(scope.ResourceType, DomainTopicResource.ResourceType, StringComparison.OrdinalIgnoreCase) && scope.Parent != null)
            {
                parentResourceName = scope.Parent.Name;
                return ScopeKind.DomainTopic;
            }
            return ScopeKind.Resource;
        }
    }
}
