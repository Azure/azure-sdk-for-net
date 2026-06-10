// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Kusto.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Kusto
{
    public static partial class KustoExtensions
    {
        /// <summary> Lists eligible Kusto SKUs using the legacy method name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<KustoSkuDescription> GetKustoEligibleSkus(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
            => GetSkus(subscriptionResource, cancellationToken);

        /// <summary> Lists eligible Kusto SKUs using the legacy method name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<KustoSkuDescription> GetKustoEligibleSkusAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken)
            => GetSkusAsync(subscriptionResource, cancellationToken);

        /// <summary> Lists Kusto SKUs for a location using the legacy AzureLocation overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<KustoSkuDescription> GetSkus(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
            => GetAll(subscriptionResource, location.ToString(), cancellationToken);

        /// <summary> Lists Kusto SKUs for a location using the legacy AzureLocation overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<KustoSkuDescription> GetSkusAsync(this SubscriptionResource subscriptionResource, AzureLocation location, CancellationToken cancellationToken)
            => GetAllAsync(subscriptionResource, location.ToString(), cancellationToken);

        /// <summary> Checks Kusto cluster name availability using the legacy AzureLocation overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<KustoNameAvailabilityResult> CheckKustoClusterNameAvailability(this SubscriptionResource subscriptionResource, AzureLocation location, KustoClusterNameAvailabilityContent content, CancellationToken cancellationToken)
            => CheckNameAvailability(subscriptionResource, location.ToString(), content, cancellationToken);

        /// <summary> Checks Kusto cluster name availability using the legacy AzureLocation overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Task<Response<KustoNameAvailabilityResult>> CheckKustoClusterNameAvailabilityAsync(this SubscriptionResource subscriptionResource, AzureLocation location, KustoClusterNameAvailabilityContent content, CancellationToken cancellationToken)
            => CheckNameAvailabilityAsync(subscriptionResource, location.ToString(), content, cancellationToken);
    }
}
