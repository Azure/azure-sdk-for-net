// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Search.Models;

namespace Azure.ResourceManager.Search.Mocking
{
    public partial class MockableSearchSubscriptionResource
    {
        /// <summary> Checks whether the given search service name is available for use. </summary>
        /// <param name="content"> The resource name and type to check. </param>
        /// <param name="searchManagementRequestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<SearchServiceNameAvailabilityResult>> CheckSearchServiceNameAvailabilityAsync(SearchServiceNameAvailabilityContent content, SearchManagementRequestOptions searchManagementRequestOptions = null, CancellationToken cancellationToken = default)
            => await CheckSearchServiceNameAvailabilityAsync(content, searchManagementRequestOptions ?? new SearchManagementRequestOptions(), cancellationToken).ConfigureAwait(false);

        /// <summary> Checks whether the given search service name is available for use. </summary>
        /// <param name="content"> The resource name and type to check. </param>
        /// <param name="searchManagementRequestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<SearchServiceNameAvailabilityResult> CheckSearchServiceNameAvailability(SearchServiceNameAvailabilityContent content, SearchManagementRequestOptions searchManagementRequestOptions = null, CancellationToken cancellationToken = default)
            => CheckSearchServiceNameAvailability(content, searchManagementRequestOptions ?? new SearchManagementRequestOptions(), cancellationToken);

        /// <summary> Gets a list of all quota usages in the given subscription. </summary>
        /// <param name="location"> The unique location name for a Microsoft Azure geographic region. </param>
        /// <param name="searchManagementRequestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<QuotaUsageResult> GetUsagesBySubscriptionAsync(AzureLocation location, SearchManagementRequestOptions searchManagementRequestOptions = null, CancellationToken cancellationToken = default)
            => GetUsagesBySubscriptionAsync(location.ToString(), searchManagementRequestOptions ?? new SearchManagementRequestOptions(), cancellationToken);

        /// <summary> Gets a list of all quota usages in the given subscription. </summary>
        /// <param name="location"> The unique location name for a Microsoft Azure geographic region. </param>
        /// <param name="searchManagementRequestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<QuotaUsageResult> GetUsagesBySubscription(AzureLocation location, SearchManagementRequestOptions searchManagementRequestOptions = null, CancellationToken cancellationToken = default)
            => GetUsagesBySubscription(location.ToString(), searchManagementRequestOptions ?? new SearchManagementRequestOptions(), cancellationToken);
    }
}
