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
    public partial class DnsResolverOutboundEndpointCollection
    {
        // Backward-compat: old CreateOrUpdate took string ifMatch + string ifNoneMatch, new takes MatchConditions.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<DnsResolverOutboundEndpointResource> CreateOrUpdate(WaitUntil waitUntil, string outboundEndpointName, DnsResolverOutboundEndpointData data, string ifMatch, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return CreateOrUpdate(waitUntil, outboundEndpointName, data, default(MatchConditions), cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<DnsResolverOutboundEndpointResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string outboundEndpointName, DnsResolverOutboundEndpointData data, string ifMatch, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await CreateOrUpdateAsync(waitUntil, outboundEndpointName, data, default(MatchConditions), cancellationToken).ConfigureAwait(false);
        }
    }
}

#pragma warning restore CS1591
