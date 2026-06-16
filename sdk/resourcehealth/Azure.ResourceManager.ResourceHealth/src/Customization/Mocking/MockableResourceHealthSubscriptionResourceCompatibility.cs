// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure;
using Azure.ResourceManager.ResourceHealth.Models;

namespace Azure.ResourceManager.ResourceHealth.Mocking
{
    public partial class MockableResourceHealthSubscriptionResource
    {
        /// <summary> Lists current availability status for resources in the subscription. </summary>
        public virtual AsyncPageable<ResourceHealthAvailabilityStatus> GetAvailabilityStatusesBySubscriptionAsync(string filter = default, string expand = default, CancellationToken cancellationToken = default)
        {
            return new AsyncPageableWrapper<AvailabilityStatusResource, ResourceHealthAvailabilityStatus>(
                GetAvailabilityStatusResourcesBySubscriptionAsync(filter, expand, cancellationToken),
                resource => ResourceHealthAvailabilityStatus.FromData(resource.Data));
        }

        /// <summary> Lists current availability status for resources in the subscription. </summary>
        public virtual Pageable<ResourceHealthAvailabilityStatus> GetAvailabilityStatusesBySubscription(string filter = default, string expand = default, CancellationToken cancellationToken = default)
        {
            return new PageableWrapper<AvailabilityStatusResource, ResourceHealthAvailabilityStatus>(
                GetAvailabilityStatusResourcesBySubscription(filter, expand, cancellationToken),
                resource => ResourceHealthAvailabilityStatus.FromData(resource.Data));
        }
    }
}
