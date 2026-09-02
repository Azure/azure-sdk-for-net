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
    public partial class DnsSecurityRuleResource
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
        public virtual ArmOperation<DnsSecurityRuleResource> Update(WaitUntil waitUntil, DnsSecurityRulePatch patch, string ifMatch, CancellationToken cancellationToken = default)
        {
            return Update(waitUntil, patch, ifMatch != null ? new ETag(ifMatch) : default(ETag?), cancellationToken);
        }

        /// <summary>
        /// Asynchronously updates the resource.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<DnsSecurityRuleResource>> UpdateAsync(WaitUntil waitUntil, DnsSecurityRulePatch patch, string ifMatch, CancellationToken cancellationToken = default)
        {
            return await UpdateAsync(waitUntil, patch, ifMatch != null ? new ETag(ifMatch) : default(ETag?), cancellationToken).ConfigureAwait(false);
        }
    }
}
