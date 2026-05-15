// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility shims: AvailabilityStatus extension methods from GA 1.0.0.
// GA 1.0.0 returned Pageable<ResourceHealthAvailabilityStatus> from extension methods.
// The new SDK returns Pageable<AvailabilityStatusData> or Pageable<AvailabilityStatusResource>.
// These shims preserve the old method signatures and return types by wrapping the new generated
// APIs with type-converting MappedPageable/MappedAsyncPageable. Each extension method delegates
// through the corresponding Mockable* class to satisfy the ValidateMockingPattern test — this is
// an Azure SDK architecture requirement, not optional.

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
        // GA 1.0.0 backward compatibility shim: returns Pageable<ResourceHealthAvailabilityStatus>
        // instead of the new Pageable<AvailabilityStatusData>. Delegates to
        // MockableResourceHealthArmClient.GetAvailabilityStatusesAsync() for mocking support.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<ResourceHealthAvailabilityStatus> GetAvailabilityStatusesAsync(this ArmClient client, ResourceIdentifier scope, string filter = null, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableResourceHealthArmClient(client).GetAvailabilityStatusesAsync(scope, filter, expand, cancellationToken);
        }

        /// <summary> Lists the historical availability statuses for a single resource. </summary>
        // GA 1.0.0 backward compatibility shim: sync version of GetAvailabilityStatusesAsync.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<ResourceHealthAvailabilityStatus> GetAvailabilityStatuses(this ArmClient client, ResourceIdentifier scope, string filter = null, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableResourceHealthArmClient(client).GetAvailabilityStatuses(scope, filter, expand, cancellationToken);
        }

        /// <summary> Lists the current availability status for all the resources in the resource group. </summary>
        // GA 1.0.0 backward compatibility shim: returns Pageable<ResourceHealthAvailabilityStatus>
        // instead of Pageable<AvailabilityStatusResource>. Delegates through
        // MockableResourceHealthResourceGroupResource for mocking support.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<ResourceHealthAvailabilityStatus> GetAvailabilityStatusesByResourceGroupAsync(this ResourceGroupResource resourceGroupResource, string filter = null, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableResourceHealthResourceGroupResource(resourceGroupResource).GetAvailabilityStatusesByResourceGroupAsync(filter, expand, cancellationToken);
        }

        /// <summary> Lists the current availability status for all the resources in the resource group. </summary>
        // GA 1.0.0 backward compatibility shim: sync version of GetAvailabilityStatusesByResourceGroupAsync.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<ResourceHealthAvailabilityStatus> GetAvailabilityStatusesByResourceGroup(this ResourceGroupResource resourceGroupResource, string filter = null, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableResourceHealthResourceGroupResource(resourceGroupResource).GetAvailabilityStatusesByResourceGroup(filter, expand, cancellationToken);
        }

        /// <summary> Lists the current availability status for all the resources in the subscription. </summary>
        // GA 1.0.0 backward compatibility shim: returns Pageable<ResourceHealthAvailabilityStatus>
        // instead of Pageable<AvailabilityStatusResource>. Delegates through
        // MockableResourceHealthSubscriptionResource for mocking support.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<ResourceHealthAvailabilityStatus> GetAvailabilityStatusesBySubscriptionAsync(this SubscriptionResource subscriptionResource, string filter = null, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableResourceHealthSubscriptionResource(subscriptionResource).GetAvailabilityStatusesBySubscriptionAsync(filter, expand, cancellationToken);
        }

        /// <summary> Lists the current availability status for all the resources in the subscription. </summary>
        // GA 1.0.0 backward compatibility shim: sync version of GetAvailabilityStatusesBySubscriptionAsync.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<ResourceHealthAvailabilityStatus> GetAvailabilityStatusesBySubscription(this SubscriptionResource subscriptionResource, string filter = null, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableResourceHealthSubscriptionResource(subscriptionResource).GetAvailabilityStatusesBySubscription(filter, expand, cancellationToken);
        }

        /// <summary> Lists the child resources' availability statuses. </summary>
        // GA 1.0.0 backward compatibility shim: preserves old name and return type.
        // The new generated API is GetAllAsync() returning Pageable<AvailabilityStatusData>.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<ResourceHealthAvailabilityStatus> GetAvailabilityStatusOfChildResourcesAsync(this ArmClient client, ResourceIdentifier scope, string filter = null, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableResourceHealthArmClient(client).GetAvailabilityStatusOfChildResourcesAsync(scope, filter, expand, cancellationToken);
        }

        /// <summary> Lists the child resources' availability statuses. </summary>
        // GA 1.0.0 backward compatibility shim: sync version of GetAvailabilityStatusOfChildResourcesAsync.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<ResourceHealthAvailabilityStatus> GetAvailabilityStatusOfChildResources(this ArmClient client, ResourceIdentifier scope, string filter = null, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableResourceHealthArmClient(client).GetAvailabilityStatusOfChildResources(scope, filter, expand, cancellationToken);
        }

        /// <summary> Lists the historical availability statuses of child resources. </summary>
        // GA 1.0.0 backward compatibility shim: preserves old name and return type.
        // The new generated API is GetAllAsync() returning Pageable<AvailabilityStatusData>.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<ResourceHealthAvailabilityStatus> GetHistoricalAvailabilityStatusesOfChildResourceAsync(this ArmClient client, ResourceIdentifier scope, string filter = null, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableResourceHealthArmClient(client).GetHistoricalAvailabilityStatusesOfChildResourceAsync(scope, filter, expand, cancellationToken);
        }

        /// <summary> Lists the historical availability statuses of child resources. </summary>
        // GA 1.0.0 backward compatibility shim: sync version of GetHistoricalAvailabilityStatusesOfChildResourceAsync.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<ResourceHealthAvailabilityStatus> GetHistoricalAvailabilityStatusesOfChildResource(this ArmClient client, ResourceIdentifier scope, string filter = null, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableResourceHealthArmClient(client).GetHistoricalAvailabilityStatusesOfChildResource(scope, filter, expand, cancellationToken);
        }

        /// <summary> Gets current availability status for a single resource. </summary>
        // GA 1.0.0 backward compatibility shim: returns Response<ResourceHealthAvailabilityStatus>
        // instead of Response<AvailabilityStatusResource>. Wraps the new AvailabilityStatusResource.GetAsync().
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static async Task<Response<ResourceHealthAvailabilityStatus>> GetAvailabilityStatusAsync(this ArmClient client, ResourceIdentifier scope, string filter = null, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));
            return await GetMockableResourceHealthArmClient(client).GetAvailabilityStatusAsync(scope, filter, expand, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets current availability status for a single resource. </summary>
        // GA 1.0.0 backward compatibility shim: sync version of GetAvailabilityStatusAsync.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Response<ResourceHealthAvailabilityStatus> GetAvailabilityStatus(this ArmClient client, ResourceIdentifier scope, string filter = null, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableResourceHealthArmClient(client).GetAvailabilityStatus(scope, filter, expand, cancellationToken);
        }

        /// <summary> Gets current availability status for a single child resource. </summary>
        // GA 1.0.0 backward compatibility shim: returns Response<ResourceHealthAvailabilityStatus>
        // instead of Response<ChildAvailabilityStatusResource>.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static async Task<Response<ResourceHealthAvailabilityStatus>> GetAvailabilityStatusOfChildResourceAsync(this ArmClient client, ResourceIdentifier scope, string filter = null, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));
            return await GetMockableResourceHealthArmClient(client).GetAvailabilityStatusOfChildResourceAsync(scope, filter, expand, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets current availability status for a single child resource. </summary>
        // GA 1.0.0 backward compatibility shim: sync version of GetAvailabilityStatusOfChildResourceAsync.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Response<ResourceHealthAvailabilityStatus> GetAvailabilityStatusOfChildResource(this ArmClient client, ResourceIdentifier scope, string filter = null, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableResourceHealthArmClient(client).GetAvailabilityStatusOfChildResource(scope, filter, expand, cancellationToken);
        }

        /// <summary> Lists health events for a single resource. </summary>
        // GA 1.0.0 backward compatibility shim: preserves GetHealthEventsOfSingleResourceAsync.
        // The TypeSpec Events.getBySingleResource operation exists in the REST layer but is NOT
        // surfaced as a public API by the generator. This shim uses the internal Events REST client
        // via EventsBySingleResourceHelper to implement the pageable manually.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<ResourceHealthEventData> GetHealthEventsOfSingleResourceAsync(this ArmClient client, ResourceIdentifier scope, string filter = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableResourceHealthArmClient(client).GetHealthEventsOfSingleResourceAsync(scope, filter, cancellationToken);
        }

        /// <summary> Lists health events for a single resource. </summary>
        // GA 1.0.0 backward compatibility shim: sync version of GetHealthEventsOfSingleResourceAsync.
        // Same manual REST client implementation as the async version.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<ResourceHealthEventData> GetHealthEventsOfSingleResource(this ArmClient client, ResourceIdentifier scope, string filter = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableResourceHealthArmClient(client).GetHealthEventsOfSingleResource(scope, filter, cancellationToken);
        }
    }
}
