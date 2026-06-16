// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.ResourceHealth.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.ResourceHealth
{
    // This file preserves GA extension APIs that are not emitted in the same shape by the current generator.
    // The methods forward to mockable compatibility implementations, which wrap generated resources/data
    // or custom pageable results back into the public types used by the GA surface.
    public static partial class ResourceHealthExtensions
    {
        /// <summary> Lists service health events for a single resource. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ResourceHealthEventData"/> that may take multiple service requests to iterate over. </returns>
        [ForwardsClientCalls]
        public static AsyncPageable<ResourceHealthEventData> GetHealthEventsOfSingleResourceAsync(this ArmClient client, ResourceIdentifier scope, string filter = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableResourceHealthArmClient(client).GetHealthEventsOfSingleResourceAsync(scope, filter, cancellationToken);
        }

        /// <summary> Lists service health events for a single resource. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ResourceHealthEventData"/> that may take multiple service requests to iterate over. </returns>
        [ForwardsClientCalls]
        public static Pageable<ResourceHealthEventData> GetHealthEventsOfSingleResource(this ArmClient client, ResourceIdentifier scope, string filter = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableResourceHealthArmClient(client).GetHealthEventsOfSingleResource(scope, filter, cancellationToken);
        }

        /// <summary> Lists child resource historical availability statuses. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="expand"> Setting $expand=recommendedactions in url query expands the recommendedactions in the response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ResourceHealthAvailabilityStatus"/> that may take multiple service requests to iterate over. </returns>
        [ForwardsClientCalls]
        public static AsyncPageable<ResourceHealthAvailabilityStatus> GetHistoricalAvailabilityStatusesOfChildResourceAsync(this ArmClient client, ResourceIdentifier scope, string filter = default, string expand = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableResourceHealthArmClient(client).GetHistoricalAvailabilityStatusesOfChildResourceAsync(scope, filter, expand, cancellationToken);
        }

        /// <summary> Lists child resource historical availability statuses. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="expand"> Setting $expand=recommendedactions in url query expands the recommendedactions in the response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ResourceHealthAvailabilityStatus"/> that may take multiple service requests to iterate over. </returns>
        [ForwardsClientCalls]
        public static Pageable<ResourceHealthAvailabilityStatus> GetHistoricalAvailabilityStatusesOfChildResource(this ArmClient client, ResourceIdentifier scope, string filter = default, string expand = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableResourceHealthArmClient(client).GetHistoricalAvailabilityStatusesOfChildResource(scope, filter, expand, cancellationToken);
        }

        /// <summary> Lists child resources and their current health status for a parent resource. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="expand"> Setting $expand=recommendedactions in url query expands the recommendedactions in the response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ResourceHealthAvailabilityStatus"/> that may take multiple service requests to iterate over. </returns>
        [ForwardsClientCalls]
        public static AsyncPageable<ResourceHealthAvailabilityStatus> GetAvailabilityStatusOfChildResourcesAsync(this ArmClient client, ResourceIdentifier scope, string filter = default, string expand = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableResourceHealthArmClient(client).GetAvailabilityStatusOfChildResourcesAsync(scope, filter, expand, cancellationToken);
        }

        /// <summary> Lists child resources and their current health status for a parent resource. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="expand"> Setting $expand=recommendedactions in url query expands the recommendedactions in the response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ResourceHealthAvailabilityStatus"/> that may take multiple service requests to iterate over. </returns>
        [ForwardsClientCalls]
        public static Pageable<ResourceHealthAvailabilityStatus> GetAvailabilityStatusOfChildResources(this ArmClient client, ResourceIdentifier scope, string filter = default, string expand = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableResourceHealthArmClient(client).GetAvailabilityStatusOfChildResources(scope, filter, expand, cancellationToken);
        }

        /// <summary> Gets current availability status for a child resource. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="expand"> Setting $expand=recommendedactions in url query expands the recommendedactions in the response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public static async Task<Response<ResourceHealthAvailabilityStatus>> GetAvailabilityStatusOfChildResourceAsync(this ArmClient client, ResourceIdentifier scope, string filter = default, string expand = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));

            return await GetMockableResourceHealthArmClient(client).GetAvailabilityStatusOfChildResourceAsync(scope, filter, expand, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets current availability status for a child resource. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="expand"> Setting $expand=recommendedactions in url query expands the recommendedactions in the response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public static Response<ResourceHealthAvailabilityStatus> GetAvailabilityStatusOfChildResource(this ArmClient client, ResourceIdentifier scope, string filter = default, string expand = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableResourceHealthArmClient(client).GetAvailabilityStatusOfChildResource(scope, filter, expand, cancellationToken);
        }

        /// <summary> Lists current availability status for resources in the resource group. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="expand"> Setting $expand=recommendedactions in url query expands the recommendedactions in the response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ResourceHealthAvailabilityStatus"/> that may take multiple service requests to iterate over. </returns>
        [ForwardsClientCalls]
        public static AsyncPageable<ResourceHealthAvailabilityStatus> GetAvailabilityStatusesByResourceGroupAsync(this ResourceGroupResource resourceGroupResource, string filter = default, string expand = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return GetMockableResourceHealthResourceGroupResource(resourceGroupResource).GetAvailabilityStatusesByResourceGroupAsync(filter, expand, cancellationToken);
        }

        /// <summary> Lists current availability status for resources in the resource group. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="expand"> Setting $expand=recommendedactions in url query expands the recommendedactions in the response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ResourceHealthAvailabilityStatus"/> that may take multiple service requests to iterate over. </returns>
        [ForwardsClientCalls]
        public static Pageable<ResourceHealthAvailabilityStatus> GetAvailabilityStatusesByResourceGroup(this ResourceGroupResource resourceGroupResource, string filter = default, string expand = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));

            return GetMockableResourceHealthResourceGroupResource(resourceGroupResource).GetAvailabilityStatusesByResourceGroup(filter, expand, cancellationToken);
        }

        /// <summary> Lists current availability status for resources in the subscription. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> the method will execute against. </param>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="expand"> Setting $expand=recommendedactions in url query expands the recommendedactions in the response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AvailabilityStatusResource"/> that may take multiple service requests to iterate over. </returns>
        [ForwardsClientCalls]
        public static AsyncPageable<AvailabilityStatusResource> GetAvailabilityStatusResourcesBySubscriptionAsync(this SubscriptionResource subscriptionResource, string filter = default, string expand = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableResourceHealthSubscriptionResource(subscriptionResource).GetAvailabilityStatusResourcesBySubscriptionAsync(filter, expand, cancellationToken);
        }

        /// <summary> Lists current availability status for resources in the subscription. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> the method will execute against. </param>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="expand"> Setting $expand=recommendedactions in url query expands the recommendedactions in the response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AvailabilityStatusResource"/> that may take multiple service requests to iterate over. </returns>
        [ForwardsClientCalls]
        public static Pageable<AvailabilityStatusResource> GetAvailabilityStatusResourcesBySubscription(this SubscriptionResource subscriptionResource, string filter = default, string expand = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableResourceHealthSubscriptionResource(subscriptionResource).GetAvailabilityStatusResourcesBySubscription(filter, expand, cancellationToken);
        }

        /// <summary> Lists current availability status for resources in the subscription. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> the method will execute against. </param>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="expand"> Setting $expand=recommendedactions in url query expands the recommendedactions in the response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ResourceHealthAvailabilityStatus"/> that may take multiple service requests to iterate over. </returns>
        [ForwardsClientCalls]
        public static AsyncPageable<ResourceHealthAvailabilityStatus> GetAvailabilityStatusesBySubscriptionAsync(this SubscriptionResource subscriptionResource, string filter = default, string expand = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableResourceHealthSubscriptionResource(subscriptionResource).GetAvailabilityStatusesBySubscriptionAsync(filter, expand, cancellationToken);
        }

        /// <summary> Lists current availability status for resources in the subscription. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> the method will execute against. </param>
        /// <param name="filter"> The filter to apply on the operation. </param>
        /// <param name="expand"> Setting $expand=recommendedactions in url query expands the recommendedactions in the response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ResourceHealthAvailabilityStatus"/> that may take multiple service requests to iterate over. </returns>
        [ForwardsClientCalls]
        public static Pageable<ResourceHealthAvailabilityStatus> GetAvailabilityStatusesBySubscription(this SubscriptionResource subscriptionResource, string filter = default, string expand = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableResourceHealthSubscriptionResource(subscriptionResource).GetAvailabilityStatusesBySubscription(filter, expand, cancellationToken);
        }
    }
}
