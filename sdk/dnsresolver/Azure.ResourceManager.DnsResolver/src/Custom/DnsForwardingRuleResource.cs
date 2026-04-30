// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.DnsResolver.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.DnsResolver
{
    [CodeGenSuppress("CreateResourceIdentifier", typeof(string), typeof(string), typeof(string), typeof(string))]
    public partial class DnsForwardingRuleResource
    {
        // Backward-compat: preserve the original `rulesetName` parameter name (the
        // generated method, driven by the resource URI template, uses `dnsForwardingRulesetName`).
        // TODO: Remove this workaround once the mgmt generator preserves previously-emitted
        // parameter names on CreateResourceIdentifier.
        /// <summary> Generate the resource identifier of a <see cref="DnsForwardingRuleResource"/> instance. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="rulesetName"> The rulesetName. </param>
        /// <param name="forwardingRuleName"> The forwardingRuleName. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string rulesetName, string forwardingRuleName)
        {
            string resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsForwardingRulesets/{rulesetName}/forwardingRules/{forwardingRuleName}";
            return new ResourceIdentifier(resourceId);
        }

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

        // Backward-compat: old non-LRO Update/UpdateAsync took string ifMatch, new takes ETag? ifMatch.
        /// <summary>
        /// Updates the resource.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DnsForwardingRuleResource> Update(DnsForwardingRulePatch patch, string ifMatch, CancellationToken cancellationToken = default)
        {
            return Update(patch, ifMatch != null ? new ETag(ifMatch) : default(ETag?), cancellationToken);
        }

        /// <summary>
        /// Asynchronously updates the resource.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DnsForwardingRuleResource>> UpdateAsync(DnsForwardingRulePatch patch, string ifMatch, CancellationToken cancellationToken = default)
        {
            return await UpdateAsync(patch, ifMatch != null ? new ETag(ifMatch) : default(ETag?), cancellationToken).ConfigureAwait(false);
        }
    }
}
