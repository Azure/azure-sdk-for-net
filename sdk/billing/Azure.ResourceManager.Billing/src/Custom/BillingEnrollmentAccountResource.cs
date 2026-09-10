// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using Azure.ResourceManager.Billing.Models;

namespace Azure.ResourceManager.Billing
{
    // Back-compat overload for GA 1.2.2 callers that pass an Options aggregate.
    // The new MPG generator emits GetByEnrollmentAccount with individual parameters.
    public partial class BillingEnrollmentAccountResource
    {
        /// <summary> Back-compat overload for GA 1.2.2 callers that pass an Options aggregate. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<BillingSubscriptionData> GetBillingSubscriptionsAsync(BillingEnrollmentAccountResourceGetBillingSubscriptionsOptions options, CancellationToken cancellationToken = default)
        {
            return GetByEnrollmentAccountAsync(filter: options?.Filter, orderBy: options?.OrderBy, maxCount: options?.Top, skip: options?.Skip, count: options?.Count, search: options?.Search, cancellationToken: cancellationToken);
        }

        /// <summary> Back-compat overload for GA 1.2.2 callers that pass an Options aggregate. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<BillingSubscriptionData> GetBillingSubscriptions(BillingEnrollmentAccountResourceGetBillingSubscriptionsOptions options, CancellationToken cancellationToken = default)
        {
            return GetByEnrollmentAccount(filter: options?.Filter, orderBy: options?.OrderBy, maxCount: options?.Top, skip: options?.Skip, count: options?.Count, search: options?.Search, cancellationToken: cancellationToken);
        }
    }
}
