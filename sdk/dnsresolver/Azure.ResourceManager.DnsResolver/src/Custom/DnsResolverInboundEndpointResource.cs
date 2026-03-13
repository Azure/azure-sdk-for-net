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
    public partial class DnsResolverInboundEndpointResource
    {
        // Backward-compat: old Delete/DeleteAsync took string ifMatch, new takes ETag? ifMatch.
        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation Delete(WaitUntil waitUntil, string ifMatch, CancellationToken cancellationToken = default)
        {
            return Delete(waitUntil, ifMatch != null ? new ETag(ifMatch) : default(ETag?), cancellationToken);
        }

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, string ifMatch, CancellationToken cancellationToken = default)
        {
            return await DeleteAsync(waitUntil, ifMatch != null ? new ETag(ifMatch) : default(ETag?), cancellationToken).ConfigureAwait(false);
        }

        // Backward-compat: old Update/UpdateAsync took string ifMatch, new takes ETag? ifMatch.
        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<DnsResolverInboundEndpointResource> Update(WaitUntil waitUntil, DnsResolverInboundEndpointPatch patch, string ifMatch, CancellationToken cancellationToken = default)
        {
            return Update(waitUntil, patch, ifMatch != null ? new ETag(ifMatch) : default(ETag?), cancellationToken);
        }

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<DnsResolverInboundEndpointResource>> UpdateAsync(WaitUntil waitUntil, DnsResolverInboundEndpointPatch patch, string ifMatch, CancellationToken cancellationToken = default)
        {
            return await UpdateAsync(waitUntil, patch, ifMatch != null ? new ETag(ifMatch) : default(ETag?), cancellationToken).ConfigureAwait(false);
        }
    }
}
