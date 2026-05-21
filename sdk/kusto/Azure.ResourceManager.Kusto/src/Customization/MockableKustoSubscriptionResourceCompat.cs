// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Kusto.Models;

namespace Azure.ResourceManager.Kusto.Mocking
{
    public partial class MockableKustoSubscriptionResource
    {
        /// <summary> Lists eligible Kusto SKUs using the legacy method name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<KustoSkuDescription> GetKustoEligibleSkus(CancellationToken cancellationToken)
            => GetSkus(cancellationToken);

        /// <summary> Lists eligible Kusto SKUs using the legacy method name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<KustoSkuDescription> GetKustoEligibleSkusAsync(CancellationToken cancellationToken)
            => GetSkusAsync(cancellationToken);

        /// <summary> Lists Kusto SKUs for a location using the legacy AzureLocation overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<KustoSkuDescription> GetSkus(AzureLocation location, CancellationToken cancellationToken)
            => GetAll(location.ToString(), cancellationToken);

        /// <summary> Lists Kusto SKUs for a location using the legacy AzureLocation overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<KustoSkuDescription> GetSkusAsync(AzureLocation location, CancellationToken cancellationToken)
            => GetAllAsync(location.ToString(), cancellationToken);

        /// <summary> Checks Kusto cluster name availability using the legacy AzureLocation overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<KustoNameAvailabilityResult> CheckKustoClusterNameAvailability(AzureLocation location, KustoClusterNameAvailabilityContent content, CancellationToken cancellationToken)
            => CheckNameAvailability(location.ToString(), content, cancellationToken);

        /// <summary> Checks Kusto cluster name availability using the legacy AzureLocation overload. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<KustoNameAvailabilityResult>> CheckKustoClusterNameAvailabilityAsync(AzureLocation location, KustoClusterNameAvailabilityContent content, CancellationToken cancellationToken)
            => CheckNameAvailabilityAsync(location.ToString(), content, cancellationToken);
    }
}
