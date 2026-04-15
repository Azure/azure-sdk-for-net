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
    public partial class DnsForwardingRulesetVirtualNetworkLinkCollection
    {
        // Backward-compat: old CreateOrUpdate took string ifMatch + string ifNoneMatch, new takes MatchConditions.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<DnsForwardingRulesetVirtualNetworkLinkResource> CreateOrUpdate(WaitUntil waitUntil, string virtualNetworkLinkName, DnsForwardingRulesetVirtualNetworkLinkData data, string ifMatch, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return CreateOrUpdate(waitUntil, virtualNetworkLinkName, data, default(MatchConditions), cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<DnsForwardingRulesetVirtualNetworkLinkResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string virtualNetworkLinkName, DnsForwardingRulesetVirtualNetworkLinkData data, string ifMatch, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await CreateOrUpdateAsync(waitUntil, virtualNetworkLinkName, data, default(MatchConditions), cancellationToken).ConfigureAwait(false);
        }
    }
}

#pragma warning restore CS1591
