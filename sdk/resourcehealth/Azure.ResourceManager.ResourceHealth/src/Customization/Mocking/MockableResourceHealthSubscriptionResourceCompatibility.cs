// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure;
using Azure.Core;
using Azure.ResourceManager.ResourceHealth;
using Azure.ResourceManager.ResourceHealth.Models;

namespace Azure.ResourceManager.ResourceHealth.Mocking
{
    // This file preserves the GA subscription availability status mockable API names
    // and forwards them to the generated model-returning pageable results.
    public partial class MockableResourceHealthSubscriptionResource
    {
        /// <summary> Lists current availability status for resources in the subscription. </summary>
        public virtual AsyncPageable<ResourceHealthAvailabilityStatus> GetAvailabilityStatusResourcesBySubscriptionAsync(string filter = default, string expand = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = CreateRequestContext(cancellationToken);
            return new GetAvailabilityStatusResourcesBySubscriptionAsyncCollectionResult(AvailabilityStatusesRestClient, Id.SubscriptionId, filter, expand, context);
        }

        /// <summary> Lists current availability status for resources in the subscription. </summary>
        public virtual Pageable<ResourceHealthAvailabilityStatus> GetAvailabilityStatusResourcesBySubscription(string filter = default, string expand = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = CreateRequestContext(cancellationToken);
            return new GetAvailabilityStatusResourcesBySubscriptionCollectionResult(AvailabilityStatusesRestClient, Id.SubscriptionId, filter, expand, context);
        }

        /// <summary> Lists current availability status for resources in the subscription. </summary>
        public virtual AsyncPageable<ResourceHealthAvailabilityStatus> GetAvailabilityStatusesBySubscriptionAsync(string filter = default, string expand = default, CancellationToken cancellationToken = default)
        {
            return GetAvailabilityStatusResourcesBySubscriptionAsync(filter, expand, cancellationToken);
        }

        /// <summary> Lists current availability status for resources in the subscription. </summary>
        public virtual Pageable<ResourceHealthAvailabilityStatus> GetAvailabilityStatusesBySubscription(string filter = default, string expand = default, CancellationToken cancellationToken = default)
        {
            return GetAvailabilityStatusResourcesBySubscription(filter, expand, cancellationToken);
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
