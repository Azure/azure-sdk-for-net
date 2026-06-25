// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// SDK customization: scope-dispatched EventSubscriptionCollection.GetAll(...).
//
// WHY THIS CUSTOMIZATION EXISTS:
// On main, the (old) generator collapses FOUR event-subscription list routes into one
// scope-dispatched EventSubscriptionCollection.GetAll that branches on the parent resource
// type (SubscriptionResource -> ListGlobalBySubscription, ResourceGroupResource ->
// ListGlobalByResourceGroup, DomainTopicResource -> ListByDomainTopic, any other scope ->
// ListByResource). The new mgmt generator does NOT support that multi-route "scope
// collection" collapse: the generated EventSubscriptionCollection only emits
// Get/Exists/CreateOrUpdate/GetIfExists and no GetAll. This file hand-builds the same
// scope-dispatch GetAll so the public API matches main (no regression).
//
// Paired spec-side changes in csharp-customizations.tsp keep the rest of the surface aligned:
//   - EventSubscriptions.listByDomainTopic is scoped out of C# (@@scope "!csharp") because
//     the DomainTopicResource branch below delegates to the GENERATED
//     DomainTopicEventSubscriptionCollection.GetAll instead of that op's plumbing.
//   - EventSubscriptionOperationGroup.listByResource is internalized (@@access internal)
//     because the default scope branch below reuses its GENERATED
//     EventSubscriptionsGetByResource*CollectionResultOfT plumbing; internalizing it only
//     removes the duplicate public MockableEventGridArmClient.GetByResource* method.
// Both ops would otherwise generate EXTRA public methods that do not exist on main.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Azure;
using Azure.ResourceManager.EventGrid.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.EventGrid
{
    public partial class EventSubscriptionCollection : IEnumerable<EventSubscriptionResource>, IAsyncEnumerable<EventSubscriptionResource>
    {
        /// <summary>
        /// List all event subscriptions that have been created for the current scope.
        /// </summary>
        /// <param name="filter"> The query used to filter the search results using OData syntax. </param>
        /// <param name="top"> The number of results to return per page for the list operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<EventSubscriptionResource> GetAllAsync(string filter = default, int? top = default, CancellationToken cancellationToken = default)
        {
            if (Id.ResourceType == DomainTopicResource.ResourceType)
            {
                DomainTopicEventSubscriptionCollection domainTopicCollection = new DomainTopicEventSubscriptionCollection(Client, Id);
                return new AsyncPageableWrapper<DomainTopicEventSubscriptionResource, EventSubscriptionResource>(
                    domainTopicCollection.GetAllAsync(filter, top, cancellationToken),
                    resource => new EventSubscriptionResource(Client, resource.Data));
            }

            return new AsyncPageableWrapper<EventGridSubscriptionData, EventSubscriptionResource>(
                GetAllDataAsync(filter, top, cancellationToken),
                data => new EventSubscriptionResource(Client, data));
        }

        /// <summary>
        /// List all event subscriptions that have been created for the current scope.
        /// </summary>
        /// <param name="filter"> The query used to filter the search results using OData syntax. </param>
        /// <param name="top"> The number of results to return per page for the list operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<EventSubscriptionResource> GetAll(string filter = default, int? top = default, CancellationToken cancellationToken = default)
        {
            if (Id.ResourceType == DomainTopicResource.ResourceType)
            {
                DomainTopicEventSubscriptionCollection domainTopicCollection = new DomainTopicEventSubscriptionCollection(Client, Id);
                return new PageableWrapper<DomainTopicEventSubscriptionResource, EventSubscriptionResource>(
                    domainTopicCollection.GetAll(filter, top, cancellationToken),
                    resource => new EventSubscriptionResource(Client, resource.Data));
            }

            return new PageableWrapper<EventGridSubscriptionData, EventSubscriptionResource>(
                GetAllData(filter, top, cancellationToken),
                data => new EventSubscriptionResource(Client, data));
        }

        IEnumerator<EventSubscriptionResource> IEnumerable<EventSubscriptionResource>.GetEnumerator() => GetAll().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetAll().GetEnumerator();

        IAsyncEnumerator<EventSubscriptionResource> IAsyncEnumerable<EventSubscriptionResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
            => GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);

        private AsyncPageable<EventGridSubscriptionData> GetAllDataAsync(string filter, int? top, CancellationToken cancellationToken)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };

            if (Id.ResourceType == SubscriptionResource.ResourceType)
            {
                return new EventSubscriptionsGetGlobalBySubscriptionAsyncCollectionResultOfT(
                    _eventSubscriptionsRestClient,
                    Guid.Parse(Id.SubscriptionId),
                    filter,
                    top,
                    context,
                    "EventSubscriptionCollection.GetAll");
            }

            if (Id.ResourceType == ResourceGroupResource.ResourceType)
            {
                return new EventSubscriptionsGetGlobalByResourceGroupAsyncCollectionResultOfT(
                    _eventSubscriptionsRestClient,
                    Guid.Parse(Id.SubscriptionId),
                    Id.ResourceGroupName,
                    filter,
                    top,
                    context,
                    "EventSubscriptionCollection.GetAll");
            }

            return new EventSubscriptionsGetByResourceAsyncCollectionResultOfT(
                _eventSubscriptionsRestClient,
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                Id.ResourceType.Namespace,
                GetLastResourceTypeSegment(Id.ResourceType.Type),
                Id.Name,
                filter,
                top,
                context,
                "EventSubscriptionCollection.GetAll");
        }

        private Pageable<EventGridSubscriptionData> GetAllData(string filter, int? top, CancellationToken cancellationToken)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };

            if (Id.ResourceType == SubscriptionResource.ResourceType)
            {
                return new EventSubscriptionsGetGlobalBySubscriptionCollectionResultOfT(
                    _eventSubscriptionsRestClient,
                    Guid.Parse(Id.SubscriptionId),
                    filter,
                    top,
                    context,
                    "EventSubscriptionCollection.GetAll");
            }

            if (Id.ResourceType == ResourceGroupResource.ResourceType)
            {
                return new EventSubscriptionsGetGlobalByResourceGroupCollectionResultOfT(
                    _eventSubscriptionsRestClient,
                    Guid.Parse(Id.SubscriptionId),
                    Id.ResourceGroupName,
                    filter,
                    top,
                    context,
                    "EventSubscriptionCollection.GetAll");
            }

            return new EventSubscriptionsGetByResourceCollectionResultOfT(
                _eventSubscriptionsRestClient,
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                Id.ResourceType.Namespace,
                GetLastResourceTypeSegment(Id.ResourceType.Type),
                Id.Name,
                filter,
                top,
                context,
                "EventSubscriptionCollection.GetAll");
        }

        private static string GetLastResourceTypeSegment(string resourceTypeName)
        {
            int separatorIndex = resourceTypeName.LastIndexOf('/');
            return separatorIndex >= 0 ? resourceTypeName.Substring(separatorIndex + 1) : resourceTypeName;
        }
    }
}
