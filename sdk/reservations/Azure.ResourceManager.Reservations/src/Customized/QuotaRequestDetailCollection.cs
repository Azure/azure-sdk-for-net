// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Threading;
using Azure.ResourceManager.Reservations.Models;
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
        public virtual AsyncPageable<QuotaRequestDetailResource> GetAllAsync(string filter = null, int? top = null, string skiptoken = null, CancellationToken cancellationToken = default) =>
            GetAllAsync(new QuotaRequestDetailCollectionGetAllOptions
            {
                Filter = filter,
                Top = top,
                Skiptoken = skiptoken
            }, cancellationToken);

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
        public virtual Pageable<QuotaRequestDetailResource> GetAll(string filter = null, int? top = null, string skiptoken = null, CancellationToken cancellationToken = default) =>
            GetAll(new QuotaRequestDetailCollectionGetAllOptions
            {
                Filter = filter,
                Top = top,
                Skiptoken = skiptoken
            }, cancellationToken);
    }
}
