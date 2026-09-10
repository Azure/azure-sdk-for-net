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
    public partial class DnsResolverInboundEndpointCollection
    {
        // Backward-compat: old CreateOrUpdate took string ifMatch + string ifNoneMatch, new takes MatchConditions.
        /// <summary>
        /// Creates or updates the resource.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<DnsResolverInboundEndpointResource> CreateOrUpdate(WaitUntil waitUntil, string inboundEndpointName, DnsResolverInboundEndpointData data, string ifMatch, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return CreateOrUpdate(waitUntil, inboundEndpointName, data, CompatibilityRequestConditions.Create(ifMatch, ifNoneMatch), cancellationToken);
        }

        /// <summary>
        /// Asynchronously creates or updates the resource.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<DnsResolverInboundEndpointResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string inboundEndpointName, DnsResolverInboundEndpointData data, string ifMatch, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await CreateOrUpdateAsync(waitUntil, inboundEndpointName, data, CompatibilityRequestConditions.Create(ifMatch, ifNoneMatch), cancellationToken).ConfigureAwait(false);
        }
    }
}
