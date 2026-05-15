// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility: mockable methods for SubscriptionResource extension shims.
// Required by ValidateMockingPattern test — each extension method on ResourceHealthExtensions
// that extends SubscriptionResource must have a corresponding virtual method here.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.ResourceHealth.Models;

namespace Azure.ResourceManager.ResourceHealth.Mocking
{
    public partial class MockableResourceHealthSubscriptionResource
    {
        /// <summary> Lists the current availability status for all the resources in the subscription. </summary>
        // Mockable counterpart of ResourceHealthExtensions.GetAvailabilityStatusesBySubscriptionAsync.
        // Wraps GetAvailabilityStatusesAsync() and converts Pageable<AvailabilityStatusResource>
        // to Pageable<ResourceHealthAvailabilityStatus>.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ResourceHealthAvailabilityStatus> GetAvailabilityStatusesBySubscriptionAsync(string filter, string expand, CancellationToken cancellationToken = default)
        {
            AsyncPageable<AvailabilityStatusResource> inner = GetAvailabilityStatusesAsync(filter, expand, cancellationToken);
            return new MappedAsyncPageable<AvailabilityStatusResource, ResourceHealthAvailabilityStatus>(inner, r => ResourceHealthAvailabilityStatus.FromData(r.Data));
        }

        /// <summary> Lists the current availability status for all the resources in the subscription. </summary>
        // Mockable counterpart of ResourceHealthExtensions.GetAvailabilityStatusesBySubscription.
        // Sync version of GetAvailabilityStatusesBySubscriptionAsync.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ResourceHealthAvailabilityStatus> GetAvailabilityStatusesBySubscription(string filter, string expand, CancellationToken cancellationToken = default)
        {
            Pageable<AvailabilityStatusResource> inner = GetAvailabilityStatuses(filter, expand, cancellationToken);
            return new MappedPageable<AvailabilityStatusResource, ResourceHealthAvailabilityStatus>(inner, r => ResourceHealthAvailabilityStatus.FromData(r.Data));
        }

        /// <summary> Gets the collection of ResourceHealthEvents for the subscription. </summary>
        // Mockable counterpart of ResourceHealthExtensions.GetResourceHealthEvents.
        // Delegates to the generated GetEvents() method.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ResourceHealthEventCollection GetResourceHealthEvents()
        {
            return GetEvents();
        }

        /// <summary> Gets a specific service health event in the subscription. </summary>
        // Mockable counterpart of ResourceHealthExtensions.GetResourceHealthEventAsync.
        // Delegates to the generated GetEventAsync() method.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<ResourceHealthEventResource>> GetResourceHealthEventAsync(string eventTrackingId, string filter = default, string queryStartTime = default, CancellationToken cancellationToken = default)
        {
            return await GetEventAsync(eventTrackingId, filter, queryStartTime, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a specific service health event in the subscription. </summary>
        // Mockable counterpart of ResourceHealthExtensions.GetResourceHealthEvent.
        // Delegates to the generated GetEvent() method.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ResourceHealthEventResource> GetResourceHealthEvent(string eventTrackingId, string filter = default, string queryStartTime = default, CancellationToken cancellationToken = default)
        {
            return GetEvent(eventTrackingId, filter, queryStartTime, cancellationToken);
        }
    }
}