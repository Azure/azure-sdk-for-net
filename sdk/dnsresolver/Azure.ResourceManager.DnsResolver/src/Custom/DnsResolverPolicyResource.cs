// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS1591

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.DnsResolver.Models;

namespace Azure.ResourceManager.DnsResolver
{
    public partial class DnsResolverPolicyResource
    {
        // Backward-compat: old Delete/DeleteAsync took string ifMatch, new takes ETag? ifMatch.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation Delete(WaitUntil waitUntil, string ifMatch, CancellationToken cancellationToken = default)
        {
            return Delete(waitUntil, ifMatch != null ? new ETag(ifMatch) : default(ETag?), cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, string ifMatch, CancellationToken cancellationToken = default)
        {
            return await DeleteAsync(waitUntil, ifMatch != null ? new ETag(ifMatch) : default(ETag?), cancellationToken).ConfigureAwait(false);
        }

        // Backward-compat: old Update/UpdateAsync took string ifMatch, new takes ETag? ifMatch.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<DnsResolverPolicyResource> Update(WaitUntil waitUntil, DnsResolverPolicyPatch patch, string ifMatch, CancellationToken cancellationToken = default)
        {
            return Update(waitUntil, patch, ifMatch != null ? new ETag(ifMatch) : default(ETag?), cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<DnsResolverPolicyResource>> UpdateAsync(WaitUntil waitUntil, DnsResolverPolicyPatch patch, string ifMatch, CancellationToken cancellationToken = default)
        {
            return await UpdateAsync(waitUntil, patch, ifMatch != null ? new ETag(ifMatch) : default(ETag?), cancellationToken).ConfigureAwait(false);
        }
    }
}

#pragma warning restore CS1591
