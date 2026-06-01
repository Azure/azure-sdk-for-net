// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using Azure.ResourceManager.Billing.Models;

namespace Azure.ResourceManager.Billing
{
    public partial class BillingSubscriptionAliasCollection
    {
        /// <summary> Back-compat overload for GA 1.2.2 callers that pass an Options aggregate. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<BillingSubscriptionAliasResource> GetAllAsync(BillingSubscriptionAliasCollectionGetAllOptions options, CancellationToken cancellationToken = default)
        {
            return GetAllAsync(count: options?.Count, filter: options?.Filter, includeDeleted: options?.IncludeDeleted, orderBy: options?.OrderBy, search: options?.Search, skip: options?.Skip, maxCount: options?.Top, cancellationToken: cancellationToken);
        }

        /// <summary> Back-compat overload for GA 1.2.2 callers that pass an Options aggregate. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<BillingSubscriptionAliasResource> GetAll(BillingSubscriptionAliasCollectionGetAllOptions options, CancellationToken cancellationToken = default)
        {
            return GetAll(count: options?.Count, filter: options?.Filter, includeDeleted: options?.IncludeDeleted, orderBy: options?.OrderBy, search: options?.Search, skip: options?.Skip, maxCount: options?.Top, cancellationToken: cancellationToken);
        }

        /// <summary> Back-compat parameterless overload for GA 1.2.2 callers. New MPG generator added query parameters as optional; ApiCompat treats them as new signature, so an explicit single-arg overload is required for source compat. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<BillingSubscriptionAliasResource> GetAllAsync(CancellationToken cancellationToken)
        {
            return GetAllAsync(includeDeleted: default, filter: default, orderBy: default, maxCount: default, skip: default, count: default, search: default, cancellationToken: cancellationToken);
        }

        /// <summary> Back-compat parameterless overload for GA 1.2.2 callers. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<BillingSubscriptionAliasResource> GetAll(CancellationToken cancellationToken)
        {
            return GetAll(includeDeleted: default, filter: default, orderBy: default, maxCount: default, skip: default, count: default, search: default, cancellationToken: cancellationToken);
        }
    }
}
