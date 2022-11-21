// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Reservations
{
    /// <summary>
    /// A class representing a collection of <see cref="QuotaRequestDetailResource" /> and their operations.
    /// Each <see cref="QuotaRequestDetailResource" /> in the collection will belong to the same instance of <see cref="SubscriptionResource" />.
    /// To get a <see cref="QuotaRequestDetailCollection" /> instance call the GetQuotaRequestDetails method from an instance of <see cref="SubscriptionResource" />.
    /// </summary>
    public partial class QuotaRequestDetailCollection : ArmCollection, IEnumerable<QuotaRequestDetailResource>, IAsyncEnumerable<QuotaRequestDetailResource>
    {
        /// <summary>
        /// For the specified Azure region (location), subscription, and resource provider, get the history of the quota requests for the past year. To select specific quota requests, use the oData filter.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Capacity/resourceProviders/{providerId}/locations/{location}/serviceLimitsRequests
        /// Operation Id: QuotaRequestStatus_List
        /// </summary>
        /// <param name="filter">
        /// | Field | Supported operators |
        /// |---------------------|------------------------|
        /// |requestSubmitTime | ge, le, eq, gt, lt |
        /// </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skiptoken"> Skiptoken is only used if a previous operation returned a partial result. If a previous response contains a nextLink element, the value of the nextLink element includes a skiptoken parameter that specifies a starting point to use for subsequent calls. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="QuotaRequestDetailResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<QuotaRequestDetailResource> GetAllAsync(string filter = null, int? top = null, string skiptoken = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<QuotaRequestDetailResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _quotaRequestDetailQuotaRequestStatusClientDiagnostics.CreateScope("QuotaRequestDetailCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _quotaRequestDetailQuotaRequestStatusRestClient.ListAsync(Id.SubscriptionId, _providerId, new AzureLocation(_location), filter, top, skiptoken, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new QuotaRequestDetailResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<QuotaRequestDetailResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _quotaRequestDetailQuotaRequestStatusClientDiagnostics.CreateScope("QuotaRequestDetailCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _quotaRequestDetailQuotaRequestStatusRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, _providerId, new AzureLocation(_location), filter, top, skiptoken, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new QuotaRequestDetailResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// For the specified Azure region (location), subscription, and resource provider, get the history of the quota requests for the past year. To select specific quota requests, use the oData filter.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Capacity/resourceProviders/{providerId}/locations/{location}/serviceLimitsRequests
        /// Operation Id: QuotaRequestStatus_List
        /// </summary>
        /// <param name="filter">
        /// | Field | Supported operators |
        /// |---------------------|------------------------|
        /// |requestSubmitTime | ge, le, eq, gt, lt |
        /// </param>
        /// <param name="top"> Number of records to return. </param>
        /// <param name="skiptoken"> Skiptoken is only used if a previous operation returned a partial result. If a previous response contains a nextLink element, the value of the nextLink element includes a skiptoken parameter that specifies a starting point to use for subsequent calls. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="QuotaRequestDetailResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<QuotaRequestDetailResource> GetAll(string filter = null, int? top = null, string skiptoken = null, CancellationToken cancellationToken = default)
        {
            Page<QuotaRequestDetailResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _quotaRequestDetailQuotaRequestStatusClientDiagnostics.CreateScope("QuotaRequestDetailCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _quotaRequestDetailQuotaRequestStatusRestClient.List(Id.SubscriptionId, _providerId, new AzureLocation(_location), filter, top, skiptoken, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new QuotaRequestDetailResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<QuotaRequestDetailResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _quotaRequestDetailQuotaRequestStatusClientDiagnostics.CreateScope("QuotaRequestDetailCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _quotaRequestDetailQuotaRequestStatusRestClient.ListNextPage(nextLink, Id.SubscriptionId, _providerId, new AzureLocation(_location), filter, top, skiptoken, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new QuotaRequestDetailResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
    }
}
