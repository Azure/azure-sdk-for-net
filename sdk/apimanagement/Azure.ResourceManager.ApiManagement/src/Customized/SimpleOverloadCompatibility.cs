// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable SA1402 // File may only contain a single type
#pragma warning disable SA1649 // File name should match first type name

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.ApiManagement.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.ApiManagement
{
    public partial class ApiManagementServiceData
    {
        /// <summary> Initializes a new instance of <see cref="ApiManagementServiceData"/>. </summary>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <param name="sku"> SKU properties of the API Management service. </param>
        /// <param name="publisherEmail"> Publisher email. </param>
        /// <param name="publisherName"> Publisher name. </param>
        public ApiManagementServiceData(AzureLocation location, ApiManagementServiceSkuProperties sku, string publisherEmail, string publisherName)
            : this(location, publisherEmail, publisherName, sku)
        {
        }
    }

    public partial class ApiManagementServiceResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<NetworkStatusContract>> GetNetworkStatusByLocationAsync(AzureLocation locationName, CancellationToken cancellationToken = default)
            => await GetNetworkStatusByLocationAsync(locationName.ToString(), cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<NetworkStatusContract> GetNetworkStatusByLocation(AzureLocation locationName, CancellationToken cancellationToken = default)
            => GetNetworkStatusByLocation(locationName.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual async Task<ArmOperation<ApiManagementServiceResource>> MigrateToStv2Async(WaitUntil waitUntil, CancellationToken cancellationToken)
            => await MigrateToStv2Async(waitUntil, default(MigrateToStv2Contract), cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual ArmOperation<ApiManagementServiceResource> MigrateToStv2(WaitUntil waitUntil, CancellationToken cancellationToken)
            => MigrateToStv2(waitUntil, default(MigrateToStv2Contract), cancellationToken);
    }

    public static partial class ApiManagementExtensions
    {
        /// <inheritdoc />
        [ForwardsClientCalls]
        public static AsyncPageable<ApiManagementDeletedServiceResource> GetApiManagementDeletedServicesAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableApiManagementSubscriptionResource(subscriptionResource).GetApiManagementDeletedServicesAsync(cancellationToken);
        }

        /// <inheritdoc />
        [ForwardsClientCalls]
        public static Pageable<ApiManagementDeletedServiceResource> GetApiManagementDeletedServices(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableApiManagementSubscriptionResource(subscriptionResource).GetApiManagementDeletedServices(cancellationToken);
        }

        /// <inheritdoc />
        [ForwardsClientCalls]
        public static AsyncPageable<ApiManagementSku> GetApiManagementSkusAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableApiManagementSubscriptionResource(subscriptionResource).GetApiManagementSkusAsync(cancellationToken);
        }

        /// <inheritdoc />
        [ForwardsClientCalls]
        public static Pageable<ApiManagementSku> GetApiManagementSkus(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableApiManagementSubscriptionResource(subscriptionResource).GetApiManagementSkus(cancellationToken);
        }
    }
}

namespace Azure.ResourceManager.ApiManagement.Mocking
{
    public partial class MockableApiManagementSubscriptionResource
    {
        /// <inheritdoc />
        public virtual AsyncPageable<ApiManagementDeletedServiceResource> GetApiManagementDeletedServicesAsync(CancellationToken cancellationToken = default)
            => GetBySubscriptionAsync(cancellationToken);

        /// <inheritdoc />
        public virtual Pageable<ApiManagementDeletedServiceResource> GetApiManagementDeletedServices(CancellationToken cancellationToken = default)
            => GetBySubscription(cancellationToken);

        /// <inheritdoc />
        public virtual AsyncPageable<ApiManagementSku> GetApiManagementSkusAsync(CancellationToken cancellationToken = default)
            => GetAllAsync(cancellationToken);

        /// <inheritdoc />
        public virtual Pageable<ApiManagementSku> GetApiManagementSkus(CancellationToken cancellationToken = default)
            => GetAll(cancellationToken);
    }
}
