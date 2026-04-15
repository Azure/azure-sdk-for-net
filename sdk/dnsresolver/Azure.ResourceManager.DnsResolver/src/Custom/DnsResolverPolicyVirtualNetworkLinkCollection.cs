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
    public partial class DnsResolverPolicyVirtualNetworkLinkCollection
    {
        // Backward-compat: old CreateOrUpdate took string ifMatch + string ifNoneMatch, new takes MatchConditions.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<DnsResolverPolicyVirtualNetworkLinkResource> CreateOrUpdate(WaitUntil waitUntil, string dnsResolverPolicyVirtualNetworkLinkName, DnsResolverPolicyVirtualNetworkLinkData data, string ifMatch, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return CreateOrUpdate(waitUntil, dnsResolverPolicyVirtualNetworkLinkName, data, default(MatchConditions), cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<DnsResolverPolicyVirtualNetworkLinkResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string dnsResolverPolicyVirtualNetworkLinkName, DnsResolverPolicyVirtualNetworkLinkData data, string ifMatch, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await CreateOrUpdateAsync(waitUntil, dnsResolverPolicyVirtualNetworkLinkName, data, default(MatchConditions), cancellationToken).ConfigureAwait(false);
        }
    }
}

#pragma warning restore CS1591
