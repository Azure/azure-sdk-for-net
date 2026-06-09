// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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

            if (Id.ResourceType == DomainTopicResource.ResourceType)
            {
                return new EventSubscriptionsGetByDomainTopicAsyncCollectionResultOfT(
                    _eventSubscriptionsRestClient,
                    Guid.Parse(Id.SubscriptionId),
                    Id.ResourceGroupName,
                    Id.Parent.Name,
                    Id.Name,
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

            if (Id.ResourceType == DomainTopicResource.ResourceType)
            {
                return new EventSubscriptionsGetByDomainTopicCollectionResultOfT(
                    _eventSubscriptionsRestClient,
                    Guid.Parse(Id.SubscriptionId),
                    Id.ResourceGroupName,
                    Id.Parent.Name,
                    Id.Name,
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
