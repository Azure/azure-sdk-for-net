// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Support.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Support
{
    // Suppress the generated ValidateResourceId to accept both TenantResource and SubscriptionResource
    [CodeGenSuppress("ValidateResourceId", typeof(Core.ResourceIdentifier))]
    public partial class TenantSupportTicketCollection : IEnumerable<TenantSupportTicketResource>, IAsyncEnumerable<TenantSupportTicketResource>
    {
        [System.Diagnostics.Conditional("DEBUG")]
        internal static void ValidateResourceId(Core.ResourceIdentifier id)
        {
            if (id.ResourceType != SubscriptionResource.ResourceType && id.ResourceType != TenantResource.ResourceType)
            {
                throw new System.ArgumentException(
                    string.Format("Invalid resource type {0} expected {1} or {2}", id.ResourceType, SubscriptionResource.ResourceType, TenantResource.ResourceType),
                    nameof(id));
            }
        }

        /// <summary> Lists all the support tickets. </summary>
        /// <param name="top"> The number of values to return in the collection. </param>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="TenantSupportTicketResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<TenantSupportTicketResource> GetAllAsync(int? top = default, string filter = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new AsyncPageableWrapper<SupportTicketData, TenantSupportTicketResource>(
                new TenantSupportTicketGetAllAsyncCollectionResultOfT(
                    _tenantSupportTicketRestClient,
                    top,
                    filter,
                    context),
                data => new TenantSupportTicketResource(Client, data));
        }

        /// <summary> Lists all the support tickets. </summary>
        /// <param name="top"> The number of values to return in the collection. </param>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="TenantSupportTicketResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<TenantSupportTicketResource> GetAll(int? top = default, string filter = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new PageableWrapper<SupportTicketData, TenantSupportTicketResource>(
                new TenantSupportTicketGetAllCollectionResultOfT(
                    _tenantSupportTicketRestClient,
                    top,
                    filter,
                    context),
                data => new TenantSupportTicketResource(Client, data));
        }

        IEnumerator<TenantSupportTicketResource> IEnumerable<TenantSupportTicketResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<TenantSupportTicketResource> IAsyncEnumerable<TenantSupportTicketResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
