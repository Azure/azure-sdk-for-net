// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.ResourceHealth.Mocking;
using Azure.ResourceManager.ResourceHealth.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.ResourceHealth
{
    public static partial class ResourceHealthExtensions
    {
        /// <summary> Lists the historical availability statuses for a single resource. </summary>
        // This compatibility shim restores the GA 1.0.0 Pageable<ResourceHealthAvailabilityStatus> return type,
        // while delegating through Mockable* to satisfy ValidateMockingPattern.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<ResourceHealthAvailabilityStatus> GetAvailabilityStatusesAsync(this ArmClient client, ResourceIdentifier scope, string filter = null, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableResourceHealthArmClient(client).GetAvailabilityStatusesAsync(scope, filter, expand, cancellationToken);
        }

        /// <summary> Lists the historical availability statuses for a single resource. </summary>
        // Sync counterpart for the same GA return-type compatibility shim.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<ResourceHealthAvailabilityStatus> GetAvailabilityStatuses(this ArmClient client, ResourceIdentifier scope, string filter = null, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableResourceHealthArmClient(client).GetAvailabilityStatuses(scope, filter, expand, cancellationToken);
        }

        /// <summary> Lists the current availability status for all the resources in the resource group. </summary>
        // This compatibility shim restores the GA 1.0.0 item type for the resource-group list API while keeping the required Mockable* delegation.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<ResourceHealthAvailabilityStatus> GetAvailabilityStatusesByResourceGroupAsync(this ResourceGroupResource resourceGroupResource, string filter = null, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableResourceHealthResourceGroupResource(resourceGroupResource).GetAvailabilityStatusesByResourceGroupAsync(filter, expand, cancellationToken);
        }

        /// <summary> Lists the current availability status for all the resources in the resource group. </summary>
        // Sync counterpart for the same GA return-type compatibility shim.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<ResourceHealthAvailabilityStatus> GetAvailabilityStatusesByResourceGroup(this ResourceGroupResource resourceGroupResource, string filter = null, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableResourceHealthResourceGroupResource(resourceGroupResource).GetAvailabilityStatusesByResourceGroup(filter, expand, cancellationToken);
        }

        /// <summary> Lists the current availability status for all the resources in the subscription. </summary>
        // This compatibility shim restores the GA 1.0.0 item type for the subscription list API while keeping the required Mockable* delegation.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<ResourceHealthAvailabilityStatus> GetAvailabilityStatusesBySubscriptionAsync(this SubscriptionResource subscriptionResource, string filter = null, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableResourceHealthSubscriptionResource(subscriptionResource).GetAvailabilityStatusesBySubscriptionAsync(filter, expand, cancellationToken);
        }

        /// <summary> Lists the current availability status for all the resources in the subscription. </summary>
        // Sync counterpart for the same GA return-type compatibility shim.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<ResourceHealthAvailabilityStatus> GetAvailabilityStatusesBySubscription(this SubscriptionResource subscriptionResource, string filter = null, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableResourceHealthSubscriptionResource(subscriptionResource).GetAvailabilityStatusesBySubscription(filter, expand, cancellationToken);
        }

        /// <summary> Lists the child resources' availability statuses. </summary>
        // This shim preserves the GA child-resource method name and wrapper item type; the generated pageable already exists, so the customization is only the type conversion.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<ResourceHealthAvailabilityStatus> GetAvailabilityStatusOfChildResourcesAsync(this ArmClient client, ResourceIdentifier scope, string filter = null, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableResourceHealthArmClient(client).GetAvailabilityStatusOfChildResourcesAsync(scope, filter, expand, cancellationToken);
        }

        /// <summary> Lists the child resources' availability statuses. </summary>
        // Sync counterpart for the same GA method-name and item-type compatibility shim.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<ResourceHealthAvailabilityStatus> GetAvailabilityStatusOfChildResources(this ArmClient client, ResourceIdentifier scope, string filter = null, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableResourceHealthArmClient(client).GetAvailabilityStatusOfChildResources(scope, filter, expand, cancellationToken);
        }

        /// <summary> Lists the historical availability statuses of child resources. </summary>
        // This shim preserves the GA historical child-resource method name and wrapper item type; the generated pageable already exists, so the customization is only the type conversion.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<ResourceHealthAvailabilityStatus> GetHistoricalAvailabilityStatusesOfChildResourceAsync(this ArmClient client, ResourceIdentifier scope, string filter = null, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableResourceHealthArmClient(client).GetHistoricalAvailabilityStatusesOfChildResourceAsync(scope, filter, expand, cancellationToken);
        }

        /// <summary> Lists the historical availability statuses of child resources. </summary>
        // Sync counterpart for the same GA method-name and item-type compatibility shim.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<ResourceHealthAvailabilityStatus> GetHistoricalAvailabilityStatusesOfChildResource(this ArmClient client, ResourceIdentifier scope, string filter = null, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableResourceHealthArmClient(client).GetHistoricalAvailabilityStatusesOfChildResource(scope, filter, expand, cancellationToken);
        }

        /// <summary> Gets current availability status for a single resource. </summary>
        // This shim restores the GA single-item return type by wrapping the generated AvailabilityStatusResource response through Mockable*.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static async Task<Response<ResourceHealthAvailabilityStatus>> GetAvailabilityStatusAsync(this ArmClient client, ResourceIdentifier scope, string filter = null, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));
            return await GetMockableResourceHealthArmClient(client).GetAvailabilityStatusAsync(scope, filter, expand, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets current availability status for a single resource. </summary>
        // Sync counterpart for the same GA single-item return-type compatibility shim.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Response<ResourceHealthAvailabilityStatus> GetAvailabilityStatus(this ArmClient client, ResourceIdentifier scope, string filter = null, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableResourceHealthArmClient(client).GetAvailabilityStatus(scope, filter, expand, cancellationToken);
        }

        /// <summary> Gets current availability status for a single child resource. </summary>
        // This shim restores the GA child-resource return type by wrapping the generated ChildAvailabilityStatusResource response through Mockable*.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static async Task<Response<ResourceHealthAvailabilityStatus>> GetAvailabilityStatusOfChildResourceAsync(this ArmClient client, ResourceIdentifier scope, string filter = null, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));
            return await GetMockableResourceHealthArmClient(client).GetAvailabilityStatusOfChildResourceAsync(scope, filter, expand, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets current availability status for a single child resource. </summary>
        // Sync counterpart for the same GA child-resource return-type compatibility shim.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Response<ResourceHealthAvailabilityStatus> GetAvailabilityStatusOfChildResource(this ArmClient client, ResourceIdentifier scope, string filter = null, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableResourceHealthArmClient(client).GetAvailabilityStatusOfChildResource(scope, filter, expand, cancellationToken);
        }

        /// <summary> Lists health events for a single resource. </summary>
        // This shim preserves the GA method because listBySingleResource generated only REST request builders; the public pageable must be implemented manually, and Mockable* delegation is still required.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<ResourceHealthEventData> GetHealthEventsOfSingleResourceAsync(this ArmClient client, ResourceIdentifier scope, string filter = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableResourceHealthArmClient(client).GetHealthEventsOfSingleResourceAsync(scope, filter, cancellationToken);
        }

        /// <summary> Lists health events for a single resource. </summary>
        // Sync counterpart for the same manual pageable compatibility shim for listBySingleResource.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<ResourceHealthEventData> GetHealthEventsOfSingleResource(this ArmClient client, ResourceIdentifier scope, string filter = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableResourceHealthArmClient(client).GetHealthEventsOfSingleResource(scope, filter, cancellationToken);
        }
    }
}
