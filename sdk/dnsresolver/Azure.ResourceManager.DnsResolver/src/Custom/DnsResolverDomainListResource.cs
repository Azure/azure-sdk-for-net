// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.DnsResolver.Models;

namespace Azure.ResourceManager.DnsResolver
{
    public partial class DnsResolverDomainListResource
    {
        // Backward-compat: old Delete/DeleteAsync took string ifMatch, new takes ETag? ifMatch.
        /// <summary>
        /// Deletes the resource.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation Delete(WaitUntil waitUntil, string ifMatch, CancellationToken cancellationToken = default)
        {
            return Delete(waitUntil, ifMatch != null ? new ETag(ifMatch) : default(ETag?), cancellationToken);
        }

        /// <summary>
        /// Asynchronously deletes the resource.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, string ifMatch, CancellationToken cancellationToken = default)
        {
            return await DeleteAsync(waitUntil, ifMatch != null ? new ETag(ifMatch) : default(ETag?), cancellationToken).ConfigureAwait(false);
        }

        // Backward-compat: old Update/UpdateAsync took string ifMatch, new takes ETag? ifMatch.
        /// <summary>
        /// Updates the resource.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<DnsResolverDomainListResource> Update(WaitUntil waitUntil, DnsResolverDomainListPatch patch, string ifMatch, CancellationToken cancellationToken = default)
        {
            return Update(waitUntil, patch, ifMatch != null ? new ETag(ifMatch) : default(ETag?), cancellationToken);
        }

        /// <summary>
        /// Asynchronously updates the resource.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<DnsResolverDomainListResource>> UpdateAsync(WaitUntil waitUntil, DnsResolverDomainListPatch patch, string ifMatch, CancellationToken cancellationToken = default)
        {
            return await UpdateAsync(waitUntil, patch, ifMatch != null ? new ETag(ifMatch) : default(ETag?), cancellationToken).ConfigureAwait(false);
        }

        // Backward-compat: old Bulk/BulkAsync took string ifMatch + string ifNoneMatch, new takes MatchConditions.
        /// <summary>
        /// Executes the bulk operation for the resource.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<DnsResolverDomainListResource> Bulk(WaitUntil waitUntil, DnsResolverDomainListBulk dnsResolverDomainListBulk, string ifMatch, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return Bulk(waitUntil, dnsResolverDomainListBulk, CompatibilityRequestConditions.Create(ifMatch, ifNoneMatch), cancellationToken);
        }

        /// <summary>
        /// Asynchronously executes the bulk operation for the resource.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<DnsResolverDomainListResource>> BulkAsync(WaitUntil waitUntil, DnsResolverDomainListBulk dnsResolverDomainListBulk, string ifMatch, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await BulkAsync(waitUntil, dnsResolverDomainListBulk, CompatibilityRequestConditions.Create(ifMatch, ifNoneMatch), cancellationToken).ConfigureAwait(false);
        }
    }
}
