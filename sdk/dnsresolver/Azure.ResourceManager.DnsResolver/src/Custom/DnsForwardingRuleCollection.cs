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
    public partial class DnsForwardingRuleCollection
    {
        // Backward-compat: old CreateOrUpdate took string ifMatch + string ifNoneMatch, new takes MatchConditions.
        /// <summary>
        /// Creates or updates the resource.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<DnsForwardingRuleResource> CreateOrUpdate(WaitUntil waitUntil, string forwardingRuleName, DnsForwardingRuleData data, string ifMatch, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return CreateOrUpdate(waitUntil, forwardingRuleName, data, CompatibilityRequestConditions.Create(ifMatch, ifNoneMatch), cancellationToken);
        }

        /// <summary>
        /// Asynchronously creates or updates the resource.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<DnsForwardingRuleResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string forwardingRuleName, DnsForwardingRuleData data, string ifMatch, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await CreateOrUpdateAsync(waitUntil, forwardingRuleName, data, CompatibilityRequestConditions.Create(ifMatch, ifNoneMatch), cancellationToken).ConfigureAwait(false);
        }
    }
}
