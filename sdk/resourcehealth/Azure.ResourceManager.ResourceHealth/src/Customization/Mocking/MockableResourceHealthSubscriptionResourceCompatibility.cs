// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure;
using Azure.Core;
using Azure.ResourceManager.ResourceHealth;
using Azure.ResourceManager.ResourceHealth.Models;

namespace Azure.ResourceManager.ResourceHealth.Mocking
{
    public partial class MockableResourceHealthSubscriptionResource
    {
        /// <summary> Lists current availability status for resources in the subscription. </summary>
        public virtual AsyncPageable<AvailabilityStatusResource> GetAvailabilityStatusResourcesBySubscriptionAsync(string filter = default, string expand = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = CreateRequestContext(cancellationToken);
            return new AsyncPageableWrapper<ResourceHealthAvailabilityStatusData, AvailabilityStatusResource>(
                new GetAvailabilityStatusResourcesBySubscriptionAsyncCollectionResult(AvailabilityStatusesRestClient, Id.SubscriptionId, filter, expand, context),
                data => new AvailabilityStatusResource(Client, data));
        }

        /// <summary> Lists current availability status for resources in the subscription. </summary>
        public virtual Pageable<AvailabilityStatusResource> GetAvailabilityStatusResourcesBySubscription(string filter = default, string expand = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = CreateRequestContext(cancellationToken);
            return new PageableWrapper<ResourceHealthAvailabilityStatusData, AvailabilityStatusResource>(
                new GetAvailabilityStatusResourcesBySubscriptionCollectionResult(AvailabilityStatusesRestClient, Id.SubscriptionId, filter, expand, context),
                data => new AvailabilityStatusResource(Client, data));
        }

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

        private static RequestContext CreateRequestContext(CancellationToken cancellationToken)
        {
            return new RequestContext
            {
                CancellationToken = cancellationToken
            };
        }
    }
}
