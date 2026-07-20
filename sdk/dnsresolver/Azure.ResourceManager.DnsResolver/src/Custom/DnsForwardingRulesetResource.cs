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
    [CodeGenSuppress("CreateResourceIdentifier", typeof(string), typeof(string), typeof(string))]
    public partial class DnsForwardingRulesetResource
    {
        // Backward-compat: preserve the original `rulesetName` parameter name (the
        // generated method, driven by the resource URI template, uses `dnsForwardingRulesetName`).
        // TODO: Remove this workaround once the mgmt generator preserves previously-emitted
        // parameter names on CreateResourceIdentifier.
        /// <summary> Generate the resource identifier of a <see cref="DnsForwardingRulesetResource"/> instance. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="rulesetName"> The rulesetName. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string rulesetName)
        {
            string resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsForwardingRulesets/{rulesetName}";
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

        // Backward-compat: old Update/UpdateAsync took string ifMatch, new takes ETag? ifMatch.
        /// <summary>
        /// Updates the resource.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<DnsForwardingRulesetResource> Update(WaitUntil waitUntil, DnsForwardingRulesetPatch patch, string ifMatch, CancellationToken cancellationToken = default)
        {
            return Update(waitUntil, patch, ifMatch != null ? new ETag(ifMatch) : default(ETag?), cancellationToken);
        }

        /// <summary>
        /// Asynchronously updates the resource.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<DnsForwardingRulesetResource>> UpdateAsync(WaitUntil waitUntil, DnsForwardingRulesetPatch patch, string ifMatch, CancellationToken cancellationToken = default)
        {
            return await UpdateAsync(waitUntil, patch, ifMatch != null ? new ETag(ifMatch) : default(ETag?), cancellationToken).ConfigureAwait(false);
        }
    }
}
