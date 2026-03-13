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
    /*
     * Custom code reason:
     *
     * Codegen bug: https://github.com/Azure/azure-sdk-for-net/issues/57073
     * The MPG generator incorrectly assigns resourceScope "Subscription" instead of "Tenant" for
     * TenantSupportTicket in tspCodeModel.json, even though all its operations are tenant-scoped.
     * This causes incorrect generated code that requires the workarounds below.
     *
     * 1. ValidateResourceId override (dual-scope support):
     *    In the TypeSpec spec (SupportTicketDetails.tsp), SupportTicketDetails is marked @subscriptionResource,
     *    so the generator places it under SubscriptionResource scope and the generated ValidateResourceId
     *    only accepts SubscriptionResource.ResourceType. However, the spec also defines a separate operation
     *    interface SupportTicketsNoSubscriptionOps (without SubscriptionIdParameter) for tenant-level access.
     *    In the old Swagger API, TenantSupportTicketCollection was accessible from BOTH SubscriptionResource
     *    and TenantResource via GetTenantSupportTickets() extension methods. To maintain backward compatibility,
     *    the custom MockableSupportTenantResource.GetTenantSupportTickets() passes TenantResource.Id to this
     *    collection, which would fail the generated validation. The custom ValidateResourceId accepts both
     *    SubscriptionResource.ResourceType and TenantResource.ResourceType.
     *
     * 2. GetAll/GetAllAsync methods and IEnumerable/IAsyncEnumerable interfaces:
     *    In the old Swagger API, TenantSupportTicketCollection had GetAll(int?, string, CancellationToken)
     *    and GetAllAsync methods, and implemented IEnumerable<TenantSupportTicketResource>. The new TypeSpec
     *    generator moved listing operations to MockableSupportTenantResource.GetTenantSupportTickets(int?,
     *    string, CancellationToken) returning Pageable directly, removing them from the collection class.
     *    These methods are restored here for ApiCompat with the 1.1.1 GA release.
     */
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
