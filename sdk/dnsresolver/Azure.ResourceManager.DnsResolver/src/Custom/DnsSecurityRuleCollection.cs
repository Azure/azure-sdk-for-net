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
    public partial class DnsSecurityRuleCollection
    {
        // Backward-compat: old CreateOrUpdate took string ifMatch + string ifNoneMatch, new takes MatchConditions.
        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<DnsSecurityRuleResource> CreateOrUpdate(WaitUntil waitUntil, string dnsSecurityRuleName, DnsSecurityRuleData data, string ifMatch, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return CreateOrUpdate(waitUntil, dnsSecurityRuleName, data, default(MatchConditions), cancellationToken);
        }

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<DnsSecurityRuleResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string dnsSecurityRuleName, DnsSecurityRuleData data, string ifMatch, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await CreateOrUpdateAsync(waitUntil, dnsSecurityRuleName, data, default(MatchConditions), cancellationToken).ConfigureAwait(false);
        }
    }
}
