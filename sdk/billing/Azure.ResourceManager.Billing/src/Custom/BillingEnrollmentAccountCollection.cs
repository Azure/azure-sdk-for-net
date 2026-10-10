// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using Azure.ResourceManager.Billing.Models;

namespace Azure.ResourceManager.Billing
{
    // Back-compat overloads for GA 1.2.2 callers that pass an Options aggregate.
    // The MPG generator emits GetAll with individual query parameters; these
    // hand-written shims forward an Options instance to the generated method
    // so existing call sites keep working.
    public partial class BillingEnrollmentAccountCollection
    {
        /// <summary> Back-compat overload for GA 1.2.2 callers that pass an Options aggregate. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<BillingEnrollmentAccountResource> GetAllAsync(BillingEnrollmentAccountCollectionGetAllOptions options, CancellationToken cancellationToken = default)
        {
            return GetAllAsync(filter: options?.Filter, orderBy: options?.OrderBy, maxCount: options?.Top, skip: options?.Skip, count: options?.Count, search: options?.Search, cancellationToken: cancellationToken);
        }

        /// <summary> Back-compat overload for GA 1.2.2 callers that pass an Options aggregate. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<BillingEnrollmentAccountResource> GetAll(BillingEnrollmentAccountCollectionGetAllOptions options, CancellationToken cancellationToken = default)
        {
            return GetAll(filter: options?.Filter, orderBy: options?.OrderBy, maxCount: options?.Top, skip: options?.Skip, count: options?.Count, search: options?.Search, cancellationToken: cancellationToken);
        }
    }
}
