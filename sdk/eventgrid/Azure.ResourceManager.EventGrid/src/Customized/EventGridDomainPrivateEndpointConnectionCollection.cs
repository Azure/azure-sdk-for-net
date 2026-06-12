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
    public partial class EventGridDomainPrivateEndpointConnectionCollection : IEnumerable<EventGridDomainPrivateEndpointConnectionResource>, IAsyncEnumerable<EventGridDomainPrivateEndpointConnectionResource>
    {
        /// <summary> Get all private endpoint connections under this Event Grid domain. </summary>
        /// <param name="filter"> The query used to filter the search results using OData syntax. </param>
        /// <param name="top"> The number of results to return per page for the list operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<EventGridDomainPrivateEndpointConnectionResource> GetAllAsync(string filter = default, int? top = default, CancellationToken cancellationToken = default)
        {
            return new AsyncPageableWrapper<EventGridPrivateEndpointConnectionData, EventGridDomainPrivateEndpointConnectionResource>(
                GetAllDataAsync(filter, top, cancellationToken),
                data => new EventGridDomainPrivateEndpointConnectionResource(Client, data));
        }

        /// <summary> Get all private endpoint connections under this Event Grid domain. </summary>
        /// <param name="filter"> The query used to filter the search results using OData syntax. </param>
        /// <param name="top"> The number of results to return per page for the list operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<EventGridDomainPrivateEndpointConnectionResource> GetAll(string filter = default, int? top = default, CancellationToken cancellationToken = default)
        {
            return new PageableWrapper<EventGridPrivateEndpointConnectionData, EventGridDomainPrivateEndpointConnectionResource>(
                GetAllData(filter, top, cancellationToken),
                data => new EventGridDomainPrivateEndpointConnectionResource(Client, data));
        }

        IEnumerator<EventGridDomainPrivateEndpointConnectionResource> IEnumerable<EventGridDomainPrivateEndpointConnectionResource>.GetEnumerator() => GetAll().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetAll().GetEnumerator();

        IAsyncEnumerator<EventGridDomainPrivateEndpointConnectionResource> IAsyncEnumerable<EventGridDomainPrivateEndpointConnectionResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
            => GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);

        private AsyncPageable<EventGridPrivateEndpointConnectionData> GetAllDataAsync(string filter, int? top, CancellationToken cancellationToken)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new PrivateEndpointConnectionsGetByResourceAsyncCollectionResultOfT(
                _privateEndpointConnectionsRestClient,
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                "domains",
                Id.Name,
                filter,
                top,
                context,
                "EventGridDomainPrivateEndpointConnectionCollection.GetAll");
        }

        private Pageable<EventGridPrivateEndpointConnectionData> GetAllData(string filter, int? top, CancellationToken cancellationToken)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new PrivateEndpointConnectionsGetByResourceCollectionResultOfT(
                _privateEndpointConnectionsRestClient,
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                "domains",
                Id.Name,
                filter,
                top,
                context,
                "EventGridDomainPrivateEndpointConnectionCollection.GetAll");
        }
    }
}
