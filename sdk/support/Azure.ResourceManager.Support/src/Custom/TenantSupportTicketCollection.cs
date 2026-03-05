// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Azure.Core;

namespace Azure.ResourceManager.Support
{
    public partial class TenantSupportTicketCollection : IEnumerable<TenantSupportTicketResource>, IAsyncEnumerable<TenantSupportTicketResource>
    {
        /// <summary>
        /// Lists all the support tickets.
        /// </summary>
        /// <param name="top"> The number of values to return in the collection. Default is 25 and max is 100. </param>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="TenantSupportTicketResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<TenantSupportTicketResource> GetAllAsync(int? top = default, string filter = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new AsyncPageableWrapper<SupportTicketData, TenantSupportTicketResource>(new TenantSupportTicketGetAllAsyncCollectionResultOfT(_tenantSupportTicketRestClient, top, filter, context), data => new TenantSupportTicketResource(Client, data));
        }

        /// <summary>
        /// Lists all the support tickets.
        /// </summary>
        /// <param name="top"> The number of values to return in the collection. Default is 25 and max is 100. </param>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="TenantSupportTicketResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<TenantSupportTicketResource> GetAll(int? top = default, string filter = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new PageableWrapper<SupportTicketData, TenantSupportTicketResource>(new TenantSupportTicketGetAllCollectionResultOfT(_tenantSupportTicketRestClient, top, filter, context), data => new TenantSupportTicketResource(Client, data));
        }

        IEnumerator<TenantSupportTicketResource> IEnumerable<TenantSupportTicketResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        IAsyncEnumerator<TenantSupportTicketResource> IAsyncEnumerable<TenantSupportTicketResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
