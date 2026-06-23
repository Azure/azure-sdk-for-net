// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

#pragma warning disable CS1591
namespace Azure.ResourceManager.Sql
{
    // Backward-compat: the previous AutoRest SDK had Update/UpdateAsync(WaitUntil, OutboundFirewallRuleData, CancellationToken).
    // The new TypeSpec SDK generates Update/UpdateAsync(WaitUntil, CancellationToken) since the PUT has no body.
    // Keep the old overloads hidden so existing callers don't break.
    public partial class OutboundFirewallRuleResource
    {
        /// <summary>
        /// Create a outbound firewall rule with a given name.
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> The <see cref="OutboundFirewallRuleData"/> to use. Ignored; present for backward-compatibility only. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<OutboundFirewallRuleResource>> UpdateAsync(WaitUntil waitUntil, OutboundFirewallRuleData data, CancellationToken cancellationToken = default)
        {
            return UpdateAsync(waitUntil, cancellationToken);
        }

        /// <summary>
        /// Create a outbound firewall rule with a given name.
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> The <see cref="OutboundFirewallRuleData"/> to use. Ignored; present for backward-compatibility only. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<OutboundFirewallRuleResource> Update(WaitUntil waitUntil, OutboundFirewallRuleData data, CancellationToken cancellationToken = default)
        {
            return Update(waitUntil, cancellationToken);
        }
    }
}
