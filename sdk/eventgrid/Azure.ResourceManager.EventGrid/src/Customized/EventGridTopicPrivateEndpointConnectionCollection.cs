// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Azure;

namespace Azure.ResourceManager.EventGrid
{
    // GA-compat private-link surface: the generator emits one generic PrivateLinkResources group; main exposes
    // typed per-resource (Domain/Topic/PartnerNamespace) collections/resources. Rationale: PrivateLinkResourceCompat.cs.
    public partial class EventGridTopicPrivateEndpointConnectionCollection : IEnumerable<EventGridTopicPrivateEndpointConnectionResource>, IAsyncEnumerable<EventGridTopicPrivateEndpointConnectionResource>
    {
        /// <summary> Get all private endpoint connections under this Event Grid topic. </summary>
        /// <param name="filter"> The query used to filter the search results using OData syntax. </param>
        /// <param name="top"> The number of results to return per page for the list operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<EventGridTopicPrivateEndpointConnectionResource> GetAllAsync(string filter = default, int? top = default, CancellationToken cancellationToken = default)
        {
            return new AsyncPageableWrapper<EventGridPrivateEndpointConnectionData, EventGridTopicPrivateEndpointConnectionResource>(
                GetAllDataAsync(filter, top, cancellationToken),
                data => new EventGridTopicPrivateEndpointConnectionResource(Client, data));
        }

        /// <summary> Get all private endpoint connections under this Event Grid topic. </summary>
        /// <param name="filter"> The query used to filter the search results using OData syntax. </param>
        /// <param name="top"> The number of results to return per page for the list operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<EventGridTopicPrivateEndpointConnectionResource> GetAll(string filter = default, int? top = default, CancellationToken cancellationToken = default)
        {
            return new PageableWrapper<EventGridPrivateEndpointConnectionData, EventGridTopicPrivateEndpointConnectionResource>(
                GetAllData(filter, top, cancellationToken),
                data => new EventGridTopicPrivateEndpointConnectionResource(Client, data));
        }

        IEnumerator<EventGridTopicPrivateEndpointConnectionResource> IEnumerable<EventGridTopicPrivateEndpointConnectionResource>.GetEnumerator() => GetAll().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetAll().GetEnumerator();

        IAsyncEnumerator<EventGridTopicPrivateEndpointConnectionResource> IAsyncEnumerable<EventGridTopicPrivateEndpointConnectionResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
            => GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);

        private AsyncPageable<EventGridPrivateEndpointConnectionData> GetAllDataAsync(string filter, int? top, CancellationToken cancellationToken)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new PrivateEndpointConnectionsGetByResourceAsyncCollectionResultOfT(
                _privateEndpointConnectionsRestClient,
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                "topics",
                Id.Name,
                filter,
                top,
                context,
                "EventGridTopicPrivateEndpointConnectionCollection.GetAll");
        }

        private Pageable<EventGridPrivateEndpointConnectionData> GetAllData(string filter, int? top, CancellationToken cancellationToken)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new PrivateEndpointConnectionsGetByResourceCollectionResultOfT(
                _privateEndpointConnectionsRestClient,
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                "topics",
                Id.Name,
                filter,
                top,
                context,
                "EventGridTopicPrivateEndpointConnectionCollection.GetAll");
        }
    }
}
