// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Search.Mocking;
using Azure.ResourceManager.Search.Models;

namespace Azure.ResourceManager.Search
{
    public static partial class SearchExtensions
    {
        /// <summary> Checks whether the given search service name is available for use. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> instance the method will execute against. </param>
        /// <param name="content"> The resource name and type to check. </param>
        /// <param name="searchManagementRequestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<Response<SearchServiceNameAvailabilityResult>> CheckSearchServiceNameAvailabilityAsync(this SubscriptionResource subscriptionResource, SearchServiceNameAvailabilityContent content, SearchManagementRequestOptions searchManagementRequestOptions = null, CancellationToken cancellationToken = default)
        {
            return await subscriptionResource.GetCachedClient(client => new MockableSearchSubscriptionResource(client, subscriptionResource.Id)).CheckSearchServiceNameAvailabilityAsync(content, searchManagementRequestOptions, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Checks whether the given search service name is available for use. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> instance the method will execute against. </param>
        /// <param name="content"> The resource name and type to check. </param>
        /// <param name="searchManagementRequestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<SearchServiceNameAvailabilityResult> CheckSearchServiceNameAvailability(this SubscriptionResource subscriptionResource, SearchServiceNameAvailabilityContent content, SearchManagementRequestOptions searchManagementRequestOptions = null, CancellationToken cancellationToken = default)
        {
            return subscriptionResource.GetCachedClient(client => new MockableSearchSubscriptionResource(client, subscriptionResource.Id)).CheckSearchServiceNameAvailability(content, searchManagementRequestOptions, cancellationToken);
        }

        /// <summary> Gets a list of all quota usages in the given subscription. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> instance the method will execute against. </param>
        /// <param name="location"> The unique location name for a Microsoft Azure geographic region. </param>
        /// <param name="searchManagementRequestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<QuotaUsageResult> GetUsagesBySubscriptionAsync(this SubscriptionResource subscriptionResource, AzureLocation location, SearchManagementRequestOptions searchManagementRequestOptions = null, CancellationToken cancellationToken = default)
        {
            return subscriptionResource.GetCachedClient(client => new MockableSearchSubscriptionResource(client, subscriptionResource.Id)).GetUsagesBySubscriptionAsync(location, searchManagementRequestOptions, cancellationToken);
        }

        /// <summary> Gets a list of all quota usages in the given subscription. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> instance the method will execute against. </param>
        /// <param name="location"> The unique location name for a Microsoft Azure geographic region. </param>
        /// <param name="searchManagementRequestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<QuotaUsageResult> GetUsagesBySubscription(this SubscriptionResource subscriptionResource, AzureLocation location, SearchManagementRequestOptions searchManagementRequestOptions = null, CancellationToken cancellationToken = default)
        {
            return subscriptionResource.GetCachedClient(client => new MockableSearchSubscriptionResource(client, subscriptionResource.Id)).GetUsagesBySubscription(location, searchManagementRequestOptions, cancellationToken);
        }
    }
}
