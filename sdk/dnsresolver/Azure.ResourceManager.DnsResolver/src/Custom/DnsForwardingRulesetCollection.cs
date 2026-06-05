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
    public partial class DnsForwardingRulesetCollection
    {
        // Backward-compat: old CreateOrUpdate took string ifMatch + string ifNoneMatch, new takes MatchConditions.
        /// <summary>
        /// Creates or updates the resource.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<DnsForwardingRulesetResource> CreateOrUpdate(WaitUntil waitUntil, string rulesetName, DnsForwardingRulesetData data, string ifMatch, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return CreateOrUpdate(waitUntil, rulesetName, data, CompatibilityRequestConditions.Create(ifMatch, ifNoneMatch), cancellationToken);
        }

        /// <summary>
        /// Asynchronously creates or updates the resource.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<DnsForwardingRulesetResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string rulesetName, DnsForwardingRulesetData data, string ifMatch, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await CreateOrUpdateAsync(waitUntil, rulesetName, data, CompatibilityRequestConditions.Create(ifMatch, ifNoneMatch), cancellationToken).ConfigureAwait(false);
        }
    }
}
