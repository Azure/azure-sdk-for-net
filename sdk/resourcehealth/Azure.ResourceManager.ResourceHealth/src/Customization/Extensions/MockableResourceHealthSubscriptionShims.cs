// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.ResourceHealth.Models;

namespace Azure.ResourceManager.ResourceHealth.Mocking
{
    public partial class MockableResourceHealthSubscriptionResource
    {
        /// <summary> Lists the current availability status for all the resources in the subscription. </summary>
        // This mockable shim is required by ValidateMockingPattern, and it converts generated subscription availability items back to the GA 1.0.0 wrapper type.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ResourceHealthAvailabilityStatus> GetAvailabilityStatusesBySubscriptionAsync(string filter, string expand, CancellationToken cancellationToken = default)
        {
            AsyncPageable<AvailabilityStatusResource> inner = GetAvailabilityStatusesAsync(filter, expand, cancellationToken);
            return new AsyncPageableWrapper<AvailabilityStatusResource, ResourceHealthAvailabilityStatus>(inner, r => ResourceHealthAvailabilityStatus.FromData(r.Data));
        }

        /// <summary> Lists the current availability status for all the resources in the subscription. </summary>
        // Sync counterpart for the same mocking requirement and GA-compatible item-type conversion.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ResourceHealthAvailabilityStatus> GetAvailabilityStatusesBySubscription(string filter, string expand, CancellationToken cancellationToken = default)
        {
            Pageable<AvailabilityStatusResource> inner = GetAvailabilityStatuses(filter, expand, cancellationToken);
            return new PageableWrapper<AvailabilityStatusResource, ResourceHealthAvailabilityStatus>(inner, r => ResourceHealthAvailabilityStatus.FromData(r.Data));
        }

        /// <summary> Gets the collection of ResourceHealthEvents for the subscription. </summary>
        // This mockable shim is required because method-name compatibility extensions must delegate through a virtual Mockable* member to satisfy ValidateMockingPattern.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ResourceHealthEventCollection GetResourceHealthEvents()
        {
            return GetEvents();
        }

        /// <summary> Gets a specific service health event in the subscription. </summary>
        // Async mockable counterpart for the GA method name GetResourceHealthEventAsync, which now maps to the generated GetEventAsync method.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<ResourceHealthEventResource>> GetResourceHealthEventAsync(string eventTrackingId, string filter = default, string queryStartTime = default, CancellationToken cancellationToken = default)
        {
            return await GetEventAsync(eventTrackingId, filter, queryStartTime, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a specific service health event in the subscription. </summary>
        // Sync mockable counterpart for the GA method name GetResourceHealthEvent, which now maps to the generated GetEvent method.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ResourceHealthEventResource> GetResourceHealthEvent(string eventTrackingId, string filter = default, string queryStartTime = default, CancellationToken cancellationToken = default)
        {
            return GetEvent(eventTrackingId, filter, queryStartTime, cancellationToken);
        }
    }
}
